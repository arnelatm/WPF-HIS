CREATE TABLE [dbo].[A1_Works] (
    [ID]                           INT             IDENTITY (1, 1) NOT NULL,
    [Code]                         NVARCHAR (255)  NULL,
    [Name]                         NVARCHAR (MAX)  NULL,
    [Group]                        NVARCHAR (MAX)  NULL,
    [GroupCode]                    NVARCHAR (MAX)  NULL,
    [LowerPrice]                   DECIMAL (18, 2) NULL,
    [UpperPrice]                   DECIMAL (18, 2) NULL,
    [OriginalCost]                 DECIMAL (18, 2) NULL,
    [OriginalOriginalCost]         DECIMAL (18, 2) NULL,
    [CustCost]                     DECIMAL (18, 2) NULL,
    [InsureanceDisc]               INT             NULL,
    [Unit]                         NVARCHAR (50)   NULL,
    [LocalBarCode]                 NVARCHAR (255)  NULL,
    [SourceBarCode]                NVARCHAR (255)  NULL,
    [Source_Copmany]               NVARCHAR (MAX)  NULL,
    [IsExpiredDate]                BIT             NULL,
    [DefaultCountBuy]              DECIMAL (18, 2) NULL,
    [DefaultCountVendor]           DECIMAL (18, 2) NULL,
    [DefaultDicount]               DECIMAL (19, 4) NULL,
    [DefaultDicountMoney]          DECIMAL (18, 2) NULL,
    [DefaultDicountMoneyEnb]       BIT             NULL,
    [IsService]                    BIT             NULL,
    [CountInStore]                 DECIMAL (18, 2) NULL,
    [LowerCountStore]              DECIMAL (18, 2) NULL,
    [UpperCountStore]              DECIMAL (18, 2) NULL,
    [Price]                        DECIMAL (18, 2) NULL,
    [SendSmsForLowCount]           BIT             NULL,
    [Disabled]                     BIT             NULL,
    [IsHidePrush]                  BIT             NULL,
    [IsHideSell]                   BIT             NULL,
    [IsHideStore]                  BIT             NULL,
    [Number]                       INT             NULL,
    [IsDisableDiscout]             BIT             NULL,
    [IsDisableDiscoutExpetedUsers] NVARCHAR (MAX)  NULL,
    [IsLocalProductEnb]            BIT             NULL,
    [IsLocalProductWorks]          NVARCHAR (MAX)  NULL,
    [Note]                         NVARCHAR (MAX)  NULL,
    [IsDisableFractures]           BIT             NULL,
    [IsAnalysesEnb]                BIT             NULL,
    [IsAnalysesDataSource]         NVARCHAR (MAX)  NULL,
    [IsAnalysesRefranceValue]      NVARCHAR (MAX)  NULL,
    [IsInsurance]                  BIT             NULL,
    [IsCustomPrice]                BIT             NULL,
    [IsAnalysesCustomProEnb]       BIT             NULL,
    [IsAnalysesCustomProValue]     NVARCHAR (MAX)  NULL,
    [IsAnalysesNote]               NVARCHAR (MAX)  NULL,
    [IsDrug]                       BIT             NULL,
    [DrugForm]                     NVARCHAR (MAX)  NULL,
    [DrugComposition]              NVARCHAR (MAX)  NULL,
    [DrugUsedFor]                  NVARCHAR (MAX)  NULL,
    [DrugManufacturer]             NVARCHAR (MAX)  NULL,
    [DrugDose]                     NVARCHAR (MAX)  NULL,
    [DrugMechanism]                NVARCHAR (MAX)  NULL,
    [DrugSideEffects]              NVARCHAR (MAX)  NULL,
    [DrugWarning]                  NVARCHAR (MAX)  NULL,
    [DrugRadyNote]                 NVARCHAR (MAX)  NULL,
    [DrugOtherInfo]                NVARCHAR (MAX)  NULL,
    [IsXray]                       BIT             NULL,
    [IsAnalysesDefaultValue]       NVARCHAR (MAX)  NULL,
    [IsAnalysesSingleInput]        BIT             NULL,
    [MinCharge]                    DECIMAL (18, 2) NULL,
    [IsDentalLab]                  BIT             NULL,
    [ICD10]                        NVARCHAR (255)  NULL,
    [IsInsuranceNeedApproved]      BIT             NULL,
    [CountInBox]                   INT             NULL,
    [ShowCashEvenInsurance]        BIT             NULL,
    [DrugSeverityDegree]           INT             NULL,
    [DrugIsMedSimilarity]          BIT             NULL,
    [StoreShelfCode]               NVARCHAR (50)   NULL,
    [IsInpatient]                  BIT             NULL,
    [MinChargMoney]                DECIMAL (18, 2) NULL,
    [MinChargeMoneyEnb]            BIT             NULL,
    [DefaultDicountPercBuy]        DECIMAL (18, 2) NULL,
    [DefaultDicountMoneyBuy]       DECIMAL (18, 2) NULL,
    [DefaultDicountMoneyEnbBuy]    BIT             NULL,
    [IsEmergency]                  BIT             NULL,
    [CCHICode]                     NVARCHAR (255)  NULL,
    [CCHIName]                     NVARCHAR (255)  NULL,
    [CCHIType]                     NVARCHAR (255)  NULL,
    [InsurancePreventDuplicateDay] INT             NULL,
    [LonicCode]                    NVARCHAR (50)   NULL,
    [GTIN]                         NVARCHAR (255)  NULL,
    [ScientificCode]               NVARCHAR (255)  NULL,
    [IsEnableSession]              BIT             NULL,
    [SessionsCreateType]           INT             NULL,
    [SessionRepeatDays]            INT             NULL,
    [SessionIsExpired]             BIT             NULL,
    [SessionExpireDays]            INT             NULL,
    [SessionTerms]                 NVARCHAR (MAX)  NULL,
    [SessionNote]                  NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_A1_Works] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Works_Code]
    ON [dbo].[A1_Works]([Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Works_GTIN]
    ON [dbo].[A1_Works]([GTIN] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Works_Number]
    ON [dbo].[A1_Works]([Number] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Works_ScientificCode]
    ON [dbo].[A1_Works]([ScientificCode] ASC);

