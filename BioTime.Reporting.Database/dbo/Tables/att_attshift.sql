CREATE TABLE [dbo].[att_attshift] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [alias]          NVARCHAR (50) NOT NULL,
    [cycle_unit]     SMALLINT      NOT NULL,
    [shift_cycle]    INT           NOT NULL,
    [work_weekend]   BIT           NOT NULL,
    [weekend_type]   SMALLINT      NOT NULL,
    [work_day_off]   BIT           NOT NULL,
    [day_off_type]   SMALLINT      NOT NULL,
    [auto_shift]     SMALLINT      NOT NULL,
    [enable_ot_rule] BIT           NOT NULL,
    [frequency]      SMALLINT      NOT NULL,
    [ot_rule]        CHAR (32)     NULL,
    [company_id]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_attshift_company_id_2c0a4f56_fk_personnel_company_id] FOREIGN KEY ([company_id]) REFERENCES [dbo].[personnel_company] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_attshift_company_id_2c0a4f56]
    ON [dbo].[att_attshift]([company_id] ASC);

