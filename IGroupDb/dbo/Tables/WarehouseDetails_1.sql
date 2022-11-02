CREATE TABLE [dbo].[WarehouseDetails] (
    [Primary_Key]          INT           IDENTITY (1, 1) NOT NULL,
    [BranchID]             VARCHAR (15)  NOT NULL,
    [WareHouseID]          VARCHAR (5)   NOT NULL,
    [AC_Code]              VARCHAR (15)  NOT NULL,
    [WarehouseNameEnglish] VARCHAR (30)  NULL,
    [WarehouseNameArabic]  NVARCHAR (30) NULL,
    [WareHouseType]        CHAR (15)     DEFAULT ('WAREHOUSE') NULL,
    [Remark]               VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Primary_Key] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_WarehouseDetails]
    ON [dbo].[WarehouseDetails]([BranchID] ASC, [WareHouseID] ASC);

