CREATE TABLE [dbo].[payroll_emploan] (
    [id]               INT            IDENTITY (1, 1) NOT NULL,
    [create_time]      DATETIME2 (7)  NULL,
    [create_user]      NVARCHAR (150) NULL,
    [change_time]      DATETIME2 (7)  NULL,
    [change_user]      NVARCHAR (150) NULL,
    [status]           SMALLINT       NOT NULL,
    [loan_amount]      FLOAT (53)     NOT NULL,
    [loan_time]        DATETIME2 (7)  NOT NULL,
    [refund_cycle]     SMALLINT       NOT NULL,
    [per_cycle_refund] FLOAT (53)     NOT NULL,
    [loan_clean_time]  DATETIME2 (7)  NULL,
    [remark]           NVARCHAR (300) NULL,
    [employee_id]      INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_emploan_employee_id_97a251ef_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [payroll_emploan_employee_id_97a251ef]
    ON [dbo].[payroll_emploan]([employee_id] ASC);

