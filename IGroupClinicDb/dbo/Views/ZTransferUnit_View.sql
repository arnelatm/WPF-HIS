












CREATE VIEW [dbo].[ZTransferUnit_View]
AS
SELECT	1 as 'Sequence',
		a.Item_code as 'ProductCode',
		b.Primary_key,
		iif(Unit = 'Box',1,iif(Unit='Strip',2,3)) as 'UnitIdNo',
		iif(Unit = 'Strip',B.Pack2,b.Pack2*b.Pack3) as 'UnitQty',
		1 as 'BaseQty'
		FROM [iGroupClinic].[dbo].[Z1TransferUnit_View] a
		left join ItemDetails b
		on a.Item_Code = b.Item_Code and a.BranchId = b.BranchId