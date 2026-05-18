CREATE TABLE [dbo].[att_payloadpaycode] (
    [id]              CHAR (32)      NOT NULL,
    [att_date]        DATE           NOT NULL,
    [week]            INT            NOT NULL,
    [weekday]         INT            NOT NULL,
    [pay_code_alias]  NVARCHAR (50)  NOT NULL,
    [pay_code_symbol] NVARCHAR (20)  NULL,
    [duration]        INT            NOT NULL,
    [workday]         NUMERIC (4, 1) NOT NULL,
    [hours]           NUMERIC (6, 1) NOT NULL,
    [minutes]         NUMERIC (8, 1) NOT NULL,
    [is_exception]    SMALLINT       NOT NULL,
    [is_weekly]       BIT            NOT NULL,
    [year]            INT            NOT NULL,
    [emp_id]          INT            NOT NULL,
    [pay_code_id]     INT            NOT NULL,
    [shift_id]        INT            NULL,
    [time_card_id]    CHAR (32)      NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_payloadpaycode_emp_id_78e75279_fk_personnel_employee_id] FOREIGN KEY ([emp_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [att_payloadpaycode_pay_code_id_4a096cc7_fk_att_paycode_id] FOREIGN KEY ([pay_code_id]) REFERENCES [dbo].[att_paycode] ([id]),
    CONSTRAINT [att_payloadpaycode_shift_id_79a0901e_fk_att_attshift_id] FOREIGN KEY ([shift_id]) REFERENCES [dbo].[att_attshift] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_payloadpaycode_time_card_id_1696b969]
    ON [dbo].[att_payloadpaycode]([time_card_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadpaycode_pay_code_id_4a096cc7]
    ON [dbo].[att_payloadpaycode]([pay_code_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadpaycode_att_date_aa048d7b]
    ON [dbo].[att_payloadpaycode]([att_date] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadpaycode_shift_id_79a0901e]
    ON [dbo].[att_payloadpaycode]([shift_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadpaycode_emp_id_78e75279]
    ON [dbo].[att_payloadpaycode]([emp_id] ASC);

