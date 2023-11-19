


-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[fnInventoryCount]
(	
	-- Add the parameters for the function here
	@warehouseIdNo int
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	Select sum(QtyOnHand) as QtyOnHand,ProductIdNo,ProductCode from InventoryCount_View
	where WarehouseIdNo = @warehouseIdNo
	group by ProductIdNo,ProductCode,WarehouseIdNo
)