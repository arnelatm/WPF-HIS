CREATE TYPE [dbo].[JournalItemUpdatex] AS TABLE (
    [AccountIdNo]      INT            NOT NULL,
    [Credit]           MONEY          NOT NULL,
    [Debit]            MONEY          NOT NULL,
    [IDNo]             INT            NOT NULL,
    [JournalIDNo]      INT            NOT NULL,
    [Notes]            NVARCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ProfitCenterIdNo] INT            NOT NULL,
    [Sequence]         INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));



