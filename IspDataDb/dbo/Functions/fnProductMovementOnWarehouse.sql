


-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[fnProductMovementOnWarehouse]
(	
	-- Add the parameters for the function here
	@warehouseIdNo int
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT sum(qtyMovement) as QtyMovement,productIdNo,ProductCode from fnProductMovementWarehouse(@warehouseIdNo)
	group by productIdNo,productCode
)