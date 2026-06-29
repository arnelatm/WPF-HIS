CREATE PROCEDURE [dbo].[custom_att_dbg_DailyTrace]
    @EmpID int,
    @AttDate date,
    @IncludeAccuracyIssues bit = 0,
    @IncludeMonthlySummary bit = 0
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @pEmpID int = @EmpID;
    DECLARE @pAttDate date = @AttDate;
    DECLARE @MonthStart date = DATEFROMPARTS(YEAR(@pAttDate), MONTH(@pAttDate), 1);
    DECLARE @MonthEnd date = EOMONTH(@pAttDate);

    --------------------------------------------------
    -- Scope the trace once. Avoid broad audit/foundation views here;
    -- this procedure is for one employee/date.
    --------------------------------------------------
    CREATE TABLE #Fact
    (
        emp_id int NOT NULL,
        emp_code nvarchar(20) NULL,
        att_date date NOT NULL,
        year_no int NULL,
        month_no int NULL,
        employee_name nvarchar(201) NULL,
        emp_code_name nvarchar(250) NULL,
        department_id int NULL,
        dept_name nvarchar(200) NULL,
        group_id int NULL,
        daily_status varchar(50) NULL,
        business_day_type varchar(50) NULL,
        attendance_status varchar(50) NULL,
        punch_status varchar(50) NULL,
        schedule_label varchar(100) NULL,
        anomaly_flag varchar(100) NULL,
        anomaly_group varchar(50) NULL,
        needs_payroll_review bit NULL,
        first_clock_in datetime NULL,
        last_clock_out datetime NULL,
        effective_punch_in1 datetime2(7) NULL,
        effective_punch_out1 datetime2(7) NULL,
        effective_punch_in2 datetime2(7) NULL,
        effective_punch_out2 datetime2(7) NULL,
        required_scheduled_hours decimal(10,2) NULL,
        worked_hours decimal(10,2) NULL,
        regular_worked_hours decimal(10,2) NULL,
        ot_hours decimal(10,2) NULL,
        recomputed_worked_minutes decimal(10,2) NULL,
        regular_worked_minutes decimal(10,2) NULL,
        ot_minutes decimal(10,2) NULL,
        late_minutes decimal(10,2) NULL,
        early_out_minutes decimal(10,2) NULL,
        actual_late_minutes decimal(10,2) NULL,
        actual_early_out_minutes decimal(10,2) NULL,
        excess_minutes decimal(10,2) NULL,
        shortfall_minutes decimal(10,2) NULL,
        reconciliation_status varchar(50) NULL,
        reconciliation_variance_minutes decimal(10,2) NULL,
        work_gap_minutes decimal(10,2) NULL,
        corrected bit NULL,
        [Leaves] decimal(10,2) NULL,
        CONSTRAINT PK_TempDailyTraceFact PRIMARY KEY CLUSTERED (emp_id, att_date)
    );

    INSERT INTO #Fact
    (
        emp_id,
        emp_code,
        att_date,
        year_no,
        month_no,
        employee_name,
        emp_code_name,
        department_id,
        dept_name,
        group_id,
        daily_status,
        business_day_type,
        attendance_status,
        punch_status,
        schedule_label,
        anomaly_flag,
        anomaly_group,
        needs_payroll_review,
        first_clock_in,
        last_clock_out,
        effective_punch_in1,
        effective_punch_out1,
        effective_punch_in2,
        effective_punch_out2,
        required_scheduled_hours,
        worked_hours,
        regular_worked_hours,
        ot_hours,
        recomputed_worked_minutes,
        regular_worked_minutes,
        ot_minutes,
        late_minutes,
        early_out_minutes,
        actual_late_minutes,
        actual_early_out_minutes,
        excess_minutes,
        shortfall_minutes,
        reconciliation_status,
        reconciliation_variance_minutes,
        work_gap_minutes,
        corrected,
        [Leaves]
    )
    SELECT
        f.emp_id,
        f.emp_code,
        f.att_date,
        f.year_no,
        f.month_no,
        LTRIM(RTRIM(ISNULL(e.first_name, '') + ' ' + ISNULL(e.last_name, ''))) AS employee_name,
        CONCAT(f.emp_code, '-', e.first_name) AS emp_code_name,
        e.department_id,
        d.dept_name,
        ae.group_id,
        f.daily_status,
        f.business_day_type,
        f.attendance_status,
        f.punch_status,
        f.schedule_label,
        f.anomaly_flag,
        f.anomaly_group,
        f.needs_payroll_review,
        f.first_clock_in,
        f.last_clock_out,
        f.effective_punch_in1,
        f.effective_punch_out1,
        f.effective_punch_in2,
        f.effective_punch_out2,
        f.required_scheduled_hours,
        f.worked_hours,
        f.regular_worked_hours,
        f.ot_hours,
        f.recomputed_worked_minutes,
        f.regular_worked_minutes,
        f.ot_minutes,
        f.late_minutes,
        f.early_out_minutes,
        f.actual_late_minutes,
        f.actual_early_out_minutes,
        f.excess_minutes,
        f.shortfall_minutes,
        f.reconciliation_status,
        f.reconciliation_variance_minutes,
        f.work_gap_minutes,
        f.corrected,
        f.[Leaves]
    FROM dbo.custom_att_fact_DailyAttendance f
    LEFT JOIN dbo.personnel_employee e
        ON e.id = f.emp_id
    LEFT JOIN dbo.personnel_department d
        ON d.id = e.department_id
    LEFT JOIN dbo.att_attemployee ae
        ON ae.emp_id = f.emp_id
    WHERE f.emp_id = @pEmpID
      AND f.att_date = @pAttDate;

    CREATE TABLE #ResolvedSchedule
    (
        emp_id int NOT NULL,
        att_date date NOT NULL,
        effective_schedule_source varchar(30) NULL,
        source_priority int NULL,
        effective_shift_id int NULL,
        effective_shift_alias nvarchar(50) NULL,
        effective_time_interval_id int NULL,
        effective_time_interval_alias nvarchar(50) NULL,
        resolved_is_off_day int NULL,
        effective_required_work_minutes int NULL,
        scheduled_ot_cap_minutes int NULL,
        in_time time NULL,
        duration int NULL,
        work_time_duration int NULL,
        work_type smallint NULL,
        use_mode smallint NULL,
        effective_scheduled_in_datetime datetime NULL,
        effective_scheduled_out_datetime datetime NULL,
        CONSTRAINT PK_TempDailyTraceSchedule PRIMARY KEY CLUSTERED (emp_id, att_date)
    );

    ;WITH ScheduleCandidates AS
    (
        SELECT
            ts.employee_id AS emp_id,
            ts.att_date,
            CAST('Temporary' AS varchar(30)) AS effective_schedule_source,
            1 AS source_priority,
            CAST(NULL AS int) AS effective_shift_id,
            ts.time_interval_id AS effective_time_interval_id,
            ts.id AS source_row_id,
            ts.att_date AS schedule_anchor_date
        FROM dbo.att_temporaryschedule ts
        WHERE ISNULL(ts.status, 0) = 0
          AND ts.employee_id = @pEmpID
          AND ts.att_date = @pAttDate

        UNION ALL

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
        INNER JOIN #Fact f
            ON f.emp_id = s.employee_id
           AND f.att_date BETWEEN s.start_date AND s.end_date
        WHERE s.shift_id IS NOT NULL

        UNION ALL

        SELECT
            f.emp_id,
            f.att_date,
            'Group',
            3,
            gs.shift_id,
            CAST(NULL AS int),
            gs.id,
            gs.start_date
        FROM #Fact f
        INNER JOIN dbo.att_groupschedule gs
            ON gs.group_id = f.group_id
           AND f.att_date BETWEEN gs.start_date AND gs.end_date
        WHERE ISNULL(gs.status, 0) = 0
          AND gs.shift_id IS NOT NULL

        UNION ALL

        SELECT
            f.emp_id,
            f.att_date,
            'Department',
            4,
            ds.shift_id,
            CAST(NULL AS int),
            ds.id,
            ds.start_date
        FROM #Fact f
        INNER JOIN dbo.att_departmentschedule ds
            ON ds.department_id = f.department_id
           AND f.att_date BETWEEN ds.start_date AND ds.end_date
        WHERE ISNULL(ds.status, 0) = 0
          AND ds.shift_id IS NOT NULL
    ),
    Ranked AS
    (
        SELECT
            sc.*,
            ROW_NUMBER() OVER
            (
                PARTITION BY sc.emp_id, sc.att_date
                ORDER BY sc.source_priority, sc.source_row_id DESC
            ) AS rn
        FROM ScheduleCandidates sc
    ),
    Chosen AS
    (
        SELECT
            r.emp_id,
            r.att_date,
            r.effective_schedule_source,
            r.source_priority,
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
    ),
    Breaks AS
    (
        SELECT
            tib.timeinterval_id,
            SUM(ISNULL(bt.duration, 0)) AS break_minutes
        FROM dbo.att_timeinterval_break_time tib
        INNER JOIN dbo.att_breaktime bt
            ON bt.id = tib.breaktime_id
        GROUP BY tib.timeinterval_id
    )
    INSERT INTO #ResolvedSchedule
    (
        emp_id,
        att_date,
        effective_schedule_source,
        source_priority,
        effective_shift_id,
        effective_shift_alias,
        effective_time_interval_id,
        effective_time_interval_alias,
        resolved_is_off_day,
        effective_required_work_minutes,
        scheduled_ot_cap_minutes,
        in_time,
        duration,
        work_time_duration,
        work_type,
        use_mode,
        effective_scheduled_in_datetime,
        effective_scheduled_out_datetime
    )
    SELECT
        c.emp_id,
        c.att_date,
        c.effective_schedule_source,
        c.source_priority,
        c.effective_shift_id,
        sh.alias,
        COALESCE(c.effective_time_interval_id, sd.time_interval_id),
        ti.alias,
        CASE
            WHEN c.effective_schedule_source <> 'Temporary'
             AND c.effective_shift_id IS NOT NULL
             AND sd.shift_id IS NULL THEN 1
            WHEN ISNULL(ti.work_type, 0) IN (1, 2) THEN 1
            ELSE 0
        END,
        CASE
            WHEN ISNULL(ti.work_type, 0) IN (1, 2) THEN 0
            WHEN c.effective_schedule_source <> 'Temporary'
             AND c.effective_shift_id IS NOT NULL
             AND sd.shift_id IS NULL THEN 0
            ELSE ISNULL(ti.duration, 0) - ISNULL(b.break_minutes, 0)
        END,
        CASE
            WHEN c.effective_schedule_source = 'Temporary' THEN 0
            WHEN ISNULL(ti.enable_overtime, 0) = 1
             AND ISNULL(ti.max_ot_limit, 0) > 0
            THEN ISNULL(ti.max_ot_limit, 0)
            ELSE 0
        END,
        ti.in_time,
        ti.duration,
        ti.work_time_duration,
        ti.work_type,
        ti.use_mode,
        DATEADD(
            MINUTE,
            DATEDIFF(MINUTE, CAST('00:00:00' AS time), ti.in_time),
            CAST(c.att_date AS datetime)
        ),
        DATEADD(
            MINUTE,
            DATEDIFF(MINUTE, CAST('00:00:00' AS time), ti.in_time) + ISNULL(ti.duration, 0),
            CAST(c.att_date AS datetime)
        )
    FROM Chosen c
    LEFT JOIN dbo.att_attshift sh
        ON sh.id = c.effective_shift_id
    OUTER APPLY
    (
        SELECT TOP (1) *
        FROM dbo.att_shiftdetail sd
        WHERE sd.shift_id = c.effective_shift_id
          AND sd.day_index = c.resolved_day_index
    ) sd
    LEFT JOIN dbo.att_timeinterval ti
        ON ti.id = COALESCE(c.effective_time_interval_id, sd.time_interval_id)
    LEFT JOIN Breaks b
        ON b.timeinterval_id = COALESCE(c.effective_time_interval_id, sd.time_interval_id);

    CREATE TABLE #RawPunches
    (
        id int NOT NULL,
        emp_id int NOT NULL,
        emp_code nvarchar(20) NULL,
        work_date date NOT NULL,
        punch_time datetime2(7) NOT NULL,
        punch_state int NULL,
        norm_punch_state int NULL,
        CONSTRAINT PK_TempDailyTraceRawPunches PRIMARY KEY CLUSTERED (emp_id, work_date, punch_time, id)
    );

    INSERT INTO #RawPunches
    (
        id,
        emp_id,
        emp_code,
        work_date,
        punch_time,
        punch_state,
        norm_punch_state
    )
    SELECT
        t.id,
        t.emp_id,
        t.emp_code,
        @pAttDate,
        t.punch_time,
        TRY_CONVERT(int, t.punch_state),
        CASE
            WHEN t.punch_state IN ('0', '4') THEN 0
            WHEN t.punch_state IN ('1', '5') THEN 1
            ELSE TRY_CONVERT(int, t.punch_state)
        END
    FROM dbo.iclock_transaction t
    WHERE t.emp_id = @pEmpID
      AND t.punch_time >= DATEADD(HOUR, 3, CAST(@pAttDate AS datetime2(0)))
      AND t.punch_time < DATEADD(HOUR, 3, DATEADD(DAY, 1, CAST(@pAttDate AS datetime2(0))));

    CREATE TABLE #CleanedPunches
    (
        emp_id int NOT NULL,
        emp_code nvarchar(20) NULL,
        work_date date NOT NULL,
        id int NOT NULL,
        punch_time datetime2(7) NOT NULL,
        punch_state int NULL,
        norm_punch_state int NULL,
        burst_no int NOT NULL,
        burst_punch_count int NOT NULL,
        is_duplicate_burst int NOT NULL,
        CONSTRAINT PK_TempDailyTraceCleanedPunches PRIMARY KEY CLUSTERED (emp_id, work_date, punch_time, id)
    );

    ;WITH Ordered AS
    (
        SELECT
            p.*,
            LAG(p.punch_time) OVER
            (
                PARTITION BY p.emp_id, p.work_date, p.norm_punch_state
                ORDER BY p.punch_time, p.id
            ) AS prev_same_state_punch_time
        FROM #RawPunches p
    ),
    Marked AS
    (
        SELECT
            o.*,
            CASE
                WHEN o.prev_same_state_punch_time IS NULL THEN 1
                WHEN DATEDIFF(MINUTE, o.prev_same_state_punch_time, o.punch_time) > 5 THEN 1
                ELSE 0
            END AS is_new_burst
        FROM Ordered o
    ),
    Bursted AS
    (
        SELECT
            m.*,
            SUM(m.is_new_burst) OVER
            (
                PARTITION BY m.emp_id, m.work_date, m.norm_punch_state
                ORDER BY m.punch_time, m.id
                ROWS UNBOUNDED PRECEDING
            ) AS burst_no
        FROM Marked m
    ),
    Collapsed AS
    (
        SELECT
            emp_id,
            emp_code,
            work_date,
            norm_punch_state,
            burst_no,
            MIN(punch_time) AS punch_time,
            MIN(id) AS id,
            COUNT(*) AS burst_punch_count,
            MIN(punch_state) AS punch_state
        FROM Bursted
        GROUP BY
            emp_id,
            emp_code,
            work_date,
            norm_punch_state,
            burst_no
    )
    INSERT INTO #CleanedPunches
    (
        emp_id,
        emp_code,
        work_date,
        id,
        punch_time,
        punch_state,
        norm_punch_state,
        burst_no,
        burst_punch_count,
        is_duplicate_burst
    )
    SELECT
        c.emp_id,
        c.emp_code,
        c.work_date,
        c.id,
        c.punch_time,
        c.punch_state,
        c.norm_punch_state,
        c.burst_no,
        c.burst_punch_count,
        CASE WHEN c.burst_punch_count > 1 THEN 1 ELSE 0 END
    FROM Collapsed c;

    CREATE TABLE #WorkedIntervals
    (
        emp_id int NOT NULL,
        emp_code nvarchar(20) NULL,
        work_date date NOT NULL,
        in_segment_no int NOT NULL,
        out_segment_no int NOT NULL,
        in_time datetime2(7) NOT NULL,
        out_time datetime2(7) NOT NULL,
        worked_minutes int NOT NULL,
        worked_hours decimal(10,2) NOT NULL
    );

    ;WITH Numbered AS
    (
        SELECT
            cp.*,
            ROW_NUMBER() OVER
            (
                PARTITION BY cp.emp_id, cp.work_date, cp.norm_punch_state
                ORDER BY cp.punch_time, cp.id
            ) AS state_no
        FROM #CleanedPunches cp
        WHERE cp.norm_punch_state IN (0, 1)
    ),
    Ins AS
    (
        SELECT *
        FROM Numbered
        WHERE norm_punch_state = 0
    ),
    Outs AS
    (
        SELECT *
        FROM Numbered
        WHERE norm_punch_state = 1
    )
    INSERT INTO #WorkedIntervals
    (
        emp_id,
        emp_code,
        work_date,
        in_segment_no,
        out_segment_no,
        in_time,
        out_time,
        worked_minutes,
        worked_hours
    )
    SELECT
        i.emp_id,
        i.emp_code,
        i.work_date,
        i.state_no,
        o.state_no,
        i.punch_time,
        o.punch_time,
        DATEDIFF(MINUTE, i.punch_time, o.punch_time),
        CAST(DATEDIFF(SECOND, i.punch_time, o.punch_time) / 3600.0 AS decimal(10,2))
    FROM Ins i
    INNER JOIN Outs o
        ON o.emp_id = i.emp_id
       AND o.work_date = i.work_date
       AND o.state_no = i.state_no
       AND o.punch_time >= i.punch_time;

    PRINT 'START';

    PRINT '01_FactDailyAttendance';
    SELECT
        '01_FactDailyAttendance' AS step,
        f.*
    FROM #Fact f;

    PRINT '02_FocusedDailyPunchAudit';
    ;WITH PunchSlots AS
    (
        SELECT
            p.emp_id,
            p.work_date,
            COUNT(*) AS TotalPunches,
            MAX(CASE WHEN p.punch_no = 1 THEN CONVERT(varchar(8), CAST(p.punch_time AS time), 108) END) AS RawPunch1,
            MAX(CASE WHEN p.punch_no = 2 THEN CONVERT(varchar(8), CAST(p.punch_time AS time), 108) END) AS RawPunch2,
            MAX(CASE WHEN p.punch_no = 3 THEN CONVERT(varchar(8), CAST(p.punch_time AS time), 108) END) AS RawPunch3,
            MAX(CASE WHEN p.punch_no = 4 THEN CONVERT(varchar(8), CAST(p.punch_time AS time), 108) END) AS RawPunch4,
            MAX(CASE WHEN p.punch_no = 5 THEN CONVERT(varchar(8), CAST(p.punch_time AS time), 108) END) AS RawPunch5,
            MAX(CASE WHEN p.punch_no = 6 THEN CONVERT(varchar(8), CAST(p.punch_time AS time), 108) END) AS RawPunch6
        FROM
        (
            SELECT
                rp.*,
                ROW_NUMBER() OVER
                (
                    PARTITION BY rp.emp_id, rp.work_date
                    ORDER BY rp.punch_time, rp.id
                ) AS punch_no
            FROM #RawPunches rp
        ) p
        GROUP BY
            p.emp_id,
            p.work_date
    )
    SELECT
        '02_FocusedDailyPunchAudit' AS step,
        f.att_date AS [Date],
        f.emp_id,
        f.emp_code,
        f.employee_name,
        CONVERT(varchar(8), CAST(f.effective_punch_in1 AS time), 108) AS PunchIn1,
        CONVERT(varchar(8), CAST(f.effective_punch_out1 AS time), 108) AS PunchOut1,
        CONVERT(varchar(8), CAST(f.effective_punch_in2 AS time), 108) AS PunchIn2,
        CONVERT(varchar(8), CAST(f.effective_punch_out2 AS time), 108) AS PunchOut2,
        CONVERT(varchar(8), CAST(f.first_clock_in AS time), 108) AS FirstClockInUsed,
        CONVERT(varchar(8), CAST(f.last_clock_out AS time), 108) AS LastClockOutUsed,
        ISNULL(ps.TotalPunches, 0) AS TotalPunches,
        ps.RawPunch1,
        ps.RawPunch2,
        ps.RawPunch3,
        ps.RawPunch4,
        ps.RawPunch5,
        ps.RawPunch6,
        CASE
            WHEN ISNULL(ps.TotalPunches, 0) = 1 THEN 'Only One Punch'
            WHEN ISNULL(ps.TotalPunches, 0) = 3 THEN 'Three Punches / One Missing'
            WHEN ISNULL(ps.TotalPunches, 0) = 5 THEN 'Five Punches / Unpaired'
            WHEN ISNULL(ps.TotalPunches, 0) % 2 = 1 THEN 'Odd Number of Punches'
            ELSE 'OK'
        END AS PunchExceptionType,
        raw_lists.AllRawPunches,
        effective_lists.AllEffectivePunches,
        rs.effective_shift_alias AS EffectiveShiftAlias,
        rs.effective_time_interval_alias AS EffectiveTimeTableAlias,
        rs.effective_schedule_source AS ScheduleType,
        CASE
            WHEN ISNULL(f.recomputed_worked_minutes, 0) > 0 THEN 'OK'
            WHEN f.first_clock_in IS NULL AND f.last_clock_out IS NULL THEN 'NoPunch'
            WHEN f.first_clock_in IS NOT NULL AND f.last_clock_out IS NULL THEN 'MissingOut'
            WHEN f.first_clock_in IS NULL AND f.last_clock_out IS NOT NULL THEN 'MissingIn'
            ELSE 'OK'
        END AS DerivedPunchStatus,
        f.attendance_status AS AttendanceStatus,
        f.anomaly_flag AS AnomalyFlag,
        f.reconciliation_status AS ReconciliationStatus
    FROM #Fact f
    LEFT JOIN PunchSlots ps
        ON ps.emp_id = f.emp_id
       AND ps.work_date = f.att_date
    LEFT JOIN #ResolvedSchedule rs
        ON rs.emp_id = f.emp_id
       AND rs.att_date = f.att_date
    OUTER APPLY
    (
        SELECT
            STUFF(
                (
                    SELECT
                        ',' + CONVERT(varchar(8), CAST(rp.punch_time AS time), 108)
                        + '('
                        + CASE
                            WHEN rp.norm_punch_state = 0 THEN 'IN'
                            WHEN rp.norm_punch_state = 1 THEN 'OUT'
                            ELSE CONVERT(varchar(10), rp.punch_state)
                          END
                        + ')'
                    FROM #RawPunches rp
                    WHERE rp.emp_id = f.emp_id
                      AND rp.work_date = f.att_date
                    ORDER BY
                        rp.punch_time,
                        rp.id
                    FOR XML PATH('')
                ),
                1,
                1,
                ''
            ) AS AllRawPunches
    ) raw_lists
    OUTER APPLY
    (
        SELECT
            STUFF(
                (
                    SELECT
                        ',' + CONVERT(varchar(8), CAST(v.punch_datetime AS time), 108)
                        + '(' + v.punch_label + ')'
                    FROM
                    (
                        VALUES
                            (1, f.effective_punch_in1, 'IN'),
                            (2, f.effective_punch_out1, 'OUT'),
                            (3, f.effective_punch_in2, 'IN'),
                            (4, f.effective_punch_out2, 'OUT')
                    ) v(sort_no, punch_datetime, punch_label)
                    WHERE v.punch_datetime IS NOT NULL
                    ORDER BY
                        v.sort_no
                    FOR XML PATH('')
                ),
                1,
                1,
                ''
            ) AS AllEffectivePunches
    ) effective_lists;

    PRINT '03_FocusedDailySchedulePunchAudit';
    SELECT
        '03_FocusedDailySchedulePunchAudit' AS step,
        f.att_date AS [Date],
        f.emp_id,
        f.emp_code,
        f.emp_code_name,
        rs.effective_time_interval_alias AS EffectiveScheduleAlias,
        CONVERT(varchar(8), CAST(rs.effective_scheduled_in_datetime AS time), 108) AS ScheduledIn,
        CONVERT(varchar(8), CAST(rs.effective_scheduled_out_datetime AS time), 108) AS ScheduledOut,
        CONVERT(varchar(8), CAST(f.effective_punch_in1 AS time), 108) AS EffectivePunchIn1,
        CONVERT(varchar(8), CAST(f.effective_punch_out1 AS time), 108) AS EffectivePunchOut1,
        CONVERT(varchar(8), CAST(f.effective_punch_in2 AS time), 108) AS EffectivePunchIn2,
        CONVERT(varchar(8), CAST(f.effective_punch_out2 AS time), 108) AS EffectivePunchOut2,
        raw_lists.AllPunches,
        DATEDIFF(MINUTE, rs.effective_scheduled_in_datetime, f.effective_punch_in1) AS InOffsetMinutes,
        DATEDIFF(MINUTE, rs.effective_scheduled_out_datetime, COALESCE(f.effective_punch_out2, f.effective_punch_out1)) AS OutOffsetMinutes,
        CASE
            WHEN rs.effective_time_interval_id IS NULL THEN 'MissingSchedule'
            WHEN f.effective_punch_in1 IS NULL AND f.effective_punch_out1 IS NULL THEN 'NoEffectivePunches'
            WHEN f.effective_punch_in1 IS NULL THEN 'MissingEffectiveIn'
            WHEN COALESCE(f.effective_punch_out2, f.effective_punch_out1) IS NULL THEN 'MissingEffectiveOut'
            WHEN rs.effective_scheduled_in_datetime IS NOT NULL
             AND rs.effective_scheduled_out_datetime IS NOT NULL
             AND f.effective_punch_in1 IS NOT NULL
             AND COALESCE(f.effective_punch_out2, f.effective_punch_out1) IS NOT NULL
             AND DATEDIFF(MINUTE, rs.effective_scheduled_in_datetime, f.effective_punch_in1) <= -60
             AND DATEDIFF(MINUTE, rs.effective_scheduled_out_datetime, COALESCE(f.effective_punch_out2, f.effective_punch_out1)) <= -60
            THEN 'LikelyEarlierSchedule'
            WHEN rs.effective_scheduled_in_datetime IS NOT NULL
             AND rs.effective_scheduled_out_datetime IS NOT NULL
             AND f.effective_punch_in1 IS NOT NULL
             AND COALESCE(f.effective_punch_out2, f.effective_punch_out1) IS NOT NULL
             AND DATEDIFF(MINUTE, rs.effective_scheduled_in_datetime, f.effective_punch_in1) >= 60
             AND DATEDIFF(MINUTE, rs.effective_scheduled_out_datetime, COALESCE(f.effective_punch_out2, f.effective_punch_out1)) >= 60
            THEN 'LikelyLaterSchedule'
            WHEN rs.effective_scheduled_in_datetime IS NOT NULL
             AND f.effective_punch_in1 IS NOT NULL
             AND ABS(DATEDIFF(MINUTE, rs.effective_scheduled_in_datetime, f.effective_punch_in1)) >= 120
            THEN 'PunchInFarFromSchedule'
            WHEN rs.effective_scheduled_out_datetime IS NOT NULL
             AND COALESCE(f.effective_punch_out2, f.effective_punch_out1) IS NOT NULL
             AND ABS(DATEDIFF(MINUTE, rs.effective_scheduled_out_datetime, COALESCE(f.effective_punch_out2, f.effective_punch_out1))) >= 120
            THEN 'PunchOutFarFromSchedule'
            ELSE 'OK'
        END AS SchedulePunchCheck,
        f.required_scheduled_hours AS RequiredScheduledHours,
        f.worked_hours AS WorkedHours,
        f.attendance_status AS AttendanceStatus,
        f.anomaly_flag AS AnomalyFlag,
        f.needs_payroll_review AS NeedsPayrollReview,
        rs.effective_schedule_source AS EffectiveScheduleSource
    FROM #Fact f
    LEFT JOIN #ResolvedSchedule rs
        ON rs.emp_id = f.emp_id
       AND rs.att_date = f.att_date
    OUTER APPLY
    (
        SELECT
            STUFF(
                (
                    SELECT
                        ',' + CONVERT(varchar(8), CAST(rp.punch_time AS time), 108)
                        + '('
                        + CASE
                            WHEN rp.norm_punch_state = 0 THEN 'IN'
                            WHEN rp.norm_punch_state = 1 THEN 'OUT'
                            ELSE CONVERT(varchar(10), rp.punch_state)
                          END
                        + ')'
                    FROM #RawPunches rp
                    WHERE rp.emp_id = f.emp_id
                      AND rp.work_date = f.att_date
                    ORDER BY
                        rp.punch_time,
                        rp.id
                    FOR XML PATH('')
                ),
                1,
                1,
                ''
            ) AS AllPunches
    ) raw_lists;

    PRINT '04_FocusedEffectiveScheduleResolved';
    SELECT
        '04_FocusedEffectiveScheduleResolved' AS step,
        rs.*
    FROM #ResolvedSchedule rs;

    PRINT '05_RawPunches';
    SELECT
        '05_RawPunches' AS step,
        rp.*
    FROM #RawPunches rp
    ORDER BY
        rp.punch_time,
        rp.id;

    PRINT '06_CleanedPunches';
    SELECT
        '06_CleanedPunches' AS step,
        cp.*
    FROM #CleanedPunches cp
    ORDER BY
        cp.punch_time,
        cp.id;

    PRINT '07_PunchSegments';
    SELECT
        '07_PunchSegments' AS step,
        cp.emp_id,
        cp.emp_code,
        cp.work_date,
        DENSE_RANK() OVER
        (
            PARTITION BY cp.emp_id, cp.work_date
            ORDER BY cp.burst_no
        ) AS segment_no,
        cp.id,
        cp.punch_time,
        cp.burst_no,
        cp.burst_punch_count,
        cp.is_duplicate_burst
    FROM #CleanedPunches cp
    ORDER BY
        segment_no,
        cp.punch_time,
        cp.id;

    PRINT '08_WorkedIntervals';
    SELECT
        '08_WorkedIntervals' AS step,
        wi.*
    FROM #WorkedIntervals wi
    ORDER BY
        wi.in_segment_no,
        wi.in_time;

    PRINT '09_DailyWorkedMinutes';
    SELECT
        '09_DailyWorkedMinutes' AS step,
        wi.emp_id,
        wi.emp_code,
        wi.work_date,
        COUNT(*) AS worked_interval_count,
        MIN(wi.in_time) AS first_clock_in,
        MAX(wi.out_time) AS last_clock_out,
        SUM(wi.worked_minutes) AS total_worked_minutes,
        CAST(SUM(wi.worked_minutes) / 60.0 AS decimal(10,2)) AS total_worked_hours
    FROM #WorkedIntervals wi
    GROUP BY
        wi.emp_id,
        wi.emp_code,
        wi.work_date;

    IF @IncludeAccuracyIssues = 1
    BEGIN
        PRINT '10_AttendanceAccuracyIssues';
        CREATE TABLE #Issues
        (
            emp_id int NULL,
            emp_code nvarchar(50) NULL,
            employee_name nvarchar(200) NULL,
            department_id int NULL,
            dept_code nvarchar(50) NULL,
            dept_name nvarchar(100) NULL,
            group_id int NULL,
            group_code nvarchar(50) NULL,
            group_name nvarchar(100) NULL,
            att_date date NULL,
            issue_area varchar(30) NULL,
            issue_code varchar(60) NULL,
            severity varchar(20) NULL,
            issue_message varchar(250) NULL,
            expected_value varchar(100) NULL,
            actual_value varchar(100) NULL,
            needs_payroll_block bit NULL
        );

        INSERT INTO #Issues
        EXEC dbo.custom_att_GetAttendanceAccuracyIssues
            @DateFrom = @pAttDate,
            @DateTo = @pAttDate,
            @EmpID = @pEmpID,
            @IncludeDeepChecks = 0;

        SELECT
            '10_AttendanceAccuracyIssues' AS step,
            i.*
        FROM #Issues i
        ORDER BY
            CASE i.severity
                WHEN 'Critical' THEN 1
                WHEN 'High' THEN 2
                WHEN 'Medium' THEN 3
                ELSE 4
            END,
            i.issue_area,
            i.issue_code;
    END;

    IF @IncludeMonthlySummary = 1
    BEGIN
        PRINT '11_MonthlyFactSummaryScoped';
        SELECT
            '11_MonthlyFactSummaryScoped' AS step,
            f.emp_id,
            f.emp_code,
            YEAR(@pAttDate) AS year_no,
            MONTH(@pAttDate) AS month_no,
            COUNT(*) AS fact_calendar_days,
            SUM(CASE WHEN ISNULL(f.required_scheduled_hours, 0) > 0 THEN 1 ELSE 0 END) AS required_work_days,
            SUM(CASE WHEN f.attendance_status IN ('Present', 'Partial') THEN 1 ELSE 0 END) AS present_or_partial_days,
            SUM(CASE WHEN f.attendance_status = 'Absent' THEN 1 ELSE 0 END) AS absent_days,
            SUM(CASE WHEN ISNULL(f.needs_payroll_review, 0) = 1 THEN 1 ELSE 0 END) AS payroll_review_days,
            SUM(CASE WHEN ISNULL(f.anomaly_flag, 'Normal') <> 'Normal' THEN 1 ELSE 0 END) AS anomaly_days,
            SUM(CASE WHEN ISNULL(f.punch_status, 'OK') <> 'OK' THEN 1 ELSE 0 END) AS punch_issue_days,
            CAST(SUM(ISNULL(f.recomputed_worked_minutes, 0)) / 60.0 AS decimal(10,2)) AS recomputed_worked_hours,
            CAST(SUM(ISNULL(f.worked_hours, 0)) AS decimal(10,2)) AS worked_hours,
            CAST(SUM(ISNULL(f.regular_worked_hours, 0)) AS decimal(10,2)) AS regular_worked_hours,
            CAST(SUM(ISNULL(f.ot_hours, 0)) AS decimal(10,2)) AS ot_hours,
            CAST(SUM(ISNULL(f.recomputed_absence_hours, 0)) AS decimal(10,2)) AS absence_hours,
            SUM(ISNULL(f.late_minutes, 0)) AS late_minutes,
            SUM(ISNULL(f.early_out_minutes, 0)) AS early_out_minutes
        FROM dbo.custom_att_fact_DailyAttendance f
        WHERE f.emp_id = @pEmpID
          AND f.att_date BETWEEN @MonthStart AND @MonthEnd
        GROUP BY
            f.emp_id,
            f.emp_code
        OPTION (RECOMPILE);
    END;

    PRINT 'END';
END;

GO
