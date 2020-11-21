CREATE TABLE [dbo].[CdOiItem] (
    [IdNo]              INT   IDENTITY (1, 1) NOT NULL,
    [CjIdNo]            INT   NOT NULL,
    [ApOpenInvoiceIdNo] INT   NOT NULL,
    [Sequence]          INT   NOT NULL,
    [Amount]            MONEY NOT NULL,
    [DiscountTaken]     MONEY NOT NULL,
    CONSTRAINT [PK_CdOiItemIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

