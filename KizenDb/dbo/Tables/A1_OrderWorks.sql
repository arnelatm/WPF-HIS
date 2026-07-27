CREATE TABLE [dbo].[A1_OrderWorks] (
    [ID]                             INT             IDENTITY (1, 1) NOT NULL,
    [OrderID]                        INT             NULL,
    [Category]                       NVARCHAR (255)  NULL,
    [Name]                           NVARCHAR (MAX)  NULL,
    [Price]                          FLOAT (53)      NULL,
    [Count]                          FLOAT (53)      NULL,
    [Total]                          FLOAT (53)      NULL,
    [Disc]                           DECIMAL (19, 4) NULL,
    [DiscType]                       NVARCHAR (50)   NULL,
    [DiscNet]                        DECIMAL (18, 2) NULL,
    [Net]                            DECIMAL (18, 2) NULL,
    [Note]                           NVARCHAR (MAX)  NULL,
    [UserName]                       NVARCHAR (255)  NULL,
    [Date]                           DATE            NULL,
    [Time]                           TIME (0)        NULL,
    [Unit]                           NVARCHAR (50)   NULL,
    [WorkID]                         NVARCHAR (255)  NULL,
    [QuotationWorkID]                INT             NULL,
    [MaxPrice]                       FLOAT (53)      NULL,
    [MinPrice]                       FLOAT (53)      NULL,
    [IsService]                      BIT             NULL,
    [PrushID]                        INT             NULL,
    [Cost]                           FLOAT (53)      NULL,
    [TotalCost]                      FLOAT (53)      NULL,
    [SourceBarCode]                  NVARCHAR (255)  NULL,
    [InsuranceTahamal]               DECIMAL (18, 2) NULL,
    [PatientTahamalPer]              DECIMAL (18, 2) NULL,
    [IsInsurance]                    BIT             NULL,
    [InuranceCode]                   NVARCHAR (255)  NULL,
    [InuranceName]                   NVARCHAR (255)  NULL,
    [InsuranceTahamalStatic]         DECIMAL (18, 2) NULL,
    [InsuranceTahamalChangedCause]   NVARCHAR (MAX)  NULL,
    [InternalNotes]                  NVARCHAR (MAX)  NULL,
    [VATPer]                         DECIMAL (18, 2) NULL,
    [VatValue]                       DECIMAL (18, 2) NULL,
    [TotalNoVAT]                     DECIMAL (18, 2) NULL,
    [VatExemption]                   DECIMAL (18, 2) NULL,
    [InsuranceTahamalVATPer]         DECIMAL (18, 2) NULL,
    [InsuranceTahamalVATValue]       DECIMAL (18, 2) NULL,
    [InsuranceTahamalAfterVAT]       DECIMAL (18, 2) NULL,
    [ICD10]                          NVARCHAR (555)  NULL,
    [DrugDose]                       NVARCHAR (MAX)  NULL,
    [DrugInfo]                       NVARCHAR (MAX)  NULL,
    [DrugScientificName]             NVARCHAR (MAX)  NULL,
    [Type]                           INT             NULL,
    [OfferID]                        INT             NULL,
    [InsuranceApprovalType]          NVARCHAR (4)    NULL,
    [InsuranceApprovalID]            INT             NULL,
    [ExpiredDate]                    DATE            NULL,
    [MedDose]                        NVARCHAR (255)  NULL,
    [MedDuration]                    NVARCHAR (255)  NULL,
    [MedUnit]                        NVARCHAR (50)   NULL,
    [MedFrequency]                   NVARCHAR (50)   NULL,
    [Teeth]                          NVARCHAR (255)  NULL,
    [GTIN]                           NVARCHAR (255)  NULL,
    [SN]                             NVARCHAR (255)  NULL,
    [BN]                             NVARCHAR (255)  NULL,
    [Rsd_NotificationID]             NVARCHAR (255)  NULL,
    [Rsd_RC]                         NVARCHAR (255)  NULL,
    [ItemLimitID]                    INT             NULL,
    [ItemLimitAmount]                DECIMAL (18, 2) NULL,
    [CCHICode]                       NVARCHAR (255)  NULL,
    [CCHIName]                       NVARCHAR (255)  NULL,
    [InvoiceSourceID]                INT             NULL,
    [PurchaseAVG]                    DECIMAL (19, 4) NULL,
    [GeneralDiscount]                DECIMAL (19, 4) NULL,
    [CouponDiscount]                 DECIMAL (19, 4) NULL,
    [PointsDiscount]                 DECIMAL (19, 4) NULL,
    [TotalDiscount]                  DECIMAL (19, 4) NULL,
    [ParentId]                       INT             NULL,
    [StoreExpensePause]              BIT             NULL,
    [StoreExpenseUserID]             INT             NULL,
    [StoreExpenseUserName]           NVARCHAR (255)  NULL,
    [StoreExpenseDateTime]           DATETIME        NULL,
    [InsuranceApprovedAmountWithVat] DECIMAL (18, 2) NULL,
    [ToothSurface]                   NVARCHAR (255)  NULL,
    [ScientificCode]                 NVARCHAR (255)  NULL,
    [IsSessionWork]                  BIT             NULL,
    [DrugSelectionReason]            NVARCHAR (255)  NULL,
    [Priority]                       INT             NULL,
    [Morphology]                     NVARCHAR (50)   NULL,
    [IsMaternity]                    BIT             NULL,
    [LastMenstrualPeriod]            DATETIME        NULL,
    [WorkType]                       INT             NULL,
    [IsVatExempted]                  BIT             NULL,
    [QuotationWorkDetailID]          INT             NULL,
    [HideFromInsurance]              BIT             NULL,
    CONSTRAINT [PK_A1_OrderWorks] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_A1_OrderWorks_InsuranceApproval]
    ON [dbo].[A1_OrderWorks]([InsuranceApprovalID] ASC, [InsuranceApprovalType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_OrderWorks_InsuranceApprovalID]
    ON [dbo].[A1_OrderWorks]([InsuranceApprovalID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_OrderWorks_InsuranceApprovalType]
    ON [dbo].[A1_OrderWorks]([InsuranceApprovalType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_OrderWorks_OrderID]
    ON [dbo].[A1_OrderWorks]([OrderID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_OrderWorks_VATPer]
    ON [dbo].[A1_OrderWorks]([VATPer] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_OrderWorks_WorkID]
    ON [dbo].[A1_OrderWorks]([WorkID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_OrderWorks_QuotationWorkID]
    ON [dbo].[A1_OrderWorks]([QuotationWorkID] ASC);

