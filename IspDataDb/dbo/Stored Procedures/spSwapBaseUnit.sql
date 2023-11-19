-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spSwapBaseUnit]
	-- Add the parameters for the stored procedure here
	@newUnitIdNo as Int, 
	@oldUnitIdNo as Int,
	@productIdNo as Int,
	@UnitFactor as Int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

    -- Insert statements for procedure here

Update BeginningInventory set Quantity = Quantity * @UnitFactor, UnitCost = UnitCost / @UnitFactor where ProductIdNo = @productIdNo
Update ProductUnit set UnitIdNo = @oldUnitIdNo, UnitQty = BaseQty, BaseQty = UnitQty where UnitIdNo = @newUnitIdNo and ProductIdNo = @productIdNo
Update Product set BaseUnitIdNo = @newUnitIdNo where BaseUnitIdNo = @oldUnitIdNo and IdNo = @productIdNo
Update Inventory set QtyOnHand = QtyOnHand * @UnitFactor, UnitCost = UnitCost / @UnitFactor, UnitSalesPrice = UnitSalesPrice / @UnitFactor where ProductIdNo = @productIdNo

END