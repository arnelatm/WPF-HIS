






CREATE VIEW [dbo].[custom_att_calc_DailyBase]
AS
/*
Layer: Calculation
Role: Base daily attendance dataset combining worked time and resolved schedule

Primary Sources:
- dbo.custom_att_fnd_DailyWorkedMinutes
- dbo.custom_att_fnd_EffectiveScheduleResolved

Purpose:
- Produces one row per employee per day
- Combines:
    • actual worked minutes (from punch processing)
    • scheduled work requirements (from resolved schedule)
- Serves as the foundation for higher-level attendance calculations

Key Outputs:
- effective_required_work_minutes
- recomputed_worked_minutes
- scheduled_ot_cap_minutes
- schedule_source, schedule_type
- date_type (regular / holiday / rest day)

Used by:
- dbo.custom_att_calc_DailyMetrics

Notes:
- No business classification (Present/Absent/OT logic) should be finalized here
- This layer should remain focused on merging time + schedule facts
*/
WITH tc AS
(
    SELECT
        t.emp_id,
        t.att_date,
        MAX(t.date_type) AS payload_date_type,
        MAX(t.present) AS present_flag,
        MAX(t.full_attendance) AS full_attendance_flag,

        MIN(t.check_in) AS scheduled_in,
        MAX(t.check_out) AS scheduled_out,

        SUM(dbo.custom_ExtractPayloadMinutes(t.payload, 'total_ot')) AS payload_ot_minutes,
        SUM(dbo.custom_ExtractPayloadMinutes(t.payload, 'remaining')) AS payload_absence_minutes,
        SUM(dbo.custom_ExtractPayloadMinutes(t.payload, 'worked_hrs'))
            + SUM(dbo.custom_ExtractPayloadMinutes(t.payload, 'remaining')) AS payload_required_work_minutes
    FROM dbo.att_payloadtimecard t
    GROUP BY
        t.emp_id,
        t.att_date
),
dwm AS
(
    SELECT
        d.emp_id,
        d.work_date AS att_date,
        d.first_clock_in,
        d.last_clock_out,
        CAST(d.total_worked_minutes AS decimal(10,2)) AS worked_minutes,
        CAST(d.total_worked_minutes AS decimal(10,2)) AS recomputed_worked_minutes,
        CAST(d.total_worked_minutes / 60.0 AS decimal(10,2)) AS recomputed_worked_hours
    FROM dbo.custom_att_fnd_DailyWorkedMinutes d
),
ti_break AS
(
    SELECT
        tib.timeinterval_id,
        SUM(ISNULL(bt.duration, 0)) AS break_minutes
    FROM dbo.att_timeinterval_break_time tib
    INNER JOIN dbo.att_breaktime bt
        ON tib.breaktime_id = bt.id
    GROUP BY
        tib.timeinterval_id
),
resolved AS
(
    SELECT
        esr.emp_id,
        esr.att_date,
        esr.effective_schedule_source,
        esr.effective_shift_id,
        esr.effective_time_interval_id,
        ISNULL(esr.resolved_is_off_day, 0) AS resolved_is_off_day,

        ti.use_mode,
        ti.duration,
        ti.work_time_duration,
        ti.enable_overtime,
        ti.in_time,
        ISNULL(tb.break_minutes, 0) AS break_minutes,

        DATEADD(
            SECOND,
            DATEDIFF(SECOND, CAST('00:00:00' AS time), ti.in_time),
            CAST(esr.att_date AS datetime2(0))
        ) AS resolved_scheduled_in,

        DATEADD(
            MINUTE,
            ti.duration,
            DATEADD(
                SECOND,
                DATEDIFF(SECOND, CAST('00:00:00' AS time), ti.in_time),
                CAST(esr.att_date AS datetime2(0))
            )
        ) AS resolved_scheduled_out,

		CASE
			WHEN ISNULL(esr.resolved_is_off_day, 0) = 1 THEN 0
			ELSE
				CASE
					WHEN ISNULL(ti.duration, 0) - ISNULL(tb.break_minutes, 0) > 0
						THEN ISNULL(ti.duration, 0) - ISNULL(tb.break_minutes, 0)
					ELSE 0
				END
		END AS resolved_required_work_minutes
    FROM dbo.custom_att_fnd_EffectiveScheduleResolved esr
    LEFT JOIN dbo.att_timeinterval ti
        ON esr.effective_time_interval_id = ti.id
    LEFT JOIN ti_break tb
        ON ti.id = tb.timeinterval_id
),
calc AS
(
    SELECT
        tc.emp_id,
        tc.att_date,
		CASE
			WHEN ISNULL(r.resolved_is_off_day, 0) = 1 THEN 2
			WHEN h.id IS NOT NULL THEN 1
			ELSE 0
		END AS date_type,
        tc.present_flag,
        tc.full_attendance_flag,
        tc.scheduled_in,
        tc.scheduled_out,
        ISNULL(r.resolved_is_off_day, 0) AS resolved_is_off_day,
        dwm.first_clock_in,
        dwm.last_clock_out,

        ISNULL(dwm.worked_minutes, 0) AS worked_minutes,
        ISNULL(dwm.recomputed_worked_minutes, 0) AS recomputed_worked_minutes,
        ISNULL(dwm.recomputed_worked_hours, 0) AS recomputed_worked_hours,

        r.use_mode,
        ISNULL(r.duration, 0) AS temp_duration_minutes,
        ISNULL(r.work_time_duration, 0) AS temp_work_time_duration,
        ISNULL(r.break_minutes, 0) AS temp_break_minutes,
        ISNULL(r.enable_overtime, 0) AS ot_eligible_flag,

        CASE
            WHEN r.effective_schedule_source = 'Temporary' THEN 1
            ELSE 0
        END AS has_temp_schedule,

        CASE
            WHEN r.effective_schedule_source IN ('Employee', 'Group', 'Department') THEN 1
            ELSE 0
        END AS has_assigned_schedule,

        ISNULL(r.effective_schedule_source, 'Unscheduled') AS schedule_source,

        r.resolved_scheduled_in AS effective_scheduled_in,
        r.resolved_scheduled_out AS effective_scheduled_out,

        ISNULL(r.resolved_required_work_minutes, 0) AS effective_required_work_minutes,

        ISNULL(tc.payload_ot_minutes, 0) AS payload_ot_minutes,
        ISNULL(tc.payload_absence_minutes, 0) AS payload_absence_minutes,
        ISNULL(tc.payload_required_work_minutes, 0) AS payload_required_work_minutes
    FROM tc
    LEFT JOIN dwm
        ON tc.emp_id = dwm.emp_id
       AND tc.att_date = dwm.att_date
    LEFT JOIN resolved r
        ON tc.emp_id = r.emp_id
       AND tc.att_date = r.att_date
    LEFT JOIN dbo.att_attemployee ae
        ON tc.emp_id = ae.emp_id
    LEFT JOIN dbo.personnel_employee pe
        ON tc.emp_id = pe.id
    OUTER APPLY
	(
		SELECT TOP (1)
			h.id
		FROM dbo.att_holiday h
		WHERE tc.att_date >= CAST(h.start_date AS date)
		  AND tc.att_date <= CAST(h.end_date AS date)
		  AND (
				h.att_group_id = ae.group_id
				OR h.department_id = pe.department_id
			  )
		ORDER BY h.id
	) h
),
logic AS
(
    SELECT
        c.*,

        CASE
            WHEN c.effective_required_work_minutes > 0 THEN
                CASE
                    WHEN c.payload_ot_minutes > c.effective_required_work_minutes
                        THEN c.effective_required_work_minutes
                    WHEN c.payload_ot_minutes > 0
                        THEN c.payload_ot_minutes
                    ELSE 0
                END
            ELSE
                CASE
                    WHEN c.payload_ot_minutes > 0
                        THEN c.payload_ot_minutes
                    ELSE 0
                END
        END AS scheduled_ot_cap_minutes
    FROM calc c
)
SELECT
    l.emp_id,
    l.att_date,
    l.date_type,
    l.present_flag,
    l.full_attendance_flag,

    l.scheduled_in,
    l.scheduled_out,

    l.first_clock_in,
    l.last_clock_out,

    l.worked_minutes,

    -- Corrected OT:
    -- 1) If no OT cap/configured OT -> 0
    -- 2) If zero-required day -> all worked time is OT, capped by timetable OT cap
    -- 3) Else -> OT is work beyond regular threshold, capped by timetable OT cap
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
        END
        AS decimal(10,2)
    ) AS ot_minutes,

    -- Absence is against regular required minutes only
    CAST(
        CASE
            WHEN l.schedule_source = 'Temporary'
                THEN 0
            WHEN
                CASE
                    WHEN l.effective_required_work_minutes > 0
                        THEN
                            CASE
                                WHEN l.effective_required_work_minutes - l.scheduled_ot_cap_minutes > 0
                                    THEN l.effective_required_work_minutes - l.scheduled_ot_cap_minutes
                                ELSE 0
                            END
                    ELSE 0
                END
                > l.recomputed_worked_minutes
            THEN
                CASE
                    WHEN l.effective_required_work_minutes > 0
                        THEN
                            CASE
                                WHEN l.effective_required_work_minutes - l.scheduled_ot_cap_minutes > 0
                                    THEN l.effective_required_work_minutes - l.scheduled_ot_cap_minutes
                                ELSE 0
                            END
                    ELSE 0
                END
                - l.recomputed_worked_minutes
            ELSE 0
        END
        AS decimal(10,2)
    ) AS absence_minutes,

    -- Regular required minutes only, not total payable minutes
    CAST(
        CASE
            WHEN l.schedule_source = 'Temporary'
                THEN 0
            WHEN l.effective_required_work_minutes > 0
                THEN
                    CASE
                        WHEN l.effective_required_work_minutes - l.scheduled_ot_cap_minutes > 0
                            THEN l.effective_required_work_minutes - l.scheduled_ot_cap_minutes
                        ELSE 0
                    END
            ELSE 0
        END
        AS decimal(10,2)
    ) AS required_work_minutes,

    l.recomputed_worked_minutes,
    l.recomputed_worked_hours,

    l.use_mode,
    l.temp_duration_minutes,
    l.temp_work_time_duration,
    l.temp_break_minutes,
    l.ot_eligible_flag,
    l.has_temp_schedule,
    l.has_assigned_schedule,
    l.schedule_source,
    l.effective_scheduled_in,
    l.effective_scheduled_out,
    l.resolved_is_off_day,
	l.scheduled_ot_cap_minutes,
    l.effective_required_work_minutes
FROM logic l;
