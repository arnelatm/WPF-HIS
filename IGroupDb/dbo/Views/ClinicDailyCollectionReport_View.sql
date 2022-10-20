
CREATE VIEW ClinicDailyCollectionReport_View
 
AS

select
	BranchID,
	TransDateEnglish,
	AcCode,
	DepartmentNameEnglish,
	SalesCode,
	CostOfGoodsCode,
	InventoryCode, 
	SUM(GrossAmt) as GrossAmt, 
	SUM(DiscountAmt+DiscountOnDeductible+ExtraDiscountAmt) AS DiscountAmt, 
	SUM(DeductibleAmt) as DeductibleAmt,
	SUM(CostAmt) as CostAmt,
	SUM(DiscountOnDeductible) as DiscountOnDeductible,
	SUM(ExtraDiscountAmt) as ExtraDiscountAmt,
	SUM(RoundOffAmt) as RoundOffAmt
from ClinicDailyCollectionCalculation_View
group by BranchID,
	 TransDateEnglish,
   	 AcCode,
	 DepartmentNameEnglish,
	 SalesCode,
	 CostOfGoodsCode,
	 InventoryCode