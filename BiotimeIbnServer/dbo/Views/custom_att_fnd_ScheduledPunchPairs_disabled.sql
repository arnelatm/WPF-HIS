



CREATE VIEW [dbo].[custom_att_fnd_ScheduledPunchPairs_disabled]
AS
SELECT
    s.emp_id,
    s.work_date,
    s.schedule_segment_no,

    s.scheduled_segment_in,
    s.scheduled_segment_out,

    i.actual_in,
    o.actual_out,

    CASE
        WHEN i.actual_in IS NULL OR o.actual_out IS NULL THEN 1
        ELSE 0
    END AS is_open_pair,

    CASE
        WHEN i.actual_in IS NOT NULL
         AND o.actual_out IS NOT NULL
         AND o.actual_out >= i.actual_in
         AND DATEDIFF(MINUTE, i.actual_in, o.actual_out) <= 960
        THEN DATEDIFF(MINUTE, i.actual_in, o.actual_out)
        ELSE NULL
    END AS paired_minutes,

    ISNULL(i.corrected_punch_count, 0)
    + ISNULL(o.corrected_punch_count, 0) AS corrected_punch_count

FROM dbo.custom_att_fnd_ScheduledWorkSegments s

OUTER APPLY
(
    SELECT TOP 1
        cp.punch_time AS actual_in,
        0 AS corrected_punch_count
    FROM dbo.custom_att_fnd_CleanedPunches cp
    WHERE cp.emp_id = s.emp_id
      AND cp.norm_punch_state = 0
      AND cp.punch_time BETWEEN DATEADD(HOUR, -2, s.scheduled_segment_in)
                            AND DATEADD(HOUR,  3, s.scheduled_segment_in)
    ORDER BY
        ABS(DATEDIFF(MINUTE, cp.punch_time, s.scheduled_segment_in)),
        cp.punch_time
) i

OUTER APPLY
(
    SELECT TOP 1
        cp.punch_time AS actual_out,
        0 AS corrected_punch_count
    FROM dbo.custom_att_fnd_CleanedPunches cp
    WHERE cp.emp_id = s.emp_id
      AND cp.norm_punch_state = 1
      AND i.actual_in IS NOT NULL
      AND cp.punch_time > i.actual_in
      AND cp.punch_time <= DATEADD(HOUR, 3, s.scheduled_segment_out)
    ORDER BY
        ABS(DATEDIFF(MINUTE, cp.punch_time, s.scheduled_segment_out)),
        cp.punch_time
) o;
