CREATE TABLE [dbo].[DataImage] (
    [IdNo]  INT             IDENTITY (1, 1) NOT NULL,
    [Image] VARBINARY (MAX) NULL,
    CONSTRAINT [PK_DataImage] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

