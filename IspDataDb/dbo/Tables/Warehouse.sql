CREATE TABLE [dbo].[Warehouse] (
    [IdNo]             SMALLINT      IDENTITY (1, 1) NOT NULL,
    [WarehouseCode]    NVARCHAR (10) NOT NULL,
    [WarehouseName]    VARCHAR (20)  NOT NULL,
    [WarehouseNameAra] NVARCHAR (20) NOT NULL,
    [DateTimeStamp]    ROWVERSION    NULL,
    CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Warehouse_Name]
    ON [dbo].[Warehouse]([WarehouseName] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Warehouse_Code]
    ON [dbo].[Warehouse]([WarehouseCode] ASC);

