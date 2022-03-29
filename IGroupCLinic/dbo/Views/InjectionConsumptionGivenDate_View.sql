

CREATE View [dbo].[InjectionConsumptionGivenDate_View]
as
select itm.ServiceID,ms.ServiceNameEnglish,
	sum(itm.PcsQty) AS 'PcsQty',	
	(select top 1 purchaselist.Costprice 
		from (SELECT b.TransDate,a.costprice 
			FROM [iGroupClinic].[dbo].[PurchaseDetails] a
			left join PurchaseGroup b
			on a.Group_key = b.Trans_Key 		
			where a.item_code=itm.serviceid and a.branchid='02' and b.TransDate <= '2019/12/31'
			group by a.item_code,b.transdate,costprice) as PurchaseList
			order by TransDate DESC) as 'LatestCostPrice',
	(Select TOP 1 c.CostPrice
	   From StockPosition c
			where c.item_code=itm.serviceid AND c.StockDate <= '2019/12/31' and c.BranchID = '02'
			order by c.StockDate DESC) as 'LastOpenPrice'
from ClinicInvoiceDetails as itm
left join ClinicInvoiceGroup as IG
on itm.group_key = ig.Trans_Key
left join MedicalServices as MS
on itm.serviceid = ms.ServiceID 
left join ItemDetails as ID
on itm.ServiceID = id.Item_Code and id.BranchID = '02'
where ig.TransDateEnglish>='2019/12/01' and ig.TransDateEnglish <= '2019/12/31' and ig.Reject = 0
group by itm.ServiceID,ms.ServiceNameEnglish
