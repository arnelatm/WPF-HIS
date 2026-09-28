# Accounts ClickOnce deployment

These scripts automate the Accounts ClickOnce application release while keeping local publishing separate from production deployment.

The user-facing ClickOnce product name is `Clinic Information System`, published by `AATM Software`. Internal technical identifiers, including the `Accounts` project, assembly, manifest, deployment path, and administrative GPO/task names, remain unchanged for compatibility.

They do not publish a DACPAC, modify database data, or deploy external Crystal Reports.

## Publish and validate locally

The simplest method is to double-click `Publish-Accounts.cmd`, enter the four-part version, and choose whether the release is mandatory.

Before publishing, review `git status --short` and the diffs for the application and referenced projects. ClickOnce packages the current working-tree build, including tracked edits, so confirm that each included change belongs in the release. Read the version from the live `Accounts.application` manifest and choose a higher four-part version. The latest verified release was `1.0.0.15`; use that only as a reference, not as a substitute for checking the live manifest.

Manifest signing requires the approved code-signing certificate with its private key in the release user's `Cert:\CurrentUser\My` store. The scripts use thumbprint `1A175C7C0E61C34D09B6827C5E3D8738C562A831`; do not copy the private key or password to the share. Run publishing and deployment from an authorized release session that can access this certificate and `\\IBN-SERVER\ISP\COAccounts`.

The equivalent PowerShell command from the repository root is:

```powershell
powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File .\tools\deployment\Publish-AccountsClickOnce.ps1 -Version 1.0.0.16
```

The script:

- validates `Accounts\app - ibn-server.config` as the ignored live configuration profile;
- temporarily activates the live profile;
- publishes `Accounts.vbproj` in Release to a version-specific staging directory, such as `Publish\Accounts_1_0_0_16_staging`;
- verifies the version, update provider, desktop shortcut, pre-start update check, payload, and live ISPDATA targets; and
- restores the original `Accounts\app.config`, including when publishing fails.

The publish script runs `Clean` before `Publish`. Keep this ordering: an incremental Release build can otherwise reuse an older `Accounts.exe.config.deploy` and package a test-server connection even while the live profile is temporarily active. The staged config is validated before the script succeeds. Review connection targets without printing credentials; they must point to `IBN-SERVER.ISPDATA`.

Add `-RequiredUpdate` when clients must not be allowed to skip the version:

```powershell
powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File .\tools\deployment\Publish-AccountsClickOnce.ps1 -Version 1.0.0.16 -RequiredUpdate
```

The staging directory must not already exist. This prevents an old and new publication from being mixed accidentally.

## Deploy the verified package

Review the staged package, then run:

```powershell
powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File .\tools\deployment\Deploy-AccountsClickOnce.ps1 -Version 1.0.0.16
```

The deployment script:

- only accepts `\\IBN-SERVER\ISP\COAccounts` as the production destination;
- refuses an equal or older version;
- displays the source, destination, current version, new version, and backup path;
- requires the exact confirmation `DEPLOY 1.0.0.16`;
- backs up the current `COAccounts` folder;
- copies and hashes the new version payload;
- replaces `setup.exe`;
- promotes `Accounts.application` last; and
- verifies the live package and configuration.

Preview the production actions without copying anything:

```powershell
powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File .\tools\deployment\Deploy-AccountsClickOnce.ps1 -Version 1.0.0.16 -WhatIf
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
- `Read & execute` for the legacy server-local `IBN-SERVER\kizen_user` account because the existing `Map ISP Drive Z–IBN-APP` logon script establishes the SMB session with that identity. It must not have write access. Remove this exception after the shared-credential drive mapping is replaced.
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

Use item-level targeting for the target workstation group. After every intended user has installed the application, change the preference action to `Delete` or unlink the shortcut item. The ClickOnce publication has `CreateDesktopShortcut=true`, so a separate `Clinic Information System` shortcut is created for each user after installation.

### 2B. Launch installation automatically at user logon

This is the recommended choice when all targeted users must receive Clinic Information System. It is more reliable than asking each person to open the installer shortcut, although Windows may still show the normal ClickOnce installation interface.

1. Copy the signed `Install-AccountsClickOnce.ps1` to a read-only deployment path. Production uses `\\ibn-sina.local\NETLOGON\AATM\Install-AccountsClickOnce.ps1`.
2. Verify that the copied script has a valid Authenticode signature with thumbprint `1A175C7C0E61C34D09B6827C5E3D8738C562A831`.
3. Under `User Configuration > Preferences > Control Panel Settings > Scheduled Tasks`, create an `Update` task for Windows Vista or later.
4. Run it only when the user is logged on, as `%LogonDomain%\%LogonUser%`, with a 30-second logon delay.
5. Use this action:

```text
Program:   %SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe
Arguments: -NoLogo -NoProfile -NonInteractive -WindowStyle Hidden -ExecutionPolicy AllSigned -File "\\ibn-sina.local\NETLOGON\AATM\Install-AccountsClickOnce.ps1"
```

Do not enable `Run in logged-on user's security context` on the preference item's Common tab; specify the user on the task's General tab. The bootstrap exits immediately when it finds the approved installed ClickOnce shortcut; otherwise, it verifies the live version, publisher certificate, manifest, and `setup.exe` before launching the installer.

The production user GPO is `AATM - Accounts ClickOnce Install`. It is linked to `Domain-Users/Standard-Users` and `Domain-Users/Privileged-Users`, and security-filtered to `Domain Users`. Its scheduled-task preference source is `Gpo-AccountsClickOnce-ScheduledTasks.xml`. The task is named `AATM Accounts ClickOnce Bootstrap`, runs as the logged-on user with `InteractiveToken`, is hidden, and starts 30 seconds after logon. `Remove this item when it is no longer applied` is enabled so the task is removed when the user leaves policy scope. The previous RunOnce policy setting was removed after the task was verified on `MARKETING-PC` as `IBN-SINA\ali` and on `ARDEPT` as `IBN-SINA\yousef`.

The companion computer GPO is `AATM - Accounts ClickOnce Trust`. It is linked only to the non-server workstation OUs `Workstations`, `Laptops`, `USB-Blocked`, `USB-Allowed-If-Authorized`, and `USB-CD Allowed-If-Authorized`, and security-filtered to `Domain Computers`.

The bootstrap log is written per user to:

```text
%LOCALAPPDATA%\AATM\Logs\AccountsClickOnceBootstrap.log
```

### Rollout verification

On a non-production pilot workstation:

1. Run `gpupdate /force`, then restart the workstation so the computer certificate policy is applied.
2. Confirm the certificate exists in both `Local Computer\Trusted Root Certification Authorities` and `Local Computer\Trusted Publishers` with the expected thumbprint.
3. Sign in as a targeted ordinary user and confirm the installer shortcut or logon task appears.
4. Install Clinic Information System and verify its ClickOnce shortcut opens version `1.0.0.14` or later.
5. Sign in as a second targeted user on the same workstation and confirm that user receives a separate ClickOnce installation.
6. Confirm a non-targeted user or workstation does not receive the shortcut or task.
7. Review the bootstrap log and the ClickOnce installation prompt before expanding or changing the GPO scope.

Removing the GPO stops future shortcut/task delivery but does not uninstall existing per-user ClickOnce installations. Uninstall those from each affected user's Windows Apps/Programs interface only when removal is explicitly required.
