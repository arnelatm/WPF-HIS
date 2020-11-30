CREATE TABLE [dbo].[DiscountScheme] (
    [IdNo]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [Code]          VARCHAR (5)    NOT NULL,
    [Name]          VARCHAR (50)   NOT NULL,
    [NameAra]       NVARCHAR (50)  NULL,
    [Note]          NVARCHAR (255) NULL,
    [DateTimeStamp] ROWVERSION     NULL,
    CONSTRAINT [PK_DiscountScheme] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

