
CREATE   VIEW [dbo].[custom_att_audit_MonthlyRawHoursSummary]
AS
WITH numbered_punches AS
(
    SELECT
        ps.emp_id,
        ps.work_date,
        YEAR(ps.work_date) AS year_no,
        MONTH(ps.work_date) AS month_no,
        ps.segment_no,
        ps.punch_time
    FROM dbo.custom_att_fnd_PunchSegments ps
),
present_days AS
(
    SELECT
        np.emp_id,
        np.work_date,
        np.year_no,
        np.month_no,
        1 AS day_present
    FROM numbered_punches np
    GROUP BY
        np.emp_id,
        np.work_date,
        np.year_no,
        np.month_no
),
paired_segments AS
(
    SELECT
        p1.emp_id,
        p1.work_date,
        p1.year_no,
        p1.month_no,
        p1.segment_no AS in_segment_no,
        p1.punch_time AS punch_in,
        p2.segment_no AS out_segment_no,
        p2.punch_time AS punch_out,
        CASE
            WHEN p2.punch_time IS NOT NULL
             AND p2.punch_time > p1.punch_time
            THEN DATEDIFF(MINUTE, p1.punch_time, p2.punch_time)
            ELSE 0
        END AS worked_minutes,
        CASE
            WHEN p2.punch_time IS NOT NULL
             AND p2.punch_time > p1.punch_time
            THEN 1
            ELSE 0
        END AS has_valid_pair
    FROM numbered_punches p1
    LEFT JOIN numbered_punches p2
        ON p1.emp_id = p2.emp_id
       AND p1.work_date = p2.work_date
       AND p2.segment_no = p1.segment_no + 1
    WHERE p1.segment_no % 2 = 1
),
daily_pairs AS
(
    SELECT
        ps.emp_id,
        ps.work_date,
        ps.year_no,
        ps.month_no,
        SUM(ps.worked_minutes) AS worked_minutes,
        MAX(ps.has_valid_pair) AS has_valid_pair
    FROM paired_segments ps
    GROUP BY
        ps.emp_id,
        ps.work_date,
        ps.year_no,
        ps.month_no
),
daily_rollup AS
(
    SELECT
        pd.emp_id,
        pd.work_date,
        pd.year_no,
        pd.month_no,
        pd.day_present,
        ISNULL(dp.worked_minutes, 0) AS worked_minutes,
        ISNULL(dp.has_valid_pair, 0) AS has_valid_pair
    FROM present_days pd
    LEFT JOIN daily_pairs dp
        ON pd.emp_id = dp.emp_id
       AND pd.work_date = dp.work_date
)
SELECT
    dr.emp_id,
    e.first_name,
    e.department,
    dr.year_no,
    dr.month_no,
    SUM(dr.day_present) AS days_present,
    SUM(CASE WHEN dr.has_valid_pair = 0 THEN 1 ELSE 0 END) AS ignored_unpaired_days,
    SUM(dr.worked_minutes) AS total_work_minutes,
    CAST(SUM(dr.worked_minutes) / 60.0 AS DECIMAL(10,2)) AS total_work_hours,
    CAST(
        CASE
            WHEN SUM(dr.day_present) = 0 THEN 0
            ELSE SUM(dr.worked_minutes) / 60.0 / SUM(dr.day_present)
        END
        AS DECIMAL(10,2)
    ) AS average_work_hours
FROM daily_rollup dr
LEFT JOIN vw_employees e
    ON dr.emp_id = e.id
GROUP BY
    dr.emp_id,
    e.first_name,
    e.department,
    dr.year_no,
    dr.month_no;
