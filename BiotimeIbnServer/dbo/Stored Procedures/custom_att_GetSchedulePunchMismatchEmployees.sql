CREATE PROCEDURE [dbo].[custom_att_GetSchedulePunchMismatchEmployees]
    @DateFrom date = NULL,
    @DateTo date = NULL,
    @EmpID int = NULL,
    @DepartmentID int = NULL,
    @GroupID int = NULL,
    @OffsetThresholdMinutes int = 120,
    @ShiftedWindowThresholdMinutes int = 60,
    @MinimumMismatchDays int = 1,
    @IncludeFlexibleSchedules bit = 0,
    @ResultMode varchar(20) = 'Full'
AS
BEGIN
    SET NOCOUNT ON;

    IF @DateFrom IS NULL AND @DateTo IS NULL
    BEGIN
        SET @DateFrom = CAST(GETDATE() AS date);
        SET @DateTo = @DateFrom;
    END;

    IF @DateFrom IS NULL
        SET @DateFrom = @DateTo;

    IF @DateTo IS NULL
        SET @DateTo = @DateFrom;

    IF @DateFrom > @DateTo
    BEGIN
        DECLARE @SwapDate date = @DateFrom;
        SET @DateFrom = @DateTo;
        SET @DateTo = @SwapDate;
    END;

    IF @OffsetThresholdMinutes IS NULL OR @OffsetThresholdMinutes < 1
        SET @OffsetThresholdMinutes = 120;

    IF @ShiftedWindowThresholdMinutes IS NULL OR @ShiftedWindowThresholdMinutes < 1
        SET @ShiftedWindowThresholdMinutes = 60;

    IF @MinimumMismatchDays IS NULL OR @MinimumMismatchDays < 1
        SET @MinimumMismatchDays = 1;

    CREATE TABLE #Facts
    (
        emp_id int NOT NULL,
        emp_code nvarchar(20) NOT NULL,
        employee_name nvarchar(200) NULL,
        department_id int NULL,
        dept_code nvarchar(50) NULL,
        dept_name nvarchar(200) NULL,
        group_id int NULL,
        group_code nvarchar(50) NULL,
        group_name nvarchar(100) NULL,
        att_date date NOT NULL,
        effective_punch_in1 datetime2(7) NULL,
        effective_punch_out1 datetime2(7) NULL,
        effective_punch_in2 datetime2(7) NULL,
        effective_punch_out2 datetime2(7) NULL,
        required_scheduled_hours decimal(10,2) NULL,
        worked_hours decimal(10,2) NULL,
        recomputed_worked_minutes decimal(10,2) NULL,
        attendance_status varchar(50) NULL,
        anomaly_flag varchar(100) NULL,
        needs_payroll_review bit NULL,
        reconciliation_status varchar(50) NULL,
        CONSTRAINT PK_TempSchedulePunchMismatchFacts PRIMARY KEY CLUSTERED (emp_id, att_date)
    );

    INSERT INTO #Facts
    (
        emp_id,
        emp_code,
        employee_name,
        department_id,
        dept_code,
        dept_name,
        group_id,
        group_code,
        group_name,
        att_date,
        effective_punch_in1,
        effective_punch_out1,
        effective_punch_in2,
        effective_punch_out2,
        required_scheduled_hours,
        worked_hours,
        recomputed_worked_minutes,
        attendance_status,
        anomaly_flag,
        needs_payroll_review,
        reconciliation_status
    )
    SELECT
        f.emp_id,
        f.emp_code,
        LTRIM(RTRIM(ISNULL(e.first_name, '') + ' ' + ISNULL(e.last_name, ''))) AS employee_name,
        e.department_id,
        d.dept_code,
        d.dept_name,
        ae.group_id,
        ag.code AS group_code,
        ag.name AS group_name,
        f.att_date,
        f.effective_punch_in1,
        f.effective_punch_out1,
        f.effective_punch_in2,
        f.effective_punch_out2,
        f.required_scheduled_hours,
        f.worked_hours,
        f.recomputed_worked_minutes,
        f.attendance_status,
        f.anomaly_flag,
        f.needs_payroll_review,
        f.reconciliation_status
    FROM dbo.custom_att_fact_DailyAttendance f
    LEFT JOIN dbo.personnel_employee e
        ON e.id = f.emp_id
    LEFT JOIN dbo.personnel_department d
        ON d.id = e.department_id
    LEFT JOIN dbo.att_attemployee ae
        ON ae.emp_id = f.emp_id
    LEFT JOIN dbo.att_attgroup ag
        ON ag.id = ae.group_id
    WHERE f.att_date BETWEEN @DateFrom AND @DateTo
      AND (@EmpID IS NULL OR f.emp_id = @EmpID)
      AND (@DepartmentID IS NULL OR e.department_id = @DepartmentID)
      AND (@GroupID IS NULL OR ae.group_id = @GroupID)
      AND NOT EXISTS
      (
          SELECT 1
          FROM dbo.personnel_resign r
          WHERE r.employee_id = f.emp_id
            AND f.att_date > r.resign_date
    )
    OPTION (RECOMPILE);

    CREATE NONCLUSTERED INDEX IX_TempSchedulePunchMismatchFacts_GroupDate
        ON #Facts (group_id, att_date)
        INCLUDE (emp_id)
        WHERE group_id IS NOT NULL;

    CREATE NONCLUSTERED INDEX IX_TempSchedulePunchMismatchFacts_DepartmentDate
        ON #Facts (department_id, att_date)
        INCLUDE (emp_id)
        WHERE department_id IS NOT NULL;

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
    WHERE ts.status = 0
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
    WHERE gs.status = 0
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
    WHERE ds.status = 0
      AND ds.shift_id IS NOT NULL;

    CREATE CLUSTERED INDEX IX_TempSchedulePunchMismatchCandidates
        ON #ScheduleCandidates (emp_id, att_date, source_priority, source_row_id DESC);

    CREATE TABLE #ResolvedSchedule
    (
        emp_id int NOT NULL,
        att_date date NOT NULL,
        effective_schedule_source varchar(30) NULL,
        effective_time_interval_id int NULL,
        effective_scheduled_in_datetime datetime NULL,
        effective_scheduled_out_datetime datetime NULL,
        effective_schedule_alias nvarchar(50) NULL,
        schedule_use_mode int NULL,
        CONSTRAINT PK_TempSchedulePunchMismatchResolved PRIMARY KEY CLUSTERED (emp_id, att_date)
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
        effective_schedule_alias,
        schedule_use_mode
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
        ti.alias,
        ti.use_mode
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

    CREATE TABLE #DailyFindings
    (
        emp_id int NOT NULL,
        emp_code nvarchar(20) NOT NULL,
        employee_name nvarchar(200) NULL,
        department_id int NULL,
        dept_code nvarchar(50) NULL,
        dept_name nvarchar(200) NULL,
        group_id int NULL,
        group_code nvarchar(50) NULL,
        group_name nvarchar(100) NULL,
        att_date date NOT NULL,
        effective_schedule_source varchar(30) NULL,
        effective_schedule_alias nvarchar(50) NULL,
        effective_scheduled_in_datetime datetime NULL,
        effective_scheduled_out_datetime datetime NULL,
        effective_punch_in1 datetime2(7) NULL,
        effective_punch_out1 datetime2(7) NULL,
        effective_punch_in2 datetime2(7) NULL,
        effective_punch_out2 datetime2(7) NULL,
        first_clock_in datetime2(7) NULL,
        last_clock_out datetime2(7) NULL,
        in_offset_minutes int NULL,
        out_offset_minutes int NULL,
        audit_reason varchar(60) NOT NULL,
        severity varchar(20) NOT NULL,
        severity_rank int NOT NULL,
        required_scheduled_hours decimal(10,2) NULL,
        worked_hours decimal(10,2) NULL,
        recomputed_worked_minutes decimal(10,2) NULL,
        attendance_status varchar(50) NULL,
        anomaly_flag varchar(100) NULL,
        needs_payroll_review bit NULL,
        reconciliation_status varchar(50) NULL,
        CONSTRAINT PK_TempSchedulePunchMismatchFindings PRIMARY KEY CLUSTERED (emp_id, att_date)
    );

    ;WITH CandidateRows AS
    (
        SELECT
            f.emp_id,
            f.emp_code,
            f.employee_name,
            f.department_id,
            f.dept_code,
            f.dept_name,
            f.group_id,
            f.group_code,
            f.group_name,
            f.att_date,
            rs.effective_schedule_source,
            rs.effective_schedule_alias,
            rs.effective_scheduled_in_datetime,
            rs.effective_scheduled_out_datetime,
            f.effective_punch_in1,
            f.effective_punch_out1,
            f.effective_punch_in2,
            f.effective_punch_out2,
            f.effective_punch_in1 AS first_clock_in,
            COALESCE(f.effective_punch_out2, f.effective_punch_out1) AS last_clock_out,
            DATEDIFF(MINUTE, rs.effective_scheduled_in_datetime, f.effective_punch_in1) AS in_offset_minutes,
            DATEDIFF(
                MINUTE,
                rs.effective_scheduled_out_datetime,
                COALESCE(f.effective_punch_out2, f.effective_punch_out1)
            ) AS out_offset_minutes,
            f.required_scheduled_hours,
            f.worked_hours,
            f.recomputed_worked_minutes,
            f.attendance_status,
            f.anomaly_flag,
            f.needs_payroll_review,
            f.reconciliation_status
        FROM #Facts f
        LEFT JOIN #ResolvedSchedule rs
            ON rs.emp_id = f.emp_id
           AND rs.att_date = f.att_date
        WHERE
            (
                @IncludeFlexibleSchedules = 1
                OR ISNULL(rs.effective_schedule_alias, '') NOT LIKE '%Flex%'
            )
          AND ISNULL(rs.schedule_use_mode, 0) <> 1
    ),
    MarkedRows AS
    (
        SELECT
            cr.*,
            CASE
                WHEN cr.effective_scheduled_in_datetime IS NULL
                  OR cr.effective_scheduled_out_datetime IS NULL
                THEN 'MissingSchedule'

                WHEN cr.effective_punch_in1 IS NULL
                 AND cr.effective_punch_out1 IS NULL
                 AND cr.effective_punch_in2 IS NULL
                 AND cr.effective_punch_out2 IS NULL
                THEN 'NoEffectivePunches'

                WHEN cr.effective_punch_in1 IS NULL
                THEN 'MissingEffectiveIn'

                WHEN cr.last_clock_out IS NULL
                THEN 'MissingEffectiveOut'

                WHEN cr.in_offset_minutes <= -@ShiftedWindowThresholdMinutes
                 AND cr.out_offset_minutes <= -@ShiftedWindowThresholdMinutes
                THEN 'LikelyEarlierSchedule'

                WHEN cr.in_offset_minutes >= @ShiftedWindowThresholdMinutes
                 AND cr.out_offset_minutes >= @ShiftedWindowThresholdMinutes
                THEN 'LikelyLaterSchedule'

                WHEN ABS(ISNULL(cr.in_offset_minutes, 0)) >= @OffsetThresholdMinutes
                 AND ABS(ISNULL(cr.out_offset_minutes, 0)) >= @OffsetThresholdMinutes
                THEN 'BothPunchesFarFromSchedule'

                WHEN ABS(ISNULL(cr.in_offset_minutes, 0)) >= @OffsetThresholdMinutes
                THEN 'PunchInFarFromSchedule'

                WHEN ABS(ISNULL(cr.out_offset_minutes, 0)) >= @OffsetThresholdMinutes
                THEN 'PunchOutFarFromSchedule'

                ELSE 'OK'
            END AS audit_reason,
            CASE
                WHEN ABS(ISNULL(cr.in_offset_minutes, 0)) >= 180
                  OR ABS(ISNULL(cr.out_offset_minutes, 0)) >= 180
                  OR cr.effective_punch_in1 IS NULL
                  OR cr.last_clock_out IS NULL
                  OR cr.effective_scheduled_in_datetime IS NULL
                  OR cr.effective_scheduled_out_datetime IS NULL
                THEN 'High'
                ELSE 'Medium'
            END AS severity,
            CASE
                WHEN ABS(ISNULL(cr.in_offset_minutes, 0)) >= 180
                  OR ABS(ISNULL(cr.out_offset_minutes, 0)) >= 180
                  OR cr.effective_punch_in1 IS NULL
                  OR cr.last_clock_out IS NULL
                  OR cr.effective_scheduled_in_datetime IS NULL
                  OR cr.effective_scheduled_out_datetime IS NULL
                THEN 1
                ELSE 2
            END AS severity_rank
        FROM CandidateRows cr
    )
    INSERT INTO #DailyFindings
    SELECT
        mr.emp_id,
        mr.emp_code,
        mr.employee_name,
        mr.department_id,
        mr.dept_code,
        mr.dept_name,
        mr.group_id,
        mr.group_code,
        mr.group_name,
        mr.att_date,
        mr.effective_schedule_source,
        mr.effective_schedule_alias,
        mr.effective_scheduled_in_datetime,
        mr.effective_scheduled_out_datetime,
        mr.effective_punch_in1,
        mr.effective_punch_out1,
        mr.effective_punch_in2,
        mr.effective_punch_out2,
        mr.first_clock_in,
        mr.last_clock_out,
        mr.in_offset_minutes,
        mr.out_offset_minutes,
        mr.audit_reason,
        mr.severity,
        mr.severity_rank,
        mr.required_scheduled_hours,
        mr.worked_hours,
        mr.recomputed_worked_minutes,
        mr.attendance_status,
        mr.anomaly_flag,
        mr.needs_payroll_review,
        mr.reconciliation_status
    FROM MarkedRows mr
    WHERE mr.audit_reason <> 'OK'
      AND NOT
      (
          mr.attendance_status = 'On Leave'
          AND ISNULL(mr.needs_payroll_review, 0) = 0
          AND ISNULL(mr.reconciliation_status, '') = 'Balanced'
          AND ISNULL(mr.anomaly_flag, 'Normal') = 'Normal'
      );

    CREATE TABLE #EmployeeMismatchCounts
    (
        emp_id int NOT NULL PRIMARY KEY,
        mismatch_days int NOT NULL,
        employee_worst_in_offset_minutes int NOT NULL,
        employee_worst_out_offset_minutes int NOT NULL
    );

    INSERT INTO #EmployeeMismatchCounts
    SELECT
        df.emp_id,
        COUNT(*) AS mismatch_days,
        MAX(ABS(ISNULL(df.in_offset_minutes, 0))) AS employee_worst_in_offset_minutes,
        MAX(ABS(ISNULL(df.out_offset_minutes, 0))) AS employee_worst_out_offset_minutes
    FROM #DailyFindings df
    GROUP BY df.emp_id
    HAVING COUNT(*) >= @MinimumMismatchDays;

    SELECT
        df.*,
        emc.mismatch_days AS employee_mismatch_days_in_period,
        emc.employee_worst_in_offset_minutes,
        emc.employee_worst_out_offset_minutes
    INTO #ResultFindings
    FROM #DailyFindings df
    INNER JOIN #EmployeeMismatchCounts emc
        ON emc.emp_id = df.emp_id;

    CREATE CLUSTERED INDEX IX_TempSchedulePunchMismatchResult
        ON #ResultFindings (emp_id, att_date);

    CREATE TABLE #RawPunchRows
    (
        emp_id int NOT NULL,
        att_date date NOT NULL,
        punch_time datetime2(7) NOT NULL,
        id int NOT NULL,
        punch_state nvarchar(5) NOT NULL,
        CONSTRAINT PK_TempSchedulePunchMismatchRawPunchRows PRIMARY KEY CLUSTERED (emp_id, att_date, punch_time, id)
    );

    INSERT INTO #RawPunchRows
    SELECT
        rf.emp_id,
        rf.att_date,
        t.punch_time,
        t.id,
        t.punch_state
    FROM #ResultFindings rf
    INNER JOIN dbo.iclock_transaction t
        ON t.emp_id = rf.emp_id
       AND t.punch_time >= DATEADD(HOUR, 3, CAST(rf.att_date AS datetime2(7)))
       AND t.punch_time < DATEADD(HOUR, 3, DATEADD(DAY, 1, CAST(rf.att_date AS datetime2(7))))
    OPTION (RECOMPILE);

    CREATE TABLE #RawPunchLists
    (
        emp_id int NOT NULL,
        att_date date NOT NULL,
        raw_punches nvarchar(max) NULL,
        CONSTRAINT PK_TempSchedulePunchMismatchRawPunchLists PRIMARY KEY CLUSTERED (emp_id, att_date)
    );

    INSERT INTO #RawPunchLists
    SELECT
        rf.emp_id,
        rf.att_date,
        STUFF(
            (
                SELECT
                    ',' + CONVERT(varchar(8), CAST(rpr.punch_time AS time), 108)
                    + '('
                    + CASE
                        WHEN rpr.punch_state IN (N'0', N'4') THEN 'IN'
                        WHEN rpr.punch_state IN (N'1', N'5') THEN 'OUT'
                        ELSE CONVERT(varchar(10), rpr.punch_state)
                      END
                    + ')'
                FROM #RawPunchRows rpr
                WHERE rpr.emp_id = rf.emp_id
                  AND rpr.att_date = rf.att_date
                ORDER BY
                    rpr.punch_time,
                    rpr.id
                FOR XML PATH(''), TYPE
            ).value('.', 'nvarchar(max)'),
            1,
            1,
            ''
        ) AS raw_punches
    FROM #ResultFindings rf;

    IF UPPER(ISNULL(@ResultMode, 'Full')) = 'SIMPLE'
    BEGIN
        SELECT
            rf.att_date,
            rf.emp_id,
            rf.emp_code,
            rf.employee_name AS Employee_name,
            rf.effective_schedule_alias,
            CONVERT(varchar(8), CAST(rf.effective_punch_in1 AS time), 108) AS effective_punch_in1_time,
            CONVERT(varchar(8), CAST(rf.effective_punch_out1 AS time), 108) AS effective_punch_out1_time,
            CONVERT(varchar(8), CAST(rf.effective_punch_in2 AS time), 108) AS effective_punch_in2_time,
            CONVERT(varchar(8), CAST(rf.effective_punch_out2 AS time), 108) AS effective_punch_out2,
            rpl.raw_punches
        FROM #ResultFindings rf
        LEFT JOIN #RawPunchLists rpl
            ON rpl.emp_id = rf.emp_id
           AND rpl.att_date = rf.att_date
        ORDER BY
            rf.employee_name,
            rf.att_date,
            rf.emp_code,
            rf.emp_id;

        RETURN;
    END;

    CREATE TABLE #CorrectedPunchRows
    (
        emp_id int NOT NULL,
        work_date date NOT NULL,
        punch_time datetime2(7) NOT NULL,
        id int NOT NULL,
        corrected_punch_state int NOT NULL,
        corrected_punch_flag int NOT NULL,
        CONSTRAINT PK_TempSchedulePunchMismatchCorrectedPunchRows PRIMARY KEY CLUSTERED (emp_id, work_date, punch_time, id)
    );

    INSERT INTO #CorrectedPunchRows
    SELECT
        cp.emp_id,
        cp.work_date,
        cp.punch_time,
        cp.id,
        cp.corrected_punch_state,
        cp.corrected_punch_flag
    FROM dbo.custom_att_fnd_CorrectedPunches cp
    INNER JOIN #ResultFindings rf
        ON rf.emp_id = cp.emp_id
       AND rf.att_date = cp.work_date
    OPTION (RECOMPILE);

    CREATE TABLE #CorrectedPunchLists
    (
        emp_id int NOT NULL,
        att_date date NOT NULL,
        corrected_punches nvarchar(max) NULL,
        CONSTRAINT PK_TempSchedulePunchMismatchCorrectedPunchLists PRIMARY KEY CLUSTERED (emp_id, att_date)
    );

    INSERT INTO #CorrectedPunchLists
    SELECT
        rf.emp_id,
        rf.att_date,
        STUFF(
            (
                SELECT
                    ',' + CONVERT(varchar(8), CAST(cpr.punch_time AS time), 108)
                    + '('
                    + CASE
                        WHEN cpr.corrected_punch_state = 0 THEN 'IN'
                        WHEN cpr.corrected_punch_state = 1 THEN 'OUT'
                        ELSE CONVERT(varchar(10), cpr.corrected_punch_state)
                      END
                    + CASE WHEN ISNULL(cpr.corrected_punch_flag, 0) = 1 THEN '*' ELSE '' END
                    + ')'
                FROM #CorrectedPunchRows cpr
                WHERE cpr.emp_id = rf.emp_id
                  AND cpr.work_date = rf.att_date
                ORDER BY
                    cpr.punch_time,
                    cpr.id
                FOR XML PATH(''), TYPE
            ).value('.', 'nvarchar(max)'),
            1,
            1,
            ''
        ) AS corrected_punches
    FROM #ResultFindings rf;

    SELECT
        rf.att_date,
        rf.emp_id,
        rf.emp_code,
        rf.employee_name,
        rf.department_id,
        rf.dept_code,
        rf.dept_name,
        rf.group_id,
        rf.group_code,
        rf.group_name,
        rf.severity,
        rf.audit_reason,
        rf.effective_schedule_source,
        rf.effective_schedule_alias,
        rf.effective_scheduled_in_datetime,
        rf.effective_scheduled_out_datetime,
        CONVERT(varchar(8), CAST(rf.effective_scheduled_in_datetime AS time), 108) AS scheduled_in,
        CONVERT(varchar(8), CAST(rf.effective_scheduled_out_datetime AS time), 108) AS scheduled_out,
        rf.effective_punch_in1,
        rf.effective_punch_out1,
        rf.effective_punch_in2,
        rf.effective_punch_out2,
        CONVERT(varchar(8), CAST(rf.effective_punch_in1 AS time), 108) AS effective_punch_in1_time,
        CONVERT(varchar(8), CAST(rf.effective_punch_out1 AS time), 108) AS effective_punch_out1_time,
        CONVERT(varchar(8), CAST(rf.effective_punch_in2 AS time), 108) AS effective_punch_in2_time,
        CONVERT(varchar(8), CAST(rf.effective_punch_out2 AS time), 108) AS effective_punch_out2_time,
        rf.first_clock_in,
        rf.last_clock_out,
        CONVERT(varchar(8), CAST(rf.first_clock_in AS time), 108) AS actual_first_clock_in,
        CONVERT(varchar(8), CAST(rf.last_clock_out AS time), 108) AS actual_last_clock_out,
        rf.in_offset_minutes,
        rf.out_offset_minutes,
        ABS(ISNULL(rf.in_offset_minutes, 0)) AS abs_in_offset_minutes,
        ABS(ISNULL(rf.out_offset_minutes, 0)) AS abs_out_offset_minutes,
        rpl.raw_punches,
        cpl.corrected_punches,
        rf.required_scheduled_hours,
        rf.worked_hours,
        rf.recomputed_worked_minutes,
        rf.attendance_status,
        rf.anomaly_flag,
        rf.needs_payroll_review,
        rf.reconciliation_status,
        rf.employee_mismatch_days_in_period,
        rf.employee_worst_in_offset_minutes,
        rf.employee_worst_out_offset_minutes
    FROM #ResultFindings rf
    LEFT JOIN #RawPunchLists rpl
        ON rpl.emp_id = rf.emp_id
       AND rpl.att_date = rf.att_date
    LEFT JOIN #CorrectedPunchLists cpl
        ON cpl.emp_id = rf.emp_id
       AND cpl.att_date = rf.att_date
    ORDER BY
        rf.employee_name,
        rf.att_date,
        rf.emp_code,
        rf.emp_id;
END;
