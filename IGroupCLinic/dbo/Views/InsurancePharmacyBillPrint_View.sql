CREATE VIEW InsurancePharmacyBillPrint_View
 
AS

Select  
	a.TrType,
	'CR' as BillType,
	'CR' as TransType,
	a.Trans_Key,
	a.BranchID,
	a.InsuranceID as InsuranceGroupID,
	a.RegistrationNo,
	a.PatientNameEnglish,
	a.TransNBR,
	a.TransDateEnglish,
	a.ServiceID as Item_Code,
	a.ServiceDescription as ItemNameEnglish,
	a.DoctorID,
	a.DoctorNameEnglish,
	a.Qty,
	'Box' as Unit,
	a.Amount as SalePrice,
	0 as DiscountPer,
	a.Discount as DiscountAmt,
	a.Deductible as DeductibleAmt,
	0 as DeductibleDiscountAmt,
	0 as ExtraDiscountAmt,
	a.UserID,
	a.Create_Date,
	a.MachineID,
	b.InsCoCode as InsuranceID,
	c.NameEnglish as InsuranceNameEnglish,
	b.Age,
	b.Sex
from InsuranceAlteredData a
left outer join PatientDetails b on a.RegistrationNo = b.RegistrationNo AND b.Series = 'CR'
left outer join InsuranceDetails c on c.InsuranceID = b.InsCoCode
