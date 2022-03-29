
CREATE VIEW ClinicDailyCollectionCCR_View
 
AS

select
	a.BranchID,
	a.TransType,
	a.TransNBR,
	a.TransDateEnglish,
	e.AcCode,
	e.DepartmentNameEnglish,
	e.SalesCode,
	e.CostOfGoodsCode,
	e.InventoryCode, 
	a.CreditCardID,
	CONVERT(numeric(10,2),SUM(b.Qty*b.SalePrice)) as GrossAmt, 
	CONVERT(numeric(10,2),SUM(case when b.discountamt = 0 then b.Qty*b.SalePrice* b.DiscountPer/100 else b.DiscountAmt end)) as DiscountAmt,
	CONVERT(numeric(10,2),a.DeductibleAmt) as DeductibleAmt,
	CONVERT(numeric(10,2),SUM(b.Qty*b.CostPrice)) as CostAmt,
        CONVERT(numeric(10,2),a.DeductibleDiscountAmt) as DiscountOnDeductible,
	CONVERT(numeric(10,2),a.ExtraDiscountAmt) AS ExtraDiscountAmt,
	CONVERT(numeric(10,2),a.RoundOffAmt) as RoundOffAmt
from ClinicInvoiceGroup a
left outer join ClinicInvoiceDetails b on a.Trans_Key = b.Group_Key
left outer join MedicalServices c on b.ServiceID = c.ServiceID
left outer join AccountsSalesDepartments e on e.accode = CASE WHEN b.serviceid = 'CLN-DED' OR b.serviceid = 'CLN-DEDU' then '01' else c.acledgerid end
where a.branchid is not null and (b.sbt_status is null or b.sbt_status = '') 
and (b.InvoiceType = 'CA' or a.billtype = 'CA') and (a.Reject is null or a.Reject = 0) 
and (not a.CreditCardNo is null and a.CreditCardNo<>'')
group by a.BranchID,
	 a.TransType,
	 a.TRansNBR,
	 a.TransDateEnglish,
         e.AcCode,
	 e.DepartmentNameEnglish,
	 e.SalesCode,
	 e.CostOfGoodsCode,
	 e.InventoryCode,
	 a.DeductibleAmt,
	 a.DeductibleDiscountAmt,
	 a.ExtraDiscountAmt,
	 a.RoundOffAmt,
	 a.CreditCardID
