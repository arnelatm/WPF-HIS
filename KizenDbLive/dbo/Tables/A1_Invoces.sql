CREATE TABLE [dbo].[A1_Invoces] (
    [ID]                               INT             IDENTITY (1, 1) NOT NULL,
    [Date]                             DATETIME        NULL,
    [CustID]                           INT             NULL,
    [CustName]                         NVARCHAR (255)  NULL,
    [Type]                             NVARCHAR (255)  NULL,
    [Total]                            INT             NULL,
    [Mdfo3]                            INT             NULL,
    [Bake]                             INT             NULL,
    [Comment]                          NVARCHAR (MAX)  NULL,
    [Time]                             TIME (0)        NULL,
    [UserName]                         NVARCHAR (255)  NULL,
    [UserID]                           INT             NULL,
    [GeneralCust]                      BIT             NULL,
    [Store]                            INT             NULL,
    [Box]                              NVARCHAR (255)  NULL,
    [DrName]                           NVARCHAR (255)  NULL,
    [DrID]                             INT             NULL,
    [SourceType]                       NVARCHAR (50)   NULL,
    [SourceID]                         INT             NULL,
    [MailPayDate]                      DATETIME        NULL,
    [MailPayData]                      NVARCHAR (MAX)  NULL,
    [MailPayNote]                      NVARCHAR (MAX)  NULL,
    [AssignedTo]                       INT             NULL,
    [OrderID]                          INT             NULL,
    [IsSchedule]                       BIT             NULL,
    [scheduleValue]                    INT             NULL,
    [MeritDate]                        DATE            NULL,
    [IsInsurance]                      BIT             NULL,
    [InsuranceCompany]                 NVARCHAR (100)  NULL,
    [InsurancePolicy]                  NVARCHAR (100)  NULL,
    [InsuranceClass]                   NVARCHAR (55)   NULL,
    [InsuranceMemberNo]                NVARCHAR (55)   NULL,
    [InsuranceApprovalNo]              NVARCHAR (255)  NULL,
    [InsuranceLimitCustDay]            DECIMAL (18, 2) NULL,
    [InsuranceUpToPer]                 DECIMAL (18, 2) NULL,
    [InsuranceUpToMoney]               DECIMAL (18, 2) NULL,
    [InsuranceSeparateMedicineService] BIT             NULL,
    [CustIdentity]                     NVARCHAR (255)  NULL,
    [CustNat]                          NVARCHAR (255)  NULL,
    [Clinic]                           NVARCHAR (255)  NULL,
    [Glass]                            NVARCHAR (MAX)  NULL,
    [SpecialtieID]                     INT             NULL,
    [LimitCustVisit]                   DECIMAL (18, 2) NULL,
    [IsFavorite]                       BIT             NULL,
    [FavoriteNote]                     NVARCHAR (255)  NULL,
    [IsESignature]                     BIT             NULL,
    [EligrefNo]                        NVARCHAR (255)  NULL,
    [IsReturn]                         BIT             CONSTRAINT [DF_A1_Invoces_IsReturn] DEFAULT ((0)) NOT NULL,
    [ParentId]                         INT             NULL,
    [InvoiceSourceID]                  INT             NULL,
    [PaymentMethodId]                  INT             NULL,
    [CouponCode]                       NVARCHAR (255)  NULL,
    [GeneralDiscount]                  DECIMAL (19, 4) NULL,
    [CouponDiscount]                   DECIMAL (19, 4) NULL,
    [PointsDiscount]                   DECIMAL (19, 4) NULL,
    [ENumber]                          NVARCHAR (127)  NULL,
    [EId]                              INT             NULL,
    [RequestedLabUserName]             NVARCHAR (255)  NULL,
    [RequestedLabDateTime]             DATETIME        NULL,
    [RequestedERUserName]              NVARCHAR (255)  NULL,
    [RequestedERDateTime]              DATETIME        NULL,
    [RequestedXRayUserName]            NVARCHAR (255)  NULL,
    [RequestedXRayDateTime]            DATETIME        NULL,
    CONSTRAINT [PK_A1_Invoces] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Invoces_CustID]
    ON [dbo].[A1_Invoces]([CustID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Invoces_Date]
    ON [dbo].[A1_Invoces]([Date] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Invoces_Date_Desc]
    ON [dbo].[A1_Invoces]([Date] DESC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Invoces_DrID]
    ON [dbo].[A1_Invoces]([DrID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Invoces_InsuranceClass]
    ON [dbo].[A1_Invoces]([InsuranceClass] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Invoces_InsuranceCompany]
    ON [dbo].[A1_Invoces]([InsuranceCompany] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Invoces_InsurancePolicy]
    ON [dbo].[A1_Invoces]([InsurancePolicy] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Invoces_IsInsurance]
    ON [dbo].[A1_Invoces]([IsInsurance] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Invoces_Store]
    ON [dbo].[A1_Invoces]([Store] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Invoces_Clinic]
    ON [dbo].[A1_Invoces]([Clinic] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Invoces_EligrefNo]
    ON [dbo].[A1_Invoces]([EligrefNo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Invoces_InsuranceApprovalNo]
    ON [dbo].[A1_Invoces]([InsuranceApprovalNo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Invoces_ParentId]
    ON [dbo].[A1_Invoces]([ParentId] ASC);

