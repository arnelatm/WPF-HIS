

CREATE VIEW [dbo].[custom_att_fnd_SegmentPairs]
AS
WITH cleaned AS
(
    SELECT
        emp_id,
        emp_code,
        work_date,
        id,
        punch_time,
        punch_state,
        corrected_punch_state AS norm_punch_state,
        corrected_punch_flag
    FROM dbo.custom_att_fnd_CorrectedPunches
),

daily_stats AS
(
    SELECT
        emp_id,
        emp_code,
        work_date,
        COUNT(*) AS punch_count,
        MIN(punch_time) AS first_punch_time,
        MAX(punch_time) AS last_punch_time,
        MIN(id) AS first_punch_id,
        MAX(id) AS last_punch_id,
        SUM(CASE WHEN norm_punch_state = 1 THEN 1 ELSE 0 END) AS real_out_count,
        SUM(ISNULL(corrected_punch_flag, 0)) AS corrected_punch_count
    FROM cleaned
    GROUP BY
        emp_id,
        emp_code,
        work_date
),

/* Normal IN punches */
ins AS
(
    SELECT
        c.emp_id,
        c.emp_code,
        c.work_date,
        c.id AS in_punch_id,
        c.punch_time AS in_time,
        ROW_NUMBER() OVER
        (
            PARTITION BY c.emp_id, c.work_date
            ORDER BY c.punch_time, c.id
        ) AS in_no
    FROM cleaned c
    INNER JOIN daily_stats ds
        ON ds.emp_id = c.emp_id
       AND ds.work_date = c.work_date
    WHERE c.norm_punch_state = 0
      AND NOT
      (
          ds.real_out_count = 0
          AND ds.punch_count >= 2
          AND ds.last_punch_time > ds.first_punch_time
      )
),

/* Normal OUT punches */
outs AS
(
    SELECT
        c.emp_id,
        c.emp_code,
        c.work_date,
        c.id AS out_punch_id,
        c.punch_time AS out_time,
        ROW_NUMBER() OVER
        (
            PARTITION BY c.emp_id, c.work_date
            ORDER BY c.punch_time, c.id
        ) AS out_no,
        LAG(c.punch_time) OVER
        (
            PARTITION BY c.emp_id, c.work_date
            ORDER BY c.punch_time, c.id
        ) AS previous_out_time
    FROM cleaned c
    WHERE c.norm_punch_state = 1
),

punch_counts AS
(
    SELECT
        c.emp_id,
        c.emp_code,
        c.work_date,
        SUM(CASE WHEN c.norm_punch_state = 0 THEN 1 ELSE 0 END) AS in_count,
        SUM(CASE WHEN c.norm_punch_state = 1 THEN 1 ELSE 0 END) AS out_count
    FROM cleaned c
    GROUP BY
        c.emp_id,
        c.emp_code,
        c.work_date
),

single_in_multi_out_pairs AS
(
    SELECT
        i.emp_id,
        i.emp_code,
        i.work_date,
        i.in_no AS in_segment_no,
        o.out_no AS out_segment_no,
        i.in_time,
        o.out_time,
        i.in_punch_id,
        o.out_punch_id
    FROM ins i
    INNER JOIN punch_counts pc
        ON pc.emp_id = i.emp_id
       AND pc.work_date = i.work_date
    OUTER APPLY
    (
        SELECT TOP (1)
            o.out_no,
            o.out_punch_id,
            o.out_time
        FROM outs o
        WHERE o.emp_id = i.emp_id
          AND o.work_date = i.work_date
          AND o.out_time > i.in_time
        ORDER BY
            o.out_time DESC,
            o.out_punch_id DESC
    ) o
    WHERE pc.in_count = 1
      AND pc.out_count > 1
      AND o.out_time IS NOT NULL
),

