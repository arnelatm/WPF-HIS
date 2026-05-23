param(
    [string]$Server = "ibn-server",
    [string]$Database = "BioTime",
    [datetime]$DateFrom = "2026-05-01",
    [datetime]$DateTo = "2026-05-17",
    [Nullable[int]]$EmpID = $null
)

$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $MyInvocation.MyCommand.Path
$procedurePath = Join-Path $root "dbo\Stored Procedures\Custom_att_ProcessMonthlyPayrollFacts.sql"

if (-not (Test-Path -LiteralPath $procedurePath)) {
    throw "Procedure file not found: $procedurePath"
}

$procedureSql = Get-Content -Raw -LiteralPath $procedurePath
$testProcedureSql = $procedureSql.Replace(
    "CREATE PROCEDURE [dbo].[Custom_att_ProcessMonthlyPayrollFacts]",
    "CREATE PROCEDURE [dbo].[Custom_att_ProcessMonthlyPayrollFacts_Test]"
)

if ($testProcedureSql -eq $procedureSql) {
    throw "Could not rename procedure in source SQL. Check the CREATE PROCEDURE line."
}

$createTestProcedureScript = @"
IF OBJECT_ID(N'dbo.Custom_att_ProcessMonthlyPayrollFacts_Test', N'P') IS NOT NULL
    DROP PROCEDURE dbo.Custom_att_ProcessMonthlyPayrollFacts_Test;
GO
$testProcedureSql
GO
"@

$empIdSql = if ($null -eq $EmpID) { "NULL" } else { $EmpID.ToString() }
$dateFromSql = $DateFrom.ToString("yyyy-MM-dd")
$dateToSql = $DateTo.ToString("yyyy-MM-dd")

$compareScript = @"
SET NOCOUNT ON;
SET XACT_ABORT ON;

DECLARE @DateFrom date = '$dateFromSql';
DECLARE @DateTo date = '$dateToSql';
DECLARE @EmpID int = $empIdSql;
DECLARE @StartedAt datetime2(3);
DECLARE @OldElapsedMs int;
DECLARE @NewElapsedMs int;

DECLARE @OldControl TABLE
(
    date_from date,
    date_to date,
    emp_id_filter int NULL,
    fact_rows_processed int,
    total_worked_hours decimal(10,2),
    total_ot_hours decimal(10,2),
    total_absence_hours decimal(10,2),
    total_late_minutes decimal(10,2),
    total_early_out_minutes decimal(10,2)
);

DECLARE @NewControl TABLE
(
    date_from date,
    date_to date,
    emp_id_filter int NULL,
    fact_rows_processed int,
    total_worked_hours decimal(10,2),
    total_ot_hours decimal(10,2),
    total_absence_hours decimal(10,2),
    total_late_minutes decimal(10,2),
    total_early_out_minutes decimal(10,2)
);

DECLARE @OldFact TABLE
(
    emp_id int,
    att_date date,
    daily_status varchar(50) NULL,
    attendance_status varchar(50) NULL,
    anomaly_flag varchar(100) NULL,
    needs_payroll_review bit NULL,
    first_clock_in datetime NULL,
    last_clock_out datetime NULL,
    recomputed_worked_minutes decimal(10,2) NULL,
    ot_minutes decimal(10,2) NULL,
    required_scheduled_hours decimal(10,2) NULL,
    worked_hours decimal(10,2) NULL,
    ot_hours decimal(10,2) NULL,
    schedule_label varchar(100) NULL,
    late_minutes decimal(10,2) NULL,
    early_out_minutes decimal(10,2) NULL,
    recomputed_absence_hours decimal(10,2) NULL,
    comp_leave_eligible_flag int NULL,
    comp_leave_minutes decimal(10,2) NULL,
    comp_leave_hours decimal(10,2) NULL,
    excess_minutes decimal(10,2) NULL,
    excess_hours decimal(10,2) NULL,
    shortfall_minutes decimal(10,2) NULL,
    shortfall_hours decimal(10,2) NULL,
    reconciliation_status varchar(50) NULL,
    reconciliation_variance_minutes decimal(10,2) NULL,
    work_gap_minutes decimal(10,2) NULL,
    actual_late_minutes decimal(10,2) NULL,
    actual_early_out_minutes decimal(10,2) NULL
);

DECLARE @NewFact TABLE
(
    emp_id int,
    att_date date,
    daily_status varchar(50) NULL,
    attendance_status varchar(50) NULL,
    anomaly_flag varchar(100) NULL,
    needs_payroll_review bit NULL,
    first_clock_in datetime NULL,
    last_clock_out datetime NULL,
    recomputed_worked_minutes decimal(10,2) NULL,
    ot_minutes decimal(10,2) NULL,
    required_scheduled_hours decimal(10,2) NULL,
    worked_hours decimal(10,2) NULL,
    ot_hours decimal(10,2) NULL,
    schedule_label varchar(100) NULL,
    late_minutes decimal(10,2) NULL,
    early_out_minutes decimal(10,2) NULL,
    recomputed_absence_hours decimal(10,2) NULL,
    comp_leave_eligible_flag int NULL,
    comp_leave_minutes decimal(10,2) NULL,
    comp_leave_hours decimal(10,2) NULL,
    excess_minutes decimal(10,2) NULL,
    excess_hours decimal(10,2) NULL,
    shortfall_minutes decimal(10,2) NULL,
    shortfall_hours decimal(10,2) NULL,
    reconciliation_status varchar(50) NULL,
    reconciliation_variance_minutes decimal(10,2) NULL,
    work_gap_minutes decimal(10,2) NULL,
    actual_late_minutes decimal(10,2) NULL,
    actual_early_out_minutes decimal(10,2) NULL
);

