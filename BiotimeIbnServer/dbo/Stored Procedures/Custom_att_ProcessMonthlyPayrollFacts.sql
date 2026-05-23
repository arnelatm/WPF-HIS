


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

    SELECT
        emp_id,
        att_date,
        date_type,
        first_clock_in,
        last_clock_out,
        recomputed_worked_minutes,
        ot_minutes,
        use_mode,
        scheduled_ot_cap_minutes,
        required_work_minutes
    INTO #DailyBase
    FROM dbo.custom_att_calc_DailyBase
    WHERE att_date BETWEEN @DateFrom AND @DateTo
      AND (@EmpID IS NULL OR emp_id = @EmpID)
      AND NOT EXISTS
      (
          SELECT 1
          FROM dbo.personnel_resign r
          WHERE r.employee_id = custom_att_calc_DailyBase.emp_id
            AND custom_att_calc_DailyBase.att_date > r.resign_date
      )
    OPTION (RECOMPILE);

    CREATE INDEX IX_DailyBase_EmpDate
    ON #DailyBase(emp_id, att_date);

    --------------------------------------------------
    -- 0. Insert missing fact rows
    --------------------------------------------------
    INSERT INTO dbo.custom_att_fact_DailyAttendance (
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
    LEFT JOIN dbo.custom_att_fact_DailyAttendance f WITH (UPDLOCK, HOLDLOCK)
        ON f.emp_id = b.emp_id
       AND f.att_date = b.att_date
    WHERE f.emp_id IS NULL;

    --------------------------------------------------
    -- A. Daily worked-time aggregate
    --------------------------------------------------
    IF OBJECT_ID('tempdb..#PunchAgg') IS NOT NULL
        DROP TABLE #PunchAgg;

    SELECT
        b.emp_id,
        b.att_date,
        0 AS corrected_punch_count,
        b.first_clock_in,
        b.last_clock_out,
        ISNULL(b.recomputed_worked_minutes, 0) AS paired_worked_minutes,
        CASE
            WHEN b.first_clock_in IS NOT NULL
             AND b.last_clock_out IS NULL
            THEN 1
            ELSE 0
        END AS open_pair_count,
        0 AS segment_count
    INTO #PunchAgg
    FROM #DailyBase b;
    CREATE INDEX IX_PunchAgg_EmpDate
    ON #PunchAgg(emp_id, att_date);

    --------------------------------------------------
    -- B. Latest raw punch of the day
    --------------------------------------------------
    IF OBJECT_ID('tempdb..#RawPunchAgg') IS NOT NULL
        DROP TABLE #RawPunchAgg;

    SELECT
        b.emp_id,
        b.att_date,
        rp.punch_time AS latest_punch_time,
        rp.punch_state AS latest_punch_state,
        fp.punch_time AS first_raw_punch_time,
        pc.raw_punch_count
    INTO #RawPunchAgg
    FROM #DailyBase b
    OUTER APPLY
    (
        SELECT TOP (1)
            t.punch_time,
            t.punch_state
        FROM dbo.iclock_transaction t
        WHERE t.emp_id = b.emp_id
          AND t.punch_time >= b.att_date
          AND t.punch_time < DATEADD(DAY, 1, b.att_date)
        ORDER BY t.punch_time DESC, t.id DESC
    ) rp
    OUTER APPLY
    (
        SELECT TOP (1)
            t.punch_time
        FROM dbo.iclock_transaction t
        WHERE t.emp_id = b.emp_id
          AND t.punch_time >= b.att_date
          AND t.punch_time < DATEADD(DAY, 1, b.att_date)
        ORDER BY t.punch_time, t.id
    ) fp
    OUTER APPLY
    (
        SELECT COUNT_BIG(*) AS raw_punch_count
        FROM dbo.iclock_transaction t
        WHERE t.emp_id = b.emp_id
          AND t.punch_time >= b.att_date
          AND t.punch_time < DATEADD(DAY, 1, b.att_date)
    ) pc
    WHERE rp.punch_time IS NOT NULL;

    CREATE INDEX IX_RawPunchAgg_EmpDate
    ON #RawPunchAgg(emp_id, att_date);

    --------------------------------------------------
    -- B.0 Worked intervals for split-duty comparison
    --------------------------------------------------
    IF OBJECT_ID('tempdb..#WorkedIntervals') IS NOT NULL
        DROP TABLE #WorkedIntervals;

    SELECT
        wi.emp_id,
        wi.work_date AS att_date,
        wi.in_segment_no,
        wi.out_segment_no,
        wi.in_time,
        wi.out_time,
        wi.worked_minutes
    INTO #WorkedIntervals
    FROM dbo.custom_att_fnd_WorkedIntervals wi
    WHERE wi.work_date BETWEEN @DateFrom AND @DateTo
      AND (@EmpID IS NULL OR wi.emp_id = @EmpID)
    OPTION (RECOMPILE);

    CREATE INDEX IX_WorkedIntervals_EmpDate
    ON #WorkedIntervals(emp_id, att_date);

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
    -- B.2 Materialize effective schedule once
    --------------------------------------------------
    IF OBJECT_ID('tempdb..#EffectiveSchedule') IS NOT NULL
        DROP TABLE #EffectiveSchedule;

    SELECT
        es.emp_id,
        es.att_date,
        es.effective_schedule_source,
        es.resolved_is_off_day,
        es.base_is_off_day,
        es.effective_required_work_minutes,
        es.effective_time_interval_id,
        es.effective_scheduled_in_datetime,
        es.effective_scheduled_out_datetime
    INTO #EffectiveSchedule
    FROM dbo.custom_att_fnd_EffectiveScheduleResolved es
    WHERE es.att_date BETWEEN @DateFrom AND @DateTo
      AND (@EmpID IS NULL OR es.emp_id = @EmpID)
    OPTION (RECOMPILE);

    CREATE INDEX IX_EffectiveSchedule_EmpDate
    ON #EffectiveSchedule(emp_id, att_date);

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
        rp.first_raw_punch_time,
        ISNULL(rp.raw_punch_count, 0) AS raw_punch_count,
        CASE
            WHEN rp.first_raw_punch_time IS NOT NULL
             AND COALESCE(p.first_clock_in, b.first_clock_in) IS NOT NULL
             AND rp.first_raw_punch_time < COALESCE(p.first_clock_in, b.first_clock_in)
            THEN 1
            ELSE 0
        END AS has_raw_punch_before_first_in,

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
    LEFT JOIN #EffectiveSchedule es
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
    -- 1A. Split-duty schedule segments
    --------------------------------------------------
    IF OBJECT_ID('tempdb..#ScheduleSegments') IS NOT NULL
        DROP TABLE #ScheduleSegments;

    ;WITH WorkDays AS
    (
        SELECT
            s.emp_id,
            s.att_date,
            es.effective_time_interval_id,
            es.effective_scheduled_in_datetime AS schedule_start_datetime,
            es.effective_scheduled_out_datetime AS schedule_end_datetime,
            ti.in_time
        FROM #PayrollSrc s
        INNER JOIN #EffectiveSchedule es
            ON es.emp_id = s.emp_id
           AND es.att_date = s.att_date
        INNER JOIN dbo.att_timeinterval ti
            ON ti.id = es.effective_time_interval_id
        WHERE s.required_minutes > 0
          AND ISNULL(s.use_mode, 0) <> 1
          AND es.effective_scheduled_in_datetime IS NOT NULL
          AND es.effective_scheduled_out_datetime IS NOT NULL
    ),
    Breaks AS
    (
        SELECT
            wd.emp_id,
            wd.att_date,
            DATEADD(
                MINUTE,
                CASE
                    WHEN DATEDIFF(MINUTE, wd.in_time, bt.period_start) < 0
                    THEN DATEDIFF(MINUTE, wd.in_time, bt.period_start) + 1440
                    ELSE DATEDIFF(MINUTE, wd.in_time, bt.period_start)
                END,
                wd.schedule_start_datetime
            ) AS break_start_datetime,
            DATEADD(
                MINUTE,
                CASE
                    WHEN DATEDIFF(MINUTE, wd.in_time, bt.period_start) < 0
                    THEN DATEDIFF(MINUTE, wd.in_time, bt.period_start) + 1440
                    ELSE DATEDIFF(MINUTE, wd.in_time, bt.period_start)
                END + ISNULL(bt.duration, 0),
                wd.schedule_start_datetime
            ) AS break_end_datetime
        FROM WorkDays wd
        INNER JOIN dbo.att_timeinterval_break_time tib
            ON tib.timeinterval_id = wd.effective_time_interval_id
        INNER JOIN dbo.att_breaktime bt
            ON bt.id = tib.breaktime_id
    ),
    ValidBreaks AS
    (
        SELECT
            b.emp_id,
            b.att_date,
            b.break_start_datetime,
            b.break_end_datetime,
            ROW_NUMBER() OVER
            (
                PARTITION BY b.emp_id, b.att_date
                ORDER BY b.break_start_datetime, b.break_end_datetime
            ) AS break_no,
            LAG(b.break_end_datetime) OVER
            (
                PARTITION BY b.emp_id, b.att_date
                ORDER BY b.break_start_datetime, b.break_end_datetime
            ) AS previous_break_end_datetime
        FROM Breaks b
        INNER JOIN WorkDays wd
            ON wd.emp_id = b.emp_id
           AND wd.att_date = b.att_date
        WHERE b.break_start_datetime > wd.schedule_start_datetime
          AND b.break_start_datetime < wd.schedule_end_datetime
          AND b.break_end_datetime > b.break_start_datetime
          AND b.break_end_datetime < wd.schedule_end_datetime
    ),
    Segments AS
    (
        SELECT
            wd.emp_id,
            wd.att_date,
            vb.break_no AS segment_no,
            COALESCE(vb.previous_break_end_datetime, wd.schedule_start_datetime) AS segment_start_datetime,
            vb.break_start_datetime AS segment_end_datetime
        FROM ValidBreaks vb
        INNER JOIN WorkDays wd
            ON wd.emp_id = vb.emp_id
           AND wd.att_date = vb.att_date

        UNION ALL

        SELECT
            wd.emp_id,
            wd.att_date,
            ISNULL(MAX(vb.break_no), 0) + 1 AS segment_no,
            COALESCE(MAX(vb.break_end_datetime), wd.schedule_start_datetime) AS segment_start_datetime,
            wd.schedule_end_datetime AS segment_end_datetime
        FROM WorkDays wd
        LEFT JOIN ValidBreaks vb
            ON vb.emp_id = wd.emp_id
           AND vb.att_date = wd.att_date
        GROUP BY
            wd.emp_id,
            wd.att_date,
            wd.schedule_start_datetime,
            wd.schedule_end_datetime
    )
    SELECT
        s.emp_id,
        s.att_date,
        s.segment_no,
        s.segment_start_datetime,
        s.segment_end_datetime
    INTO #ScheduleSegments
    FROM Segments s
    WHERE s.segment_end_datetime > s.segment_start_datetime;

    CREATE INDEX IX_ScheduleSegments_EmpDate
    ON #ScheduleSegments(emp_id, att_date);

    IF OBJECT_ID('tempdb..#SegmentTiming') IS NOT NULL
        DROP TABLE #SegmentTiming;

    SELECT
        ss.emp_id,
        ss.att_date,
        COUNT(*) AS schedule_segment_count,

        SUM(
            CASE
                WHEN wi.in_time IS NOT NULL
                 AND wi.in_time > DATEADD(MINUTE, @LateGraceMinutes, ss.segment_start_datetime)
                THEN DATEDIFF(MINUTE, DATEADD(MINUTE, @LateGraceMinutes, ss.segment_start_datetime), wi.in_time)
                ELSE 0
            END
        ) AS final_late_minutes,

        SUM(
            CASE
                WHEN wi.in_time IS NOT NULL
                 AND wi.in_time > ss.segment_start_datetime
                THEN DATEDIFF(MINUTE, ss.segment_start_datetime, wi.in_time)
                ELSE 0
            END
        ) AS actual_late_minutes,

        SUM(
            CASE
                WHEN wi.out_time IS NOT NULL
                 AND wi.out_time < DATEADD(MINUTE, -@EarlyOutGraceMinutes, ss.segment_end_datetime)
                THEN DATEDIFF(MINUTE, wi.out_time, DATEADD(MINUTE, -@EarlyOutGraceMinutes, ss.segment_end_datetime))
                ELSE 0
            END
        ) AS final_early_out_minutes,

        SUM(
            CASE
                WHEN wi.out_time IS NOT NULL
                 AND wi.out_time < ss.segment_end_datetime
                THEN DATEDIFF(MINUTE, wi.out_time, ss.segment_end_datetime)
                ELSE 0
            END
        ) AS actual_early_out_minutes,

        SUM(CASE WHEN wi.in_time IS NULL THEN 1 ELSE 0 END) AS unmatched_segment_count
    INTO #SegmentTiming
    FROM #ScheduleSegments ss
    OUTER APPLY
    (
        SELECT TOP (1)
            wi.in_time,
            wi.out_time
        FROM #WorkedIntervals wi
        WHERE wi.emp_id = ss.emp_id
          AND wi.att_date = ss.att_date
          AND wi.out_time > ss.segment_start_datetime
          AND wi.in_time < ss.segment_end_datetime
        ORDER BY
            CASE
                WHEN
                    DATEDIFF(
                        MINUTE,
                        CASE WHEN wi.in_time > ss.segment_start_datetime THEN wi.in_time ELSE ss.segment_start_datetime END,
                        CASE WHEN wi.out_time < ss.segment_end_datetime THEN wi.out_time ELSE ss.segment_end_datetime END
                    ) < 0
                THEN 0
                ELSE
                    DATEDIFF(
                        MINUTE,
                        CASE WHEN wi.in_time > ss.segment_start_datetime THEN wi.in_time ELSE ss.segment_start_datetime END,
                        CASE WHEN wi.out_time < ss.segment_end_datetime THEN wi.out_time ELSE ss.segment_end_datetime END
                    )
            END DESC,
            wi.in_time
    ) wi
    GROUP BY
        ss.emp_id,
        ss.att_date;

    CREATE INDEX IX_SegmentTiming_EmpDate
    ON #SegmentTiming(emp_id, att_date);

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
        schedule_segment_count int NULL,
        unmatched_schedule_segment_count int NULL,
        attendance_status_final varchar(50) NULL,
        anomaly_flag_final varchar(100) NULL,
        needs_payroll_review_final bit NULL,
        schedule_label_final varchar(100) NULL,
        actual_excess_minutes decimal(10,2) NULL,
        excess_minutes decimal(10,2) NULL,
        reconciliation_variance_minutes decimal(10,2) NULL,
        reconciliation_status varchar(50) NULL,
        work_gap_minutes decimal(10,2) NULL;

    --------------------------------------------------
    -- 2A. Shortfall, absence, and OT
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
            END,

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
        actual_excess_minutes =
            CASE
                WHEN s.required_minutes > 0
                 AND s.worked_minutes - s.required_minutes - ISNULL(s.final_ot_minutes, 0) > 0
                THEN s.worked_minutes - s.required_minutes - ISNULL(s.final_ot_minutes, 0)
                ELSE 0
            END,

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
    -- 2C. True early-out and late calculation
    --------------------------------------------------
    UPDATE s
    SET
        schedule_segment_count = ISNULL(st.schedule_segment_count, 1),
        unmatched_schedule_segment_count = ISNULL(st.unmatched_segment_count, 0),

        final_early_out_minutes =
            CASE
                WHEN ISNULL(st.schedule_segment_count, 1) > 1
                THEN ISNULL(st.final_early_out_minutes, 0)
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
                WHEN ISNULL(st.schedule_segment_count, 1) > 1
                THEN ISNULL(st.actual_early_out_minutes, 0)
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
            END,

        final_late_minutes =
            CASE
                WHEN ISNULL(st.schedule_segment_count, 1) > 1
                THEN ISNULL(st.final_late_minutes, 0)
                WHEN s.required_minutes <= 0 THEN 0
                WHEN s.effective_scheduled_in_datetime IS NULL THEN 0
                WHEN s.first_clock_in IS NULL THEN 0
                WHEN s.use_mode = 1 THEN 0
                WHEN s.has_raw_punch_before_first_in = 1
                 AND s.first_clock_in > DATEADD(MINUTE, @LateGraceMinutes, s.effective_scheduled_in_datetime)
                THEN 0
                WHEN s.first_clock_in > DATEADD(MINUTE, @LateGraceMinutes, s.effective_scheduled_in_datetime)
                THEN DATEDIFF(MINUTE, DATEADD(MINUTE, @LateGraceMinutes, s.effective_scheduled_in_datetime), s.first_clock_in)
                ELSE 0
            END,

        actual_late_minutes =
            CASE
                WHEN ISNULL(st.schedule_segment_count, 1) > 1
                THEN ISNULL(st.actual_late_minutes, 0)
                WHEN s.required_minutes <= 0 THEN 0
                WHEN s.effective_scheduled_in_datetime IS NULL THEN 0
                WHEN s.first_clock_in IS NULL THEN 0
                WHEN s.use_mode = 1 THEN 0
                WHEN s.has_raw_punch_before_first_in = 1
                 AND s.first_clock_in > s.effective_scheduled_in_datetime
                THEN 0
                WHEN s.first_clock_in > s.effective_scheduled_in_datetime
                THEN DATEDIFF(MINUTE, s.effective_scheduled_in_datetime, s.first_clock_in)
                ELSE 0
            END
    FROM #PayrollSrc s
    LEFT JOIN #SegmentTiming st
        ON st.emp_id = s.emp_id
       AND st.att_date = s.att_date;

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
                 AND (
                        s.first_clock_in IS NOT NULL
                     OR s.last_clock_out IS NOT NULL
                     OR s.latest_punch_time IS NOT NULL
                 )
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
                 AND s.latest_punch_time IS NULL
                    THEN 'AbsentNoPunch'

                WHEN s.first_clock_in IS NOT NULL AND s.last_clock_out IS NULL
                    THEN 'MissingOut'

                WHEN s.first_clock_in IS NULL AND s.last_clock_out IS NOT NULL
                    THEN 'MissingIn'

                WHEN s.required_minutes > 0
                 AND s.worked_minutes = 0
                 AND s.first_clock_in IS NULL
                 AND s.last_clock_out IS NULL
                 AND s.latest_punch_time IS NOT NULL
                 AND s.latest_punch_state = 1
                    THEN 'MissingIn'

                WHEN s.required_minutes > 0
                 AND s.worked_minutes = 0
                 AND s.first_clock_in IS NULL
                 AND s.last_clock_out IS NULL
                 AND s.latest_punch_time IS NOT NULL
                    THEN 'MissingOut'

                WHEN s.required_minutes > 0
                 AND ISNULL(s.schedule_segment_count, 1) > 1
                 AND ISNULL(s.unmatched_schedule_segment_count, 0) > 0
                 AND s.worked_minutes > 0
                    THEN 'IncompleteSplitDuty'

                WHEN s.required_minutes > 0
                 AND ISNULL(s.has_raw_punch_before_first_in, 0) = 1
                 AND s.effective_scheduled_in_datetime IS NOT NULL
                 AND s.first_clock_in > DATEADD(MINUTE, @LateGraceMinutes, s.effective_scheduled_in_datetime)
                    THEN 'UnpairedEarlyPunch'

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
                 AND ISNULL(s.schedule_segment_count, 1) > 1
                 AND ISNULL(s.unmatched_schedule_segment_count, 0) > 0
                 AND s.worked_minutes > 0
                    THEN 1

                WHEN s.required_minutes > 0
                 AND ISNULL(s.has_raw_punch_before_first_in, 0) = 1
                 AND s.effective_scheduled_in_datetime IS NOT NULL
                 AND s.first_clock_in > DATEADD(MINUTE, @LateGraceMinutes, s.effective_scheduled_in_datetime)
                    THEN 1

                WHEN s.required_minutes > 0
                 AND s.worked_minutes + ISNULL(s.comp_leave_minutes, 0) >= s.required_minutes
                    THEN 0

                WHEN s.worked_minutes > (@MaxWorkHours * 60) THEN 1
                WHEN ISNULL(s.open_pair_count, 0) > 0 THEN 1
                WHEN s.first_clock_in IS NOT NULL AND s.last_clock_out IS NULL THEN 1
                WHEN s.first_clock_in IS NULL AND s.last_clock_out IS NOT NULL THEN 1
                WHEN s.required_minutes > 0
                 AND s.worked_minutes = 0
                 AND s.latest_punch_time IS NOT NULL THEN 1

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
        f.first_clock_in =
            COALESCE(
                s.first_clock_in,
                CASE
                    WHEN s.worked_minutes = 0
                     AND s.latest_punch_time IS NOT NULL
                     AND s.latest_punch_state <> 1
                    THEN s.latest_punch_time
                END
            ),
        f.last_clock_out =
            COALESCE(
                s.last_clock_out,
                CASE
                    WHEN s.worked_minutes = 0
                     AND s.latest_punch_time IS NOT NULL
                     AND s.latest_punch_state = 1
                    THEN s.latest_punch_time
                END
            ),

        f.recomputed_worked_minutes = s.worked_minutes,
        f.worked_hours = CAST(s.worked_minutes / 60.0 AS decimal(10,2)),

        f.actual_excess_minutes = s.actual_excess_minutes,
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
    FROM dbo.custom_att_fact_DailyAttendance f
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
    FROM dbo.custom_att_fact_DailyAttendance
    WHERE att_date BETWEEN @DateFrom AND @DateTo
      AND (@EmpID IS NULL OR emp_id = @EmpID)
      AND NOT EXISTS
      (
          SELECT 1
          FROM dbo.personnel_resign r
          WHERE r.employee_id = custom_att_fact_DailyAttendance.emp_id
            AND custom_att_fact_DailyAttendance.att_date > r.resign_date
      );
END;
