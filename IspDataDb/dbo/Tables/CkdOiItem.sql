CREATE TABLE [dbo].[CkdOiItem] (
    [IdNo]              INT   IDENTITY (1, 1) NOT NULL,
    [CkdIdNo]           INT   NOT NULL,
    [ApOpenInvoiceIdNo] INT   NOT NULL,
    [Sequence]          INT   NOT NULL,
    [Amount]            MONEY CONSTRAINT [DF_CkdOiItem_Amount] DEFAULT ((0)) NOT NULL,
    [DiscountTaken]     MONEY CONSTRAINT [DF_CkdOiItem_DiscountTaken] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CkdOiItemIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);







