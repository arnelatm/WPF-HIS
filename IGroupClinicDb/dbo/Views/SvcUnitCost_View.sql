





CREATE View [dbo].[SvcUnitCost_View]
as
select ms.ServiceID,ms.ServiceNameEnglish,ms.BranchID,
	(select IIf(Sum(QtyInPcs)=0,0,Sum(Amount)/Sum(QtyInPcs))
		from (SELECT a.QtyInPcs,a.Amount
			 FROM PurchaseDetails_View a
			 where a.Item_code = ia.Item_Code) as PurchaseList) as 'AvgCost'
FROM MedicalServices as ms
left join ItemAssignment ia
on ms.ServiceID = ia.ServiceId
WHERE ms.branchid='02'