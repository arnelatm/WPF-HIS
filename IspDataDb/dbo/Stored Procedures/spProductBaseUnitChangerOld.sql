-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spProductBaseUnitChangerOld] 
	-- Add the parameters for the stored procedure here
	@productIdNo int = 0,
	@oldUnitIdNo int = 0, 
	@newUnitIdNo int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

    -- Insert statements for procedure here
	Update SaleDetail set UnitIdNo = @newUnitIdNo where UnitIdNo = @oldUnitIdNo and ProductIdNo = @productIdNo
	Update PurchaseOrderDetail set UnitIdNo = @newUnitIdNo where UnitIdNo = @oldUnitIdNo and ProductIdNo = @productIdNo
	Update PurchaseDetail set UnitIdNo = @newUnitIdNo where UnitIdNo = @oldUnitIdNo and ProductIdNo = @productIdNo
	Update ProductUnit set UnitIdNo = @newUnitIdNo where UnitIdNo = @oldUnitIdNo and ProductIdNo = @productIdNo
	Update InvTransactionDetail set UnitIdNo = @newUnitIdNo where UnitIdNo = @oldUnitIdNo and ProductIdNo = @productIdNo
	Update Product set BaseUnitIdNo = @newUnitIdNo where BaseUnitIdNo = @oldUnitIdNo and IdNo = @productIdNo
END