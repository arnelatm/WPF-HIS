CREATE TABLE [dbo].[Warehouse] (
    [IdNo]             SMALLINT      IDENTITY (1, 1) NOT NULL,
    [BranchIdNo]       TINYINT       NULL,
    [WarehouseCode]    VARCHAR (10)  NOT NULL,
    [WarehouseName]    VARCHAR (50)  NOT NULL,
    [WarehouseNameAra] NVARCHAR (50) NULL,
    [DateTimeStamp]    ROWVERSION    NULL,
    CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);




GO



GO


