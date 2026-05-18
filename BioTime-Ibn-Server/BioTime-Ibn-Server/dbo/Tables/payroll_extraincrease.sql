CREATE TABLE [dbo].[payroll_extraincrease] (
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
    CONSTRAINT [payroll_extraincrease_employee_id_f902e6bb_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [payroll_extraincrease_special_type_id_d15ce699_fk_payroll_specialpayment_id] FOREIGN KEY ([special_type_id]) REFERENCES [dbo].[payroll_specialpayment] ([id])
);


GO
CREATE NONCLUSTERED INDEX [payroll_extraincrease_employee_id_f902e6bb]
    ON [dbo].[payroll_extraincrease]([employee_id] ASC);


GO
CREATE NONCLUSTERED INDEX [payroll_extraincrease_special_type_id_d15ce699]
    ON [dbo].[payroll_extraincrease]([special_type_id] ASC);

