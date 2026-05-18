CREATE TABLE [dbo].[payroll_salarystructure_exceptionformula] (
    [id]                  INT IDENTITY (1, 1) NOT NULL,
    [salarystructure_id]  INT NOT NULL,
    [exceptionformula_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_salarystructure_exceptionformula_exceptionformula_id_8f6dadb3_fk_payroll_exceptionformula_id] FOREIGN KEY ([exceptionformula_id]) REFERENCES [dbo].[payroll_exceptionformula] ([id]),
    CONSTRAINT [payroll_salarystructure_exceptionformula_salarystructure_id_3c087208_fk_payroll_salarystructure_id] FOREIGN KEY ([salarystructure_id]) REFERENCES [dbo].[payroll_salarystructure] ([id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [payroll_salarystructure_exceptionformula_salarystructure_id_exceptionformula_id_a5e869ff_uniq]
    ON [dbo].[payroll_salarystructure_exceptionformula]([salarystructure_id] ASC, [exceptionformula_id] ASC) WHERE ([salarystructure_id] IS NOT NULL AND [exceptionformula_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [payroll_salarystructure_exceptionformula_exceptionformula_id_8f6dadb3]
    ON [dbo].[payroll_salarystructure_exceptionformula]([exceptionformula_id] ASC);


GO
CREATE NONCLUSTERED INDEX [payroll_salarystructure_exceptionformula_salarystructure_id_3c087208]
    ON [dbo].[payroll_salarystructure_exceptionformula]([salarystructure_id] ASC);

