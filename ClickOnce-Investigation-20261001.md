# Clinic Information System shortcut investigation

Date: 2026-10-01. PC: ISPADMIN2. User: IBN-SINA\Administrator.

## Confirmed launch restriction

The interactive user is the built-in Administrator (SID ends in -500). Windows 10 build 19045 is installed. EnableLUA is 1; FilterAdministratorToken is absent (Admin Approval Mode for the built-in Administrator is not enabled).

The existing desktop Explorer process is PID 26360, session 5. CreateExplorerShellUnelevatedTask is running. A read-only helper launched through the existing desktop shell (FindWindowSW with SWC_DESKTOP) had Explorer PID 26360 as its parent.

The helper's native Windows job queries and harmless CreateProcess test returned:

- InJob: true
- LimitFlags: 0
- JOB_OBJECT_LIMIT_BREAKAWAY_OK: false
- JOB_OBJECT_LIMIT_SILENT_BREAKAWAY_OK: false
- CreateProcess with CREATE_BREAKAWAY_FROM_JOB: failed
- Windows error: 5 (Access denied)

The full compact probe result is saved in ClickOnce-ExplorerJobProbe.json.

Microsoft documents the same built-in Administrator/Explorer job restriction as a cause of silent ClickOnce launch failures. The loader tries to start outside the job; this restricted Explorer job prevents that. If dfsvc.exe has already been started through another launch path, shortcuts can reuse it temporarily. When the loader is no longer running, the Explorer shortcut again cannot start it. This explains the temporary improvement following Setup without requiring a new publish or deployment.

Sources:

- [Microsoft Support: ClickOnce applications may not launch from the built-in Administrator account on Windows 10](https://support.microsoft.com/en-us/servicing/dotnetframework/2020/05/clickonce-applications-may-not-launch-from-the-built-in-administrator-account-on-windows-10)
- [Microsoft Japan Developer Support: silent ClickOnce launch and job restrictions](https://jpdscore.github.io/blog/deployment/nothing-happens-when-attempting-to-launch-clickonce-apps/)

## Application and deployment checks

- Installed version and live deployment: 1.0.0.24.
- Live deployment manifest last write: 2026-09-29 17:09:08 +03:00.
- Desktop and Start Menu shortcut targets: file://ibn-server/ISP/COAccounts/Accounts.application with the expected Accounts identity and public key token.
- Both shortcut timestamps remain 2026-09-29 10:33:24; length 306 bytes.
- Windows appref-ms association invokes dfshim.dll,ShOpenVerbShortcut.
- Both current cached Accounts.exe copies exactly match the network Accounts.exe.deploy, SHA256 79FB6E72F54F170AFB89238F9F9DB1C62C2F652E03795343CE20304E9EEAE961.
- Cached executable launched directly and opened a responsive Clinic Information System window without running Setup.
- ClickOnce service and Explorer are in the same interactive session (5).
- Two ClickOnce identities differ only by ISP/isp URL casing. Both are marked PreparedForExecution and HasRunBefore. Their payload hashes are identical. These duplicate records were a preliminary lead, not an established cause.

## Remedy and investigation limits

Microsoft recommends using a different user account or enabling Admin Approval Mode for the built-in Administrator account. A policy change should be followed by signing out and back in so Explorer is recreated under the correct user token. A domain-managed policy should be changed at its owning policy rather than relying on a local setting that a later policy refresh may overwrite.

No Setup, reinstall, cache deletion, registration repair, UAC policy change, source code change, build, publish, or deployment was performed during this investigation. The application was launched for diagnosis using its existing shortcut and then its existing cached executable. Original successful/failed baseline files were preserved. Oversized intermediate JSON files were removed because PowerShell expanded provider metadata during serialization; their useful findings are summarized here.

## Authorized remedy applied afterward

At the user's request, FilterAdministratorToken was set to DWORD 1 on ISPADMIN2 at 2026-10-01 13:24:57 +03:00, enabling Admin Approval Mode for the built-in Administrator account. The registry value and type were read back and verified. EnableLUA remains 1. The prior setting was absent and is recorded in ClickOnce-AdminApprovalMode-Before.json; the applied state is recorded in ClickOnce-AdminApprovalMode-Applied.json.

The computer-policy report could not be generated: gpresult returned Invalid class / Access Denied. Consequently, domain-policy ownership was not established and future domain-policy refresh could override a local setting. No domain policy was changed.

The current Explorer process retains its existing restricted job until the user signs out and signs in again. Sign-out was not initiated because it would interrupt the user's open work. Final verification requires a new sign-in followed by launching the existing desktop shortcut while dfsvc.exe is initially stopped, and repeating after the loader has exited. No Setup is needed for this verification.
