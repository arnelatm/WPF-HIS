CREATE TABLE [dbo].[FormItems] (
    [IdNo]        INT      IDENTITY (1, 1) NOT NULL,
    [SystemViewIdNo]    SMALLINT NOT NULL,
    [CaptionIdNo] INT      NOT NULL,
    CONSTRAINT [PK_FormItemsIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_FormItemsFormIdNo]
    ON [dbo].[FormItems]([SystemViewIdNo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FormItemsOriginalIdNo]
    ON [dbo].[FormItems]([CaptionIdNo] ASC);

