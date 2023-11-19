


CREATE View [dbo].[MovementVsInventory_View] as
Select a.QtyOnHand,a.WarehouseIdNo,b.WarehouseToIdNo,a.ProductIdNo,a.ProductCode,
iif(a.WarehouseIdNo=b.WarehouseIdNo,b.QtyMovement,b.QtyMovement*-1) as QtyMovement
from InventoryCount_View a
left join ProductMovementCount_View b
on a.ProductIdNo = b.ProductIdNo and (a.WarehouseIdNo = b.WarehouseIdNo or a.WarehouseIdNo = b.WarehouseToIdNo)