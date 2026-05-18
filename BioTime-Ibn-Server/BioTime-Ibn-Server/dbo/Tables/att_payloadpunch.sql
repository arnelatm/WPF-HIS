CREATE TABLE [dbo].[att_payloadpunch] (
    [uuid]          NVARCHAR (36) NOT NULL,
    [att_date]      DATE          NULL,
    [correct_state] NVARCHAR (3)  NULL,
    [emp_id]        INT           NOT NULL,
    [orig_id]       INT           NULL,
    [skd_id]        NVARCHAR (36) NULL,
    PRIMARY KEY CLUSTERED ([uuid] ASC),
    CONSTRAINT [att_payloadpunch_emp_id_053da2f0_fk_personnel_employee_id] FOREIGN KEY ([emp_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [att_payloadpunch_orig_id_16b26416_fk_iclock_transaction_id] FOREIGN KEY ([orig_id]) REFERENCES [dbo].[iclock_transaction] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_payloadpunch_emp_id_053da2f0]
    ON [dbo].[att_payloadpunch]([emp_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadpunch_orig_id_16b26416]
    ON [dbo].[att_payloadpunch]([orig_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadpunch_skd_id_17596d82]
    ON [dbo].[att_payloadpunch]([skd_id] ASC);

