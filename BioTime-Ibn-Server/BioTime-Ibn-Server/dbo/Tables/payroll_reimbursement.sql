CREATE TABLE [dbo].[payroll_reimbursement] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [rmb_amount]  FLOAT (53)     NOT NULL,
    [rmb_time]    DATETIME2 (7)  NOT NULL,
    [rmb_file]    NVARCHAR (200) NULL,
    [rmb_remark]  NVARCHAR (300) NULL,
    [employee_id] INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_reimbursement_employee_id_c4bbde36_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [payroll_reimbursement_employee_id_c4bbde36]
    ON [dbo].[payroll_reimbursement]([employee_id] ASC);

