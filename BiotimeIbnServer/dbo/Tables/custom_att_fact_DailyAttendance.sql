CREATE TABLE [dbo].[custom_att_fact_DailyAttendance] (
    [emp_id]                          INT             NOT NULL,
    [emp_code]                        NVARCHAR(20)    NOT NULL,
    [att_date]                        DATE            NOT NULL,
    [year_no]                         INT             NOT NULL,
    [month_no]                        INT             NOT NULL,
    [daily_status]                    VARCHAR (50)    CONSTRAINT [DF_custom_att_fact_DailyAttendance_daily_status] DEFAULT ('Unprocessed') NULL,
    [business_day_type]               VARCHAR (50)    CONSTRAINT [DF_custom_att_fact_DailyAttendance_business_day_type] DEFAULT ('Unclassified') NULL,
    [attendance_status]               VARCHAR (50)    CONSTRAINT [DF_custom_att_fact_DailyAttendance_attendance_status] DEFAULT ('Unprocessed') NULL,
    [anomaly_flag]                    VARCHAR (100)   CONSTRAINT [DF_custom_att_fact_DailyAttendance_anomaly_flag] DEFAULT ('Normal') NULL,
    [anomaly_group]                   VARCHAR (50)    CONSTRAINT [DF_custom_att_fact_DailyAttendance_anomaly_group] DEFAULT ('Normal') NULL,
    [needs_payroll_review]            BIT             NULL,
    [first_clock_in]                  DATETIME        NULL,
    [last_clock_out]                  DATETIME        NULL,
    [recomputed_worked_minutes]       DECIMAL (10, 2) NULL,
    [regular_worked_minutes]          DECIMAL (10, 2) NULL,
    [ot_minutes]                      DECIMAL (10, 2) NULL,
    [required_scheduled_hours]        DECIMAL (10, 2) NULL,
    [worked_hours]                    DECIMAL (10, 2) NULL,
    [regular_worked_hours]            DECIMAL (10, 2) NULL,
    [ot_hours]                        DECIMAL (10, 2) NULL,
    [punch_status]                    VARCHAR (50)    CONSTRAINT [DF_custom_att_fact_DailyAttendance_punch_status] DEFAULT ('NoPunch') NULL,
    [schedule_label]                  VARCHAR (100)   NULL,
    [late_minutes]                    DECIMAL (10, 2) NULL,
    [early_out_minutes]               DECIMAL (10, 2) NULL,
    [recomputed_absence_hours]        DECIMAL (10, 2) NULL,
    [work_completion_pct]             DECIMAL (10, 2) CONSTRAINT [DF_custom_att_fact_DailyAttendance_work_completion_pct] DEFAULT ((0)) NULL,
    [date_type]                       INT             NULL,
    [is_flex_duty]                    BIT             NULL,
    [flex_duty_minutes]               DECIMAL (10, 2) NULL,
    [Leaves]                          DECIMAL (10, 2) NULL,
    [sick_leave_days]                 DECIMAL (10, 2) NULL,
    [annual_leave_days]               DECIMAL (10, 2) NULL,
    [compensatory_leave_days]         DECIMAL (10, 2) NULL,
    [other_paid_leave_days]           DECIMAL (10, 2) NULL,
    [unpaid_leave_days]               DECIMAL (10, 2) NULL,
    [comp_leave_eligible_flag]        INT             NULL,
    [comp_leave_minutes]              DECIMAL (10, 2) NULL,
    [comp_leave_hours]                DECIMAL (10, 2) NULL,
    [actual_excess_minutes]           DECIMAL (10, 2) CONSTRAINT [DF_custom_att_fact_DailyAttendance_actual_excess_minutes] DEFAULT ((0)) NOT NULL,
    [excess_minutes]                  DECIMAL (10, 2) NULL,
    [excess_hours]                    DECIMAL (10, 2) NULL,
    [shortfall_minutes]               DECIMAL (10, 2) NULL,
    [shortfall_hours]                 DECIMAL (10, 2) NULL,
    [reconciliation_status]           VARCHAR (50)    NULL,
    [reconciliation_variance_minutes] DECIMAL (10, 2) NULL,
    [work_gap_minutes]                DECIMAL (10, 2) NULL,
    [actual_late_minutes]             DECIMAL (10, 2) CONSTRAINT [DF_custom_att_fact_DailyAttendance_actual_late_minutes] DEFAULT ((0)) NOT NULL,
    [actual_early_out_minutes]        DECIMAL (10, 2) NULL,
    [corrected]                       BIT             CONSTRAINT [DF_custom_att_fact_DailyAttendance_corrected] DEFAULT ((0)) NOT NULL,
    [effective_punch_in1]             DATETIME2 (7)   NULL,
    [effective_punch_out1]            DATETIME2 (7)   NULL,
    [effective_punch_in2]             DATETIME2 (7)   NULL,
    [effective_punch_out2]            DATETIME2 (7)   NULL,
    CONSTRAINT [PK_custom_att_fact_DailyAttendance] PRIMARY KEY CLUSTERED ([emp_id] ASC, [att_date] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CustomFact_EmpDate]
    ON [dbo].[custom_att_fact_DailyAttendance]([emp_id] ASC, [att_date] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_CustomFact_AttDateEmp]
    ON [dbo].[custom_att_fact_DailyAttendance]([att_date] ASC, [emp_id] ASC)
    INCLUDE (
        [emp_code],
        [effective_punch_in1],
        [effective_punch_out1],
        [effective_punch_in2],
        [effective_punch_out2],
        [required_scheduled_hours],
        [worked_hours],
        [recomputed_worked_minutes],
        [attendance_status],
        [anomaly_flag],
        [needs_payroll_review],
        [reconciliation_status]
    );
