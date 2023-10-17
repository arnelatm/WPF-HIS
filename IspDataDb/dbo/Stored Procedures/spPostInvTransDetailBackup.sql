

CREATE PROCEDURE [dbo].[spPostInvTransDetailBackup] @InvTransactionDetailIdNo Int, @InvTransactionIdNo Int, @BranchIdNo SmallInt, @WarehouseIdNo Smallint, @WarehouseToIdNo Smallint, @InventoryAction Char(1)
AS
Declare @Quantity as Decimal(12,4) = 0 
Declare @Cost as Decimal(12,2) = 0 
Declare @UnitCost as Decimal(12,4) = 0 
Declare @QtyOnHand as Decimal(12,4)
Declare @BatchNo as VarChar(20)
Declare @ExpiryDate as Date
Declare @ProductIdNo as Int
Declare @UnitIdNo as Int
Declare @InventoryIdNo as Int
Declare @Switch as Int = 0

Select @ProductIdNo = ProductIdNo, @UnitIdNo = UnitIdNo, @UnitCost = UnitCost, @BatchNo = BatchNo, @ExpiryDate = ExpiryDate, @InventoryIdNo = InventoryIdNo from InvTransactionDetail where idno = @InvTransactionDetailIdNo
Set @Quantity = (select IIf(c.UnitQTy = 0,0,(cast(a.Quantity as Decimal(12,4)) * c.BaseQty / c.UnitQty))
				from InvTransactionDetail a
				Left Join ProductUnit_View c 
			    On a.ProductIdNo = c.ProductIdNo And a.UnitIdNo = c.UnitIdNo where idno = @InvTransactionDetailIdNo) 
Declare @UnitQty as Int = (select UnitQty from ProductUnit where ProductIdNo = @ProductIdNo and UnitIdNo = @UnitIdNo)
Declare @BaseQty as Int = (select BaseQty from ProductUnit where ProductIdNo = @ProductIdNo and UnitIdNo = @UnitIdNo)
Declare @UnitSalesPrice as Decimal(12,4)
Declare @InvQty as Decimal(12,4)
Declare @TotalCost as Decimal(12,4)
Declare @ZeroQtySw as Int = 0
Declare @Qty as Decimal(12,4)
If @InventoryAction = 'A'
	BEGIN /* 1 */
		Select Top 1 @InventoryIdNo = IdNo, @UnitCost = UnitCost, @QtyOnHand = QtyOnHand, @TotalCost = TotalCost, @UnitSalesPrice = UnitSalesPrice from inventory where BatchNo = @BatchNo and ExpiryDate = @ExpiryDate Order by QtyOnHand Desc
		if @InventoryIdNo Is Not Null 
			BEGIN /* 2 */
				Set @Cost = @TotalCost / @QtyOnHand * @Quantity
				update inventory set Qtyonhand = Qtyonhand + @Quantity where idno = @InventoryIdNo 
				/* update the Inventory Transaction detail to reflect the actual cost based on the inventory values */
				update InvTransactionDetail set unitCost = 0, NetAmount = 0 where idno = @InvTransactionDetailIdNo
				Set @Switch = 1
			END /* 2 */
		else 
			Insert into Inventory (BranchIdNo, ProductIdNo, TransactionIdNo, QtyOnHand, WarehouseIdNo, TransactionType, BatchNo, ExpiryDate, UnitCost, TotalCost, UnitSalesPrice)
				Values(@BranchIdNo, @ProductIdNo, @InvTransactionDetailIdNo, @Quantity, @WarehouseToIdNo, 'I', @BatchNo, @ExpiryDate, 0, 0, IIf(@UnitSalesPrice Is Null, @UnitCost, @UnitSalesPrice))
		/* @@InventoryIdNo is Not Null */
	END /* 1 */ 
