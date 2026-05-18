CREATE TABLE [dbo].[att_payloadmulpunchset] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [att_date]     DATE          NOT NULL,
    [weekday]      SMALLINT      NULL,
    [data_index]   SMALLINT      NOT NULL,
    [clock_in]     DATETIME2 (7) NULL,
    [in_id]        INT           NULL,
    [clock_out]    DATETIME2 (7) NULL,
    [out_id]       INT           NULL,
    [total_time]   INT           NULL,
    [worked_time]  INT           NULL,
    [data_type]    SMALLINT      NOT NULL,
    [emp_id]       INT           NOT NULL,
    [timetable_id] INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_payloadmulpunchset_emp_id_f47610c8_fk_personnel_employee_id] FOREIGN KEY ([emp_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_payloadmulpunchset_timetable_id_9a439a09]
    ON [dbo].[att_payloadmulpunchset]([timetable_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadmulpunchset_emp_id_f47610c8]
    ON [dbo].[att_payloadmulpunchset]([emp_id] ASC);

