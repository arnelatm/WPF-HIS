CREATE TYPE [dbo].[CadOiItemUpdate] AS TABLE (
    [Amount]          MONEY NULL,
    [CadIdNo]         INT   NOT NULL,
    [DiscountTaken]   MONEY NULL,
    [IDNo]            INT   NOT NULL,
    [JournalItemIdNo] INT   NOT NULL,
    [Sequence]        INT   NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

