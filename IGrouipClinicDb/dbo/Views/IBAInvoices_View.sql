























CREATE VIEW [dbo].[IBAInvoices_View]
  AS
(SELECT a.InvSource,
		a.Trans_Key,
		a.TransType,
        a.SaleType,
        a.BranchID,
        a.DoctorID,
        a.TransNbr,
        a.TransDateEnglish,
        a.TransDateHijri,
        a.NormalDiscountAmt,
        a.ExtraDiscountAmt,
        a.ExtraDiscountPercent,
        a.RoundOffAmt,
        a.InvVatAmt,
        a.VatExemption,
        a.BillAmt,
        a.Reject,
        a.InsuranceID,
        a.TokenNo,
        a.RegistrationNo,
        a.RegistrationType,
        a.RegistrationDate,
        a.InsuranceGroupID,
        a.BillType,
        a.DeductibleAmt,
        a.Remarks,
        a.RejectDate,
        a.UserId,
        a.MachineID,
        a.Create_Date,
        a.InsuranceNameEnglish,
        a.PatientNameEnglish,
        a.PatientNameArabic,
        a.Age,
        a.AgeYMD,
        a.Sex,
        a.CountryIOTA,
        a.IqamaNo,
        a.Mobile,
        a.EmpNameEnglish,
        a.SponsorID,
		b.RowNbr,b.ServiceId,b.Qty,b.Unit,b.PcsQty,b.SalePrice,b.ItemDiscountAmt,b.VatPercent,b.VatAmt,b.DiscountPer,b.DiscountAmt,
		case when n.serviceID is null then d.ServiceNameEnglish else n.ServiceNameEnglish end as ServiceNameEnglish	,
		case when (n.serviceID is null or d.ServiceNameArabic is null or d.ServiceNameArabic = '') then d.ServiceNameEnglish else d.ServiceNameArabic  end as ServiceNameArabic,
		i.GroupInsuranceID,
		n.ServiceID	as insServiceID	,
		n.ServiceNameEnglish as InsServiceNameEnglish,
		f.CountryNameEng,
		f.CountryNameArabic,
		d.DepartmentID,
		a.IBType,
		a.OPDFloor,
		a.OPDNo,
		P.PrintDept
from IBHInvoices_View a 
Inner Join IBDInvoices_View b
on a.InvSource = b.InvSource and a.Trans_Key = b.Group_Key
left outer join MedicalServices d 
on b.ServiceID=d.ServiceID and a.BranchID=d.BranchID	  
left outer join InsuranceDetails i
on a.Insuranceid = i.InsuranceID
left outer join InsuranceServicePriceList n 
on b.ServiceID = n.ServiceID AND n.InsuranceID = i.GroupInsuranceID
left outer join CountryMaster f 
on a.CountryIOTA COLLATE database_default = f.CountryIOTA COLLATE database_default  
left outer join ClinicInvoicePrint p
on a.TransNbr = p.TransNbr and a.BillType = p.BillType and p.RegistrationType = 'IBD' and p.PrintDept = 'N'
)