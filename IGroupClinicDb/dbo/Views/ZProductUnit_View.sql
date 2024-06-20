
















CREATE VIEW [dbo].[ZProductUnit_View]
AS
SELECT	a.[Sequence],b.IdNo as ProductIdNo,a.unitIdNo,a.UnitQty,a.BaseQty
		from dbo.ZPhProductUnit_View a
		left join ISPDATA.dbo.Product b
		on a.primary_key = b.Primary_key
		where a.UnitQTy <> 1
UNION 
SELECT a.[Sequence],b.IdNo,a.unitIdNo,a.UnitQty,a.BaseQty
		from dbo.ZTransferUnit_View a
		left join ISPDATA.dbo.Product b
		on a.primary_key = b.Primary_key
		where a.UnitQTy <> 1