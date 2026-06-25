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
    WHERE mr.audit_reason <> 'OK';

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

    IF UPPER(ISNULL(@ResultMode, 'Full')) = 'SIMPLE'
    BEGIN
        SELECT
            df.att_date,
            df.emp_id,
            df.emp_code,
            df.employee_name AS Employee_name,
            df.effective_schedule_alias,
            CONVERT(varchar(8), CAST(df.effective_punch_in1 AS time), 108) AS effective_punch_in1_time,
            CONVERT(varchar(8), CAST(df.effective_punch_out1 AS time), 108) AS effective_punch_out1_time,
            CONVERT(varchar(8), CAST(df.effective_punch_in2 AS time), 108) AS effective_punch_in2_time,
            CONVERT(varchar(8), CAST(df.effective_punch_out2 AS time), 108) AS effective_punch_out2,
            punch_lists.raw_punches
        FROM #DailyFindings df
        INNER JOIN #EmployeeMismatchCounts emc
            ON emc.emp_id = df.emp_id
        OUTER APPLY
        (
            SELECT
                STUFF(
                    (
                        SELECT
                            ',' + CONVERT(varchar(8), CAST(np.punch_time AS time), 108)
                            + '('
                            + CASE
                                WHEN np.punch_state IN (0, 4) THEN 'IN'
                                WHEN np.punch_state IN (1, 5) THEN 'OUT'
                                ELSE CONVERT(varchar(10), np.punch_state)
                              END
                            + ')'
                        FROM dbo.custom_att_fnd_NormalizedPunches np
                        WHERE np.emp_id = df.emp_id
                          AND np.work_date = df.att_date
                        ORDER BY
                            np.punch_time,
                            np.id
                        FOR XML PATH('')
                    ),
                    1,
                    1,
                    ''
                ) AS raw_punches
        ) punch_lists
        ORDER BY
            df.att_date,
            df.emp_code;

        RETURN;
    END;

    SELECT
        df.att_date,
        df.emp_id,
        df.emp_code,
        df.employee_name,
        df.department_id,
        df.dept_code,
        df.dept_name,
        df.group_id,
        df.group_code,
        df.group_name,
        df.severity,
        df.audit_reason,
        df.effective_schedule_source,
        df.effective_schedule_alias,
        df.effective_scheduled_in_datetime,
        df.effective_scheduled_out_datetime,
        CONVERT(varchar(8), CAST(df.effective_scheduled_in_datetime AS time), 108) AS scheduled_in,
        CONVERT(varchar(8), CAST(df.effective_scheduled_out_datetime AS time), 108) AS scheduled_out,
        df.effective_punch_in1,
        df.effective_punch_out1,
        df.effective_punch_in2,
        df.effective_punch_out2,
        CONVERT(varchar(8), CAST(df.effective_punch_in1 AS time), 108) AS effective_punch_in1_time,
        CONVERT(varchar(8), CAST(df.effective_punch_out1 AS time), 108) AS effective_punch_out1_time,
        CONVERT(varchar(8), CAST(df.effective_punch_in2 AS time), 108) AS effective_punch_in2_time,
        CONVERT(varchar(8), CAST(df.effective_punch_out2 AS time), 108) AS effective_punch_out2_time,
        df.first_clock_in,
        df.last_clock_out,
        CONVERT(varchar(8), CAST(df.first_clock_in AS time), 108) AS actual_first_clock_in,
        CONVERT(varchar(8), CAST(df.last_clock_out AS time), 108) AS actual_last_clock_out,
        df.in_offset_minutes,
        df.out_offset_minutes,
        ABS(ISNULL(df.in_offset_minutes, 0)) AS abs_in_offset_minutes,
        ABS(ISNULL(df.out_offset_minutes, 0)) AS abs_out_offset_minutes,
        punch_lists.raw_punches,
        corrected_punches.corrected_punches,
        df.required_scheduled_hours,
        df.worked_hours,
        df.recomputed_worked_minutes,
        df.attendance_status,
        df.anomaly_flag,
        df.needs_payroll_review,
        df.reconciliation_status,
        emc.mismatch_days AS employee_mismatch_days_in_period,
        emc.employee_worst_in_offset_minutes,
        emc.employee_worst_out_offset_minutes
    FROM #DailyFindings df
    INNER JOIN #EmployeeMismatchCounts emc
        ON emc.emp_id = df.emp_id
    OUTER APPLY
    (
        SELECT
            STUFF(
                (
                    SELECT
                        ',' + CONVERT(varchar(8), CAST(np.punch_time AS time), 108)
                        + '('
                        + CASE
                            WHEN np.punch_state IN (0, 4) THEN 'IN'
                            WHEN np.punch_state IN (1, 5) THEN 'OUT'
                            ELSE CONVERT(varchar(10), np.punch_state)
                          END
                        + ')'
                    FROM dbo.custom_att_fnd_NormalizedPunches np
                    WHERE np.emp_id = df.emp_id
                      AND np.work_date = df.att_date
                    ORDER BY
                        np.punch_time,
                        np.id
                    FOR XML PATH('')
                ),
                1,
                1,
                ''
            ) AS raw_punches
    ) punch_lists
    OUTER APPLY
    (
        SELECT
            STUFF(
                (
                    SELECT
                        ',' + CONVERT(varchar(8), CAST(cp.punch_time AS time), 108)
                        + '('
                        + CASE
                            WHEN cp.corrected_punch_state = 0 THEN 'IN'
                            WHEN cp.corrected_punch_state = 1 THEN 'OUT'
                            ELSE CONVERT(varchar(10), cp.corrected_punch_state)
                          END
                        + CASE WHEN ISNULL(cp.corrected_punch_flag, 0) = 1 THEN '*' ELSE '' END
                        + ')'
                    FROM dbo.custom_att_fnd_CorrectedPunches cp
                    WHERE cp.emp_id = df.emp_id
                      AND cp.work_date = df.att_date
                    ORDER BY
                        cp.punch_time,
                        cp.id
                    FOR XML PATH('')
                ),
                1,
                1,
                ''
            ) AS corrected_punches
    ) corrected_punches
    ORDER BY
        df.severity_rank,
        emc.mismatch_days DESC,
        CASE
            WHEN ABS(ISNULL(df.in_offset_minutes, 0)) >= ABS(ISNULL(df.out_offset_minutes, 0))
            THEN ABS(ISNULL(df.in_offset_minutes, 0))
            ELSE ABS(ISNULL(df.out_offset_minutes, 0))
        END DESC,
        df.att_date,
        df.dept_name,
        df.group_name,
        df.emp_code;
END;
