CREATE TABLE [dbo].[payroll_emppayrollprofile] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [payment_mode]  SMALLINT      NULL,
    [payment_type]  SMALLINT      NULL,
    [bank_name]     NVARCHAR (30) NULL,
    [bank_account]  NVARCHAR (30) NULL,
    [personnel_id]  NVARCHAR (30) NULL,
    [agent_id]      NVARCHAR (30) NULL,
    [agent_account] NVARCHAR (30) NULL,
    [employee_id]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_emppayrollprofile_employee_id_6c97078c_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    UNIQUE NONCLUSTERED ([employee_id] ASC)
);

