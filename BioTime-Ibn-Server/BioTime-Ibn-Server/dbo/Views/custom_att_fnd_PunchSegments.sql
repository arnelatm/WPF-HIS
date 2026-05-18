
CREATE VIEW [dbo].[custom_att_fnd_PunchSegments]
AS
WITH burst_rep AS
(
    SELECT
        cp.emp_id,
        cp.work_date,
        cp.id,
        cp.punch_time,
        cp.burst_no,
        cp.burst_punch_count,
        cp.is_duplicate_burst,
        ROW_NUMBER() OVER
        (
            PARTITION BY cp.emp_id, cp.work_date, cp.burst_no
            ORDER BY cp.punch_time, cp.id
        ) AS burst_rn
    FROM dbo.custom_att_fnd_CleanedPunches cp
),
base AS
(
    SELECT
        br.emp_id,
        br.work_date,
        br.id,
        br.punch_time,
        br.burst_no,
        br.burst_punch_count,
        br.is_duplicate_burst
    FROM burst_rep br
    WHERE br.burst_rn = 1
)
SELECT
    b.emp_id,
    b.work_date,
    b.id,
    b.punch_time,
    b.burst_no,
    b.burst_punch_count,
    b.is_duplicate_burst,
    DENSE_RANK() OVER
    (
        PARTITION BY b.emp_id, b.work_date
        ORDER BY b.burst_no
    ) AS segment_no
FROM base b;
