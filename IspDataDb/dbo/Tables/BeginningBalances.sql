CREATE TABLE [dbo].[BeginningBalances] (
    [IdNo]        INT      IDENTITY (1, 1) NOT NULL,
    [AccountType] CHAR (2) NULL,
    [PayIdNo]     INT      NULL,
    [Debit]       MONEY    NULL,
    [Credit]      MONEY    NULL,
    CONSTRAINT [PK_BeginningBalances] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

