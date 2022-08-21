CREATE TABLE [dbo].[Payee] (
    [IdNo]      INT      IDENTITY (1, 1) NOT NULL,
    [PayeeIdNo] INT      NULL,
    [PayeeType] CHAR (1) NULL,
    CONSTRAINT [PK_Payee] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

