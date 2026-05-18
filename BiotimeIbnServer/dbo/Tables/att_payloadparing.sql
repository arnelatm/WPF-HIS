CREATE TABLE [dbo].[att_payloadparing] (
    [id]              CHAR (32)      NOT NULL,
    [stamp]           BIGINT         NOT NULL,
    [att_date]        DATE           NOT NULL,
    [week]            SMALLINT       NOT NULL,
    [weekday]         SMALLINT       NOT NULL,
    [data_type]       SMALLINT       NOT NULL,
    [clock_in]        DATETIME2 (7)  NULL,
    [in_date]         DATE           NULL,
    [in_time]         TIME (7)       NULL,
    [clock_out]       DATETIME2 (7)  NULL,
    [out_date]        DATE           NULL,
    [out_time]        TIME (7)       NULL,
    [duration]        INT            NOT NULL,
    [worked_duration] INT            NOT NULL,
    [data_index]      INT            NOT NULL,
    [workday]         NUMERIC (4, 1) NOT NULL,
    [emp_id]          INT            NOT NULL,
    [in_trans_id]     INT            NULL,
    [out_trans_id]    INT            NULL,
    [pay_code_id]     INT            NULL,
    [time_card_id]    CHAR (32)      NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_payloadparing_emp_id_c5daac4f_fk_personnel_employee_id] FOREIGN KEY ([emp_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [att_payloadparing_in_trans_id_50a8040e_fk_iclock_transaction_id] FOREIGN KEY ([in_trans_id]) REFERENCES [dbo].[iclock_transaction] ([id]),
    CONSTRAINT [att_payloadparing_out_trans_id_8b2375b9_fk_iclock_transaction_id] FOREIGN KEY ([out_trans_id]) REFERENCES [dbo].[iclock_transaction] ([id]),
    CONSTRAINT [att_payloadparing_pay_code_id_aa241cca_fk_att_paycode_id] FOREIGN KEY ([pay_code_id]) REFERENCES [dbo].[att_paycode] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_payloadparing_att_date_5daaa45d]
    ON [dbo].[att_payloadparing]([att_date] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadparing_emp_id_c5daac4f]
    ON [dbo].[att_payloadparing]([emp_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadparing_in_trans_id_50a8040e]
    ON [dbo].[att_payloadparing]([in_trans_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadparing_out_trans_id_8b2375b9]
    ON [dbo].[att_payloadparing]([out_trans_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadparing_pay_code_id_aa241cca]
    ON [dbo].[att_payloadparing]([pay_code_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadparing_time_card_id_3adc3517]
    ON [dbo].[att_payloadparing]([time_card_id] ASC);