BEGIN TRY
    SET @StartedAt = SYSDATETIME();
    BEGIN TRANSACTION;

    INSERT INTO @OldControl
    EXEC dbo.Custom_att_ProcessMonthlyPayrollFacts
        @DateFrom = @DateFrom,
        @DateTo = @DateTo,
        @EmpID = @EmpID;

    INSERT INTO @OldFact
    SELECT
        emp_id,
        att_date,
        daily_status,
        attendance_status,
        anomaly_flag,
        needs_payroll_review,
        first_clock_in,
        last_clock_out,
        recomputed_worked_minutes,
        ot_minutes,
        required_scheduled_hours,
        worked_hours,
        ot_hours,
        schedule_label,
        late_minutes,
        early_out_minutes,
        recomputed_absence_hours,
        comp_leave_eligible_flag,
        comp_leave_minutes,
        comp_leave_hours,
        excess_minutes,
        excess_hours,
        shortfall_minutes,
        shortfall_hours,
        reconciliation_status,
        reconciliation_variance_minutes,
        work_gap_minutes,
        actual_late_minutes,
        actual_early_out_minutes
    FROM dbo.custom_att_fact_DailyAttendance
    WHERE att_date BETWEEN @DateFrom AND @DateTo
      AND (@EmpID IS NULL OR emp_id = @EmpID);

    ROLLBACK TRANSACTION;
    SET @OldElapsedMs = DATEDIFF(MILLISECOND, @StartedAt, SYSDATETIME());

    SET @StartedAt = SYSDATETIME();
    BEGIN TRANSACTION;

    INSERT INTO @NewControl
    EXEC dbo.Custom_att_ProcessMonthlyPayrollFacts_Test
        @DateFrom = @DateFrom,
        @DateTo = @DateTo,
        @EmpID = @EmpID;

    INSERT INTO @NewFact
    SELECT
        emp_id,
        att_date,
        daily_status,
        attendance_status,
        anomaly_flag,
        needs_payroll_review,
        first_clock_in,
        last_clock_out,
        recomputed_worked_minutes,
        ot_minutes,
        required_scheduled_hours,
        worked_hours,
        ot_hours,
        schedule_label,
        late_minutes,
        early_out_minutes,
        recomputed_absence_hours,
        comp_leave_eligible_flag,
        comp_leave_minutes,
        comp_leave_hours,
        excess_minutes,
        excess_hours,
        shortfall_minutes,
        shortfall_hours,
        reconciliation_status,
        reconciliation_variance_minutes,
        work_gap_minutes,
        actual_late_minutes,
        actual_early_out_minutes
    FROM dbo.custom_att_fact_DailyAttendance
    WHERE att_date BETWEEN @DateFrom AND @DateTo
      AND (@EmpID IS NULL OR emp_id = @EmpID);

    ROLLBACK TRANSACTION;
    SET @NewElapsedMs = DATEDIFF(MILLISECOND, @StartedAt, SYSDATETIME());

    SELECT
        @DateFrom AS date_from,
        @DateTo AS date_to,
        @EmpID AS emp_id_filter,
        @OldElapsedMs AS old_elapsed_ms,
        @NewElapsedMs AS new_elapsed_ms,
        @OldElapsedMs - @NewElapsedMs AS saved_ms;

    SELECT 'OldControl' AS result_set, * FROM @OldControl;
    SELECT 'NewControl' AS result_set, * FROM @NewControl;

    SELECT 'OldMinusNew' AS diff_type, *
    FROM @OldFact
    EXCEPT
    SELECT 'OldMinusNew' AS diff_type, *
    FROM @NewFact;

    SELECT 'NewMinusOld' AS diff_type, *
    FROM @NewFact
    EXCEPT
    SELECT 'NewMinusOld' AS diff_type, *
    FROM @OldFact;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    THROW;
END CATCH;
"@

$dropTestProcedureScript = @"
IF OBJECT_ID(N'dbo.Custom_att_ProcessMonthlyPayrollFacts_Test', N'P') IS NOT NULL
    DROP PROCEDURE dbo.Custom_att_ProcessMonthlyPayrollFacts_Test;
"@

function Invoke-SqlCmdText {
    param([string]$SqlText)

    $tempFile = [System.IO.Path]::GetTempFileName()
    try {
        Set-Content -LiteralPath $tempFile -Value $SqlText -Encoding UTF8
        & sqlcmd -S $Server -E -C -d $Database -b -i $tempFile
        if ($LASTEXITCODE -ne 0) {
            throw "sqlcmd failed with exit code $LASTEXITCODE"
        }
    }
    finally {
        Remove-Item -LiteralPath $tempFile -Force -ErrorAction SilentlyContinue
    }
}

try {
    Write-Host "Creating temporary test procedure dbo.Custom_att_ProcessMonthlyPayrollFacts_Test..."
    Invoke-SqlCmdText $createTestProcedureScript

    Write-Host "Running old vs new comparison in rollback transactions..."
    Invoke-SqlCmdText $compareScript
}
finally {
    Write-Host "Dropping temporary test procedure dbo.Custom_att_ProcessMonthlyPayrollFacts_Test..."
    Invoke-SqlCmdText $dropTestProcedureScript
}
