

/****** Script for SelectTopNRows command from SSMS  ******/
CREATE View [dbo].[ProductMovementCount_View] as
SELECT sum(a.baseqty) as QtyMovement, a.WarehouseIdNo,a.WarehouseToIdNo,a.ProductIdNo,p.ProductCode FROM [ProductMovement_View] a
left join product p
on a.ProductIdNo = p.IdNo
group by a.productidno, a.warehouseidno,p.ProductCode,a.WarehouseToIdNo