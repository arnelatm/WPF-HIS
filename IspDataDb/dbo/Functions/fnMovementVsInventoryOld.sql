


-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[fnMovementVsInventoryOld]
(	
	-- Add the parameters for the function here
	@warehouseIdNo int
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	Select a.*,b.QtyMovement from inventoryCount_View a
	left join (select * from fnProductmovementOnWarehouse(@warehouseIdNo)) b
	on a.ProductIdNo = b.ProductIdNo and a.WarehouseIdNo = @WarehouseIdNo
	where IsNull(QtyOnhand,0) <> IsNull(Round(QtyMovement,4),0) and a.WarehouseIdNo = @WarehouseIdNo
)