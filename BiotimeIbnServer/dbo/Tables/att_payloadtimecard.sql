CREATE TABLE [dbo].[att_payloadtimecard] (
    [id]               CHAR (32)      NOT NULL,
    [att_date]         DATE           NOT NULL,
    [week]             INT            NOT NULL,
    [weekday]          INT            NOT NULL,
    [date_type]        SMALLINT       NOT NULL,
    [time_table_alias] NVARCHAR (50)  NOT NULL,
    [check_in]         DATETIME2 (7)  NOT NULL,
    [check_out]        DATETIME2 (7)  NOT NULL,
    [work_day]         NUMERIC (4, 1) NOT NULL,
    [clock_in]         DATETIME2 (7)  NULL,
    [clock_out]        DATETIME2 (7)  NULL,
    [break_out]        DATETIME2 (7)  NULL,
    [break_in]         DATETIME2 (7)  NULL,
    [lock_down]        BIT            NOT NULL,
    [present]          SMALLINT       NOT NULL,
    [full_attendance]  SMALLINT       NOT NULL,
    [payload]          NVARCHAR (MAX) NULL,
    [emp_id]           INT            NOT NULL,
    [in_trans_id]      INT            NULL,
    [out_trans_id]     INT            NULL,
    [time_table_id]    INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_payloadtimecard_emp_id_47caeab4_fk_personnel_employee_id] FOREIGN KEY ([emp_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [att_payloadtimecard_in_trans_id_d0e9c411_fk_iclock_transaction_id] FOREIGN KEY ([in_trans_id]) REFERENCES [dbo].[iclock_transaction] ([id]),
    CONSTRAINT [att_payloadtimecard_out_trans_id_aff7023d_fk_iclock_transaction_id] FOREIGN KEY ([out_trans_id]) REFERENCES [dbo].[iclock_transaction] ([id]),
    CONSTRAINT [att_payloadtimecard_time_table_id_6e0b0137_fk_att_timeinterval_id] FOREIGN KEY ([time_table_id]) REFERENCES [dbo].[att_timeinterval] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_payloadtimecard_att_date_48c1dc00]
    ON [dbo].[att_payloadtimecard]([att_date] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadtimecard_emp_id_47caeab4]
    ON [dbo].[att_payloadtimecard]([emp_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [att_payloadtimecard_emp_id_att_date_time_table_id_9df16bc5_uniq]
    ON [dbo].[att_payloadtimecard]([emp_id] ASC, [att_date] ASC, [time_table_id] ASC) WHERE ([emp_id] IS NOT NULL AND [att_date] IS NOT NULL AND [time_table_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [att_payloadtimecard_in_trans_id_d0e9c411]
    ON [dbo].[att_payloadtimecard]([in_trans_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadtimecard_out_trans_id_aff7023d]
    ON [dbo].[att_payloadtimecard]([out_trans_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_payloadtimecard_time_table_id_6e0b0137]
    ON [dbo].[att_payloadtimecard]([time_table_id] ASC);

