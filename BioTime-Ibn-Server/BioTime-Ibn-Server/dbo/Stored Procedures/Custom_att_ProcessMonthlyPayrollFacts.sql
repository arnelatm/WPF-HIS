


CREATE PROCEDURE [dbo].[Custom_att_ProcessMonthlyPayrollFacts]
    @DateFrom date,
    @DateTo   date,
    @EmpID    int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @LateGraceMinutes int;
    DECLARE @EarlyOutGraceMinutes int;
    DECLARE @MaxWorkHours int;
    DECLARE @ExcessThresholdMinutes int;
    DECLARE @WorkCompletionToleranceMinutes int;

    SELECT @LateGraceMinutes =
        ISNULL(MAX(CASE WHEN config_key = 'LateGraceMinutes' THEN config_value END), 10),
           @EarlyOutGraceMinutes =
        ISNULL(MAX(CASE WHEN config_key = 'EarlyOutGraceMinutes' THEN config_value END), 5),
           @MaxWorkHours =
        ISNULL(MAX(CASE WHEN config_key = 'MaxWorkHours' THEN config_value END), 16),
           @ExcessThresholdMinutes =
        ISNULL(MAX(CASE WHEN config_key = 'ExcessThresholdMinutes' THEN config_value END), 120),
           @WorkCompletionToleranceMinutes =
        ISNULL(MAX(CASE WHEN config_key = 'WorkCompletionToleranceMinutes' THEN config_value END), 30)
    FROM dbo.custom_att_Config;

    --------------------------------------------------
    -- 0A. Materialize DailyBase once
    --------------------------------------------------
    IF OBJECT_ID('tempdb..#DailyBase') IS NOT NULL
        DROP TABLE #DailyBase;

	SELECT *
	INTO #DailyBase
	FROM dbo.custom_att_calc_DailyBase
	WHERE att_date BETWEEN @DateFrom AND @DateTo
	  AND (@EmpID IS NULL OR emp_id = @EmpID)
	OPTION (RECOMPILE);

    CREATE INDEX IX_DailyBase_EmpDate
    ON #DailyBase(emp_id, att_date);

    --------------------------------------------------
    -- 0. Insert missing fact rows
    --------------------------------------------------
    INSERT INTO dbo.Custom_att_fact_DailyAttendance (
        emp_id,
        att_date,
        year_no,
        month_no
    )
    SELECT
        b.emp_id,
        b.att_date,
        YEAR(b.att_date),
        MONTH(b.att_date)
    FROM #DailyBase b
    LEFT JOIN dbo.Custom_att_fact_DailyAttendance f WITH (UPDLOCK, HOLDLOCK)
        ON f.emp_id = b.emp_id
       AND f.att_date = b.att_date
    WHERE f.emp_id IS NULL;

    --------------------------------------------------
    -- A. Daily worked-time aggregate
    --------------------------------------------------
    IF OBJECT_ID('tempdb..#PunchAgg') IS NOT NULL
        DROP TABLE #PunchAgg;

    SELECT
        dwm.emp_id,
        dwm.work_date AS att_date,
        0 AS corrected_punch_count,
        dwm.first_clock_in,
        dwm.last_clock_out,
        ISNULL(dwm.total_worked_minutes, 0) AS paired_worked_minutes,
        CASE
            WHEN dwm.first_clock_in IS NOT NULL
             AND dwm.last_clock_out IS NULL
            THEN 1
            ELSE 0
        END AS open_pair_count,
        ISNULL(dwm.worked_interval_count, 0) AS segment_count
    INTO #PunchAgg
    FROM dbo.custom_att_fnd_DailyWorkedMinutes dwm
    WHERE dwm.work_date BETWEEN @DateFrom AND @DateTo
      AND (@EmpID IS NULL OR dwm.emp_id = @EmpID)
    OPTION (RECOMPILE);
    CREATE INDEX IX_PunchAgg_EmpDate
    ON #PunchAgg(emp_id, att_date);

    --------------------------------------------------
    -- B. Latest raw punch of the day
    --------------------------------------------------
    IF OBJECT_ID('tempdb..#RawPunchAgg') IS NOT NULL
        DROP TABLE #RawPunchAgg;

    ;WITH x AS (
        SELECT
            t.emp_id,
            CAST(t.punch_time AS date) AS att_date,
            t.punch_time,
            t.punch_state,
            ROW_NUMBER() OVER (
                PARTITION BY t.emp_id, CAST(t.punch_time AS date)
                ORDER BY t.punch_time DESC
            ) AS rn
        FROM dbo.iclock_transaction t
        WHERE t.punch_time >= @DateFrom
          AND t.punch_time < DATEADD(DAY, 1, @DateTo)
          AND (@EmpID IS NULL OR t.emp_id = @EmpID)
    )
    SELECT
        emp_id,
        att_date,
        punch_time AS latest_punch_time,
        punch_state AS latest_punch_state
    INTO #RawPunchAgg
    FROM x
    WHERE rn = 1;

    CREATE INDEX IX_RawPunchAgg_EmpDate
    ON #RawPunchAgg(emp_id, att_date);

    --------------------------------------------------
    -- B.1 Approved Compensatory Leave
    --------------------------------------------------
    IF OBJECT_ID('tempdb..#CompLeave') IS NOT NULL
        DROP TABLE #CompLeave;

    SELECT
        wi.employee_id AS emp_id,
        CAST(l.start_time AS date) AS att_date,
        SUM(CAST(ISNULL(l.leave_day, 0) * 60 AS decimal(10,2))) AS comp_leave_minutes
    INTO #CompLeave
    FROM dbo.att_leave l
    INNER JOIN dbo.workflow_workflowinstance wi
        ON wi.id = l.workflowinstance_ptr_id
    INNER JOIN dbo.att_paycode pc
        ON pc.id = l.pay_code_id
    WHERE l.start_time >= @DateFrom
      AND l.start_time < DATEADD(DAY, 1, @DateTo)
      AND pc.code IN ('CP', 'CPL')
      AND ISNULL(wi.approval_status, 0) = 2
      AND (@EmpID IS NULL OR wi.employee_id = @EmpID)
    GROUP BY
        wi.employee_id,
        CAST(l.start_time AS date);

    CREATE INDEX IX_CompLeave_EmpDate
    ON #CompLeave(emp_id, att_date);

    --------------------------------------------------
    -- 1. Build payroll source
    --------------------------------------------------
    IF OBJECT_ID('tempdb..#PayrollSrc') IS NOT NULL
        DROP TABLE #PayrollSrc;

    SELECT
        b.emp_id,
        b.att_date,

        COALESCE(p.first_clock_in, b.first_clock_in) AS first_clock_in,
        COALESCE(p.last_clock_out, b.last_clock_out) AS last_clock_out,

        CASE
            WHEN ISNULL(b.use_mode, 0) = 1
                THEN ISNULL(b.recomputed_worked_minutes, 0)
            ELSE ISNULL(p.paired_worked_minutes, 0)
        END AS worked_minutes,

        ISNULL(b.ot_minutes, 0) AS payload_ot_minutes,
        ISNULL(b.use_mode, 0) AS use_mode,
        ISNULL(b.scheduled_ot_cap_minutes, 0) AS scheduled_ot_cap_minutes,

        ISNULL(es.effective_schedule_source, 'Unscheduled') AS schedule_source,
        ISNULL(es.resolved_is_off_day, 0) AS resolved_is_off_day,

        ti.alias AS effective_timetable_name,
        ISNULL(ti.work_type, 0) AS effective_work_type,

        ISNULL(p.open_pair_count, 0) AS open_pair_count,
        ISNULL(p.corrected_punch_count, 0) AS corrected_punch_count,

        CASE
            WHEN ISNULL(b.use_mode, 0) = 1 THEN 0
            ELSE ISNULL(p.segment_count, 0)
        END AS pair_count,

        es.effective_scheduled_in_datetime,
        es.effective_scheduled_out_datetime,

        rp.latest_punch_time,
        rp.latest_punch_state,

        base_date_type =
            CASE
                WHEN b.date_type = 1 THEN 1
                WHEN b.date_type = 2 THEN 2
                WHEN ISNULL(es.base_is_off_day, 0) = 1 THEN 2
                ELSE 0
            END,

        required_minutes =
            CASE
                WHEN b.date_type = 1
                     AND ISNULL(es.effective_required_work_minutes, 0) <= 0
                THEN 0

                WHEN ISNULL(es.resolved_is_off_day, 0) = 1
                     AND ISNULL(es.effective_required_work_minutes, 0) <= 0
                THEN 0

                WHEN es.effective_schedule_source = 'Temporary'
                     AND ISNULL(es.effective_required_work_minutes, 0) = 0
                THEN 0

                WHEN ISNULL(b.use_mode, 0) = 1
                     AND ISNULL(ti.work_time_duration, 0) > 0
                THEN ISNULL(ti.work_time_duration, 0)

                WHEN ISNULL(es.effective_required_work_minutes, 0) > 0
                THEN
                    CASE
                        WHEN ISNULL(es.effective_required_work_minutes, 0)
                             - CASE
                                   WHEN ISNULL(ti.enable_overtime, 0) = 1
                                    AND ISNULL(ti.max_ot_limit, 0) > 0
                                   THEN ti.max_ot_limit
                                   ELSE 0
                               END < 0
                        THEN 0
                        ELSE
                            ISNULL(es.effective_required_work_minutes, 0)
                            - CASE
                                  WHEN ISNULL(ti.enable_overtime, 0) = 1
                                   AND ISNULL(ti.max_ot_limit, 0) > 0
                                  THEN ti.max_ot_limit
                                  ELSE 0
                              END
                    END

                ELSE ISNULL(b.required_work_minutes, 0)
            END,

        scheduled_ot_minutes =
            CASE
                WHEN ISNULL(ti.enable_overtime, 0) = 1
                 AND ISNULL(ti.max_ot_limit, 0) > 0
                THEN ti.max_ot_limit
                ELSE 0
            END,

        CASE
            WHEN ISNULL(cl.comp_leave_minutes, 0) >
                 CASE
                     WHEN ISNULL(es.effective_required_work_minutes, 0) > 0
                     THEN ISNULL(es.effective_required_work_minutes, 0)
                     ELSE ISNULL(b.required_work_minutes, 0)
                 END
            THEN
                 CASE
                     WHEN ISNULL(es.effective_required_work_minutes, 0) > 0
                     THEN ISNULL(es.effective_required_work_minutes, 0)
                     ELSE ISNULL(b.required_work_minutes, 0)
                 END
            ELSE ISNULL(cl.comp_leave_minutes, 0)
        END AS comp_leave_minutes

    INTO #PayrollSrc
    FROM #DailyBase b
    LEFT JOIN dbo.custom_att_fnd_EffectiveScheduleResolved es
        ON es.emp_id = b.emp_id
       AND es.att_date = b.att_date
    LEFT JOIN dbo.att_timeinterval ti
        ON ti.id = es.effective_time_interval_id
    LEFT JOIN #PunchAgg p
        ON p.emp_id = b.emp_id
       AND p.att_date = b.att_date
    LEFT JOIN #RawPunchAgg rp
        ON rp.emp_id = b.emp_id
       AND rp.att_date = b.att_date
    LEFT JOIN #CompLeave cl
        ON cl.emp_id = b.emp_id
       AND cl.att_date = b.att_date
	OPTION (RECOMPILE);

    CREATE INDEX IX_PayrollSrc_EmpDate
    ON #PayrollSrc(emp_id, att_date);

    --------------------------------------------------
    -- 2. Add calculated fields
    --------------------------------------------------
    ALTER TABLE #PayrollSrc ADD
        shortfall_minutes decimal(10,2) NULL,
        absence_minutes decimal(10,2) NULL,
        final_ot_minutes decimal(10,2) NULL,
        final_late_minutes decimal(10,2) NULL,
        actual_late_minutes decimal(10,2) NULL,
        final_early_out_minutes decimal(10,2) NULL,
        actual_early_out_minutes decimal(10,2) NULL,
        attendance_status_final varchar(50) NULL,
        anomaly_flag_final varchar(100) NULL,
        needs_payroll_review_final bit NULL,
        schedule_label_final varchar(100) NULL,
        excess_minutes decimal(10,2) NULL,
        reconciliation_variance_minutes decimal(10,2) NULL,
        reconciliation_status varchar(50) NULL,
        work_gap_minutes decimal(10,2) NULL;

    --------------------------------------------------
    -- 2A. Shortfall and absence
    --------------------------------------------------
    UPDATE s
    SET
        shortfall_minutes =
            CASE
                WHEN s.required_minutes > s.worked_minutes + ISNULL(s.comp_leave_minutes, 0)
                 AND s.required_minutes - s.worked_minutes - ISNULL(s.comp_leave_minutes, 0) > @WorkCompletionToleranceMinutes
                THEN s.required_minutes - s.worked_minutes - ISNULL(s.comp_leave_minutes, 0)
                ELSE 0
            END,

        absence_minutes =
            CASE
                WHEN s.required_minutes > 0
                 AND s.worked_minutes = 0
                 AND ISNULL(s.comp_leave_minutes, 0) = 0
                THEN s.required_minutes

                WHEN s.required_minutes > 0
                 AND s.worked_minutes + ISNULL(s.comp_leave_minutes, 0) < s.required_minutes
                THEN s.required_minutes - s.worked_minutes - ISNULL(s.comp_leave_minutes, 0)

                ELSE 0
            END
    FROM #PayrollSrc s;

    --------------------------------------------------
    -- 2B. OT calculation
    --------------------------------------------------
    UPDATE s
    SET
        final_ot_minutes =
            CASE
                WHEN s.required_minutes = 0
                 AND s.worked_minutes > 0
                THEN
                    CASE
                        WHEN s.scheduled_ot_cap_minutes > 0
                        THEN
                            CASE
                                WHEN s.worked_minutes > s.scheduled_ot_cap_minutes
                                THEN s.scheduled_ot_cap_minutes
                                ELSE s.worked_minutes
                            END
                        ELSE s.worked_minutes
                    END

                WHEN s.required_minutes > 0
                 AND s.worked_minutes > s.required_minutes
                THEN
                    CASE
                        WHEN s.scheduled_ot_minutes > 0
                        THEN
                            CASE
                                WHEN s.worked_minutes - s.required_minutes > s.scheduled_ot_minutes
                                THEN s.scheduled_ot_minutes
                                ELSE s.worked_minutes - s.required_minutes
                            END
                        ELSE 0
                    END

                ELSE 0
            END
    FROM #PayrollSrc s;

    --------------------------------------------------
    -- 2B.1 Excess and reconciliation
    --------------------------------------------------
    UPDATE s
    SET
        excess_minutes =
            CASE
                WHEN s.required_minutes > 0
                 AND ISNULL(s.final_ot_minutes, 0) = 0
                 AND (s.worked_minutes - s.required_minutes) > @ExcessThresholdMinutes
                THEN s.worked_minutes - s.required_minutes

                WHEN s.required_minutes > 0
                 AND ISNULL(s.final_ot_minutes, 0) > 0
                 AND (s.worked_minutes - s.required_minutes - ISNULL(s.final_ot_minutes, 0)) > @ExcessThresholdMinutes
                THEN s.worked_minutes - s.required_minutes - ISNULL(s.final_ot_minutes, 0)

                ELSE 0
            END,

        reconciliation_variance_minutes =
            s.worked_minutes
            + ISNULL(s.comp_leave_minutes, 0)
            - s.required_minutes
            - ISNULL(s.final_ot_minutes, 0),

        reconciliation_status =
            CASE
                WHEN s.required_minutes = 0 AND s.worked_minutes = 0
                    THEN 'NotRequiredNoWork'

                WHEN s.required_minutes = 0 AND s.worked_minutes > 0 AND s.final_ot_minutes > 0
                    THEN 'OT Work'

                WHEN s.required_minutes = 0 AND s.worked_minutes > 0
                    THEN 'NonRequiredWorked'

                WHEN ABS(
                        s.worked_minutes
                        + ISNULL(s.comp_leave_minutes, 0)
                        - s.required_minutes
                        - ISNULL(s.final_ot_minutes, 0)
                     ) <= @WorkCompletionToleranceMinutes
                    THEN 'Balanced'

                WHEN (
                    s.required_minutes
                    - s.worked_minutes
                    - ISNULL(s.comp_leave_minutes, 0)
                 ) > @WorkCompletionToleranceMinutes
                    THEN 'Shortfall'

                WHEN s.worked_minutes > s.required_minutes
                 AND ISNULL(s.final_ot_minutes, 0) > 0
                    THEN 'WorkedWithOT'

                WHEN s.worked_minutes > s.required_minutes
                 AND ISNULL(s.final_ot_minutes, 0) = 0
                    THEN 'ExcessNonOT'

                ELSE 'Review'
            END
    FROM #PayrollSrc s;

    --------------------------------------------------
    -- 2B.2 Work Gap
    --------------------------------------------------
    UPDATE s
    SET work_gap_minutes =
        s.worked_minutes
        + ISNULL(s.comp_leave_minutes, 0)
        - s.required_minutes
        - ISNULL(s.final_ot_minutes, 0)
        - ISNULL(s.excess_minutes, 0)
        + ISNULL(s.shortfall_minutes, 0)
    FROM #PayrollSrc s;

    --------------------------------------------------
    -- 2C. True early-out calculation
    --------------------------------------------------
    UPDATE s
    SET
        final_early_out_minutes =
            CASE
                WHEN s.required_minutes <= 0 THEN 0
                WHEN s.worked_minutes <= 0 THEN 0
                WHEN s.use_mode = 1 THEN 0
                WHEN s.effective_scheduled_out_datetime IS NULL THEN 0
                WHEN s.latest_punch_time IS NULL THEN 0
                WHEN s.latest_punch_state <> 1 THEN 0
                WHEN s.worked_minutes >= s.required_minutes THEN 0
                WHEN s.latest_punch_time < DATEADD(MINUTE, -@EarlyOutGraceMinutes, s.effective_scheduled_out_datetime)
                THEN DATEDIFF(
                        MINUTE,
                        s.latest_punch_time,
                        DATEADD(MINUTE, -@EarlyOutGraceMinutes, s.effective_scheduled_out_datetime)
                     )
                ELSE 0
            END,

        actual_early_out_minutes =
            CASE
                WHEN s.required_minutes <= 0 THEN 0
                WHEN s.worked_minutes <= 0 THEN 0
                WHEN s.use_mode = 1 THEN 0
                WHEN s.effective_scheduled_out_datetime IS NULL THEN 0
                WHEN s.latest_punch_time IS NULL THEN 0
                WHEN s.latest_punch_state <> 1 THEN 0
                WHEN s.worked_minutes >= s.required_minutes THEN 0
                WHEN s.latest_punch_time < s.effective_scheduled_out_datetime
                THEN DATEDIFF(MINUTE, s.latest_punch_time, s.effective_scheduled_out_datetime)
                ELSE 0
            END
    FROM #PayrollSrc s;

    --------------------------------------------------
    -- 2D. Late calculation
    --------------------------------------------------
    UPDATE s
    SET
        final_late_minutes =
            CASE
                WHEN s.required_minutes <= 0 THEN 0
                WHEN s.effective_scheduled_in_datetime IS NULL THEN 0
                WHEN s.first_clock_in IS NULL THEN 0
                WHEN s.use_mode = 1 THEN 0
                WHEN s.first_clock_in > DATEADD(MINUTE, @LateGraceMinutes, s.effective_scheduled_in_datetime)
                THEN DATEDIFF(MINUTE, DATEADD(MINUTE, @LateGraceMinutes, s.effective_scheduled_in_datetime), s.first_clock_in)
                ELSE 0
            END,

        actual_late_minutes =
            CASE
                WHEN s.required_minutes <= 0 THEN 0
                WHEN s.effective_scheduled_in_datetime IS NULL THEN 0
                WHEN s.first_clock_in IS NULL THEN 0
                WHEN s.use_mode = 1 THEN 0
                WHEN s.first_clock_in > s.effective_scheduled_in_datetime
                THEN DATEDIFF(MINUTE, s.effective_scheduled_in_datetime, s.first_clock_in)
                ELSE 0
            END
    FROM #PayrollSrc s;

    --------------------------------------------------
    -- 2E. Status, anomaly, review flag, label
    --------------------------------------------------
    UPDATE s
    SET
        attendance_status_final =
            CASE
                WHEN s.required_minutes = 0 AND s.worked_minutes = 0
                    THEN 'NotRequired'

                WHEN s.required_minutes = 0 AND s.worked_minutes > 0 AND ISNULL(s.final_ot_minutes, 0) > 0
                    THEN 'OT Day'

                WHEN s.required_minutes = 0 AND s.worked_minutes > 0
                    THEN 'WorkedNonRequired'

                WHEN s.required_minutes > 0 AND ISNULL(s.comp_leave_minutes, 0) >= s.required_minutes
                    THEN 'CompensatoryLeave'

                WHEN s.required_minutes > 0
                 AND ISNULL(s.comp_leave_minutes, 0) > 0
                 AND s.worked_minutes + ISNULL(s.comp_leave_minutes, 0) >= s.required_minutes
                    THEN 'PresentWithCompLeave'

                WHEN s.required_minutes > 0 AND ISNULL(s.comp_leave_minutes, 0) > 0
                    THEN 'PartialWithCompLeave'

                WHEN s.required_minutes > 0
                 AND s.worked_minutes + ISNULL(s.comp_leave_minutes, 0) >= s.required_minutes - @WorkCompletionToleranceMinutes
                    THEN 'Present'

                WHEN s.required_minutes > 0
                 AND s.worked_minutes = 0
                 AND (s.first_clock_in IS NOT NULL OR s.last_clock_out IS NOT NULL)
                    THEN 'Partial'

                WHEN s.required_minutes > 0 AND s.worked_minutes = 0
                    THEN 'Absent'

                WHEN s.required_minutes > 0 AND s.worked_minutes < s.required_minutes
                    THEN 'Partial'

                ELSE 'Present'
            END,

        anomaly_flag_final =
            CASE
                WHEN s.required_minutes = 0 AND s.worked_minutes = 0
                    THEN 'Normal'

                WHEN s.required_minutes > 0
                 AND s.worked_minutes = 0
                 AND s.first_clock_in IS NULL
                 AND s.last_clock_out IS NULL
                    THEN 'AbsentNoPunch'

                WHEN s.first_clock_in IS NOT NULL AND s.last_clock_out IS NULL
                    THEN 'MissingOut'

                WHEN s.first_clock_in IS NULL AND s.last_clock_out IS NOT NULL
                    THEN 'MissingIn'

                WHEN ISNULL(s.open_pair_count, 0) > 0
                    THEN 'IncompletePunchPair'

                WHEN s.worked_minutes > (@MaxWorkHours * 60)
                    THEN 'ExcessiveWorkHours'

                WHEN s.required_minutes > 0
                 AND s.worked_minutes > 0
                 AND s.effective_scheduled_in_datetime IS NOT NULL
                 AND s.first_clock_in < DATEADD(HOUR, -2, s.effective_scheduled_in_datetime)
                    THEN 'WorkedOutsideSchedule'

                WHEN ISNULL(s.corrected_punch_count, 0) > 0
                 AND s.worked_minutes BETWEEN 240 AND 720
                    THEN 'AutoCorrectedOK'

                WHEN ISNULL(s.corrected_punch_count, 0) > 0
                    THEN 'AutoCorrectedPunchState'

                WHEN s.required_minutes > 0
                 AND (s.required_minutes - s.worked_minutes - ISNULL(s.comp_leave_minutes, 0)) > @WorkCompletionToleranceMinutes
                    THEN 'IncompleteWork'

                ELSE 'Normal'
            END,

        needs_payroll_review_final =
            CASE
                WHEN s.required_minutes = 0 AND s.worked_minutes = 0
                    THEN 0

                WHEN s.required_minutes > 0
                 AND s.worked_minutes + ISNULL(s.comp_leave_minutes, 0) >= s.required_minutes
                    THEN 0

                WHEN s.worked_minutes > (@MaxWorkHours * 60) THEN 1
                WHEN ISNULL(s.open_pair_count, 0) > 0 THEN 1
                WHEN s.first_clock_in IS NOT NULL AND s.last_clock_out IS NULL THEN 1
                WHEN s.first_clock_in IS NULL AND s.last_clock_out IS NOT NULL THEN 1

                WHEN s.required_minutes > 0
                 AND s.required_minutes - s.worked_minutes - ISNULL(s.comp_leave_minutes, 0) > @WorkCompletionToleranceMinutes
                    THEN 1

                ELSE 0
            END,

        schedule_label_final =
            CASE
                WHEN ISNULL(s.required_minutes, 0) > 0 AND s.schedule_source = 'Temporary'
                    THEN 'Temporary Schedule'

                WHEN ISNULL(s.required_minutes, 0) > 0
                    THEN 'Employee Schedule'

                WHEN ISNULL(s.required_minutes, 0) = 0
                 AND ISNULL(s.effective_timetable_name, '') LIKE '%Holiday%'
                    THEN 'Holiday'

                WHEN ISNULL(s.required_minutes, 0) = 0
                 AND s.base_date_type = 1
                    THEN 'Holiday'

                WHEN ISNULL(s.required_minutes, 0) = 0
                 AND s.effective_work_type IN (1, 2)
                    THEN 'Assigned Off Day'

                ELSE 'Rest Day'
            END
    FROM #PayrollSrc s;

    --------------------------------------------------
    -- 3. Update fact table
    --------------------------------------------------
    UPDATE f
    SET
        f.first_clock_in = s.first_clock_in,
        f.last_clock_out = s.last_clock_out,

        f.recomputed_worked_minutes = s.worked_minutes,
        f.worked_hours = CAST(s.worked_minutes / 60.0 AS decimal(10,2)),

        f.excess_minutes = s.excess_minutes,
        f.excess_hours = CAST(s.excess_minutes / 60.0 AS decimal(10,2)),

        f.shortfall_minutes = s.shortfall_minutes,
        f.shortfall_hours = CAST(s.shortfall_minutes / 60.0 AS decimal(10,2)),

        f.reconciliation_status = s.reconciliation_status,
        f.reconciliation_variance_minutes = s.reconciliation_variance_minutes,

        f.ot_minutes = s.final_ot_minutes,
        f.ot_hours = CAST(s.final_ot_minutes / 60.0 AS decimal(10,2)),

        f.recomputed_absence_hours = CAST(s.absence_minutes / 60.0 AS decimal(10,2)),

        f.late_minutes = s.final_late_minutes,
        f.actual_late_minutes = s.actual_late_minutes,
        f.early_out_minutes = s.final_early_out_minutes,
        f.actual_early_out_minutes = s.actual_early_out_minutes,

        f.daily_status =
            CASE
                WHEN ISNULL(s.required_minutes, 0) > 0
                    THEN 'RegularDay'

                WHEN ISNULL(s.required_minutes, 0) = 0
                 AND ISNULL(s.effective_timetable_name, '') LIKE '%Holiday%'
                    THEN 'Holiday'

                WHEN ISNULL(s.required_minutes, 0) = 0
                 AND s.base_date_type = 1
                    THEN 'Holiday'

                ELSE 'RestDay'
            END,

        f.attendance_status = s.attendance_status_final,
        f.needs_payroll_review = s.needs_payroll_review_final,
        f.required_scheduled_hours = CAST(s.required_minutes / 60.0 AS decimal(10,2)),
        f.schedule_label = s.schedule_label_final,
        f.anomaly_flag = s.anomaly_flag_final,
        f.work_gap_minutes = s.work_gap_minutes,
        f.comp_leave_eligible_flag =
            CASE WHEN ISNULL(s.comp_leave_minutes, 0) > 0 THEN 1 ELSE 0 END,
        f.comp_leave_minutes = ISNULL(s.comp_leave_minutes, 0),
        f.comp_leave_hours = CAST(ISNULL(s.comp_leave_minutes, 0) / 60.0 AS decimal(10,2))
    FROM dbo.Custom_att_fact_DailyAttendance f
    JOIN #PayrollSrc s
        ON s.emp_id = f.emp_id
       AND s.att_date = f.att_date;

    --------------------------------------------------
    -- 4. Return control totals
    --------------------------------------------------
    SELECT
        @DateFrom AS date_from,
        @DateTo AS date_to,
        @EmpID AS emp_id_filter,

        COUNT(*) AS fact_rows_processed,

        CAST(SUM(ISNULL(recomputed_worked_minutes, 0)) / 60.0 AS decimal(10,2)) AS total_worked_hours,
        CAST(SUM(ISNULL(ot_minutes, 0)) / 60.0 AS decimal(10,2)) AS total_ot_hours,
        CAST(SUM(ISNULL(recomputed_absence_hours, 0)) AS decimal(10,2)) AS total_absence_hours,

        SUM(ISNULL(late_minutes, 0)) AS total_late_minutes,
        SUM(ISNULL(early_out_minutes, 0)) AS total_early_out_minutes
    FROM dbo.Custom_att_fact_DailyAttendance
    WHERE att_date BETWEEN @DateFrom AND @DateTo
      AND (@EmpID IS NULL OR emp_id = @EmpID);
END;