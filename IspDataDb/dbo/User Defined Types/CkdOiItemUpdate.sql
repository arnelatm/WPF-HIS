CREATE TYPE [dbo].[CkdOiItemUpdate] AS TABLE (
    [Amount]          MONEY NULL,
    [ApOpenInvoiceIdNo] INT   NOT NULL,
    [CkdIdNo]         INT   NOT NULL,
    [DiscountTaken]   MONEY NULL,
    [IDNo]            INT   NOT NULL,
    [Sequence]        INT   NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

