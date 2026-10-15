#requires -Version 3.0
# Read-only share/NTFS/service-identity diagnostics. Writes only a unique audit JSON file.
$ErrorActionPreference='Stop'
if ([Environment]::MachineName -ne 'IBN-SERVER') { throw 'Unexpected machine.' }
$observations=New-Object 'System.Collections.Generic.List[object]'
function Probe([string]$Name,[scriptblock]$Action) {
    try { $data=& $Action; $observations.Add([pscustomobject]@{Check=$Name;Success=$true;Data=$data}) }
    catch { $observations.Add([pscustomobject]@{Check=$Name;Success=$false;Error=$_.Exception.Message}) }
}
function Describe-Acl([string]$Path) {
    $acl=Get-Acl -LiteralPath ('Microsoft.PowerShell.Core\FileSystem::'+$Path) -ErrorAction Stop
    return [pscustomobject]@{Path=$Path;Owner=$acl.Owner;InheritanceProtected=$acl.AreAccessRulesProtected;Rules=@($acl.Access | Select-Object @{Name='Identity';Expression={$_.IdentityReference.Value}},FileSystemRights,AccessControlType,IsInherited,InheritanceFlags,PropagationFlags)}
}
$unc='\\ibn-server\Ibn-Server-SqlBackup'
$manual=Join-Path $unc 'ISPDATA_Log.trn'
$may='E:\SQLBackupFallback\ISPDataBackup\ISPData_20260505.BAK'
Probe 'AgentIdentity' { [Security.Principal.WindowsIdentity]::GetCurrent().Name }
Probe 'CurrentProvider' { (Get-Location).Provider.Name }
$share=$null
# Local mapping independently verified from the server share registry.
Probe 'ShareLocalPath' { $script:share=[pscustomobject]@{Name='Ibn-Server-SqlBackup';Path='F:\Ibn-Server-SqlBackup'}; $share }
Probe 'SharePermissions' {
    $setting=Get-WmiObject -Class Win32_LogicalShareSecuritySetting -Filter "Name='Ibn-Server-SqlBackup'" -ErrorAction Stop
    $d=$setting.GetSecurityDescriptor()
    if($d.ReturnValue -ne 0){throw ('Share descriptor return code '+$d.ReturnValue)}
    @($d.Descriptor.DACL | ForEach-Object {[pscustomobject]@{Trustee=($_.Trustee.Domain+'\'+$_.Trustee.Name);SID=$_.Trustee.SIDString;AccessMask=$_.AccessMask;AceType=$_.AceType}})
}
Probe 'ShareNtfsAclViaUNC' { Describe-Acl $unc }
if ($null -ne $share) {
    Probe 'ShareNtfsAclViaLocalPath' { Describe-Acl $share.Path }
    Probe 'ISPDATAFilesInShareLocalFolder' { @(Get-ChildItem -LiteralPath $share.Path -File -Force -ErrorAction Stop | Where-Object {$_.Name -like 'ISPDATA*'} | Select-Object Name,Length,LastWriteTimeUtc) }
    Probe 'ManualLogLocalExists' { [IO.File]::Exists((Join-Path $share.Path 'ISPDATA_Log.trn')) }
}
Probe 'ManualLogAgentTestPath' { Test-Path -LiteralPath $manual -PathType Leaf -ErrorAction Stop }
Probe 'ManualLogFileSystemProviderTestPath' { Test-Path -LiteralPath ('Microsoft.PowerShell.Core\FileSystem::'+$manual) -PathType Leaf -ErrorAction Stop }
Probe 'ManualLogDotNetExists' { [IO.File]::Exists($manual) }
Probe 'ManualLogRead' { $s=[IO.File]::Open($manual,[IO.FileMode]::Open,[IO.FileAccess]::Read,[IO.FileShare]::ReadWrite); try { [pscustomobject]@{Length=$s.Length;FirstByte=$s.ReadByte()} } finally {$s.Dispose()} }
Probe 'ShareAgentDirectoryRead' { @(Get-ChildItem -LiteralPath ('Microsoft.PowerShell.Core\FileSystem::'+$unc) -File -ErrorAction Stop | Where-Object {$_.Name -like 'ISPDATA*'} | Select-Object Name,Length) }
Probe 'MayBackupFile' { Get-Item -LiteralPath $may -Force -ErrorAction Stop | Select-Object FullName,Length,Attributes,LastWriteTimeUtc }
Probe 'MayBackupAcl' { Describe-Acl $may }
Probe 'FallbackDirectoryAcl' { Describe-Acl 'E:\SQLBackupFallback\ISPDataBackup' }
# Confirm requested roots and inherited access on the cleanup subfolders.
foreach ($folder in @('F:\ISPDataBackup','F:\ISPDataBackup\Logs','F:\ISPDataBackup\Monthly','E:\SQLBackupFallback\ISPDataBackup','E:\SQLBackupFallback\ISPDataBackup\Logs','E:\SQLBackupFallback\ISPDataBackup\Monthly','E:\SQLBackupFallback\ISPDataBackup\Audit','F:\Ibn-Server-SqlBackup')) {
    if (-not [IO.Directory]::Exists($folder)) { Probe ('FolderMissing:'+ $folder) { throw 'Directory absent or not visible to Agent.' }; continue }
    Probe ('FolderAcl:'+ $folder) { Describe-Acl $folder }
    Probe ('FolderRead:'+ $folder) { [pscustomobject]@{Path=$folder;Files=@(Get-ChildItem -LiteralPath $folder -File -Force -ErrorAction Stop).Count} }
    Probe ('SampleBackupRead:'+ $folder) {
        $sample=Get-ChildItem -LiteralPath $folder -File -Force -ErrorAction Stop | Where-Object {$_.Extension -in @('.bak','.trn')} | Select-Object -First 1
        if ($null -eq $sample) { [pscustomobject]@{Path=$folder;NoBackupFileToTest=$true} }
        else {
            $s=[IO.File]::Open($sample.FullName,[IO.FileMode]::Open,[IO.FileAccess]::Read,[IO.FileShare]::ReadWrite)
            try { [pscustomobject]@{Path=$sample.FullName;Length=$s.Length;FirstByte=$s.ReadByte();Acl=(Describe-Acl $sample.FullName)} } finally { $s.Dispose() }
        }
    }
}
$path='E:\SQLBackupFallback\ISPDataBackup\Audit\AccessCheck_'+(Get-Date).ToString('yyyyMMdd_HHmmss')+'_'+[guid]::NewGuid().ToString('N')+'.json'
$json=ConvertTo-Json -InputObject $observations.ToArray() -Depth 10
$stream=New-Object IO.FileStream $path,([IO.FileMode]::CreateNew),([IO.FileAccess]::Write),([IO.FileShare]::Read)
$writer=New-Object IO.StreamWriter $stream,(New-Object Text.UTF8Encoding $false)
try {$writer.Write($json);$writer.Flush();$writer.BaseStream.Flush($true)} finally {$writer.Dispose()}
Write-Output ('Read-only access results: '+$path)
