CREATE TABLE [dbo].[att_breaktime] (
    [id]                      INT           IDENTITY (1, 1) NOT NULL,
    [alias]                   NVARCHAR (50) NOT NULL,
    [period_start]            TIME (7)      NOT NULL,
    [duration]                INT           NOT NULL,
    [end_margin]              INT           NOT NULL,
    [func_key]                SMALLINT      NOT NULL,
    [available_interval_type] SMALLINT      NOT NULL,
    [available_interval]      INT           NOT NULL,
    [multiple_punch]          SMALLINT      NOT NULL,
    [calc_type]               SMALLINT      NOT NULL,
    [minimum_duration]        INT           NULL,
    [early_in]                SMALLINT      NOT NULL,
    [late_in]                 SMALLINT      NOT NULL,
    [profit_rule]             BIT           NOT NULL,
    [min_early_in]            INT           NOT NULL,
    [loss_rule]               BIT           NOT NULL,
    [min_late_in]             INT           NOT NULL,
    [with_salary]             SMALLINT      NOT NULL,
    [company_id]              INT           NOT NULL,
    [loss_code_id]            INT           NULL,
    [profit_code_id]          INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_breaktime_company_id_fbb9a2b7_fk_personnel_company_id] FOREIGN KEY ([company_id]) REFERENCES [dbo].[personnel_company] ([id]),
    CONSTRAINT [att_breaktime_loss_code_id_2ffb5432_fk_att_paycode_id] FOREIGN KEY ([loss_code_id]) REFERENCES [dbo].[att_paycode] ([id]),
    CONSTRAINT [att_breaktime_profit_code_id_63cdbbcc_fk_att_paycode_id] FOREIGN KEY ([profit_code_id]) REFERENCES [dbo].[att_paycode] ([id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [att_breaktime_alias_6212d9cf_uniq]
    ON [dbo].[att_breaktime]([alias] ASC) WHERE ([alias] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [att_breaktime_company_id_fbb9a2b7]
    ON [dbo].[att_breaktime]([company_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_breaktime_loss_code_id_2ffb5432]
    ON [dbo].[att_breaktime]([loss_code_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_breaktime_profit_code_id_63cdbbcc]
    ON [dbo].[att_breaktime]([profit_code_id] ASC);

