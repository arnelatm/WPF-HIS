
-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[fnProductMovementWarehouse]
(	
	-- Add the parameters for the function here
	@warehouseIdNo int
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT sum(iif(a.warehouseIdNo=@warehouseIdNo,a.baseQty,a.baseqty*-1)) as QtyMovement, a.ProductIdNo,p.ProductCode FROM [ProductMovement_View] a
	left join product p
	on a.ProductIdNo = p.IdNo 
	where a.WarehouseIdNo = @WarehouseIdNo or a.WarehouseToIdNo = @WarehouseIdNo
	group by a.productidno, a.warehouseidno,p.ProductCode,a.WarehouseToIdNo
)