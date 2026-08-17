CREATE TYPE [dbo].[CkdOiItemInsert] AS TABLE (
    [Amount]            MONEY NULL,
    [ApOpenInvoiceIdNo] INT   NOT NULL,
    [CkdIdNo]           INT   NOT NULL,
    [DiscountTaken]     MONEY NULL,
    [Sequence]          INT   NOT NULL);


GO

