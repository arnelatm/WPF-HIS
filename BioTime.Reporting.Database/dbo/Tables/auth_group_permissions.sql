CREATE TABLE [dbo].[auth_group_permissions] (
    [id]            INT IDENTITY (1, 1) NOT NULL,
    [group_id]      INT NOT NULL,
    [permission_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [auth_group_permissions_group_id_b120cbf9_fk_auth_group_id] FOREIGN KEY ([group_id]) REFERENCES [dbo].[auth_group] ([id]),
    CONSTRAINT [auth_group_permissions_permission_id_84c5c92e_fk_auth_permission_id] FOREIGN KEY ([permission_id]) REFERENCES [dbo].[auth_permission] ([id])
);


GO
CREATE NONCLUSTERED INDEX [auth_group_permissions_permission_id_84c5c92e]
    ON [dbo].[auth_group_permissions]([permission_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [auth_group_permissions_group_id_permission_id_0cd325b0_uniq]
    ON [dbo].[auth_group_permissions]([group_id] ASC, [permission_id] ASC) WHERE ([group_id] IS NOT NULL AND [permission_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [auth_group_permissions_group_id_b120cbf9]
    ON [dbo].[auth_group_permissions]([group_id] ASC);

