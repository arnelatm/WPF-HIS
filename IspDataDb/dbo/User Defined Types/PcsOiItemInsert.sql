CREATE TYPE [dbo].[PcsOiItemInsert] AS TABLE (
    [Amount]          MONEY NULL,
    [ApOpenInvoiceIdNo] INT   NOT NULL,
    [DiscountTaken]   MONEY NULL,
    [PcsIdNo]         INT   NOT NULL,
    [Sequence]        INT   NOT NULL);

