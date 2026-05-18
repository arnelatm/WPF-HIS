CREATE TABLE [dbo].[authtoken_token] (
    [key]     NVARCHAR (40) NOT NULL,
    [created] DATETIME2 (7) NOT NULL,
    [user_id] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([key] ASC),
    CONSTRAINT [authtoken_token_user_id_35299eff_fk_auth_user_id] FOREIGN KEY ([user_id]) REFERENCES [dbo].[auth_user] ([id]),
    UNIQUE NONCLUSTERED ([user_id] ASC)
);

