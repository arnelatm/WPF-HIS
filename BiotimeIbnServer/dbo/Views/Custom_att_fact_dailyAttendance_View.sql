CREATE VIEW [dbo].[Custom_att_fact_dailyAttendance_View]
AS
WITH Base AS
(
    SELECT
        f.emp_id,
        CONCAT(e.emp_code, '-', e.first_name) AS EmployeeIdCodeName,
        f.att_date,
        ti.alias AS effective_timetable_name,
        f.daily_status,
        f.attendance_status,
        f.anomaly_flag,
        f.needs_payroll_review,
        f.worked_hours,
        f.regular_worked_hours,
        f.ot_hours,
        f.schedule_label,
        f.punch_status,
        f.late_minutes,
        f.early_out_minutes,
        f.shortfall_hours,
        f.excess_hours,
        f.recomputed_absence_hours,
        f.actual_late_minutes,
        f.actual_early_out_minutes,
        f.first_clock_in,
        f.last_clock_out,
        f.year_no,
        f.month_no,
        es.effective_time_interval_id,
        es.effective_scheduled_in_datetime,
        es.effective_scheduled_out_datetime,
        f.business_day_type,
        f.anomaly_group,
        f.required_scheduled_hours,
        f.recomputed_worked_minutes,
        f.regular_worked_minutes AS regular_worked_minutes_decimal,
        f.ot_minutes,
        f.work_completion_pct,
        f.date_type,
        f.[Leaves],
        f.comp_leave_eligible_flag,
        f.comp_leave_minutes,
        f.comp_leave_hours,
        f.actual_excess_minutes,
        f.excess_minutes,
        f.shortfall_minutes,
        f.reconciliation_status,
        f.reconciliation_variance_minutes,
        f.work_gap_minutes,
        f.corrected,
        f.effective_punch_in1,
        f.effective_punch_out1,
        f.effective_punch_in2,
        f.effective_punch_out2,
        ti.in_time,
        ti.use_mode
    FROM dbo.custom_att_fact_DailyAttendance f
    LEFT JOIN dbo.personnel_employee e
        ON e.id = f.emp_id
    LEFT JOIN dbo.custom_att_fnd_EffectiveScheduleResolved es
        ON es.emp_id = f.emp_id
       AND es.att_date = f.att_date
    LEFT JOIN dbo.att_timeinterval ti
        ON ti.id = es.effective_time_interval_id
),
WorkDays AS
(
    SELECT
        b.emp_id,
        b.att_date,
        b.effective_time_interval_id,
        b.effective_scheduled_in_datetime AS schedule_start_datetime,
        b.effective_scheduled_out_datetime AS schedule_end_datetime,
        b.in_time
    FROM Base b
    WHERE ISNULL(b.required_scheduled_hours, 0) > 0
      AND ISNULL(b.use_mode, 0) <> 1
      AND b.effective_scheduled_in_datetime IS NOT NULL
      AND b.effective_scheduled_out_datetime IS NOT NULL
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
),
ScheduleSegments AS
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
),
SegmentMatches AS
(
    SELECT
        ss.emp_id,
        ss.att_date,
        ss.segment_no,
        ss.segment_start_datetime,
        ss.segment_end_datetime,
        si.in_time,
        so.out_time
    FROM ScheduleSegments ss
    OUTER APPLY
    (
        SELECT TOP (1)
            cp.punch_time AS in_time
        FROM dbo.custom_att_fnd_CorrectedPunches cp
        WHERE cp.emp_id = ss.emp_id
          AND cp.work_date = ss.att_date
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
        FROM dbo.custom_att_fnd_CorrectedPunches cp
        WHERE cp.emp_id = ss.emp_id
          AND cp.work_date = ss.att_date
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
),
SegmentAudit AS
(
    SELECT
        sm.emp_id,
        sm.att_date,
        COUNT(*) AS schedule_segment_count,
        SUM(CASE WHEN sm.in_time IS NULL OR sm.out_time IS NULL THEN 1 ELSE 0 END) AS unmatched_segment_count,
        MIN(sm.in_time) AS first_clock_in,
        MAX(sm.out_time) AS last_clock_out,
        SUM(
            CASE
                WHEN sm.in_time IS NOT NULL
                 AND sm.out_time IS NOT NULL
                 AND sm.out_time > sm.in_time
                THEN DATEDIFF(MINUTE, sm.in_time, sm.out_time)
                ELSE 0
            END
        ) AS segment_worked_minutes,
        SUM(
            CASE
                WHEN sm.in_time IS NOT NULL
                 AND sm.out_time IS NOT NULL
                 AND sm.out_time > sm.in_time
                THEN
                    CASE
                        WHEN DATEDIFF(
                                MINUTE,
                                CASE WHEN sm.in_time > sm.segment_start_datetime THEN sm.in_time ELSE sm.segment_start_datetime END,
                                CASE WHEN sm.out_time < sm.segment_end_datetime THEN sm.out_time ELSE sm.segment_end_datetime END
                             ) > 0
                        THEN DATEDIFF(
                                MINUTE,
                                CASE WHEN sm.in_time > sm.segment_start_datetime THEN sm.in_time ELSE sm.segment_start_datetime END,
                                CASE WHEN sm.out_time < sm.segment_end_datetime THEN sm.out_time ELSE sm.segment_end_datetime END
                             )
                        ELSE 0
                    END
                ELSE 0
            END
        ) AS segment_regular_worked_minutes,
        MAX(CASE WHEN sm.segment_no = 1 THEN sm.in_time END) AS effective_punch_in1,
        MAX(CASE WHEN sm.segment_no = 1 THEN sm.out_time END) AS effective_punch_out1,
        MAX(CASE WHEN sm.segment_no = 2 THEN sm.in_time END) AS effective_punch_in2,
        MAX(CASE WHEN sm.segment_no = 2 THEN sm.out_time END) AS effective_punch_out2
    FROM SegmentMatches sm
    GROUP BY
        sm.emp_id,
        sm.att_date
)
SELECT
    b.emp_id,
    b.EmployeeIdCodeName,
    b.att_date,
    b.effective_timetable_name,
    raw_punches.raw_punch_times,
    b.daily_status,
    b.attendance_status,
    b.anomaly_flag,
    b.needs_payroll_review,
    b.worked_hours,
    b.regular_worked_hours,
    b.ot_hours,
    b.schedule_label,
    b.punch_status,
    b.late_minutes,
    b.early_out_minutes,
    b.shortfall_hours,
    b.excess_hours,
    b.recomputed_absence_hours,
    b.actual_late_minutes,
    b.actual_early_out_minutes,
    CASE
        WHEN ISNULL(sa.schedule_segment_count, 1) > 1
         AND ISNULL(sa.unmatched_segment_count, 0) = 0
         AND ISNULL(sa.segment_worked_minutes, 0) > 0
        THEN sa.first_clock_in
        ELSE b.first_clock_in
    END AS first_clock_in,
    CASE
        WHEN ISNULL(sa.schedule_segment_count, 1) > 1
         AND ISNULL(sa.unmatched_segment_count, 0) = 0
         AND ISNULL(sa.segment_worked_minutes, 0) > 0
        THEN sa.last_clock_out
        ELSE b.last_clock_out
    END AS last_clock_out,
    b.year_no,
    b.month_no,
    b.effective_time_interval_id,
    b.effective_scheduled_in_datetime,
    b.effective_scheduled_out_datetime,
    b.business_day_type,
    b.anomaly_group,
    b.required_scheduled_hours,
    CASE
        WHEN ISNULL(sa.schedule_segment_count, 1) > 1
         AND ISNULL(sa.unmatched_segment_count, 0) = 0
         AND ISNULL(sa.segment_worked_minutes, 0) > 0
        THEN CAST(sa.segment_worked_minutes AS decimal(10,2))
        ELSE b.recomputed_worked_minutes
    END AS recomputed_worked_minutes,
    CASE
        WHEN ISNULL(sa.schedule_segment_count, 1) > 1
         AND ISNULL(sa.unmatched_segment_count, 0) = 0
         AND ISNULL(sa.segment_regular_worked_minutes, 0) > 0
        THEN CAST(sa.segment_regular_worked_minutes AS decimal(10,2))
        ELSE b.regular_worked_minutes_decimal
    END AS regular_worked_minutes,
    b.ot_minutes,
    b.work_completion_pct,
    b.date_type,
    b.[Leaves],
    b.comp_leave_eligible_flag,
    b.comp_leave_minutes,
    b.comp_leave_hours,
    b.actual_excess_minutes,
    b.excess_minutes,
    b.shortfall_minutes,
    b.reconciliation_status,
    b.reconciliation_variance_minutes,
    b.work_gap_minutes,
    CAST(
        CASE
            WHEN ISNULL(sa.schedule_segment_count, 1) > 1
             AND ISNULL(sa.unmatched_segment_count, 0) = 0
             AND ISNULL(sa.segment_worked_minutes, 0) > 0
             AND
             (
                 ISNULL(sa.effective_punch_in1, CONVERT(datetime2(7), '19000101')) <> ISNULL(b.effective_punch_in1, CONVERT(datetime2(7), '19000101'))
              OR ISNULL(sa.effective_punch_out1, CONVERT(datetime2(7), '19000101')) <> ISNULL(b.effective_punch_out1, CONVERT(datetime2(7), '19000101'))
              OR ISNULL(sa.effective_punch_in2, CONVERT(datetime2(7), '19000101')) <> ISNULL(b.effective_punch_in2, CONVERT(datetime2(7), '19000101'))
              OR ISNULL(sa.effective_punch_out2, CONVERT(datetime2(7), '19000101')) <> ISNULL(b.effective_punch_out2, CONVERT(datetime2(7), '19000101'))
             )
            THEN 1
            ELSE ISNULL(b.corrected, 0)
        END AS bit
    ) AS corrected,
    CASE
        WHEN ISNULL(sa.schedule_segment_count, 1) > 1
         AND ISNULL(sa.unmatched_segment_count, 0) = 0
         AND ISNULL(sa.segment_worked_minutes, 0) > 0
        THEN sa.effective_punch_in1
        ELSE b.effective_punch_in1
    END AS effective_punch_in1,
    CASE
        WHEN ISNULL(sa.schedule_segment_count, 1) > 1
         AND ISNULL(sa.unmatched_segment_count, 0) = 0
         AND ISNULL(sa.segment_worked_minutes, 0) > 0
        THEN sa.effective_punch_out1
        ELSE b.effective_punch_out1
    END AS effective_punch_out1,
    CASE
        WHEN ISNULL(sa.schedule_segment_count, 1) > 1
         AND ISNULL(sa.unmatched_segment_count, 0) = 0
         AND ISNULL(sa.segment_worked_minutes, 0) > 0
        THEN sa.effective_punch_in2
        ELSE b.effective_punch_in2
    END AS effective_punch_in2,
    CASE
        WHEN ISNULL(sa.schedule_segment_count, 1) > 1
         AND ISNULL(sa.unmatched_segment_count, 0) = 0
         AND ISNULL(sa.segment_worked_minutes, 0) > 0
        THEN sa.effective_punch_out2
        ELSE b.effective_punch_out2
    END AS effective_punch_out2
FROM Base b
LEFT JOIN SegmentAudit sa
    ON sa.emp_id = b.emp_id
   AND sa.att_date = b.att_date
OUTER APPLY
(
    SELECT
        STUFF(
            (
                SELECT
                    ',' + CONVERT(varchar(8), CAST(np.punch_time AS time), 108)
                FROM dbo.custom_att_fnd_NormalizedPunches np
                WHERE np.emp_id = b.emp_id
                  AND np.work_date = b.att_date
                ORDER BY
                    np.punch_time,
                    np.id
                FOR XML PATH('')
            ),
            1,
            1,
            ''
        ) AS raw_punch_times
) raw_punches;

GO
