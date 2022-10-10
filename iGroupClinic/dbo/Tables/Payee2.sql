CREATE TABLE [dbo].[Payee2] (
    [IdNo]      INT      IDENTITY (1, 1) NOT NULL,
    [PayeeIdNo] INT      NULL,
    [PayeeType] CHAR (1) NULL,
    CONSTRAINT [PK_Payee2] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

