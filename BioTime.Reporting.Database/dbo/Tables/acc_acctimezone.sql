CREATE TABLE [dbo].[acc_acctimezone] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [create_time]   DATETIME2 (7)  NULL,
    [create_user]   NVARCHAR (150) NULL,
    [change_time]   DATETIME2 (7)  NULL,
    [change_user]   NVARCHAR (150) NULL,
    [status]        SMALLINT       NOT NULL,
    [timezone_no]   INT            NOT NULL,
    [timezone_name] NVARCHAR (100) NOT NULL,
    [sun_start]     TIME (7)       NOT NULL,
    [sun_end]       TIME (7)       NOT NULL,
    [sun_on]        SMALLINT       NULL,
    [mon_start]     TIME (7)       NOT NULL,
    [mon_end]       TIME (7)       NOT NULL,
    [mon_on]        SMALLINT       NULL,
    [tue_start]     TIME (7)       NOT NULL,
    [tue_end]       TIME (7)       NOT NULL,
    [tue_on]        SMALLINT       NULL,
    [wed_start]     TIME (7)       NOT NULL,
    [wed_end]       TIME (7)       NOT NULL,
    [wed_on]        SMALLINT       NULL,
    [thu_start]     TIME (7)       NOT NULL,
    [thu_end]       TIME (7)       NOT NULL,
    [thu_on]        SMALLINT       NULL,
    [fri_start]     TIME (7)       NOT NULL,
    [fri_end]       TIME (7)       NOT NULL,
    [fri_on]        SMALLINT       NULL,
    [sat_start]     TIME (7)       NOT NULL,
    [sat_end]       TIME (7)       NOT NULL,
    [sat_on]        SMALLINT       NULL,
    [remark]        NVARCHAR (999) NULL,
    [update_time]   DATETIME2 (7)  NULL,
    [area_id]       INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [acc_acctimezone_area_id_e9ce7a7a_fk_personnel_area_id] FOREIGN KEY ([area_id]) REFERENCES [dbo].[personnel_area] ([id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [acc_acctimezone_area_id_timezone_no_0cb8250f_uniq]
    ON [dbo].[acc_acctimezone]([area_id] ASC, [timezone_no] ASC) WHERE ([area_id] IS NOT NULL AND [timezone_no] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [acc_acctimezone_area_id_e9ce7a7a]
    ON [dbo].[acc_acctimezone]([area_id] ASC);

