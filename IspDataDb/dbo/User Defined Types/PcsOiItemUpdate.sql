CREATE TYPE [dbo].[PcsOiItemUpdate] AS TABLE (
    [Amount]          MONEY NULL,
    [ApOpenInvoiceIdNo] INT   NOT NULL,   
    [DiscountTaken]   MONEY NULL,
    [IDNo]            INT   NOT NULL,
    [PcsIdNo]         INT   NOT NULL,
    [Sequence]        INT   NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

