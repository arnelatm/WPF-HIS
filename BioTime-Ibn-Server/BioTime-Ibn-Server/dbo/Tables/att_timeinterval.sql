CREATE TABLE [dbo].[att_timeinterval] (
    [id]                      INT           IDENTITY (1, 1) NOT NULL,
    [alias]                   NVARCHAR (50) NOT NULL,
    [use_mode]                SMALLINT      NOT NULL,
    [in_time]                 TIME (7)      NOT NULL,
    [in_ahead_margin]         INT           NOT NULL,
    [in_above_margin]         INT           NOT NULL,
    [out_ahead_margin]        INT           NOT NULL,
    [out_above_margin]        INT           NOT NULL,
    [duration]                INT           NOT NULL,
    [in_required]             SMALLINT      NOT NULL,
    [out_required]            SMALLINT      NOT NULL,
    [allow_late]              INT           NOT NULL,
    [allow_leave_early]       INT           NOT NULL,
    [work_day]                FLOAT (53)    NOT NULL,
    [early_in]                SMALLINT      NOT NULL,
    [min_early_in]            INT           NOT NULL,
    [count_early_in_interval] BIT           NOT NULL,
    [late_out]                SMALLINT      NOT NULL,
    [min_late_out]            INT           NOT NULL,
    [count_late_out_interval] BIT           NOT NULL,
    [overtime_lv]             SMALLINT      NOT NULL,
    [overtime_lv1]            SMALLINT      NOT NULL,
    [overtime_lv2]            SMALLINT      NOT NULL,
    [overtime_lv3]            SMALLINT      NOT NULL,
    [multiple_punch]          SMALLINT      NOT NULL,
    [available_interval_type] SMALLINT      NOT NULL,
    [available_interval]      INT           NOT NULL,
    [work_time_duration]      INT           NOT NULL,
    [func_key]                SMALLINT      NOT NULL,
    [work_type]               SMALLINT      NOT NULL,
    [day_change]              TIME (7)      NOT NULL,
    [enable_early_in]         BIT           NOT NULL,
    [enable_late_out]         BIT           NOT NULL,
    [enable_overtime]         BIT           NOT NULL,
    [ot_rule]                 CHAR (32)     NULL,
    [color_setting]           NVARCHAR (30) NULL,
    [enable_max_ot_limit]     BIT           NOT NULL,
    [max_ot_limit]            INT           NOT NULL,
    [overtime_policy]         SMALLINT      NOT NULL,
    [compensate_duration]     INT           NOT NULL,
    [company_id]              INT           NOT NULL,
    [ot_pay_code_id]          INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_timeinterval_company_id_9824d651_fk_personnel_company_id] FOREIGN KEY ([company_id]) REFERENCES [dbo].[personnel_company] ([id]),
    CONSTRAINT [att_timeinterval_ot_pay_code_id_17438af8_fk_att_paycode_id] FOREIGN KEY ([ot_pay_code_id]) REFERENCES [dbo].[att_paycode] ([id]),
    UNIQUE NONCLUSTERED ([alias] ASC)
);


GO
CREATE NONCLUSTERED INDEX [att_timeinterval_company_id_9824d651]
    ON [dbo].[att_timeinterval]([company_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_timeinterval_ot_pay_code_id_17438af8]
    ON [dbo].[att_timeinterval]([ot_pay_code_id] ASC);

