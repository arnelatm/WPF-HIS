CREATE TABLE [dbo].[GTIN] (
    [IdNo]           INT          IDENTITY (1, 1) NOT NULL,
    [GTIN]           VARCHAR (14) NULL,
    [ItemPrimaryKey] INT          NULL,
    CONSTRAINT [PK_GTIN] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

