CREATE VIEW dbo.custom_att_fnd_ScheduledWorkSegments
AS
WITH base AS
(
    SELECT
        es.emp_id,
        es.att_date AS work_date,
        es.effective_time_interval_id,
        es.effective_scheduled_in_datetime,
        es.effective_scheduled_out_datetime,
        bt.period_start AS break_start_time,
        bt.duration AS break_duration
    FROM dbo.custom_att_fnd_EffectiveScheduleResolved es
    LEFT JOIN dbo.att_timeinterval_break_time tib
        ON tib.timeinterval_id = es.effective_time_interval_id
    LEFT JOIN dbo.att_breaktime bt
        ON bt.id = tib.breaktime_id
),
seg1 AS
(
    SELECT
        emp_id,
        work_date,
        1 AS schedule_segment_no,
        effective_scheduled_in_datetime AS scheduled_segment_in,
        DATEADD(
            DAY,
            CASE WHEN break_start_time < CAST(effective_scheduled_in_datetime AS time) THEN 1 ELSE 0 END,
            CAST(CAST(work_date AS date) AS datetime) + CAST(break_start_time AS datetime)
        ) AS scheduled_segment_out
    FROM base
    WHERE break_start_time IS NOT NULL
),
seg2 AS
(
    SELECT
        emp_id,
        work_date,
        2 AS schedule_segment_no,
        DATEADD(
            MINUTE,
            break_duration,
            DATEADD(
                DAY,
                CASE WHEN break_start_time < CAST(effective_scheduled_in_datetime AS time) THEN 1 ELSE 0 END,
                CAST(CAST(work_date AS date) AS datetime) + CAST(break_start_time AS datetime)
            )
        ) AS scheduled_segment_in,
        effective_scheduled_out_datetime AS scheduled_segment_out
    FROM base
    WHERE break_start_time IS NOT NULL
),
nobreak AS
(
    SELECT
        emp_id,
        work_date,
        1 AS schedule_segment_no,
        effective_scheduled_in_datetime AS scheduled_segment_in,
        effective_scheduled_out_datetime AS scheduled_segment_out
    FROM base
    WHERE break_start_time IS NULL
)
SELECT *
FROM seg1
WHERE scheduled_segment_out > scheduled_segment_in

UNION ALL

SELECT *
FROM seg2
WHERE scheduled_segment_out > scheduled_segment_in

UNION ALL

SELECT *
FROM nobreak
WHERE scheduled_segment_out > scheduled_segment_in;
