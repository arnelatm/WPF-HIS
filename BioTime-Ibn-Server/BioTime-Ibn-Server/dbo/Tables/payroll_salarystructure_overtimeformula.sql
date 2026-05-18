CREATE TABLE [dbo].[payroll_salarystructure_overtimeformula] (
    [id]                 INT IDENTITY (1, 1) NOT NULL,
    [salarystructure_id] INT NOT NULL,
    [overtimeformula_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_salarystructure_overtimeformula_overtimeformula_id_40ad89ef_fk_payroll_overtimeformula_id] FOREIGN KEY ([overtimeformula_id]) REFERENCES [dbo].[payroll_overtimeformula] ([id]),
    CONSTRAINT [payroll_salarystructure_overtimeformula_salarystructure_id_64f75042_fk_payroll_salarystructure_id] FOREIGN KEY ([salarystructure_id]) REFERENCES [dbo].[payroll_salarystructure] ([id])
);


GO
CREATE NONCLUSTERED INDEX [payroll_salarystructure_overtimeformula_overtimeformula_id_40ad89ef]
    ON [dbo].[payroll_salarystructure_overtimeformula]([overtimeformula_id] ASC);


GO
CREATE NONCLUSTERED INDEX [payroll_salarystructure_overtimeformula_salarystructure_id_64f75042]
    ON [dbo].[payroll_salarystructure_overtimeformula]([salarystructure_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [payroll_salarystructure_overtimeformula_salarystructure_id_overtimeformula_id_0d0a0e81_uniq]
    ON [dbo].[payroll_salarystructure_overtimeformula]([salarystructure_id] ASC, [overtimeformula_id] ASC) WHERE ([salarystructure_id] IS NOT NULL AND [overtimeformula_id] IS NOT NULL);

