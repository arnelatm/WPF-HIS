CREATE VIEW [dbo].[custom_att_vw_AttendanceAccuracyIssues]
AS
WITH FactBase AS
(
    SELECT
        f.emp_id,
        e.emp_code,
        LTRIM(RTRIM(ISNULL(e.first_name, '') + ' ' + ISNULL(e.last_name, ''))) AS employee_name,
        e.department_id,
        d.dept_code,
        d.dept_name,
        ae.group_id,
        ag.code AS group_code,
        ag.name AS group_name,
        f.att_date,
        f.daily_status,
        f.attendance_status,
        f.anomaly_flag,
        f.needs_payroll_review,
        f.first_clock_in,
        f.last_clock_out,
        f.required_scheduled_hours,
        f.worked_hours,
        f.recomputed_worked_minutes,
        f.recomputed_absence_hours,
        f.reconciliation_status,
        f.reconciliation_variance_minutes,
        f.work_gap_minutes,
        f.[Leaves],
        es.emp_id AS schedule_emp_id,
        es.effective_schedule_source,
        es.base_schedule_source,
        es.effective_required_work_minutes,
        es.resolved_is_off_day,
        interval_totals.interval_worked_minutes,
        punch_totals.punch_count
    FROM dbo.custom_att_fact_DailyAttendance f
    LEFT JOIN dbo.personnel_employee e
        ON e.id = f.emp_id
    LEFT JOIN dbo.personnel_department d
        ON d.id = e.department_id
    LEFT JOIN dbo.att_attemployee ae
        ON ae.emp_id = f.emp_id
    LEFT JOIN dbo.att_attgroup ag
        ON ag.id = ae.group_id
    LEFT JOIN dbo.custom_att_fnd_EffectiveScheduleResolved es
        ON es.emp_id = f.emp_id
       AND es.att_date = f.att_date
    OUTER APPLY
    (
        SELECT SUM(wi.worked_minutes) AS interval_worked_minutes
        FROM dbo.custom_att_fnd_WorkedIntervals wi
        WHERE wi.emp_id = f.emp_id
          AND wi.work_date = f.att_date
    ) interval_totals
    OUTER APPLY
    (
        SELECT COUNT_BIG(*) AS punch_count
        FROM dbo.custom_att_fnd_NormalizedPunches np
        WHERE np.emp_id = f.emp_id
          AND np.work_date = f.att_date
    ) punch_totals
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM dbo.personnel_resign r
        WHERE r.employee_id = f.emp_id
          AND f.att_date > r.resign_date
    )
)
SELECT
    fb.emp_id,
    fb.emp_code,
    fb.employee_name,
    fb.department_id,
    fb.dept_code,
    fb.dept_name,
    fb.group_id,
    fb.group_code,
    fb.group_name,
    fb.att_date,
    CAST('Schedule' AS varchar(30)) AS issue_area,
    CAST('MissingSchedule' AS varchar(60)) AS issue_code,
    CAST(
        CASE
            WHEN ISNULL(fb.punch_count, 0) > 0
              OR ISNULL(fb.worked_hours, 0) > 0
            THEN 'Critical'
            ELSE 'High'
        END AS varchar(20)
    ) AS severity,
    CAST('Employee attendance fact has no resolved schedule for the date.' AS varchar(250)) AS issue_message,
    CAST('Resolved schedule' AS varchar(100)) AS expected_value,
    CAST('No schedule' AS varchar(100)) AS actual_value,
    CAST(1 AS bit) AS needs_payroll_block
FROM FactBase fb
WHERE fb.schedule_emp_id IS NULL
  AND
  (
      ISNULL(fb.required_scheduled_hours, 0) > 0
      OR ISNULL(fb.worked_hours, 0) > 0
      OR ISNULL(fb.punch_count, 0) > 0
      OR fb.daily_status = 'RegularDay'
  )

UNION ALL

SELECT
    fb.emp_id,
    fb.emp_code,
    fb.employee_name,
    fb.department_id,
    fb.dept_code,
    fb.dept_name,
    fb.group_id,
    fb.group_code,
    fb.group_name,
    fb.att_date,
    CAST('Schedule' AS varchar(30)) AS issue_area,
    CAST('InheritedSchedule' AS varchar(60)) AS issue_code,
    CAST('Medium' AS varchar(20)) AS severity,
    CAST('Employee is using an inherited group or department schedule.' AS varchar(250)) AS issue_message,
    CAST('Employee or temporary schedule when duty is employee-specific' AS varchar(100)) AS expected_value,
    CAST(ISNULL(fb.effective_schedule_source, 'No schedule') AS varchar(100)) AS actual_value,
    CAST(0 AS bit) AS needs_payroll_block
FROM FactBase fb
WHERE fb.effective_schedule_source IN ('Group', 'Department')

UNION ALL

