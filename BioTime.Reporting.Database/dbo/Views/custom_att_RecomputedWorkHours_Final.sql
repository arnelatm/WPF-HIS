
CREATE   VIEW [dbo].[custom_att_RecomputedWorkHours_Final]
AS
SELECT
    r.*,
    CAST(
        CASE
            WHEN r.raw_punch_confidence_score < 0 THEN 0
            WHEN r.raw_punch_confidence_score > 100 THEN 100
            ELSE r.raw_punch_confidence_score
        END
        AS decimal(10,2)
    ) AS punch_confidence_score
FROM dbo.custom_att_RecomputedWorkHours r;