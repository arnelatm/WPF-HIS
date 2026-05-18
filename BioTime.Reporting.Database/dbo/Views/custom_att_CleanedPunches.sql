
CREATE   VIEW [dbo].[custom_att_CleanedPunches]
AS
WITH ordered AS
(
    SELECT
        np.emp_id,
        np.work_date,
        np.punch_time,
        np.id,
        LAG(np.punch_time) OVER
        (
            PARTITION BY np.emp_id, np.work_date
            ORDER BY np.punch_time, np.id
        ) AS prev_punch_time
    FROM dbo.custom_att_NormalizedPunches np
),
marked AS
(
    SELECT
        o.emp_id,
        o.work_date,
        o.punch_time,
        o.id,
        CASE
            WHEN o.prev_punch_time IS NULL THEN 1
            WHEN DATEDIFF(MINUTE, o.prev_punch_time, o.punch_time) > 5 THEN 1
            ELSE 0
        END AS is_new_burst
    FROM ordered o
),
bursted AS
(
    SELECT
        m.emp_id,
        m.work_date,
        m.punch_time,
        m.id,
        SUM(m.is_new_burst) OVER
        (
            PARTITION BY m.emp_id, m.work_date
            ORDER BY m.punch_time, m.id
            ROWS UNBOUNDED PRECEDING
        ) AS burst_no
    FROM marked m
),
collapsed AS
(
    SELECT
        b.emp_id,
        b.work_date,
        b.burst_no,
        MIN(b.punch_time) AS cleaned_punch_time,
        MIN(b.id) AS kept_trans_id,
        COUNT(*) AS burst_punch_count
    FROM bursted b
    GROUP BY
        b.emp_id,
        b.work_date,
        b.burst_no
)
SELECT
    c.emp_id,
    c.work_date,
    c.cleaned_punch_time AS punch_time,
    c.kept_trans_id AS id,
    c.burst_no,
    c.burst_punch_count,
    CASE WHEN c.burst_punch_count > 1 THEN 1 ELSE 0 END AS is_duplicate_burst
FROM collapsed c;