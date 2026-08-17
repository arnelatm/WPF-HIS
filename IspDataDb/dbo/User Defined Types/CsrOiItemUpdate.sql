CREATE TYPE [dbo].[CsrOiItemUpdate] AS TABLE (
    [Amount]            MONEY NULL,
    [ArOpenInvoiceIdNo] INT   NOT NULL,
    [CsrIdNo]           INT   NOT NULL,
    [DiscountTaken]     MONEY NULL,
    [IDNo]              INT   NOT NULL,
    [Sequence]          INT   NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));


GO