out_closed_pairs AS
(
    SELECT
        o.emp_id,
        o.emp_code,
        o.work_date,
        i.in_no AS in_segment_no,
        o.out_no AS out_segment_no,
        i.in_time,
        o.out_time,
        i.in_punch_id,
        o.out_punch_id
    FROM outs o
    INNER JOIN punch_counts pc
        ON pc.emp_id = o.emp_id
       AND pc.work_date = o.work_date
    OUTER APPLY
    (
        SELECT TOP (1)
            i.in_no,
            i.in_punch_id,
            i.in_time
        FROM ins i
        WHERE i.emp_id = o.emp_id
          AND i.work_date = o.work_date
          AND i.in_time < o.out_time
          AND i.in_time > ISNULL(o.previous_out_time, CONVERT(datetime2(7), '19000101'))
        ORDER BY
            i.in_time DESC,
            i.in_punch_id DESC
    ) i
    WHERE NOT (pc.in_count = 1 AND pc.out_count > 1)
      AND i.in_time IS NOT NULL
),

matched_pairs AS
(
    SELECT *
    FROM single_in_multi_out_pairs

    UNION ALL

    SELECT *
    FROM out_closed_pairs
),

normal_pairs AS
(
    SELECT
        emp_id,
        emp_code,
        work_date,

        in_segment_no,
        out_segment_no,

        in_time,
        out_time,

        in_time AS in_segment_end_time,
        out_time AS out_segment_start_time,

        1 AS in_segment_punch_count,
        CASE WHEN out_time IS NULL THEN NULL ELSE 1 END AS out_segment_punch_count,

        in_punch_id AS in_first_punch_id,
        in_punch_id AS in_last_punch_id,
        out_punch_id AS out_first_punch_id,
        out_punch_id AS out_last_punch_id,

        CASE WHEN out_time IS NULL THEN 1 ELSE 0 END AS is_open_pair,

        CASE
            WHEN out_time IS NOT NULL AND out_time >= in_time
                THEN DATEDIFF(MINUTE, in_time, out_time)
            ELSE NULL
        END AS paired_minutes,

        CASE
            WHEN out_time IS NOT NULL AND out_time >= in_time
                THEN DATEDIFF(SECOND, in_time, out_time)
            ELSE NULL
        END AS paired_seconds
    FROM matched_pairs
),

open_pairs AS
(
    SELECT
        i.emp_id,
        i.emp_code,
        i.work_date,

        i.in_no AS in_segment_no,
        CAST(NULL AS bigint) AS out_segment_no,

        i.in_time,
        CAST(NULL AS datetime2(7)) AS out_time,

        i.in_time AS in_segment_end_time,
        CAST(NULL AS datetime2(7)) AS out_segment_start_time,

        1 AS in_segment_punch_count,
        CAST(NULL AS int) AS out_segment_punch_count,

        i.in_punch_id AS in_first_punch_id,
        i.in_punch_id AS in_last_punch_id,
        CAST(NULL AS int) AS out_first_punch_id,
        CAST(NULL AS int) AS out_last_punch_id,

        1 AS is_open_pair,

        CAST(NULL AS int) AS paired_minutes,
        CAST(NULL AS int) AS paired_seconds
    FROM ins i
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM matched_pairs mp
        WHERE mp.emp_id = i.emp_id
          AND mp.work_date = i.work_date
          AND mp.in_punch_id = i.in_punch_id
    )
),

/* Fallback: no OUT punch, but at least 2 valid punches.
   Treat first punch as IN and last punch as inferred OUT. */
fallback_pairs AS
(
    SELECT
        ds.emp_id,
        ds.emp_code,
        ds.work_date,

        1 AS in_segment_no,
        1 AS out_segment_no,

        ds.first_punch_time AS in_time,
        ds.last_punch_time AS out_time,

        ds.first_punch_time AS in_segment_end_time,
        ds.last_punch_time AS out_segment_start_time,

        1 AS in_segment_punch_count,
        1 AS out_segment_punch_count,

        ds.first_punch_id AS in_first_punch_id,
        ds.first_punch_id AS in_last_punch_id,
        ds.last_punch_id AS out_first_punch_id,
        ds.last_punch_id AS out_last_punch_id,

        0 AS is_open_pair,

        DATEDIFF(MINUTE, ds.first_punch_time, ds.last_punch_time) AS paired_minutes,
        DATEDIFF(SECOND, ds.first_punch_time, ds.last_punch_time) AS paired_seconds
    FROM daily_stats ds
    WHERE ds.real_out_count = 0
      AND ds.punch_count >= 2
      AND ds.last_punch_time > ds.first_punch_time
)

SELECT *
FROM normal_pairs

UNION ALL

SELECT *
FROM open_pairs

UNION ALL

SELECT *
FROM fallback_pairs;
