CREATE TABLE [dbo].[payroll_increasementformula] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [name]            NVARCHAR (30)  NOT NULL,
    [formula]         NVARCHAR (100) NOT NULL,
    [remark]          NVARCHAR (MAX) NULL,
    [apply_mode]      SMALLINT       NOT NULL,
    [special_type_id] INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_increasementformula_special_type_id_88016f0b_fk_payroll_specialpayment_id] FOREIGN KEY ([special_type_id]) REFERENCES [dbo].[payroll_specialpayment] ([id]),
    UNIQUE NONCLUSTERED ([name] ASC)
);


GO
CREATE NONCLUSTERED INDEX [payroll_increasementformula_special_type_id_88016f0b]
    ON [dbo].[payroll_increasementformula]([special_type_id] ASC);

