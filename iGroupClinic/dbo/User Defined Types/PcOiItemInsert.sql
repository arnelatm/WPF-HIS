CREATE TYPE [dbo].[PcOiItemInsert] AS TABLE (
    [Amount]            MONEY NULL,
    [ApOpenInvoiceIdNo] INT   NOT NULL,
    [DiscountTaken]     MONEY NULL,
    [DjIdNo]            INT   NOT NULL,
    [Sequence]          INT   NOT NULL);

