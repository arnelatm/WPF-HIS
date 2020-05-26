CREATE TYPE [dbo].[CadOiItemUpdate] AS TABLE (
    [Amount]          MONEY NULL,
    [ApOpenInvoiceIdNo] INT   NOT NULL,
    [CadIdNo]         INT   NOT NULL,
    [DiscountTaken]   MONEY NULL,
    [IDNo]            INT   NOT NULL,
    [Sequence]        INT   NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