SELECT
    sm.emp_id,
    sm.emp_code,
    sm.employee_name,
    sm.department_id,
    sm.dept_code,
    sm.dept_name,
    sm.group_id,
    sm.group_code,
    sm.group_name,
    sm.att_date,
    CAST('Schedule' AS varchar(30)) AS issue_area,
    CAST(sm.mismatch_type AS varchar(60)) AS issue_code,
    CAST(sm.severity AS varchar(20)) AS severity,
    CAST('Actual punch window is far from the resolved schedule window.' AS varchar(250)) AS issue_message,
    CAST(
        CONVERT(varchar(16), sm.effective_scheduled_in_datetime, 120)
        + ' - '
        + CONVERT(varchar(16), sm.effective_scheduled_out_datetime, 120)
        AS varchar(100)
    ) AS expected_value,
    CAST(
        ISNULL(CONVERT(varchar(16), sm.first_clock_in, 120), 'Missing IN')
        + ' - '
        + ISNULL(CONVERT(varchar(16), sm.last_clock_out, 120), 'Missing OUT')
        AS varchar(100)
    ) AS actual_value,
    CAST(1 AS bit) AS needs_payroll_block
FROM dbo.Custom_att_vw_ScheduleMismatchEmployees sm

UNION ALL

SELECT
    fb.emp_id,
    fb.emp_code,
    fb.employee_name,
    fb.department_id,
    fb.dept_code,
    fb.dept_name,
    fb.group_id,
    fb.group_code,
    fb.group_name,
    fb.att_date,
    CAST('Schedule' AS varchar(30)) AS issue_area,
    CAST('RequiredHoursMismatch' AS varchar(60)) AS issue_code,
    CAST('High' AS varchar(20)) AS severity,
    CAST('Fact required hours do not match the resolved schedule required hours.' AS varchar(250)) AS issue_message,
    CAST(CAST(ISNULL(fb.effective_required_work_minutes, 0) / 60.0 AS decimal(10,2)) AS varchar(100)) AS expected_value,
    CAST(CAST(ISNULL(fb.required_scheduled_hours, 0) AS decimal(10,2)) AS varchar(100)) AS actual_value,
    CAST(1 AS bit) AS needs_payroll_block
FROM FactBase fb
WHERE fb.schedule_emp_id IS NOT NULL
  AND ABS(
        ISNULL(fb.required_scheduled_hours, 0)
        - CAST(ISNULL(fb.effective_required_work_minutes, 0) / 60.0 AS decimal(10,2))
      ) >= 0.02

UNION ALL

SELECT
    fb.emp_id,
    fb.emp_code,
    fb.employee_name,
    fb.department_id,
    fb.dept_code,
    fb.dept_name,
    fb.group_id,
    fb.group_code,
    fb.group_name,
    fb.att_date,
    CAST('Fact' AS varchar(30)) AS issue_area,
    CAST('WorkedMinutesMismatch' AS varchar(60)) AS issue_code,
    CAST('High' AS varchar(20)) AS severity,
    CAST('Fact worked minutes do not match summed worked intervals.' AS varchar(250)) AS issue_message,
    CAST(CAST(ISNULL(fb.interval_worked_minutes, 0) AS decimal(10,2)) AS varchar(100)) AS expected_value,
    CAST(CAST(ISNULL(fb.recomputed_worked_minutes, 0) AS decimal(10,2)) AS varchar(100)) AS actual_value,
    CAST(1 AS bit) AS needs_payroll_block
FROM FactBase fb
WHERE ABS(ISNULL(fb.interval_worked_minutes, 0) - ISNULL(fb.recomputed_worked_minutes, 0)) > 5

UNION ALL

SELECT
    fb.emp_id,
    fb.emp_code,
    fb.employee_name,
    fb.department_id,
    fb.dept_code,
    fb.dept_name,
    fb.group_id,
    fb.group_code,
    fb.group_name,
    fb.att_date,
    CAST('Schedule' AS varchar(30)) AS issue_area,
    CAST('RegularDayZeroRequiredHours' AS varchar(60)) AS issue_code,
    CAST('Critical' AS varchar(20)) AS severity,
    CAST('Regular work day has zero required scheduled hours.' AS varchar(250)) AS issue_message,
    CAST('Required hours greater than zero' AS varchar(100)) AS expected_value,
    CAST(CAST(ISNULL(fb.required_scheduled_hours, 0) AS decimal(10,2)) AS varchar(100)) AS actual_value,
    CAST(1 AS bit) AS needs_payroll_block
FROM FactBase fb
WHERE fb.daily_status = 'RegularDay'
  AND ISNULL(fb.required_scheduled_hours, 0) = 0

UNION ALL

