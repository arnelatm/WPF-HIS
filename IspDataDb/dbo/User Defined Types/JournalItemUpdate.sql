CREATE TYPE [dbo].[JournalItemUpdate] AS TABLE (
    [AccountIdNo]       INT            NOT NULL,
    [ContactIdNo]       INT            NULL,
    [Credit]            MONEY          NOT NULL,
    [Debit]             MONEY          NOT NULL,
    [IDNo]              INT            NOT NULL,
    [JournalIDNo]       INT            NOT NULL,
    [Notes]             NVARCHAR (300) NULL,
    [PayIdNo]           INT            NULL,
    [RevCostCenterIdNo] INT            NULL,
    [Sequence]          INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));





