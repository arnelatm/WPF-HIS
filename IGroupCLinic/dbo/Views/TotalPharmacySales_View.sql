
CREATE VIEW TotalPharmacySales_View
  AS ( Select c.item_code,c.ItemNameEnglish,c.pack1,c.pack2,c.pack3,
      (SELECT sum( iif(a.SaleType='SALE INVOICE', 
	                   iif(a.unit = 'B',
					       a.qty,
						   iif(a.unit = 'S', 
						       a.qty/d.pack2, 
						       a.qty/d.pack2/d.pack3
							  )
						   ),
					   iif(a.unit = 'B',
					       a.qty*-1,
						   iif(a.unit = 'S', 
						       a.qty/d.pack2*-1, 
						       a.qty/d.pack2/d.pack3*-1
							  )
						   )
						) ) 
       from itemdetails as d 
	   left join PharmacyInvoiceDetails as a on d.item_code = a.item_code
	           where d.item_code = c.Item_code and d.branchid = a.branchid
	   ) as TBQty
from ItemDetails as c WHERE c.BRANCHID= '01'
	 )

