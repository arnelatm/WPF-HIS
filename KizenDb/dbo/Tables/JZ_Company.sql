CREATE TABLE [dbo].[JZ_Company] (
    [Id]                                INT             IDENTITY (1, 1) NOT NULL,
    [OrganizationIdentifier]            NVARCHAR (15)   NOT NULL,
    [CommercialRegistrationNumber]      NVARCHAR (50)   NOT NULL,
    [TaxIdentificationNumber]           NVARCHAR (MAX)  NULL,
    [OrganizationName]                  NVARCHAR (100)  NOT NULL,
    [CountryName]                       NVARCHAR (2)    NOT NULL,
    [InvoiceType]                       NVARCHAR (4)    NOT NULL,
    [Location]                          NVARCHAR (MAX)  NOT NULL,
    [Industry]                          NVARCHAR (MAX)  NOT NULL,
    [Disabled]                          BIT             NOT NULL,
    [AddressStreet]                     NVARCHAR (1000) NOT NULL,
    [AddressBuildingNumber]             NVARCHAR (4)    NOT NULL,
    [AddressCity]                       NVARCHAR (127)  NOT NULL,
    [AddressDistrict]                   NVARCHAR (127)  NOT NULL,
    [AddressAdditionalNumber]           NVARCHAR (MAX)  NOT NULL,
    [AddressAdditionalStreet]           NVARCHAR (127)  NULL,
    [AddressState]                      NVARCHAR (127)  NULL,
    [AddressPostalCode]                 NVARCHAR (5)    NOT NULL,
    [ActiveCertificateId]               INT             NULL,
    [UseProduction]                     BIT             DEFAULT ((0)) NOT NULL,
    [DemoType]                          INT             DEFAULT ((0)) NOT NULL,
    [Title]                             NVARCHAR (100)  NOT NULL,
    [IsFirstStage]                      BIT             DEFAULT ((0)) NOT NULL,
    [SignSimplifiedInvoicesAutomaticly] BIT             DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.JZ_Company] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JZ_Company_dbo.JZ_Certificate_ActiveCertificateId] FOREIGN KEY ([ActiveCertificateId]) REFERENCES [dbo].[JZ_Certificate] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ActiveCertificateId]
    ON [dbo].[JZ_Company]([ActiveCertificateId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Title]
    ON [dbo].[JZ_Company]([Title] ASC);

