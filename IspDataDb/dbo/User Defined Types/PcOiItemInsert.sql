CREATE TYPE [dbo].[PcOiItemInsert] AS TABLE (
    [Amount]            MONEY NULL,
    [ApOpenInvoiceIdNo] INT   NOT NULL,
    [DjIdNo]            INT   NOT NULL,
    [DiscountTaken]     MONEY NULL,
    [Sequence]          INT   NOT NULL);

