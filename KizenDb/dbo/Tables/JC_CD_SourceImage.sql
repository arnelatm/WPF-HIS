CREATE TABLE [dbo].[JC_CD_SourceImage] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [Caption]    NVARCHAR (225)  NOT NULL,
    [SourceType] NVARCHAR (50)   NULL,
    [ImageArray] VARBINARY (MAX) NULL,
    CONSTRAINT [PK_dbo.JC_CD_SourceImage] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Caption]
    ON [dbo].[JC_CD_SourceImage]([Caption] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SourceType]
    ON [dbo].[JC_CD_SourceImage]([SourceType] ASC);

