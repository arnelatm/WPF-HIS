CREATE TABLE [dbo].[payroll_extradeduction] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [create_time]     DATETIME2 (7)  NULL,
    [create_user]     NVARCHAR (150) NULL,
    [change_time]     DATETIME2 (7)  NULL,
    [change_user]     NVARCHAR (150) NULL,
    [status]          SMALLINT       NOT NULL,
    [amount]          FLOAT (53)     NOT NULL,
    [issued_time]     DATETIME2 (7)  NOT NULL,
    [remark]          NVARCHAR (300) NULL,
    [employee_id]     INT            NULL,
    [special_type_id] INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_extradeduction_employee_id_53072441_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [payroll_extradeduction_special_type_id_50673042_fk_payroll_specialpayment_id] FOREIGN KEY ([special_type_id]) REFERENCES [dbo].[payroll_specialpayment] ([id])
);


GO
CREATE NONCLUSTERED INDEX [payroll_extradeduction_special_type_id_50673042]
    ON [dbo].[payroll_extradeduction]([special_type_id] ASC);


GO
CREATE NONCLUSTERED INDEX [payroll_extradeduction_employee_id_53072441]
    ON [dbo].[payroll_extradeduction]([employee_id] ASC);

