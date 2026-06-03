CREATE view dbo.custom_att_fnd_CorrectedPunches
AS
WITH x AS
(
    SELECT
        cp.*,

        COUNT(*) OVER (
            PARTITION BY cp.emp_id, cp.work_date
        ) AS daily_punch_count,

        FIRST_VALUE(cp.norm_punch_state) OVER (
            PARTITION BY cp.emp_id, cp.work_date
            ORDER BY cp.punch_time, cp.id
        ) AS first_punch_state,

        LAST_VALUE(cp.norm_punch_state) OVER (
            PARTITION BY cp.emp_id, cp.work_date
            ORDER BY cp.punch_time, cp.id
            ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING
        ) AS last_punch_state,

        ROW_NUMBER() OVER (
            PARTITION BY cp.emp_id, cp.work_date
            ORDER BY cp.punch_time, cp.id
        ) AS rn,

        DATEDIFF(
            MINUTE,
            MIN(cp.punch_time) OVER (
                PARTITION BY cp.emp_id, cp.work_date
            ),
            MAX(cp.punch_time) OVER (
                PARTITION BY cp.emp_id, cp.work_date
            )
        ) AS daily_span_minutes
    FROM dbo.custom_att_fnd_CleanedPunches cp
)
SELECT
    x.emp_id,
    x.work_date,
    x.punch_time,
    x.punch_state,
    x.norm_punch_state,
    corrected_punch_state =
        CASE
            -- exactly 2 cleaned punches marked OUT, IN;
            -- treat them as chronological IN, OUT when duration is reasonable
            WHEN x.daily_punch_count = 2
             AND x.first_punch_state = 1
             AND x.last_punch_state = 0
             AND x.daily_span_minutes BETWEEN 240 AND 960
            THEN
                CASE x.rn
                    WHEN 1 THEN 0
                    WHEN 2 THEN 1
                    ELSE x.norm_punch_state
                END

            -- exactly 2 cleaned punches, both OUT;
            -- treat first as IN when duration is reasonable
            WHEN x.daily_punch_count = 2
             AND x.first_punch_state = 1
             AND x.last_punch_state = 1
             AND x.rn = 1
             AND x.daily_span_minutes BETWEEN 240 AND 960
            THEN 0

            ELSE x.norm_punch_state
        END,
    corrected_punch_flag =
        CASE
            WHEN x.daily_punch_count = 2
             AND x.first_punch_state = 1
             AND x.last_punch_state = 0
             AND x.daily_span_minutes BETWEEN 240 AND 960
            THEN 1

            WHEN x.daily_punch_count = 2
             AND x.first_punch_state = 1
             AND x.last_punch_state = 1
             AND x.rn = 1
             AND x.daily_span_minutes BETWEEN 240 AND 960
            THEN 1
            ELSE 0
        END,
    x.id,
    x.burst_no,
    x.burst_punch_count,
    x.is_duplicate_burst,
    x.daily_punch_count,
    x.daily_span_minutes
FROM x;
