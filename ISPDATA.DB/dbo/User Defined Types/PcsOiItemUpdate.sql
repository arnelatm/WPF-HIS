CREATE TYPE [dbo].[PcsOiItemUpdate] AS TABLE (
    [Amount]          MONEY NULL,
    [PtcIdNo]         INT   NOT NULL,
    [DiscountTaken]   MONEY NULL,
    [IDNo]            INT   NOT NULL,
    [JournalItemIdNo] INT   NOT NULL,
    [Sequence]        INT   NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

