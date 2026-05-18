CREATE TABLE [dbo].[payroll_salaryadvance] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [advance_amount] FLOAT (53)     NOT NULL,
    [advance_time]   DATETIME2 (7)  NOT NULL,
    [advance_remark] NVARCHAR (300) NULL,
    [employee_id]    INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_salaryadvance_employee_id_2abd43e5_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [payroll_salaryadvance_employee_id_2abd43e5]
    ON [dbo].[payroll_salaryadvance]([employee_id] ASC);

