CREATE PROCEDURE [dbo].[custom_att_GetAttendanceAccuracyIssues]
    @DateFrom date = NULL,
    @DateTo date = NULL,
    @EmpID int = NULL,
    @DepartmentID int = NULL,
    @GroupID int = NULL,
    @Severity varchar(20) = NULL,
    @IssueArea varchar(30) = NULL,
    @IssueCode varchar(60) = NULL,
    @OnlyPayrollBlock bit = 0,
    @IncludeDeepChecks bit = 0,
    @ReconciliationVarianceToleranceMinutes decimal(10,2) = 5.00
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

    DECLARE @NeedSchedule bit =
        CASE
            WHEN @IssueArea IS NULL OR @IssueArea = 'Schedule' THEN 1
            ELSE 0
        END;

    DECLARE @NeedWorkedIntervals bit =
        CASE
            WHEN @IncludeDeepChecks = 1
             AND (@IssueArea IS NULL OR @IssueArea = 'Fact')
             AND (@IssueCode IS NULL OR @IssueCode = 'WorkedMinutesMismatch')
            THEN 1
            ELSE 0
        END;

    CREATE TABLE #Facts
    (
        emp_id int NOT NULL,
        emp_code nvarchar(50) NULL,
        employee_name nvarchar(200) NULL,
        department_id int NULL,
        dept_code nvarchar(50) NULL,
        dept_name nvarchar(100) NULL,
        group_id int NULL,
        group_code nvarchar(50) NULL,
        group_name nvarchar(100) NULL,
        att_date date NOT NULL,
        daily_status varchar(50) NULL,
        attendance_status varchar(50) NULL,
        anomaly_flag varchar(100) NULL,
        needs_payroll_review bit NULL,
        first_clock_in datetime NULL,
        last_clock_out datetime NULL,
        required_scheduled_hours decimal(10,2) NULL,
        worked_hours decimal(10,2) NULL,
        recomputed_worked_minutes decimal(10,2) NULL,
        recomputed_absence_hours decimal(10,2) NULL,
        reconciliation_status varchar(50) NULL,
        reconciliation_variance_minutes decimal(10,2) NULL,
        work_gap_minutes decimal(10,2) NULL,
        [Leaves] decimal(10,2) NULL,
        interval_worked_minutes int NULL,
        CONSTRAINT PK_TempFacts PRIMARY KEY CLUSTERED (emp_id, att_date)
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
        daily_status,
        attendance_status,
        anomaly_flag,
        needs_payroll_review,
        first_clock_in,
        last_clock_out,
        required_scheduled_hours,
        worked_hours,
        recomputed_worked_minutes,
        recomputed_absence_hours,
        reconciliation_status,
        reconciliation_variance_minutes,
        work_gap_minutes,
        [Leaves]
    )
    SELECT
        f.emp_id,
        e.emp_code,
        LTRIM(RTRIM(ISNULL(e.first_name, '') + ' ' + ISNULL(e.last_name, ''))) AS employee_name,
        e.department_id,
        d.dept_code,
        d.dept_name,
        ae.group_id,
        ag.code AS group_code,
        ag.name AS group_name,
        f.att_date,
        f.daily_status,
        f.attendance_status,
        f.anomaly_flag,
        f.needs_payroll_review,
        f.first_clock_in,
        f.last_clock_out,
        f.required_scheduled_hours,
        f.worked_hours,
        f.recomputed_worked_minutes,
        f.recomputed_absence_hours,
        f.reconciliation_status,
        f.reconciliation_variance_minutes,
        f.work_gap_minutes,
        f.[Leaves]
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

    IF @NeedWorkedIntervals = 1
    BEGIN
        UPDATE f
        SET interval_worked_minutes = wi.interval_worked_minutes
        FROM #Facts f
        INNER JOIN
        (
            SELECT
                wi.emp_id,
                wi.work_date,
                SUM(wi.worked_minutes) AS interval_worked_minutes
            FROM dbo.custom_att_fnd_WorkedIntervals wi
            INNER JOIN #Facts f
                ON f.emp_id = wi.emp_id
               AND f.att_date = wi.work_date
            GROUP BY
                wi.emp_id,
                wi.work_date
        ) wi
            ON wi.emp_id = f.emp_id
           AND wi.work_date = f.att_date;
    END;

    CREATE TABLE #ResolvedSchedule
    (
        emp_id int NOT NULL,
        att_date date NOT NULL,
        effective_schedule_source varchar(30) NULL,
        effective_shift_id int NULL,
        effective_time_interval_id int NULL,
        effective_required_work_minutes int NULL,
        scheduled_ot_cap_minutes int NULL,
        resolved_is_off_day int NULL,
        effective_scheduled_in_datetime datetime NULL,
        effective_scheduled_out_datetime datetime NULL,
        schedule_use_mode int NULL,
        schedule_work_time_duration int NULL,
        CONSTRAINT PK_TempResolvedSchedule PRIMARY KEY CLUSTERED (emp_id, att_date)
    );

    IF @NeedSchedule = 1
    BEGIN
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
        (
            emp_id,
            att_date,
            effective_schedule_source,
            source_priority,
            effective_shift_id,
            effective_time_interval_id,
            source_row_id,
            schedule_anchor_date
        )
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
        (
            emp_id,
            att_date,
            effective_schedule_source,
            source_priority,
            effective_shift_id,
            effective_time_interval_id,
            source_row_id,
            schedule_anchor_date
        )
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
        (
            emp_id,
            att_date,
            effective_schedule_source,
            source_priority,
            effective_shift_id,
            effective_time_interval_id,
            source_row_id,
            schedule_anchor_date
        )
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
        (
            emp_id,
            att_date,
            effective_schedule_source,
            source_priority,
            effective_shift_id,
            effective_time_interval_id,
            source_row_id,
            schedule_anchor_date
        )
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

        CREATE CLUSTERED INDEX IX_TempScheduleCandidates
            ON #ScheduleCandidates (emp_id, att_date, source_priority, source_row_id DESC);

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
        ),
        ti_break AS
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
            effective_shift_id,
            effective_time_interval_id,
            effective_required_work_minutes,
            scheduled_ot_cap_minutes,
            resolved_is_off_day,
            effective_scheduled_in_datetime,
            effective_scheduled_out_datetime,
            schedule_use_mode,
            schedule_work_time_duration
        )
        SELECT
            c.emp_id,
            c.att_date,
            c.effective_schedule_source,
            c.effective_shift_id,
            COALESCE(c.effective_time_interval_id, sd.time_interval_id) AS effective_time_interval_id,
            CASE
                WHEN ISNULL(ti.work_type, 0) IN (1, 2) THEN 0
                WHEN c.effective_schedule_source <> 'Temporary'
                 AND c.effective_shift_id IS NOT NULL
                 AND sd.shift_id IS NULL THEN 0
                ELSE ISNULL(ti.duration, 0) - ISNULL(tb.break_minutes, 0)
            END AS effective_required_work_minutes,
            CASE
                WHEN c.effective_schedule_source = 'Temporary' THEN 0
                WHEN ISNULL(ti.enable_overtime, 0) = 1
                 AND ISNULL(ti.max_ot_limit, 0) > 0
                THEN ISNULL(ti.max_ot_limit, 0)
                ELSE 0
            END AS scheduled_ot_cap_minutes,
            CASE
                WHEN c.effective_schedule_source <> 'Temporary'
                 AND c.effective_shift_id IS NOT NULL
                 AND sd.shift_id IS NULL THEN 1
                WHEN ISNULL(ti.work_type, 0) IN (1, 2) THEN 1
                ELSE 0
            END AS resolved_is_off_day,
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
            ti.work_time_duration
        FROM Chosen c
        OUTER APPLY
        (
            SELECT TOP (1) *
            FROM dbo.att_shiftdetail sd
            WHERE sd.shift_id = c.effective_shift_id
              AND sd.day_index = c.resolved_day_index
        ) sd
        LEFT JOIN dbo.att_timeinterval ti
            ON ti.id = COALESCE(c.effective_time_interval_id, sd.time_interval_id)
        LEFT JOIN ti_break tb
            ON tb.timeinterval_id = COALESCE(c.effective_time_interval_id, sd.time_interval_id);
    END;

    CREATE TABLE #Issues
    (
        emp_id int NOT NULL,
        emp_code nvarchar(50) NULL,
        employee_name nvarchar(200) NULL,
        department_id int NULL,
        dept_code nvarchar(50) NULL,
        dept_name nvarchar(100) NULL,
        group_id int NULL,
        group_code nvarchar(50) NULL,
        group_name nvarchar(100) NULL,
        att_date date NOT NULL,
        issue_area varchar(30) NOT NULL,
        issue_code varchar(60) NOT NULL,
        severity varchar(20) NOT NULL,
        issue_message varchar(250) NOT NULL,
        expected_value varchar(100) NULL,
        actual_value varchar(100) NULL,
        needs_payroll_block bit NOT NULL
    );

    IF @NeedSchedule = 1
       AND (@IssueCode IS NULL OR @IssueCode = 'MissingSchedule')
    BEGIN
        INSERT INTO #Issues
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
            'Schedule',
            'MissingSchedule',
            CASE
                WHEN f.first_clock_in IS NOT NULL
                  OR f.last_clock_out IS NOT NULL
                  OR ISNULL(f.worked_hours, 0) > 0
                THEN 'Critical'
                ELSE 'High'
            END,
            'Employee attendance fact has no resolved schedule for the date.',
            'Resolved schedule',
            'No schedule',
            1
        FROM #Facts f
        LEFT JOIN #ResolvedSchedule rs
            ON rs.emp_id = f.emp_id
           AND rs.att_date = f.att_date
        WHERE rs.emp_id IS NULL
          AND (@Severity IS NULL OR @Severity =
                CASE
                    WHEN f.first_clock_in IS NOT NULL
                      OR f.last_clock_out IS NOT NULL
                      OR ISNULL(f.worked_hours, 0) > 0
                    THEN 'Critical'
                    ELSE 'High'
                END)
          AND
          (
              ISNULL(f.required_scheduled_hours, 0) > 0
              OR ISNULL(f.worked_hours, 0) > 0
              OR f.first_clock_in IS NOT NULL
              OR f.last_clock_out IS NOT NULL
              OR f.daily_status = 'RegularDay'
          );
    END;

    IF @NeedSchedule = 1
       AND (@IssueCode IS NULL OR @IssueCode = 'InheritedSchedule')
       AND @OnlyPayrollBlock = 0
       AND (@Severity IS NULL OR @Severity = 'Medium')
    BEGIN
        INSERT INTO #Issues
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
            'Schedule',
            'InheritedSchedule',
            'Medium',
            'Employee is using an inherited group or department schedule.',
            'Employee or temporary schedule when duty is employee-specific',
            rs.effective_schedule_source,
            0
        FROM #Facts f
        INNER JOIN #ResolvedSchedule rs
            ON rs.emp_id = f.emp_id
           AND rs.att_date = f.att_date
        WHERE rs.effective_schedule_source IN ('Group', 'Department');
    END;

    IF @NeedSchedule = 1
       AND
       (
           @IssueCode IS NULL
        OR @IssueCode IN
           (
               'MissingClockOutAgainstSchedule',
               'MissingClockInAgainstSchedule',
               'ShiftedEarly',
               'ShiftedLate',
               'ClockInFarFromSchedule',
               'ClockOutFarFromSchedule',
               'ScheduleWindowMismatch'
           )
       )
    BEGIN
        ;WITH ScheduleMismatch AS
        (
            SELECT
                f.*,
                rs.effective_scheduled_in_datetime,
                rs.effective_scheduled_out_datetime,
                DATEDIFF(MINUTE, rs.effective_scheduled_in_datetime, f.first_clock_in) AS in_offset_minutes,
                DATEDIFF(MINUTE, rs.effective_scheduled_out_datetime, f.last_clock_out) AS out_offset_minutes,
                CASE
                    WHEN f.first_clock_in IS NOT NULL
                     AND f.last_clock_out IS NULL
                    THEN 'MissingClockOutAgainstSchedule'

                    WHEN f.first_clock_in IS NULL
                     AND f.last_clock_out IS NOT NULL
                    THEN 'MissingClockInAgainstSchedule'

                    WHEN DATEDIFF(MINUTE, rs.effective_scheduled_in_datetime, f.first_clock_in) <= -60
                     AND DATEDIFF(MINUTE, rs.effective_scheduled_out_datetime, f.last_clock_out) <= -60
                    THEN 'ShiftedEarly'

                    WHEN DATEDIFF(MINUTE, rs.effective_scheduled_in_datetime, f.first_clock_in) >= 60
                     AND DATEDIFF(MINUTE, rs.effective_scheduled_out_datetime, f.last_clock_out) >= 60
                    THEN 'ShiftedLate'

                    WHEN ABS(DATEDIFF(MINUTE, rs.effective_scheduled_in_datetime, f.first_clock_in)) >= 60
                    THEN 'ClockInFarFromSchedule'

                    WHEN ABS(DATEDIFF(MINUTE, rs.effective_scheduled_out_datetime, f.last_clock_out)) >= 60
                    THEN 'ClockOutFarFromSchedule'

                    ELSE 'ScheduleWindowMismatch'
                END AS mismatch_type,
                CASE
                    WHEN f.first_clock_in IS NULL
                      OR f.last_clock_out IS NULL
                    THEN 'High'

                    WHEN ABS(ISNULL(DATEDIFF(MINUTE, rs.effective_scheduled_in_datetime, f.first_clock_in), 0)) >= 180
                      OR ABS(ISNULL(DATEDIFF(MINUTE, rs.effective_scheduled_out_datetime, f.last_clock_out), 0)) >= 180
                    THEN 'High'

                    ELSE 'Medium'
                END AS mismatch_severity
            FROM #Facts f
            INNER JOIN #ResolvedSchedule rs
                ON rs.emp_id = f.emp_id
               AND rs.att_date = f.att_date
            WHERE ISNULL(rs.schedule_use_mode, 0) <> 1
              AND ISNULL(f.required_scheduled_hours, 0) > 0
              AND rs.effective_scheduled_in_datetime IS NOT NULL
              AND rs.effective_scheduled_out_datetime IS NOT NULL
              AND (f.first_clock_in IS NOT NULL OR f.last_clock_out IS NOT NULL)
              AND
              (
                  (
                      f.first_clock_in IS NOT NULL
                  AND f.last_clock_out IS NOT NULL
                  AND ISNULL(f.recomputed_worked_minutes, 0) >= (ISNULL(f.required_scheduled_hours, 0) * 60.0) - 30
                  AND
                      (
                          (
                              DATEDIFF(MINUTE, f.first_clock_in, rs.effective_scheduled_in_datetime) >= 60
                          AND DATEDIFF(MINUTE, f.last_clock_out, rs.effective_scheduled_out_datetime) >= 60
                          )
                          OR
                          (
                              DATEDIFF(MINUTE, rs.effective_scheduled_in_datetime, f.first_clock_in) >= 60
                          AND DATEDIFF(MINUTE, rs.effective_scheduled_out_datetime, f.last_clock_out) >= 60
                          )
                      )
                  )
                  OR
                  (
                      f.first_clock_in IS NOT NULL
                  AND f.last_clock_out IS NULL
                  AND ABS(DATEDIFF(MINUTE, rs.effective_scheduled_in_datetime, f.first_clock_in)) >= 60
                  )
                  OR
                  (
                      f.first_clock_in IS NULL
                  AND f.last_clock_out IS NOT NULL
                  AND ABS(DATEDIFF(MINUTE, rs.effective_scheduled_out_datetime, f.last_clock_out)) >= 60
                  )
              )
        )
        INSERT INTO #Issues
        SELECT
            sm.emp_id,
            sm.emp_code,
            sm.employee_name,
            sm.department_id,
            sm.dept_code,
            sm.dept_name,
            sm.group_id,
            sm.group_code,
            sm.group_name,
            sm.att_date,
            'Schedule',
            sm.mismatch_type,
            sm.mismatch_severity,
            'Actual punch window is far from the resolved schedule window.',
            CONVERT(varchar(16), sm.effective_scheduled_in_datetime, 120)
                + ' - '
                + CONVERT(varchar(16), sm.effective_scheduled_out_datetime, 120),
            ISNULL(CONVERT(varchar(16), sm.first_clock_in, 120), 'Missing IN')
                + ' - '
                + ISNULL(CONVERT(varchar(16), sm.last_clock_out, 120), 'Missing OUT'),
            1
        FROM ScheduleMismatch sm
        WHERE (@IssueCode IS NULL OR sm.mismatch_type = @IssueCode)
          AND (@Severity IS NULL OR sm.mismatch_severity = @Severity);
    END;

    IF @NeedSchedule = 1
       AND (@IssueCode IS NULL OR @IssueCode = 'RequiredHoursMismatch')
       AND (@Severity IS NULL OR @Severity = 'High')
    BEGIN
        ;WITH ExpectedRequired AS
        (
            SELECT
                rs.emp_id,
                rs.att_date,
                CASE
                    WHEN ISNULL(rs.resolved_is_off_day, 0) = 1
                     AND ISNULL(rs.effective_required_work_minutes, 0) <= 0
                    THEN 0

                    WHEN rs.effective_schedule_source = 'Temporary'
                     AND ISNULL(rs.effective_required_work_minutes, 0) = 0
                    THEN 0

                    WHEN ISNULL(rs.schedule_use_mode, 0) = 1
                     AND ISNULL(rs.schedule_work_time_duration, 0) > 0
                    THEN ISNULL(rs.schedule_work_time_duration, 0)

                    WHEN ISNULL(rs.effective_required_work_minutes, 0) > 0
                    THEN
                        CASE
                            WHEN ISNULL(rs.effective_required_work_minutes, 0)
                                 - ISNULL(rs.scheduled_ot_cap_minutes, 0) > 0
                            THEN ISNULL(rs.effective_required_work_minutes, 0)
                               - ISNULL(rs.scheduled_ot_cap_minutes, 0)
                            ELSE 0
                        END

                    ELSE 0
                END AS expected_required_minutes
            FROM #ResolvedSchedule rs
        )
        INSERT INTO #Issues
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
            'Schedule',
            'RequiredHoursMismatch',
            'High',
            'Fact required hours do not match the payroll-required schedule hours.',
            CAST(CAST(ISNULL(er.expected_required_minutes, 0) / 60.0 AS decimal(10,2)) AS varchar(100)),
            CAST(CAST(ISNULL(f.required_scheduled_hours, 0) AS decimal(10,2)) AS varchar(100)),
            1
        FROM #Facts f
        INNER JOIN ExpectedRequired er
            ON er.emp_id = f.emp_id
           AND er.att_date = f.att_date
        WHERE ABS(
                ISNULL(f.required_scheduled_hours, 0)
                - CAST(ISNULL(er.expected_required_minutes, 0) / 60.0 AS decimal(10,2))
              ) >= 0.02;
    END;

    IF @NeedWorkedIntervals = 1
       AND (@Severity IS NULL OR @Severity = 'High')
    BEGIN
        INSERT INTO #Issues
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
            'Fact',
            'WorkedMinutesMismatch',
            'High',
            'Fact worked minutes do not match summed worked intervals.',
            CAST(CAST(ISNULL(f.interval_worked_minutes, 0) AS decimal(10,2)) AS varchar(100)),
            CAST(CAST(ISNULL(f.recomputed_worked_minutes, 0) AS decimal(10,2)) AS varchar(100)),
            1
        FROM #Facts f
        WHERE ABS(ISNULL(f.interval_worked_minutes, 0) - ISNULL(f.recomputed_worked_minutes, 0)) > 5;
    END;

    IF (@IssueArea IS NULL OR @IssueArea = 'Schedule')
       AND (@IssueCode IS NULL OR @IssueCode = 'RegularDayZeroRequiredHours')
       AND (@Severity IS NULL OR @Severity = 'Critical')
    BEGIN
        INSERT INTO #Issues
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
            'Schedule',
            'RegularDayZeroRequiredHours',
            'Critical',
            'Regular work day has zero required scheduled hours.',
            'Required hours greater than zero',
            CAST(CAST(ISNULL(f.required_scheduled_hours, 0) AS decimal(10,2)) AS varchar(100)),
            1
        FROM #Facts f
        WHERE f.daily_status = 'RegularDay'
          AND ISNULL(f.required_scheduled_hours, 0) = 0;
    END;

    IF (@IssueArea IS NULL OR @IssueArea = 'Schedule')
       AND (@IssueCode IS NULL OR @IssueCode = 'NonRegularDayHasRequiredHours')
       AND (@Severity IS NULL OR @Severity = 'High')
    BEGIN
        INSERT INTO #Issues
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
            'Schedule',
            'NonRegularDayHasRequiredHours',
            'High',
            'Rest day, holiday, or non-regular day has required scheduled hours.',
            'Required hours equal zero',
            CAST(CAST(ISNULL(f.required_scheduled_hours, 0) AS decimal(10,2)) AS varchar(100)),
            1
        FROM #Facts f
        WHERE ISNULL(f.daily_status, '') <> 'RegularDay'
          AND ISNULL(f.required_scheduled_hours, 0) > 0;
    END;

    IF @NeedSchedule = 1
       AND (@IssueArea IS NULL OR @IssueArea = 'Schedule')
       AND
       (
           @IssueCode IS NULL
        OR @IssueCode IN
           (
               'WorkedOnNonWorkingDay',
               'WorkedWithoutRequiredSchedule',
               'AbsentWithoutPunches',
               'WorkedMuchLongerThanSchedule',
               'WorkedMuchShorterThanSchedule',
               'ClockInFarFromSchedule'
           )
       )
    BEGIN
        ;WITH ScheduleWorkIssues AS
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
                CAST('WorkedOnNonWorkingDay' AS varchar(60)) AS issue_code,
                CAST('High' AS varchar(20)) AS severity,
                CAST('Employee worked on a rest day or holiday that is not cleanly classified as OT work.' AS varchar(250)) AS issue_message,
                CAST('No regular work on rest day or holiday' AS varchar(100)) AS expected_value,
                CAST(ISNULL(f.daily_status, 'Unknown') + ', worked_hours=' + CAST(CAST(ISNULL(f.worked_hours, 0) AS decimal(10,2)) AS varchar(20)) AS varchar(100)) AS actual_value,
                CAST(1 AS bit) AS needs_payroll_block
            FROM #Facts f
            WHERE f.daily_status IN ('RestDay', 'Holiday')
              AND ISNULL(f.worked_hours, 0) > 0
              AND NOT
              (
                  f.attendance_status = 'OT Day'
              AND f.reconciliation_status = 'OT Work'
              AND ISNULL(f.needs_payroll_review, 0) = 0
              )

            UNION ALL

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
                CAST('WorkedWithoutRequiredSchedule' AS varchar(60)),
                CAST('High' AS varchar(20)),
                CAST('Employee has worked hours but zero required scheduled hours outside a temporary schedule.' AS varchar(250)),
                CAST('Required schedule or temporary OT schedule' AS varchar(100)),
                CAST(ISNULL(rs.effective_schedule_source, 'No schedule') + ', worked_hours=' + CAST(CAST(ISNULL(f.worked_hours, 0) AS decimal(10,2)) AS varchar(20)) AS varchar(100)),
                CAST(1 AS bit)
            FROM #Facts f
            LEFT JOIN #ResolvedSchedule rs
                ON rs.emp_id = f.emp_id
               AND rs.att_date = f.att_date
            WHERE ISNULL(f.required_scheduled_hours, 0) = 0
              AND ISNULL(f.worked_hours, 0) > 0
              AND ISNULL(rs.effective_schedule_source, '') <> 'Temporary'
              AND NOT
              (
                  f.attendance_status = 'OT Day'
              AND f.reconciliation_status = 'OT Work'
              AND ISNULL(f.needs_payroll_review, 0) = 0
              )

            UNION ALL

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
                CAST('AbsentWithoutPunches' AS varchar(60)),
                CAST('Critical' AS varchar(20)),
                CAST('Regular scheduled work day has no punches and no worked hours.' AS varchar(250)),
                CAST('Punches or approved leave/absence handling' AS varchar(100)),
                CAST('No punches, worked_hours=0' AS varchar(100)),
                CAST(1 AS bit)
            FROM #Facts f
            WHERE f.daily_status = 'RegularDay'
              AND ISNULL(f.required_scheduled_hours, 0) > 0
              AND ISNULL(f.worked_hours, 0) = 0
              AND f.first_clock_in IS NULL
              AND f.last_clock_out IS NULL

            UNION ALL

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
                CAST('WorkedMuchLongerThanSchedule' AS varchar(60)),
                CAST('Medium' AS varchar(20)),
                CAST('Worked hours exceed required scheduled hours by at least four hours.' AS varchar(250)),
                CAST('Worked hours near required schedule' AS varchar(100)),
                CAST('required=' + CAST(CAST(ISNULL(f.required_scheduled_hours, 0) AS decimal(10,2)) AS varchar(20)) + ', worked=' + CAST(CAST(ISNULL(f.worked_hours, 0) AS decimal(10,2)) AS varchar(20)) AS varchar(100)),
                CAST(0 AS bit)
            FROM #Facts f
            WHERE ISNULL(f.worked_hours, 0) >= ISNULL(f.required_scheduled_hours, 0) + 4
              AND NOT
              (
                  f.attendance_status = 'OT Day'
              AND f.reconciliation_status = 'OT Work'
              AND ISNULL(f.needs_payroll_review, 0) = 0
              )

            UNION ALL

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
                CAST('WorkedMuchShorterThanSchedule' AS varchar(60)),
                CAST('High' AS varchar(20)),
                CAST('Employee worked three hours or less on a day requiring at least six hours.' AS varchar(250)),
                CAST('Worked hours near required schedule' AS varchar(100)),
                CAST('required=' + CAST(CAST(ISNULL(f.required_scheduled_hours, 0) AS decimal(10,2)) AS varchar(20)) + ', worked=' + CAST(CAST(ISNULL(f.worked_hours, 0) AS decimal(10,2)) AS varchar(20)) AS varchar(100)),
                CAST(1 AS bit)
            FROM #Facts f
            WHERE ISNULL(f.required_scheduled_hours, 0) >= 6
              AND ISNULL(f.worked_hours, 0) <= 3
              AND ISNULL(f.worked_hours, 0) > 0

            UNION ALL

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
                CAST('ClockInFarFromSchedule' AS varchar(60)),
                CAST('High' AS varchar(20)),
                CAST('First clock-in is at least three hours away from scheduled IN.' AS varchar(250)),
                CAST(CONVERT(varchar(16), rs.effective_scheduled_in_datetime, 120) AS varchar(100)),
                CAST(CONVERT(varchar(16), f.first_clock_in, 120) AS varchar(100)),
                CAST(1 AS bit)
            FROM #Facts f
            INNER JOIN #ResolvedSchedule rs
                ON rs.emp_id = f.emp_id
               AND rs.att_date = f.att_date
            WHERE f.first_clock_in IS NOT NULL
              AND rs.effective_scheduled_in_datetime IS NOT NULL
              AND ISNULL(rs.schedule_use_mode, 0) <> 1
              AND ABS(DATEDIFF(MINUTE, rs.effective_scheduled_in_datetime, f.first_clock_in)) >= 180
        )
        INSERT INTO #Issues
        SELECT
            swi.emp_id,
            swi.emp_code,
            swi.employee_name,
            swi.department_id,
            swi.dept_code,
            swi.dept_name,
            swi.group_id,
            swi.group_code,
            swi.group_name,
            swi.att_date,
            'Schedule',
            swi.issue_code,
            swi.severity,
            swi.issue_message,
            swi.expected_value,
            swi.actual_value,
            swi.needs_payroll_block
        FROM ScheduleWorkIssues swi
        WHERE (@IssueCode IS NULL OR swi.issue_code = @IssueCode)
          AND (@Severity IS NULL OR swi.severity = @Severity);
    END;

    IF (@IssueArea IS NULL OR @IssueArea = 'Punch')
       AND
       (
           @IssueCode IS NULL
        OR @IssueCode IN ('MissingIn', 'MissingOut', 'NoPunch', 'IncompletePunchPair')
       )
       AND (@Severity IS NULL OR @Severity = 'Critical')
    BEGIN
        INSERT INTO #Issues
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
            'Punch',
            ISNULL(f.anomaly_flag, 'UnknownPunchAnomaly'),
            'Critical',
            'Attendance fact has a missing or incomplete punch anomaly.',
            'Complete IN/OUT punch pair',
            ISNULL(f.anomaly_flag, 'Unknown'),
            1
        FROM #Facts f
        WHERE f.anomaly_flag IN ('MissingIn', 'MissingOut', 'NoPunch', 'IncompletePunchPair')
          AND (@IssueCode IS NULL OR f.anomaly_flag = @IssueCode);
    END;

    IF (@IssueArea IS NULL OR @IssueArea = 'Payroll')
       AND (@IssueCode IS NULL OR @IssueCode = 'PayrollReviewRequired')
       AND (@Severity IS NULL OR @Severity = 'High')
    BEGIN
        INSERT INTO #Issues
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
            'Payroll',
            'PayrollReviewRequired',
            'High',
            'Attendance fact is marked as needing payroll review.',
            'needs_payroll_review = 0',
            'needs_payroll_review = 1',
            1
        FROM #Facts f
        WHERE ISNULL(f.needs_payroll_review, 0) = 1;
    END;

    IF (@IssueArea IS NULL OR @IssueArea = 'Payroll')
       AND (@IssueCode IS NULL OR @IssueCode = 'ReconciliationVariance')
       AND (@Severity IS NULL OR @Severity = 'High')
    BEGIN
        INSERT INTO #Issues
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
            'Payroll',
            'ReconciliationVariance',
            'High',
            'Attendance fact has reconciliation variance beyond tolerance.',
            CAST('<= ' + CAST(@ReconciliationVarianceToleranceMinutes AS varchar(20)) + ' minutes variance' AS varchar(100)),
            CAST(CAST(ISNULL(f.reconciliation_variance_minutes, 0) AS decimal(10,2)) AS varchar(100)),
            1
        FROM #Facts f
        WHERE ABS(ISNULL(f.reconciliation_variance_minutes, 0)) > @ReconciliationVarianceToleranceMinutes;
    END;

    IF (@IssueArea IS NULL OR @IssueArea = 'Payroll')
       AND (@IssueCode IS NULL OR @IssueCode = 'GeneralAnomaly')
       AND @OnlyPayrollBlock = 0
       AND (@Severity IS NULL OR @Severity = 'Medium')
    BEGIN
        INSERT INTO #Issues
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
            'Payroll',
            'GeneralAnomaly',
            'Medium',
            'Attendance fact has a non-normal anomaly flag.',
            'Normal',
            ISNULL(f.anomaly_flag, 'NULL'),
            0
        FROM #Facts f
        WHERE ISNULL(f.anomaly_flag, 'Normal') <> 'Normal'
          AND f.anomaly_flag NOT IN ('MissingIn', 'MissingOut', 'NoPunch', 'IncompletePunchPair');
    END;

    SELECT
        i.emp_id,
        i.emp_code,
        i.employee_name,
        i.department_id,
        i.dept_code,
        i.dept_name,
        i.group_id,
        i.group_code,
        i.group_name,
        i.att_date,
        i.issue_area,
        i.issue_code,
        i.severity,
        i.issue_message,
        i.expected_value,
        i.actual_value,
        i.needs_payroll_block
    FROM #Issues i
    WHERE (@OnlyPayrollBlock = 0 OR i.needs_payroll_block = 1)
    ORDER BY
        CASE i.severity
            WHEN 'Critical' THEN 1
            WHEN 'High' THEN 2
            WHEN 'Medium' THEN 3
            ELSE 4
        END,
        i.dept_name,
        i.group_name,
        i.emp_code,
        i.att_date,
        i.issue_area,
        i.issue_code;
END;
