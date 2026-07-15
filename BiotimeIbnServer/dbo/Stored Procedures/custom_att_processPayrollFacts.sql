


CREATE PROCEDURE [dbo].[custom_att_processPayrollFacts]
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
    -- 0A. Materialize date-range scope once
    --------------------------------------------------
    IF OBJECT_ID('tempdb..#TimeCard') IS NOT NULL
        DROP TABLE #TimeCard;

    ;WITH ScheduleDates AS
    (
        SELECT
            es.emp_id,
            es.att_date
        FROM dbo.custom_att_fnd_EffectiveScheduleResolved es
        INNER JOIN dbo.att_attemployee ae
            ON ae.emp_id = es.emp_id
           AND ae.enable_attendance = 1
        WHERE es.att_date BETWEEN @DateFrom AND @DateTo
          AND (@EmpID IS NULL OR es.emp_id = @EmpID)
          AND NOT EXISTS
          (
              SELECT 1
              FROM dbo.personnel_resign r
              WHERE r.employee_id = es.emp_id
                AND es.att_date > r.resign_date
          )
        GROUP BY
            es.emp_id,
            es.att_date
    ),
    PunchDates AS
    (
        SELECT
            t.emp_id,
            CASE
                WHEN CAST(t.punch_time AS time) < CAST('03:00:00' AS time)
                THEN CAST(DATEADD(DAY, -1, t.punch_time) AS date)
                ELSE CAST(t.punch_time AS date)
            END AS att_date
        FROM dbo.iclock_transaction t
        INNER JOIN dbo.att_attemployee ae
            ON ae.emp_id = t.emp_id
           AND ae.enable_attendance = 1
        WHERE t.punch_time >= DATEADD(HOUR, 3, CAST(@DateFrom AS datetime2(0)))
          AND t.punch_time < DATEADD(HOUR, 3, DATEADD(DAY, 1, CAST(@DateTo AS datetime2(0))))
          AND (@EmpID IS NULL OR t.emp_id = @EmpID)
          AND ISNULL(t.is_attendance, 1) = 1
          AND NOT EXISTS
          (
              SELECT 1
              FROM dbo.personnel_resign r
              WHERE r.employee_id = t.emp_id
                AND
                (
                    CASE
                        WHEN CAST(t.punch_time AS time) < CAST('03:00:00' AS time)
                        THEN CAST(DATEADD(DAY, -1, t.punch_time) AS date)
                        ELSE CAST(t.punch_time AS date)
                    END
                ) > r.resign_date
          )
        GROUP BY
            t.emp_id,
            CASE
                WHEN CAST(t.punch_time AS time) < CAST('03:00:00' AS time)
                THEN CAST(DATEADD(DAY, -1, t.punch_time) AS date)
                ELSE CAST(t.punch_time AS date)
            END
    ),
    ApprovedLeaveRanges AS
    (
        SELECT
            wi.employee_id AS emp_id,
            CASE
                WHEN CAST(l.start_time AS date) < @DateFrom THEN @DateFrom
                ELSE CAST(l.start_time AS date)
            END AS start_date,
            CASE
                WHEN CASE
                         WHEN CAST(l.end_time AS time) = CAST('00:00:00' AS time)
                         THEN DATEADD(DAY, -1, CAST(l.end_time AS date))
                         ELSE CAST(l.end_time AS date)
                     END > @DateTo THEN @DateTo
                ELSE CASE
                         WHEN CAST(l.end_time AS time) = CAST('00:00:00' AS time)
                         THEN DATEADD(DAY, -1, CAST(l.end_time AS date))
                         ELSE CAST(l.end_time AS date)
                     END
            END AS end_date
        FROM dbo.workflow_workflowinstance wi
        INNER JOIN dbo.att_leave l
            ON l.workflowinstance_ptr_id = wi.id
        WHERE ISNULL(wi.approval_status, 0) = 2
          AND l.start_time < DATEADD(DAY, 1, CAST(@DateTo AS datetime2(0)))
          AND l.end_time > CAST(@DateFrom AS datetime2(0))
          AND (@EmpID IS NULL OR wi.employee_id = @EmpID)
    ),
    ApprovedLeaveDates AS
    (
        SELECT
            alr.emp_id,
            alr.start_date AS att_date,
            alr.end_date
        FROM ApprovedLeaveRanges alr

        UNION ALL

        SELECT
            ald.emp_id,
            CAST(DATEADD(DAY, 1, ald.att_date) AS date),
            ald.end_date
        FROM ApprovedLeaveDates ald
        WHERE ald.att_date < ald.end_date
    ),
    DateScope AS
    (
        SELECT
            sd.emp_id,
            sd.att_date
        FROM ScheduleDates sd

        UNION

        SELECT
            pd.emp_id,
            pd.att_date
        FROM PunchDates pd

        UNION

        SELECT
            ald.emp_id,
            ald.att_date
        FROM ApprovedLeaveDates ald
        WHERE NOT EXISTS
          (
              SELECT 1
              FROM dbo.personnel_resign r
              WHERE r.employee_id = ald.emp_id
                AND ald.att_date > r.resign_date
          )
    )
    SELECT
        ms.emp_id,
        ms.att_date,
        CAST(NULL AS smallint) AS payload_date_type,
        CAST(NULL AS smallint) AS present_flag,
        CAST(NULL AS smallint) AS full_attendance_flag,
        CAST(NULL AS datetime2(7)) AS scheduled_in,
        CAST(NULL AS datetime2(7)) AS scheduled_out,
        CAST(0 AS decimal(18,2)) AS payload_ot_minutes,
        CAST(0 AS decimal(18,2)) AS payload_absence_minutes,
        CAST(0 AS decimal(18,2)) AS payload_required_work_minutes
    INTO #TimeCard
    FROM DateScope ms
    GROUP BY
        ms.emp_id,
        ms.att_date
    OPTION (MAXRECURSION 32767, RECOMPILE);

    CREATE INDEX IX_TimeCard_EmpDate
    ON #TimeCard(emp_id, att_date);

    --------------------------------------------------
    -- 0B. Materialize effective schedule once
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
    INNER JOIN #TimeCard tc
        ON tc.emp_id = es.emp_id
       AND tc.att_date = es.att_date
    OPTION (RECOMPILE);

    CREATE INDEX IX_EffectiveSchedule_EmpDate
    ON #EffectiveSchedule(emp_id, att_date);

    --------------------------------------------------
    -- 0C. Corrected punches for the date-range scope
    --------------------------------------------------
    IF OBJECT_ID('tempdb..#RawPunches') IS NOT NULL
        DROP TABLE #RawPunches;

    SELECT
        t.emp_id,
        tc.att_date,
        t.id,
        t.punch_time,
        CASE
            WHEN t.punch_state IN ('0', '4') THEN 0
            WHEN t.punch_state IN ('1', '5') THEN 1
            ELSE TRY_CONVERT(int, t.punch_state)
        END AS norm_punch_state
    INTO #RawPunches
    FROM #TimeCard tc
    INNER JOIN dbo.iclock_transaction t
        ON t.emp_id = tc.emp_id
       AND t.punch_time >= DATEADD(HOUR, 3, CAST(tc.att_date AS datetime2(0)))
       AND t.punch_time < DATEADD(HOUR, 3, DATEADD(DAY, 1, CAST(tc.att_date AS datetime2(0))));

    CREATE INDEX IX_RawPunches_EmpDateStateTime
    ON #RawPunches(emp_id, att_date, norm_punch_state, punch_time, id);

    IF OBJECT_ID('tempdb..#CorrectedPunches') IS NOT NULL
        DROP TABLE #CorrectedPunches;

    ;WITH ordered AS
    (
        SELECT
            rp.*,
            LAG(rp.punch_time) OVER
            (
                PARTITION BY rp.emp_id, rp.att_date, rp.norm_punch_state
                ORDER BY rp.punch_time, rp.id
            ) AS prev_same_state_punch_time
        FROM #RawPunches rp
    ),
    marked AS
    (
        SELECT
            o.*,
            CASE
                WHEN o.prev_same_state_punch_time IS NULL THEN 1
                WHEN DATEDIFF(MINUTE, o.prev_same_state_punch_time, o.punch_time) > 5 THEN 1
                ELSE 0
            END AS is_new_burst
        FROM ordered o
    ),
    bursted AS
    (
        SELECT
            m.*,
            SUM(m.is_new_burst) OVER
            (
                PARTITION BY m.emp_id, m.att_date, m.norm_punch_state
                ORDER BY m.punch_time, m.id
                ROWS UNBOUNDED PRECEDING
            ) AS burst_no
        FROM marked m
    ),
    collapsed AS
    (
        SELECT
            emp_id,
            att_date,
            norm_punch_state,
            burst_no,
            MIN(punch_time) AS punch_time,
            MIN(id) AS id,
            COUNT(*) AS burst_punch_count
        FROM bursted
        WHERE norm_punch_state IS NOT NULL
        GROUP BY
            emp_id,
            att_date,
            norm_punch_state,
            burst_no
    ),
    day_ordered AS
    (
        SELECT
            c.*,
            ROW_NUMBER() OVER
            (
                PARTITION BY c.emp_id, c.att_date
                ORDER BY c.punch_time, c.id
            ) AS punch_order,
            COUNT(*) OVER
            (
                PARTITION BY c.emp_id, c.att_date
            ) AS daily_punch_count
        FROM collapsed c
    ),
    ti_break AS
    (
        SELECT
            tib.timeinterval_id,
            SUM(ISNULL(bt.duration, 0)) AS break_minutes
        FROM dbo.att_timeinterval_break_time tib
        INNER JOIN dbo.att_breaktime bt
            ON bt.id = tib.breaktime_id
        GROUP BY
            tib.timeinterval_id
    ),
    schedule_check AS
    (
        SELECT
            es.emp_id,
            es.att_date,
            CASE
                WHEN ISNULL(tb.break_minutes, 0) > 0
                  OR ISNULL(ti.duration, 0) > ISNULL(ti.work_time_duration, 0)
                THEN 1
                ELSE 0
            END AS is_split_shift
        FROM #EffectiveSchedule es
        LEFT JOIN dbo.att_timeinterval ti
            ON ti.id = es.effective_time_interval_id
        LEFT JOIN ti_break tb
            ON tb.timeinterval_id = es.effective_time_interval_id
    ),
    corrected_base AS
    (
        SELECT
            d.emp_id,
            d.att_date,
            d.id,
            d.punch_time,
            CASE
                WHEN ISNULL(sc.is_split_shift, 0) = 1
                 AND d.daily_punch_count = 4
                THEN
                    CASE d.punch_order
                        WHEN 1 THEN 0
                        WHEN 2 THEN 1
                        WHEN 3 THEN 0
                        WHEN 4 THEN 1
                        ELSE d.norm_punch_state
                    END
                ELSE d.norm_punch_state
            END AS norm_punch_state,
            CASE
                WHEN ISNULL(sc.is_split_shift, 0) = 1
                 AND d.daily_punch_count = 4
                 AND d.norm_punch_state <>
                    CASE d.punch_order
                        WHEN 1 THEN 0
                        WHEN 2 THEN 1
                        WHEN 3 THEN 0
                        WHEN 4 THEN 1
                        ELSE d.norm_punch_state
                    END
                THEN 1
                ELSE 0
            END AS auto_corrected_state
        FROM day_ordered d
        LEFT JOIN schedule_check sc
            ON sc.emp_id = d.emp_id
           AND sc.att_date = d.att_date
    ),
    x AS
    (
        SELECT
            cb.*,
            COUNT(*) OVER
            (
                PARTITION BY cb.emp_id, cb.att_date
            ) AS daily_punch_count,
            FIRST_VALUE(cb.norm_punch_state) OVER
            (
                PARTITION BY cb.emp_id, cb.att_date
                ORDER BY cb.punch_time, cb.id
            ) AS first_punch_state,
            LAST_VALUE(cb.norm_punch_state) OVER
            (
                PARTITION BY cb.emp_id, cb.att_date
                ORDER BY cb.punch_time, cb.id
                ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING
            ) AS last_punch_state,
            ROW_NUMBER() OVER
            (
                PARTITION BY cb.emp_id, cb.att_date
                ORDER BY cb.punch_time, cb.id
            ) AS rn,
            DATEDIFF(
                MINUTE,
                MIN(cb.punch_time) OVER
                (
                    PARTITION BY cb.emp_id, cb.att_date
                ),
                MAX(cb.punch_time) OVER
                (
                    PARTITION BY cb.emp_id, cb.att_date
                )
            ) AS daily_span_minutes
        FROM corrected_base cb
    )
    SELECT
        x.emp_id,
        x.att_date,
        x.id,
        x.punch_time,
        CASE
            WHEN x.daily_punch_count = 2
             AND x.first_punch_state = 1
             AND x.last_punch_state = 0
             AND x.daily_span_minutes BETWEEN 240 AND 960
            THEN
                CASE x.rn
                    WHEN 1 THEN 0
                    WHEN 2 THEN 1
                    ELSE x.norm_punch_state
                END

            WHEN x.daily_punch_count = 2
             AND x.first_punch_state = 1
             AND x.last_punch_state = 1
             AND x.rn = 1
             AND x.daily_span_minutes BETWEEN 240 AND 960
            THEN 0
            ELSE x.norm_punch_state
        END AS corrected_punch_state,
        CASE
            WHEN x.daily_punch_count = 2
             AND x.first_punch_state = 1
             AND x.last_punch_state = 0
             AND x.daily_span_minutes BETWEEN 240 AND 960
            THEN 1

            WHEN x.auto_corrected_state = 1
              OR (
                    x.daily_punch_count = 2
                AND x.first_punch_state = 1
                AND x.last_punch_state = 1
                AND x.rn = 1
                AND x.daily_span_minutes BETWEEN 240 AND 960
              )
            THEN 1
            ELSE 0
        END AS corrected_punch_flag
    INTO #CorrectedPunches
    FROM x;

    CREATE INDEX IX_CorrectedPunches_EmpDateStateTime
    ON #CorrectedPunches(emp_id, att_date, corrected_punch_state, punch_time);

    --------------------------------------------------
    -- 0D. Effective punch pairs and daily worked minutes
    --------------------------------------------------
    IF OBJECT_ID('tempdb..#EffectivePairs') IS NOT NULL
        DROP TABLE #EffectivePairs;

    ;WITH ins AS
    (
        SELECT
            cp.emp_id,
            cp.att_date,
            cp.id AS in_punch_id,
            cp.punch_time AS in_time,
            ROW_NUMBER() OVER
            (
                PARTITION BY cp.emp_id, cp.att_date
                ORDER BY cp.punch_time, cp.id
            ) AS in_no
        FROM #CorrectedPunches cp
        WHERE cp.corrected_punch_state = 0
    ),
    outs AS
    (
        SELECT
            cp.emp_id,
            cp.att_date,
            cp.id AS out_punch_id,
            cp.punch_time AS out_time,
            ROW_NUMBER() OVER
            (
                PARTITION BY cp.emp_id, cp.att_date
                ORDER BY cp.punch_time, cp.id
            ) AS out_no,
            LAG(cp.punch_time) OVER
            (
                PARTITION BY cp.emp_id, cp.att_date
                ORDER BY cp.punch_time, cp.id
            ) AS previous_out_time
        FROM #CorrectedPunches cp
        WHERE cp.corrected_punch_state = 1
    ),
    punch_counts AS
    (
        SELECT
            cp.emp_id,
            cp.att_date,
            COUNT(*) AS punch_count,
            MIN(cp.punch_time) AS first_punch_time,
            MAX(cp.punch_time) AS last_punch_time,
            MIN(cp.id) AS first_punch_id,
            MAX(cp.id) AS last_punch_id,
            SUM(CASE WHEN cp.corrected_punch_state = 0 THEN 1 ELSE 0 END) AS in_count,
            SUM(CASE WHEN cp.corrected_punch_state = 1 THEN 1 ELSE 0 END) AS out_count
        FROM #CorrectedPunches cp
        GROUP BY
            cp.emp_id,
            cp.att_date
    ),
    valid_ins AS
    (
        SELECT i.*
        FROM ins i
        INNER JOIN punch_counts pc
            ON pc.emp_id = i.emp_id
           AND pc.att_date = i.att_date
        WHERE NOT
        (
            pc.out_count = 0
            AND pc.punch_count >= 2
            AND pc.last_punch_time > pc.first_punch_time
        )
    ),
    single_in_multi_out_pairs AS
    (
        SELECT
            i.emp_id,
            i.att_date,
            i.in_time,
            o.out_time,
            i.in_no,
            o.out_no,
            i.in_punch_id,
            0 AS is_open_pair
        FROM valid_ins i
        INNER JOIN punch_counts pc
            ON pc.emp_id = i.emp_id
           AND pc.att_date = i.att_date
        OUTER APPLY
        (
            SELECT TOP (1)
                o.out_no,
                o.out_time,
                o.out_punch_id
            FROM outs o
            WHERE o.emp_id = i.emp_id
              AND o.att_date = i.att_date
              AND o.out_time > i.in_time
            ORDER BY
                o.out_time DESC,
                o.out_punch_id DESC
        ) o
        WHERE pc.in_count = 1
          AND pc.out_count > 1
          AND o.out_time IS NOT NULL
    ),
    out_closed_pairs AS
    (
        SELECT
            o.emp_id,
            o.att_date,
            i.in_time,
            o.out_time,
            i.in_no,
            o.out_no,
            i.in_punch_id,
            0 AS is_open_pair
        FROM outs o
        INNER JOIN punch_counts pc
            ON pc.emp_id = o.emp_id
           AND pc.att_date = o.att_date
        OUTER APPLY
        (
            SELECT TOP (1)
                i.in_no,
                i.in_punch_id,
                i.in_time
            FROM valid_ins i
            WHERE i.emp_id = o.emp_id
              AND i.att_date = o.att_date
              AND i.in_time < o.out_time
              AND i.in_time > ISNULL(o.previous_out_time, CONVERT(datetime2(7), '19000101'))
            ORDER BY
                i.in_time DESC,
                i.in_punch_id DESC
        ) i
        WHERE NOT (pc.in_count = 1 AND pc.out_count > 1)
          AND i.in_time IS NOT NULL
    ),
    matched_pairs AS
    (
        SELECT *
        FROM single_in_multi_out_pairs

        UNION ALL

        SELECT *
        FROM out_closed_pairs
    ),
    open_pairs AS
    (
        SELECT
            i.emp_id,
            i.att_date,
            i.in_time,
            CAST(NULL AS datetime2(7)) AS out_time,
            i.in_no,
            CAST(NULL AS bigint) AS out_no,
            i.in_punch_id,
            1 AS is_open_pair
        FROM valid_ins i
        WHERE NOT EXISTS
        (
            SELECT 1
            FROM matched_pairs mp
            WHERE mp.emp_id = i.emp_id
              AND mp.att_date = i.att_date
              AND mp.in_punch_id = i.in_punch_id
        )
    ),
    fallback_pairs AS
    (
        SELECT
            pc.emp_id,
            pc.att_date,
            pc.first_punch_time AS in_time,
            pc.last_punch_time AS out_time,
            1 AS in_no,
            1 AS out_no,
            pc.first_punch_id AS in_punch_id,
            0 AS is_open_pair
        FROM punch_counts pc
        WHERE pc.out_count = 0
          AND pc.punch_count >= 2
          AND pc.last_punch_time > pc.first_punch_time
    )
    SELECT
        p.emp_id,
        p.att_date,
        p.in_time,
        p.out_time,
        p.in_no,
        p.out_no,
        p.in_punch_id,
        p.is_open_pair,
        CASE
            WHEN p.is_open_pair = 0
             AND p.out_time IS NOT NULL
             AND p.out_time >= p.in_time
            THEN DATEDIFF(MINUTE, p.in_time, p.out_time)
            ELSE NULL
        END AS paired_minutes
    INTO #EffectivePairs
    FROM
    (
        SELECT *
        FROM matched_pairs

        UNION ALL

        SELECT *
        FROM open_pairs

        UNION ALL

        SELECT *
        FROM fallback_pairs
    ) p;

    CREATE INDEX IX_EffectivePairs_EmpDate
    ON #EffectivePairs(emp_id, att_date, in_time);

    IF OBJECT_ID('tempdb..#DailyWorkedMinutes') IS NOT NULL
        DROP TABLE #DailyWorkedMinutes;

    SELECT
        ep.emp_id,
        ep.att_date,
        COUNT(*) AS worked_interval_count,
        MIN(ep.in_time) AS first_clock_in,
        MAX(ep.out_time) AS last_clock_out,
        SUM(ep.paired_minutes) AS total_worked_minutes
    INTO #DailyWorkedMinutes
    FROM #EffectivePairs ep
    WHERE ep.is_open_pair = 0
      AND ep.in_time IS NOT NULL
      AND ep.out_time IS NOT NULL
      AND ep.out_time >= ep.in_time
    GROUP BY
        ep.emp_id,
        ep.att_date;

    CREATE INDEX IX_DailyWorkedMinutes_EmpDate
    ON #DailyWorkedMinutes(emp_id, att_date);

    --------------------------------------------------
    -- 0E. Date-range audit punch columns
    --------------------------------------------------
    IF OBJECT_ID('tempdb..#AuditPunchColumns') IS NOT NULL
        DROP TABLE #AuditPunchColumns;

    ;WITH corrected_flags AS
    (
        SELECT
            cp.emp_id,
            cp.att_date,
            CAST(
                CASE
                    WHEN SUM(CASE WHEN ISNULL(cp.corrected_punch_flag, 0) = 1 THEN 1 ELSE 0 END) > 0
                    THEN 1
                    ELSE 0
                END AS bit
            ) AS corrected
        FROM #CorrectedPunches cp
        GROUP BY
            cp.emp_id,
            cp.att_date
    ),
    numbered_pairs AS
    (
        SELECT
            ep.*,
            ROW_NUMBER() OVER
            (
                PARTITION BY ep.emp_id, ep.att_date
                ORDER BY
                    ep.in_time,
                    ep.out_time,
                    ep.in_no,
                    ep.out_no
            ) AS pair_no
        FROM #EffectivePairs ep
    )
    SELECT
        tc.emp_id,
        tc.att_date,
        ISNULL(cf.corrected, CAST(0 AS bit)) AS corrected,
        MAX(CASE WHEN np.pair_no = 1 THEN np.in_time END) AS effective_punch_in1,
        MAX(CASE WHEN np.pair_no = 1 THEN np.out_time END) AS effective_punch_out1,
        MAX(CASE WHEN np.pair_no = 2 THEN np.in_time END) AS effective_punch_in2,
        MAX(CASE WHEN np.pair_no = 2 THEN np.out_time END) AS effective_punch_out2
    INTO #AuditPunchColumns
    FROM #TimeCard tc
    LEFT JOIN corrected_flags cf
        ON cf.emp_id = tc.emp_id
       AND cf.att_date = tc.att_date
    LEFT JOIN numbered_pairs np
        ON np.emp_id = tc.emp_id
       AND np.att_date = tc.att_date
       AND np.pair_no <= 2
    GROUP BY
        tc.emp_id,
        tc.att_date,
        cf.corrected;

    CREATE INDEX IX_AuditPunchColumns_EmpDate
    ON #AuditPunchColumns(emp_id, att_date);

    --------------------------------------------------
    -- 0F. Materialize DailyBase once
    --------------------------------------------------
    IF OBJECT_ID('tempdb..#DailyBase') IS NOT NULL
        DROP TABLE #DailyBase;

    ;WITH calc AS
    (
        SELECT
            tc.emp_id,
            pe.emp_code,
            tc.att_date,
            CASE
                WHEN h.id IS NOT NULL THEN 1
                WHEN ISNULL(es.resolved_is_off_day, 0) = 1 THEN 2
                ELSE 0
            END AS date_type,
            dwm.first_clock_in,
            dwm.last_clock_out,
            ISNULL(dwm.total_worked_minutes, 0) AS recomputed_worked_minutes,
            ISNULL(ti.use_mode, 0) AS use_mode,
            ISNULL(es.effective_schedule_source, 'Unscheduled') AS schedule_source,
            ISNULL(es.effective_required_work_minutes, 0) AS effective_required_work_minutes,
            CASE
                WHEN ISNULL(ti.enable_overtime, 0) = 1
                 AND ISNULL(ti.max_ot_limit, 0) > 0
                THEN ti.max_ot_limit
                ELSE 0
            END AS configured_ot_cap_minutes
        FROM #TimeCard tc
        LEFT JOIN #DailyWorkedMinutes dwm
            ON dwm.emp_id = tc.emp_id
           AND dwm.att_date = tc.att_date
        LEFT JOIN #EffectiveSchedule es
            ON es.emp_id = tc.emp_id
           AND es.att_date = tc.att_date
        LEFT JOIN dbo.att_timeinterval ti
            ON ti.id = es.effective_time_interval_id
        LEFT JOIN dbo.att_attemployee ae
            ON ae.emp_id = tc.emp_id
        LEFT JOIN dbo.personnel_employee pe
            ON pe.id = tc.emp_id
        OUTER APPLY
        (
            SELECT TOP (1)
                h.id
            FROM dbo.att_holiday h
            WHERE tc.att_date >= CAST(h.start_date AS date)
              AND tc.att_date <= CAST(h.end_date AS date)
              AND (
                    (h.att_group_id IS NULL AND h.department_id IS NULL)
                    OR h.att_group_id = ae.group_id
                    OR h.department_id = pe.department_id
                  )
            ORDER BY h.id
        ) h
    ),
    logic AS
    (
        SELECT
            c.*,
            ISNULL(c.configured_ot_cap_minutes, 0) AS scheduled_ot_cap_minutes
        FROM calc c
    )
    SELECT
        l.emp_id,
        l.emp_code,
        l.att_date,
        l.date_type,
        l.first_clock_in,
        l.last_clock_out,
        CAST(l.recomputed_worked_minutes AS decimal(10,2)) AS recomputed_worked_minutes,
        CAST(
            CASE
                WHEN ISNULL(l.scheduled_ot_cap_minutes, 0) <= 0 THEN 0
                WHEN ISNULL(l.effective_required_work_minutes, 0) = 0 THEN
                    CASE
                        WHEN ISNULL(l.recomputed_worked_minutes, 0) > ISNULL(l.scheduled_ot_cap_minutes, 0)
                            THEN ISNULL(l.scheduled_ot_cap_minutes, 0)
                        ELSE ISNULL(l.recomputed_worked_minutes, 0)
                    END
                WHEN ISNULL(l.recomputed_worked_minutes, 0) >
                     CASE
                         WHEN l.schedule_source = 'Temporary' THEN 0
                         WHEN ISNULL(l.effective_required_work_minutes, 0) - ISNULL(l.scheduled_ot_cap_minutes, 0) > 0
                             THEN ISNULL(l.effective_required_work_minutes, 0) - ISNULL(l.scheduled_ot_cap_minutes, 0)
                         ELSE 0
                     END
                THEN
                    CASE
                        WHEN
                            ISNULL(l.recomputed_worked_minutes, 0) -
                            CASE
                                WHEN l.schedule_source = 'Temporary' THEN 0
                                WHEN ISNULL(l.effective_required_work_minutes, 0) - ISNULL(l.scheduled_ot_cap_minutes, 0) > 0
                                    THEN ISNULL(l.effective_required_work_minutes, 0) - ISNULL(l.scheduled_ot_cap_minutes, 0)
                                ELSE 0
                            END
                            > ISNULL(l.scheduled_ot_cap_minutes, 0)
                        THEN ISNULL(l.scheduled_ot_cap_minutes, 0)
                        ELSE
                            ISNULL(l.recomputed_worked_minutes, 0) -
                            CASE
                                WHEN l.schedule_source = 'Temporary' THEN 0
                                WHEN ISNULL(l.effective_required_work_minutes, 0) - ISNULL(l.scheduled_ot_cap_minutes, 0) > 0
                                    THEN ISNULL(l.effective_required_work_minutes, 0) - ISNULL(l.scheduled_ot_cap_minutes, 0)
                                ELSE 0
                            END
                    END
                ELSE 0
            END AS decimal(10,2)
        ) AS ot_minutes,
        l.use_mode,
        CAST(ISNULL(l.scheduled_ot_cap_minutes, 0) AS decimal(10,2)) AS scheduled_ot_cap_minutes,
        CAST(
            CASE
                WHEN l.schedule_source = 'Temporary' THEN 0
                WHEN l.effective_required_work_minutes > 0 THEN
                    CASE
                        WHEN l.effective_required_work_minutes - l.scheduled_ot_cap_minutes > 0
                            THEN l.effective_required_work_minutes - l.scheduled_ot_cap_minutes
                        ELSE 0
                    END
                ELSE 0
            END AS decimal(10,2)
        ) AS required_work_minutes
    INTO #DailyBase
    FROM logic l;

    CREATE INDEX IX_DailyBase_EmpDate
    ON #DailyBase(emp_id, att_date);

    --------------------------------------------------
    -- 0. Insert missing fact rows
    --------------------------------------------------
    INSERT INTO dbo.custom_att_fact_DailyAttendance (
        emp_id,
        emp_code,
        att_date,
        year_no,
        month_no,
        sick_leave_days,
        annual_leave_days,
        compensatory_leave_days,
        other_paid_leave_days,
        unpaid_leave_days
    )
    SELECT
        b.emp_id,
        b.emp_code,
        b.att_date,
        YEAR(b.att_date),
        MONTH(b.att_date),
        CAST(0 AS decimal(10,2)),
        CAST(0 AS decimal(10,2)),
        CAST(0 AS decimal(10,2)),
        CAST(0 AS decimal(10,2)),
        CAST(0 AS decimal(10,2))
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

    ;WITH RankedRawPunches AS
    (
        SELECT
            rp.emp_id,
            rp.att_date,
            rp.punch_time,
            rp.norm_punch_state,
            ROW_NUMBER() OVER
            (
                PARTITION BY rp.emp_id, rp.att_date
                ORDER BY rp.punch_time DESC, rp.id DESC
            ) AS latest_punch_no,
            COUNT_BIG(*) OVER
            (
                PARTITION BY rp.emp_id, rp.att_date
            ) AS raw_punch_count
        FROM #RawPunches rp
    )
    SELECT
        rp.emp_id,
        rp.att_date,
        MAX(CASE WHEN rp.latest_punch_no = 1 THEN rp.punch_time END) AS latest_punch_time,
        MAX(CASE WHEN rp.latest_punch_no = 1 THEN rp.norm_punch_state END) AS latest_punch_state,
        MIN(rp.punch_time) AS first_raw_punch_time,
        MAX(rp.raw_punch_count) AS raw_punch_count
    INTO #RawPunchAgg
    FROM RankedRawPunches rp
    GROUP BY
        rp.emp_id,
        rp.att_date;

    CREATE INDEX IX_RawPunchAgg_EmpDate
    ON #RawPunchAgg(emp_id, att_date);

    --------------------------------------------------
    -- B.1 Approved Leaves
    --------------------------------------------------
    IF OBJECT_ID('tempdb..#ApprovedLeaves') IS NOT NULL
        DROP TABLE #ApprovedLeaves;

    ;WITH ApprovedLeaveDaily AS
    (
        SELECT
            b.emp_id,
            b.att_date,
            pc.code AS pay_code,
            pc.code_type,
            pc.is_paid,
            CAST(
            CASE
                WHEN pc.code IN ('CP', 'CPL') THEN
                    CASE
                        WHEN ISNULL(b.required_work_minutes, 0) <= 0 THEN 0
                        WHEN
                            (
                                CAST(ISNULL(l.leave_day, 0) AS decimal(10,2))
                                / NULLIF(
                                    DATEDIFF(
                                        DAY,
                                        CAST(l.start_time AS date),
                                        CASE
                                            WHEN CAST(l.end_time AS time) = CAST('00:00:00' AS time)
                                            THEN DATEADD(DAY, -1, CAST(l.end_time AS date))
                                            ELSE CAST(l.end_time AS date)
                                        END
                                    ) + 1,
                                    0
                                  )
                            ) / (CAST(b.required_work_minutes AS decimal(10,2)) / 60.0) > 1
                        THEN 1
                        ELSE
                            (
                                CAST(ISNULL(l.leave_day, 0) AS decimal(10,2))
                                / NULLIF(
                                    DATEDIFF(
                                        DAY,
                                        CAST(l.start_time AS date),
                                        CASE
                                            WHEN CAST(l.end_time AS time) = CAST('00:00:00' AS time)
                                            THEN DATEADD(DAY, -1, CAST(l.end_time AS date))
                                            ELSE CAST(l.end_time AS date)
                                        END
                                    ) + 1,
                                    0
                                  )
                            ) / (CAST(b.required_work_minutes AS decimal(10,2)) / 60.0)
                    END
                ELSE
                    CAST(ISNULL(l.leave_day, 0) AS decimal(10,2))
                    / NULLIF(
                        DATEDIFF(
                            DAY,
                            CAST(l.start_time AS date),
                            CASE
                                WHEN CAST(l.end_time AS time) = CAST('00:00:00' AS time)
                                THEN DATEADD(DAY, -1, CAST(l.end_time AS date))
                                ELSE CAST(l.end_time AS date)
                            END
                        ) + 1,
                        0
                      )
            END
            AS decimal(10,2)) AS leave_days
        FROM #DailyBase b
        INNER JOIN dbo.workflow_workflowinstance wi
            ON wi.employee_id = b.emp_id
        INNER JOIN dbo.att_leave l
            ON l.workflowinstance_ptr_id = wi.id
        LEFT JOIN dbo.att_paycode pc
            ON pc.id = l.pay_code_id
        WHERE ISNULL(wi.approval_status, 0) = 2
          AND l.start_time < DATEADD(DAY, 1, CAST(b.att_date AS datetime2(0)))
          AND l.end_time > CAST(b.att_date AS datetime2(0))
          AND l.start_time < DATEADD(DAY, 1, CAST(@DateTo AS datetime2(0)))
          AND l.end_time > CAST(@DateFrom AS datetime2(0))
          AND (@EmpID IS NULL OR wi.employee_id = @EmpID)
    )
    SELECT
        ald.emp_id,
        ald.att_date,
        CAST(SUM(ISNULL(ald.leave_days, 0)) AS decimal(10,2)) AS [Leaves],
        CAST(SUM(CASE WHEN ald.code_type = 3 AND ald.is_paid = 1 AND ald.pay_code = 'SL' THEN ISNULL(ald.leave_days, 0) ELSE 0 END) AS decimal(10,2)) AS sick_leave_days,
        CAST(SUM(CASE WHEN ald.code_type = 3 AND ald.is_paid = 1 AND ald.pay_code = 'AL' THEN ISNULL(ald.leave_days, 0) ELSE 0 END) AS decimal(10,2)) AS annual_leave_days,
        CAST(SUM(CASE WHEN ald.code_type = 3 AND ald.pay_code IN ('CP', 'CPL') THEN ISNULL(ald.leave_days, 0) ELSE 0 END) AS decimal(10,2)) AS compensatory_leave_days,
        CAST(SUM(CASE WHEN ald.code_type = 3 AND ald.is_paid = 1 AND ald.pay_code NOT IN ('SL', 'AL', 'CP', 'CPL') THEN ISNULL(ald.leave_days, 0) ELSE 0 END) AS decimal(10,2)) AS other_paid_leave_days,
        CAST(SUM(CASE WHEN ald.code_type = 3 AND ald.is_paid = 0 AND ald.pay_code NOT IN ('CP', 'CPL') THEN ISNULL(ald.leave_days, 0) ELSE 0 END) AS decimal(10,2)) AS unpaid_leave_days
    INTO #ApprovedLeaves
    FROM ApprovedLeaveDaily ald
    GROUP BY
        ald.emp_id,
        ald.att_date;

    CREATE INDEX IX_ApprovedLeaves_EmpDate
    ON #ApprovedLeaves(emp_id, att_date);

    --------------------------------------------------
    -- B.2 Approved Compensatory Leave
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
        b.emp_code,
        b.att_date,

        COALESCE(p.first_clock_in, b.first_clock_in) AS first_clock_in,
        COALESCE(p.last_clock_out, b.last_clock_out) AS last_clock_out,

        CASE
            WHEN ISNULL(b.use_mode, 0) = 1
                THEN ISNULL(b.recomputed_worked_minutes, 0)
            ELSE ISNULL(p.paired_worked_minutes, 0)
        END AS worked_minutes,

        ISNULL(b.ot_minutes, 0) AS base_ot_minutes,
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
        ISNULL(al.[Leaves], 0) AS [Leaves],
        ISNULL(al.sick_leave_days, 0) AS sick_leave_days,
        ISNULL(al.annual_leave_days, 0) AS annual_leave_days,
        ISNULL(al.compensatory_leave_days, 0) AS compensatory_leave_days,
        ISNULL(al.other_paid_leave_days, 0) AS other_paid_leave_days,
        ISNULL(al.unpaid_leave_days, 0) AS unpaid_leave_days,
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
                     AND NOT (
                         es.effective_schedule_source = 'Temporary'
                         AND ISNULL(es.effective_required_work_minutes, 0) > 0
                     )
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
    LEFT JOIN #ApprovedLeaves al
        ON al.emp_id = b.emp_id
       AND al.att_date = b.att_date
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
        s.segment_end_datetime,
        LAG(s.segment_end_datetime) OVER
        (
            PARTITION BY s.emp_id, s.att_date
            ORDER BY s.segment_no
        ) AS previous_segment_end_datetime,
        LEAD(s.segment_start_datetime) OVER
        (
            PARTITION BY s.emp_id, s.att_date
            ORDER BY s.segment_no
        ) AS next_segment_start_datetime
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
                WHEN si.in_time IS NOT NULL
                 AND si.in_time > DATEADD(MINUTE, @LateGraceMinutes, ss.segment_start_datetime)
                THEN DATEDIFF(MINUTE, DATEADD(MINUTE, @LateGraceMinutes, ss.segment_start_datetime), si.in_time)
                ELSE 0
            END
        ) AS final_late_minutes,

        SUM(
            CASE
                WHEN si.in_time IS NOT NULL
                 AND si.in_time > ss.segment_start_datetime
                THEN DATEDIFF(MINUTE, ss.segment_start_datetime, si.in_time)
                ELSE 0
            END
        ) AS actual_late_minutes,

        SUM(
            CASE
                WHEN so.out_time IS NOT NULL
                 AND so.out_time < DATEADD(MINUTE, -@EarlyOutGraceMinutes, ss.segment_end_datetime)
                THEN DATEDIFF(MINUTE, so.out_time, DATEADD(MINUTE, -@EarlyOutGraceMinutes, ss.segment_end_datetime))
                ELSE 0
            END
        ) AS final_early_out_minutes,

        SUM(
            CASE
                WHEN so.out_time IS NOT NULL
                 AND so.out_time < ss.segment_end_datetime
                THEN DATEDIFF(MINUTE, so.out_time, ss.segment_end_datetime)
                ELSE 0
            END
        ) AS actual_early_out_minutes,

        SUM(
            CASE
                WHEN si.in_time IS NOT NULL
                 AND so.out_time IS NOT NULL
                 AND so.out_time > si.in_time
                THEN DATEDIFF(MINUTE, si.in_time, so.out_time)
                ELSE 0
            END
        ) AS segment_actual_worked_minutes,

        SUM(
            CASE
                WHEN si.in_time IS NOT NULL
                 AND so.out_time IS NOT NULL
                 AND so.out_time > si.in_time
                THEN
                    CASE
                        WHEN DATEDIFF(
                                MINUTE,
                                CASE WHEN si.in_time > ss.segment_start_datetime THEN si.in_time ELSE ss.segment_start_datetime END,
                                CASE WHEN so.out_time < ss.segment_end_datetime THEN so.out_time ELSE ss.segment_end_datetime END
                             ) > 0
                        THEN DATEDIFF(
                                MINUTE,
                                CASE WHEN si.in_time > ss.segment_start_datetime THEN si.in_time ELSE ss.segment_start_datetime END,
                                CASE WHEN so.out_time < ss.segment_end_datetime THEN so.out_time ELSE ss.segment_end_datetime END
                             )
                        ELSE 0
                    END
                ELSE 0
            END
        ) AS segment_regular_worked_minutes,

        MIN(si.in_time) AS segment_first_clock_in,
        MAX(so.out_time) AS segment_last_clock_out,
        MAX(CASE WHEN ss.segment_no = 1 THEN si.in_time END) AS segment_punch_in1,
        MAX(CASE WHEN ss.segment_no = 1 THEN so.out_time END) AS segment_punch_out1,
        MAX(CASE WHEN ss.segment_no = 2 THEN si.in_time END) AS segment_punch_in2,
        MAX(CASE WHEN ss.segment_no = 2 THEN so.out_time END) AS segment_punch_out2,

        SUM(CASE WHEN si.in_time IS NULL OR so.out_time IS NULL THEN 1 ELSE 0 END) AS unmatched_segment_count
    INTO #SegmentTiming
    FROM #ScheduleSegments ss
    OUTER APPLY
    (
        SELECT TOP (1)
            cp.punch_time AS in_time
        FROM #CorrectedPunches cp
        WHERE cp.emp_id = ss.emp_id
          AND cp.att_date = ss.att_date
          AND cp.corrected_punch_state = 0
          AND cp.punch_time >= COALESCE(ss.previous_segment_end_datetime, DATEADD(DAY, -1, ss.segment_start_datetime))
          AND cp.punch_time < ss.segment_end_datetime
          AND cp.punch_time < COALESCE(ss.next_segment_start_datetime, DATEADD(DAY, 1, ss.segment_end_datetime))
        ORDER BY
            CASE
                WHEN cp.punch_time <= ss.segment_start_datetime THEN 0
                ELSE 1
            END,
            CASE
                WHEN cp.punch_time <= ss.segment_start_datetime
                THEN ABS(DATEDIFF(SECOND, cp.punch_time, ss.segment_start_datetime))
                ELSE ABS(DATEDIFF(SECOND, ss.segment_start_datetime, cp.punch_time))
            END,
            cp.punch_time,
            cp.id
    ) si
    OUTER APPLY
    (
        SELECT TOP (1)
            cp.punch_time AS out_time
        FROM #CorrectedPunches cp
        WHERE cp.emp_id = ss.emp_id
          AND cp.att_date = ss.att_date
          AND cp.corrected_punch_state = 1
          AND cp.punch_time > COALESCE(si.in_time, ss.segment_start_datetime)
          AND cp.punch_time > ss.segment_start_datetime
          AND cp.punch_time < COALESCE(ss.next_segment_start_datetime, DATEADD(DAY, 1, ss.segment_end_datetime))
        ORDER BY
            CASE
                WHEN cp.punch_time >= ss.segment_end_datetime THEN 0
                ELSE 1
            END,
            CASE
                WHEN cp.punch_time >= ss.segment_end_datetime
                THEN DATEDIFF(SECOND, ss.segment_end_datetime, cp.punch_time)
            END,
            CASE
                WHEN cp.punch_time < ss.segment_end_datetime
                THEN DATEDIFF(SECOND, cp.punch_time, ss.segment_end_datetime)
            END,
            cp.punch_time,
            cp.id
    ) so
    GROUP BY
        ss.emp_id,
        ss.att_date;

    UPDATE s
    SET
        worked_minutes = st.segment_actual_worked_minutes,
        first_clock_in = st.segment_first_clock_in,
        last_clock_out = st.segment_last_clock_out
    FROM #PayrollSrc s
    INNER JOIN #SegmentTiming st
        ON st.emp_id = s.emp_id
       AND st.att_date = s.att_date
    WHERE ISNULL(st.schedule_segment_count, 1) > 1
      AND ISNULL(st.unmatched_segment_count, 0) = 0
      AND ISNULL(st.segment_actual_worked_minutes, 0) > 0;

    UPDATE ap
    SET
        corrected = CAST(1 AS bit),
        effective_punch_in1 = st.segment_punch_in1,
        effective_punch_out1 = st.segment_punch_out1,
        effective_punch_in2 = st.segment_punch_in2,
        effective_punch_out2 = st.segment_punch_out2
    FROM #AuditPunchColumns ap
    INNER JOIN #SegmentTiming st
        ON st.emp_id = ap.emp_id
       AND st.att_date = ap.att_date
    WHERE ISNULL(st.schedule_segment_count, 1) > 1
      AND ISNULL(st.unmatched_segment_count, 0) = 0
      AND ISNULL(st.segment_actual_worked_minutes, 0) > 0;

    CREATE INDEX IX_SegmentTiming_EmpDate
    ON #SegmentTiming(emp_id, att_date);

    --------------------------------------------------
    -- 2. Add calculated fields
    --------------------------------------------------
    ALTER TABLE #PayrollSrc ADD
        regular_worked_minutes decimal(10,2) NULL,
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

    UPDATE s
    SET
        regular_worked_minutes =
            CASE
                WHEN ISNULL(st.schedule_segment_count, 1) > 1
                 AND ISNULL(st.unmatched_segment_count, 0) = 0
                 AND ISNULL(st.segment_regular_worked_minutes, 0) > 0
                THEN st.segment_regular_worked_minutes
                ELSE s.worked_minutes
            END
    FROM #PayrollSrc s
    LEFT JOIN #SegmentTiming st
        ON st.emp_id = s.emp_id
       AND st.att_date = s.att_date;

    --------------------------------------------------
    -- 2A. Shortfall, absence, and OT
    --------------------------------------------------
    UPDATE s
    SET
        shortfall_minutes =
            CASE
                WHEN s.required_minutes > ISNULL(s.regular_worked_minutes, s.worked_minutes) + ISNULL(s.comp_leave_minutes, 0)
                 AND s.required_minutes - ISNULL(s.regular_worked_minutes, s.worked_minutes) - ISNULL(s.comp_leave_minutes, 0) > @WorkCompletionToleranceMinutes
                THEN s.required_minutes - ISNULL(s.regular_worked_minutes, s.worked_minutes) - ISNULL(s.comp_leave_minutes, 0)
                ELSE 0
            END,

        absence_minutes =
            CASE
                WHEN s.required_minutes > 0
                 AND ISNULL(s.regular_worked_minutes, s.worked_minutes) = 0
                 AND ISNULL(s.comp_leave_minutes, 0) = 0
                THEN s.required_minutes

                WHEN s.required_minutes > 0
                 AND ISNULL(s.regular_worked_minutes, s.worked_minutes) + ISNULL(s.comp_leave_minutes, 0) < s.required_minutes
                THEN s.required_minutes - ISNULL(s.regular_worked_minutes, s.worked_minutes) - ISNULL(s.comp_leave_minutes, 0)

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
                 AND ISNULL(s.regular_worked_minutes, s.worked_minutes) + ISNULL(s.comp_leave_minutes, 0) >= s.required_minutes
                    THEN 'PresentWithCompLeave'

                WHEN s.required_minutes > 0 AND ISNULL(s.comp_leave_minutes, 0) > 0
                    THEN 'PartialWithCompLeave'

                WHEN s.required_minutes > 0
                 AND ISNULL(s.regular_worked_minutes, s.worked_minutes) + ISNULL(s.comp_leave_minutes, 0) >= s.required_minutes - @WorkCompletionToleranceMinutes
                    THEN 'Present'

                WHEN s.required_minutes > 0
                 AND s.worked_minutes = 0
                 AND (
                        s.first_clock_in IS NOT NULL
                     OR s.last_clock_out IS NOT NULL
                     OR s.latest_punch_time IS NOT NULL
                 )
                    THEN 'Partial'

                WHEN s.required_minutes > 0 AND ISNULL(s.regular_worked_minutes, s.worked_minutes) = 0
                    THEN 'Absent'

                WHEN s.required_minutes > 0 AND ISNULL(s.regular_worked_minutes, s.worked_minutes) < s.required_minutes
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
                 AND (s.required_minutes - ISNULL(s.regular_worked_minutes, s.worked_minutes) - ISNULL(s.comp_leave_minutes, 0)) > @WorkCompletionToleranceMinutes
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
                 AND ISNULL(s.regular_worked_minutes, s.worked_minutes) + ISNULL(s.comp_leave_minutes, 0) >= s.required_minutes
                    THEN 0

                WHEN s.worked_minutes > (@MaxWorkHours * 60) THEN 1
                WHEN ISNULL(s.open_pair_count, 0) > 0 THEN 1
                WHEN s.first_clock_in IS NOT NULL AND s.last_clock_out IS NULL THEN 1
                WHEN s.first_clock_in IS NULL AND s.last_clock_out IS NOT NULL THEN 1
                WHEN s.required_minutes > 0
                 AND s.worked_minutes = 0
                 AND s.latest_punch_time IS NOT NULL THEN 1

                WHEN s.required_minutes > 0
                 AND s.required_minutes - ISNULL(s.regular_worked_minutes, s.worked_minutes) - ISNULL(s.comp_leave_minutes, 0) > @WorkCompletionToleranceMinutes
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
        f.emp_code = s.emp_code,
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
        f.regular_worked_minutes = s.regular_worked_minutes,
        f.regular_worked_hours = CAST(s.regular_worked_minutes / 60.0 AS decimal(10,2)),
        f.work_completion_pct =
            CASE
                WHEN s.required_minutes > 0
                THEN CAST(
                    CASE
                        WHEN (
                                (
                                    ISNULL(s.regular_worked_minutes, s.worked_minutes)
                                    + ISNULL(s.comp_leave_minutes, 0)
                                ) * 100.0 / s.required_minutes
                             ) > 100
                        THEN 100
                        ELSE
                            (
                                ISNULL(s.regular_worked_minutes, s.worked_minutes)
                                + ISNULL(s.comp_leave_minutes, 0)
                            ) * 100.0 / s.required_minutes
                    END AS decimal(10,2)
                )
                ELSE CAST(0 AS decimal(10,2))
            END,

        f.actual_excess_minutes =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 0 ELSE s.actual_excess_minutes END,
        f.excess_minutes =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 0 ELSE s.excess_minutes END,
        f.excess_hours =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 0 ELSE CAST(s.excess_minutes / 60.0 AS decimal(10,2)) END,

        f.shortfall_minutes =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 0 ELSE s.shortfall_minutes END,
        f.shortfall_hours =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 0 ELSE CAST(s.shortfall_minutes / 60.0 AS decimal(10,2)) END,

        f.reconciliation_status =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 'Balanced' ELSE s.reconciliation_status END,
        f.reconciliation_variance_minutes =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 0 ELSE s.reconciliation_variance_minutes END,

        f.ot_minutes = s.final_ot_minutes,
        f.ot_hours = CAST(s.final_ot_minutes / 60.0 AS decimal(10,2)),

        f.recomputed_absence_hours =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 0 ELSE CAST(s.absence_minutes / 60.0 AS decimal(10,2)) END,

        f.late_minutes =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 0 ELSE s.final_late_minutes END,
        f.actual_late_minutes =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 0 ELSE s.actual_late_minutes END,
        f.early_out_minutes =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 0 ELSE s.final_early_out_minutes END,
        f.actual_early_out_minutes =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 0 ELSE s.actual_early_out_minutes END,
        f.date_type = s.base_date_type,
        f.is_flex_duty =
            CASE
                WHEN ISNULL(s.use_mode, 0) = 1
                 AND ISNULL(s.resolved_is_off_day, 0) = 0
                 AND ISNULL(s.required_minutes, 0) > 0
                THEN 1 ELSE 0
            END,
        f.flex_duty_minutes =
            CASE
                WHEN ISNULL(s.use_mode, 0) = 1
                 AND ISNULL(s.resolved_is_off_day, 0) = 0
                 AND ISNULL(s.required_minutes, 0) > 0
                THEN CAST(ISNULL(s.worked_minutes, 0) AS decimal(10,2))
                ELSE CAST(0 AS decimal(10,2))
            END,
        f.[Leaves] = ISNULL(s.[Leaves], 0),
        f.sick_leave_days = ISNULL(s.sick_leave_days, 0),
        f.annual_leave_days = ISNULL(s.annual_leave_days, 0),
        f.compensatory_leave_days = ISNULL(s.compensatory_leave_days, 0),
        f.other_paid_leave_days = ISNULL(s.other_paid_leave_days, 0),
        f.unpaid_leave_days = ISNULL(s.unpaid_leave_days, 0),

        f.daily_status =
            CASE
                WHEN ISNULL(s.[Leaves], 0) > 0
                    THEN 'LeaveDay'

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
        f.business_day_type =
            CASE
                WHEN ISNULL(s.required_minutes, 0) = 0
                 AND ISNULL(s.worked_minutes, 0) > 0
                THEN
                    CASE
                        WHEN s.schedule_source IN ('Temporary', 'Employee', 'Group', 'Department')
                            THEN 'RegularDay'
                        WHEN s.base_date_type = 2 THEN 'RestDayOT'
                        WHEN s.base_date_type = 1 THEN 'HolidayOT'
                        ELSE 'RegularDayOT'
                    END

                WHEN s.base_date_type = 2
                 AND ISNULL(s.final_ot_minutes, 0) > 0
                 AND s.schedule_source = 'Unscheduled'
                    THEN 'RestDayOT'

                WHEN s.base_date_type = 1
                 AND ISNULL(s.final_ot_minutes, 0) > 0
                 AND s.schedule_source = 'Unscheduled'
                    THEN 'HolidayOT'

                WHEN s.base_date_type = 0
                 AND ISNULL(s.final_ot_minutes, 0) > 0
                    THEN 'RegularDayWithOT'

                WHEN s.base_date_type = 2 THEN 'RestDay'
                WHEN s.base_date_type = 1 THEN 'Holiday'
                ELSE 'RegularDay'
            END,

        f.attendance_status =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 'On Leave' ELSE s.attendance_status_final END,
        f.needs_payroll_review =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 0 ELSE s.needs_payroll_review_final END,
        f.required_scheduled_hours = CAST(s.required_minutes / 60.0 AS decimal(10,2)),
        f.schedule_label =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 'Approved Leave' ELSE s.schedule_label_final END,
        f.punch_status =
            CASE
                WHEN ISNULL(s.[Leaves], 0) > 0 THEN 'OK'
                WHEN ISNULL(s.worked_minutes, 0) > 0 THEN 'OK'
                WHEN s.first_clock_in IS NULL AND s.last_clock_out IS NULL THEN 'NoPunch'
                WHEN s.first_clock_in IS NOT NULL AND s.last_clock_out IS NULL THEN 'MissingOut'
                WHEN s.first_clock_in IS NULL AND s.last_clock_out IS NOT NULL THEN 'MissingIn'
                ELSE 'OK'
            END,
        f.anomaly_flag =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 'Normal' ELSE s.anomaly_flag_final END,
        f.anomaly_group =
            CASE
                WHEN ISNULL(s.[Leaves], 0) > 0 THEN 'Normal'
                WHEN ISNULL(s.anomaly_flag_final, 'Normal') = 'Normal' THEN 'Normal'
                WHEN s.anomaly_flag_final IN
                (
                    'AbsentNoPunch',
                    'MissingOut',
                    'MissingIn',
                    'IncompleteSplitDuty',
                    'UnpairedEarlyPunch',
                    'IncompletePunchPair',
                    'AutoCorrectedOK',
                    'AutoCorrectedPunchState'
                )
                    THEN 'PunchIssue'
                WHEN s.anomaly_flag_final IN
                (
                    'ExcessiveWorkHours',
                    'WorkedOutsideSchedule',
                    'IncompleteWork'
                )
                    THEN 'BusinessRule'
                ELSE 'Other'
            END,
        f.work_gap_minutes =
            CASE WHEN ISNULL(s.[Leaves], 0) > 0 THEN 0 ELSE s.work_gap_minutes END,
        f.comp_leave_eligible_flag =
            CASE WHEN ISNULL(s.comp_leave_minutes, 0) > 0 THEN 1 ELSE 0 END,
        f.comp_leave_minutes = ISNULL(s.comp_leave_minutes, 0),
        f.comp_leave_hours = CAST(ISNULL(s.comp_leave_minutes, 0) / 60.0 AS decimal(10,2)),
        f.corrected = ISNULL(ap.corrected, 0),
        f.effective_punch_in1 = ap.effective_punch_in1,
        f.effective_punch_out1 = ap.effective_punch_out1,
        f.effective_punch_in2 = ap.effective_punch_in2,
        f.effective_punch_out2 = ap.effective_punch_out2
    FROM dbo.custom_att_fact_DailyAttendance f
    JOIN #PayrollSrc s
        ON s.emp_id = f.emp_id
       AND s.att_date = f.att_date
    LEFT JOIN #AuditPunchColumns ap
        ON ap.emp_id = f.emp_id
       AND ap.att_date = f.att_date;

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
        CAST(SUM(ISNULL([Leaves], 0)) AS decimal(10,2)) AS total_leave_days,
        CAST(SUM(ISNULL(sick_leave_days, 0)) AS decimal(10,2)) AS total_sick_leave_days,
        CAST(SUM(ISNULL(annual_leave_days, 0)) AS decimal(10,2)) AS total_annual_leave_days,
        CAST(SUM(ISNULL(compensatory_leave_days, 0)) AS decimal(10,2)) AS total_compensatory_leave_days,
        CAST(SUM(ISNULL(other_paid_leave_days, 0)) AS decimal(10,2)) AS total_other_paid_leave_days,
        CAST(SUM(ISNULL(unpaid_leave_days, 0)) AS decimal(10,2)) AS total_unpaid_leave_days,
        SUM(CASE WHEN ISNULL(is_flex_duty, 0) = 1 THEN 1 ELSE 0 END) AS total_flex_duty_days,
        CAST(SUM(ISNULL(flex_duty_minutes, 0)) AS decimal(10,2)) AS total_flex_duty_minutes,

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
