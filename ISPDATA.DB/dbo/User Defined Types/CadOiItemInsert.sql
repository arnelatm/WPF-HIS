CREATE TYPE [dbo].[CadOiItemInsert] AS TABLE (
    [Amount]          MONEY NULL,
    [CadIdNo]         INT   NOT NULL,
    [DiscountTaken]   MONEY NULL,
    [JournalItemIdNo] INT   NOT NULL,
    [Sequence]        INT   NOT NULL);

