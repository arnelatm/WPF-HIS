
CREATE VIEW ClinicDailyCollectionCCRReport_View
 
AS

select
	a.BranchID,
	a.TransDateEnglish,
	a.AcCode,
	a.DepartmentNameEnglish,
	a.SalesCode,
	a.CostOfGoodsCode,
	a.InventoryCode, 
	SUM(a.GrossAmt) as GrossAmt, 
	SUM(a.DiscountAmt+a.DiscountOnDeductible+a.ExtraDiscountAmt) AS DiscountAmt, 
	SUM(a.DeductibleAmt) as DeductibleAmt,
	SUM(a.CostAmt) as CostAmt,
	SUM(a.DiscountOnDeductible) as DiscountOnDeductible,
	SUM(a.ExtraDiscountAmt) as ExtraDiscountAmt,
	SUM(a.RoundOffAmt) as RoundOffAmt,
	b.BankNameEnglish,
	b.LedgerID
from ClinicDailyCollectionCCR_View a
left outer join CreditCardMaster b on b.ItemNameEnglish = a.CreditCardID
group by BranchID,
	 a.TransDateEnglish,
   	 a.AcCode,
	 a.DepartmentNameEnglish,
	 a.SalesCode,
	 a.CostOfGoodsCode,
	 a.InventoryCode,
	 b.BankNameEnglish,
	 b.LedgerID