SELECT
    fb.emp_id,
    fb.emp_code,
    fb.employee_name,
    fb.department_id,
    fb.dept_code,
    fb.dept_name,
    fb.group_id,
    fb.group_code,
    fb.group_name,
    fb.att_date,
    CAST('Schedule' AS varchar(30)) AS issue_area,
    CAST('NonRegularDayHasRequiredHours' AS varchar(60)) AS issue_code,
    CAST('High' AS varchar(20)) AS severity,
    CAST('Rest day, holiday, or non-regular day has required scheduled hours.' AS varchar(250)) AS issue_message,
    CAST('Required hours equal zero' AS varchar(100)) AS expected_value,
    CAST(CAST(ISNULL(fb.required_scheduled_hours, 0) AS decimal(10,2)) AS varchar(100)) AS actual_value,
    CAST(1 AS bit) AS needs_payroll_block
FROM FactBase fb
WHERE ISNULL(fb.daily_status, '') <> 'RegularDay'
  AND ISNULL(fb.required_scheduled_hours, 0) > 0

UNION ALL

SELECT
    fb.emp_id,
    fb.emp_code,
    fb.employee_name,
    fb.department_id,
    fb.dept_code,
    fb.dept_name,
    fb.group_id,
    fb.group_code,
    fb.group_name,
    fb.att_date,
    CAST('Punch' AS varchar(30)) AS issue_area,
    CAST(ISNULL(fb.anomaly_flag, 'UnknownPunchAnomaly') AS varchar(60)) AS issue_code,
    CAST('Critical' AS varchar(20)) AS severity,
    CAST('Attendance fact has a missing or incomplete punch anomaly.' AS varchar(250)) AS issue_message,
    CAST('Complete IN/OUT punch pair' AS varchar(100)) AS expected_value,
    CAST(ISNULL(fb.anomaly_flag, 'Unknown') AS varchar(100)) AS actual_value,
    CAST(1 AS bit) AS needs_payroll_block
FROM FactBase fb
WHERE fb.anomaly_flag IN ('MissingIn', 'MissingOut', 'NoPunch', 'IncompletePunchPair')

UNION ALL

SELECT
    fb.emp_id,
    fb.emp_code,
    fb.employee_name,
    fb.department_id,
    fb.dept_code,
    fb.dept_name,
    fb.group_id,
    fb.group_code,
    fb.group_name,
    fb.att_date,
    CAST('Payroll' AS varchar(30)) AS issue_area,
    CAST('PayrollReviewRequired' AS varchar(60)) AS issue_code,
    CAST('High' AS varchar(20)) AS severity,
    CAST('Attendance fact is marked as needing payroll review.' AS varchar(250)) AS issue_message,
    CAST('needs_payroll_review = 0' AS varchar(100)) AS expected_value,
    CAST('needs_payroll_review = 1' AS varchar(100)) AS actual_value,
    CAST(1 AS bit) AS needs_payroll_block
FROM FactBase fb
WHERE ISNULL(fb.needs_payroll_review, 0) = 1

UNION ALL

SELECT
    fb.emp_id,
    fb.emp_code,
    fb.employee_name,
    fb.department_id,
    fb.dept_code,
    fb.dept_name,
    fb.group_id,
    fb.group_code,
    fb.group_name,
    fb.att_date,
    CAST('Payroll' AS varchar(30)) AS issue_area,
    CAST('ReconciliationVariance' AS varchar(60)) AS issue_code,
    CAST('High' AS varchar(20)) AS severity,
    CAST('Attendance fact has non-zero reconciliation variance minutes.' AS varchar(250)) AS issue_message,
    CAST('0 minutes variance' AS varchar(100)) AS expected_value,
    CAST(CAST(ISNULL(fb.reconciliation_variance_minutes, 0) AS decimal(10,2)) AS varchar(100)) AS actual_value,
    CAST(1 AS bit) AS needs_payroll_block
FROM FactBase fb
WHERE ABS(ISNULL(fb.reconciliation_variance_minutes, 0)) > 0

UNION ALL

SELECT
    fb.emp_id,
    fb.emp_code,
    fb.employee_name,
    fb.department_id,
    fb.dept_code,
    fb.dept_name,
    fb.group_id,
    fb.group_code,
    fb.group_name,
    fb.att_date,
    CAST('Payroll' AS varchar(30)) AS issue_area,
    CAST('GeneralAnomaly' AS varchar(60)) AS issue_code,
    CAST('Medium' AS varchar(20)) AS severity,
    CAST('Attendance fact has a non-normal anomaly flag.' AS varchar(250)) AS issue_message,
    CAST('Normal' AS varchar(100)) AS expected_value,
    CAST(ISNULL(fb.anomaly_flag, 'NULL') AS varchar(100)) AS actual_value,
    CAST(0 AS bit) AS needs_payroll_block
FROM FactBase fb
WHERE ISNULL(fb.anomaly_flag, 'Normal') <> 'Normal'
  AND fb.anomaly_flag NOT IN ('MissingIn', 'MissingOut', 'NoPunch', 'IncompletePunchPair');
