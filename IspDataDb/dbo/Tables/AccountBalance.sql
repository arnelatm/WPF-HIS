CREATE TABLE [dbo].[AccountBalance] (
    [IdNo]          INT        IDENTITY (1, 1) NOT NULL,
    [Year]          SMALLINT   NOT NULL,
    [AccountIdNo]   SMALLINT   NOT NULL,
    [Debit]         MONEY      NULL,
    [Credit]        MONEY      NULL,
    [DateTimeStamp] ROWVERSION NULL,
    CONSTRAINT [PK_AccountBalance] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_AccountBalance_Year_IdNo]
    ON [dbo].[AccountBalance]([Year] ASC, [AccountIdNo] ASC);

