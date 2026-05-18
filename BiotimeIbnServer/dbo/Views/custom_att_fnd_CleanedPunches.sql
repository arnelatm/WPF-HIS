CREATE VIEW [dbo].[custom_att_fnd_CleanedPunches]
AS
WITH normalized AS
(
    SELECT
        np.emp_id,
        np.work_date,
        np.punch_time,
        np.punch_state,
        np.id,
        CASE 
            WHEN np.punch_state IN (0, 4) THEN 0
            WHEN np.punch_state IN (1, 5) THEN 1
            ELSE np.punch_state
        END AS norm_punch_state
    FROM dbo.custom_att_fnd_NormalizedPunches np
),
ordered AS
(
    SELECT
        n.emp_id,
        n.work_date,
        n.punch_time,
        n.punch_state,
        n.norm_punch_state,
        n.id,
        LAG(n.punch_time) OVER
        (
            PARTITION BY n.emp_id, n.work_date, n.norm_punch_state
            ORDER BY n.punch_time, n.id
        ) AS prev_same_state_punch_time
    FROM normalized n
),
marked AS
(
    SELECT
        o.*,
        CASE
            WHEN o.prev_same_state_punch_time IS NULL THEN 1
            WHEN DATEDIFF(MINUTE, o.prev_same_state_punch_time, o.punch_time) > 5 THEN 1
            ELSE 0
        END AS is_new_burst
    FROM ordered o
),
bursted AS
(
    SELECT
        m.*,
        SUM(m.is_new_burst) OVER
        (
            PARTITION BY m.emp_id, m.work_date, m.norm_punch_state
            ORDER BY m.punch_time, m.id
            ROWS UNBOUNDED PRECEDING
        ) AS burst_no
    FROM marked m
),
collapsed AS
(
    SELECT
        emp_id,
        work_date,
        norm_punch_state,
        burst_no,
        MIN(punch_time) AS cleaned_punch_time,
        MIN(id) AS kept_trans_id,
        COUNT(*) AS burst_punch_count,
        MIN(punch_state) AS original_punch_state
    FROM bursted
    GROUP BY
        emp_id,
        work_date,
        norm_punch_state,
        burst_no
),
day_ordered AS
(
    SELECT
        c.*,
        ROW_NUMBER() OVER
        (
            PARTITION BY c.emp_id, c.work_date
            ORDER BY c.cleaned_punch_time, c.kept_trans_id
        ) AS punch_order,

        COUNT(*) OVER
        (
            PARTITION BY c.emp_id, c.work_date
        ) AS daily_punch_count
    FROM collapsed c
),
ti_break AS
(
    SELECT
        tib.timeinterval_id,
        SUM(ISNULL(bt.duration, 0)) AS break_minutes
    FROM dbo.att_timeinterval_break_time tib
    INNER JOIN dbo.att_breaktime bt
        ON bt.id = tib.breaktime_id
    GROUP BY
        tib.timeinterval_id
),
schedule_check AS
(
    SELECT
        es.emp_id,
        es.att_date AS work_date,
        es.effective_time_interval_id,
        ti.alias AS timetable_name,
        ti.duration,
        ti.work_time_duration,
        ISNULL(tb.break_minutes, 0) AS break_minutes,

        CASE
            WHEN ISNULL(tb.break_minutes, 0) > 0
              OR ISNULL(ti.duration, 0) > ISNULL(ti.work_time_duration, 0)
            THEN 1
            ELSE 0
        END AS is_split_shift
    FROM dbo.custom_att_fnd_EffectiveScheduleResolved es
    LEFT JOIN dbo.att_timeinterval ti
        ON ti.id = es.effective_time_interval_id
    LEFT JOIN ti_break tb
        ON tb.timeinterval_id = es.effective_time_interval_id
),
corrected AS
(
    SELECT
        d.emp_id,
        d.work_date,
        d.cleaned_punch_time AS punch_time,
        d.original_punch_state AS punch_state,

        CASE
            WHEN ISNULL(sc.is_split_shift, 0) = 1
             AND d.daily_punch_count = 4
            THEN
                CASE d.punch_order
                    WHEN 1 THEN 0
                    WHEN 2 THEN 1
                    WHEN 3 THEN 0
                    WHEN 4 THEN 1
                    ELSE d.norm_punch_state
                END
            ELSE d.norm_punch_state
        END AS norm_punch_state,

        d.kept_trans_id AS id,
        d.burst_no,
        d.burst_punch_count,
        CASE WHEN d.burst_punch_count > 1 THEN 1 ELSE 0 END AS is_duplicate_burst,

        CASE
            WHEN ISNULL(sc.is_split_shift, 0) = 1
             AND d.daily_punch_count = 4
             AND d.norm_punch_state <>
                CASE d.punch_order
                    WHEN 1 THEN 0
                    WHEN 2 THEN 1
                    WHEN 3 THEN 0
                    WHEN 4 THEN 1
                    ELSE d.norm_punch_state
                END
            THEN 1
            ELSE 0
        END AS auto_corrected_state,

        CASE
            WHEN ISNULL(sc.is_split_shift, 0) = 1
             AND d.daily_punch_count = 4
            THEN 'SplitShift4PunchPattern'
            ELSE NULL
        END AS correction_rule
    FROM day_ordered d
    LEFT JOIN schedule_check sc
        ON sc.emp_id = d.emp_id
       AND sc.work_date = d.work_date
)
SELECT
    emp_id,
    work_date,
    punch_time,
    punch_state,
    norm_punch_state,
    id,
    burst_no,
    burst_punch_count,
    is_duplicate_burst,
    auto_corrected_state,
    correction_rule
FROM corrected;
