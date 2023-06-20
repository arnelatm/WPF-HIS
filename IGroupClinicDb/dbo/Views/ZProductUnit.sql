













CREATE VIEW [dbo].[ZProductUnit]
AS
SELECT	[Sequence],productIdNo,unitIdNo,UnitQty,BaseQty
		from ZPhProductUnit
		where UnitQTy <> 1
UNION 
SELECT [Sequence],productIdNo,unitIdNo,UnitQty,BaseQty
		from ZTransferUnit
		where UnitQTy <> 1