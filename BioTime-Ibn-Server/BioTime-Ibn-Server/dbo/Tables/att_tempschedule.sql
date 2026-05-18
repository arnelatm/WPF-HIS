CREATE TABLE [dbo].[att_tempschedule] (
    [id]               INT           IDENTITY (1, 1) NOT NULL,
    [att_date]         DATE          NULL,
    [start_time]       DATETIME2 (7) NOT NULL,
    [end_time]         DATETIME2 (7) NOT NULL,
    [rule_flag]        SMALLINT      NOT NULL,
    [work_type]        SMALLINT      NOT NULL,
    [employee_id]      INT           NOT NULL,
    [time_interval_id] INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_tempschedule_employee_id_b89c7e54_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_tempschedule_employee_id_b89c7e54]
    ON [dbo].[att_tempschedule]([employee_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_tempschedule_time_interval_id_08dd8eb3]
    ON [dbo].[att_tempschedule]([time_interval_id] ASC);

