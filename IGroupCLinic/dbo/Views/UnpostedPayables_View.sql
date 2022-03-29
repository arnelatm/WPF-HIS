
CREATE view	UnpostedPayables_View
 
as
select 
	a.BranchID,
	a.TransType,
	a.TransSeries,
	a.TransNo,
	a.InvoiceDate as VDate,
	year(a.TransDate) as FinYear,
	a.WareHouseID,
	Case when a.TransSeries = 'CA' then 'Cash' else 'Credit' end as CashCredit,
	a.SupplierID,
	b.Ac_Code as LedgerID,
	b.SupplierNameEnglish, 
	a.InvoiceNo, 
	a.InvoiceDate, 
	a.PurchaseGrossAmt, 
	a.invoiceAmt, 
	a.Trans_Key 
From 	PurchaseGroup a,
	SupplierDetails b 
WHERE 	a.SupplierID = b.SupplierID 
	AND (a.PostInAccounts = 'N' OR a.PostInAccounts = '' OR a.PostInAccounts IS NULL) 
--	AND a.TransSeries = 'CR'
