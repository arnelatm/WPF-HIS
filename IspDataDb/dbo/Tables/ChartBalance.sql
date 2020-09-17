CREATE TABLE [dbo].[ChartBalance] (
    [IdNo]          INT        IDENTITY (1, 1) NOT NULL,
    [Year]          SMALLINT   NOT NULL,
    [AccountIdNo]   SMALLINT   NOT NULL,
    [Debit]         MONEY      NULL,
    [Credit]        MONEY      NULL,
    [DateTimeStamp] ROWVERSION NULL,
    CONSTRAINT [PK_ChartBalance] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_ChartBalance_Year_IdNo]
    ON [dbo].[ChartBalance]([Year] ASC, [AccountIdNo] ASC);

