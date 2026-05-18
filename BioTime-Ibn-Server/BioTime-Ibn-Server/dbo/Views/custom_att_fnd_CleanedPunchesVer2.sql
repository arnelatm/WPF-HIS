
CREATE VIEW [dbo].[custom_att_fnd_CleanedPunchesVer2]
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
)
SELECT
    emp_id,
    work_date,
    cleaned_punch_time AS punch_time,
    original_punch_state AS punch_state,
    norm_punch_state,
    kept_trans_id AS id,
    burst_no,
    burst_punch_count,
    CASE WHEN burst_punch_count > 1 THEN 1 ELSE 0 END AS is_duplicate_burst
FROM collapsed;