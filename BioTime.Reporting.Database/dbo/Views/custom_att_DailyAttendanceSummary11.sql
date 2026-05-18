

CREATE VIEW [dbo].[custom_att_DailyAttendanceSummary11]
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
np AS
(
    SELECT
        np.emp_id,
        np.work_date AS att_date,
        COUNT(*) AS normalized_punch_count,
        MIN(np.punch_time) AS normalized_first_punch,
        MAX(np.punch_time) AS normalized_last_punch
    FROM dbo.custom_att_NormalizedPunches np
    GROUP BY
        np.emp_id,
        np.work_date
),
cp AS
(
    SELECT
        cp.emp_id,
        cp.work_date AS att_date,
        COUNT(*) AS cleaned_punch_count,
        MIN(cp.punch_time) AS cleaned_first_punch,
        MAX(cp.punch_time) AS cleaned_last_punch,
        SUM(CASE WHEN cp.is_duplicate_burst = 1 THEN (cp.burst_punch_count - 1) ELSE 0 END) AS duplicate_punch_count,
        MAX(CASE WHEN cp.is_duplicate_burst = 1 THEN 1 ELSE 0 END) AS has_duplicate_punches
    FROM dbo.custom_att_CleanedPunches cp
    GROUP BY
        cp.emp_id,
        cp.work_date
),
tp AS
(
    SELECT
        tp.emp_id,
        tp.att_date,
        COUNT(*) AS true_pair_rows,
        SUM(CASE WHEN tp.is_unmatched_last_punch = 1 THEN 1 ELSE 0 END) AS unmatched_rows,
        SUM(CASE WHEN tp.inferred_missing_in = 1 THEN 1 ELSE 0 END) AS true_missing_in_rows,
        SUM(CASE WHEN tp.inferred_missing_out = 1 THEN 1 ELSE 0 END) AS true_missing_out_rows,
        SUM(ISNULL(tp.duration_seconds, 0)) AS true_paired_duration_seconds
    FROM dbo.custom_att_TruePunchPairs tp
    GROUP BY
        tp.emp_id,
        tp.att_date
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

        ISNULL(np.normalized_punch_count, 0) AS normalized_punch_count,
        np.normalized_first_punch,
        np.normalized_last_punch,

        ISNULL(cp.cleaned_punch_count, 0) AS cleaned_punch_count,
        cp.cleaned_first_punch,
        cp.cleaned_last_punch,
        ISNULL(cp.duplicate_punch_count, 0) AS duplicate_punch_count,
        ISNULL(cp.has_duplicate_punches, 0) AS has_duplicate_punches,

        ISNULL(tp.true_pair_rows, 0) AS pair_rows,
        ISNULL(tp.unmatched_rows, 0) AS missing_pair_rows,
        ISNULL(tp.true_missing_in_rows, 0) AS missing_in_rows,
        ISNULL(tp.true_missing_out_rows, 0) AS missing_out_rows,
        ISNULL(tp.true_pair_rows, 0) AS nonblank_pair_rows,
        ISNULL(tp.true_paired_duration_seconds, 0) AS paired_duration_seconds,
        ISNULL(tp.true_paired_duration_seconds, 0) AS paired_worked_duration_seconds,

        CASE
            WHEN tc.present_flag = 1 THEN 1
            ELSE 0
        END AS is_present,

        CASE
            WHEN tc.present_flag = 0 THEN 1
            ELSE 0
        END AS is_absent,

        CASE
            WHEN ISNULL(tp.unmatched_rows, 0) > 0 THEN 1
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
            WHEN tc.scheduled_in IS NOT NULL
             AND tc.scheduled_out IS NOT NULL
            THEN CAST(DATEDIFF(MINUTE, tc.scheduled_in, tc.scheduled_out) / 60.0 AS decimal(10,2))
            ELSE 0
        END AS required_scheduled_hours,

        CASE
            WHEN EXISTS
            (
                SELECT 1
                FROM dbo.custom_att_NormalizedPunches x
                WHERE x.emp_id = tc.emp_id
                  AND x.work_date = tc.att_date
            )
            THEN 1
            ELSE 0
        END AS has_valid_workday_punch
    FROM tc
    LEFT JOIN np
        ON tc.emp_id = np.emp_id
       AND tc.att_date = np.att_date
    LEFT JOIN cp
        ON tc.emp_id = cp.emp_id
       AND tc.att_date = cp.att_date
    LEFT JOIN tp
        ON tc.emp_id = tp.emp_id
       AND tc.att_date = tp.att_date
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
    b.required_scheduled_hours,

    b.pair_rows,
    b.missing_pair_rows,
    b.missing_in_rows,
    b.missing_out_rows,
    b.nonblank_pair_rows,
    b.paired_duration_seconds,
    b.paired_worked_duration_seconds,

    b.normalized_punch_count,
    b.normalized_first_punch,
    b.normalized_last_punch,

    b.cleaned_punch_count,
    b.cleaned_first_punch,
    b.cleaned_last_punch,
    b.duplicate_punch_count,
    b.has_duplicate_punches,

    b.is_present,
    b.is_absent,
    b.has_missing_punch,

    CASE
        WHEN b.date_type = 0 THEN 'RegularDay'
        WHEN b.date_type = 1 THEN 'Holiday'
        WHEN b.date_type = 2 THEN 'DayOff'
        ELSE 'Unclassified'
    END AS daily_status,

	CASE
		WHEN normalized_punch_count = 0 THEN 'NoPunch'

		WHEN cleaned_punch_count = 0 THEN 'NoPunch'

		-- 🔥 NEW: protect valid workdays
		WHEN cleaned_punch_count >= 2 
			 AND worked_hours >= required_scheduled_hours * 0.8
		THEN 'OK'

		WHEN cleaned_punch_count % 2 = 0 THEN 'OK'

		WHEN missing_in_rows > 0 AND missing_out_rows > 0 THEN 'MissingInAndOut'
		WHEN missing_in_rows > 0 THEN 'MissingIn'
		WHEN missing_out_rows > 0 THEN 'MissingOut'

		ELSE 'OddPunchCount'
	END AS punch_status,

    CASE
        WHEN b.date_type IN (1, 2) THEN 'NotRequired'

        WHEN b.date_type = 0
         AND NOT
         (
             b.present_flag = 1
             OR ISNULL(b.worked_hours, 0) > 0
             OR b.has_valid_workday_punch = 1
         )
        THEN 'Absent'

        WHEN b.date_type = 0
         AND
         (
             b.present_flag = 1
             OR ISNULL(b.worked_hours, 0) > 0
             OR b.has_valid_workday_punch = 1
         )
         AND
         (
             ISNULL(b.absence_hours, 0) > 0
             OR ISNULL(b.full_attendance_flag, 0) = 0
         )
        THEN 'Partial'

        WHEN b.date_type = 0
         AND
         (
             b.present_flag = 1
             OR ISNULL(b.worked_hours, 0) > 0
             OR b.has_valid_workday_punch = 1
         )
        THEN 'Present'

        ELSE 'Unknown'
    END AS attendance_status,

    CASE
        WHEN ISNULL(b.ot_hours, 0) > 0 THEN 'WithOT'
        ELSE 'NoOT'
    END AS ot_status,

    b.late_minutes,
    b.early_out_minutes,
    b.has_valid_workday_punch,

    CASE
        WHEN
        (
            b.present_flag = 1
            OR ISNULL(b.worked_hours, 0) > 0
            OR b.has_valid_workday_punch = 1
        )
        THEN 1
        ELSE 0
    END AS is_present_by_report_rule

FROM base b;