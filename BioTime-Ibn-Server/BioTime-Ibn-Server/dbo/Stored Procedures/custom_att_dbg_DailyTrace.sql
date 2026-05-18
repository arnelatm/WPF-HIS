
CREATE PROCEDURE [dbo].[custom_att_dbg_DailyTrace]
    @EmpID  INT,
    @AttDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @pEmpID INT = @EmpID;
    DECLARE @pAttDate DATE = @AttDate;

    PRINT 'START';

    PRINT '01_NormalizedPunches';
    SELECT '01_NormalizedPunches' AS step, *
    FROM dbo.custom_att_fnd_NormalizedPunches
    WHERE emp_id = @pEmpID
      AND work_date = @pAttDate
    ORDER BY punch_time
    OPTION (RECOMPILE);

    PRINT '02_CleanedPunches';
    SELECT '02_CleanedPunches' AS step, *
    FROM dbo.custom_att_fnd_CleanedPunches
    WHERE emp_id = @pEmpID
      AND work_date = @pAttDate
    ORDER BY punch_time
    OPTION (RECOMPILE);

    PRINT '03_PunchSegments';
    SELECT '03_PunchSegments' AS step, *
    FROM dbo.custom_att_fnd_PunchSegments
    WHERE emp_id = @pEmpID
      AND work_date = @pAttDate
    ORDER BY segment_no, punch_time
    OPTION (RECOMPILE);

    PRINT '04_WorkedIntervals';
    SELECT '04_WorkedIntervals' AS step, *
    FROM dbo.custom_att_fnd_WorkedIntervals
    WHERE emp_id = @pEmpID
      AND work_date = @pAttDate
    ORDER BY in_segment_no
    OPTION (RECOMPILE);

    PRINT '05_DailyWorkedMinutes';
    SELECT '05_DailyWorkedMinutes' AS step, *
    FROM dbo.custom_att_fnd_DailyWorkedMinutes
    WHERE emp_id = @pEmpID
      AND work_date = @pAttDate
    OPTION (RECOMPILE);

	PRINT '06_EffectiveScheduleResolved';
	SELECT
		'06_EffectiveScheduleResolved' AS step,
		es.emp_id,
		es.att_date,
		es.effective_schedule_source,
		es.base_is_off_day,
		es.resolved_is_off_day,
		es.effective_shift_id,
		es.effective_time_interval_id,
		ti.alias AS timetable_name,
		ti.work_type,
		ti.use_mode,
		ti.work_time_duration,
		es.effective_required_work_minutes,
		es.effective_scheduled_in_datetime,
		es.effective_scheduled_out_datetime
	FROM dbo.custom_att_fnd_EffectiveScheduleResolved es
	LEFT JOIN dbo.att_timeinterval ti
		ON ti.id = es.effective_time_interval_id
	WHERE es.emp_id = @pEmpID
	  AND es.att_date = @pAttDate
	OPTION (RECOMPILE);

    PRINT '07_DailyBase';
    SELECT '07_DailyBase' AS step,
        emp_id, att_date, date_type, schedule_source,
        effective_scheduled_in, effective_scheduled_out,
        effective_required_work_minutes,
        worked_minutes, recomputed_worked_minutes,
        scheduled_ot_cap_minutes
    FROM dbo.custom_att_calc_DailyBase
    WHERE emp_id = @pEmpID
      AND att_date = @pAttDate
    OPTION (RECOMPILE);

    PRINT '08_DailyMetricsTable';
    SELECT '08_DailyMetricsTable' AS step, *
    FROM dbo.custom_att_DailyMetrics
    WHERE emp_id = @pEmpID
      AND att_date = @pAttDate
    OPTION (RECOMPILE);

    PRINT '09_FactDailyAttendance';
    SELECT '09_FactDailyAttendance' AS step, *
    FROM dbo.Custom_att_fact_DailyAttendance
    WHERE emp_id = @pEmpID
      AND att_date = @pAttDate
    OPTION (RECOMPILE);

    PRINT 'END';
END