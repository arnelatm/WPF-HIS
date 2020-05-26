CREATE TYPE [dbo].[CadOiItemInsert] AS TABLE (
    [Amount]          MONEY NULL,
    [ApOpenInvoiceIdNo] INT   NOT NULL,
    [CadIdNo]         INT   NOT NULL,
    [DiscountTaken]   MONEY NULL,
    [Sequence]        INT   NOT NULL);

