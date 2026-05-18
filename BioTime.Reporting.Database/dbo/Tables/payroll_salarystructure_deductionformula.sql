CREATE TABLE [dbo].[payroll_salarystructure_deductionformula] (
    [id]                  INT IDENTITY (1, 1) NOT NULL,
    [salarystructure_id]  INT NOT NULL,
    [deductionformula_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_salarystructure_deductionformula_deductionformula_id_b174d5b6_fk_payroll_deductionformula_id] FOREIGN KEY ([deductionformula_id]) REFERENCES [dbo].[payroll_deductionformula] ([id]),
    CONSTRAINT [payroll_salarystructure_deductionformula_salarystructure_id_5ca7cdb5_fk_payroll_salarystructure_id] FOREIGN KEY ([salarystructure_id]) REFERENCES [dbo].[payroll_salarystructure] ([id])
);


GO
CREATE NONCLUSTERED INDEX [payroll_salarystructure_deductionformula_salarystructure_id_5ca7cdb5]
    ON [dbo].[payroll_salarystructure_deductionformula]([salarystructure_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [payroll_salarystructure_deductionformula_salarystructure_id_deductionformula_id_794e8449_uniq]
    ON [dbo].[payroll_salarystructure_deductionformula]([salarystructure_id] ASC, [deductionformula_id] ASC) WHERE ([salarystructure_id] IS NOT NULL AND [deductionformula_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [payroll_salarystructure_deductionformula_deductionformula_id_b174d5b6]
    ON [dbo].[payroll_salarystructure_deductionformula]([deductionformula_id] ASC);

