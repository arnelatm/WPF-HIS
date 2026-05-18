

CREATE VIEW [dbo].[custom_att_fnd_SegmentPairs]
AS
WITH cleaned AS
(
    SELECT
        emp_id,
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
        work_date
),

/* Normal IN punches */
ins AS
(
    SELECT
        c.emp_id,
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
        c.work_date,
        c.id AS out_punch_id,
        c.punch_time AS out_time,
        ROW_NUMBER() OVER
        (
            PARTITION BY c.emp_id, c.work_date
            ORDER BY c.punch_time, c.id
        ) AS out_no
    FROM cleaned c
    WHERE c.norm_punch_state = 1
),

matched AS
(
    SELECT
        i.emp_id,
        i.work_date,
        i.in_no,
        i.in_punch_id,
        i.in_time,
        o.out_no,
        o.out_punch_id,
        o.out_time,
        ROW_NUMBER() OVER
        (
            PARTITION BY i.emp_id, i.work_date, i.in_no
            ORDER BY o.out_time, o.out_punch_id
        ) AS rn
    FROM ins i
    LEFT JOIN outs o
        ON o.emp_id = i.emp_id
       AND o.work_date = i.work_date
       AND o.out_time > i.in_time
       AND o.out_no >= i.in_no
),

normal_pairs AS
(
    SELECT
        emp_id,
        work_date,

        in_no AS in_segment_no,
        out_no AS out_segment_no,

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
    FROM matched
    WHERE rn = 1 OR rn IS NULL
),

/* Fallback: no OUT punch, but at least 2 valid punches.
   Treat first punch as IN and last punch as inferred OUT. */
fallback_pairs AS
(
    SELECT
        ds.emp_id,
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
FROM fallback_pairs;
