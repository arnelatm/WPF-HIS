CREATE TABLE [dbo].[accounts_usernotification] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [category]  INT            NULL,
    [event]     INT            NULL,
    [content]   NVARCHAR (MAX) NOT NULL,
    [send_time] DATETIME2 (7)  NOT NULL,
    [read_time] DATETIME2 (7)  NULL,
    [status]    SMALLINT       NOT NULL,
    [user_id]   INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [accounts_usernotification_user_id_b86755b3_fk_auth_user_id] FOREIGN KEY ([user_id]) REFERENCES [dbo].[auth_user] ([id])
);


GO
CREATE NONCLUSTERED INDEX [accounts_usernotification_user_id_b86755b3]
    ON [dbo].[accounts_usernotification]([user_id] ASC);

