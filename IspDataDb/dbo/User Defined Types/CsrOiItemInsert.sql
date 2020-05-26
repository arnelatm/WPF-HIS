CREATE TYPE [dbo].[CsrOiItemInsert] AS TABLE (
    [Amount]          MONEY NULL,
    [ArOpenInvoiceIdNo] INT   NOT NULL,
    [CsrIdNo]         INT   NOT NULL,
    [DiscountTaken]   MONEY NULL,
    [Sequence]        INT   NOT NULL);

