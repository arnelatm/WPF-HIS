CREATE TYPE [dbo].[CsrOiItemInsert] AS TABLE (
    [Amount]          MONEY NULL,
    [CsrIdNo]         INT   NOT NULL,
    [DiscountTaken]   MONEY NULL,
    [JournalItemIdNo] INT   NOT NULL,
    [Sequence]        INT   NOT NULL);

