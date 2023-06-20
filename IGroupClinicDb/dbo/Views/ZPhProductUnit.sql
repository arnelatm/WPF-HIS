







CREATE VIEW [dbo].[ZPhProductUnit]
AS
SELECT	1 as 'Sequence',
		b.Primary_key as 'ProductIdNo',
		iif(Unit = 'B',1,iif(Unit='S',2,3)) as 'UnitIdNo',
		iif(Unit = 'S',B.Pack2,b.Pack2*b.Pack3) as 'UnitQty',
		1 as 'BaseQty'
		FROM [iGroupClinic].[dbo].[Z1PharmacyUnit_View] a
		left join ItemDetails b
		on a.Item_Code = b.Item_Code and a.BranchId = b.BranchId
		where unit <> 'B'