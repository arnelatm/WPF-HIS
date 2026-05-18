

CREATE VIEW [dbo].[custom_att_fnd_WorkedIntervals]
AS
SELECT
    sp.emp_id,
    sp.work_date,
    sp.in_segment_no,
    sp.out_segment_no,
    sp.in_time,
    sp.out_time,

    DATEDIFF(MINUTE, sp.in_time, sp.out_time) AS worked_minutes,
    CAST(DATEDIFF(SECOND, sp.in_time, sp.out_time) / 3600.0 AS decimal(10,2)) AS worked_hours

FROM dbo.custom_att_fnd_SegmentPairs sp
WHERE sp.is_open_pair = 0
  AND sp.in_time IS NOT NULL
  AND sp.out_time IS NOT NULL
  AND sp.out_time >= sp.in_time;
