# Daily Employee Punch Audit Report

Create the Crystal report file here:

`Accounts\Reports\BioTime\Daily Employee Punch Audit Report.rpt`

Suggested report title:

`Daily Employee Punch Audit Report`

Recommended data source:

`dbo.custom_att_DailyEmployeePunchAudit_Crystal`

The report is registered without an application query form, so Crystal should prompt for these report parameters:

- `BeginningDate`
- `EndingDate`

Optional report parameter:

- `EmpCode` String, blank/null means all employees

The wrapper maps the report application's standard parameters to the audit procedure:

- `BeginningDate` -> `custom_att_GetDailySchedulePunchAudit.@BeginningDate`
- `EndingDate` -> `custom_att_GetDailySchedulePunchAudit.@EndDate`
- `EmpCode` -> `custom_att_GetDailySchedulePunchAudit.@EmpCode`

Recommended report columns:

- `Date`
- `emp_code`
- `emp_code_name`
- `EffectiveScheduleAlias`
- `ScheduledIn`
- `ScheduledOut`
- `EffectivePunchIn1`
- `EffectivePunchOut1`
- `EffectivePunchIn2`
- `EffectivePunchOut2`
- `AllRawPunches`
- `AttendanceStatus`
- `WorkedHours`
- `AnomalyFlag`
- `SchedulePunchCheck`

After saving the `.rpt`, run `Daily Employee Punch Audit Report - Report Registration.sql` against `ISPDATA`.
