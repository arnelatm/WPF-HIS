CREATE TABLE [dbo].[auth_user_auth_area] (
    [id]        INT IDENTITY (1, 1) NOT NULL,
    [myuser_id] INT NOT NULL,
    [area_id]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [auth_user_auth_area_area_id_d1e54c70_fk_personnel_area_id] FOREIGN KEY ([area_id]) REFERENCES [dbo].[personnel_area] ([id]),
    CONSTRAINT [auth_user_auth_area_myuser_id_5fb9a803_fk_auth_user_id] FOREIGN KEY ([myuser_id]) REFERENCES [dbo].[auth_user] ([id])
);


GO
CREATE NONCLUSTERED INDEX [auth_user_auth_area_area_id_d1e54c70]
    ON [dbo].[auth_user_auth_area]([area_id] ASC);


GO
CREATE NONCLUSTERED INDEX [auth_user_auth_area_myuser_id_5fb9a803]
    ON [dbo].[auth_user_auth_area]([myuser_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [auth_user_auth_area_myuser_id_area_id_02a19d63_uniq]
    ON [dbo].[auth_user_auth_area]([myuser_id] ASC, [area_id] ASC) WHERE ([myuser_id] IS NOT NULL AND [area_id] IS NOT NULL);

