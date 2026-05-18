CREATE VIEW dbo.custom_att_fnd_CleanedPunches_Corrected
AS
WITH p AS
(
    SELECT
        cp.*,
        ROW_NUMBER() OVER (
            PARTITION BY cp.emp_id, cp.work_date
            ORDER BY cp.punch_time, cp.id
        ) AS rn
    FROM dbo.custom_att_fnd_CleanedPunches cp
),
fixed AS
(
    SELECT
        p.*,

        CASE
            -- odd row should be IN
            WHEN p.rn % 2 = 1 THEN 0

            -- even row should be OUT
            WHEN p.rn % 2 = 0 THEN 1

            ELSE p.norm_punch_state
        END AS corrected_punch_state,

        CASE
            WHEN p.norm_punch_state <>
                 CASE
                     WHEN p.rn % 2 = 1 THEN 0
                     WHEN p.rn % 2 = 0 THEN 1
                     ELSE p.norm_punch_state
                 END
            THEN 1 ELSE 0
        END AS punch_state_corrected_flag
    FROM p
)
SELECT
    id,
    emp_id,
    work_date,
    punch_time,
    norm_punch_state,
    corrected_punch_state,
    punch_state_corrected_flag
FROM fixed;