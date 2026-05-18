CREATE TABLE [dbo].[att_payloadbase] (
    [uuid]          NVARCHAR (36) NOT NULL,
    [att_date]      DATE          NULL,
    [weekday]       SMALLINT      NULL,
    [check_in]      DATETIME2 (7) NULL,
    [check_out]     DATETIME2 (7) NULL,
    [duration]      INT           NULL,
    [duty_duration] INT           NULL,
    [work_day]      FLOAT (53)    NOT NULL,
    [clock_in]      DATETIME2 (7) NULL,
    [clock_out]     DATETIME2 (7) NULL,
    [total_time]    INT           NULL,
    [duty_worked]   INT           NULL,
    [actual_worked] INT           NULL,
    [unscheduled]   INT           NULL,
    [remaining]     INT           NULL,
    [total_worked]  INT           NULL,
    [late]          INT           NULL,
    [early_leave]   INT           NULL,
    [short]         INT           NULL,
    [absent]        INT           NULL,
    [leave]         INT           NULL,
    [exception]     NVARCHAR (50) NULL,
    [day_off]       SMALLINT      NOT NULL,
    [break_time_id] NVARCHAR (36) NULL,
    [emp_id]        INT           NOT NULL,
    [overtime_id]   NVARCHAR (36) NULL,
    [timetable_id]  INT           NULL,
    PRIMARY KEY CLUSTERED ([uuid] ASC),
    CONSTRAINT [att_payloadbase_emp_id_2c0f6a7b_fk_personnel_employee_id] FOREIGN KEY ([emp_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [att_payloadbase_timetable_id_a389e3d8_fk_att_timeinterval_id] FOREIGN KEY ([timetable_id]) REFERENCES [dbo].[att_timeinterval] ([id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [att_payloadbase_break_time_id_022d6fac_uniq]
    ON [dbo].[att_payloadbase]([break_time_id] ASC) WHERE ([break_time_id] IS NOT NULL);


GO
CREATE UNIQUE NONCLUSTERED INDEX [att_payloadbase_overtime_id_0e7be795_uniq]
    ON [dbo].[att_payloadbase]([overtime_id] ASC) WHERE ([overtime_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [att_payloadbase_emp_id_2c0f6a7b]
    ON [dbo].[att_payloadbase]([emp_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadbase_timetable_id_a389e3d8]
    ON [dbo].[att_payloadbase]([timetable_id] ASC);

