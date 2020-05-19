CREATE TYPE [dbo].[PcsOiItemInsert] AS TABLE (
    [Amount]          MONEY NULL,
    [PcsIdNo]         INT   NOT NULL,
    [DiscountTaken]   MONEY NULL,
    [JournalItemIdNo] INT   NOT NULL,
    [Sequence]        INT   NOT NULL);

