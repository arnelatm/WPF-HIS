CREATE TABLE [dbo].[payroll_payrollpayloadexpenseexemption] (
    [id]           INT IDENTITY (1, 1) NOT NULL,
    [exemption_id] INT NULL,
    [payload_id]   INT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_payrollpayloadexpenseexemption_exemption_id_2effb718_fk_payroll_empexpenseexemption_id] FOREIGN KEY ([exemption_id]) REFERENCES [dbo].[payroll_empexpenseexemption] ([id]),
    CONSTRAINT [payroll_payrollpayloadexpenseexemption_payload_id_46c8357d_fk_payroll_payrollpayload_id] FOREIGN KEY ([payload_id]) REFERENCES [dbo].[payroll_payrollpayload] ([id])
);


GO
CREATE NONCLUSTERED INDEX [payroll_payrollpayloadexpenseexemption_payload_id_46c8357d]
    ON [dbo].[payroll_payrollpayloadexpenseexemption]([payload_id] ASC);


GO
CREATE NONCLUSTERED INDEX [payroll_payrollpayloadexpenseexemption_exemption_id_2effb718]
    ON [dbo].[payroll_payrollpayloadexpenseexemption]([exemption_id] ASC);

