

CREATE PROCEDURE [dbo].[PostInvTransDetail] @InvTransactionDetailIdNo Int,@ProductIdNo Int, @UnitIdNo SmallInt, @InventoryIdNo Int, @InvTransactionIdNo Int, @WarehouseIdNo Smallint, @WarehouseToIdNo Smallint, @Sequence as Int Output
AS
Declare @Quantity as Decimal(12,4) = 0 
Declare @Cost as Decimal(12,2) = 0 
Declare @UnitCost as Decimal(12,4) = 0 
Declare @QtyOnHand as Decimal(12,4)
Declare @BatchNo as VarChar(20)
Declare @ExpiryDate as Date
Declare @BranchIdNo as Smallint

Set @Quantity = (select IIf(c.UnitQTy = 0,0,(cast(a.Quantity as Decimal(12,4)) * c.BaseQty / c.UnitQty))
					from InvTransactionDetail a
					Left Join ProductUnit_View c 
				    On a.ProductIdNo = c.ProductIdNo And a.UnitIdNo = c.UnitIdNo where idno = @InvTransactionDetailIdNo) 
Select @QtyOnHand = QtyOnHand, @unitCost = UnitCost,@BranchIdNo = BranchIdNo, @ExpiryDate = ExpiryDate, @BatchNo = BatchNo from inventory where idno = @InventoryIdNo
Declare @UnitQty as Int = (select UnitQty from ProductUnit where ProductIdNo = @ProductIdNo and UnitIdNo = @UnitIdNo)
Declare @BaseQty as Int = (select BaseQty from ProductUnit where ProductIdNo = @ProductIdNo and UnitIdNo = @UnitIdNo)
Declare @UnitSalesPrice as Decimal(12,4)
Declare @InvQty as Decimal(12,4)
Declare @TotalCost as Decimal(12,4)
Declare @ZeroQtySw as Int = 0
If @Quantity <> 0 
	BEGIN /* 1 */
		Declare @Qty as Decimal(12,4)
		Select @unitCost = UnitCost,@InvQty = QtyOnHand, @BranchIdNo = BranchIdNo, @ExpiryDate = ExpiryDate, @BatchNo = BatchNo, @TotalCost = TotalCost, @UnitSalesPrice = UnitSalesPrice from inventory where idno = @InventoryIdNo
		/* Quantity On Inventory is greater than the quantity to be deducted */
		if @QtyOnHand >= @Quantity Set @Qty = @Quantity else Set @Qty = @InvQty
		/* if @QtyOnHand >= @Quantity 
		update inventory by reducing the quantity on hand and the total cost */
		if @Qty <> 0 
			BEGIN /* 2 */
				Set @Sequence = @Sequence + 1
				Set @Cost = @TotalCost / @QtyOnHand * @Qty
				update inventory set Qtyonhand = Qtyonhand - @Qty, TotalCost = TotalCost - @cost where idno = @InventoryIdNo 
				/* update the Inventory Transaction detail to reflect the actual cost based on the inventory values */
				update InvTransactionDetail set [Sequence] = @Sequence, unitCost = @UnitCost, NetAmount = @cost, Quantity = @Qty where idno = @InvTransactionDetailIdNo

				Declare @InvIdNo as Int
				Select Top 1 @InvIdNo = IdNo from Inventory where BatchNo = @BatchNo and ExpiryDate = @ExpiryDate and ProductIdNo = @ProductIdNo and WarehouseIdNo = @WarehouseToIdNo order by QtyOnHand Desc
				if @InvIdNo > 0 
					Update Inventory set QtyOnHand = QtyOnHand + @Qty, TotalCost = TotalCost + @cost where IdNo = @InvIdNo 
				else					
					Insert into Inventory (BranchIdNo, ProductIdNo, TransactionIdNo, QtyOnHand, WarehouseIdNo, TransactionType, BatchNo, ExpiryDate, UnitCost, TotalCost, UnitSalesPrice)
						Values(@BranchIdNo, @ProductIdNo, @InvTransactionDetailIdNo, @Qty, @WarehouseToIdNo, 'I', @BatchNo, @ExpiryDate, @UnitCost, @Cost, @UnitSalesPrice)
			END /* 2 */
		else
			Set @ZeroQtySw = 1
		/* if @Qty <> 0 */
		Declare @ExcessQty as Decimal(12,4)
		Declare @excessCost as Decimal(12,2)
		Set @ExcessQty = @Quantity - @Qty

		WHILE ( @excessQty <> 0)		
			BEGIN /* 3 */
				Declare @nextInventoryIdNo as Int 
				/* find the next available inventory with the same productidno & warehouseIdNo beginning with the item with the lowest expired date */
				Set @nextInventoryIdNo = (Select Top 1 IdNo From Inventory where WarehouseIdNo = @WarehouseIdNo and ProductIdNo = @ProductIdNo and QtyOnHand <> 0 and BranchIdNo = @BranchIdNo order by ExpiryDate Asc )				
				if @nextInventoryIdNo > 0 
					BEGIN /* 4 */
						/* Declare @iUnitCost as Decimal(12,4)
						Declare @iQtyOnHand as Decimal(12,4) */
						Set @QtyOnHand = (Select qtyOnHand from inventory where idno = @nextInventoryIdNo) 
						Set @UnitCost = (Select TotalCost / QtyOnHand from inventory where idno = @nextInventoryIdNo)
						/* Quantity On Inventory is greater than the quantity to be deducted */
						if @QtyOnHand > @excessQty set @Qty = @excessQty else set @Qty = @QtyOnHand
						Set @cost = @unitcost * @Qty
						if @ZeroQtySw = 0 
							BEGIN /* 5 */
								INSERT INTO [dbo].[InvTransactionDetail]
								([Sequence]
								,[InvTransactionIdNo]
								,[ProductIdNo]
								,[Quantity]
								,[UnitIdNo]
								,[BatchNo]
								,[UnitCost]
								,[NetAmount]
								,[ExpiryDate]
								,[InventoryIdNo])
								VALUES
								(@sequence
								,@invTransactionIdNo
								,@productIdNo
								,@Qty 
								,@UnitIdNo
								,@BatchNo
								,@unitCost 
								,@cost
								,@expiryDate
								,@nextInventoryIdNo);
								Set @ExcessQty = @ExcessQty - @Qty
								Set @InvTransactionDetailIdNo = (Select scope_identity())
							END /* 5 */
						else
							Begin /* 6 */
								Set @sequence = @sequence + 1
								/* inventory Qty for selected item is zero, so cannot reduce anymore, so get the nextInventory values with non zero quantity values */
								Select @BatchNo = BatchNo, @ExpiryDate = ExpiryDate, @UnitCost = TotalCost / QtyOnHand From Inventory where IdNo = @nextInventoryIdNo
								/* update invTransactionDetail values with the values acquired above */
								update InvTransactionDetail set [Sequence] = @Sequence, BatchNo = @BatchNo, ExpiryDate = @ExpiryDate, UnitCost = @UnitCost, NetAmount = @UnitCost * @ExcessQty, InventoryIdNo = @nextInventoryIdNo where idno = @InvTransactionDetailIdNo 
								/* call this program recursively with the corrected values */
								Set @ExcessQty = 0 /* force quit loop */
							End   /* 6 */
						/* if @QtySw = 0 */												
						/* recursively call this procedure */
						/* Exec PostInvTransDetail @InvTransactionDetailIdNo,@productIdNo,@UnitIdNo,@nextInventoryIdNo,@InvTransactionIdNo,@WarehouseIdNo,@WarehouseToIdNo */
						EXEC @Sequence = PostInvTransDetail @InvTransactionDetailIdNo,@productIdNo,@UnitIdNo,@nextInventoryIdNo,@InvTransactionIdNo,@WarehouseIdNo,@WarehouseToIdNo,@Sequence
					END /* 4 */
				Else  
					Set @ExcessQty = 0
					/* 
					reduce the quantity to the actual qtyon hand 
					update InvTransactionDetail set NetAmount = NetAmount - @ExcessQty * @UnitCost, Quantity = Quantity - @ExcessQty where idno = @InvTransactionDetailIdNo 
					BEGIN /* 7 */
						/* code here to run if no more stock for the said productIdNo by finding the lastest inventory with the said batch & expiryDate */
						Declare @InvFind as Int 
						Select Top 1 @InvFind = IdNo From Inventory where WarehouseIdNo = @WarehouseIdNo and ProductIdNo = @ProductIdNo and BranchIdNo = @BranchIdNo and BatchNo = @BatchNo and ExpiryDate = @ExpiryDate order by IdNo Desc			
						if @InvFind > 0 
							update Inventory set QtyOnHand = @ExcessQty * -1, TotalCost = @UnitCost * @ExcessQty * -1 where idno = @InvFind
						else
							Begin /* 8 */
								Set @InvFind = (Select Top 1 IdNo From Inventory where WarehouseIdNo = @WarehouseIdNo and ProductIdNo = @ProductIdNo and BranchIdNo = @BranchIdNo order by IdNo Desc)
								update Inventory set QtyOnHand = @ExcessQty * -1, TotalCost = @UnitCost * @ExcessQty * -1 where idno = @InvFind
								/* update InvTransactionDetail set NetAmount = NetAmount + @UnitCost * @ExcessQty * -1 where idno = @InvTransactionDetailIdNo  */
							End /* 8 */
						Set @ExcessQty = 0 /* force quit loop */
						Declare @DummyLine as Int  
					END 7 
					*/
				/* end if @nextInventoryIdNo > 0 */
			END /* 3 */
		/* END WHILE */
	END /* 1 */
/* @Quantity <> 0 
	insert into Inventory(BranchIdNo,ProductIdNo,TransactionIdNo,QtyOnHand,WarehouseIdNo,TransactionType,BatchNo,ExpiryDate,UnitCost,TotalCost,UnitSalesPrice)
	Select BranchIdNo,ProductIdNo,@InvTransactionIdNo,@Quantity,@WarehouseIdNo,'I',BatchNo,ExpiryDate,UnitCost, @Cost as TotalCost,UnitSalesPrice 
	   from Inventory where IdNo = @InventoryIdNo
*/
RETURN (@Sequence)