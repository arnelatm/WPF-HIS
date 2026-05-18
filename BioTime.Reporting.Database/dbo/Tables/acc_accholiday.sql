CREATE TABLE [dbo].[acc_accholiday] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [create_time] DATETIME2 (7)  NULL,
    [create_user] NVARCHAR (150) NULL,
    [change_time] DATETIME2 (7)  NULL,
    [change_user] NVARCHAR (150) NULL,
    [status]      SMALLINT       NOT NULL,
    [update_time] DATETIME2 (7)  NULL,
    [area_id]     INT            NOT NULL,
    [holiday_id]  INT            NOT NULL,
    [timezone_id] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [acc_accholiday_area_id_d15c19da_fk_personnel_area_id] FOREIGN KEY ([area_id]) REFERENCES [dbo].[personnel_area] ([id]),
    CONSTRAINT [acc_accholiday_holiday_id_a9efe924_fk_att_holiday_id] FOREIGN KEY ([holiday_id]) REFERENCES [dbo].[att_holiday] ([id]),
    CONSTRAINT [acc_accholiday_timezone_id_450d2d1e_fk_acc_acctimezone_id] FOREIGN KEY ([timezone_id]) REFERENCES [dbo].[acc_acctimezone] ([id])
);


GO
CREATE NONCLUSTERED INDEX [acc_accholiday_timezone_id_450d2d1e]
    ON [dbo].[acc_accholiday]([timezone_id] ASC);


GO
CREATE NONCLUSTERED INDEX [acc_accholiday_holiday_id_a9efe924]
    ON [dbo].[acc_accholiday]([holiday_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [acc_accholiday_area_id_holiday_id_6630c2eb_uniq]
    ON [dbo].[acc_accholiday]([area_id] ASC, [holiday_id] ASC) WHERE ([area_id] IS NOT NULL AND [holiday_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [acc_accholiday_area_id_d15c19da]
    ON [dbo].[acc_accholiday]([area_id] ASC);

