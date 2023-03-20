CREATE TABLE [dbo].[WarehouseDetails] (
    [Primary_Key]          INT           IDENTITY (1, 1) NOT NULL,
    [BranchID]             VARCHAR (15)  NOT NULL,
    [WareHouseID]          VARCHAR (5)   NOT NULL,
    [AC_Code]              VARCHAR (15)  NOT NULL,
    [WarehouseNameEnglish] VARCHAR (30)  NULL,
    [WarehouseNameArabic]  NVARCHAR (30) NULL,
    [WareHouseType]        CHAR (15)     CONSTRAINT [DF__Warehouse__WareH__14E61A24] DEFAULT ('WAREHOUSE') NULL,
    [Remark]               VARCHAR (100) NULL,
    [WarehouseIDOriginal]  VARCHAR (5)   NULL,
    CONSTRAINT [PK__WarehouseDetails__13F1F5EB] PRIMARY KEY CLUSTERED ([Primary_Key] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_WarehouseDetails]
    ON [dbo].[WarehouseDetails]([BranchID] ASC, [WareHouseID] ASC);

