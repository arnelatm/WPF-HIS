CREATE TABLE [dbo].[att_temporaryschedule] (
    [id]               INT            IDENTITY (1, 1) NOT NULL,
    [create_time]      DATETIME2 (7)  NULL,
    [create_user]      NVARCHAR (150) NULL,
    [change_time]      DATETIME2 (7)  NULL,
    [change_user]      NVARCHAR (150) NULL,
    [status]           SMALLINT       NOT NULL,
    [att_date]         DATE           NOT NULL,
    [employee_id]      INT            NOT NULL,
    [time_interval_id] INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_temporaryschedule_employee_id_2b2b94c2_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_temporaryschedule_att_date_8aed8916]
    ON [dbo].[att_temporaryschedule]([att_date] ASC);


GO
CREATE NONCLUSTERED INDEX [att_temporaryschedule_employee_id_2b2b94c2]
    ON [dbo].[att_temporaryschedule]([employee_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_temporaryschedule_time_interval_id_2be60ee4]
    ON [dbo].[att_temporaryschedule]([time_interval_id] ASC);

