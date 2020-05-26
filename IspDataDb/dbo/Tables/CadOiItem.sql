CREATE TABLE [dbo].[CadOiItem] (
    [IdNo]              INT   IDENTITY (1, 1) NOT NULL,
    [CadIdNo]           INT   NOT NULL,
    [ApOpenInvoiceIdNo] INT   NOT NULL,
    [Sequence]          INT   NOT NULL,
    [Amount]            MONEY NOT NULL,
    [DiscountTaken]     MONEY NOT NULL,
    CONSTRAINT [PK_CadOiItemIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);







