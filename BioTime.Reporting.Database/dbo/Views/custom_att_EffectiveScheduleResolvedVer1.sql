
CREATE VIEW [dbo].[custom_att_EffectiveScheduleResolvedVer1]
AS
WITH Numbers AS
(
    SELECT TOP (4000)
        ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
    FROM sys.all_objects
),

TemporarySchedule AS
(
    SELECT
        ts.employee_id AS emp_id,
        ts.att_date AS att_date,
        CAST('Temporary' AS varchar(30)) AS effective_schedule_source,
        1 AS source_priority,
        CAST(NULL AS int) AS effective_shift_id,
        ts.time_interval_id AS effective_time_interval_id,
        ts.id AS source_row_id,
        ts.att_date AS schedule_anchor_date
    FROM dbo.att_temporaryschedule ts
    WHERE ISNULL(ts.status, 0) = 0
      AND ts.employee_id IS NOT NULL
      AND ts.att_date IS NOT NULL
),

EmployeeSchedule AS
(
    SELECT
        s.employee_id AS emp_id,
        DATEADD(DAY, n.n, s.start_date) AS att_date,
        CAST('Employee' AS varchar(30)) AS effective_schedule_source,
        2 AS source_priority,
        s.shift_id AS effective_shift_id,
        CAST(NULL AS int) AS effective_time_interval_id,
        s.id AS source_row_id,
        s.start_date AS schedule_anchor_date
    FROM dbo.att_attschedule s
    INNER JOIN Numbers n
        ON DATEADD(DAY, n.n, s.start_date) <= s.end_date
    WHERE s.employee_id IS NOT NULL
      AND s.shift_id IS NOT NULL
),

GroupSchedule AS
(
    SELECT
        ae.emp_id,
        DATEADD(DAY, n.n, gs.start_date) AS att_date,
        CAST('Group' AS varchar(30)) AS effective_schedule_source,
        3 AS source_priority,
        gs.shift_id AS effective_shift_id,
        CAST(NULL AS int) AS effective_time_interval_id,
        gs.id AS source_row_id,
        gs.start_date AS schedule_anchor_date
    FROM dbo.att_groupschedule gs
    INNER JOIN Numbers n
        ON DATEADD(DAY, n.n, gs.start_date) <= gs.end_date
    INNER JOIN dbo.att_attemployee ae
        ON ae.group_id = gs.group_id
    WHERE ISNULL(gs.status, 0) = 0
      AND ae.emp_id IS NOT NULL
      AND gs.shift_id IS NOT NULL
),

DepartmentSchedule AS
(
    SELECT
        e.id AS emp_id,
        DATEADD(DAY, n.n, ds.start_date) AS att_date,
        CAST('Department' AS varchar(30)) AS effective_schedule_source,
        4 AS source_priority,
        ds.shift_id AS effective_shift_id,
        CAST(NULL AS int) AS effective_time_interval_id,
        ds.id AS source_row_id,
        ds.start_date AS schedule_anchor_date
    FROM dbo.att_departmentschedule ds
    INNER JOIN Numbers n
        ON DATEADD(DAY, n.n, ds.start_date) <= ds.end_date
    INNER JOIN dbo.personnel_employee e
        ON e.department_id = ds.department_id
    WHERE ISNULL(ds.status, 0) = 0
      AND e.id IS NOT NULL
      AND ds.shift_id IS NOT NULL
),

AllCandidates AS
(
    SELECT * FROM TemporarySchedule
    UNION ALL
    SELECT * FROM EmployeeSchedule
    UNION ALL
    SELECT * FROM GroupSchedule
    UNION ALL
    SELECT * FROM DepartmentSchedule
),

Ranked AS
(
    SELECT
        ac.*,
        ROW_NUMBER() OVER
        (
            PARTITION BY ac.emp_id, ac.att_date
            ORDER BY ac.source_priority, ac.source_row_id DESC
        ) AS rn
    FROM AllCandidates ac
),

Chosen AS
(
    SELECT
        r.emp_id,
        r.att_date,
        r.effective_schedule_source,
        r.effective_shift_id,
        r.effective_time_interval_id,
        r.schedule_anchor_date
    FROM Ranked r
    WHERE r.rn = 1
),

