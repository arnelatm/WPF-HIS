CREATE VIEW dbo.[custom_att_audit_DailyPairingSummary]
AS
SELECT
    p.emp_id,
    p.att_date,
    COUNT(*) AS pair_rows,
    SUM(CASE WHEN p.in_trans_id IS NULL OR p.out_trans_id IS NULL THEN 1 ELSE 0 END) AS missing_pair_rows,
    SUM(CASE WHEN p.in_trans_id IS NULL AND p.out_trans_id IS NOT NULL THEN 1 ELSE 0 END) AS missing_in_rows,
    SUM(CASE WHEN p.in_trans_id IS NOT NULL AND p.out_trans_id IS NULL THEN 1 ELSE 0 END) AS missing_out_rows,
    SUM(CASE WHEN p.in_trans_id IS NOT NULL OR p.out_trans_id IS NOT NULL THEN 1 ELSE 0 END) AS nonblank_pair_rows,
    SUM(ISNULL(p.duration, 0)) AS paired_duration_seconds,
    SUM(ISNULL(p.worked_duration, 0)) AS paired_worked_duration_seconds
FROM dbo.att_payloadparing p
GROUP BY
    p.emp_id,
    p.att_date;
