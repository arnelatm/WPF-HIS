CREATE TABLE [dbo].[SystemViewItem] (
    [IdNo]           INT      IDENTITY (1, 1) NOT NULL,
    [SystemViewIdNo] SMALLINT NOT NULL,
    [CaptionIdNo]    INT      NOT NULL,
    CONSTRAINT [PK_SystemViewItemIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

