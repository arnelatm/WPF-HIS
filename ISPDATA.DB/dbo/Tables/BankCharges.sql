CREATE TABLE [dbo].[BankCharges] (
    [IdNo]      INT            IDENTITY (1, 1) NOT NULL,
    [CashCode]  CHAR (2)       COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [StartDate] DATE           NULL,
    [EndDate]   DATE           NULL,
    [Rate]      DECIMAL (5, 2) NULL,
    CONSTRAINT [PK_BankCharges] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

