
CREATE VIEW ClinicDailyCollectionCalculation_View
 
AS

select
	a.BranchID,
	a.TransType,
	a.TransNBR,
	a.TransDateEnglish,
	CASE WHEN e.AcCode IS NULL THEN '99' ELSE E.ACCODE END AS ACCODE,
	CASE WHEN e.accode is null then 'Others' else e.DepartmentNameEnglish end as DepartmentNameEnglish,
	CASE WHEN e.accode is null then '41010100003' else e.SalesCode end as SalesCode,
	CASE WHEN e.accode is null then '' else e.CostOfGoodsCode end as CostOfGoodsCode,
	CASE WHEN e.accode is null then '' else e.InventoryCode end as InventoryCode, 
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
left outer join EmployeeDetails emp on a.DoctorID = emp.EmpID 
left outer join accountsdistributeddepartments AcD on c.DepartmentID  = acd.departmentid and acd.status = 1
left outer join AccountsSalesDepartments e on 
case when acd.departmentid is null  then c.DepartmentID else emp.deptid end  = e.DepartmentID 
where a.branchid is not null and (b.sbt_status is null or b.sbt_status = '') 
and (b.InvoiceType = 'CA' or a.billtype = 'CA') and (a.Reject is null or a.Reject = 0) 
and (a.CreditCardNo is null or a.CreditCardNo='') 
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
	 a.RoundOffAmt
UNION ALL
select
	a.BranchID,
	a.TransType,
	a.TransNBR,
	a.TransDateEnglish,
	CASE WHEN e.AcCode IS NULL THEN '999' ELSE E.ACCODE END AS ACCODE,
	CASE WHEN e.accode is null then 'Others' else e.DepartmentNameEnglish end as DepartmentNameEnglish,
	CASE WHEN e.accode is null then '41010100003' else e.SalesCode end as SalesCode,
	CASE WHEN e.accode is null then '' else e.CostOfGoodsCode end as CostOfGoodsCode,
	CASE WHEN e.accode is null then '' else e.InventoryCode end as InventoryCode, 
	CONVERT(numeric(10,2),SUM(b.Qty*b.Price)) as GrossAmt, 
	CONVERT(numeric(10,2),SUM(case when b.discamt = 0 then b.Qty*b.Price* b.DiscPer/100 else b.DiscAmt end)) as DiscountAmt,
	CONVERT(numeric(10,2),0) as DeductibleAmt,
	CONVERT(numeric(10,2),SUM(b.Qty*c.CostPrice)) as CostAmt,
    CONVERT(numeric(10,2),0) as DiscountOnDeductible,
	CONVERT(numeric(10,2),a.ExtraDiscountAmt) AS ExtraDiscountAmt,
	CONVERT(numeric(10,2),0) as RoundOffAmt
from IBInvoiceGroup  a
left outer join IBInvoiceDetails  b on a.Trans_Key = b.Group_Key
left outer join MedicalServices c on b.ServiceID = c.ServiceID
left outer join AccountsSalesDepartments e on e.accode = CASE WHEN b.serviceid = 'CLN-DED' OR b.serviceid = 'CLN-DEDU' then '01' else c.acledgerid end
where a.branchid is not null  
and UPPER(a.TransType)  = 'CASH' and (a.Rejected  is null or a.Rejected  = 0) 
--and (a.CreditCardNo is null or a.CreditCardNo='')
group by a.BranchID,
	 a.TransType,
	 a.TRansNBR,
	 a.TransDateEnglish,
     	 e.AcCode,
	 e.DepartmentNameEnglish,
	 e.SalesCode,
	 e.CostOfGoodsCode,
	 e.InventoryCode,
	 a.ExtraDiscountAmt