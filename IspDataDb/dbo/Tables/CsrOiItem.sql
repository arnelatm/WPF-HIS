CREATE TABLE [dbo].[CsrOiItem] (
    [IdNo]            INT   IDENTITY (1, 1) NOT NULL,
    [ApOpenInvoiceIdNo] INT   NOT NULL,
    [CsrIdNo]         INT   NOT NULL,
    [Sequence]        INT   NOT NULL,
    [Amount]          MONEY CONSTRAINT [DF_CsrOiItem_Amount] DEFAULT ((0)) NOT NULL,
    [DiscountTaken]   MONEY CONSTRAINT [DF_CsrOiItem_DiscountTaken] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CsrOiItemIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

