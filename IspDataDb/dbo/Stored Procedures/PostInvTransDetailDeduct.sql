

CREATE PROCEDURE [dbo].[PostInvTransDetailDeduct] @InvTransactionDetailIdNo Int,@InventoryIdNo Int, @InvTransactionIdNo Int, @WarehouseIdNo Smallint
AS
Declare @Quantity as Decimal(12,4) = 0 
SELECT @Quantity = (select IIf(c.UnitQTy = 0,0,(cast(a.Quantity as Decimal(12,4)) * c.BaseQty / c.UnitQty))
					from InvTransactionDetail a
					Left Join ProductUnit_View c 
				    On a.ProductIdNo = c.ProductIdNo And a.UnitIdNo = c.UnitIdNo where idno = @InvTransactionDetailIdNo) 
update inventory set qtyonhand = qtyonhand - @Quantity,
					TotalCost = TotalCost - IIf(QtyOnHand=0,0,(@Quantity * TotalCost / QtyOnHand))
where idno = @InventoryIdNo
select @@ROWCOUNT