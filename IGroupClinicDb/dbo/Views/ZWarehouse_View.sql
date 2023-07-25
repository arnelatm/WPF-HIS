


CREATE VIEW [dbo].[ZWarehouse_View]
AS
SELECT IIF(BranchID='01',2,1) as 'BranchIdNo',
WareHouseID as 'WarehouseCode',
WarehouseNameEnglish as 'WarehouseName',
WarehouseNameArabic as 'WarehouseNameAra'
FROM dbo.WarehouseDetails