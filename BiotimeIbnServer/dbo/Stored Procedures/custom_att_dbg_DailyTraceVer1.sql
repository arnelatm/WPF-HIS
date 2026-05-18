


CREATE PROCEDURE [dbo].[custom_att_dbg_DailyTraceVer1]
    @EmpID  INT,
    @AttDate DATE
AS
/*
Layer: Debug Procedure
Role: Traces one employee and one attendance date across the main attendance pipeline
Primary Sources:
- Foundation views
- Calculation views
- Canonical daily attendance summary

Purpose:
- Troubleshoot discrepancies by showing results from each major layer in sequence
- Validate schedule resolution, worked minutes, metrics, and final daily status

Notes:
- Intended for diagnostics only
- Not a reporting source
*/
BEGIN
    SET NOCOUNT ON;

   -- 1) Normalized punches
    SELECT '01_NormalizedPunches' AS step, *
    FROM dbo.custom_att_fnd_NormalizedPunches
    WHERE emp_id = @EmpID AND work_date = @AttDate
    ORDER BY punch_time;

    -- 2) Cleaned punches
    SELECT '02_CleanedPunches' AS step, *
    FROM dbo.custom_att_fnd_CleanedPunches
    WHERE emp_id = @EmpID AND work_date = @AttDate
    ORDER BY punch_time;

    -- 3) Punch segments
    SELECT '03_PunchSegments' AS step, *
    FROM dbo.custom_att_fnd_PunchSegments
    WHERE emp_id = @EmpID AND work_date = @AttDate
    ORDER BY segment_no, punch_time;

    -- 4) Worked intervals
    SELECT '04_WorkedIntervals' AS step, *
    FROM dbo.custom_att_fnd_WorkedIntervals
    WHERE emp_id = @EmpID AND work_date = @AttDate
    ORDER BY in_segment_no;

    -- 5) Daily worked minutes
    SELECT '05_DailyWorkedMinutes' AS step, *
    FROM dbo.custom_att_fnd_DailyWorkedMinutes
    WHERE emp_id = @EmpID AND work_date = @AttDate;

    -- 6) Effective schedule
    SELECT '06_EffectiveScheduleResolved' AS step, *
    FROM dbo.custom_att_fnd_EffectiveScheduleResolved
    WHERE emp_id = @EmpID AND att_date = @AttDate;

    -- 7) DailyBase (key columns only)
    SELECT '07_DailyBase' AS step,
        emp_id, att_date, date_type, schedule_source,
        effective_scheduled_in, effective_scheduled_out,
        effective_required_work_minutes,
        worked_minutes, recomputed_worked_minutes,
        scheduled_ot_cap_minutes
    FROM dbo.custom_att_calc_DailyBase
    WHERE emp_id = @EmpID AND att_date = @AttDate;

	-- 8) DailyMetrics table
	SELECT '08_DailyMetrics' AS step, *
	FROM dbo.custom_att_DailyMetrics
	WHERE emp_id = @EmpID
	  AND att_date = @AttDate;

	-- 9) Final fact table
	SELECT '09_FactDailyAttendance' AS step, *
	FROM dbo.Custom_att_fact_DailyAttendance
	WHERE emp_id = @EmpID
	  AND att_date = @AttDate;
END
