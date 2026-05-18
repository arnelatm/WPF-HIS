
CREATE   VIEW [dbo].[custom_att_RecomputedWorkHours]
AS
SELECT
    tp.emp_id,
    tp.att_date,

    COUNT(*) AS recomputed_pair_rows,

    SUM(CASE WHEN tp.out_trans_id IS NOT NULL THEN 1 ELSE 0 END) AS complete_pair_rows,
    SUM(CASE WHEN tp.is_unmatched_last_punch = 1 THEN 1 ELSE 0 END) AS unmatched_pair_rows,

    SUM(CASE WHEN tp.inferred_missing_in = 1 THEN 1 ELSE 0 END) AS recomputed_missing_in_rows,
    SUM(CASE WHEN tp.inferred_missing_out = 1 THEN 1 ELSE 0 END) AS recomputed_missing_out_rows,

    SUM(ISNULL(tp.duration_seconds, 0)) AS recomputed_worked_seconds,
    CAST(SUM(ISNULL(tp.duration_seconds, 0)) / 60.0 AS decimal(10,2)) AS recomputed_worked_minutes,
    CAST(SUM(ISNULL(tp.duration_seconds, 0)) / 3600.0 AS decimal(10,2)) AS recomputed_worked_hours,

    MIN(tp.in_time) AS recomputed_first_in,
    MAX(COALESCE(tp.out_time, tp.in_time)) AS recomputed_last_out
FROM dbo.custom_att_TruePunchPairs tp
GROUP BY
    tp.emp_id,
    tp.att_date;