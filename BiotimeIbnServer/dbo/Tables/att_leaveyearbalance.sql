CREATE TABLE [dbo].[att_leaveyearbalance] (
    [id]               INT            IDENTITY (1, 1) NOT NULL,
    [create_time]      DATETIME2 (7)  NULL,
    [create_user]      NVARCHAR (150) NULL,
    [change_time]      DATETIME2 (7)  NULL,
    [change_user]      NVARCHAR (150) NULL,
    [status]           SMALLINT       NOT NULL,
    [leave_type]       INT            NULL,
    [year]             INT            NULL,
    [entitlement_days] SMALLINT       NULL,
    [leave_day]        FLOAT (53)     NULL,
    [pre_balance]      SMALLINT       NULL,
    [employee_id]      INT            NOT NULL,
    [pay_code_id]      INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_leaveyearbalance_employee_id_14febdb3_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [att_leaveyearbalance_pay_code_id_82632aca_fk_att_paycode_id] FOREIGN KEY ([pay_code_id]) REFERENCES [dbo].[att_paycode] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_leaveyearbalance_employee_id_14febdb3]
    ON [dbo].[att_leaveyearbalance]([employee_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [att_leaveyearbalance_employee_id_year_pay_code_id_2ec71517_uniq]
    ON [dbo].[att_leaveyearbalance]([employee_id] ASC, [year] ASC, [pay_code_id] ASC) WHERE ([employee_id] IS NOT NULL AND [year] IS NOT NULL AND [pay_code_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [att_leaveyearbalance_pay_code_id_82632aca]
    ON [dbo].[att_leaveyearbalance]([pay_code_id] ASC);

