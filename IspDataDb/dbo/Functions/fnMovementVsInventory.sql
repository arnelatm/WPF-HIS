


-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[fnMovementVsInventory]
(	
	-- Add the parameters for the function here
	@warehouseIdNo int
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select b.QtyMovement,b.productIdNo,b.ProductCode ,@warehouseIdNo as WarehouseIdNo, a.BranchIdNo,a.QtyOnHand,a.ProductName,a.UnitCost,a.TotalCost from fnProductmovementOnWarehouse(@warehouseIdNo) b
	left Join (Select * from InventoryCount_View) a
	on a.ProductIdNo = b.ProductIdNo and a.WarehouseIdNo = @WarehouseIdNo
	where Round(qtyMovement,4) <> Round(QtyOnHand,4) or QtyOnHand Is Null or qtyMovement is Null
)