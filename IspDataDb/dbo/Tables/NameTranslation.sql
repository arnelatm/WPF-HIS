CREATE TABLE [dbo].[NameTranslation] (
    [IdNo]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [Language]          CHAR (2)       NOT NULL,
    [DatabaseTableIdNo] SMALLINT       NOT NULL,
    [TableIdNo]         SMALLINT       NOT NULL,
    [Name]              NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_NameTranslation] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_NameTranslation_DbTbIdNo]
    ON [dbo].[NameTranslation]([DatabaseTableIdNo] ASC);

