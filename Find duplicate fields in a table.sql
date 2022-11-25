SELECT a.*
FROM users a
JOIN (SELECT username, email, COUNT(*)
FROM users 
GROUP BY username, email
HAVING count(*) > 1 ) b
ON a.username = b.username
AND a.email = b.email
ORDER BY a.email



SELECT a.ItemNameEnglish,a.item_code,c.QtyOnHand,d.sCount,e.pCount
FROM ItemDetails a 
JOIN (SELECT ItemNameEnglish,COUNT(*) as myCount FROM ItemDetails 
	  GROUP BY ItemNameEnglish
	  HAVING COUNT(*) > 1 ) as b
ON a.ItemNameEnglish = b.ItemNameEnglish
left join ItemDetailsQty_View c
on a.Primary_Key = c.Primary_Key
left join (select item_Code,BranchId,count(*) as sCount from PharmacyInvoiceDetails 
		   group by item_code,BranchId having count(*) > 1) as d
on a.Item_Code = d.Item_Code and a.BranchID = d.BranchID
left join (select item_Code,BranchId,count(*) as pCount from PurchaseDetails 
		   group by item_code,BranchId having count(*) > 1) as e
on a.Item_Code = e.Item_Code and a.BranchID = e.BranchID
ORDER BY a.ItemNameEnglish,a.item_Code