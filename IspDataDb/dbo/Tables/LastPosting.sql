CREATE TABLE [dbo].[LastPosting] (
    [IdNo]               INT          IDENTITY (1, 1) NOT NULL,
    [LastPostingDate]    DATE         NULL,
    [TransactionName]    VARCHAR (25) NULL,
    [LastPostingDateOld] DATE         NULL,
    CONSTRAINT [PK_LastPosting] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





