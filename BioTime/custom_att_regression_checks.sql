USE [BioTime];
GO

-- =========================================
-- custom_att regression checks
-- =========================================

-- 1) Known daily trace case
PRINT '1) Daily trace check';
EXEC dbo.custom_att_dbg_DailyTrace
    @EmpID = 6,
    @AttDate = '2026-03-05';
GO

-- 2) Missing punch anomalies for March 2026
PRINT '2) Missing punch anomaly check';
SELECT *
FROM dbo.custom_att_calc_DailyAttendanceSummary
WHERE anomaly_flag IN ('MissingOut', 'MissingIn', 'NoPunch')
  AND att_date BETWEEN '2026-03-01' AND '2026-03-31'
ORDER BY emp_id, att_date;
GO

-- 3) Holiday / Holiday OT cases for March 2026
PRINT '3) Holiday case check';
SELECT *
FROM dbo.custom_att_calc_DailyAttendanceSummary
WHERE business_day_type IN ('Holiday', 'HolidayOT')
  AND att_date BETWEEN '2026-03-01' AND '2026-03-31'
ORDER BY emp_id, att_date;
GO

-- 4) Rest day / Rest day OT cases for March 2026
PRINT '4) Rest day case check';
SELECT *
FROM dbo.custom_att_calc_DailyAttendanceSummary
WHERE business_day_type IN ('RestDay', 'RestDayOT')
  AND att_date BETWEEN '2026-03-01' AND '2026-03-31'
ORDER BY emp_id, att_date;
GO

-- 5) Monthly rollup check for known employee
PRINT '5) Monthly rollup check';
EXEC dbo.custom_att_GetMonthlyAttendanceRollup
    @DateFrom = '2026-03-01',
    @DateTo   = '2026-03-31',
    @EmpID    = 24;
GO

-- 6) Monthly attendance report check for known employee
PRINT '6) Monthly attendance report check';
EXEC dbo.custom_att_GetMonthlyAttendanceReport
    @DateFrom = '2026-03-01',
    @DateTo   = '2026-03-31',
    @EmpID    = 24;
GO

-- 7) Monthly attendance summary check for known employee
PRINT '7) Monthly attendance summary check';
EXEC dbo.custom_att_GetMonthlyAttendanceSummary
    @DateFrom = '2026-03-01',
    @DateTo   = '2026-03-31',
    @EmpID    = 24;
GO