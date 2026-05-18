CREATE TABLE [dbo].[att_grouppolicy] (
    [id]                     INT            IDENTITY (1, 1) NOT NULL,
    [create_time]            DATETIME2 (7)  NULL,
    [create_user]            NVARCHAR (150) NULL,
    [change_time]            DATETIME2 (7)  NULL,
    [change_user]            NVARCHAR (150) NULL,
    [status]                 SMALLINT       NOT NULL,
    [use_ot]                 SMALLINT       NOT NULL,
    [weekend1]               SMALLINT       NOT NULL,
    [weekend2]               SMALLINT       NOT NULL,
    [start_of_week]          SMALLINT       NOT NULL,
    [max_hrs]                NUMERIC (4, 1) NOT NULL,
    [day_change]             TIME (7)       NOT NULL,
    [paring_rule]            SMALLINT       NOT NULL,
    [overtime_policy]        SMALLINT       NOT NULL,
    [punch_period]           SMALLINT       NOT NULL,
    [daily_ot]               BIT            NOT NULL,
    [daily_ot_rule]          CHAR (32)      NULL,
    [weekly_ot]              BIT            NOT NULL,
    [weekly_ot_rule]         CHAR (32)      NULL,
    [weekend_ot]             BIT            NOT NULL,
    [weekend_ot_rule]        CHAR (32)      NULL,
    [holiday_ot]             BIT            NOT NULL,
    [holiday_ot_rule]        CHAR (32)      NULL,
    [late_in2absence]        INT            NOT NULL,
    [early_out2absence]      INT            NOT NULL,
    [miss_in]                SMALLINT       NOT NULL,
    [late_in_hrs]            INT            NOT NULL,
    [miss_out]               SMALLINT       NOT NULL,
    [early_out_hrs]          INT            NOT NULL,
    [require_capture]        BIT            NOT NULL,
    [require_work_code]      BIT            NOT NULL,
    [require_punch_state]    BIT            NOT NULL,
    [max_late_in]            SMALLINT       NOT NULL,
    [max_early_out]          SMALLINT       NOT NULL,
    [max_absent]             SMALLINT       NOT NULL,
    [group_frequency]        SMALLINT       NOT NULL,
    [group_send_day]         SMALLINT       NOT NULL,
    [email_send_time]        TIME (7)       NOT NULL,
    [sending_day]            SMALLINT       NOT NULL,
    [weekend1_color_setting] NVARCHAR (30)  NULL,
    [weekend2_color_setting] NVARCHAR (30)  NULL,
    [enable_compensatory]    BIT            NOT NULL,
    [bot_uid]                NVARCHAR (100) NULL,
    [group_id]               INT            NOT NULL,
    [ot_pay_code_id]         INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_grouppolicy_group_id_b2e4dfe8_fk_att_attgroup_id] FOREIGN KEY ([group_id]) REFERENCES [dbo].[att_attgroup] ([id]),
    CONSTRAINT [att_grouppolicy_ot_pay_code_id_1ec83080_fk_att_paycode_id] FOREIGN KEY ([ot_pay_code_id]) REFERENCES [dbo].[att_paycode] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_grouppolicy_ot_pay_code_id_1ec83080]
    ON [dbo].[att_grouppolicy]([ot_pay_code_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_grouppolicy_group_id_b2e4dfe8]
    ON [dbo].[att_grouppolicy]([group_id] ASC);

