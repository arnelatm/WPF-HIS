CREATE VIEW InsuranceClinicPrint_View
 
AS
SELECT
	'Clinic' as TrType,
	a.Trans_Key,
	'CR' as TransType,
	a.TransNBR,
	'CR' as BillType,
	a.RegistrationNo,
	a.TransDateEnglish,
	b.InsCoCode as InsuranceID,
	c.NameEnglish as InsuranceNameEnglish,
	a.Deductible as DeductibleAmt,
	0 as ExtraDiscountAmt,
	'' as Remarks,
	a.InsCardNo,
	case when g.AltServiceID is null then a.ServiceID else g.AltServiceID end as ServiceID,
	case when g.AltServiceID is null then a.ServiceID else g.AltServiceID end as InsServiceID,
	a.Qty,
	a.Amount as SalePrice,
	0 as DiscountPer,
	a.Discount as DiscountAmt,
	a.PatientNameEnglish,
	b.Age,
	b.AgeYMD,
	b.Sex,
	case when g.AltServiceID is null then a.ServiceDescription else g.AltServiceNameEnglish end as ServiceNameEnglish,
	case when g.AltServiceID is null then a.ServiceDescription else g.AltServiceNameEnglish end as InsServiceNameEnglish,
	a.DoctorNameEnglish as EmpNameEnglish,
	e.CountryNameEng,
	b.IQAMANo,
	f.NameEnglish,
	0 as TokenNo,
	d.OPDNo,
	'N' as PrintDept,
	a.UserID,
	a.Create_Date
From InsuranceAlteredData a
left outer join PatientDetails b on a.RegistrationNo = b.RegistrationNo AND b.Series = 'CR'
left outer join InsuranceDetails c on c.InsuranceID = b.InsCoCode
left outer join EmployeeDetails d on a.DoctorID = d.EmpID
left outer join CountryMaster e on e.CountryIOTA = b.CountryIOTA
left outer join InsuranceDetails f on a.InsuranceID = f.InsuranceID AND f.InsuranceType = 'TPA'
left outer join InsuranceAltServicePriceList g on a.ServiceID = g.ServiceID AND a.InsuranceID = g.InsuranceID
