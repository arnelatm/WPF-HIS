
/****** Object:  UserDefinedTableType [dbo].[InvRequestSuppliedInsertType]    Script Date: 19/09/2023 4:33:38 PM ******/
CREATE PROCEDURE [dbo].[spPostInvRequest] 
	@MParamType [dbo].InvRequestSuppliedInsertType READONLY,
	@InvTransactionIdNo Int,
	@Amount Decimal(12,4),
	@BranchIdNo TinyInt,
	@Cancelled Bit,
	@InvTransTypeIdNo TinyInt,
	@Notes NVarChar(100),
	@Posted Bit,
	@ReferenceNo Varchar(10),
	@TransactionDate Date,
	@UseridNo SmallInt,
	@WarehouseIdNo SmallInt,
	@WarehouseToIdNo SmallInt	
AS

BEGIN

	Declare @NewInvTransactionIdNo as Int
	INSERT INTO [InvTransaction] (Amount,BranchIdNo,Cancelled,InvTransTypeIdNo,Notes,Posted,ReferenceNo,TransactionDate,UserIdNo,WarehouseIdNo,WarehouseToIdNo) 
                    VALUES (@Amount,@BranchIdNo,@Cancelled,1,@Notes,@Posted,@ReferenceNo,@TransactionDate,@UseridNo,@WarehouseIdNo,@WarehouseToIdNo)
	set @NewInvTransactionIdNo = @@identity

	-- DECLARE @InvTransactionDetailInsert Int, @QtySupplied Int;

	Declare InvRequestSupply_Cursor CURSOR For (SELECT  InvTransactionDetailIdNo, QtySupplied FROM @MParamType)

	OPEN InvRequestSupply_Cursor
	Declare @InvTransactionDetailIdNo Int
	Declare @QtySuppliedReqUnit as Decimal(12,4)
	Declare @QtySupplied as Decimal(12,4)
	Declare @RunningQty as Decimal(12,4) 
	Declare @ProductIdNo as Int
	Declare @UnitIdNo as Int
	FETCH NEXT FROM InvRequestSupply_Cursor INTO @InvTransactionDetailIdNo, @QtySuppliedReqUnit
	WHILE @@FETCH_STATUS = 0  
	BEGIN -- InvRequestSuppliedInsertType loop

		Select @ProductIdNo = ProductIdNo, @UnitIdNo = UnitIdNo from dbo.InvTransactionDetail where IdNo = @InvTransactionDetailIdNo

		DECLARE inventory_cursor CURSOR FOR  
			(Select IdNo, QtyOnHand, BatchNo, ExpiryDate, UnitCost from Inventory where ProductIdNo = @ProductIdNo and QtyOnHand > 0 and WarehouseIdNo = @WarehouseIdNo) order by ExpiryDate
		OPEN inventory_cursor;  
  
		-- Perform the first fetch and store the values in variables.  
		-- Note: The variables are in the same order as the columns  
		-- in the SELECT statement.   
  
  		Declare @InventoryIdNo as Int
		Declare @QtyOnHand as Decimal(12,4)
		Declare @BatchNo as VarChar(20)
		Declare @ExpiryDate as Date
		Declare @Sequence as Int = 1
		Declare @UnitCost as Decimal(12,4)
		Declare @Qty as Decimal(12,4)
		Declare @NetAmount as Decimal(12,4)
		Declare @QtyFactor as Decimal(12,4)
		FETCH NEXT FROM inventory_cursor INTO @InventoryIdNo, @QtyOnHand, @BatchNo, @ExpiryDate, @UnitCost
		-- Check @@FETCH_STATUS to see if there are any more rows to fetch.  
		Set @QtyFactor = (Select Iif(BaseQTy = 0,0, Cast(BaseQty as Decimal(12,4)) / UnitQty ) from ProductUnit_View where ProductIdNo = @ProductIdNo and UnitIdNo = @UnitIdNo)	
		Set @QtySupplied = @QtySuppliedReqUnit * @QtyFactor
		Set @RunningQty = @QtySupplied
		WHILE @@FETCH_STATUS = 0  
			BEGIN  -- Loop through existing inventory and reduced the quantity
		
				if @QtyOnHand > @RunningQty 
					Set @Qty = @RunningQty
				else
					Set @Qty = @QtyOnHand

				Set @NetAmount = @Qty * @UnitCost
				-- add a new InvTransactionDetail
				Insert Into InvTransactionDetail (Sequence,InvTransactionIdNo,ProductIdNo,Quantity,UnitIdNo,BatchNo,UnitCost,NetAmount,ExpiryDate,InventoryIdNo)
					VALUES (@Sequence,@NewInvTransactionIdNo,@ProductIdNo,iIf(@qtyFactor=0,0,@Qty/@QtyFactor),@UnitIdNo,@BatchNo,iIf(@qtyFactor=0,0,@UnitCost * @QtyFactor),@NetAmount,@ExpiryDate,@InventoryIdNo)
				-- update the Inventory qty on hand and cost
				Update Inventory set QtyOnHand = QtyOnHand - @Qty, TotalCost = TotalCost - @Qty * @UnitCost where IdNo = @InventoryIdNo 
				Declare @InvIdNo as Int
				Set @InvIdNo = (Select Top 1 IdNo from Inventory where BatchNo = @BatchNo and ExpiryDate = @ExpiryDate and ProductIdNo = @ProductIdNo and WarehouseIdNo = @WarehouseToIdNo)
				if @InvIdNo > 0 
					Update Inventory set QtyOnHand = QtyOnHand + @Qty, TotalCost = TotalCost + @Qty * @UnitCost where IdNo = @InvIdNo 
				else					
					Insert into Inventory (BranchIdNo, ProductIdNo, TransactionIdNo, QtyOnHand,WarehouseIdNo, TransactionType, BatchNo, ExpiryDate, UnitCost, TotalCost, UnitSalesPrice)
						Values(@BranchIdNo, @ProductIdNo, @NewInvTransactionIdNo, @Qty, @WarehouseToIdNo, 'I', @BatchNo, @ExpiryDate, @UnitCost, @UnitCost * @Qty, @UnitCost)

				Set @RunningQty = @RunningQty - @Qty
				if @RunningQty <= 0 Break
			
				
				-- This is executed as long as the previous fetch succeeds.  
				FETCH NEXT FROM inventory_cursor INTO @InventoryIdNo, @QtyOnHand, @BatchNo, @ExpiryDate, @UnitCost  
				IF @@FETCH_STATUS = -1 BREAK;

			END  
		
		CLOSE inventory_cursor
		DEALLOCATE inventory_cursor	
		if @RunningQty > 0 
			Begin
				Insert Into InvTransactionDetail (Sequence,InvTransactionIdNo,ProductIdNo,Quantity,UnitIdNo,BatchNo,UnitCost,NetAmount,ExpiryDate,InventoryIdNo)
					VALUES (@Sequence,@NewInvTransactionIdNo,@ProductIdNo,@RunningQty,@UnitIdNo,@BatchNo,@UnitCost,@NetAmount,@ExpiryDate,@inventoryIdNo)
				Update Inventory set QtyOnHand = QtyOnHand - @RunningQty, UnitCost = UnitCost - @Qty * @UnitCost where IdNo = @InvTransactionDetailIdNo 
			end
		
		-- Declare @qtySuppliedInRequestUnit as Decimal(12,4) 
		-- Set @qtySuppliedInRequestUnit = @QtySupplied * @Qty
		IF NOT EXISTS (Select * from InvRequestSupplied where InvTransactionDetailIdNo = @InvTransactionDetailIdNo)
			INSERT INTO InvRequestSupplied (InvTransactionDetailIdNo, QtySupplied) Values (@InvTransactionDetailIdNo, @QtySuppliedReqUnit)
		else
			Update InvRequestSupplied Set QtySupplied = QtySupplied + @QtySuppliedReqUnit where InvTransactionDetailIdNo = @InvTransactionDetailIdNo

	
		FETCH NEXT FROM InvRequestSupply_Cursor INTO @InvTransactionDetailIdNo, @QtySuppliedReqUnit;
		
		IF @@FETCH_STATUS < 0 BREAK;

	END		
	CLOSE InvRequestSupply_Cursor
	DEALLOCATE InvRequestSupply_Cursor	

	IF NOT EXISTS (select * from InvRequestDetail_view where invTransactionIdNo = @InvTransactionIdNo and (Quantity - QtySupplied)  > 0)
		Update InvTransaction Set Posted = 1 where IdNo = @InvTransactionIdNo

END