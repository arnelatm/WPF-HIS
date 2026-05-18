
CREATE VIEW dbo.custom_att_MonthlyAttendanceSummary
AS
SELECT
    YEAR(d.att_date) AS year_no,
    MONTH(d.att_date) AS month_no,
    d.emp_id,

    e.emp_code AS employee_code,
    LTRIM(RTRIM(
        ISNULL(e.first_name, '') +
        CASE
            WHEN ISNULL(e.last_name, '') = '' THEN ''
            ELSE ' ' + e.last_name
        END
    )) AS employee_name,

    dept.dept_name AS department_name,

    -- day counts
    SUM(CASE WHEN d.date_type = 0 THEN 1 ELSE 0 END) AS need_present_days,

    SUM(CASE
        WHEN d.daily_status IN (
            'RegularWorkingDayWithoutOT',
            'RegularWorkingDayWithOT',
            'PartialAttendance',
            'OTOnlyDay'
        )
        THEN 1 ELSE 0 END) AS actual_present_days,

    SUM(CASE
        WHEN d.daily_status = 'Absent'
        THEN 1 ELSE 0 END) AS actual_absence_days,

    SUM(CASE
        WHEN d.daily_status IN (
            'RegularWorkingDayWithoutOT',
            'RegularWorkingDayWithOT',
            'PartialAttendance',
            'OTOnlyDay'
        )
        THEN 1 ELSE 0 END) AS computed_present_days,

    SUM(CASE
        WHEN d.daily_status = 'Absent'
        THEN 1 ELSE 0 END) AS computed_absence_days,

    -- required regular working days = scheduled workdays minus OT-only days
    SUM(CASE WHEN d.date_type = 0 THEN 1 ELSE 0 END)
    -
    SUM(CASE WHEN d.daily_status = 'OTOnlyDay' THEN 1 ELSE 0 END)
    AS needed_regular_working_days,

    -- percentages
    CAST(
        100.0 *
        SUM(CASE
            WHEN d.daily_status IN (
                'RegularWorkingDayWithoutOT',
                'RegularWorkingDayWithOT',
                'PartialAttendance',
                'OTOnlyDay'
            )
            THEN 1 ELSE 0 END)
        / NULLIF(SUM(CASE WHEN d.date_type = 0 THEN 1 ELSE 0 END), 0)
        AS decimal(6,2)
    ) AS presence_percentage,

    CAST(
        100.0 *
        SUM(CASE
            WHEN d.daily_status = 'Absent'
            THEN 1 ELSE 0 END)
        / NULLIF(SUM(CASE WHEN d.date_type = 0 THEN 1 ELSE 0 END), 0)
        AS decimal(6,2)
    ) AS absence_percentage,

    -- hours
    CAST(SUM(CASE WHEN d.date_type = 0 THEN d.regular_only_hours ELSE 0 END) AS decimal(10,1)) AS regular_hours,
    CAST(SUM(CASE WHEN d.date_type = 0 THEN d.ot_hours ELSE 0 END) AS decimal(10,1)) AS normal_ot_hours,
    CAST(SUM(CASE WHEN d.date_type = 0 THEN d.worked_hours ELSE 0 END) AS decimal(10,1)) AS total_worked_hours,
    CAST(SUM(CASE WHEN d.date_type = 0 THEN d.absence_hours ELSE 0 END) AS decimal(10,1)) AS absence_hours,

    -- OT-only days
    SUM(CASE WHEN d.daily_status = 'OTOnlyDay' THEN 1 ELSE 0 END) AS OT_Days,

    -- time issues
    SUM(CASE WHEN d.date_type = 0 THEN d.late_minutes ELSE 0 END) AS late_minutes,
    SUM(CASE WHEN d.date_type = 0 THEN d.early_out_minutes ELSE 0 END) AS early_out_minutes,

    -- punch issues
    SUM(CASE WHEN d.date_type = 0 AND d.has_single_pair = 1 THEN 1 ELSE 0 END) AS single_punch_days,
    SUM(CASE WHEN d.date_type = 0 AND d.has_missing_punch = 1 THEN 1 ELSE 0 END) AS missing_punch_days,

    -- day classifications
    SUM(CASE WHEN d.daily_status = 'RegularWorkingDayWithoutOT' THEN 1 ELSE 0 END) AS RegularWorkingDayWithoutOT_Days,
    SUM(CASE WHEN d.daily_status = 'RegularWorkingDayWithOT' THEN 1 ELSE 0 END) AS RegularWorkingDayWithOT_Days,
    SUM(CASE WHEN d.daily_status = 'PartialAttendance' THEN 1 ELSE 0 END) AS PartialAttendance_Days,
    SUM(CASE WHEN d.daily_status = 'Holiday_WithOT' THEN 1 ELSE 0 END) AS Holiday_WithOT_Days,
    SUM(CASE WHEN d.daily_status = 'Holiday_WithoutOT' THEN 1 ELSE 0 END) AS Holiday_WithoutOT_Days,
    SUM(CASE WHEN d.daily_status = 'DayOff' THEN 1 ELSE 0 END) AS DayOff_Days,
    SUM(CASE WHEN d.daily_status = 'Absent' THEN 1 ELSE 0 END) AS Absent_Days,

    -- generic holiday/rest counts
    SUM(CASE WHEN d.date_type = 1 THEN 1 ELSE 0 END) AS holiday_days,
    SUM(CASE WHEN d.date_type = 2 THEN 1 ELSE 0 END) AS rest_days

FROM dbo.custom_att_DailyAttendanceSummary d
LEFT JOIN dbo.personnel_employee e
    ON d.emp_id = e.id
LEFT JOIN dbo.personnel_department dept
    ON e.department_id = dept.id
GROUP BY
    YEAR(d.att_date),
    MONTH(d.att_date),
    d.emp_id,
    e.emp_code,
    e.first_name,
    e.last_name,
    dept.dept_name;