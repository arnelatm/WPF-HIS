CREATE TYPE [dbo].[CsrOiItemInsert] AS TABLE (
    [Amount]          MONEY NULL,
    [ApOpenInvoiceIdNo] INT   NOT NULL,
    [CsrIdNo]         INT   NOT NULL,
    [DiscountTaken]   MONEY NULL,
    [Sequence]        INT   NOT NULL);

