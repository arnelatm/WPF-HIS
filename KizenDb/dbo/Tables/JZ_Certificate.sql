CREATE TABLE [dbo].[JZ_Certificate] (
    [Id]                            INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]                     INT            NOT NULL,
    [CommonName]                    NVARCHAR (250) NOT NULL,
    [SerialNumber]                  NVARCHAR (250) NOT NULL,
    [OrganizationIdentifier]        NVARCHAR (15)  NOT NULL,
    [CommercialRegistrationNumber]  NVARCHAR (50)  NOT NULL,
    [TaxIdentificationNumber]       NVARCHAR (MAX) NULL,
    [OrganizationName]              NVARCHAR (100) NOT NULL,
    [CountryName]                   NVARCHAR (2)   NOT NULL,
    [InvoiceType]                   NVARCHAR (4)   NOT NULL,
    [Location]                      NVARCHAR (MAX) NOT NULL,
    [Industry]                      NVARCHAR (MAX) NOT NULL,
    [PrivateKey]                    NVARCHAR (MAX) NULL,
    [PublicKey]                     NVARCHAR (MAX) NULL,
    [CSRText]                       NVARCHAR (MAX) NULL,
    [CSR]                           NVARCHAR (MAX) NULL,
    [ComplianceRequestId]           BIGINT         NOT NULL,
    [ComplianceDispositionMessage]  NVARCHAR (MAX) NULL,
    [ComplianceBinarySecurityToken] NVARCHAR (MAX) NULL,
    [ComplianceSecret]              NVARCHAR (MAX) NULL,
    [ProdRequestId]                 BIGINT         NOT NULL,
    [ProdDispositionMessage]        NVARCHAR (MAX) NULL,
    [ProdBinarySecurityToken]       NVARCHAR (MAX) NULL,
    [ProdSecret]                    NVARCHAR (MAX) NULL,
    [ComplianceInvoiceResponse]     NVARCHAR (MAX) NULL,
    [Disabled]                      BIT            NOT NULL,
    CONSTRAINT [PK_dbo.JZ_Certificate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JZ_Certificate_dbo.JZ_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JZ_Company] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JZ_Certificate]([CompanyId] ASC);

