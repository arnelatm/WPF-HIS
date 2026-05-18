


CREATE   VIEW [dbo].[custom_att_audit_TruePunchPairs]
AS
/*
Layer: Audit View
Role: Alternate true punch-pair reconstruction for validation and reconciliation

Primary Sources:
- dbo.custom_att_fnd_CleanedPunches
- att_payloadtimecard schedule references

Purpose:
- Rebuilds in/out punch pairs using cleaned punch sequence logic
- Supports investigation of missing in/out cases and alternate worked-time reconstruction

Key Outputs:
- in_time / out_time
- duration_seconds
- unmatched last punch indicators
- inferred_missing_in
- inferred_missing_out

Used by:
- dbo.custom_att_audit_RecomputedWorkHours
- Audit and reconciliation workflows

Notes:
- Audit-only path
- Not part of the production reporting pipeline
- Useful for comparing alternate punch pairing outcomes against production results
*/
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
        cp.emp_id,
        cp.work_date,
        cp.id,
        cp.punch_time,
        ROW_NUMBER() OVER
        (
            PARTITION BY cp.emp_id, cp.work_date
            ORDER BY cp.punch_time, cp.id
        ) AS seq_no,
        COUNT(*) OVER
        (
            PARTITION BY cp.emp_id, cp.work_date
        ) AS cleaned_punch_count
    FROM dbo.custom_att_fnd_CleanedPunches cp
),
odd_punches AS
(
    SELECT
        s.emp_id,
        s.work_date,
        s.id AS in_trans_id,
        s.punch_time AS in_time,
        s.seq_no,
        s.cleaned_punch_count
    FROM seq s
    WHERE s.seq_no % 2 = 1
),
even_punches AS
(
    SELECT
        s.emp_id,
        s.work_date,
        s.id AS out_trans_id,
        s.punch_time AS out_time,
        s.seq_no
    FROM seq s
    WHERE s.seq_no % 2 = 0
)
SELECT
    o.emp_id,
    o.work_date AS att_date,
    ((o.seq_no + 1) / 2) AS pair_no,

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
   AND e.seq_no = o.seq_no + 1
LEFT JOIN sched sch
    ON o.emp_id = sch.emp_id
   AND o.work_date = sch.att_date;
