CREATE TABLE [dbo].[auth_user_user_permissions] (
    [id]            INT IDENTITY (1, 1) NOT NULL,
    [myuser_id]     INT NOT NULL,
    [permission_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [auth_user_user_permissions_myuser_id_679b1527_fk_auth_user_id] FOREIGN KEY ([myuser_id]) REFERENCES [dbo].[auth_user] ([id]),
    CONSTRAINT [auth_user_user_permissions_permission_id_1fbb5f2c_fk_auth_permission_id] FOREIGN KEY ([permission_id]) REFERENCES [dbo].[auth_permission] ([id])
);


GO
CREATE NONCLUSTERED INDEX [auth_user_user_permissions_myuser_id_679b1527]
    ON [dbo].[auth_user_user_permissions]([myuser_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [auth_user_user_permissions_myuser_id_permission_id_a558717f_uniq]
    ON [dbo].[auth_user_user_permissions]([myuser_id] ASC, [permission_id] ASC) WHERE ([myuser_id] IS NOT NULL AND [permission_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [auth_user_user_permissions_permission_id_1fbb5f2c]
    ON [dbo].[auth_user_user_permissions]([permission_id] ASC);

