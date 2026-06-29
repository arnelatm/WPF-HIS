# Periodic Attendance Report

Create the Crystal report file here:

`Accounts\Reports\BioTime\Periodic Attendance Report.rpt`

Use this data source:

`dbo.custom_att_PeriodicAttendanceReport_Crystal`

The wrapper procedure maps the report application's standard parameters to the existing attendance procedure:

- `BeginningDate` -> `custom_att_PeriodicAttendanceReport.@DateFrom`
- `EndingDate` -> `custom_att_PeriodicAttendanceReport.@DateTo`

Recommended report parameters:

- `BeginningDate` String in `yyyy-mm-dd` format
- `EndingDate` String in `yyyy-mm-dd` format
- `ReportTitle` String
- `EstablishmentName` String
- `Language` String

Recommended detail columns:

- `emp_code`
- `First Name`
- `Department`
- `Total Days`
- `Rest Days`
- `Holiday`
- `Required Work Days`
- `Actual Required Days Present`
- `Absence Days`
- `Present %`
- `Absent %`
- `Ave. Worked Hours Per Day`
- `Actual Late Minutes`
- `Actual Early Out Minutes`
- `Total OT Hours`
- `Total Excess Hrs.`
- `No. of Days with Incomplete Punch in or Out`
- `Total Regular (H)`
- `Total Worked (H)`
- `Total Late In Min.`
- `Total Late In Hrs.`
- `Early Out in Min.`
- `Early Out in Hrs.`
- `Total Excess Min.`

After saving the `.rpt`, run `Periodic Attendance Report - Report Registration.sql` against `ISPDATA`.
