CREATE TABLE [dbo].[auth_user_groups] (
    [id]        INT IDENTITY (1, 1) NOT NULL,
    [myuser_id] INT NOT NULL,
    [group_id]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [auth_user_groups_group_id_97559544_fk_auth_group_id] FOREIGN KEY ([group_id]) REFERENCES [dbo].[auth_group] ([id]),
    CONSTRAINT [auth_user_groups_myuser_id_d03e8dcc_fk_auth_user_id] FOREIGN KEY ([myuser_id]) REFERENCES [dbo].[auth_user] ([id])
);


GO
CREATE NONCLUSTERED INDEX [auth_user_groups_group_id_97559544]
    ON [dbo].[auth_user_groups]([group_id] ASC);


GO
CREATE NONCLUSTERED INDEX [auth_user_groups_myuser_id_d03e8dcc]
    ON [dbo].[auth_user_groups]([myuser_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [auth_user_groups_myuser_id_group_id_664bdfc3_uniq]
    ON [dbo].[auth_user_groups]([myuser_id] ASC, [group_id] ASC) WHERE ([myuser_id] IS NOT NULL AND [group_id] IS NOT NULL);

