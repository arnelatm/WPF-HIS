
CREATE   VIEW [dbo].[custom_att_SegmentPairsVer1]
AS
WITH sched AS
(
    SELECT
        t.emp_id,
        t.att_date,
        MIN(t.check_in) AS scheduled_in,
        MAX(t.check_out) AS scheduled_out
    FROM dbo.att_payloadtimecard t
    GROUP BY
        t.emp_id,
        t.att_date
),
seq AS
(
    SELECT
        ps.emp_id,
        ps.work_date,
        ps.segment_no,
        ps.id,
        ps.punch_time,
        ROW_NUMBER() OVER
        (
            PARTITION BY ps.emp_id, ps.work_date, ps.segment_no
            ORDER BY ps.punch_time, ps.id
        ) AS seq_in_segment,
        COUNT(*) OVER
        (
            PARTITION BY ps.emp_id, ps.work_date, ps.segment_no
        ) AS punches_in_segment
    FROM dbo.custom_att_PunchSegments ps
),
odd_punches AS
(
    SELECT
        s.emp_id,
        s.work_date,
        s.segment_no,
        s.id AS in_trans_id,
        s.punch_time AS in_time,
        s.seq_in_segment,
        s.punches_in_segment
    FROM seq s
    WHERE s.seq_in_segment % 2 = 1
),
even_punches AS
(
    SELECT
        s.emp_id,
        s.work_date,
        s.segment_no,
        s.id AS out_trans_id,
        s.punch_time AS out_time,
        s.seq_in_segment
    FROM seq s
    WHERE s.seq_in_segment % 2 = 0
)
SELECT
    o.emp_id,
    o.work_date AS att_date,
    o.segment_no,
    ((o.seq_in_segment + 1) / 2) AS pair_no_in_segment,

    o.in_trans_id,
    o.in_time,
    e.out_trans_id,
    e.out_time,

    sch.scheduled_in,
    sch.scheduled_out,

    CASE
        WHEN e.out_time IS NOT NULL
         AND e.out_time >= o.in_time
        THEN DATEDIFF(SECOND, o.in_time, e.out_time)
        ELSE 0
    END AS duration_seconds,

    CASE
        WHEN e.out_time IS NULL THEN 1
        ELSE 0
    END AS is_unmatched_last_punch,

    CASE
        WHEN e.out_time IS NULL
         AND sch.scheduled_in IS NOT NULL
         AND sch.scheduled_out IS NOT NULL
         AND ABS(DATEDIFF(MINUTE, sch.scheduled_in, o.in_time))
             <= ABS(DATEDIFF(MINUTE, sch.scheduled_out, o.in_time))
        THEN 1
        ELSE 0
    END AS inferred_missing_out,

    CASE
        WHEN e.out_time IS NULL
         AND sch.scheduled_in IS NOT NULL
         AND sch.scheduled_out IS NOT NULL
         AND ABS(DATEDIFF(MINUTE, sch.scheduled_out, o.in_time))
             < ABS(DATEDIFF(MINUTE, sch.scheduled_in, o.in_time))
        THEN 1
        ELSE 0
    END AS inferred_missing_in
FROM odd_punches o
LEFT JOIN even_punches e
    ON o.emp_id = e.emp_id
   AND o.work_date = e.work_date
   AND o.segment_no = e.segment_no
   AND e.seq_in_segment = o.seq_in_segment + 1
LEFT JOIN sched sch
    ON o.emp_id = sch.emp_id
   AND o.work_date = sch.att_date;