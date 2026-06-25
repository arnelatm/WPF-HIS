CREATE VIEW [dbo].[custom_att_audit_TimeIntervals]
AS
WITH break_agg AS
(
    SELECT
        tib.timeinterval_id,
        SUM(ISNULL(bt.duration, 0)) AS break_duration
    FROM dbo.att_timeinterval_break_time tib
    LEFT JOIN dbo.att_breaktime bt
        ON bt.id = tib.breaktime_id
    GROUP BY
        tib.timeinterval_id
)
SELECT
    ti.id,
    ti.alias,

    ti.duration,
    ISNULL(ba.break_duration, 0) AS break_duration,

    ti.work_time_duration AS biotime_ui_work_time_duration,

    CASE
        WHEN ISNULL(ti.work_type, 0) IN (1, 2) THEN 0
        WHEN ISNULL(ti.duration, 0) - ISNULL(ba.break_duration, 0) < 0 THEN 0
        ELSE ISNULL(ti.duration, 0) - ISNULL(ba.break_duration, 0)
    END AS computed_work_time_duration,

    CASE
        WHEN ISNULL(ti.enable_overtime, 0) = 1
             AND ISNULL(ti.max_ot_limit, 0) > 0
        THEN ti.max_ot_limit
        ELSE 0
    END AS scheduled_ot_minutes,

    CASE
        WHEN ISNULL(ti.work_type, 0) IN (1, 2) THEN 0
        WHEN ISNULL(ti.duration, 0) - ISNULL(ba.break_duration, 0) < 0 THEN 0
        ELSE ISNULL(ti.duration, 0) - ISNULL(ba.break_duration, 0)
    END AS expected_work_no_ot,

    CASE
        WHEN ISNULL(ti.work_type, 0) IN (1, 2) THEN 0
        WHEN
            ISNULL(ti.duration, 0)
            - ISNULL(ba.break_duration, 0)
            - CASE
                WHEN ISNULL(ti.enable_overtime, 0) = 1
                     AND ISNULL(ti.max_ot_limit, 0) > 0
                THEN ti.max_ot_limit
                ELSE 0
              END < 0
        THEN 0
        ELSE
            ISNULL(ti.duration, 0)
            - ISNULL(ba.break_duration, 0)
            - CASE
                WHEN ISNULL(ti.enable_overtime, 0) = 1
                     AND ISNULL(ti.max_ot_limit, 0) > 0
                THEN ti.max_ot_limit
                ELSE 0
              END
    END AS expected_regular_work,

    ISNULL(ti.work_time_duration, 0)
        -
    CASE
        WHEN ISNULL(ti.work_type, 0) IN (1, 2) THEN 0
        WHEN ISNULL(ti.duration, 0) - ISNULL(ba.break_duration, 0) < 0 THEN 0
        ELSE ISNULL(ti.duration, 0) - ISNULL(ba.break_duration, 0)
    END AS ui_vs_computed_work_error_minutes,

    CASE
        WHEN ISNULL(ti.enable_overtime, 0) = 1
             AND ISNULL(ti.max_ot_limit, 0) > 0
        THEN ti.max_ot_limit
        ELSE 0
    END AS computed_vs_regular_ot_difference_minutes,

    CASE
        WHEN ISNULL(ti.work_type, 0) IN (1, 2) THEN 'OFF_DAY_OK'
        ELSE 'OK'
    END AS audit_status

FROM dbo.att_timeinterval ti
LEFT JOIN break_agg ba
    ON ba.timeinterval_id = ti.id;
