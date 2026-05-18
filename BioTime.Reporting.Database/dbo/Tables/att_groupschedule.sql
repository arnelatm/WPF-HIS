CREATE TABLE [dbo].[att_groupschedule] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [create_time] DATETIME2 (7)  NULL,
    [create_user] NVARCHAR (150) NULL,
    [change_time] DATETIME2 (7)  NULL,
    [change_user] NVARCHAR (150) NULL,
    [status]      SMALLINT       NOT NULL,
    [start_date]  DATE           NOT NULL,
    [end_date]    DATE           NOT NULL,
    [group_id]    INT            NOT NULL,
    [shift_id]    INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_groupschedule_group_id_c341493f_fk_att_attgroup_id] FOREIGN KEY ([group_id]) REFERENCES [dbo].[att_attgroup] ([id]),
    CONSTRAINT [att_groupschedule_shift_id_287e7fc0_fk_att_attshift_id] FOREIGN KEY ([shift_id]) REFERENCES [dbo].[att_attshift] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_groupschedule_shift_id_287e7fc0]
    ON [dbo].[att_groupschedule]([shift_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_groupschedule_group_id_c341493f]
    ON [dbo].[att_groupschedule]([group_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_groupschedule_start_date_638b6d85]
    ON [dbo].[att_groupschedule]([start_date] ASC);

