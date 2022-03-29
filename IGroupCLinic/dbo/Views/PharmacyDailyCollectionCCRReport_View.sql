
CREATE VIEW PharmacyDailyCollectionCCRReport_View
 
AS

select
	a.BranchID,
	a.TransDateEnglish,
	a.AcCode,
	a.DepartmentNameEnglish,
	a.SalesCode,
	a.CostOfGoodsCode,
	a.InventoryCode, 
	a.CreditCardID,
	SUM(a.GrossAmt+a.RoundOffAmt) as GrossAmt, 
    SUM(a.DiscountAmt) as DiscountAmt,
	SUM(a.DeductibleAmt)as DeductibleAmt,
	SUM(a.CostAmt) as CostAmt,
	b.ItemNameEnglish as BankNameEnglish,
	b.LedgerID
from PharmacyDailyCollectionCCR_View a
left outer join CreditCardMaster b on a.CreditCardID = b.ItemNameEnglish
group by a.BranchID,
	 a.TransDateEnglish,
     	 a.AcCode,
	 a.departmentnameenglish,
	 a.SalesCode,
	 a.CostOfGoodsCode,
	 a.InventoryCode,
	 a.CreditCardID,
	 b.ItemNameEnglish,
	 b.LedgerID