ELSE IF @InventoryAction = 'T' or @InventoryAction = 'D'
	If @Quantity > 0
		BEGIN /* 1 */
			Select @unitCost = UnitCost,@QtyOnHand = QtyOnHand, @ExpiryDate = ExpiryDate, @BatchNo = BatchNo, @TotalCost = TotalCost, @UnitSalesPrice = UnitSalesPrice from inventory where idno = @InventoryIdNo
			Set @Qty = Case When @QtyOnHand >= @Quantity Then @Quantity Else @QtyOnHand End
			if @Qty > 0 
				BEGIN /* 2 */
					Set @Cost = @TotalCost / @QtyOnHand * @Qty
					update inventory set Qtyonhand = Qtyonhand - @Qty, UnitCost = IIf(@Cost=0,0,@UnitCost), TotalCost = TotalCost - @cost where idno = @InventoryIdNo 
					/* update the Inventory Transaction detail to reflect the actual cost based on the inventory values */
					update InvTransactionDetail set unitCost = @UnitCost, NetAmount = @cost, Quantity = @Qty where idno = @InvTransactionDetailIdNo
					Set @Switch = 1
					If @InventoryAction = 'T' 
						BEGIN
							Declare @TrInvIdNo as Int
							Select Top 1 @TrInvIdNo = IdNo from Inventory where BatchNo = @BatchNo and ExpiryDate = @ExpiryDate and ProductIdNo = @ProductIdNo and WarehouseIdNo = @WarehouseToIdNo order by QtyOnHand Desc
							if @TrInvIdNo > 0 
								Update Inventory set QtyOnHand = QtyOnHand + @Qty, TotalCost = TotalCost + @cost where IdNo = @TrInvIdNo 
							else					
								Insert into Inventory (BranchIdNo, ProductIdNo, TransactionIdNo, QtyOnHand, WarehouseIdNo, TransactionType, BatchNo, ExpiryDate, UnitCost, TotalCost, UnitSalesPrice)
								Values(@BranchIdNo, @ProductIdNo, @InvTransactionDetailIdNo, @Qty, @WarehouseToIdNo, 'I', @BatchNo, @ExpiryDate, @UnitCost, @Cost, @UnitSalesPrice)
							/* If @TrInvIdNo > 0 */
						END
					/* if @InventoryAction = 'T' */
				END /* 2 */
			/* if @Qty > 0 */
			Declare @ExcessQty as Decimal(12,4)
			Declare @excessCost as Decimal(12,2)
			Set @ExcessQty = @Quantity - @Qty
			WHILE @excessQty > 0
				BEGIN /* 3 */
					Declare @nextInventoryIdNo as Int 
					/* find the next available inventory with the same productidno & warehouseIdNo beginning with the item with the lowest expired date */
					Set @nextInventoryIdNo = (Select Top 1 IdNo From Inventory where WarehouseIdNo = @WarehouseIdNo and ProductIdNo = @ProductIdNo and QtyOnHand <> 0 order by ExpiryDate Asc )				
					if @nextInventoryIdNo Is Not Null  
						BEGIN /* 4 */
							Select @QtyOnHand = QtyOnHand, @BatchNo = BatchNo, @ExpiryDate = ExpiryDate, @UnitCost = TotalCost / QtyOnHand from inventory where idno = @nextInventoryIdNo
							/* Quantity On Inventory is greater than the quantity to be deducted */
							Set @Qty = Case When @QtyOnHand > @excessQty Then @excessQty Else @QtyOnHand End
							Set @cost = @unitcost * @Qty
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
								(0
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
							/* recursively call this procedure */
							EXEC @Switch = spPostInvTransDetail @InvTransactionDetailIdNo,@nextInventoryIdNo,@BranchIdNo,@WarehouseIdNo,@WarehouseToIdNo,@InventoryAction
						END /* 4 */
					Else  
						Set @ExcessQty = 0
					/* end if @nextInventoryIdNo > 0 */
				END /* 3 */
			/* WHILE @ExcessQty > 0 */
		END /* 1 */
	/* If @Quantity <> 0 */
/* If @InventoryAction = 'A' */
Select @Switch