

CREATE PROCEDURE [dbo].[spPostInvTransDetail] @InvTransactionDetailIdNo Int, @InvTransactionIdNo Int, @BranchIdNo SmallInt, @WarehouseIdNo Smallint, @WarehouseToIdNo Smallint, @InventoryAction Char(1)
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
	BEGIN /* 1A */
		Declare @currentInventoryIdNo as Int = @InventoryIdNo
		Declare @CurrentInvTransactionDetailIdNo as Int = @InvTransactionDetailIdNo
		Set @currentInventoryIdNo = @InventoryIdNo
		While @Quantity > 0	
			BEGIN /* 2A */		
				/* first use the inventory number requested and see if there are stocks available but make sure it's still the same BranchId and ProductId and WarehouseIdNo */
				Select @QtyOnHand = QtyOnHand, @currentInventoryIdNo = IdNo from Inventory where idno = @currentInventoryIdNo and BranchIdNo = @BranchIdNo and WarehouseIdNo = @WarehouseIdNo and ProductIdNo = @ProductIdNo
				if Not (@QtyOnHand > 0) /* first check */
					Begin
						/* no stocks available, next check for stocks available with same batchno & expirydate */
						Select Top 1 @QtyOnHand = QtyOnHand, @currentInventoryIdNo = IdNo from Inventory where ExpiryDate = @ExpiryDate and BatchNo = @BatchNo and BranchIdNo = @BranchIdNo and WarehouseIdNo = @WarehouseIdNo and ProductIdNo = @ProductIdNo order by QtyOnHand Desc
						if Not (@QtyOnHand > 0) /* second check */
							Begin
								/* still no stock on hand, next find any stock from the same warehouse no matter the expiry and batchno */
								Select Top 1 @QtyOnHand = QtyOnHand, @currentInventoryIdNo = IdNo  from Inventory where BranchIdNo = @BranchIdNo and WarehouseIdNo = @WarehouseIdNo and ProductIdNo = @ProductIdNo and QtyOnHand > 0 order by ExpiryDate Desc
							End
						/* second check */
					End				
				/* first check */
				if Not (@QtyOnHand > 0) /* last check */
					Begin
						/* still not found, so stop looking no more stocks, zero out the quantity, unitCost and NetAmount */
						if @Switch = 0 update InvTransactionDetail set Quantity = 0, UnitCost = 0, NetAmount = 0 where IdNo = @InvTransactionDetailIdNo
						Set @Switch = 1
						Break 
					End
				/* last check */
				if Round(@QtyOnHand,4) <= 0 Break
				Set @Qty = IIf(@QtyOnHand > @Quantity, @Quantity, @QtyOnHand)
				Select @unitCost = UnitCost,@QtyOnHand = QtyOnHand, @ExpiryDate = ExpiryDate, @BatchNo = BatchNo, @TotalCost = TotalCost, @UnitSalesPrice = UnitSalesPrice from inventory where idno = @currentInventoryIdNo 				
				Set @UnitCost = @TotalCost / @QtyOnHand
				Set @Cost = @UnitCost * @Qty
				if @Switch = 1 
					BEGIN
						/* the line item already processed previously, but still the quantity is not yet fully applied therefore add first an InvTransactionDetail entry */
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
							,@InvTransactionIdNo
							,@ProductIdNo
							,@Qty 
							,@UnitIdNo
							,@BatchNo
							,@UnitCost 
							,@Cost
							,@ExpiryDate
							,@CurrentInventoryIdNo)
						Set @CurrentInvTransactionDetailIdNo = (Select scope_identity())
					END 
				else
					/* update the Inventory Transaction detail to reflect the actual cost based on the inventory values */		
					update InvTransactionDetail set BatchNo = @BatchNo, ExpiryDate = @ExpiryDate, UnitCost = @UnitCost, NetAmount = @cost, Quantity = @Qty, InventoryIdNo = @currentInventoryIdNo where idno = @CurrentInvTransactionDetailIdNo
				/* if @Switch = 1 */
				/* update the Inventory by reducing the QtyOnHand & TotalCost  */		
				update inventory set Qtyonhand = Qtyonhand - @Qty, TotalCost = TotalCost - @cost where idno = @currentInventoryIdNo 
				Set @Switch = 1
				If @InventoryAction = 'T' 
					BEGIN
						Declare @TrInvIdNo as Int
						Select Top 1 @TrInvIdNo = IdNo from Inventory where BatchNo = @BatchNo and ExpiryDate = @ExpiryDate and ProductIdNo = @ProductIdNo and WarehouseIdNo = @WarehouseToIdNo order by QtyOnHand Desc
						if @TrInvIdNo Is Not Null  
							Update Inventory set QtyOnHand = QtyOnHand + @Qty, TotalCost = TotalCost + @cost where IdNo = @TrInvIdNo 
						else					
							Insert into Inventory (BranchIdNo, ProductIdNo, TransactionIdNo, QtyOnHand, WarehouseIdNo, TransactionType, BatchNo, ExpiryDate, UnitCost, TotalCost, UnitSalesPrice)
								Values(@BranchIdNo, @ProductIdNo, @CurrentInvTransactionDetailIdNo, @Qty, @WarehouseToIdNo, 'I', @BatchNo, @ExpiryDate, @UnitCost, @Cost, @UnitSalesPrice)
						/* If @TrInvIdNo > 0 */
					END
				/* if @InventoryAction = 'T' */
				Set @Quantity = @Quantity - @Qty
			END /* 2A */
		/* While @Quantity > 0 */
	END /* 1A */
/* If @InventoryAction = 'A' */
Return @Switch