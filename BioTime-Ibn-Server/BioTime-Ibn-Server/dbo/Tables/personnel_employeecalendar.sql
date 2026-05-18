CREATE TABLE [dbo].[personnel_employeecalendar] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [create_time] DATETIME2 (7)  NULL,
    [create_user] NVARCHAR (150) NULL,
    [change_time] DATETIME2 (7)  NULL,
    [change_user] NVARCHAR (150) NULL,
    [status]      SMALLINT       NOT NULL,
    [calendar]    NVARCHAR (100) NULL,
    [employee_id] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [personnel_employeecalendar_employee_id_165e0779_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [personnel_employeecalendar_employee_id_165e0779]
    ON [dbo].[personnel_employeecalendar]([employee_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [personnel_employeecalendar_employee_id_calendar_10f7278d_uniq]
    ON [dbo].[personnel_employeecalendar]([employee_id] ASC, [calendar] ASC) WHERE ([employee_id] IS NOT NULL AND [calendar] IS NOT NULL);

