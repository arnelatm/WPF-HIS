CREATE TABLE [dbo].[visitor_visitor_acc_groups] (
    [id]           INT IDENTITY (1, 1) NOT NULL,
    [visitor_id]   INT NOT NULL,
    [accgroups_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [visitor_visitor_acc_groups_accgroups_id_b1487149_fk_acc_accgroups_id] FOREIGN KEY ([accgroups_id]) REFERENCES [dbo].[acc_accgroups] ([id]),
    CONSTRAINT [visitor_visitor_acc_groups_visitor_id_8ce09562_fk_visitor_visitor_id] FOREIGN KEY ([visitor_id]) REFERENCES [dbo].[visitor_visitor] ([id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [visitor_visitor_acc_groups_visitor_id_accgroups_id_bb522609_uniq]
    ON [dbo].[visitor_visitor_acc_groups]([visitor_id] ASC, [accgroups_id] ASC) WHERE ([visitor_id] IS NOT NULL AND [accgroups_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [visitor_visitor_acc_groups_visitor_id_8ce09562]
    ON [dbo].[visitor_visitor_acc_groups]([visitor_id] ASC);


GO
CREATE NONCLUSTERED INDEX [visitor_visitor_acc_groups_accgroups_id_b1487149]
    ON [dbo].[visitor_visitor_acc_groups]([accgroups_id] ASC);

