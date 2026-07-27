CREATE TABLE [dbo].[JZ_Invoice] (
    [Id]                            INT             IDENTITY (1, 1) NOT NULL,
    [IssuedDateTime]                DATETIME        NOT NULL,
    [CreatedDateTime]               DATETIME        NOT NULL,
    [InvoiceType]                   INT             NOT NULL,
    [Status]                        INT             NOT NULL,
    [CompanyId]                     INT             NOT NULL,
    [CertificateId]                 INT             NOT NULL,
    [DeviceName]                    NVARCHAR (MAX)  NOT NULL,
    [FriendlyDeviceName]            NVARCHAR (MAX)  NULL,
    [UserId]                        INT             NOT NULL,
    [UserName]                      NVARCHAR (MAX)  NOT NULL,
    [SystemId]                      INT             NOT NULL,
    [SourceType]                    NVARCHAR (200)  NOT NULL,
    [SourceId]                      NVARCHAR (100)  NOT NULL,
    [UUID]                          NVARCHAR (200)  NOT NULL,
    [Counter]                       INT             NOT NULL,
    [InvoiceNumberPrefix]           NVARCHAR (15)   NULL,
    [InvoiceNumber]                 INT             NOT NULL,
    [FullInvoiceNumber]             NVARCHAR (127)  NOT NULL,
    [PreviousInvoiceHash]           NVARCHAR (MAX)  NULL,
    [CurrentInvoiceHash]            NVARCHAR (MAX)  NULL,
    [InvoiceXML]                    NVARCHAR (MAX)  NULL,
    [GeneratedQR]                   NVARCHAR (MAX)  NULL,
    [ReportingDateTime]             DATETIME        NULL,
    [ReportingResponse]             NVARCHAR (MAX)  NULL,
    [ReportingMessage]              NVARCHAR (MAX)  NULL,
    [IsWarning]                     BIT             NOT NULL,
    [ThirdPartyInvoice]             BIT             NOT NULL,
    [NominalInvoice]                BIT             NOT NULL,
    [ExportsInvoice]                BIT             NOT NULL,
    [SummaryInvoice]                BIT             NOT NULL,
    [SelfBilledInvoice]             BIT             NOT NULL,
    [DocumentCurrencyCode]          NVARCHAR (10)   NOT NULL,
    [TaxCurrencyCode]               NVARCHAR (10)   NOT NULL,
    [BillingReferenceID]            NVARCHAR (MAX)  NULL,
    [SupplyDate]                    DATETIME        NULL,
    [SupplyEndDate]                 DATETIME        NULL,
    [ReasonsForCreditDebitNote]     NVARCHAR (1000) NULL,
    [OtherSellerID]                 NVARCHAR (MAX)  NOT NULL,
    [OtherSellerSchemeID]           NVARCHAR (10)   NOT NULL,
    [SellerAddressStreet]           NVARCHAR (1000) NOT NULL,
    [SellerAddressBuildingNumber]   NVARCHAR (10)   NOT NULL,
    [SellerAddressCity]             NVARCHAR (127)  NOT NULL,
    [SellerAddressPostalCode]       NVARCHAR (10)   NOT NULL,
    [SellerAddressDistrict]         NVARCHAR (127)  NOT NULL,
    [SellerAddressCountryCode]      NVARCHAR (10)   NOT NULL,
    [SellerVATNumber]               NVARCHAR (50)   NOT NULL,
    [SellerName]                    NVARCHAR (1000) NOT NULL,
    [SellerAddressAdditionalNumber] NVARCHAR (MAX)  NOT NULL,
    [SellerAddressAdditionalStreet] NVARCHAR (127)  NULL,
    [SellerAddressState]            NVARCHAR (127)  NULL,
    [OtherBuyerID]                  NVARCHAR (MAX)  NULL,
    [OtherBuyerSchemeID]            NVARCHAR (MAX)  NULL,
    [BuyerAddressStreet]            NVARCHAR (1000) NULL,
    [BuyerAddressBuildingNumber]    NVARCHAR (MAX)  NULL,
    [BuyerAddressCity]              NVARCHAR (127)  NULL,
    [BuyerAddressPostalCode]        NVARCHAR (10)   NULL,
    [BuyerAddressDistrict]          NVARCHAR (127)  NULL,
    [BuyerAddressCountryCode]       NVARCHAR (10)   NULL,
    [BuyerVATNumber]                NVARCHAR (50)   NULL,
    [BuyerName]                     NVARCHAR (1000) NULL,
    [LinesNetAmountSummary]         DECIMAL (18, 2) NOT NULL,
    [DocumentLevelAllowanceSummary] DECIMAL (18, 2) NULL,
    [DocumentLevelChargeSummary]    DECIMAL (18, 2) NULL,
    [InvoiceTotalAmountWithoutVAT]  DECIMAL (18, 2) NOT NULL,
    [InvoiceTotalVATAmount]         DECIMAL (18, 2) NOT NULL,
    [InvoiceTotalAmountWithVAT]     DECIMAL (18, 2) NOT NULL,
    [AmountDueForPayment]           DECIMAL (18, 2) NOT NULL,
    [VersionNumber]                 NVARCHAR (50)   NULL,
    CONSTRAINT [PK_dbo.JZ_Invoice] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JZ_Invoice_dbo.JZ_Certificate_CertificateId] FOREIGN KEY ([CertificateId]) REFERENCES [dbo].[JZ_Certificate] ([Id]),
    CONSTRAINT [FK_dbo.JZ_Invoice_dbo.JZ_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JZ_Company] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Invoices_NumberLookup]
    ON [dbo].[JZ_Invoice]([CompanyId] ASC, [SystemId] ASC, [SourceType] ASC, [InvoiceNumberPrefix] ASC, [InvoiceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Invoice_FullNumberValidation]
    ON [dbo].[JZ_Invoice]([CompanyId] ASC, [FullInvoiceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Invoice_SourceLookup]
    ON [dbo].[JZ_Invoice]([CompanyId] ASC, [SystemId] ASC, [SourceType] ASC, [SourceId] ASC, [CreatedDateTime] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SourceId]
    ON [dbo].[JZ_Invoice]([SourceId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SourceType]
    ON [dbo].[JZ_Invoice]([SourceType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SystemId]
    ON [dbo].[JZ_Invoice]([SystemId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Status]
    ON [dbo].[JZ_Invoice]([Status] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_InvoiceType]
    ON [dbo].[JZ_Invoice]([InvoiceType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CreatedDateTime]
    ON [dbo].[JZ_Invoice]([CreatedDateTime] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IssuedDateTime]
    ON [dbo].[JZ_Invoice]([IssuedDateTime] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CertificateId]
    ON [dbo].[JZ_Invoice]([CertificateId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Company_UUID]
    ON [dbo].[JZ_Invoice]([CompanyId] ASC, [UUID] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Company_Counter]
    ON [dbo].[JZ_Invoice]([CompanyId] ASC, [Counter] ASC);

