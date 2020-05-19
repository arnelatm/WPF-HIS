CREATE TYPE [dbo].[CsrOiItemUpdate] AS TABLE (
    [Amount]          MONEY NULL,
    [CsrIdNo]         INT   NOT NULL,
    [DiscountTaken]   MONEY NULL,
    [IDNo]            INT   NOT NULL,
    [JournalItemIdNo] INT   NOT NULL,
    [Sequence]        INT   NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

