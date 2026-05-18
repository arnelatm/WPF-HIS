



CREATE VIEW [dbo].[custom_att_DailyAttendanceSummaryVer4]
AS
WITH tc AS
(
    SELECT
        t.emp_id,
        t.att_date,
        MAX(t.date_type) AS date_type,

        COUNT(*) AS timecard_rows,
        SUM(ISNULL(t.work_day, 0)) AS total_workday,

        MAX(t.present) AS present_flag,
        MAX(t.full_attendance) AS full_attendance_flag,

        MIN(t.check_in) AS scheduled_in,
        MAX(t.check_out) AS scheduled_out,

        MIN(t.clock_in) AS first_clock_in,
        MAX(t.clock_out) AS last_clock_out,

        SUM(dbo.custom_ExtractPayloadMinutes(t.payload, 'worked_hrs')) AS worked_minutes,
        SUM(dbo.custom_ExtractPayloadMinutes(t.payload, 'total_ot')) AS ot_minutes,
        SUM(dbo.custom_ExtractPayloadMinutes(t.payload, 'remaining')) AS absence_minutes
    FROM dbo.att_payloadtimecard t
    GROUP BY
        t.emp_id,
        t.att_date
),
ps AS
(
    SELECT
        p.emp_id,
        p.att_date,
        COUNT(*) AS pair_rows,
        SUM(CASE WHEN p.in_trans_id IS NULL OR p.out_trans_id IS NULL THEN 1 ELSE 0 END) AS missing_pair_rows,
        SUM(CASE WHEN p.in_trans_id IS NULL AND p.out_trans_id IS NOT NULL THEN 1 ELSE 0 END) AS missing_in_rows,
        SUM(CASE WHEN p.in_trans_id IS NOT NULL AND p.out_trans_id IS NULL THEN 1 ELSE 0 END) AS missing_out_rows,
        SUM(CASE WHEN p.in_trans_id IS NOT NULL OR p.out_trans_id IS NOT NULL THEN 1 ELSE 0 END) AS nonblank_pair_rows,
        SUM(ISNULL(p.duration, 0)) AS paired_duration_seconds,
        SUM(ISNULL(p.worked_duration, 0)) AS paired_worked_duration_seconds
    FROM dbo.att_payloadparing p
    GROUP BY
        p.emp_id,
        p.att_date
),
base AS
(
    SELECT
        tc.emp_id,
        tc.att_date,
        tc.date_type,

        tc.timecard_rows,
        tc.total_workday,
        tc.present_flag,
        tc.full_attendance_flag,

        tc.scheduled_in,
        tc.scheduled_out,
        tc.first_clock_in,
        tc.last_clock_out,

        tc.worked_minutes,
        tc.ot_minutes,
        tc.absence_minutes,

        CAST(tc.worked_minutes / 60.0 AS decimal(10,2)) AS worked_hours,
        CAST(tc.ot_minutes / 60.0 AS decimal(10,2)) AS ot_hours,
        CAST(tc.absence_minutes / 60.0 AS decimal(10,2)) AS absence_hours,

        CASE
            WHEN (tc.worked_minutes - tc.ot_minutes) < 0 THEN 0
            ELSE CAST((tc.worked_minutes - tc.ot_minutes) / 60.0 AS decimal(10,2))
        END AS worked_hours_excluding_ot,

        ISNULL(ps.pair_rows, 0) AS pair_rows,
        ISNULL(ps.missing_pair_rows, 0) AS missing_pair_rows,
        ISNULL(ps.missing_in_rows, 0) AS missing_in_rows,
        ISNULL(ps.missing_out_rows, 0) AS missing_out_rows,
        ISNULL(ps.nonblank_pair_rows, 0) AS nonblank_pair_rows,
        ISNULL(ps.paired_duration_seconds, 0) AS paired_duration_seconds,
        ISNULL(ps.paired_worked_duration_seconds, 0) AS paired_worked_duration_seconds,

        CASE
            WHEN tc.present_flag = 1 THEN 1
            ELSE 0
        END AS is_present,

        CASE
            WHEN tc.present_flag = 0 THEN 1
            ELSE 0
        END AS is_absent,

        CASE
            WHEN ISNULL(ps.missing_pair_rows, 0) > 0 THEN 1
            ELSE 0
        END AS has_missing_punch,

        CASE
            WHEN tc.first_clock_in IS NOT NULL
             AND tc.scheduled_in IS NOT NULL
             AND tc.first_clock_in > tc.scheduled_in
            THEN DATEDIFF(MINUTE, tc.scheduled_in, tc.first_clock_in)
            ELSE 0
        END AS late_minutes,

        CASE
            WHEN tc.last_clock_out IS NOT NULL
             AND tc.scheduled_out IS NOT NULL
             AND tc.last_clock_out < tc.scheduled_out
            THEN DATEDIFF(MINUTE, tc.last_clock_out, tc.scheduled_out)
            ELSE 0
        END AS early_out_minutes,

		CASE
			WHEN EXISTS
			(
				SELECT 1
				FROM dbo.custom_att_NormalizedPunches np
				WHERE np.emp_id = tc.emp_id
				  AND np.work_date = tc.att_date
			)
			THEN 1
			ELSE 0
		END AS has_valid_workday_punch
    FROM tc
    LEFT JOIN ps
        ON tc.emp_id = ps.emp_id
       AND tc.att_date = ps.att_date
)
SELECT
    b.emp_id,
    b.att_date,
    b.date_type,

    b.timecard_rows,
    b.total_workday,
    b.present_flag,
    b.full_attendance_flag,

    b.scheduled_in,
    b.scheduled_out,
    b.first_clock_in,
    b.last_clock_out,

    b.worked_minutes,
    b.ot_minutes,
    b.absence_minutes,

    b.worked_hours,
    b.ot_hours,
    b.absence_hours,
    b.worked_hours_excluding_ot,

    b.pair_rows,
    b.missing_pair_rows,
    b.missing_in_rows,
    b.missing_out_rows,
    b.nonblank_pair_rows,
    b.paired_duration_seconds,
    b.paired_worked_duration_seconds,

    b.is_present,
    b.is_absent,
    b.has_missing_punch,
	
	CASE
		WHEN b.missing_in_rows > 0 AND b.missing_out_rows > 0 THEN 'MissingInOut'
		WHEN b.missing_in_rows > 0 THEN 'MissingIn'
		WHEN b.missing_out_rows > 0 THEN 'MissingOut'
		WHEN b.missing_pair_rows > 0 THEN 'Incomplete'
    ELSE 'OK'
	END AS punch_status,

    b.late_minutes,
    b.early_out_minutes,
    b.has_valid_workday_punch,

    CASE
        WHEN (
                b.present_flag = 1
                OR ISNULL(b.worked_hours, 0) > 0
                OR b.has_valid_workday_punch = 1
             )
        THEN 1
        ELSE 0
    END AS is_present_by_report_rule,

	CASE
		WHEN b.date_type = 2
			 AND ISNULL(b.worked_hours, 0) = 0
			 AND ISNULL(b.ot_hours, 0) = 0
			 AND b.has_valid_workday_punch = 0
		THEN 'DayOff'

		WHEN b.date_type = 1
			 AND (
					ISNULL(b.worked_hours, 0) > 0
					OR ISNULL(b.ot_hours, 0) > 0
					OR b.has_valid_workday_punch = 1
				 )
		THEN 'Holiday_WithWork'

		WHEN b.date_type = 1
		THEN 'Holiday_NoWork'

		WHEN b.date_type = 0
			 AND NOT (
					b.present_flag = 1
					OR ISNULL(b.worked_hours, 0) > 0
					OR b.has_valid_workday_punch = 1
				 )
		THEN 'Absent'

		WHEN b.date_type = 0
			 AND (
					b.present_flag = 1
					OR ISNULL(b.worked_hours,0) > 0
					OR b.has_valid_workday_punch = 1
				 )
			 AND (
					b.missing_in_rows > 0
					OR b.missing_out_rows > 0
					OR b.missing_pair_rows > 0
				 )
			 AND ISNULL(b.absence_hours,0) > 0
		THEN 'PartialAttendance_WithInvalidPunch'

		WHEN b.date_type = 0
			 AND (
					b.present_flag = 1
					OR ISNULL(b.worked_hours,0) > 0
					OR b.has_valid_workday_punch = 1
				 )
			 AND (
					b.missing_in_rows > 0
					OR b.missing_out_rows > 0
					OR b.missing_pair_rows > 0
				 )
		THEN 'Present_WithInvalidPunch'

		WHEN b.date_type = 0
			 AND (
					b.present_flag = 1
					OR ISNULL(b.worked_hours,0) > 0
					OR b.has_valid_workday_punch = 1
				 )
			 AND ISNULL(b.absence_hours,0) > 0
		THEN 'PartialAttendance'

		WHEN b.date_type = 0
			 AND (
					b.present_flag = 1
					OR ISNULL(b.worked_hours, 0) > 0
					OR b.has_valid_workday_punch = 1
				 )
			 AND ISNULL(b.ot_hours, 0) > 0
			 AND ISNULL(b.worked_hours_excluding_ot, 0) > 0
		THEN 'RegularWorkingDayWithOT'

		WHEN b.date_type = 0
			 AND (
					b.present_flag = 1
					OR ISNULL(b.worked_hours, 0) > 0
					OR b.has_valid_workday_punch = 1
				 )
			 AND ISNULL(b.worked_hours_excluding_ot, 0) = 0
			 AND ISNULL(b.ot_hours, 0) > 0
		THEN 'OTOnlyDay'

		WHEN b.date_type = 0
			 AND (
					b.present_flag = 1
					OR ISNULL(b.worked_hours, 0) > 0
					OR b.has_valid_workday_punch = 1
				 )
		THEN 'RegularWorkingDayWithoutOT'

		ELSE 'Unclassified'
	END AS daily_status

FROM base b;