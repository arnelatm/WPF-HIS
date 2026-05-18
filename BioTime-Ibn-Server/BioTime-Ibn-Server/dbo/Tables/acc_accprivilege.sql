CREATE TABLE [dbo].[acc_accprivilege] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [create_time]         DATETIME2 (7)  NULL,
    [create_user]         NVARCHAR (150) NULL,
    [change_time]         DATETIME2 (7)  NULL,
    [change_user]         NVARCHAR (150) NULL,
    [status]              SMALLINT       NOT NULL,
    [is_group_timezone]   SMALLINT       NOT NULL,
    [timezone1]           INT            NULL,
    [timezone2]           INT            NULL,
    [timezone3]           INT            NULL,
    [is_group_verifycode] SMALLINT       NOT NULL,
    [verify_mode]         INT            NULL,
    [update_time]         DATETIME2 (7)  NULL,
    [area_id]             INT            NOT NULL,
    [employee_id]         INT            NOT NULL,
    [group_id]            INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [acc_accprivilege_area_id_2123ff6f_fk_personnel_area_id] FOREIGN KEY ([area_id]) REFERENCES [dbo].[personnel_area] ([id]),
    CONSTRAINT [acc_accprivilege_employee_id_5fc55f95_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [acc_accprivilege_group_id_c5ed7003_fk_acc_accgroups_id] FOREIGN KEY ([group_id]) REFERENCES [dbo].[acc_accgroups] ([id])
);


GO
CREATE NONCLUSTERED INDEX [acc_accprivilege_area_id_2123ff6f]
    ON [dbo].[acc_accprivilege]([area_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [acc_accprivilege_area_id_employee_id_group_id_f3b297d8_uniq]
    ON [dbo].[acc_accprivilege]([area_id] ASC, [employee_id] ASC, [group_id] ASC) WHERE ([area_id] IS NOT NULL AND [employee_id] IS NOT NULL AND [group_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [acc_accprivilege_employee_id_5fc55f95]
    ON [dbo].[acc_accprivilege]([employee_id] ASC);


GO
CREATE NONCLUSTERED INDEX [acc_accprivilege_group_id_c5ed7003]
    ON [dbo].[acc_accprivilege]([group_id] ASC);

