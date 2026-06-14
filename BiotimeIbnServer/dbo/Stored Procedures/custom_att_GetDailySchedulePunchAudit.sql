CREATE PROCEDURE [dbo].[custom_att_GetDailySchedulePunchAudit]
    @BeginningDate date,
    @EndDate date,
    @EmpID int = NULL,
    @IssuesOnly bit = 0
AS
BEGIN
    SET NOCOUNT ON;

    IF @BeginningDate > @EndDate
    BEGIN
        DECLARE @SwapDate date = @BeginningDate;
        SET @BeginningDate = @EndDate;
        SET @EndDate = @SwapDate;
    END;

    CREATE TABLE #Facts
    (
        emp_id int NOT NULL,
        emp_code nvarchar(20) NULL,
        att_date date NOT NULL,
        emp_code_name nvarchar(250) NULL,
        department_id int NULL,
        group_id int NULL,
        required_scheduled_hours decimal(10,2) NULL,
        worked_hours decimal(10,2) NULL,
        attendance_status varchar(50) NULL,
        anomaly_flag varchar(100) NULL,
        needs_payroll_review bit NULL,
        fact_punch_in1 datetime2(7) NULL,
        fact_punch_out1 datetime2(7) NULL,
        fact_punch_in2 datetime2(7) NULL,
        fact_punch_out2 datetime2(7) NULL,
        CONSTRAINT PK_TempDailySchedulePunchAuditFacts PRIMARY KEY CLUSTERED (emp_id, att_date)
    );

    INSERT INTO #Facts
    (
        emp_id,
        emp_code,
        att_date,
        emp_code_name,
        department_id,
        group_id,
        required_scheduled_hours,
        worked_hours,
        attendance_status,
        anomaly_flag,
        needs_payroll_review,
        fact_punch_in1,
        fact_punch_out1,
        fact_punch_in2,
        fact_punch_out2
    )
    SELECT
        f.emp_id,
        f.emp_code,
        f.att_date,
        CONCAT(e.emp_code, '-', e.first_name) AS emp_code_name,
        e.department_id,
        ae.group_id,
        f.required_scheduled_hours,
        f.worked_hours,
        f.attendance_status,
        f.anomaly_flag,
        f.needs_payroll_review,
        f.effective_punch_in1,
        f.effective_punch_out1,
        f.effective_punch_in2,
        f.effective_punch_out2
    FROM dbo.custom_att_fact_DailyAttendance f
    LEFT JOIN dbo.personnel_employee e
        ON e.id = f.emp_id
    LEFT JOIN dbo.att_attemployee ae
        ON ae.emp_id = f.emp_id
    WHERE f.att_date BETWEEN @BeginningDate AND @EndDate
      AND (@EmpID IS NULL OR f.emp_id = @EmpID)
      AND NOT EXISTS
      (
          SELECT 1
          FROM dbo.personnel_resign r
          WHERE r.employee_id = f.emp_id
            AND f.att_date > r.resign_date
      )
    OPTION (RECOMPILE);

    CREATE TABLE #Punches
    (
        emp_id int NOT NULL,
        work_date date NOT NULL,
        id int NOT NULL,
        punch_time datetime2(7) NOT NULL,
        punch_state int NULL,
        norm_punch_state int NULL
    );

    INSERT INTO #Punches
    (
        emp_id,
        work_date,
        id,
        punch_time,
        punch_state,
        norm_punch_state
    )
    SELECT
        np.emp_id,
        np.work_date,
        np.id,
        np.punch_time,
        np.punch_state,
        CASE
            WHEN np.punch_state IN (0, 4) THEN 0
            WHEN np.punch_state IN (1, 5) THEN 1
            ELSE np.punch_state
        END AS norm_punch_state
    FROM dbo.custom_att_fnd_NormalizedPunches np
    INNER JOIN #Facts f
        ON f.emp_id = np.emp_id
       AND f.att_date = np.work_date;

    CREATE CLUSTERED INDEX IX_TempDailySchedulePunchAuditPunches
        ON #Punches (emp_id, work_date, punch_time, id);

    CREATE TABLE #CleanedPunches
    (
        emp_id int NOT NULL,
        work_date date NOT NULL,
        id int NOT NULL,
        punch_time datetime2(7) NOT NULL,
        punch_state int NULL,
        norm_punch_state int NULL
    );

    ;WITH ordered AS
    (
        SELECT
            p.*,
            LAG(p.punch_time) OVER
            (
                PARTITION BY p.emp_id, p.work_date, p.norm_punch_state
                ORDER BY p.punch_time, p.id
            ) AS prev_same_state_punch_time
        FROM #Punches p
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
                PARTITION BY m.emp_id, m.work_date, m.norm_punch_state
                ORDER BY m.punch_time, m.id
                ROWS UNBOUNDED PRECEDING
            ) AS burst_no
        FROM marked m
    )
    INSERT INTO #CleanedPunches
    (
        emp_id,
        work_date,
        id,
        punch_time,
        punch_state,
        norm_punch_state
    )
    SELECT
        b.emp_id,
        b.work_date,
        MIN(b.id) AS id,
        MIN(b.punch_time) AS punch_time,
        MIN(b.punch_state) AS punch_state,
        b.norm_punch_state
    FROM bursted b
    GROUP BY
        b.emp_id,
        b.work_date,
        b.norm_punch_state,
        b.burst_no;

    CREATE CLUSTERED INDEX IX_TempDailySchedulePunchAuditCleaned
        ON #CleanedPunches (emp_id, work_date, norm_punch_state, punch_time, id);

    CREATE TABLE #ScheduleCandidates
    (
        emp_id int NOT NULL,
        att_date date NOT NULL,
        effective_schedule_source varchar(30) NOT NULL,
        source_priority int NOT NULL,
        effective_shift_id int NULL,
        effective_time_interval_id int NULL,
        source_row_id int NOT NULL,
        schedule_anchor_date date NOT NULL
    );

    INSERT INTO #ScheduleCandidates
    SELECT
        ts.employee_id,
        ts.att_date,
        'Temporary',
        1,
        CAST(NULL AS int),
        ts.time_interval_id,
        ts.id,
        ts.att_date
    FROM dbo.att_temporaryschedule ts
    INNER JOIN #Facts f
        ON f.emp_id = ts.employee_id
       AND f.att_date = ts.att_date
    WHERE ISNULL(ts.status, 0) = 0
      AND ts.employee_id IS NOT NULL
      AND ts.att_date IS NOT NULL;

    INSERT INTO #ScheduleCandidates
    SELECT
        s.employee_id,
        f.att_date,
        'Employee',
        2,
        s.shift_id,
        CAST(NULL AS int),
        s.id,
        s.start_date
    FROM dbo.att_attschedule s
    INNER JOIN #Facts f
        ON f.emp_id = s.employee_id
       AND f.att_date BETWEEN s.start_date AND s.end_date
    WHERE s.employee_id IS NOT NULL
      AND s.shift_id IS NOT NULL;

    INSERT INTO #ScheduleCandidates
    SELECT
        f.emp_id,
        f.att_date,
        'Group',
        3,
        gs.shift_id,
        CAST(NULL AS int),
        gs.id,
        gs.start_date
    FROM dbo.att_groupschedule gs
    INNER JOIN #Facts f
        ON f.group_id = gs.group_id
       AND f.att_date BETWEEN gs.start_date AND gs.end_date
    WHERE ISNULL(gs.status, 0) = 0
      AND gs.shift_id IS NOT NULL;

    INSERT INTO #ScheduleCandidates
    SELECT
        f.emp_id,
        f.att_date,
        'Department',
        4,
        ds.shift_id,
        CAST(NULL AS int),
        ds.id,
        ds.start_date
    FROM dbo.att_departmentschedule ds
    INNER JOIN #Facts f
        ON f.department_id = ds.department_id
       AND f.att_date BETWEEN ds.start_date AND ds.end_date
    WHERE ISNULL(ds.status, 0) = 0
      AND ds.shift_id IS NOT NULL;

    CREATE CLUSTERED INDEX IX_TempDailySchedulePunchAuditScheduleCandidates
        ON #ScheduleCandidates (emp_id, att_date, source_priority, source_row_id DESC);

    CREATE TABLE #ResolvedSchedule
    (
        emp_id int NOT NULL,
        att_date date NOT NULL,
        effective_schedule_source varchar(30) NULL,
        effective_time_interval_id int NULL,
        effective_scheduled_in_datetime datetime NULL,
        effective_scheduled_out_datetime datetime NULL,
        schedule_use_mode int NULL,
        schedule_in_time time(7) NULL,
        EffectiveScheduleAlias nvarchar(50) NULL,
        CONSTRAINT PK_TempDailySchedulePunchAuditResolvedSchedule PRIMARY KEY CLUSTERED (emp_id, att_date)
    );

    ;WITH Ranked AS
    (
        SELECT
            sc.*,
            ROW_NUMBER() OVER
            (
                PARTITION BY sc.emp_id, sc.att_date
                ORDER BY sc.source_priority, sc.source_row_id DESC
            ) AS rn
        FROM #ScheduleCandidates sc
    ),
    Chosen AS
    (
        SELECT
            r.emp_id,
            r.att_date,
            r.effective_schedule_source,
            r.effective_shift_id,
            r.effective_time_interval_id,
            r.schedule_anchor_date,
            ISNULL(sh.shift_cycle, 1) AS shift_cycle,
            CASE
                WHEN r.effective_shift_id IS NULL THEN NULL

                WHEN ISNULL(sh.shift_cycle, 1) > 1
                THEN
                    (
                        (
                            (
                                DATEDIFF(
                                    DAY,
                                    DATEADD(
                                        DAY,
                                        -((DATEDIFF(DAY, '19000101', r.schedule_anchor_date) % 7 + 7) % 7),
                                        r.schedule_anchor_date
                                    ),
                                    r.att_date
                                ) / 7
                            )
                            % ISNULL(sh.shift_cycle, 1)
                        ) * 7
                        + ((DATEDIFF(DAY, '19000101', r.att_date) % 7 + 7) % 7)
                        + 1
                    )
                    % (ISNULL(sh.shift_cycle, 1) * 7)

                ELSE
                    (DATEDIFF(DAY, '19000107', r.att_date) % 7 + 7) % 7
            END AS resolved_day_index
        FROM Ranked r
        LEFT JOIN dbo.att_attshift sh
            ON sh.id = r.effective_shift_id
        WHERE r.rn = 1
    )
    INSERT INTO #ResolvedSchedule
    (
        emp_id,
        att_date,
        effective_schedule_source,
        effective_time_interval_id,
        effective_scheduled_in_datetime,
        effective_scheduled_out_datetime,
        schedule_use_mode,
        schedule_in_time,
        EffectiveScheduleAlias
    )
    SELECT
        c.emp_id,
        c.att_date,
        c.effective_schedule_source,
        COALESCE(c.effective_time_interval_id, sd.time_interval_id) AS effective_time_interval_id,
        DATEADD(
            MINUTE,
            DATEDIFF(MINUTE, CAST('00:00:00' AS time), ti.in_time),
            CAST(c.att_date AS datetime)
        ) AS effective_scheduled_in_datetime,
        DATEADD(
            MINUTE,
            DATEDIFF(MINUTE, CAST('00:00:00' AS time), ti.in_time)
              + ISNULL(ti.duration, 0),
            CAST(c.att_date AS datetime)
        ) AS effective_scheduled_out_datetime,
        ti.use_mode,
        ti.in_time,
        ti.alias
    FROM Chosen c
    OUTER APPLY
    (
        SELECT TOP (1) *
        FROM dbo.att_shiftdetail sd
        WHERE sd.shift_id = c.effective_shift_id
          AND sd.day_index = c.resolved_day_index
    ) sd
    LEFT JOIN dbo.att_timeinterval ti
        ON ti.id = COALESCE(c.effective_time_interval_id, sd.time_interval_id);

    CREATE TABLE #ScheduleSegments
    (
        emp_id int NOT NULL,
        att_date date NOT NULL,
        segment_no int NOT NULL,
        segment_start_datetime datetime NOT NULL,
        segment_end_datetime datetime NOT NULL,
        previous_segment_end_datetime datetime NULL,
        next_segment_start_datetime datetime NULL
    );

    ;WITH WorkDays AS
    (
        SELECT
            f.emp_id,
            f.att_date,
            rs.effective_time_interval_id,
            rs.effective_scheduled_in_datetime AS schedule_start_datetime,
            rs.effective_scheduled_out_datetime AS schedule_end_datetime,
            rs.schedule_in_time
        FROM #Facts f
        INNER JOIN #ResolvedSchedule rs
            ON rs.emp_id = f.emp_id
           AND rs.att_date = f.att_date
        WHERE ISNULL(f.required_scheduled_hours, 0) > 0
          AND ISNULL(rs.schedule_use_mode, 0) <> 1
          AND rs.effective_scheduled_in_datetime IS NOT NULL
          AND rs.effective_scheduled_out_datetime IS NOT NULL
    ),
    Breaks AS
    (
        SELECT
            wd.emp_id,
            wd.att_date,
            DATEADD(
                MINUTE,
                CASE
                    WHEN DATEDIFF(MINUTE, wd.schedule_in_time, bt.period_start) < 0
                    THEN DATEDIFF(MINUTE, wd.schedule_in_time, bt.period_start) + 1440
                    ELSE DATEDIFF(MINUTE, wd.schedule_in_time, bt.period_start)
                END,
                wd.schedule_start_datetime
            ) AS break_start_datetime,
            DATEADD(
                MINUTE,
                CASE
                    WHEN DATEDIFF(MINUTE, wd.schedule_in_time, bt.period_start) < 0
                    THEN DATEDIFF(MINUTE, wd.schedule_in_time, bt.period_start) + 1440
                    ELSE DATEDIFF(MINUTE, wd.schedule_in_time, bt.period_start)
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
    ),
    NumberedSegments AS
    (
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
        FROM Segments s
        WHERE s.segment_end_datetime > s.segment_start_datetime
    )
    INSERT INTO #ScheduleSegments
    SELECT
        ns.emp_id,
        ns.att_date,
        ns.segment_no,
        ns.segment_start_datetime,
        ns.segment_end_datetime,
        ns.previous_segment_end_datetime,
        ns.next_segment_start_datetime
    FROM NumberedSegments ns;

    CREATE CLUSTERED INDEX IX_TempDailySchedulePunchAuditScheduleSegments
        ON #ScheduleSegments (emp_id, att_date, segment_no);

    CREATE TABLE #SegmentAudit
    (
        emp_id int NOT NULL,
        att_date date NOT NULL,
        schedule_segment_count int NOT NULL,
        unmatched_segment_count int NOT NULL,
        segment_worked_minutes int NULL,
        effective_punch_in1 datetime2(7) NULL,
        effective_punch_out1 datetime2(7) NULL,
        effective_punch_in2 datetime2(7) NULL,
        effective_punch_out2 datetime2(7) NULL,
        CONSTRAINT PK_TempDailySchedulePunchAuditSegmentAudit PRIMARY KEY CLUSTERED (emp_id, att_date)
    );

    INSERT INTO #SegmentAudit
    (
        emp_id,
        att_date,
        schedule_segment_count,
        unmatched_segment_count,
        segment_worked_minutes,
        effective_punch_in1,
        effective_punch_out1,
        effective_punch_in2,
        effective_punch_out2
    )
    SELECT
        sm.emp_id,
        sm.att_date,
        COUNT(*) AS schedule_segment_count,
        SUM(CASE WHEN sm.in_time IS NULL OR sm.out_time IS NULL THEN 1 ELSE 0 END) AS unmatched_segment_count,
        SUM(
            CASE
                WHEN sm.in_time IS NOT NULL
                 AND sm.out_time IS NOT NULL
                 AND sm.out_time > sm.in_time
                THEN DATEDIFF(MINUTE, sm.in_time, sm.out_time)
                ELSE 0
            END
        ) AS segment_worked_minutes,
        MAX(CASE WHEN sm.segment_no = 1 THEN sm.in_time END) AS effective_punch_in1,
        MAX(CASE WHEN sm.segment_no = 1 THEN sm.out_time END) AS effective_punch_out1,
        MAX(CASE WHEN sm.segment_no = 2 THEN sm.in_time END) AS effective_punch_in2,
        MAX(CASE WHEN sm.segment_no = 2 THEN sm.out_time END) AS effective_punch_out2
    FROM
    (
        SELECT
            ss.emp_id,
            ss.att_date,
            ss.segment_no,
            si.in_time,
            so.out_time
        FROM #ScheduleSegments ss
        OUTER APPLY
        (
            SELECT TOP (1)
                cp.punch_time AS in_time
            FROM #CleanedPunches cp
            WHERE cp.emp_id = ss.emp_id
              AND cp.work_date = ss.att_date
              AND cp.norm_punch_state = 0
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
            FROM #CleanedPunches cp
            WHERE cp.emp_id = ss.emp_id
              AND cp.work_date = ss.att_date
              AND cp.norm_punch_state = 1
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
    ) sm
    GROUP BY
        sm.emp_id,
        sm.att_date;

    ;WITH FinalRows AS
    (
        SELECT
            f.att_date AS [Date],
            f.emp_id AS emp_id,
            f.emp_code,
            f.emp_code_name,
            rs.EffectiveScheduleAlias,
            CONVERT(varchar(8), CAST(rs.effective_scheduled_in_datetime AS time), 108) AS ScheduledIn,
            CONVERT(varchar(8), CAST(rs.effective_scheduled_out_datetime AS time), 108) AS ScheduledOut,
            CONVERT(varchar(8), CAST(
                CASE
                    WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                     AND ISNULL(sa.unmatched_segment_count, 0) = 0
                     AND ISNULL(sa.segment_worked_minutes, 0) > 0
                    THEN sa.effective_punch_in1
                    ELSE f.fact_punch_in1
                END AS time
            ), 108) AS EffectivePunchIn1,
            CONVERT(varchar(8), CAST(
                CASE
                    WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                     AND ISNULL(sa.unmatched_segment_count, 0) = 0
                     AND ISNULL(sa.segment_worked_minutes, 0) > 0
                    THEN sa.effective_punch_out1
                    ELSE f.fact_punch_out1
                END AS time
            ), 108) AS EffectivePunchOut1,
            CONVERT(varchar(8), CAST(
                CASE
                    WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                     AND ISNULL(sa.unmatched_segment_count, 0) = 0
                     AND ISNULL(sa.segment_worked_minutes, 0) > 0
                    THEN sa.effective_punch_in2
                    ELSE f.fact_punch_in2
                END AS time
            ), 108) AS EffectivePunchIn2,
            CONVERT(varchar(8), CAST(
                CASE
                    WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                     AND ISNULL(sa.unmatched_segment_count, 0) = 0
                     AND ISNULL(sa.segment_worked_minutes, 0) > 0
                    THEN sa.effective_punch_out2
                    ELSE f.fact_punch_out2
                END AS time
            ), 108) AS EffectivePunchOut2,
            punch_lists.AllPunches,
            DATEDIFF(
                MINUTE,
                rs.effective_scheduled_in_datetime,
                CASE
                    WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                     AND ISNULL(sa.unmatched_segment_count, 0) = 0
                     AND ISNULL(sa.segment_worked_minutes, 0) > 0
                    THEN sa.effective_punch_in1
                    ELSE f.fact_punch_in1
                END
            ) AS InOffsetMinutes,
            DATEDIFF(
                MINUTE,
                rs.effective_scheduled_out_datetime,
                COALESCE(
                    CASE
                        WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                         AND ISNULL(sa.unmatched_segment_count, 0) = 0
                         AND ISNULL(sa.segment_worked_minutes, 0) > 0
                        THEN sa.effective_punch_out2
                        ELSE f.fact_punch_out2
                    END,
                    CASE
                        WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                         AND ISNULL(sa.unmatched_segment_count, 0) = 0
                         AND ISNULL(sa.segment_worked_minutes, 0) > 0
                        THEN sa.effective_punch_out1
                        ELSE f.fact_punch_out1
                    END
                )
            ) AS OutOffsetMinutes,
            CASE
                WHEN rs.emp_id IS NULL
                THEN 'MissingSchedule'

                WHEN
                    CASE
                        WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                         AND ISNULL(sa.unmatched_segment_count, 0) = 0
                         AND ISNULL(sa.segment_worked_minutes, 0) > 0
                        THEN sa.effective_punch_in1
                        ELSE f.fact_punch_in1
                    END IS NULL
                 AND
                    CASE
                        WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                         AND ISNULL(sa.unmatched_segment_count, 0) = 0
                         AND ISNULL(sa.segment_worked_minutes, 0) > 0
                        THEN sa.effective_punch_out1
                        ELSE f.fact_punch_out1
                    END IS NULL
                THEN 'NoEffectivePunches'

                WHEN
                    CASE
                        WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                         AND ISNULL(sa.unmatched_segment_count, 0) = 0
                         AND ISNULL(sa.segment_worked_minutes, 0) > 0
                        THEN sa.effective_punch_in1
                        ELSE f.fact_punch_in1
                    END IS NULL
                THEN 'MissingEffectiveIn'

                WHEN COALESCE(
                    CASE
                        WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                         AND ISNULL(sa.unmatched_segment_count, 0) = 0
                         AND ISNULL(sa.segment_worked_minutes, 0) > 0
                        THEN sa.effective_punch_out2
                        ELSE f.fact_punch_out2
                    END,
                    CASE
                        WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                         AND ISNULL(sa.unmatched_segment_count, 0) = 0
                         AND ISNULL(sa.segment_worked_minutes, 0) > 0
                        THEN sa.effective_punch_out1
                        ELSE f.fact_punch_out1
                    END
                ) IS NULL
                THEN 'MissingEffectiveOut'

                WHEN rs.effective_scheduled_in_datetime IS NOT NULL
                 AND rs.effective_scheduled_out_datetime IS NOT NULL
                 AND DATEDIFF(
                        MINUTE,
                        rs.effective_scheduled_in_datetime,
                        CASE
                            WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                             AND ISNULL(sa.unmatched_segment_count, 0) = 0
                             AND ISNULL(sa.segment_worked_minutes, 0) > 0
                            THEN sa.effective_punch_in1
                            ELSE f.fact_punch_in1
                        END
                     ) <= -60
                 AND DATEDIFF(
                        MINUTE,
                        rs.effective_scheduled_out_datetime,
                        COALESCE(
                            CASE
                                WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                                 AND ISNULL(sa.unmatched_segment_count, 0) = 0
                                 AND ISNULL(sa.segment_worked_minutes, 0) > 0
                                THEN sa.effective_punch_out2
                                ELSE f.fact_punch_out2
                            END,
                            CASE
                                WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                                 AND ISNULL(sa.unmatched_segment_count, 0) = 0
                                 AND ISNULL(sa.segment_worked_minutes, 0) > 0
                                THEN sa.effective_punch_out1
                                ELSE f.fact_punch_out1
                            END
                        )
                     ) <= -60
                THEN 'LikelyEarlierSchedule'

                WHEN rs.effective_scheduled_in_datetime IS NOT NULL
                 AND rs.effective_scheduled_out_datetime IS NOT NULL
                 AND DATEDIFF(
                        MINUTE,
                        rs.effective_scheduled_in_datetime,
                        CASE
                            WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                             AND ISNULL(sa.unmatched_segment_count, 0) = 0
                             AND ISNULL(sa.segment_worked_minutes, 0) > 0
                            THEN sa.effective_punch_in1
                            ELSE f.fact_punch_in1
                        END
                     ) >= 60
                 AND DATEDIFF(
                        MINUTE,
                        rs.effective_scheduled_out_datetime,
                        COALESCE(
                            CASE
                                WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                                 AND ISNULL(sa.unmatched_segment_count, 0) = 0
                                 AND ISNULL(sa.segment_worked_minutes, 0) > 0
                                THEN sa.effective_punch_out2
                                ELSE f.fact_punch_out2
                            END,
                            CASE
                                WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                                 AND ISNULL(sa.unmatched_segment_count, 0) = 0
                                 AND ISNULL(sa.segment_worked_minutes, 0) > 0
                                THEN sa.effective_punch_out1
                                ELSE f.fact_punch_out1
                            END
                        )
                     ) >= 60
                THEN 'LikelyLaterSchedule'

                WHEN rs.effective_scheduled_in_datetime IS NOT NULL
                 AND ABS(DATEDIFF(
                        MINUTE,
                        rs.effective_scheduled_in_datetime,
                        CASE
                            WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                             AND ISNULL(sa.unmatched_segment_count, 0) = 0
                             AND ISNULL(sa.segment_worked_minutes, 0) > 0
                            THEN sa.effective_punch_in1
                            ELSE f.fact_punch_in1
                        END
                     )) >= 120
                THEN 'PunchInFarFromSchedule'

                WHEN rs.effective_scheduled_out_datetime IS NOT NULL
                 AND ABS(DATEDIFF(
                        MINUTE,
                        rs.effective_scheduled_out_datetime,
                        COALESCE(
                            CASE
                                WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                                 AND ISNULL(sa.unmatched_segment_count, 0) = 0
                                 AND ISNULL(sa.segment_worked_minutes, 0) > 0
                                THEN sa.effective_punch_out2
                                ELSE f.fact_punch_out2
                            END,
                            CASE
                                WHEN ISNULL(sa.schedule_segment_count, 1) > 1
                                 AND ISNULL(sa.unmatched_segment_count, 0) = 0
                                 AND ISNULL(sa.segment_worked_minutes, 0) > 0
                                THEN sa.effective_punch_out1
                                ELSE f.fact_punch_out1
                            END
                        )
                     )) >= 120
                THEN 'PunchOutFarFromSchedule'

                ELSE 'OK'
            END AS SchedulePunchCheck,
            f.required_scheduled_hours AS RequiredScheduledHours,
            f.worked_hours AS WorkedHours,
            f.attendance_status AS AttendanceStatus,
            f.anomaly_flag AS AnomalyFlag,
            f.needs_payroll_review AS NeedsPayrollReview,
            rs.effective_schedule_source AS EffectiveScheduleSource
        FROM #Facts f
        LEFT JOIN #ResolvedSchedule rs
            ON rs.emp_id = f.emp_id
           AND rs.att_date = f.att_date
        LEFT JOIN #SegmentAudit sa
            ON sa.emp_id = f.emp_id
           AND sa.att_date = f.att_date
        OUTER APPLY
        (
            SELECT
                STUFF(
                    (
                        SELECT
                            ',' + CONVERT(varchar(8), CAST(p.punch_time AS time), 108)
                            + '('
                            + CASE
                                WHEN p.punch_state IN (0, 4) THEN 'IN'
                                WHEN p.punch_state IN (1, 5) THEN 'OUT'
                                ELSE CONVERT(varchar(10), p.punch_state)
                              END
                            + ')'
                        FROM #Punches p
                        WHERE p.emp_id = f.emp_id
                          AND p.work_date = f.att_date
                        ORDER BY
                            p.punch_time,
                            p.id
                        FOR XML PATH('')
                    ),
                    1,
                    1,
                    ''
                ) AS AllPunches
        ) punch_lists
    )
    SELECT *
    FROM FinalRows
    WHERE
        @IssuesOnly = 0
        OR
        (
            SchedulePunchCheck <> 'OK'
            AND ISNULL(EffectiveScheduleAlias, '') NOT LIKE '%Flexi%'
        )
    ORDER BY
        [Date],
        emp_code_name;
END;
