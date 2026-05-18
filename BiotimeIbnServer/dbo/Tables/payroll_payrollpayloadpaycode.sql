CREATE TABLE [dbo].[payroll_payrollpayloadpaycode] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [amount]       FLOAT (53)     NULL,
    [formula]      NVARCHAR (MAX) NULL,
    [formula_name] NVARCHAR (MAX) NULL,
    [pay_code_id]  INT            NOT NULL,
    [payload_id]   INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_payrollpayloadpaycode_pay_code_id_c057af1f_fk_att_paycode_id] FOREIGN KEY ([pay_code_id]) REFERENCES [dbo].[att_paycode] ([id]),
    CONSTRAINT [payroll_payrollpayloadpaycode_payload_id_f085c4e8_fk_payroll_payrollpayload_id] FOREIGN KEY ([payload_id]) REFERENCES [dbo].[payroll_payrollpayload] ([id])
);


GO
CREATE NONCLUSTERED INDEX [payroll_payrollpayloadpaycode_pay_code_id_c057af1f]
    ON [dbo].[payroll_payrollpayloadpaycode]([pay_code_id] ASC);


GO
CREATE NONCLUSTERED INDEX [payroll_payrollpayloadpaycode_payload_id_f085c4e8]
    ON [dbo].[payroll_payrollpayloadpaycode]([payload_id] ASC);

