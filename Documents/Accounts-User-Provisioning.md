# Accounts user provisioning: Windows domain and application access

This guide records the access paths observed on `IBN-SERVER` and `IBN-SERVER\KIZEN` on 29 September 2026. It explains the current configuration; confirm live AD and SQL membership before each provisioning change because administrators can change them independently.

## How access is granted

Accounts uses separate Windows and application identities:

1. A user signs in to Windows with their domain account, such as `IBN-SINA\username`.
2. The Accounts SQL connection uses Windows integrated authentication in the IBN-SERVER configuration. SQL Server receives the Windows identity or a Windows group in that identity's token; it does not authenticate using the Accounts application password. The data layer opens the configured `ISPDATA` connection ([DB.vb](../DataLayer/AdoNet/DB.vb), [GlobalVariables.vb](../Libraries/GlobalFuncNSub/GlobalVariables.vb)). A protected connection file, if provisioned on a workstation, can override the configured ISPDATA connection; check the identity SQL actually sees.
3. Separately, Accounts checks the username and password against the application `dbo.User` table and applies the user's application security group and security level ([ServiceLogin.vb](../ServicesLayer/Services/ServiceLogin.vb), [UserPresenter.vb](../PresentationLayer/Presenters/UserPresenter.vb)). An Accounts user record does not itself grant Windows or SQL access.

### Current ISPDATA Windows-group mapping

The observed AD nesting is:

```text
Domain user -> Domain Users -> IBN-SINA\AATM-Accounts-Users -> ISPDATA database user / Windows group
```

Active Directory Users and Computers showed `Domain Users` as a member of `AATM-Accounts-Users`. SQL Server's `xp_logininfo` resolved a domain user's permission path through `IBN-SINA\AATM-Accounts-Users`, confirming that the nested membership is recognized by SQL Server.

On ISPDATA, `IBN-SINA\AATM-Accounts-Users` belongs to `db_datareader` and `db_datawriter` and has `CONNECT` on the database plus `EXECUTE` on the `dbo` schema. This permits broad table read/write access and execution of `dbo` procedures outside the Accounts UI. The application security group does not limit these SQL permissions.

**Provisioning impact:** a normal domain user who is a member of `Domain Users` inherits the ISPDATA access above. The KizenClinic and BioTime access groups also contain `Domain Users`, so a new domain user inherits those database permissions too. Do not add or remove users from these groups without reviewing the domain-wide effect. `Authenticated Users` is a separate Windows well-known principal; the verified access paths use `Domain Users` nested in the `AATM-Accounts-*` groups.

### KizenClinic on `IBN-SERVER\KIZEN`

The configured KIZEN connection targets `KizenClinic`; the Accounts Kizen import uses `Db("KIZEN")` ([KizenCreditSalesImportService.vb](../Accounts/ServiceLayer/KizenCreditSalesImportService.vb)), and the report printer selects integrated authentication for Kizen reports ([CrystalReportPrinter.vb](../Libraries/CrystalReportsHelper/CrystalReportPrinter.vb)). A protected KIZEN connection file can override the configured string on a workstation ([ProtectedConnectionStringBootstrap.vb](../Accounts/Security/ProtectedConnectionStringBootstrap.vb)).

The AD group `IBN-SINA\AATM-Accounts-Kizen-Users` contains `Domain Users` plus three individually listed user accounts. Therefore, domain users in `Domain Users` inherit the group's KizenClinic access. Yousef is in `Domain Users`, so this is his expected AD membership path as well. An AD/SQL administrator should confirm the resolved path on the KIZEN instance because the inspection account could not execute `xp_logininfo` there.

The SQL group has `db_datareader` and `CONNECT`, plus `EXECUTE` on the `dbo` schema. It also has direct `ALTER`, `INSERT`, and `UPDATE` grants on `dbo.IBLabResult` and `dbo.VisitAnalysesData`; `dbo.IBLabResult` additionally has direct `SELECT` and `VIEW DEFINITION` grants. I found no `db_datawriter` membership for this group. The direct grants allow writes/schema changes on those named tables; `db_datareader` and schema `EXECUTE` extend read/procedure access beyond those two tables.

### BioTime on `IBN-SERVER`

The configured BIOTIME connection targets the `BioTime` database with integrated authentication ([app.config](../Accounts/app.config)). A protected BIOTIME connection override is no longer loaded. Crystal reports also use integrated authentication ([CrystalReportPrinter.vb](../Libraries/CrystalReportsHelper/CrystalReportPrinter.vb)); confirm the active Windows identity for report sessions.

The AD group `IBN-SINA\AATM-Accounts-BioTime-Users` contains `Domain Users`. SQL Server resolved Yousef's permission path through this group. The group has `db_datareader` and `CONNECT`, plus `EXECUTE` on the `dbo` schema. I found no `db_datawriter` membership for this group, so its assigned roles provide broad reads and procedure execution, not general table writes.

