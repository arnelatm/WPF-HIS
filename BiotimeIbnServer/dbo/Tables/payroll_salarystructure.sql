CREATE TABLE [dbo].[payroll_salarystructure] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [create_time]    DATETIME2 (7)  NULL,
    [create_user]    NVARCHAR (150) NULL,
    [change_time]    DATETIME2 (7)  NULL,
    [change_user]    NVARCHAR (150) NULL,
    [status]         SMALLINT       NOT NULL,
    [salary_amount]  FLOAT (53)     NOT NULL,
    [effective_date] DATE           NOT NULL,
    [salary_remark]  NVARCHAR (300) NULL,
    [employee_id]    INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_salarystructure_employee_id_98996e15_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [payroll_salarystructure_employee_id_98996e15]
    ON [dbo].[payroll_salarystructure]([employee_id] ASC);

