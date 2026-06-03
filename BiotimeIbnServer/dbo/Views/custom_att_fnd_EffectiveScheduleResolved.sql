




CREATE VIEW [dbo].[custom_att_fnd_EffectiveScheduleResolved]
AS
WITH Numbers AS
(
    SELECT TOP (4000)
        ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS n
    FROM
    (
        SELECT 1 AS n FROM (VALUES (0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) AS a(n)
        CROSS JOIN (VALUES (0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) AS b(n)
        CROSS JOIN (VALUES (0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) AS c(n)
        CROSS JOIN (VALUES (0),(0),(0),(0),(0),(0),(0),(0),(0),(0)) AS d(n)
    ) AS tally
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
    SELECT *
    FROM Ranked
    WHERE rn = 1
),

BaseCandidates AS
(
    SELECT * FROM EmployeeSchedule
    UNION ALL
    SELECT * FROM GroupSchedule
    UNION ALL
    SELECT * FROM DepartmentSchedule
),

BaseRanked AS
(
    SELECT
        bc.*,
        ROW_NUMBER() OVER
        (
            PARTITION BY bc.emp_id, bc.att_date
            ORDER BY bc.source_priority, bc.source_row_id DESC
        ) AS rn
    FROM BaseCandidates bc
),

BaseChosen AS
(
    SELECT *
    FROM BaseRanked
    WHERE rn = 1
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
			THEN
				(
					(
						(
							DATEDIFF(
								DAY,
								DATEADD(
									DAY,
									-((DATEDIFF(DAY, '19000101', c.schedule_anchor_date) % 7 + 7) % 7),
									c.schedule_anchor_date
								),
								c.att_date
							) / 7
						)
						% ISNULL(sh.shift_cycle, 1)
					) * 7
				+
				((DATEDIFF(DAY, '19000101', c.att_date) % 7 + 7) % 7)
				+ 1
			)
			% (ISNULL(sh.shift_cycle, 1) * 7)

            ELSE
                (
                    DATEDIFF(DAY, '19000107', c.att_date) % 7 + 7
                ) % 7
        END AS resolved_day_index
    FROM Chosen c
    LEFT JOIN dbo.att_attshift sh
        ON sh.id = c.effective_shift_id
),

BaseWithShift AS
(
    SELECT
        bc.emp_id,
        bc.att_date,
        bc.effective_schedule_source AS base_schedule_source,
        bc.effective_shift_id AS base_shift_id,
        bc.effective_time_interval_id AS base_time_interval_id,
        bc.schedule_anchor_date,
        ISNULL(sh.shift_cycle, 1) AS shift_cycle,

        CASE
            WHEN bc.effective_shift_id IS NULL THEN NULL

            WHEN ISNULL(sh.shift_cycle, 1) > 1
			THEN
				(
					(
						(
							DATEDIFF(
								DAY,
								DATEADD(
									DAY,
									-((DATEDIFF(DAY, '19000101', bc.schedule_anchor_date) % 7 + 7) % 7),
									bc.schedule_anchor_date
								),
								bc.att_date
							) / 7
						)
						% ISNULL(sh.shift_cycle, 1)
					) * 7
				+
				((DATEDIFF(DAY, '19000101', bc.att_date) % 7 + 7) % 7)
				+ 1
			)
			% (ISNULL(sh.shift_cycle, 1) * 7)

            ELSE
                (
                    DATEDIFF(DAY, '19000107', bc.att_date) % 7 + 7
                ) % 7
        END AS base_day_index
    FROM BaseChosen bc
    LEFT JOIN dbo.att_attshift sh
        ON sh.id = bc.effective_shift_id
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

SELECT
    cws.emp_id,
    cws.att_date,

    cws.effective_schedule_source,
    cws.effective_shift_id,
    COALESCE(cws.effective_time_interval_id, sd_pick.time_interval_id) AS effective_time_interval_id,

    bws.base_schedule_source,
    bws.base_shift_id,
    COALESCE(bws.base_time_interval_id, sd_base.time_interval_id) AS base_time_interval_id,

    CASE
        WHEN bws.base_shift_id IS NOT NULL
             AND sd_base.shift_id IS NULL
        THEN 1

        WHEN ISNULL(ti_base.work_type, 0) IN (1, 2)
        THEN 1

        ELSE 0
    END AS base_is_off_day,

    CASE
        WHEN cws.effective_shift_id IS NOT NULL
             AND sd_pick.shift_id IS NULL
        THEN 1

        WHEN ISNULL(ti.work_type, 0) IN (1, 2)
        THEN 1

        ELSE 0
    END AS resolved_is_off_day,

    CASE
        WHEN sd_base.shift_id IS NULL THEN 0
        WHEN ISNULL(ti_base.work_type, 0) IN (1, 2) THEN 0
        ELSE ISNULL(ti_base.duration, 0) - ISNULL(tb_base.break_minutes, 0)
    END AS base_required_work_minutes,

    CASE
        WHEN ISNULL(ti.work_type, 0) IN (1, 2) THEN 0

        WHEN cws.effective_schedule_source = 'Temporary'
        THEN ISNULL(ti.duration, 0) - ISNULL(tb.break_minutes, 0)

        WHEN sd_pick.shift_id IS NOT NULL
        THEN ISNULL(ti.duration, 0) - ISNULL(tb.break_minutes, 0)

        ELSE 0
    END AS effective_required_work_minutes,

    ti.in_time AS effective_scheduled_in_time,

    CAST(
        DATEADD(MINUTE, ISNULL(ti.duration, 0), CAST(ti.in_time AS datetime))
        AS time
    ) AS effective_scheduled_out_time,

    CASE
        WHEN DATEDIFF(MINUTE, CAST('00:00:00' AS time), ti.in_time)
           + ISNULL(ti.duration, 0) >= 1440
        THEN 1
        ELSE 0
    END AS effective_cross_day_flag,

    DATEADD(
        MINUTE,
        DATEDIFF(MINUTE, CAST('00:00:00' AS time), ti.in_time),
        CAST(cws.att_date AS datetime)
    ) AS effective_scheduled_in_datetime,

    DATEADD(
        MINUTE,
        DATEDIFF(MINUTE, CAST('00:00:00' AS time), ti.in_time)
          + ISNULL(ti.duration, 0),
        CAST(cws.att_date AS datetime)
    ) AS effective_scheduled_out_datetime

FROM ChosenWithShift cws

LEFT JOIN BaseWithShift bws
    ON bws.emp_id = cws.emp_id
   AND bws.att_date = cws.att_date

OUTER APPLY
(
    SELECT TOP (1) *
    FROM dbo.att_shiftdetail sd
    WHERE sd.shift_id = cws.effective_shift_id
      AND sd.day_index = cws.resolved_day_index
) sd_pick

OUTER APPLY
(
    SELECT TOP (1) *
    FROM dbo.att_shiftdetail sd
    WHERE sd.shift_id = bws.base_shift_id
      AND sd.day_index = bws.base_day_index
) sd_base

LEFT JOIN dbo.att_timeinterval ti
    ON ti.id = COALESCE(cws.effective_time_interval_id, sd_pick.time_interval_id)

LEFT JOIN dbo.att_timeinterval ti_base
    ON ti_base.id = COALESCE(bws.base_time_interval_id, sd_base.time_interval_id)

LEFT JOIN ti_break tb
    ON tb.timeinterval_id = COALESCE(cws.effective_time_interval_id, sd_pick.time_interval_id)

LEFT JOIN ti_break tb_base
    ON tb_base.timeinterval_id = COALESCE(bws.base_time_interval_id, sd_base.time_interval_id);
