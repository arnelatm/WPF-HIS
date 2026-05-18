








CREATE VIEW [dbo].[custom_att_calc_DailyDayClassification_disabled]
AS
WITH d AS
(
    SELECT
        emp_id,
        att_date,
        date_type,
        base_date_type,
        base_is_off_day,
        resolved_is_off_day,
        schedule_source,
        schedule_type,
        effective_required_work_minutes,
        regular_required_minutes,
        recomputed_worked_minutes,
		first_clock_in,
		last_clock_out,
		punch_count,
        attendance_status,
        anomaly_flag,
        needs_payroll_review
    FROM dbo.custom_att_calc_DailyMetrics
),
x AS
(
    SELECT
        d.*,

        CASE
            WHEN d.schedule_source = 'Temporary'
             AND (d.date_type = 1 OR d.base_date_type = 1)
             AND ISNULL(d.effective_required_work_minutes, 0) > 0
            THEN 1 ELSE 0
        END AS is_holiday_in_lieu_work_day,

		CASE
			WHEN (d.date_type = 1 OR d.base_date_type = 1)

			AND (
				-- TRUE HOLIDAY CONDITIONS ONLY

				-- 1. Unscheduled → always holiday
				d.schedule_source = 'Unscheduled'

				OR

				-- 2. Worked day → holiday (OT)
				ISNULL(d.recomputed_worked_minutes, 0) > 0

				OR

				-- 3. Required work exists (rare but valid)
				ISNULL(d.effective_required_work_minutes, 0) > 0
			)

			AND NOT (
				-- Exclude in-lieu replacement
				d.schedule_source = 'Temporary'
				AND ISNULL(d.effective_required_work_minutes, 0) > 0
			)

			THEN 1 ELSE 0
		END AS is_calendar_holiday,

        CASE
            WHEN d.date_type = 1 OR d.base_date_type = 1 THEN 0
            WHEN d.date_type = 2
              OR d.base_date_type = 2
              OR d.resolved_is_off_day = 1
            THEN 1 ELSE 0
        END AS is_schedule_rest_day
    FROM d
),
y AS
(
    SELECT
        x.*,

        CASE
            WHEN x.is_holiday_in_lieu_work_day = 1 THEN 0
            WHEN ISNULL(x.effective_required_work_minutes, 0) = 0
             AND ISNULL(x.recomputed_worked_minutes, 0) > 0
            THEN 1 ELSE 0
        END AS is_pure_ot_day,

		CASE
			WHEN x.is_calendar_holiday = 1 THEN 0
			WHEN x.is_schedule_rest_day = 1 THEN 0
			ELSE 1
		END AS is_regular_required_day,

		--CASE
		--	-- Not required if holiday
		--	WHEN x.is_calendar_holiday = 1 THEN 0

		--	-- Not required if rest day
		--	WHEN x.is_schedule_rest_day = 1 THEN 0

		--	-- Not required if neutral NotRequired day
		--	WHEN x.attendance_status = 'NotRequired'
		--	 AND ISNULL(x.effective_required_work_minutes, 0) = 0
		--	 AND ISNULL(x.recomputed_worked_minutes, 0) = 0
		--	THEN 0

		--	-- Everything else is required
		--	ELSE 1
		--END AS is_regular_required_day,

        CASE
            WHEN x.is_calendar_holiday = 1 THEN 1
            ELSE 0
        END AS is_holiday_day,

        CASE
            WHEN x.is_schedule_rest_day = 1 THEN 1
            ELSE 0
        END AS is_rest_day
    FROM x
)
SELECT
    y.*,

	CASE
		WHEN y.is_regular_required_day = 1

		 -- TRUE absence = no punches at all
		 AND y.first_clock_in IS NULL
		 AND y.last_clock_out IS NULL

		 -- exclude neutral holiday overrides
		 AND NOT (
				(y.date_type = 1 OR y.base_date_type = 1)
			AND y.attendance_status = 'NotRequired'
			AND ISNULL(y.effective_required_work_minutes, 0) = 0
			AND ISNULL(y.recomputed_worked_minutes, 0) = 0
		 )

		THEN 1 ELSE 0
	END AS is_absent_day,

	CASE
		-- Any punch counts as present
		WHEN y.is_regular_required_day = 1
		 AND (
				y.first_clock_in IS NOT NULL
			 OR y.last_clock_out IS NOT NULL
			)
		THEN 1

		-- Covered NotRequired holiday overrides
		WHEN y.is_regular_required_day = 1
		 AND (y.date_type = 1 OR y.base_date_type = 1)
		 AND y.attendance_status = 'NotRequired'
		 AND ISNULL(y.effective_required_work_minutes, 0) = 0
		 AND ISNULL(y.recomputed_worked_minutes, 0) = 0
		THEN 1

		ELSE 0
	END AS is_present_regular_day,

	CASE
		WHEN y.is_regular_required_day = 1
		 AND (
				(y.first_clock_in IS NOT NULL AND y.last_clock_out IS NULL)
			 OR (y.first_clock_in IS NULL AND y.last_clock_out IS NOT NULL)
			 )
		THEN 1 ELSE 0
	END AS is_incomplete_punch_day
	
FROM y;
