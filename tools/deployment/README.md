# Accounts ClickOnce deployment

These scripts automate the Accounts ClickOnce application release while keeping local publishing separate from production deployment.

They do not publish a DACPAC, modify database data, or deploy external Crystal Reports.

## Publish and validate locally

The simplest method is to double-click `Publish-Accounts.cmd`, enter the four-part version, and choose whether the release is mandatory.

The equivalent PowerShell command from the repository root is:

```powershell
powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File .\tools\deployment\Publish-AccountsClickOnce.ps1 -Version 1.0.0.8
```

The script:

- validates the ignored live configuration profile;
- temporarily activates the live profile;
- publishes `Accounts.vbproj` in Release to `Publish\Accounts_1_0_0_8_staging`;
- verifies the version, update provider, desktop shortcut, pre-start update check, payload, and live ISPDATA targets; and
- restores the original `Accounts\app.config`, including when publishing fails.

Add `-RequiredUpdate` when clients must not be allowed to skip the version:

```powershell
powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File .\tools\deployment\Publish-AccountsClickOnce.ps1 -Version 1.0.0.8 -RequiredUpdate
```

The staging directory must not already exist. This prevents an old and new publication from being mixed accidentally.

## Deploy the verified package

Review the staged package, then run:

```powershell
powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File .\tools\deployment\Deploy-AccountsClickOnce.ps1 -Version 1.0.0.8
```

The deployment script:

- only accepts `\\IBN-SERVER\ISP\COAccounts` as the production destination;
- refuses an equal or older version;
- displays the source, destination, current version, new version, and backup path;
- requires the exact confirmation `DEPLOY 1.0.0.8`;
- backs up the current `COAccounts` folder;
- copies and hashes the new version payload;
- replaces `setup.exe`;
- promotes `Accounts.application` last; and
- verifies the live package and configuration.

Preview the production actions without copying anything:

```powershell
powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File .\tools\deployment\Deploy-AccountsClickOnce.ps1 -Version 1.0.0.8 -WhatIf
```

## Double-click launchers

`Publish-Accounts.cmd` prompts for the version and whether the update is mandatory. `Deploy-Accounts.cmd` prompts for the staged version. Both invoke the corresponding PowerShell script with an execution-policy override scoped to that process. The PowerShell scripts remain the source of the validation and deployment logic.

## Separate release items

- Database schema changes must use the separately authorized DACPAC workflow and database backup.
- External Crystal Reports must be backed up and copied separately to the configured report share.
- New workstations should install using `setup.exe`. Existing ClickOnce installations use their generated shortcut and deployment provider.

## Workstation rollout

ClickOnce installs Accounts into a per-user application cache. Do not run the installer as `SYSTEM` and do not treat one installation as covering every user of a workstation.

Use a dedicated domain Group Policy Object (GPO), pilot it against a test OU, and limit it to the security group whose users need Accounts. The production source is:

```text
\\IBN-SERVER\ISP\COAccounts\setup.exe
```

The share and NTFS permissions must grant users read and execute access while allowing writes only to the deployment administrators. Never copy the signing PFX or its password to the share, SYSVOL, or a workstation.

### Mandatory permission preflight

The preflight on 2026-09-26 found that the `ISP` share grants `Everyone` full share access and that `COAccounts` inherited NTFS `Modify` permission for `Authenticated Users`. The `COAccounts` folder was then protected from inheritance and hardened to the access described below. The parent `ISP` share and folder were not changed. Recheck the effective ACL before every rollout so a later administrative change does not reintroduce user write access.

Use a dedicated deployment share or protect only the `COAccounts` folder from the permissive parent ACL. The current effective access is:

- `Read & execute` for the four existing `AATM-Accounts-*-Users` groups that use this application.
- `Full control` for `SYSTEM` and a named, restricted deployment-administrators group.
- No `Write`, `Modify`, or `Full control` for `Everyone`, `Authenticated Users`, ordinary domain users, or the application-user groups.

Do not change the permissions on the parent `\\IBN-SERVER\ISP` share or folder as part of this task because other applications may rely on them. Back up the current `COAccounts` ACL, apply the new ACL first to a test copy, and verify both installation and release deployment before protecting the live folder.

Read-only checks from an authorized administrator workstation:

```powershell
(Get-Acl -LiteralPath '\\IBN-SERVER\ISP\COAccounts').Access |
    Select-Object IdentityReference, FileSystemRights, AccessControlType, IsInherited

Get-AuthenticodeSignature -LiteralPath '\\IBN-SERVER\ISP\COAccounts\setup.exe' |
    Select-Object Status, @{Name='Thumbprint'; Expression={$_.SignerCertificate.Thumbprint}}
```

