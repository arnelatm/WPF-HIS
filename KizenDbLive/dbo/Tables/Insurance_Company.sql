CREATE TABLE [dbo].[Insurance_Company] (
    [ID]                           INT            IDENTITY (1, 1) NOT NULL,
    [Code]                         NVARCHAR (100) NULL,
    [ParentCode]                   NVARCHAR (100) NULL,
    [Name]                         NVARCHAR (MAX) NULL,
    [LatinName]                    NVARCHAR (MAX) NULL,
    [Comment]                      NVARCHAR (MAX) NULL,
    [Disabled]                     BIT            NULL,
    [SellCatCodes]                 NVARCHAR (MAX) NULL,
    [ProviderCode]                 NVARCHAR (255) NULL,
    [IsOfferCompany]               BIT            NULL,
    [ExportWorkFileFormat]         NVARCHAR (255) NULL,
    [ExportWorkFolderFormat]       NVARCHAR (255) NULL,
    [VATNumber]                    NVARCHAR (255) NULL,
    [CustomField1]                 NVARCHAR (255) NULL,
    [CustomField2]                 NVARCHAR (255) NULL,
    [CustomField3]                 NVARCHAR (255) NULL,
    [CustomField4]                 NVARCHAR (255) NULL,
    [CustomField5]                 NVARCHAR (255) NULL,
    [IsCustomClaimNo]              BIT            NULL,
    [CustomClaimNoDate]            DATE           NULL,
    [CustomClaimNoBegin]           INT            NULL,
    [PolicyIDForDiscount]          INT            NULL,
    [PolicyIDForTahmel]            INT            NULL,
    [ItemLimitStartDate]           DATE           NULL,
    [ItemLimitEnb]                 BIT            NULL,
    [SeparateMedicineService]      BIT            NULL,
    [NaphisID]                     NVARCHAR (55)  NULL,
    [CommercialRegistrationNumber] NVARCHAR (255) NULL,
    [StreetName]                   NVARCHAR (255) NULL,
    [BuildingNumber]               NVARCHAR (255) NULL,
    [ExtraNumber]                  NVARCHAR (255) NULL,
    [CityName]                     NVARCHAR (255) NULL,
    [PostCode]                     NVARCHAR (255) NULL,
    [RegionName]                   NVARCHAR (255) NULL,
    [NeighborhoodName]             NVARCHAR (255) NULL,
    [CountryCode]                  NVARCHAR (255) NULL,
    [InvoiceAlertMessage]          NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Insurance_Company] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Insurance_Company_Code]
    ON [dbo].[Insurance_Company]([Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Insurance_Company_ParentCode]
    ON [dbo].[Insurance_Company]([ParentCode] ASC);

