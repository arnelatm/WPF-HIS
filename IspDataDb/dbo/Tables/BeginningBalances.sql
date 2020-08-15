CREATE TABLE [dbo].[BeginningBalances] (
    [IdNo]        INT      IDENTITY (1, 1) NOT NULL,
    [ContactType] CHAR (1) NULL,
    [ContactIdNo] INT      NULL,
    [Debit]       MONEY    NULL,
    [Credit]      MONEY    NULL,
    CONSTRAINT [PK_BeginningBalances] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