BioTime also has separate SQL and Windows principals with stronger roles, including principals in `db_owner` and service users in `db_datawriter`. Do not use those identities for ordinary domain users; confirm the exact login with `ORIGINAL_LOGIN()` for the relevant application or report session.

### IGroupClinic connection and reports

The configured `IGROUPCLINIC` connection uses integrated authentication. IGroup data access and report code now use the current Windows identity; IGroup and BioTime no longer use protected connection overrides or app-configured SQL report credentials. The generic `UID` and `PWD` settings remain for the default ISPDATA report path.

## Add a user

### 1. Create or enable the Windows domain account

An authorized domain administrator should create the account in the correct organizational unit, or enable the existing account, using the organization's naming, password, and account-lifecycle policies. Domain user accounts normally receive `Domain Users` as their primary group. Because that group is nested in the ISPDATA, KizenClinic, and BioTime access groups described above, the user inherits those SQL permissions; no per-user SQL login was needed for the confirmed ISPDATA and BioTime paths. KizenClinic inheritance is expected from AD nesting but should be confirmed on the KIZEN instance by an authorized administrator.

In **Active Directory Users and Computers** (or the organization's approved AD administration tool):

1. Select the approved organizational unit and create the user with the required logon name and initial password, or open the existing user and enable it.
2. Follow the organization's password and account-expiration policy. Do not copy the demonstration account's settings automatically.
3. Check **Member Of**. `Domain Users` is normally the user's primary group. Confirm the relevant `Domain Users` nesting for `AATM-Accounts-Users`, `AATM-Accounts-Kizen-Users`, and `AATM-Accounts-BioTime-Users`. Do not add a user directly to these groups as a substitute for following the access policy.

Do not add the user to administrative AD or SQL groups as a workaround. Add any additional groups, such as `PU-Accounts`, only when their purpose and required access are confirmed by the responsible administrator.

### 2. Create the Accounts application user

After the Windows identity can reach the application/database, an Accounts administrator can open **Masters > Security > Users** ([MainForm.vb](../Accounts/PresentationLayer/Views/Forms/MainForm.vb)). Create a separate application account and:

- Set `UserName` to the agreed Accounts login name. It can match the Windows logon name, but it remains a separate credential.
- Set an application password; do not reuse the user's Windows/domain password.
- Assign the least-privileged `SecurityGroup` that matches the user's job. The live example `Accountant` is a business role, not a Windows or SQL group.
- Set the user `Active` and select the appropriate employee record and security level where applicable.
- Save, then have the user sign in to Accounts with the application username/password.

Use **Masters > Security > Security Groups** to review the application's visible/editable features for a role. Do not assign an administrator-level application role unless separately approved.

### 3. Verify the access path

An AD/SQL administrator can check the domain account's group membership and confirm SQL's resolved Windows-group path with the matching instance command. The KIZEN instance may require a SQL administrator identity permitted to execute `xp_logininfo`:

```sql
EXEC master..xp_logininfo 'IBN-SINA\username', 'all';
```

Use `IBN-SERVER` for ISPDATA and BioTime; use `IBN-SERVER\KIZEN` for KizenClinic. Results should include the applicable `AATM-Accounts-*` group. To confirm a real SQL session's identity, run this through that session or have a DBA inspect it:

```sql
SELECT ORIGINAL_LOGIN() AS OriginalLogin,
       SUSER_SNAME() AS CurrentLogin,
       USER_NAME() AS DatabaseUser,
       DB_NAME() AS DatabaseName;
```

Then verify the user can open Accounts and has only the intended application features. Do not use a `sysadmin` session to validate ordinary-user access.

## Disable access when a user leaves or changes roles

- Disable the domain account through the organization's AD process. Do not remove users from the `Domain Users` primary group as an ordinary offboarding step.
- Deactivate the Accounts user record or change its application security group as appropriate.
- Review any other group or SQL-login paths assigned to that person. Disabling the AD account prevents new Windows-authenticated connections, but existing sessions may need to be closed.

## Security notes and limits

- The current `Domain Users` nesting gives every member SQL access beyond the Accounts UI: ISPDATA reader/writer access; KizenClinic broad reads and `dbo` procedure execution, plus table-specific write/schema grants on `IBLabResult` and `VisitAnalysesData`; and BioTime broad reads and `dbo` procedure execution. The database owners should review whether this domain-wide access is intended and replace it with narrower groups if least-privilege access is required.
- The application password is not the SQL password. The current application password implementation uses legacy SHA-1-based hashing, and the new-user save flow initially writes the submitted value before a follow-up hash update. Use a unique temporary application password and do not reuse a domain password; prioritize fixing the hashing and save flow.
- Machine-protected ISPDATA or KIZEN connection files may cause a workstation to use a different SQL identity from the standard configuration. BIOTIME and IGROUPCLINIC use the configured integrated-auth connections. Confirm the actual runtime SQL identity before concluding which login is used.
- This guide does not include credentials. Never put passwords or full connection strings in this document.
