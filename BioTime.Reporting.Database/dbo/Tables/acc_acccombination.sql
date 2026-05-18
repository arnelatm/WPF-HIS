CREATE TABLE [dbo].[acc_acccombination] (
    [id]               INT            IDENTITY (1, 1) NOT NULL,
    [create_time]      DATETIME2 (7)  NULL,
    [create_user]      NVARCHAR (150) NULL,
    [change_time]      DATETIME2 (7)  NULL,
    [change_user]      NVARCHAR (150) NULL,
    [status]           SMALLINT       NOT NULL,
    [combination_no]   INT            NOT NULL,
    [combination_name] NVARCHAR (100) NOT NULL,
    [group1]           INT            NULL,
    [group2]           INT            NULL,
    [group3]           INT            NULL,
    [group4]           INT            NULL,
    [group5]           INT            NULL,
    [remark]           NVARCHAR (999) NULL,
    [update_time]      DATETIME2 (7)  NULL,
    [area_id]          INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [acc_acccombination_area_id_0d22c34e_fk_personnel_area_id] FOREIGN KEY ([area_id]) REFERENCES [dbo].[personnel_area] ([id])
);


GO
CREATE NONCLUSTERED INDEX [acc_acccombination_area_id_0d22c34e]
    ON [dbo].[acc_acccombination]([area_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [acc_acccombination_area_id_combination_no_619eb4f5_uniq]
    ON [dbo].[acc_acccombination]([area_id] ASC, [combination_no] ASC) WHERE ([area_id] IS NOT NULL AND [combination_no] IS NOT NULL);

