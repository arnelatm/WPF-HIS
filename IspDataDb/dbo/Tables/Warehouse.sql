CREATE TABLE [dbo].[Warehouse] (
    [IdNo]             SMALLINT      IDENTITY (1, 1) NOT NULL,
    [BranchIdNo]       TINYINT       NULL,
    [WarehouseCode]    VARCHAR(10) NOT NULL,
    [WarehouseName]    VARCHAR (50)  NOT NULL,
    [WarehouseNameAra] NVARCHAR (50) NULL,
    [DateTimeStamp]    TIMESTAMP    NULL,
    CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Warehouse_Name]
    ON [dbo].[Warehouse]([WarehouseName] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Warehouse_Code]
    ON [dbo].[Warehouse]([WarehouseCode] ASC);

