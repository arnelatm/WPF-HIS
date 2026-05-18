CREATE TABLE [dbo].[auth_permission] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [name]            NVARCHAR (255) NOT NULL,
    [content_type_id] INT            NOT NULL,
    [codename]        NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [auth_permission_content_type_id_2f476e4b_fk_django_content_type_id] FOREIGN KEY ([content_type_id]) REFERENCES [dbo].[django_content_type] ([id])
);


GO
CREATE NONCLUSTERED INDEX [auth_permission_content_type_id_2f476e4b]
    ON [dbo].[auth_permission]([content_type_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [auth_permission_content_type_id_codename_01ab375a_uniq]
    ON [dbo].[auth_permission]([content_type_id] ASC, [codename] ASC) WHERE ([content_type_id] IS NOT NULL AND [codename] IS NOT NULL);

