









CREATE VIEW [dbo].[custom_att_calc_DailyAttendanceSummary_disabled]
AS
/*
Layer: Calculation
Role: Canonical daily attendance source for all reporting
Used by:
- custom_att_rpt_MonthlyRollupSource
- custom_att_GetMonthlyAttendanceRollup
- custom_att_GetMonthlyAttendanceReport
- custom_att_GetMonthlyAttendanceSummary

Notes:
- Final daily business output
- All reports should read from this directly or indirectly
*/
SELECT
    -- Identity
    m.emp_id,
    m.att_date,

    -- Schedule resolution
    m.resolved_schedule_source AS effective_schedule_source,
    m.effective_shift_id,
    m.effective_time_interval_id,

    -- Schedule times
    CASE
        WHEN ISNULL(m.resolved_schedule_source, 'Unscheduled') = 'Unscheduled' THEN NULL
        ELSE m.scheduled_in
    END AS scheduled_in,

    CASE
        WHEN ISNULL(m.resolved_schedule_source, 'Unscheduled') = 'Unscheduled' THEN NULL
        ELSE m.scheduled_out
    END AS scheduled_out,

    m.first_clock_in,
    m.last_clock_out,

    -- Work metrics
    m.required_scheduled_hours,
    m.recomputed_worked_minutes,
    m.recomputed_worked_hours,
    m.worked_hours,
    m.absence_hours,

    CAST(
        CASE
            WHEN m.regular_required_minutes <= m.recomputed_worked_minutes THEN 0
            ELSE m.regular_required_minutes - m.recomputed_worked_minutes
        END / 60.0
    AS decimal(10,2)) AS recomputed_absence_hours,

    -- Deviations
    m.late_minutes,
    m.early_out_minutes,

    -- OT
    m.ot_minutes,
    m.ot_hours,
	m.scheduled_ot_cap_minutes,

	-- Completion
	m.work_completion_pct,
	m.recomputed_excess_hours,

	CAST(
		CASE
			WHEN ISNULL(m.effective_required_work_minutes, 0) > 0
			 AND ISNULL(m.recomputed_worked_minutes, 0) > ISNULL(m.effective_required_work_minutes, 0)
			THEN ISNULL(m.recomputed_worked_minutes, 0) - ISNULL(m.effective_required_work_minutes, 0)
			ELSE 0
		END / 60.0
	AS decimal(10,2)) AS excess_work_hours,

	CAST(
		CASE
			WHEN ISNULL(m.effective_required_work_minutes, 0) > 0
			 AND ISNULL(m.recomputed_worked_minutes, 0) > ISNULL(m.effective_required_work_minutes, 0)
			 AND ISNULL(m.ot_minutes, 0) = 0
			THEN ISNULL(m.recomputed_worked_minutes, 0) - ISNULL(m.effective_required_work_minutes, 0)
			ELSE 0
		END / 60.0
	AS decimal(10,2)) AS non_ot_excess_hours,

    -- Comp leave
    m.comp_leave_eligible_flag,
    m.comp_leave_minutes,
    m.comp_leave_hours,

    CASE
        WHEN m.comp_leave_eligible_flag = 1 THEN 'For Compensatory Leave Review'
        ELSE NULL
    END AS leave_action_note,

    -- =========================================
    -- DATE CLASSIFICATION
    -- =========================================

    m.date_type,               -- system/raw
    m.base_date_type,          -- business truth
    m.weekday_name,

    CASE
        WHEN m.base_date_type = 0 THEN 'RegularDay'
        WHEN m.base_date_type = 1 THEN 'Holiday'
        WHEN m.base_date_type = 2 THEN 'RestDay'
        ELSE 'Unclassified'
    END AS daily_status,

    -- =========================================
    -- BUSINESS DAY TYPE (FINAL FIX)
    -- =========================================

	CASE
		WHEN ISNULL(m.effective_required_work_minutes, 0) = 0
			 AND ISNULL(m.recomputed_worked_minutes, 0) > 0 THEN
			CASE
				-- ✅ FIX: treat scheduled work as regular day
				WHEN m.schedule_source IN ('Temporary','Employee','Group','Department')
					THEN 'RegularDay'

				-- only true OT if really unscheduled
				WHEN m.base_date_type = 2 THEN 'RestDayOT'
				WHEN m.base_date_type = 1 THEN 'HolidayOT'
				ELSE 'RegularDayOT'
			END

		WHEN m.base_date_type = 2
			 AND ISNULL(m.ot_minutes, 0) > 0
			 AND m.schedule_source = 'Unscheduled'  -- ✅ added safety
			THEN 'RestDayOT'

		WHEN m.base_date_type = 1
			 AND ISNULL(m.ot_minutes, 0) > 0
			 AND m.schedule_source = 'Unscheduled'  -- ✅ added safety
			THEN 'HolidayOT'

		WHEN m.base_date_type = 0
			 AND ISNULL(m.ot_minutes, 0) > 0
			THEN 'RegularDayWithOT'

		WHEN m.base_date_type = 2 THEN 'RestDay'
		WHEN m.base_date_type = 1 THEN 'Holiday'
		ELSE 'RegularDay'
	END AS business_day_type,

    -- =========================================
    -- ATTENDANCE STATUS
    -- =========================================

	CASE
		WHEN ISNULL(m.effective_required_work_minutes, 0) = 0
			THEN 'NotRequired'

		-- Has punch in or punch out, but no valid worked minutes
		-- Treat as Partial, not Absent
		WHEN ISNULL(m.recomputed_worked_minutes, 0) = 0
		 AND (
				m.first_clock_in IS NOT NULL
			 OR m.last_clock_out IS NOT NULL
			 )
			THEN 'Partial'

		-- Truly no work and no usable punch
		WHEN ISNULL(m.recomputed_worked_minutes, 0) = 0
			THEN 'Absent'

		WHEN m.recomputed_worked_minutes >=
			 CASE
				 WHEN m.effective_required_work_minutes - m.WorkCompletionToleranceMinutes < 0
					 THEN 0
				 ELSE m.effective_required_work_minutes - m.WorkCompletionToleranceMinutes
			 END
			THEN 'Present'

		ELSE 'Partial'
	END AS attendance_status,

    -- OT flag
    CASE
		WHEN ISNULL(m.ot_hours, 0) > 0
		 AND ISNULL(m.recomputed_worked_minutes, 0) > 0
		THEN 'WithOT'
        ELSE 'NoOT'
    END AS ot_status,

    -- =========================================
    -- SCHEDULE LABEL (ALIGNED WITH NEW MODEL)
    -- =========================================

	CASE
		-- Holiday OT
		WHEN m.base_date_type = 1
			 AND ISNULL(m.recomputed_worked_minutes, 0) > 0
			THEN
				CASE
					WHEN m.schedule_source = 'Temporary'
						THEN 'Temporary Holiday OT'
					WHEN m.schedule_source = 'Unscheduled'
						THEN 'Holiday Work (Unscheduled)'
					ELSE 'Holiday OT'
				END

		-- Rest Day OT
		WHEN m.base_date_type = 2
			 AND ISNULL(m.recomputed_worked_minutes, 0) > 0
			THEN
				CASE
					WHEN m.schedule_source = 'Temporary'
						THEN 'Temporary Rest Day OT'
					WHEN m.schedule_source = 'Unscheduled'
						THEN 'Rest Day Work (Unscheduled)'
					ELSE 'Rest Day OT'
				END

		-- No-work holiday / rest day labels
		WHEN m.base_date_type = 1
			THEN 'Holiday'

		WHEN m.base_date_type = 2
			 AND m.base_is_off_day = 1
			THEN 'Assigned Off Day'

		WHEN m.base_date_type = 2
			THEN 'Rest Day'

		-- Regular-day schedule labels
		WHEN m.schedule_source = 'Temporary'
			THEN 'Temporary Schedule'

		WHEN m.schedule_source = 'Employee'
			THEN 'Employee Schedule'

		WHEN m.schedule_source = 'Group'
			THEN 'Group Schedule'

		WHEN m.schedule_source = 'Department'
			THEN 'Department Schedule'

		WHEN m.schedule_source = 'Unscheduled'
			 AND ISNULL(m.recomputed_worked_minutes, 0) > 0
			THEN 'Unscheduled Work'

		ELSE 'Unscheduled'
	END AS schedule_label,

    -- =========================================
    -- PUNCH STATUS
    -- =========================================

    CASE
        WHEN m.recomputed_worked_minutes > 0 THEN 'OK'
        WHEN m.first_clock_in IS NULL AND m.last_clock_out IS NULL THEN 'NoPunch'
        WHEN m.first_clock_in IS NOT NULL AND m.last_clock_out IS NULL THEN 'MissingOut'
        WHEN m.first_clock_in IS NULL AND m.last_clock_out IS NOT NULL THEN 'MissingIn'
        ELSE 'OK'
    END AS punch_status,

    -- =========================================
    -- ANOMALY + GROUPING
    -- =========================================

    ISNULL(m.anomaly_flag, 'Normal') AS anomaly_flag,

    CASE
        WHEN m.anomaly_flag IN ('NoPunch','MissingOut','MissingIn','InvalidPunch')
            THEN 'PunchIssue'
        WHEN m.anomaly_flag IN ('ExcessWorkNoOT','HolidayWorkedUnscheduled','WorkedOnAssignedOffDay')
            THEN 'BusinessRule'
        WHEN m.anomaly_flag = 'Normal'
            THEN 'Normal'
        ELSE 'Other'
    END AS anomaly_group,

    ISNULL(m.needs_payroll_review, 0) AS needs_payroll_review,

    -- =========================================
    -- REPORT RULE
    -- =========================================

    CASE
        WHEN m.effective_required_work_minutes > 0
         AND m.regular_paid_minutes > 0
        THEN 1
        ELSE 0
    END AS is_present_by_report_rule,

	CASE
		WHEN ISNULL(m.effective_required_work_minutes, 0) > 0
		 AND ISNULL(m.recomputed_worked_minutes, 0) = 0
		 AND (
				m.first_clock_in IS NOT NULL
			 OR m.last_clock_out IS NOT NULL
			 )
			THEN 'Partial - incomplete punch'

		WHEN ISNULL(m.effective_required_work_minutes, 0) > 0
		 AND ISNULL(m.recomputed_worked_minutes, 0) = 0
			THEN 'Absent'

		WHEN m.anomaly_flag IN ('NoPunch','MissingOut','MissingIn','InvalidPunch')
			THEN 'Punch issue - review required'

		WHEN ISNULL(m.effective_required_work_minutes, 0) > 0
		 AND ISNULL(m.recomputed_worked_minutes, 0) < ISNULL(m.effective_required_work_minutes, 0)
		 AND ISNULL(m.early_out_minutes, 0) >= 120
			THEN 'Severe early out'

		WHEN ISNULL(m.effective_required_work_minutes, 0) > 0
		 AND ISNULL(m.recomputed_worked_minutes, 0) < ISNULL(m.effective_required_work_minutes, 0)
			THEN 'Incomplete required work'

		WHEN ISNULL(m.effective_required_work_minutes, 0) > 0
		 AND ISNULL(m.recomputed_worked_minutes, 0) > ISNULL(m.effective_required_work_minutes, 0)
		 AND ISNULL(m.ot_minutes, 0) = 0
			THEN 'Excess non-OT work hours'

		WHEN ISNULL(m.ot_minutes, 0) > 0
			THEN 'Approved scheduled OT'

		ELSE 'Normal'
	END AS audit_flag

FROM dbo.custom_att_calc_DailyMetrics m;
