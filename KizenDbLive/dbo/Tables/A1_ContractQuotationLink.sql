CREATE TABLE [dbo].[A1_ContractQuotationLink] (
    [ID]          INT IDENTITY (1, 1) NOT NULL,
    [ContractID]  INT NOT NULL,
    [QuotationID] INT NOT NULL,
    CONSTRAINT [PK_A1_ContractQuotationLink] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_A1_ContractQuotationLink_ContractID]
    ON [dbo].[A1_ContractQuotationLink]([ContractID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_ContractQuotationLink_QuotationID]
    ON [dbo].[A1_ContractQuotationLink]([QuotationID] ASC);

