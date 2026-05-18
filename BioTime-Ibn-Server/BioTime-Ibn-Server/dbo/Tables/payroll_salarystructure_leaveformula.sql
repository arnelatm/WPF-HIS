CREATE TABLE [dbo].[payroll_salarystructure_leaveformula] (
    [id]                 INT IDENTITY (1, 1) NOT NULL,
    [salarystructure_id] INT NOT NULL,
    [leaveformula_id]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_salarystructure_leaveformula_leaveformula_id_049f9024_fk_payroll_leaveformula_id] FOREIGN KEY ([leaveformula_id]) REFERENCES [dbo].[payroll_leaveformula] ([id]),
    CONSTRAINT [payroll_salarystructure_leaveformula_salarystructure_id_cf98fdd7_fk_payroll_salarystructure_id] FOREIGN KEY ([salarystructure_id]) REFERENCES [dbo].[payroll_salarystructure] ([id])
);


GO
CREATE NONCLUSTERED INDEX [payroll_salarystructure_leaveformula_leaveformula_id_049f9024]
    ON [dbo].[payroll_salarystructure_leaveformula]([leaveformula_id] ASC);


GO
CREATE NONCLUSTERED INDEX [payroll_salarystructure_leaveformula_salarystructure_id_cf98fdd7]
    ON [dbo].[payroll_salarystructure_leaveformula]([salarystructure_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [payroll_salarystructure_leaveformula_salarystructure_id_leaveformula_id_4efdce30_uniq]
    ON [dbo].[payroll_salarystructure_leaveformula]([salarystructure_id] ASC, [leaveformula_id] ASC) WHERE ([salarystructure_id] IS NOT NULL AND [leaveformula_id] IS NOT NULL);

