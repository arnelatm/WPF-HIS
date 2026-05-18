CREATE TABLE [dbo].[att_payloadeffectpunch] (
    [id]             CHAR (32)     NOT NULL,
    [att_date]       DATE          NOT NULL,
    [punch_datetime] DATETIME2 (7) NOT NULL,
    [punch_date]     DATE          NOT NULL,
    [punch_time]     TIME (7)      NOT NULL,
    [week]           SMALLINT      NOT NULL,
    [weekday]        SMALLINT      NOT NULL,
    [work_code]      NVARCHAR (20) NOT NULL,
    [punch_state]    NVARCHAR (5)  NOT NULL,
    [adjust_state]   NVARCHAR (5)  NOT NULL,
    [emp_id]         INT           NOT NULL,
    [time_card_id]   CHAR (32)     NULL,
    [trans_id]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_payloadeffectpunch_emp_id_67e28e01_fk_personnel_employee_id] FOREIGN KEY ([emp_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [att_payloadeffectpunch_trans_id_94affbe6_fk_iclock_transaction_id] FOREIGN KEY ([trans_id]) REFERENCES [dbo].[iclock_transaction] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_payloadeffectpunch_att_date_1e3de2d4]
    ON [dbo].[att_payloadeffectpunch]([att_date] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadeffectpunch_emp_id_67e28e01]
    ON [dbo].[att_payloadeffectpunch]([emp_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadeffectpunch_trans_id_94affbe6]
    ON [dbo].[att_payloadeffectpunch]([trans_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadeffectpunch_time_card_id_52f69aaf]
    ON [dbo].[att_payloadeffectpunch]([time_card_id] ASC);

