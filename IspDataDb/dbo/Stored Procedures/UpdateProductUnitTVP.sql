











CREATE PROCEDURE  [dbo].[UpdateProductUnitTVP]
  @MParam ProductUnitUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].ProductUnit A WHERE A.ProductIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing ProductUnits
UPDATE a 
SET a.BaseQty = B.BaseQty,
	a.ProductIdNo = @GroupIdNo,
    a.UnitIdNo = B.UnitIdNo,
	a.UnitQty = B.UnitQty
from ProductUnit a JOIN @MParam b
on a.IdNo = b.IdNo

END