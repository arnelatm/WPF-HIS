
CREATE view 	PMRTreatmentDetail_View
 
as 
select 		a.Trans_Key,
		a.TransNBR,
		a.Series,
		a.RegistrationNo,
		a.DoctorID,
		a.InsuranceID,
		a.InsuranceGroupID,
		a.RowNBR,
		a.Item_Code,
		a.DepartmentID,
		a.Qty,
		a.Unit,
		a.SalePrice,
		a.DiscountPer,
		a.DiscountAmt,
		a.DeductibleAmt,
		a.CostPrice,
		a.BillAmt,
		a.Issue_Flag,
		a.Dsh_Key,
		a.UserID,
		a.Create_Date,
		a.MachineID,
		b.ServiceNameEnglish as ItemNameEnglish,
		b.ServiceNameArabic as ItemNameArabic,
		e.DepartmentNameEnglish as Department,
		CASE WHEN c.AltServiceID is NULL OR c.AltServiceID='' THEN a.Item_Code ELSE c.AltServiceID End as AltItem_Code,
		CASE WHEN c.AltServiceID is NULL OR c.AltServiceID='' THEN b.ServiceNameEnglish ELSE c.AltServiceNameEnglish END as AltItemNameEnglish,
		CASE WHEN c.AltServiceID is NULL OR c.AltServiceID='' THEN b.ServiceNameArabic ELSE c.AltServiceNameArabic END as AltItemNameArabic,
                a.TreatmentRemark as Remark
from		PMRPatientTreatment A
left outer join	MedicalServices		B ON a.item_code=b.ServiceID
left outer join InsuranceAltServicePriceList C on a.Item_Code = c.ServiceID AND a.InsuranceGroupID = c.InsuranceID
left outer join	MedicalDepartments 	E ON a.departmentID=e.DepartmentID