CREATE TABLE [dbo].[base_bookmark] (
    [id]              INT             IDENTITY (1, 1) NOT NULL,
    [title]           NVARCHAR (128)  NOT NULL,
    [filters]         NVARCHAR (1000) NOT NULL,
    [is_share]        BIT             NOT NULL,
    [time_saved]      DATETIME2 (7)   NOT NULL,
    [content_type_id] INT             NOT NULL,
    [user_id]         INT             NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [base_bookmark_content_type_id_b6a0e799_fk_django_content_type_id] FOREIGN KEY ([content_type_id]) REFERENCES [dbo].[django_content_type] ([id]),
    CONSTRAINT [base_bookmark_user_id_5f2d5ca2_fk_auth_user_id] FOREIGN KEY ([user_id]) REFERENCES [dbo].[auth_user] ([id])
);


GO
CREATE NONCLUSTERED INDEX [base_bookmark_user_id_5f2d5ca2]
    ON [dbo].[base_bookmark]([user_id] ASC);


GO
CREATE NONCLUSTERED INDEX [base_bookmark_content_type_id_b6a0e799]
    ON [dbo].[base_bookmark]([content_type_id] ASC);

