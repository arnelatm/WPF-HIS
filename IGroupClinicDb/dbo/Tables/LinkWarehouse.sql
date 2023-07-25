CREATE TABLE [dbo].[LinkWarehouse] (
    [IdNo]                 SMALLINT     IDENTITY (1, 1) NOT NULL,
    [BranchId]             VARCHAR (15) NULL,
    [BranchIdNo]           SMALLINT     NULL,
    [WarehouseId]          VARCHAR (5)  NULL,
    [WareHouseIdNo]        SMALLINT     NULL,
    [WarehouseNameEnglish] VARCHAR (30) NULL,
    CONSTRAINT [PK_LinkWarehouse] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

