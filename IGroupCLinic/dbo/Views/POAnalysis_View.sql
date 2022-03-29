
CREATE VIEW [dbo].[POAnalysis_View]
  AS 
  (SELECT b.TransNo
      ,b.TransDate
      ,b.TransNo as 'PONo'
      ,a.BranchID
	  ,a.SlNo
      ,a.Item_Code
	  ,c.ItemNameEnglish
      ,c.pack1
      ,c.pack2
      ,c.Pack3
	  ,c.create_date
      ,a.UserQty
      ,a.BonusQty
      ,(Select Max(BonusQty/iif(UserQty=0,100,UserQty)) * 100 from purchasedetails as b where b.item_code = a.Item_code and b.BranchID = a.BranchID) as 'MaxBonus' 
	  ,(Select Avg(BonusQty/iif(UserQty=0,100,UserQty)) * 100 from purchasedetails as b where b.item_code = a.Item_code and b.BranchID = a.BranchID) as 'AvgBonus' 
	  ,(Select Sum(pcsqty/itd.pack2/itd.pack3) from StockPositionCurrent as spd
	     left join itemdetails as itd
		 on spd.item_code = itd.item_Code and spd.BranchID = itd.BranchID 
		 where spd.item_code = a.Item_code and spd.BranchID = a.BranchID and spd.Expiry > CONVERT (varchar,GETDATE(),111)) as 'QtyOnHand'
	  ,(Select sum(iif(Unit='B',pid.Qty,iif(Unit='S',pid.Qty/itd.pack2,pid.qty/itd.pack2/itd.pack3)))
	     from PharmacyInvoiceDetails as PID 
	     left join itemdetails as itd
		 on pid.item_code = itd.item_Code and pid.BranchID = itd.BranchID
		 where pid.item_code = a.Item_Code and pid.branchid = a.BranchID ) as QtySold
	  ,(Select min(TransDateEnglish) from PharmacyInvoiceDetails as PID
	      left join PharmacyInvoiceGroup as PIG 
		  on pid.Group_Key = pig.Trans_Key 
		  left join itemdetails as itd
		     on pid.item_code = a.item_Code and pid.BranchID = a.BranchID 
		  where pid.Item_Code = a.item_code and pid.BranchID = a.branchId) as 'MinDateSale'
	  ,(Select min(PUG.TransDate) from PurchaseDetails as PUD
	      left join PurchaseGroup as PUG
		  on pud.Group_Key = pug.Trans_Key
		  left join itemdetails as itd
		     on pUd.item_code = a.item_Code and pUd.BranchID = a.BranchID 
		  where pUd.Item_Code = a.item_code and pUd.BranchID = a.branchId) as 'MinDatePurc'
	  ,(Select sum(iif(Unit='B',pid.Qty,iif(Unit='S',pid.Qty/itd.pack2,pid.qty/itd.pack2/itd.pack3)))
	     from PharmacyInvoiceDetails as PID 
	     left join itemdetails as itd
		 on pid.item_code = itd.item_Code and pid.BranchID = itd.BranchID 
		 left join PharmacyInvoiceGroup as PIG 
		  on pid.Group_Key = pig.Trans_Key 
		  where  pid.item_code = a.Item_Code and pid.branchid = a.BranchID and (convert(date,PIG.TransDateEnglish)) > DateAdd(day,-30,GetDate()) ) as 'QtySold30d'
	  ,(Select top 1 pud.costprice from PurchaseDetails as PUD
	      left join PurchaseGroup as PUG
		  on pud.Group_Key = pug.Trans_Key
		  left outer join itemdetails as itd
		  on pud.item_code = itd.item_Code and pud.BranchID = itd.BranchID
		  where pud.item_code = a.item_Code and pud.branchid = a.Branchid
		  order by pug.InvoiceDate desc) as 'LatestUCost'
    FROM [iGroupClinic].[dbo].[PurchaseOrderDetails] as a
    left join PurchaseOrderGroup as b
       on a.group_key = b.Trans_Key and a.BranchID = b.BranchID 
    left join itemdetails as c
       on a.Item_Code = c.Item_Code and a.BranchID = c.BranchID)



