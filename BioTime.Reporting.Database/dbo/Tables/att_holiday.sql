CREATE TABLE [dbo].[att_holiday] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [alias]          NVARCHAR (50) NOT NULL,
    [start_date]     DATE          NOT NULL,
    [duration_day]   SMALLINT      NOT NULL,
    [end_date]       DATE          NOT NULL,
    [enable_ot_rule] BIT           NOT NULL,
    [ot_rule]        CHAR (32)     NULL,
    [color_setting]  NVARCHAR (30) NULL,
    [att_group_id]   INT           NULL,
    [department_id]  INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_holiday_att_group_id_9ddf13ba_fk_att_attgroup_id] FOREIGN KEY ([att_group_id]) REFERENCES [dbo].[att_attgroup] ([id]),
    CONSTRAINT [att_holiday_department_id_fbbbd185_fk_personnel_department_id] FOREIGN KEY ([department_id]) REFERENCES [dbo].[personnel_department] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_holiday_department_id_fbbbd185]
    ON [dbo].[att_holiday]([department_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_holiday_att_group_id_9ddf13ba]
    ON [dbo].[att_holiday]([att_group_id] ASC);

