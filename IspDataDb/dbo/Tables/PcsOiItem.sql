CREATE TABLE [dbo].[PcsOiItem] (
    [IdNo]              INT      IDENTITY (1, 1) NOT NULL,
    [PcsIdNo]           INT      NOT NULL,
    [ApOpenInvoiceIdNo] INT      NOT NULL,
    [Sequence]          SMALLINT NOT NULL,
    [Amount]            MONEY    NOT NULL,
    [DiscountTaken]     MONEY    NOT NULL,
    CONSTRAINT [PK_PcsOiItemIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





