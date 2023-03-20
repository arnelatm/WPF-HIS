CREATE TABLE [dbo].[ItemDetails] (
    [BranchID]             VARCHAR (15)   NOT NULL,
    [Primary_Key]          INT            IDENTITY (1, 1) NOT NULL,
    [itemid]               VARCHAR (4)    NULL,
    [ean_code]             VARCHAR (15)   NULL,
    [Item_Code]            VARCHAR (15)   NOT NULL,
    [ABC_Class]            VARCHAR (10)   NULL,
    [ItemNameEnglish]      VARCHAR (50)   NOT NULL,
    [ItemNameArabic]       VARCHAR (50)   NULL,
    [ItemGroup]            VARCHAR (5)    NULL,
    [SubstanceGroup]       VARCHAR (5)    NULL,
    [Category]             VARCHAR (5)    NULL,
    [Content1]             VARCHAR (15)   NULL,
    [Content2]             VARCHAR (15)   NULL,
    [Content3]             VARCHAR (15)   NULL,
    [Content4]             VARCHAR (15)   NULL,
    [Content5]             VARCHAR (15)   NULL,
    [Dosage_Adult]         VARCHAR (15)   NULL,
    [Dosage_Pediatric]     VARCHAR (15)   NULL,
    [Dosage_Toddler]       VARCHAR (15)   NULL,
    [Dosage_Infant]        VARCHAR (15)   NULL,
    [Can_used_Pregnancy]   VARCHAR (1)    NULL,
    [Indications]          VARCHAR (300)  NULL,
    [Contra_Indications]   VARCHAR (300)  NULL,
    [Manufacturer]         VARCHAR (15)   NULL,
    [Made_In_Country]      VARCHAR (3)    NULL,
    [Local_Agent]          VARCHAR (15)   NULL,
    [Supplier1]            VARCHAR (15)   NULL,
    [Supplier2]            VARCHAR (15)   NULL,
    [Supplier3]            VARCHAR (15)   NULL,
    [Supplier4]            VARCHAR (15)   NULL,
    [Supplier5]            VARCHAR (15)   NULL,
    [Pack1]                NUMERIC (2)    NULL,
    [Pack2]                NUMERIC (3)    NULL,
    [Pack3]                NUMERIC (4)    NULL,
    [SaleStrip]            CHAR (1)       CONSTRAINT [DF__ItemDetai__SaleS__36470DEF] DEFAULT ('Y') NULL,
    [SalePcs]              CHAR (1)       CONSTRAINT [DF__ItemDetai__SaleP__373B3228] DEFAULT ('N') NULL,
    [Reporting_Dept]       VARCHAR (10)   NULL,
    [Acct_Dept]            VARCHAR (10)   NULL,
    [Price_Cost]           NUMERIC (7, 2) NULL,
    [Disc_Per]             NUMERIC (7, 2) NULL,
    [Price_Cash]           NUMERIC (7, 2) NULL,
    [Discount_Cash]        NUMERIC (7, 2) NULL,
    [Price_Credit]         NUMERIC (7, 2) NULL,
    [Discount_Credit]      NUMERIC (7, 2) NULL,
    [Price_Staff]          NUMERIC (7, 2) NULL,
    [Discount_Staff]       NUMERIC (7, 2) NULL,
    [Credit_Patient_Allow] CHAR (1)       CONSTRAINT [DF__ItemDetai__Credi__382F5661] DEFAULT ('Y') NULL,
    [RO_Qty]               NUMERIC (7)    NULL,
    [Max_Qty]              NUMERIC (7)    NULL,
    [Min_Qty]              NUMERIC (7)    NULL,
    [Qty_Reserved]         NUMERIC (7)    NULL,
    [Bin_Row]              VARCHAR (10)   NULL,
    [Bin_Col]              VARCHAR (10)   NULL,
    [Last_Purchase]        VARCHAR (10)   NULL,
    [Last_Selling]         VARCHAR (10)   NULL,
    [Item_Status]          CHAR (1)       NULL,
    [Item_Blocked]         CHAR (1)       NULL,
    [Blocked_Reason]       VARCHAR (50)   NULL,
    [Blocked_DateUpto]     VARCHAR (10)   NULL,
    [Remarks]              VARCHAR (100)  NULL,
    [Create_date]          DATETIME       CONSTRAINT [DF__ItemDetai__Creat__39237A9A] DEFAULT (getdate()) NULL,
    [UserId]               VARCHAR (15)   NULL,
    [MachineId]            VARCHAR (20)   CONSTRAINT [DF__ItemDetai__Machi__3A179ED3] DEFAULT (host_name()) NULL,
    [Created_By_Branch]    VARCHAR (15)   NOT NULL,
    [VATApplicable]        INT            CONSTRAINT [DF__ItemDetai__VATAp__32CC4E1D] DEFAULT ((0)) NULL,
    [VatPercent]           NUMERIC (5, 2) CONSTRAINT [DF__ItemDetai__VatPe__33C07256] DEFAULT ((0)) NULL,
    [GTIN]                 VARCHAR (14)   NULL,
    [DateTimeStamp]        ROWVERSION     NULL,
    CONSTRAINT [PK__ItemDetails__3552E9B6] PRIMARY KEY CLUSTERED ([Primary_Key] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ItemDetails]
    ON [dbo].[ItemDetails]([ItemNameEnglish] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [GTinBranchid]
    ON [dbo].[ItemDetails]([GTIN] ASC, [BranchID] ASC) WHERE ([GTin] IS NOT NULL);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_ItemDetails]
    ON [dbo].[ItemDetails]([Item_Code] ASC, [BranchID] ASC);

