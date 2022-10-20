
CREATE VIEW PharmacyDailyCollectionReport_View
 
AS

select
	BranchID,
	TransDateEnglish,
	AcCode,
	DepartmentNameEnglish,
	SalesCode,
	CostOfGoodsCode,
	InventoryCode, 
	SUM(GrossAmt+RoundOffAmt) as GrossAmt, 
    SUM(DiscountAmt) as DiscountAmt,
	SUM(DeductibleAmt)as DeductibleAmt,
	SUM(CostAmt) as CostAmt
from PharmacyDailyCollectionCalculation_View
group by BranchID,
	 TransDateEnglish,
     AcCode,
	 departmentnameenglish,
	 SalesCode,
	 CostOfGoodsCode,
	 InventoryCode