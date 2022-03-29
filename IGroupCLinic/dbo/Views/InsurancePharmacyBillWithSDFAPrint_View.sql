CREATE VIEW InsurancePharmacyBillWithSDFAPrint_View
 
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
	case when e.registrationNo is null then a.ServiceID else e.registrationno end as Item_Code,
	case when e.registrationno is null then a.ServiceDescription else e.[Trade name] end as ItemNameEnglish,
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
left outer join ItemRegistration d on d.item_code = a.ServiceID and a.TrType = 'Pharmacy'
left outer join DrugList e on e.RegistrationNo = d.RegistrationNo
