CREATE TYPE [dbo].[CdOiItemInsert] AS TABLE (
    [Amount]            MONEY NULL,
    [ApOpenInvoiceIdNo] INT   NOT NULL,
    [CjIdNo]            INT   NOT NULL,
    [DiscountTaken]     MONEY NULL,
    [Sequence]          INT   NOT NULL);

