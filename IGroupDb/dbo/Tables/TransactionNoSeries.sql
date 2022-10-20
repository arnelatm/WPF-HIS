CREATE TABLE [dbo].[TransactionNoSeries] (
    [BranchID]           VARCHAR (15)  NOT NULL,
    [TransactionType]    VARCHAR (10)  NOT NULL,
    [SeriesID]           VARCHAR (25)  NULL,
    [TransactionSeries]  VARCHAR (25)  NULL,
    [CurrentNo]          NUMERIC (10)  NULL,
    [DescriptionEnglish] VARCHAR (35)  NULL,
    [DescriptionArabic]  NVARCHAR (35) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_TransactionNoSeries]
    ON [dbo].[TransactionNoSeries]([BranchID] ASC, [TransactionType] ASC, [SeriesID] ASC);

