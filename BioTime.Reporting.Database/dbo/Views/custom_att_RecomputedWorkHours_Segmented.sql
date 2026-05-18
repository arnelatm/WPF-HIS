
CREATE   VIEW [dbo].[custom_att_RecomputedWorkHours_Segmented]
AS
WITH pair_eval AS
(
    SELECT
        sp.emp_id,
        sp.att_date,
        sp.segment_no,
        sp.pair_no_in_segment,
        sp.in_trans_id,
        sp.in_time,
        sp.out_trans_id,
        sp.out_time,
        sp.scheduled_in,
        sp.scheduled_out,
        sp.duration_seconds,
        sp.is_unmatched_last_punch,
        sp.inferred_missing_in,
        sp.inferred_missing_out,

        CASE
            WHEN sp.scheduled_in IS NULL OR sp.scheduled_out IS NULL THEN 1
            WHEN sp.in_time >= DATEADD(HOUR, -4, sp.scheduled_in)
             AND sp.in_time <= DATEADD(HOUR,  2, sp.scheduled_out)
            THEN 1
            ELSE 0
        END AS is_within_schedule_window,

        CASE
            WHEN ISNULL(sp.duration_seconds, 0) >= 3600 THEN 1
            ELSE 0
        END AS is_long_enough
    FROM dbo.custom_att_SegmentPairs sp
)
SELECT
    p.emp_id,
    p.att_date,

    COUNT(*) AS recomputed_pair_rows,
    COUNT(DISTINCT p.segment_no) AS segment_count,

    SUM(CASE WHEN p.out_trans_id IS NOT NULL THEN 1 ELSE 0 END) AS complete_pair_rows,
    SUM(CASE WHEN p.is_unmatched_last_punch = 1 THEN 1 ELSE 0 END) AS unmatched_pair_rows,

    SUM(CASE WHEN p.inferred_missing_in = 1 THEN 1 ELSE 0 END) AS recomputed_missing_in_rows,
    SUM(CASE WHEN p.inferred_missing_out = 1 THEN 1 ELSE 0 END) AS recomputed_missing_out_rows,

    SUM(ISNULL(p.duration_seconds, 0)) AS recomputed_worked_seconds_raw,
    CAST(SUM(ISNULL(p.duration_seconds, 0)) / 60.0 AS decimal(10,2)) AS recomputed_worked_minutes_raw,
    CAST(SUM(ISNULL(p.duration_seconds, 0)) / 3600.0 AS decimal(10,2)) AS recomputed_worked_hours_raw,

    SUM(
        CASE
            WHEN p.is_long_enough = 1
             AND p.is_within_schedule_window = 1
            THEN ISNULL(p.duration_seconds, 0)
            ELSE 0
        END
    ) AS recomputed_worked_seconds,

    CAST(
        SUM(
            CASE
                WHEN p.is_long_enough = 1
                 AND p.is_within_schedule_window = 1
                THEN ISNULL(p.duration_seconds, 0)
                ELSE 0
            END
        ) / 60.0
        AS decimal(10,2)
    ) AS recomputed_worked_minutes,

    CAST(
        SUM(
            CASE
                WHEN p.is_long_enough = 1
                 AND p.is_within_schedule_window = 1
                THEN ISNULL(p.duration_seconds, 0)
                ELSE 0
            END
        ) / 3600.0
        AS decimal(10,2)
    ) AS recomputed_worked_hours,

    MIN(p.in_time) AS recomputed_first_in,
    MAX(COALESCE(p.out_time, p.in_time)) AS recomputed_last_out
FROM pair_eval p
GROUP BY
    p.emp_id,
    p.att_date;