



CREATE VIEW [dbo].[ArJournalItem_View]
AS
SELECT  a.IdNo, 
		o.JournalCode, 
		a.JournalIdNo, 
		a.AccountIdNo, 
		a.Debit, 
		a.Credit, 
		a.RevCostCenterIdNo, 
		a.Notes, 
		a.Posted, 
		a.DateTimeStamp, 
		c.AccountName, 
		o.IdNo AS OpenInvoiceIdNo, 
		a.Credit - a.Debit AS OriginalAmount, 
		col.PaidAmount, 
		col.DiscountTaken, 
		c.SpecialAccount, 
		c.AccountNameAra, 
		c.PayeeType, 
		a.Sequence
FROM    dbo.ArJournalItem a
		LEFT OUTER JOIN dbo.Chart c
		ON a.AccountIdNo = c.IDNo 
		LEFT OUTER JOIN dbo.ArOpenInvoice o
		ON a.IdNo = o.JournalItemIdNo AND o.JournalCode = 'AR'
		LEFT OUTER JOIN dbo.ArCollections_View col
		on o.IdNo = col.IdNo