### 1. Trust the publisher certificate

The public certificate is stored on the release administrator's workstation at:

```text
C:\SecureBackups\AATM\ClickOnceSigning\AATM-Software-Publishing.cer
```

Verify it before importing it into Group Policy:

```text
Subject:    CN=AATM Software Publishing, O=AATM
Thumbprint: 1A175C7C0E61C34D09B6827C5E3D8738C562A831
SHA-256:    602A0DA5E55B67B4ACBA4C0D9AE02656EDD963C7488BCFDC0450FA98CE117909
Valid to:   2031-09-24
```

In the GPO editor, import only the public `.cer` under both of these computer stores:

1. `Computer Configuration > Policies > Windows Settings > Security Settings > Public Key Policies > Trusted Root Certification Authorities`
2. `Computer Configuration > Policies > Windows Settings > Security Settings > Public Key Policies > Trusted Publishers`

The private `.pfx` remains in the restricted backup directory and password manager.

### 2A. Create an installer shortcut

Use this when users should decide when to install Accounts. In the same GPO, add:

```text
Computer Configuration
  Preferences
    Windows Settings
      Shortcuts
```

Create or update the shortcut with these values:

```text
Name:           Install AATM Accounts
Location:       All Users Desktop
Target type:    File System Object
Target path:    \\IBN-SERVER\ISP\COAccounts\setup.exe
Start in:       \\IBN-SERVER\ISP\COAccounts
Icon file path: \\IBN-SERVER\ISP\COAccounts\setup.exe
```

Use item-level targeting for the target workstation group. After every intended user has installed the application, change the preference action to `Delete` or unlink the shortcut item. The ClickOnce publication has `CreateDesktopShortcut=true`, so a separate Accounts application shortcut is created for each user after installation.

### 2B. Launch installation automatically at user logon

This is the recommended choice when all targeted users must receive Accounts. It is more reliable than asking each person to open the installer shortcut, although Windows may still show the normal ClickOnce installation interface.

1. Copy the signed `Install-AccountsClickOnce.ps1` to a read-only deployment path, preferably `\\IBN-SERVER\ISP\COAccounts\Install-AccountsClickOnce.ps1` or a GPO-controlled SYSVOL path.
2. Verify that the copied script has a valid Authenticode signature with thumbprint `1A175C7C0E61C34D09B6827C5E3D8738C562A831`.
3. Under `User Configuration > Preferences > Control Panel Settings > Scheduled Tasks`, create an `Update` task for Windows Vista or later.
4. Run it only when the user is logged on, as `%LogonDomain%\%LogonUser%`, with a 30-second logon delay.
5. Use this action:

```text
Program:   %SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe
Arguments: -NoLogo -NoProfile -NonInteractive -WindowStyle Hidden -ExecutionPolicy AllSigned -File "\\IBN-SERVER\ISP\COAccounts\Install-AccountsClickOnce.ps1"
```

Do not enable `Run in logged-on user's security context` on the preference item's Common tab; specify the user on the task's General tab. Scope the task to the Accounts users group. The bootstrap exits immediately when it finds the approved installed ClickOnce shortcut; otherwise, it verifies the live version, publisher certificate, manifest, and `setup.exe` before launching the installer.

The bootstrap log is written per user to:

```text
%LOCALAPPDATA%\AATM\Logs\AccountsClickOnceBootstrap.log
```

### Pilot verification

On a non-production pilot workstation:

1. Run `gpupdate /force`, then restart the workstation so the computer certificate policy is applied.
2. Confirm the certificate exists in both `Local Computer\Trusted Root Certification Authorities` and `Local Computer\Trusted Publishers` with the expected thumbprint.
3. Sign in as a targeted ordinary user and confirm the installer shortcut or logon task appears.
4. Install Accounts and verify its ClickOnce shortcut opens version `1.0.0.10` or later.
5. Sign in as a second targeted user on the same workstation and confirm that user receives a separate ClickOnce installation.
6. Confirm a non-targeted user or workstation does not receive the shortcut or task.
7. Review the bootstrap log and the ClickOnce installation prompt before expanding the GPO beyond the pilot OU.

Removing the GPO stops future shortcut/task delivery but does not uninstall existing per-user ClickOnce installations. Uninstall those from each affected user's Windows Apps/Programs interface only when removal is explicitly required.
