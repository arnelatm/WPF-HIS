CREATE TABLE [dbo].[payroll_exceptionformula] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (30)  NOT NULL,
    [formula]     NVARCHAR (100) NOT NULL,
    [remark]      NVARCHAR (MAX) NULL,
    [pay_code_id] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_exceptionformula_pay_code_id_97609b51_fk_att_paycode_id] FOREIGN KEY ([pay_code_id]) REFERENCES [dbo].[att_paycode] ([id]),
    UNIQUE NONCLUSTERED ([name] ASC)
);


GO
CREATE NONCLUSTERED INDEX [payroll_exceptionformula_pay_code_id_97609b51]
    ON [dbo].[payroll_exceptionformula]([pay_code_id] ASC);

