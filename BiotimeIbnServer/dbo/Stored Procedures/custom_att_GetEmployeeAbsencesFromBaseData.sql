CREATE PROCEDURE [dbo].[custom_att_GetEmployeeAbsencesFromBaseData]
    @DateFrom varchar(10) = NULL,
    @DateTo varchar(10) = NULL,
    @EmpID int = NULL,
    @DepartmentID int = NULL,
    @GroupID int = NULL,
    @ExcludeApprovedLeaves bit = 1
AS
BEGIN
    SET NOCOUNT ON;
    SET FMTONLY OFF;

    DECLARE @DateFromValue datetime;
    DECLARE @DateToValue datetime;

    IF @DateFrom IS NULL AND @DateTo IS NULL
    BEGIN
        SET @DateFromValue = DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0);
        SET @DateToValue = @DateFromValue;
    END;

    IF @DateFromValue IS NULL AND @DateFrom IS NOT NULL
        SET @DateFromValue = DATEFROMPARTS(
            CAST(SUBSTRING(@DateFrom, 1, 4) AS int),
            CAST(SUBSTRING(@DateFrom, 6, 2) AS int),
            CAST(SUBSTRING(@DateFrom, 9, 2) AS int)
        );

    IF @DateToValue IS NULL AND @DateTo IS NOT NULL
        SET @DateToValue = DATEFROMPARTS(
            CAST(SUBSTRING(@DateTo, 1, 4) AS int),
            CAST(SUBSTRING(@DateTo, 6, 2) AS int),
            CAST(SUBSTRING(@DateTo, 9, 2) AS int)
        );

    IF @DateFromValue IS NULL
        SET @DateFromValue = @DateToValue;

    IF @DateToValue IS NULL
        SET @DateToValue = @DateFromValue;

    IF @DateFromValue > @DateToValue
    BEGIN
        DECLARE @SwapDate datetime = @DateFromValue;
        SET @DateFromValue = @DateToValue;
        SET @DateToValue = @SwapDate;
    END;

    IF @ExcludeApprovedLeaves IS NULL
        SET @ExcludeApprovedLeaves = 1;

    CREATE TABLE #Dates
    (
        att_date date NOT NULL PRIMARY KEY
    );

    ;WITH Numbers AS
    (
        SELECT TOP (DATEDIFF(DAY, @DateFromValue, @DateToValue) + 1)
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
        FROM sys.all_objects a
        CROSS JOIN sys.all_objects b
    )
    INSERT INTO #Dates (att_date)
    SELECT DATEADD(DAY, n, @DateFromValue)
    FROM Numbers;

    CREATE TABLE #EmployeeDates
    (
        emp_id int NOT NULL,
        emp_code nvarchar(20) NOT NULL,
        employee_name nvarchar(250) NULL,
        department_id int NULL,
        dept_code nvarchar(50) NULL,
        dept_name nvarchar(200) NULL,
        group_id int NULL,
        group_code nvarchar(50) NULL,
        group_name nvarchar(100) NULL,
        att_date date NOT NULL,
        PRIMARY KEY CLUSTERED (emp_id, att_date)
    );

    INSERT INTO #EmployeeDates
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
        att_date
    )
    SELECT
        e.id,
        e.emp_code,
        CAST(LTRIM(RTRIM(ISNULL(e.first_name, '') + ' ' + ISNULL(e.last_name, ''))) AS nvarchar(250)) AS employee_name,
        e.department_id,
        d.dept_code,
        d.dept_name,
        ae.group_id,
        ag.code AS group_code,
        ag.name AS group_name,
        dt.att_date
    FROM dbo.personnel_employee e
    INNER JOIN dbo.att_attemployee ae
        ON ae.emp_id = e.id
       AND ae.enable_attendance = 1
    CROSS JOIN #Dates dt
    LEFT JOIN dbo.personnel_department d
        ON d.id = e.department_id
    LEFT JOIN dbo.att_attgroup ag
        ON ag.id = ae.group_id
    WHERE (@EmpID IS NULL OR e.id = @EmpID)
      AND (@DepartmentID IS NULL OR e.department_id = @DepartmentID)
      AND (@GroupID IS NULL OR ae.group_id = @GroupID)
      AND ISNULL(e.is_active, 1) = 1
      AND NOT EXISTS
      (
          SELECT 1
          FROM dbo.personnel_resign r
          WHERE r.employee_id = e.id
            AND dt.att_date > r.resign_date
      )
    OPTION (RECOMPILE);

    CREATE NONCLUSTERED INDEX IX_TempAbsencesEmployeeDates_GroupDate
        ON #EmployeeDates (group_id, att_date)
        INCLUDE (emp_id)
        WHERE group_id IS NOT NULL;

    CREATE NONCLUSTERED INDEX IX_TempAbsencesEmployeeDates_DepartmentDate
        ON #EmployeeDates (department_id, att_date)
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
    INNER JOIN #EmployeeDates ed
        ON ed.emp_id = ts.employee_id
       AND ed.att_date = ts.att_date
    WHERE ts.status = 0
      AND ts.time_interval_id IS NOT NULL;

    INSERT INTO #ScheduleCandidates
    SELECT
        s.employee_id,
        ed.att_date,
        'Employee',
        2,
        s.shift_id,
        CAST(NULL AS int),
        s.id,
        s.start_date
    FROM dbo.att_attschedule s
    INNER JOIN #EmployeeDates ed
        ON ed.emp_id = s.employee_id
       AND ed.att_date BETWEEN s.start_date AND s.end_date
    WHERE s.shift_id IS NOT NULL;

    INSERT INTO #ScheduleCandidates
    SELECT
        ed.emp_id,
        ed.att_date,
        'Group',
        3,
        gs.shift_id,
        CAST(NULL AS int),
        gs.id,
        gs.start_date
    FROM dbo.att_groupschedule gs
    INNER JOIN #EmployeeDates ed
        ON ed.group_id = gs.group_id
       AND ed.att_date BETWEEN gs.start_date AND gs.end_date
    WHERE gs.status = 0
      AND gs.shift_id IS NOT NULL;

    INSERT INTO #ScheduleCandidates
    SELECT
        ed.emp_id,
        ed.att_date,
        'Department',
        4,
        ds.shift_id,
        CAST(NULL AS int),
        ds.id,
        ds.start_date
    FROM dbo.att_departmentschedule ds
    INNER JOIN #EmployeeDates ed
        ON ed.department_id = ds.department_id
       AND ed.att_date BETWEEN ds.start_date AND ds.end_date
    WHERE ds.status = 0
      AND ds.shift_id IS NOT NULL;

    CREATE CLUSTERED INDEX IX_TempAbsencesScheduleCandidates
        ON #ScheduleCandidates (emp_id, att_date, source_priority, source_row_id DESC);

    CREATE TABLE #TimeIntervalBreaks
    (
        timeinterval_id int NOT NULL PRIMARY KEY,
        break_minutes int NOT NULL
    );

    INSERT INTO #TimeIntervalBreaks
    SELECT
        tib.timeinterval_id,
        SUM(ISNULL(bt.duration, 0)) AS break_minutes
    FROM dbo.att_timeinterval_break_time tib
    INNER JOIN dbo.att_breaktime bt
        ON bt.id = tib.breaktime_id
    GROUP BY
        tib.timeinterval_id;

    CREATE TABLE #ResolvedSchedule
    (
        emp_id int NOT NULL,
        att_date date NOT NULL,
        effective_schedule_source varchar(30) NULL,
        effective_shift_id int NULL,
        effective_time_interval_id int NULL,
        effective_schedule_alias nvarchar(50) NULL,
        effective_scheduled_in_datetime datetime NULL,
        effective_scheduled_out_datetime datetime NULL,
        schedule_use_mode int NULL,
        work_type smallint NULL,
        scheduled_ot_cap_minutes int NOT NULL,
        effective_required_work_minutes int NOT NULL,
        required_work_minutes int NOT NULL,
        is_holiday bit NOT NULL,
        resolved_is_off_day bit NOT NULL,
        PRIMARY KEY CLUSTERED (emp_id, att_date)
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
    ),
    ScheduleCalc AS
    (
        SELECT
            c.emp_id,
            c.att_date,
            c.effective_schedule_source,
            c.effective_shift_id,
            COALESCE(c.effective_time_interval_id, sd.time_interval_id) AS effective_time_interval_id,
            ti.alias AS effective_schedule_alias,
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
            ti.work_type,
            CASE
                WHEN ISNULL(ti.enable_overtime, 0) = 1
                 AND ISNULL(ti.max_ot_limit, 0) > 0
                THEN ti.max_ot_limit
                ELSE 0
            END AS scheduled_ot_cap_minutes,
            CASE
                WHEN c.effective_shift_id IS NOT NULL
                 AND sd.shift_id IS NULL
                THEN 1

                WHEN ISNULL(ti.work_type, 0) IN (1, 2)
                THEN 1

                ELSE 0
            END AS resolved_is_off_day,
            CASE
                WHEN ti.id IS NULL THEN 0
                WHEN c.effective_shift_id IS NOT NULL AND sd.shift_id IS NULL THEN 0
                WHEN ISNULL(ti.work_type, 0) IN (1, 2) THEN 0
                ELSE
                    CASE
                        WHEN ISNULL(ti.duration, 0) - ISNULL(tb.break_minutes, 0) > 0
                        THEN ISNULL(ti.duration, 0) - ISNULL(tb.break_minutes, 0)
                        ELSE 0
                    END
            END AS effective_required_work_minutes
        FROM Chosen c
        OUTER APPLY
        (
            SELECT TOP (1) sd.*
            FROM dbo.att_shiftdetail sd
            WHERE sd.shift_id = c.effective_shift_id
              AND sd.day_index = c.resolved_day_index
            ORDER BY sd.id
        ) sd
        LEFT JOIN dbo.att_timeinterval ti
            ON ti.id = COALESCE(c.effective_time_interval_id, sd.time_interval_id)
        LEFT JOIN #TimeIntervalBreaks tb
            ON tb.timeinterval_id = COALESCE(c.effective_time_interval_id, sd.time_interval_id)
    )
    INSERT INTO #ResolvedSchedule
    SELECT
        sc.emp_id,
        sc.att_date,
        sc.effective_schedule_source,
        sc.effective_shift_id,
        sc.effective_time_interval_id,
        sc.effective_schedule_alias,
        sc.effective_scheduled_in_datetime,
        sc.effective_scheduled_out_datetime,
        sc.use_mode,
        sc.work_type,
        sc.scheduled_ot_cap_minutes,
        sc.effective_required_work_minutes,
        CASE
            WHEN h.id IS NOT NULL
             AND NOT (sc.effective_schedule_source = 'Temporary' AND sc.effective_required_work_minutes > 0)
            THEN 0

            WHEN sc.resolved_is_off_day = 1
             AND sc.effective_required_work_minutes <= 0
            THEN 0

            WHEN sc.effective_schedule_source = 'Temporary'
             AND sc.effective_required_work_minutes = 0
            THEN 0

            WHEN ISNULL(sc.use_mode, 0) = 1
             AND ISNULL(ti.work_time_duration, 0) > 0
            THEN ti.work_time_duration

            WHEN sc.effective_required_work_minutes > 0
            THEN
                CASE
                    WHEN sc.effective_required_work_minutes - sc.scheduled_ot_cap_minutes > 0
                    THEN sc.effective_required_work_minutes - sc.scheduled_ot_cap_minutes
                    ELSE 0
                END

            ELSE 0
        END AS required_work_minutes,
        CAST(CASE WHEN h.id IS NULL THEN 0 ELSE 1 END AS bit) AS is_holiday,
        CAST(sc.resolved_is_off_day AS bit) AS resolved_is_off_day
    FROM ScheduleCalc sc
    INNER JOIN #EmployeeDates ed
        ON ed.emp_id = sc.emp_id
       AND ed.att_date = sc.att_date
    LEFT JOIN dbo.att_timeinterval ti
        ON ti.id = sc.effective_time_interval_id
    OUTER APPLY
    (
        SELECT TOP (1) h.id
        FROM dbo.att_holiday h
        WHERE sc.att_date >= h.start_date
          AND sc.att_date <= h.end_date
          AND (
                (h.att_group_id IS NULL AND h.department_id IS NULL)
                OR h.att_group_id = ed.group_id
                OR h.department_id = ed.department_id
              )
        ORDER BY h.id
    ) h;

    CREATE TABLE #PunchAgg
    (
        emp_id int NOT NULL,
        att_date date NOT NULL,
        raw_punch_count int NOT NULL,
        first_raw_punch_time datetime2(7) NULL,
        last_raw_punch_time datetime2(7) NULL,
        PRIMARY KEY CLUSTERED (emp_id, att_date)
    );

    INSERT INTO #PunchAgg
    SELECT
        rs.emp_id,
        rs.att_date,
        COUNT(t.id) AS raw_punch_count,
        MIN(t.punch_time) AS first_raw_punch_time,
        MAX(t.punch_time) AS last_raw_punch_time
    FROM #ResolvedSchedule rs
    LEFT JOIN dbo.iclock_transaction t
        ON t.emp_id = rs.emp_id
       AND t.punch_time >= DATEADD(HOUR, 3, CAST(rs.att_date AS datetime2(7)))
       AND t.punch_time < DATEADD(HOUR, 3, DATEADD(DAY, 1, CAST(rs.att_date AS datetime2(7))))
    GROUP BY
        rs.emp_id,
        rs.att_date;

    CREATE TABLE #ApprovedLeaves
    (
        emp_id int NOT NULL,
        att_date date NOT NULL,
        leave_days decimal(10,2) NOT NULL,
        PRIMARY KEY CLUSTERED (emp_id, att_date)
    );

    CREATE TABLE #ApprovedLeaveTypes
    (
        emp_id int NOT NULL,
        att_date date NOT NULL,
        leave_instance_id int NOT NULL,
        leave_type nvarchar(50) NOT NULL,
        leave_days decimal(10,2) NOT NULL,
        PRIMARY KEY CLUSTERED (emp_id, att_date, leave_instance_id, leave_type)
    );

    ;WITH ApprovedLeaveDaily AS
    (
        SELECT
            rs.emp_id,
            rs.att_date,
            wi.id AS leave_instance_id,
            CAST(ISNULL(pc.name, ISNULL(pc.code, N'Approved Leave')) AS nvarchar(50)) AS leave_type,
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
              ) AS leave_days
        FROM #ResolvedSchedule rs
        INNER JOIN dbo.workflow_workflowinstance wi
            ON wi.employee_id = rs.emp_id
        INNER JOIN dbo.att_leave l
            ON l.workflowinstance_ptr_id = wi.id
        LEFT JOIN dbo.att_paycode pc
            ON pc.id = l.pay_code_id
        WHERE ISNULL(wi.approval_status, 0) = 2
          AND l.start_time < DATEADD(DAY, 1, CAST(rs.att_date AS datetime2(0)))
          AND l.end_time > CAST(rs.att_date AS datetime2(0))
    )
    INSERT INTO #ApprovedLeaveTypes
    SELECT
        ald.emp_id,
        ald.att_date,
        ald.leave_instance_id,
        ald.leave_type,
        CAST(
            CASE
                WHEN SUM(ISNULL(ald.leave_days, 0)) > 1 THEN 1
                ELSE SUM(ISNULL(ald.leave_days, 0))
            END
            AS decimal(10,2)
        ) AS leave_days
    FROM ApprovedLeaveDaily ald
    GROUP BY
        ald.emp_id,
        ald.att_date,
        ald.leave_instance_id,
        ald.leave_type;

    INSERT INTO #ApprovedLeaves
    SELECT
        alt.emp_id,
        alt.att_date,
        CAST(
            CASE
                WHEN SUM(ISNULL(alt.leave_days, 0)) > 1 THEN 1
                ELSE SUM(ISNULL(alt.leave_days, 0))
            END
            AS decimal(10,2)
        ) AS leave_days
    FROM #ApprovedLeaveTypes alt
    GROUP BY
        alt.emp_id,
        alt.att_date;

    ;WITH AbsenceRows AS
    (
        SELECT
            ed.att_date,
            ed.emp_id,
            ed.emp_code,
            ed.employee_name,
            ed.department_id,
            ed.dept_code,
            ed.dept_name,
            ed.group_id,
            ed.group_code,
            ed.group_name,
            rs.effective_schedule_source,
            rs.effective_schedule_alias,
            rs.effective_scheduled_in_datetime,
            rs.effective_scheduled_out_datetime,
            RIGHT('0' + CAST(DATEPART(HOUR, rs.effective_scheduled_in_datetime) AS varchar(2)), 2)
                + ':' + RIGHT('0' + CAST(DATEPART(MINUTE, rs.effective_scheduled_in_datetime) AS varchar(2)), 2)
                + ':' + RIGHT('0' + CAST(DATEPART(SECOND, rs.effective_scheduled_in_datetime) AS varchar(2)), 2) AS scheduled_in,
            RIGHT('0' + CAST(DATEPART(HOUR, rs.effective_scheduled_out_datetime) AS varchar(2)), 2)
                + ':' + RIGHT('0' + CAST(DATEPART(MINUTE, rs.effective_scheduled_out_datetime) AS varchar(2)), 2)
                + ':' + RIGHT('0' + CAST(DATEPART(SECOND, rs.effective_scheduled_out_datetime) AS varchar(2)), 2) AS scheduled_out,
            rs.required_work_minutes,
            pa.raw_punch_count,
            pa.first_raw_punch_time,
            pa.last_raw_punch_time,
            alt.leave_instance_id,
            ISNULL(alt.leave_type, N'No Approved Leave') AS leave_type,
            ISNULL(alt.leave_days, 0) AS approved_leave_days,
            rs.is_holiday,
            rs.resolved_is_off_day
        FROM #EmployeeDates ed
        INNER JOIN #ResolvedSchedule rs
            ON rs.emp_id = ed.emp_id
           AND rs.att_date = ed.att_date
        INNER JOIN #PunchAgg pa
            ON pa.emp_id = ed.emp_id
           AND pa.att_date = ed.att_date
        LEFT JOIN #ApprovedLeaves al
            ON al.emp_id = ed.emp_id
           AND al.att_date = ed.att_date
        LEFT JOIN #ApprovedLeaveTypes alt
            ON alt.emp_id = ed.emp_id
           AND alt.att_date = ed.att_date
        WHERE rs.required_work_minutes > 0
          AND pa.raw_punch_count = 0
          AND (
                @ExcludeApprovedLeaves = 0
                OR ISNULL(al.leave_days, 0) <= 0
              )
    ),
    NumberedAbsences AS
    (
        SELECT
            ar.*,
            LAG(ar.att_date) OVER
            (
                PARTITION BY
                    ar.emp_id,
                    ar.leave_type,
                    ISNULL(ar.leave_instance_id, -1)
                ORDER BY ar.att_date
            ) AS previous_absent_date
        FROM AbsenceRows ar
    ),
    GroupedAbsences AS
    (
        SELECT
            na.*,
            CASE
                WHEN na.previous_absent_date IS NULL THEN 1
                WHEN DATEDIFF(DAY, na.previous_absent_date, na.att_date) = 1 THEN 0
                WHEN NOT EXISTS
                (
                    SELECT 1
                    FROM #EmployeeDates gap_ed
                    INNER JOIN #ResolvedSchedule gap_rs
                        ON gap_rs.emp_id = gap_ed.emp_id
                       AND gap_rs.att_date = gap_ed.att_date
                    WHERE gap_ed.emp_id = na.emp_id
                      AND gap_ed.att_date > na.previous_absent_date
                      AND gap_ed.att_date < na.att_date
                      AND gap_rs.required_work_minutes > 0
                      AND ISNULL(gap_rs.is_holiday, 0) = 0
                      AND ISNULL(gap_rs.resolved_is_off_day, 0) = 0
                ) THEN 0
                ELSE 1
            END AS absence_group_start
        FROM NumberedAbsences na
    ),
    AbsenceGroups AS
    (
        SELECT
            ga.*,
            CASE
                WHEN ga.leave_instance_id IS NOT NULL
                THEN 'L:' + CAST(ga.leave_instance_id AS varchar(20))
                ELSE
                    'A:' + CAST(
                        SUM(ga.absence_group_start) OVER
                        (
                            PARTITION BY ga.emp_id, ga.leave_type
                            ORDER BY ga.att_date
                            ROWS UNBOUNDED PRECEDING
                        )
                        AS varchar(20)
                    )
            END AS absence_group_key
        FROM GroupedAbsences ga
    ),
    AbsenceGroupBounds AS
    (
        SELECT
            ag.emp_id,
            ag.emp_code,
            ag.employee_name,
            ag.department_id,
            ag.dept_code,
            ag.dept_name,
            ag.group_id,
            ag.group_code,
            ag.group_name,
            ag.leave_type,
            ag.absence_group_key,
            MIN(ag.att_date) AS work_absent_from,
            MAX(ag.att_date) AS work_absent_to
        FROM AbsenceGroups ag
        GROUP BY
            ag.emp_id,
            ag.emp_code,
            ag.employee_name,
            ag.department_id,
            ag.dept_code,
            ag.dept_name,
            ag.group_id,
            ag.group_code,
            ag.group_name,
            ag.leave_type,
            ag.absence_group_key
    ),
    AbsenceGroupDeductionBounds AS
    (
        SELECT
            agb.*,
            ISNULL(
                DATEADD(DAY, -1, blocker.first_blocker_date),
                @DateToValue
            ) AS deductible_absent_to
        FROM AbsenceGroupBounds agb
        OUTER APPLY
        (
            SELECT MIN(ed.att_date) AS first_blocker_date
            FROM #EmployeeDates ed
            INNER JOIN #ResolvedSchedule rs
                ON rs.emp_id = ed.emp_id
               AND rs.att_date = ed.att_date
            INNER JOIN #PunchAgg pa
                ON pa.emp_id = ed.emp_id
               AND pa.att_date = ed.att_date
            WHERE ed.emp_id = agb.emp_id
              AND ed.att_date > agb.work_absent_to
              AND ed.att_date <= @DateToValue
              AND NOT
              (
                    (
                        ISNULL(rs.is_holiday, 0) = 1
                        OR ISNULL(rs.resolved_is_off_day, 0) = 1
                        OR ISNULL(rs.required_work_minutes, 0) <= 0
                    )
                    AND ISNULL(pa.raw_punch_count, 0) = 0
              )
        ) blocker
    )
    SELECT
        CAST(YEAR(MIN(agdb.work_absent_from)) AS varchar(4))
            + '-' + RIGHT('0' + CAST(MONTH(MIN(agdb.work_absent_from)) AS varchar(2)), 2)
            + '-' + RIGHT('0' + CAST(DAY(MIN(agdb.work_absent_from)) AS varchar(2)), 2) AS DateAbsentFrom,
        CAST(YEAR(MAX(agdb.deductible_absent_to)) AS varchar(4))
            + '-' + RIGHT('0' + CAST(MONTH(MAX(agdb.deductible_absent_to)) AS varchar(2)), 2)
            + '-' + RIGHT('0' + CAST(DAY(MAX(agdb.deductible_absent_to)) AS varchar(2)), 2) AS DateAbsentTo,
        COUNT(*) AS AbsentDays,
        DATEDIFF(DAY, MIN(agdb.work_absent_from), MAX(agdb.deductible_absent_to)) + 1 AS CalendarDays,
        DATEDIFF(DAY, MIN(agdb.work_absent_from), MAX(agdb.deductible_absent_to)) + 1 AS DeductibleAbsentDays,
        na.emp_id AS EmployeeID,
        na.emp_code AS EmployeeCode,
        na.employee_name AS EmployeeName,
        na.department_id AS DepartmentID,
        na.dept_code AS DepartmentCode,
        na.dept_name AS DepartmentName,
        na.group_id AS GroupID,
        na.group_code AS GroupCode,
        na.group_name AS GroupName,
        na.leave_type AS LeaveType,
        CASE
            WHEN MIN(na.effective_schedule_source) = MAX(na.effective_schedule_source)
            THEN MIN(na.effective_schedule_source)
            ELSE 'Multiple'
        END AS EffectiveScheduleSource,
        CASE
            WHEN MIN(na.effective_schedule_alias) = MAX(na.effective_schedule_alias)
            THEN MIN(na.effective_schedule_alias)
            ELSE N'Multiple'
        END AS ScheduleAlias,
        CAST(YEAR(MIN(na.effective_scheduled_in_datetime)) AS varchar(4))
            + '-' + RIGHT('0' + CAST(MONTH(MIN(na.effective_scheduled_in_datetime)) AS varchar(2)), 2)
            + '-' + RIGHT('0' + CAST(DAY(MIN(na.effective_scheduled_in_datetime)) AS varchar(2)), 2)
            + ' ' + RIGHT('0' + CAST(DATEPART(HOUR, MIN(na.effective_scheduled_in_datetime)) AS varchar(2)), 2)
            + ':' + RIGHT('0' + CAST(DATEPART(MINUTE, MIN(na.effective_scheduled_in_datetime)) AS varchar(2)), 2)
            + ':' + RIGHT('0' + CAST(DATEPART(SECOND, MIN(na.effective_scheduled_in_datetime)) AS varchar(2)), 2) AS ScheduledInDateTime,
        CAST(YEAR(MAX(na.effective_scheduled_out_datetime)) AS varchar(4))
            + '-' + RIGHT('0' + CAST(MONTH(MAX(na.effective_scheduled_out_datetime)) AS varchar(2)), 2)
            + '-' + RIGHT('0' + CAST(DAY(MAX(na.effective_scheduled_out_datetime)) AS varchar(2)), 2)
            + ' ' + RIGHT('0' + CAST(DATEPART(HOUR, MAX(na.effective_scheduled_out_datetime)) AS varchar(2)), 2)
            + ':' + RIGHT('0' + CAST(DATEPART(MINUTE, MAX(na.effective_scheduled_out_datetime)) AS varchar(2)), 2)
            + ':' + RIGHT('0' + CAST(DATEPART(SECOND, MAX(na.effective_scheduled_out_datetime)) AS varchar(2)), 2) AS ScheduledOutDateTime,
        CASE
            WHEN MIN(na.scheduled_in) = MAX(na.scheduled_in)
            THEN MIN(na.scheduled_in)
            ELSE 'Multiple'
        END AS ScheduledIn,
        CASE
            WHEN MIN(na.scheduled_out) = MAX(na.scheduled_out)
            THEN MIN(na.scheduled_out)
            ELSE 'Multiple'
        END AS ScheduledOut,
        CAST(SUM(na.required_work_minutes) / 60.0 AS decimal(10,2)) AS RequiredHours,
        SUM(na.required_work_minutes) AS RequiredMinutes,
        SUM(na.raw_punch_count) AS RawPunchCount,
        CASE
            WHEN MIN(na.first_raw_punch_time) IS NULL THEN NULL
            ELSE
                CAST(YEAR(MIN(na.first_raw_punch_time)) AS varchar(4))
                + '-' + RIGHT('0' + CAST(MONTH(MIN(na.first_raw_punch_time)) AS varchar(2)), 2)
                + '-' + RIGHT('0' + CAST(DAY(MIN(na.first_raw_punch_time)) AS varchar(2)), 2)
                + ' ' + RIGHT('0' + CAST(DATEPART(HOUR, MIN(na.first_raw_punch_time)) AS varchar(2)), 2)
                + ':' + RIGHT('0' + CAST(DATEPART(MINUTE, MIN(na.first_raw_punch_time)) AS varchar(2)), 2)
                + ':' + RIGHT('0' + CAST(DATEPART(SECOND, MIN(na.first_raw_punch_time)) AS varchar(2)), 2)
        END AS FirstRawPunchTime,
        CASE
            WHEN MAX(na.last_raw_punch_time) IS NULL THEN NULL
            ELSE
                CAST(YEAR(MAX(na.last_raw_punch_time)) AS varchar(4))
                + '-' + RIGHT('0' + CAST(MONTH(MAX(na.last_raw_punch_time)) AS varchar(2)), 2)
                + '-' + RIGHT('0' + CAST(DAY(MAX(na.last_raw_punch_time)) AS varchar(2)), 2)
                + ' ' + RIGHT('0' + CAST(DATEPART(HOUR, MAX(na.last_raw_punch_time)) AS varchar(2)), 2)
                + ':' + RIGHT('0' + CAST(DATEPART(MINUTE, MAX(na.last_raw_punch_time)) AS varchar(2)), 2)
                + ':' + RIGHT('0' + CAST(DATEPART(SECOND, MAX(na.last_raw_punch_time)) AS varchar(2)), 2)
        END AS LastRawPunchTime,
        CAST(SUM(na.approved_leave_days) AS decimal(10,2)) AS ApprovedLeaveDays,
        CAST(MAX(CAST(na.is_holiday AS int)) AS bit) AS IsHoliday,
        CAST(MAX(CAST(na.resolved_is_off_day AS int)) AS bit) AS IsResolvedOffDay
    FROM AbsenceGroups na
    INNER JOIN AbsenceGroupDeductionBounds agdb
        ON agdb.emp_id = na.emp_id
       AND agdb.emp_code = na.emp_code
       AND ISNULL(agdb.employee_name, N'') = ISNULL(na.employee_name, N'')
       AND ISNULL(agdb.department_id, -1) = ISNULL(na.department_id, -1)
       AND ISNULL(agdb.dept_code, N'') = ISNULL(na.dept_code, N'')
       AND ISNULL(agdb.dept_name, N'') = ISNULL(na.dept_name, N'')
       AND ISNULL(agdb.group_id, -1) = ISNULL(na.group_id, -1)
       AND ISNULL(agdb.group_code, N'') = ISNULL(na.group_code, N'')
       AND ISNULL(agdb.group_name, N'') = ISNULL(na.group_name, N'')
       AND agdb.leave_type = na.leave_type
       AND agdb.absence_group_key = na.absence_group_key
    GROUP BY
        na.emp_id,
        na.emp_code,
        na.employee_name,
        na.department_id,
        na.dept_code,
        na.dept_name,
        na.group_id,
        na.group_code,
        na.group_name,
        na.leave_type,
        na.absence_group_key
    ORDER BY
        na.emp_code,
        MIN(na.att_date),
        na.dept_name,
        na.group_name;
END;
