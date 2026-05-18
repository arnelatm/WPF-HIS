CREATE TABLE [dbo].[payroll_empexpenseexemption] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [exemption_name] NVARCHAR (255) NOT NULL,
    [amount]         FLOAT (53)     NOT NULL,
    [issued_time]    DATETIME2 (7)  NOT NULL,
    [remark]         NVARCHAR (MAX) NULL,
    [year]           INT            NOT NULL,
    [employee_id]    INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_empexpenseexemption_employee_id_5372811d_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [payroll_empexpenseexemption_employee_id_5372811d]
    ON [dbo].[payroll_empexpenseexemption]([employee_id] ASC);