ChosenWithShift AS
(
    SELECT
        c.emp_id,
        c.att_date,
        c.effective_schedule_source,
        c.effective_shift_id,
        c.effective_time_interval_id,
        c.schedule_anchor_date,
        ISNULL(sh.shift_cycle, 1) AS shift_cycle,
        CASE
            WHEN c.effective_shift_id IS NULL THEN NULL
            WHEN ISNULL(sh.shift_cycle, 1) > 1
                THEN DATEDIFF
                     (
                         DAY,
                         DATEADD(DAY, -((DATEDIFF(DAY, '19000107', c.schedule_anchor_date)) % 7), c.schedule_anchor_date),
                         c.att_date
                     ) % (sh.shift_cycle * 7)
            ELSE DATEDIFF(DAY, '19000107', c.att_date) % 7
        END AS resolved_day_index
    FROM Chosen c
    LEFT JOIN dbo.att_attshift sh
        ON sh.id = c.effective_shift_id
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
)

SELECT
    cws.emp_id,
    cws.att_date,
    cws.effective_schedule_source,
    cws.effective_shift_id,
    COALESCE(cws.effective_time_interval_id, sd_pick.time_interval_id) AS effective_time_interval_id,
    cws.resolved_day_index,
    sd_pick.day_index AS shift_day_index_used,

    CASE
        WHEN cws.effective_schedule_source = 'Temporary'
             AND ISNULL(ti.use_mode, 0) = 1
             AND ISNULL(ti.work_time_duration, 0) = 0
             AND ISNULL(ti.enable_overtime, 0) = 0
        THEN 1

        WHEN cws.effective_schedule_source IN ('Employee', 'Group', 'Department')
             AND sd_pick.shift_id IS NULL
        THEN 1

        ELSE 0
    END AS resolved_is_off_day,

    CASE
        WHEN cws.effective_schedule_source = 'Temporary'
        THEN DATEADD
             (
                 DAY,
                 DATEDIFF(DAY, 0, cws.att_date),
                 CAST(ti.in_time AS datetime)
             )

        WHEN cws.effective_schedule_source IN ('Employee', 'Group', 'Department')
             AND sd_pick.shift_id IS NOT NULL
        THEN DATEADD
             (
                 DAY,
                 DATEDIFF(DAY, 0, cws.att_date),
                 CAST(COALESCE(sd_pick.in_time, ti.in_time) AS datetime)
             )

        ELSE NULL
    END AS effective_scheduled_in,

    CASE
        WHEN cws.effective_schedule_source = 'Temporary'
        THEN DATEADD
             (
                 MINUTE,
                 ISNULL(NULLIF(ti.duration, 0), 0),
                 DATEADD
                 (
                     DAY,
                     DATEDIFF(DAY, 0, cws.att_date),
                     CAST(ti.in_time AS datetime)
                 )
             )

        WHEN cws.effective_schedule_source IN ('Employee', 'Group', 'Department')
             AND sd_pick.shift_id IS NOT NULL
        THEN DATEADD
             (
                 MINUTE,
                 ISNULL(NULLIF(ti.duration, 0), 0),
                 DATEADD
                 (
                     DAY,
                     DATEDIFF(DAY, 0, cws.att_date),
                     CAST(COALESCE(sd_pick.in_time, ti.in_time) AS datetime)
                 )
             )

        ELSE NULL
    END AS effective_scheduled_out,

    CASE
        WHEN cws.effective_schedule_source = 'Temporary'
             AND ISNULL(ti.use_mode, 0) = 1
             AND ISNULL(ti.enable_overtime, 0) = 0
        THEN 0

        WHEN cws.effective_schedule_source IN ('Temporary', 'Employee', 'Group', 'Department')
             AND (
                    cws.effective_schedule_source = 'Temporary'
                 OR sd_pick.shift_id IS NOT NULL
                 )
        THEN
            CASE
                WHEN ISNULL(ti.duration, 0) - ISNULL(tb.break_minutes, 0) < 0 THEN 0
                ELSE ISNULL(ti.duration, 0) - ISNULL(tb.break_minutes, 0)
            END

        ELSE 0
    END AS effective_required_work_minutes

FROM ChosenWithShift cws
OUTER APPLY
(
    SELECT TOP (1)
        sd.shift_id,
        sd.time_interval_id,
        sd.day_index,
        sd.in_time,
        sd.out_time,
        sd.id
    FROM dbo.att_shiftdetail sd
    WHERE sd.shift_id = cws.effective_shift_id
      AND sd.day_index = cws.resolved_day_index
    ORDER BY sd.id DESC
) sd_pick
LEFT JOIN dbo.att_timeinterval ti
    ON ti.id = COALESCE(cws.effective_time_interval_id, sd_pick.time_interval_id)
LEFT JOIN ti_break tb
    ON tb.timeinterval_id = COALESCE(cws.effective_time_interval_id, sd_pick.time_interval_id);