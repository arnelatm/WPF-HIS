CREATE TABLE [dbo].[AccountBalance] (
    [IdNo]          INT        IDENTITY (1, 1) NOT NULL,
    [Year]          INT        NOT NULL,
    [AccountIdNo]   INT        NOT NULL,
    [Debit]         MONEY      NULL,
    [Credit]        MONEY      NULL,
    [DateTimeStamp] ROWVERSION NULL,
    CONSTRAINT [PK_AccountBalance] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [UQ_AccountBalance_Year_Account] UNIQUE NONCLUSTERED ([Year] ASC, [AccountIdNo] ASC)
);


GO

