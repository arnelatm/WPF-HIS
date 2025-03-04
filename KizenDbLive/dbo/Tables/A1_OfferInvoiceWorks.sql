CREATE TABLE [dbo].[A1_OfferInvoiceWorks] (
    [ID]            INT             IDENTITY (1, 1) NOT NULL,
    [ForeignID]     INT             NULL,
    [Code]          NVARCHAR (MAX)  NULL,
    [Name]          NVARCHAR (MAX)  NULL,
    [Price]         DECIMAL (18, 2) NULL,
    [DiscountValue] DECIMAL (18, 2) NULL,
    [DiscountType]  INT             NULL,
    [SourceCode]    NVARCHAR (MAX)  NULL,
    [Count]         DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_A1_OfferInvoiceWorks] PRIMARY KEY CLUSTERED ([ID] ASC)
);

