CREATE TABLE [dbo].[AccountsDailyCollectionDetails] (
    [BranchID]        VARCHAR (15)    NOT NULL,
    [Group_Key]       NUMERIC (10)    NOT NULL,
    [TransSeries]     VARCHAR (10)    NOT NULL,
    [SlNo]            NUMERIC (10)    NULL,
    [AcCode]          VARCHAR (15)    NULL,
    [AcNameEnglish]   VARCHAR (50)    NULL,
    [SalesCode]       VARCHAR (15)    NULL,
    [CostOfGoodsCode] VARCHAR (15)    NULL,
    [InventoryCode]   VARCHAR (15)    NULL,
    [CostCentreID]    VARCHAR (15)    NULL,
    [GrossAmt]        NUMERIC (10, 2) NULL,
    [CostAmt]         NUMERIC (10, 2) NULL,
    [DiscountAmt]     NUMERIC (10, 2) NULL,
    [DeductibleAmt]   NUMERIC (10, 2) NULL,
    [NetAmt]          NUMERIC (10, 2) NULL,
    [Apply]           INT             DEFAULT (0) NULL,
    [VATPercent]      NUMERIC (5, 2)  DEFAULT ((0)) NULL,
    [VATAmt]          NUMERIC (10, 2) DEFAULT ((0)) NULL
);

