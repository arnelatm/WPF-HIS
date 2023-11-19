-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spProductBaseUnitChanger]
	-- Add the parameters for the stored procedure here
	@newUnitIdNo as Int, 
	@oldUnitIdNo as Int,
	@productIdNo as Int
AS
BEGIN
Declare @UnitFactor as Decimal(18,9) 
Declare @unitQty as Int
Declare @baseQty as Int
Select @unitQty = UnitQty, @baseQty = BaseQty from ProductUnit where ProductIdNo = @productIdNo
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

    -- Insert statements for procedure here
Set @UnitFactor = IsNull((Select Cast(UnitQty as Decimal(20,10))/BaseQty from ProductUnit where ProductIdNo = @productIdNo and UnitIdNo = @NewUnitIdNo),1)
--Update BeginningInventory set Quantity = dbo.udfNumToDecimalFraction(Quantity,@unitQty,@baseQty) where ProductIdNo = @productIdNo
--Update BeginningInventory set UnitCost = IIf(Quantity=0,UnitCost/@UnitFactor,Round(TotalCost/Quantity,4)) where ProductIdNo = @productIdNo
Update ProductUnit set UnitIdNo = @oldUnitIdNo, UnitQty = BaseQty, BaseQty = UnitQty where UnitIdNo = @newUnitIdNo and ProductIdNo = @productIdNo
Update Product set BaseUnitIdNo = @newUnitIdNo where BaseUnitIdNo = @oldUnitIdNo and IdNo = @productIdNo
Update Inventory set QtyOnHand = dbo.udfNumToDecimalFraction(QtyOnHand,@unitQty,@baseQty), UnitSalesPrice = UnitSalesPrice / @UnitFactor where ProductIdNo = @productIdNo
Update Inventory set UnitCost = iIf(QtyOnHand=0,UnitCost/@UnitFactor,TotalCost / QtyOnHand) where ProductIdNo = @productIdNo

END