
CREATE PROCEDURE [dbo].[spPostPurchaseReturn] 
	@PurchaseIdNo Int,
	@BranchIdNo TinyInt,
	@WarehouseIdNo SmallInt
AS

BEGIN

	--	Declare @NewInvTransactionIdNo as Int
	--	INSERT INTO [InvTransaction] (Amount,BranchIdNo,Cancelled,InvTransTypeIdNo,Notes,Posted,ReferenceNo,TransactionDate,UserIdNo,WarehouseIdNo,WarehouseToIdNo) 
    --	                VALUES (@Amount,@BranchIdNo,@Cancelled,1,@Notes,@Posted,@ReferenceNo,@TransactionDate,@UseridNo,@WarehouseIdNo,@WarehouseToIdNo)
	--	set @NewInvTransactionIdNo = @@identity

	-- DECLARE @InvTransactionDetailInsert Int, @QtyReturnedInBaseUnit Int;

	--Declare PurchaseReturnItems_Cursor CURSOR For (SELECT  IdNo,ProductIdNo,Quantity,BonusQuantity,BatchNo,ExpiryDate,NetAmount FROM PurchaseDetail where PurchaseIdNo = @PurchaseIdNo)
	Declare PurchaseReturnItems_Cursor CURSOR For (SELECT  IdNo,Quantity+BonusQuantity,BatchNo,ExpiryDate,NetAmount,Price,UnitSalesPrice FROM PurchaseDetail where PurchaseIdNo = @PurchaseIdNo)
	Declare @UnitSalesPrice as Decimal(12,4)
	OPEN PurchaseReturnItems_Cursor
	Declare @PurchaseReturnDetailIdNo Int
	Declare @QtyReturnInRetUnit as Decimal(12,4)
	Declare @QtyReturnedInBaseUnit as Decimal(12,4)
	Declare @RunningQty as Decimal(12,4) 
	Declare @ProductIdNo as Int
	Declare @UnitIdNo as Int
	Declare @BatchNo as Varchar(20)
	Declare @ExpiryDate as Date
	Declare @NetAmount as Decimal(12,4)
	Declare @QtyFactor as Decimal(12,4)
	Declare @PrUnitCost as Decimal(12,4)

	FETCH NEXT FROM PurchaseReturnItems_Cursor INTO @PurchaseReturnDetailIdNo, @QtyReturnInRetUnit, @BatchNo, @ExpiryDate, @NetAmount, @PrUnitCost, @UnitSalesPrice
	WHILE @@FETCH_STATUS = 0  
		BEGIN -- PurchaseReturnItems_Cursor loop

			Select @ProductIdNo = ProductIdNo, @UnitIdNo = UnitIdNo from dbo.PurchaseDetail where IdNo = @PurchaseReturnDetailIdNo

			Declare @InventoryIdNo as Int = (Select IdNo from Inventory where ProductIdNo = @ProductIdNo and BatchNo = @BatchNo and ExpiryDate = @ExpiryDate and WarehouseIdNo=@WarehouseIdNo and QtyOnHand > 0)
			Set @QtyFactor = (Select Iif(BaseQTy = 0,0, Cast(BaseQty as Decimal(12,4)) / UnitQty ) from ProductUnit_View where ProductIdNo = @ProductIdNo and UnitIdNo = @UnitIdNo)	
			if @InventoryIdNo Is Not Null 
				Update Inventory set UnitCost = IIf( QtyOnHand+@QtyReturnInRetUnit * @QtyFactor =0,UnitCost,(TotalCost - @NetAmount) / (QtyOnHand - @QtyReturnInRetUnit*@QtyFactor) ),
								QtyOnHand = QtyOnHand - @QtyReturnInRetUnit * @QtyFactor,  TotalCost = TotalCost - @NetAmount 
								where IdNo = @InventoryIdNo
			else
				BEGIN -- @InventoryIdNo Is Null 

					DECLARE inventory_cursor CURSOR FOR  
						(Select IdNo, QtyOnHand, UnitCost from Inventory where ProductIdNo = @ProductIdNo and QtyOnHand > 0 and WarehouseIdNo = @WarehouseIdNo) order by ExpiryDate
					OPEN inventory_cursor;  
  
					-- Perform the first fetch and store the values in variables.  
					-- Note: The variables are in the same order as the columns  
					-- in the SELECT statement.   
 
					Declare @InvQtyOnHand as Decimal(12,4)
					Declare @QtyInBaseUnit as Decimal(12,4)
					Declare @QtyOnHand as Decimal(12,4)
					Declare @PrNetAmount as Decimal(12,4)

					FETCH NEXT FROM inventory_cursor INTO @InventoryIdNo, @QtyOnHand, @PrUnitCost
					-- Check @@FETCH_STATUS to see if there are any more rows to fetch.  
			
					Set @QtyReturnedInBaseUnit = @QtyReturnInRetUnit * @QtyFactor
					Set @RunningQty = @QtyReturnedInBaseUnit
					WHILE @@FETCH_STATUS = 0  
						BEGIN  -- Loop through existing inventory and reduced the quantity
		
							if @QtyOnHand > @RunningQty 
								Begin 
									Set @QtyInBaseUnit = @RunningQty
									Set @PrNetAmount = @NetAmount
								end 
							else
								Begin
									Set @QtyInBaseUnit = @QtyOnHand
									Set @PrNetAmount = @QtyOnHand * @PrUnitCost * @QtyFactor
								end
							-- endif  @QtyOnHand > @RunningQty 
							Update Inventory set UnitCost = IIf(qtyOnHand-@QtyInBaseUnit=0,UnitCost,(TotalCost - @PrNetAmount)/(QtyOnHand-@QtyInBaseUnit)),
									QtyOnHand = QtyOnHand - @QtyInBaseUnit, TotalCost = TotalCost - @PrNetAmount where IdNo = @InventoryIdNo 
							Set @RunningQty = @RunningQty - @QtyInBaseUnit
							if @RunningQty <= 0 Break
			
							-- This is executed as long as the previous fetch succeeds.  
							FETCH NEXT FROM inventory_cursor INTO @InventoryIdNo, @QtyOnHand, @PrUnitCost  
							IF @@FETCH_STATUS = -1 BREAK;
						END 
					--End WHILE
					CLOSE inventory_cursor
					DEALLOCATE inventory_cursor	
					if @RunningQty > 0 
						BEGIN
							-- find productidno with same batch Number, & expiry date & same warehouseIdNo
							SET @InventoryIdNo = (Select TOP 1 IdNo from Inventory where ProductIdNo = @ProductIdNo and BatchNo = @BatchNo and ExpiryDate = @ExpiryDate and WarehouseIdNo = @WarehouseIdNo order by IdNo Desc)
							IF @InventoryIdNo IS NULL SET @InventoryIdNo = (Select TOP 1 IdNo from Inventory where ProductIdNo = @ProductIdNo and WarehouseIdNo = @WarehouseIdNo order by IdNo Desc)
							if @InventoryIdNo Is Not Null Update Inventory set QtyOnHand = QtyOnHand - @RunningQty,UnitCost = IIf(QtyOnHand - @RunningQty=0,UnitCost,(TotalCost - @RunningQty*@PrUnitCost/@QtyFactor) / (QtyOnHand - @RunningQty)),TotalCost = TotalCost - @RunningQty * @PrUnitCost / @QtyFactor where IdNo = @InventoryIdNo 
							else
								-- add an inventory item which will result in a negative value (no choice since no record with the same ProductIdNo & Warehouse
								INSERT INTO Inventory(BranchIdNo,ProductIdNo,TransactionIdNo,QtyOnHand,WarehouseIdNo,TransactionType,BatchNo,ExpiryDate,UnitCost,TotalCost,UnitSalesPrice)
									         Values (@BranchIdNo,@ProductIdNo,@PurchaseIdNo,@RunningQty,@WarehouseIdNo,'R',@BatchNo,@ExpiryDate,@PrUnitCost*@QtyFactor,@PrUnitCost*@QtyFactor*@RunningQty,@UnitSalesPrice)
							-- Endif @InventoryIdNo Is Not Null
						END
					-- endif @RunningQTy > 0
				END -- @InventoryIdNo Is Null 	
			-- endif                                         
			FETCH NEXT FROM PurchaseReturnItems_Cursor INTO @PurchaseReturnDetailIdNo, @QtyReturnInRetUnit, @BatchNo, @ExpiryDate, @NetAmount, @PrUnitCost, @UnitSalesPrice
			IF @@FETCH_STATUS < 0 BREAK;
		-- Endif @InventoryIdNo > 0 
		END -- PurchaseReturnItems_Cursor loop
	-- END WHILE
	CLOSE PurchaseReturnItems_Cursor
	DEALLOCATE PurchaseReturnItems_Cursor	
	Update Purchase Set Posted = 1 where IdNo = @PurchaseIdNo
END