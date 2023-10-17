
CREATE PROCEDURE [dbo].[spPostPurchaseOrder] 
	@MParamType [dbo].PurchaseOrderSuppliedInsertType READONLY,
	@PurchaseOrderidNo Int,
	@ApprovedBy Int
AS

BEGIN

	Declare PurchaseOrderSupply_Cursor CURSOR For (SELECT  PurchaseOrderDetailIdNo, QtySupplied FROM @MParamType)
	OPEN PurchaseOrderSupply_Cursor
	Declare @PurchaseOrderDetailIdNo Int
	Declare @QtySuppliedReqUnit as Decimal(12,4)
	Declare @Switch as Int = 0
	FETCH NEXT FROM PurchaseOrderSupply_Cursor INTO @PurchaseOrderDetailIdNo, @QtySuppliedReqUnit
	WHILE @@FETCH_STATUS = 0  
	BEGIN -- InvRequestSuppliedInsertType loop

		Insert Into PurchaseOrderSupplied (PurchaseOrderDetailIdNo,QtySupplied)
			VALUES (@PurchaseOrderDetailIdNo,@QtySuppliedReqUnit)		
		Set @Switch = 1	
		FETCH NEXT FROM PurchaseOrderSupply_Cursor INTO @PurchaseOrderDetailIdNo, @QtySuppliedReqUnit;
		
		IF @@FETCH_STATUS < 0 BREAK;

	END		
	CLOSE PurchaseOrderSupply_Cursor
	DEALLOCATE PurchaseOrderSupply_Cursor	

	IF @Switch = 1 Update PurchaseOrder Set Posted = 1, ApprovedBy = @ApprovedBy, ApprovedDateTime = GetDate() where IdNo = @PurchaseOrderidNo 

END