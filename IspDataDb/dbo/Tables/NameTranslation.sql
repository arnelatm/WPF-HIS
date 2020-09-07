CREATE TABLE [dbo].[NameTranslation] (
    [IdNo]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [DatabaseTableIdNo] SMALLINT       NULL,
    [TableIdNo]         INT            NULL,
    [Name]              NVARCHAR (100) NULL,
    CONSTRAINT [PK_NameTranslation] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_NameTranslation_DbTbIdNo]
    ON [dbo].[NameTranslation]([DatabaseTableIdNo] ASC);

