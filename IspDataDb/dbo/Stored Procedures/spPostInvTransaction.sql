
/****** Object:  UserDefinedTableType [dbo].[InvRequestSuppliedInsertType]    Script Date: 19/09/2023 4:33:38 PM ******/
CREATE PROCEDURE [dbo].[spPostInvTransaction] 
	@InvTransactionIdNo Int
AS

BEGIN
	DECLARE @BranchIdNo TinyInt
	DECLARE @WarehouseIdNo SmallInt
	DECLARE @WarehouseToIdNo SmallInt
	Declare @ProductIdNo as Int
	Declare @UnitIdNo as Int
	Declare @InventoryIdNo as Int
	Declare @Quantity as Decimal(12,4)
	Declare @BatchNo as VarChar(20)
	Declare @UnitCost as Decimal(12,4)
	Declare @NetAmount as Decimal(12,4)
	Declare @ExpiryDate as Date
	Declare @InvTransTypeIdNo as SmallInt
	Declare @InventoryAction as Char(1)
	Select @BranchIdNo = BranchIdNo, @WarehouseIdNo = WarehouseIdNo, @WarehouseToIdNo = WarehouseToIdNo, @InvTransTypeIdNo = InvTransTypeIdNo  from InvTransaction where IdNo = @InvTransactionIdNo
	Set @InventoryAction = (Select InventoryAction from InvTransType where IdNo = @InvTransTypeIdNo)

	DECLARE invTransactionDetail_cursor CURSOR FOR  
		(Select IdNo, InventoryIdNo from InvTransactionDetail
		 where InvTransactionIdNo = @invTransactionIdNo) order By [Sequence]

	OPEN invTransactionDetail_cursor
	Declare @InvTransactionDetailIdNo Int
	
	FETCH NEXT FROM invTransactionDetail_cursor INTO @InvTransactionDetailIdNo, @InventoryIdNo 
	Declare @Switch as Int = 0
	Declare @ReturnSwitch as Int = 0
	Declare @UnitQty as Int 
	Declare @BaseQty as Int 
	Declare @MaxUnitQty as Int
	WHILE @@FETCH_STATUS = 0  
		BEGIN -- invTransactionDetail_cursor loop
			Declare @QtyOnHand as Decimal(12,4)
			Declare @Cost as Decimal(12,4)
			Declare @BaseUnitIdNo as Int 
			Declare @InvQty as Decimal(12,4)
			Select @ProductIdNo = ProductIdNo, @UnitIdNo = UnitIdNo, @UnitCost = UnitCost, @BatchNo = BatchNo, @ExpiryDate = ExpiryDate, @InventoryIdNo = InventoryIdNo from InvTransactionDetail where idno = @InvTransactionDetailIdNo
			Set @BaseUnitIdNo = (Select BaseUnitIdNo from Product where IdNo = @ProductIdNo)
			Select @MaxUnitQty = IsNull(Max(UnitQty),1) FROM ProductUnit where ProductIdNo = @ProductIdNo
			Select @UnitQty = UnitQty, @BaseQty = BaseQty from ProductUnit where ProductIdNo = @ProductIdNo and UnitIdNo = @UnitIdNo
			Set @InvQty = (select Quantity from InvTransactionDetail where idno = @InvTransactionDetailIdNo) 
			Select @UnitQty = UnitQty, @BaseQty = BaseQty from ProductUnit_View where UnitIdNo = @UnitIdNo and ProductIdNo = @ProductIdNo
			Set @Quantity = dbo.UdfConvertToBaseUnit(@InvQty,@UnitQty,@BaseQty,@MaxUnitQty)
			Declare @UnitSalesPrice as Decimal(12,4)
			Declare @TotalCost as Decimal(12,4)
			Declare @ZeroQtySw as Int = 0
			Declare @Qty as Decimal(12,4)
			Declare @QtyFactor as Decimal(12,4)
			Set @QtyFactor = Iif(@UnitQty = 0,0, Cast(@BaseQty as Decimal(12,4)) / @UnitQty )
			If @InventoryAction = 'A'
				BEGIN /* 1 */
					Select Top 1 @InventoryIdNo = IdNo, @UnitCost = UnitCost, @QtyOnHand = QtyOnHand, @TotalCost = TotalCost, @UnitSalesPrice = UnitSalesPrice from inventory 
						where BatchNo = @BatchNo and ExpiryDate = @ExpiryDate AND WarehouseIdNo = @WarehouseIdNo and BranchIdNo = @BranchIdNo 
						Order by QtyOnHand Desc
					if @QtyOnHand Is Not Null 					
						BEGIN /* 2 */
							Set @Cost = IIf(@QtyOnHand=0,0,@TotalCost / @QtyOnHand * @Quantity)
							/* update the Inventory to adjust only the Quantity (don't add to cost since this is extra values and no 
							cost involved */
							update inventory set Qtyonhand = Round(Round((Qtyonhand + @Quantity)*@MaxUnitQty,0)/@MaxUnitQty,4) where idno = @InventoryIdNo 
							/* same here update the Inventory Transaction detail to zero cost to be the same as the inventory adjustment */
							update InvTransactionDetail set unitCost = 0, NetAmount = 0 where idno = @InvTransactionDetailIdNo
						END /* 2 */
					else 
						BEGIN
							/* inventory id not found, so add a new record (with zero amount & cost (no purchase cost involved
							just an adjustment) */
							Insert into Inventory (BranchIdNo, ProductIdNo, TransactionIdNo          , QtyOnHand										  , WarehouseIdNo ,TransactionType , BatchNo, ExpiryDate , UnitCost, TotalCost, UnitSalesPrice)
								            Values(@BranchIdNo,@ProductIdNo,@InvTransactionDetailIdNo, Round(Round(@Quantity*@MaxUnitQty,0)/@MaxUnitQty,4), @WarehouseIdNo, 'I'            , @BatchNo,@ExpiryDate, 0       , 0        , IIf(@UnitSalesPrice Is Null, @UnitCost, @UnitSalesPrice))						
						END
					Set @Switch = 1
					/* @@InventoryIdNo is Not Null */
				END /* 1 */ 
			ELSE IF @InventoryAction = 'T' or @InventoryAction = 'D'
				BEGIN /* 1A */
					Set @Switch = 0
					Declare @currentInventoryIdNo as Int = @InventoryIdNo
					Declare @CurrentInvTransactionDetailIdNo as Int = @InvTransactionDetailIdNo
					Set @currentInventoryIdNo = @InventoryIdNo
					While @Quantity > 0	
						BEGIN /* 2A */		
							/* first use the inventory number requested and see if there are stocks available but make sure it's still the same BranchId and ProductId and WarehouseIdNo */
							Select @QtyOnHand = QtyOnHand, @currentInventoryIdNo = IdNo from Inventory where idno = @currentInventoryIdNo and BranchIdNo = @BranchIdNo and WarehouseIdNo = @WarehouseIdNo and ProductIdNo = @ProductIdNo
							if Not (@QtyOnHand > 0) /* first check */
								Begin
									/* qtyOnHand is less than zero or is a null value (inventory id not found) */
									/* no stocks available, next check for stocks available with same batchno & expirydate */
									Select Top 1 @QtyOnHand = QtyOnHand, @currentInventoryIdNo = IdNo from Inventory where ExpiryDate = @ExpiryDate and BatchNo = @BatchNo and BranchIdNo = @BranchIdNo and WarehouseIdNo = @WarehouseIdNo and ProductIdNo = @ProductIdNo order by QtyOnHand Desc
									if Not (@QtyOnHand > 0) /* second check */
										Begin
											/* still no stock on hand, next find any stock from the same warehouse no matter the expiry and batchno */
											Select Top 1 @QtyOnHand = QtyOnHand, @currentInventoryIdNo = IdNo  from Inventory where BranchIdNo = @BranchIdNo and WarehouseIdNo = @WarehouseIdNo and ProductIdNo = @ProductIdNo and QtyOnHand > 0 order by ExpiryDate Asc
										End
									/* second check */
								End				
							/* first check */
							Set @QtyOnHand = IsNull(@QtyOnHand,0)
							/* Set @QtyOnHand = Round(Round(@QtyOnHand*@MaxUnitQty,0)/@MaxUnitQty,4) */
							if Not (@QtyOnHand > 0) /* last check */
								Begin
									/* still not found, so stop looking no more stocks, zero out the quantity, unitCost and NetAmount */
									if @Switch = 0 update InvTransactionDetail set Quantity = 0, UnitCost = 0, NetAmount = 0 where IdNo = @InvTransactionDetailIdNo
									Set @Switch = 1
									Break 
								End
							/* at this point you will have the inventory item you wish to deduct quantity */
							if Round(@QtyOnHand,4) <= 0 Break
							Set @Qty = IIf(@QtyOnHand > @Quantity, Round(Round(@Quantity*@MaxUnitQty,0)/@MaxUnitQty,4), Round(Round(@QtyOnHand*@MaxUnitQty,0)/@MaxUnitQty,4)) 
							/* dbo.udfRoundDecimalFraction(IIf(@QtyOnHand > @Quantity, @Quantity, @QtyOnHand),@unitQty,@baseQty) */
							Set @QtyOnHand = 0
							Set @ExpiryDate = Null
							Set @BatchNo = Null
							Set @TotalCost = 0
							Set @UnitSalesPrice = 0
							Select @QtyOnHand = QtyOnHand, @ExpiryDate = ExpiryDate, @BatchNo = BatchNo, @TotalCost = TotalCost, @UnitSalesPrice = UnitSalesPrice from inventory where idno = @currentInventoryIdNo 				
							Set @UnitCost = IIf(@QtyOnHand = 0,0,@TotalCost / @QtyOnHand)
							Set @Cost = Iif(@QtyOnHand = 0,0,@TotalCost / @QtyOnHand * @Qty)
							if @Switch = 1 
								BEGIN
									/* the line item already processed previously, but still the quantity is not yet fully applied therefore add first an InvTransactionDetail entry */
									/*Declare @QtyOut as Decimal(12,4) = Iif(@BaseQty = 0,0,@Qty * @UnitQty / @BaseQty) */
									-- Set @UnitCost = IIf(@QtyOut=0,0,@Cost/@QtyOut)
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
										,Iif(@QtyFactor=0,0,@Qty / @QtyFactor)
										,@UnitIdNo
										,@BatchNo
										,@UnitCost * @QtyFactor
										,@Cost
										,@ExpiryDate
										,@CurrentInventoryIdNo)
									Set @CurrentInvTransactionDetailIdNo = (Select scope_identity())
								END 
							else
								/* update the Inventory Transaction detail to reflect the actual cost based on the inventory values */		
								update InvTransactionDetail set BatchNo = @BatchNo, ExpiryDate = @ExpiryDate, UnitCost = @UnitCost*@QtyFactor, NetAmount = @cost, Quantity =  Iif(@QtyFactor=0,0,@Qty/@QtyFactor), InventoryIdNo = @currentInventoryIdNo where idno = @CurrentInvTransactionDetailIdNo
							/* if @Switch = 1 */
							/* update the Inventory by reducing the QtyOnHand & TotalCost  */		
							update inventory set Qtyonhand = Round(Round((QtyOnHand - @Qty)*@MaxUnitQty,0)/@MaxUnitQty,4), TotalCost = TotalCost - @cost where idno = @currentInventoryIdNo 
							Set @Switch = 1
							If @InventoryAction = 'T' 
								BEGIN
									Declare @TrInvIdNo as Int = NULL
									Select Top 1 @TrInvIdNo = IdNo from Inventory where BatchNo = @BatchNo and ExpiryDate = @ExpiryDate and ProductIdNo = @ProductIdNo and WarehouseIdNo = @WarehouseToIdNo order by QtyOnHand Desc
									if @TrInvIdNo Is Not Null  
										Update Inventory set QtyOnHand = Round(Round((QtyOnHand + @Qty)*@MaxUnitQty,0)/@MaxUnitQty,4), TotalCost = TotalCost + @cost where IdNo = @TrInvIdNo  
										/* dbo.udfRoundDecimalFraction(QtyOnHand + @Qty,@unitQty,@baseQty), TotalCost = TotalCost + @cost where IdNo = @TrInvIdNo  */
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
			if @Switch = 1 Set @ReturnSwitch = 1				
			FETCH NEXT FROM invTransactionDetail_cursor INTO @InvTransactionDetailIdNo, @InventoryIdNo 	
			IF @@FETCH_STATUS < 0 BREAK;
			Set @Switch = 0
		END		
	CLOSE invTransactionDetail_cursor
	DEALLOCATE invTransactionDetail_cursor	
	DECLARE @myVar SmallInt
	SET @myVar = 0
	UPDATE InvTransactionDetail SET @myvar = [Sequence] = @myVar + 1 where InvTransactionIdNo = @InvTransactionIdNo
	Update InvTransaction Set Posted = 1, amount = (Select Sum(NetAmount) from InvTransactionDetail where InvTransactionIdNo = @InvTransactionIdNo) where IdNo = @InvTransactionIdNo	
END