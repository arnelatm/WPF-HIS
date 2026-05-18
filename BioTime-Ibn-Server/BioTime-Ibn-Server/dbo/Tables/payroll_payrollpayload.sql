CREATE TABLE [dbo].[payroll_payrollpayload] (
    [id]                           INT            IDENTITY (1, 1) NOT NULL,
    [calc_time]                    DATE           NULL,
    [basic_salary]                 FLOAT (53)     NULL,
    [effective_date]               DATE           NULL,
    [format_dict]                  NVARCHAR (MAX) NULL,
    [payment_mode]                 SMALLINT       NULL,
    [increase]                     FLOAT (53)     NULL,
    [deduction]                    FLOAT (53)     NULL,
    [increase_formula]             NVARCHAR (MAX) NULL,
    [deduction_formula]            NVARCHAR (MAX) NULL,
    [increase_formula_name]        NVARCHAR (MAX) NULL,
    [deduction_formula_name]       NVARCHAR (MAX) NULL,
    [extra_increase]               FLOAT (53)     NULL,
    [extra_deduction]              FLOAT (53)     NULL,
    [total_loan_amount]            FLOAT (53)     NULL,
    [refund_loan_amount]           FLOAT (53)     NULL,
    [unrefund_loan_amount]         FLOAT (53)     NULL,
    [loan_deduction]               FLOAT (53)     NULL,
    [loan_increase]                FLOAT (53)     NULL,
    [advance_increase]             FLOAT (53)     NULL,
    [advance_deduction]            FLOAT (53)     NULL,
    [reimbursement]                FLOAT (53)     NULL,
    [total_increase_formula]       NVARCHAR (MAX) NULL,
    [total_increase_formula_name]  NVARCHAR (MAX) NULL,
    [total_increase_expression]    NVARCHAR (MAX) NULL,
    [total_increase]               FLOAT (53)     NULL,
    [total_deduction_formula]      NVARCHAR (MAX) NULL,
    [total_deduction_formula_name] NVARCHAR (MAX) NULL,
    [total_deduction_expression]   NVARCHAR (MAX) NULL,
    [total_deduction]              FLOAT (53)     NULL,
    [total_salary_expression]      NVARCHAR (MAX) NULL,
    [total_salary]                 FLOAT (53)     NULL,
    [social_security_deduction]    FLOAT (53)     NULL,
    [total_income_per_year]        FLOAT (53)     NULL,
    [calc_end_time]                DATE           NULL,
    [net_pay]                      FLOAT (53)     NULL,
    [total_tax_deduction_per_year] FLOAT (53)     NULL,
    [tax_deduction]                FLOAT (53)     NULL,
    [employee_id]                  INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [payroll_payrollpayload_employee_id_bc868f2b_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [payroll_payrollpayload_employee_id_bc868f2b]
    ON [dbo].[payroll_payrollpayload]([employee_id] ASC);

