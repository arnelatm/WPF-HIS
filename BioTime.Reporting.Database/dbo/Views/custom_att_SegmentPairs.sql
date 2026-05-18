
create VIEW [dbo].[custom_att_SegmentPairs]
AS
WITH segment_summary AS
(
    SELECT
        ps.emp_id,
        ps.work_date,
        ps.segment_no,
        MIN(ps.punch_time) AS segment_start_time,
        MAX(ps.punch_time) AS segment_end_time,
        COUNT(*) AS segment_punch_count,
        MIN(ps.id) AS first_punch_id,
        MAX(ps.id) AS last_punch_id
    FROM dbo.custom_att_PunchSegments ps
    GROUP BY
        ps.emp_id,
        ps.work_date,
        ps.segment_no
),
paired AS
(
    SELECT
        s1.emp_id,
        s1.work_date,

        s1.segment_no AS in_segment_no,
        s1.segment_start_time AS in_time,
        s1.segment_end_time AS in_segment_end_time,
        s1.segment_punch_count AS in_segment_punch_count,
        s1.first_punch_id AS in_first_punch_id,
        s1.last_punch_id AS in_last_punch_id,

        s2.segment_no AS out_segment_no,
        s2.segment_start_time AS out_segment_start_time,
        s2.segment_end_time AS out_time,
        s2.segment_punch_count AS out_segment_punch_count,
        s2.first_punch_id AS out_first_punch_id,
        s2.last_punch_id AS out_last_punch_id

    FROM segment_summary s1
    LEFT JOIN segment_summary s2
        ON  s2.emp_id = s1.emp_id
        AND s2.work_date = s1.work_date
        AND s2.segment_no = s1.segment_no + 1
    WHERE s1.segment_no % 2 = 1
)
SELECT
    p.emp_id,
    p.work_date,

    p.in_segment_no,
    p.out_segment_no,

    p.in_time,
    p.out_time,

    p.in_segment_end_time,
    p.out_segment_start_time,

    p.in_segment_punch_count,
    p.out_segment_punch_count,

    p.in_first_punch_id,
    p.in_last_punch_id,
    p.out_first_punch_id,
    p.out_last_punch_id,

    CASE
        WHEN p.out_segment_no IS NULL THEN 1
        ELSE 0
    END AS is_open_pair,

    CASE
        WHEN p.out_time IS NOT NULL
         AND p.out_time >= p.in_time
        THEN DATEDIFF(MINUTE, p.in_time, p.out_time)
        ELSE NULL
    END AS paired_minutes,

    CASE
        WHEN p.out_time IS NOT NULL
         AND p.out_time >= p.in_time
        THEN DATEDIFF(SECOND, p.in_time, p.out_time)
        ELSE NULL
    END AS paired_seconds
FROM paired p;