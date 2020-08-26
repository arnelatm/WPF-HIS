CREATE View ArOpenInvoice_View as
(SELECT      a.IdNo, 
			a.JournalCode, 
			a.JournalItemIdNo, 
			d.Debit - d.Credit AS Amount, 
			co.PaidAmount, 
			co.DiscountTaken, 
			d.Debit - d.Credit - co.PaidAmount - co.DiscountTaken AS 'Balance', 
			a.JournalIdNo, 
			d.AccountIdNo, 
			d.CustomerIdNo, 
            d.ReferenceNo, 
			d.TransactionType, 
			d.TransactionDate, 
			d.InvoiceNo, 
			d.Notes, 
			c.AccountCode, 
			c.AccountName, 
			c.AccountNameAra, 
			c.SpecialAccount, 
			cs.CustomerCode
FROM        dbo.ArOpenInvoice a
			Left Join dbo.ArCollections_View co
			on a.IdNo = co.IdNo
			Left Join dbo.ARDetails_View d
			ON d.IdNo = a.JournalItemIdNo AND a.JournalCode COLLATE SQL_Latin1_General_CP1_CI_AS = d.JournalCode 
			Left Join dbo.Customer cs
			ON d.CustomerIdNo = cs.IdNo
			Left Join dbo.Chart c	
			ON d.AccountIdNo = c.IDNo)

GO









GO


