
/****** Object:  UserDefinedTableType [dbo].[InvRequestSuppliedInsertType]    Script Date: 19/09/2023 4:33:38 PM ******/
CREATE PROCEDURE [dbo].[spPostInvTransaction] 
	@InvTransactionIdNo Int,
	@InventoryAction Char(1)
AS

BEGIN
	DECLARE @BranchIdNo TinyInt
	DECLARE @WarehouseIdNo SmallInt
	DECLARE @WarehouseToIdNo SmallInt
	Declare @ProductIdNo as Int
	Declare @UnitIdNo as Int
	Declare @InventoryIdNo as Int
	Declare @Quantity as Decimal(12,4)
	Declare @BatchNo as VarChar(2)
	Declare @UnitCost as Decimal(12,4)
	Declare @NetAmount as Decimal(12,4)
	Declare @ExpiryDate as Date
	Declare @InvTransTypeIdNo as SmallInt
	Select @BranchIdNo = BranchIdNo, @WarehouseIdNo = WarehouseIdNo, @WarehouseToIdNo = WarehouseToIdNo, @InvTransTypeIdNo = InvTransTypeIdNo  from InvTransaction where IdNo = @InvTransactionIdNo


	DECLARE invTransactionDetail_cursor CURSOR FOR  
		(Select IdNo, ProductIdNo, Quantity, UnitIdNo, BatchNo, UnitCost, NetAmount, ExpiryDate, InventoryIdNo from InvTransactionDetail
		 where InvTransactionIdNo = @invTransactionIdNo) order By [Sequence]

	OPEN invTransactionDetail_cursor
	Declare @InvTransactionDetailIdNo Int
	
	FETCH NEXT FROM invTransactionDetail_cursor INTO @InvTransactionDetailIdNo, @ProductIdNo, @Quantity, @UnitIdNo, @BatchNo, @UnitCost, @NetAmount, @ExpiryDate, @InventoryIdNo 
	Declare @Switch as Int = 0
	Declare @SubSwitch as Int = 0
	WHILE @@FETCH_STATUS = 0  
		BEGIN -- invTransactionDetail_cursor loop
			Exec @SubSwitch = spPostInvTransDetail @InvTransactionDetailIdNo,@InvTransactionIdNo,@BranchIdNo,@WarehouseIdNo,@WarehouseToIdNo,@InventoryAction
			if @SubSwitch > 0 Set @Switch = 1
			FETCH NEXT FROM invTransactionDetail_cursor INTO @InvTransactionDetailIdNo, @ProductIdNo, @Quantity, @UnitIdNo, @BatchNo, @UnitCost, @NetAmount, @ExpiryDate, @InventoryIdNo 	
			IF @@FETCH_STATUS < 0 BREAK;
		END		
	CLOSE invTransactionDetail_cursor
	DEALLOCATE invTransactionDetail_cursor	
	If @Switch > 0 
		Begin
			DECLARE @myVar SmallInt
			SET @myVar = 0
			UPDATE InvTransactionDetail SET @myvar = [Sequence] = @myVar + 1 where InvTransactionIdNo = @InvTransactionIdNo
			Update InvTransaction Set Posted = 1, amount = (Select Sum(NetAmount) from InvTransactionDetail where InvTransactionIdNo = @InvTransactionIdNo) where IdNo = @InvTransactionIdNo
		End

END