CREATE TYPE [dbo].[CkdOiItemInsert] AS TABLE (
    [Amount]          MONEY NULL,
    [CkdIdNo]         INT   NOT NULL,
    [DiscountTaken]   MONEY NULL,
    [JournalItemIdNo] INT   NOT NULL,
    [Sequence]        INT   NOT NULL);

