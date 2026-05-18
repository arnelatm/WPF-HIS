CREATE TABLE [dbo].[acc_accgroups] (
    [id]                 INT            IDENTITY (1, 1) NOT NULL,
    [create_time]        DATETIME2 (7)  NULL,
    [create_user]        NVARCHAR (150) NULL,
    [change_time]        DATETIME2 (7)  NULL,
    [change_user]        NVARCHAR (150) NULL,
    [status]             SMALLINT       NOT NULL,
    [group_no]           INT            NOT NULL,
    [group_name]         NVARCHAR (100) NOT NULL,
    [verify_mode]        INT            NOT NULL,
    [timezone1]          INT            NULL,
    [timezone2]          INT            NULL,
    [timezone3]          INT            NULL,
    [is_include_holiday] SMALLINT       NOT NULL,
    [update_time]        DATETIME2 (7)  NULL,
    [area_id]            INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [acc_accgroups_area_id_b83745c3_fk_personnel_area_id] FOREIGN KEY ([area_id]) REFERENCES [dbo].[personnel_area] ([id])
);


GO
CREATE NONCLUSTERED INDEX [acc_accgroups_area_id_b83745c3]
    ON [dbo].[acc_accgroups]([area_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [acc_accgroups_area_id_group_no_5130a89c_uniq]
    ON [dbo].[acc_accgroups]([area_id] ASC, [group_no] ASC) WHERE ([area_id] IS NOT NULL AND [group_no] IS NOT NULL);

