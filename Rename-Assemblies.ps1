# DRY RUN: $apply = $false (only prints planned changes)
$apply = $true

# Map old project (folder / current AssemblyName) to new AssemblyName / RootNamespace
$map = @{
  "CBaseControlsLibrary"   = "AATM.Platform.UI.BaseControls"
  "BaseControlsLibrary"    = "AATM.Platform.UI.Controls"
  "HelperLibraries"        = "AATM.Platform.Foundation.Utilities"
  "GlobalFuncNSub"         = "AATM.Platform.Core"
  "ErrorsAndEvents"        = "AATM.Platform.Diagnostics"
  "MessagingLibrary"       = "AATM.Platform.Messaging"
  "MessageBoxManager"      = "AATM.Platform.UI.MessageBox"
  "Localization"           = "AATM.Platform.Localization"
  "LocalizationUtilities"  = "AATM.Platform.Localization.Utilities"
  "GlobalResources"        = "AATM.Platform.Resources"
  "CrystalReportsHelper"   = "AATM.Platform.Reporting.Crystal"
  "Forms"                  = "AATM.Platform.Presentation.Forms"
  "Views"                  = "AATM.Platform.Presentation.Views"
  "Presenters"             = "AATM.Platform.Presentation.Presenters"
  "Models"                 = "AATM.Platform.Presentation.Models"
  "Events"                 = "AATM.Platform.Presentation.Events"
}

# For VB: choose blank root (recommended). Set to $true if you want root = assembly name.
$useAssemblyNameAsRootNamespace = $false

Get-ChildItem -Recurse -Include *.vbproj,*.csproj | ForEach-Object {
  $projFile = $_.FullName
  $projName = [IO.Path]::GetFileNameWithoutExtension($_.Name)
  if (-not $map.ContainsKey($projName)) { return }

  $newName = $map[$projName]
  [xml]$xml = Get-Content $projFile
  $pg = $xml.Project.PropertyGroup | Select-Object -First 1
  $dirty = $false

  # AssemblyName
  if ($pg.AssemblyName) {
    if ($pg.AssemblyName -ne $newName) {
      Write-Host "[AssemblyName] $projName -> $newName"
      $pg.AssemblyName = $newName
      $dirty = $true
    }
  } else {
    $n = $xml.CreateElement("AssemblyName")
    $n.InnerText = $newName
    $pg.AppendChild($n) | Out-Null
    Write-Host "[AssemblyName-ADD] $projName -> $newName"
    $dirty = $true
  }

  # VB RootNamespace handling
  if ($projFile.ToLower().EndsWith(".vbproj")) {
    $targetRoot = if ($useAssemblyNameAsRootNamespace) { $newName } else { "" }
    if ($pg.RootNamespace) {
      if ($pg.RootNamespace -ne $targetRoot) {
        Write-Host "[RootNamespace] $projName -> '$targetRoot'"
        $pg.RootNamespace = $targetRoot
        $dirty = $true
      }
    } elseif ($targetRoot -ne "") {
      $rn = $xml.CreateElement("RootNamespace")
      $rn.InnerText = $targetRoot
      $pg.AppendChild($rn) | Out-Null
      Write-Host "[RootNamespace-ADD] $projName -> $targetRoot"
      $dirty = $true
    }
  }

  if ($dirty -and $apply) {
    $xml.Save($projFile)
  }
}

Write-Host "`nDry run complete. Set `$apply = `$true and rerun to apply."