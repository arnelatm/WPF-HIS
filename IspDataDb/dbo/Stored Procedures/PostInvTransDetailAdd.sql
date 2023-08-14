

CREATE PROCEDURE [dbo].[PostInvTransDetailAdd] @InvTransactionDetailIdNo Int,@InventoryIdNo Int, @InvTransactionIdNo Int, @WarehouseIdNo Smallint
AS
Declare @Quantity as Decimal(12,4) = 0 
Declare @Cost as Decimal(12,2) = 0
SELECT @Quantity = (select IIf(c.UnitQTy = 0,0,(cast(a.Quantity as Decimal(12,4)) * c.BaseQty / c.UnitQty))
					from InvTransactionDetail a
					Left Join ProductUnit_View c 
				    On a.ProductIdNo = c.ProductIdNo And a.UnitIdNo = c.UnitIdNo where idno = @InvTransactionDetailIdNo) 
SELECT @Cost = (select NetAmount from InvTransactionDetail where idno = @InvTransactionDetailIdNo) 

update inventory set TotalCost = TotalCost + @Cost, qtyonhand = qtyonhand + @Quantity				
where idno = @InventoryIdNo
select @@ROWCOUNT