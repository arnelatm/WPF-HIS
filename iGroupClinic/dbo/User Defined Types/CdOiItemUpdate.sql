CREATE TYPE [dbo].[CdOiItemUpdate] AS TABLE (
    [Amount]            MONEY NULL,
    [ApOpenInvoiceIdNo] INT   NOT NULL,
    [DiscountTaken]     MONEY NULL,
    [DjIdNo]            INT   NOT NULL,
    [IDNo]              INT   NOT NULL,
    [Sequence]          INT   NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

