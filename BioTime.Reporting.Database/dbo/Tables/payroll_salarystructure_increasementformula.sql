CREATE TABLE [dbo].[payroll_salarystructure_increasementformula] (
    [id]                     INT IDENTITY (1, 1) NOT NULL,
    [salarystructure_id]     INT NOT NULL,
    [increasementformula_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_salarystructure_increasementformula_increasementformula_id_3cd77082_fk_payroll_increasementformula_id] FOREIGN KEY ([increasementformula_id]) REFERENCES [dbo].[payroll_increasementformula] ([id]),
    CONSTRAINT [payroll_salarystructure_increasementformula_salarystructure_id_8752401c_fk_payroll_salarystructure_id] FOREIGN KEY ([salarystructure_id]) REFERENCES [dbo].[payroll_salarystructure] ([id])
);


GO
CREATE NONCLUSTERED INDEX [payroll_salarystructure_increasementformula_increasementformula_id_3cd77082]
    ON [dbo].[payroll_salarystructure_increasementformula]([increasementformula_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [payroll_salarystructure_increasementformula_salarystructure_id_increasementformula_id_749132b3_uniq]
    ON [dbo].[payroll_salarystructure_increasementformula]([salarystructure_id] ASC, [increasementformula_id] ASC) WHERE ([salarystructure_id] IS NOT NULL AND [increasementformula_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [payroll_salarystructure_increasementformula_salarystructure_id_8752401c]
    ON [dbo].[payroll_salarystructure_increasementformula]([salarystructure_id] ASC);

