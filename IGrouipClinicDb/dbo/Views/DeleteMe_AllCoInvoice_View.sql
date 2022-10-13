







CREATE VIEW [dbo].[DeleteMe_AllCoInvoice_View]
 
AS
	Select 
	a.InvSource,
	a.BranchID ,
	a.trans_key    			,
	c.series			,
	c.RegistrationDate		,
	a.RegistrationType		,
	a.TransType 			,
	a.TransNBR     			,
	a.BillType 			,
	a.RegistrationNo       		,
	a.TransDateEnglish		,
	a.TransDateHijri		,
	a.DoctorID 			,
	a.InsuranceID 			,
	a.InsuranceGroupID  		,
	a.InsuranceNameEnglish         	,
	h.NameArabic         	,
	a.NormalDiscountAmt 		,
	a.ExtraDiscountPercent 		,
	a.ExtraDiscountAmt    		,
	a.RoundOffAmt      		,
	a.VATAmt as TotalVATAmt,
	a.VATExemption, 
	a.BillAmt       		,
	a.Remarks               	,
	c.InsSoapNo 			,
	c.InsSoapCode   		,
	c.InsCardNo	           	,
	a.Reject			,
	a.RejectDate			,
	a.UserID 			,
	a.MachineID + '|' + a.UserID as MachineID,
	CONVERT(datetime,a.Create_Date) as Create_date,
	b.RowNbr			,
	b.SaleType			,
	b.ServiceID			,
    d.DepartmentID,
	case when b.qty is null then 1 else b.Qty	end as Qty,
	case when b.SalePrice is null then 0 else b.SalePrice end as SalePrice,
	case when b.VATPercent  is null then 0 else b.VATPercent  end as VATPercent,
	case when b.VATAmt   is null then 0 else b.VATAmt  end as VATAmt,
	c.PatientNameEnglish,
	c.PatientNameArabic	,
	c.Age				,
	c.AgeYMD			,
	c.Sex				,
	c.CountryIOTA			,
	case when n.serviceID is null then d.ServiceNameEnglish else n.ServiceNameEnglish end as ServiceNameEnglish	,
	case when (n.serviceID is null or d.ServiceNameArabic is null or d.ServiceNameArabic = '') then d.ServiceNameEnglish else d.ServiceNameArabic  end as ServiceNameArabic,
	e.EmpNameEnglish		,
	e.EmpNameArabic 		,
	f.CountryNameEng		,
	f.CountryNameArabic 	,
	c.IqamaNo			,
	c.Mobile			,
	c.PhoneO			,
	c.PhoneR			,
	c.Address1			,
	c.Address2			,
	c.City,
	k.NameEnglish as GroupName      ,
	h.GroupInsuranceID		,
	l.NameEnglish as activeInsName	,
	h.UnderInsuranceID		,
	m.NameEnglish as co_ins_company ,
	g.DepartmentNameEnglish		,
	a.TokenNo			,
	e.OPDFloor			,
	e.OPDNo				,
	n.ServiceID	as insServiceID	,
	n.ServiceNameEnglish as InsServiceNameEnglish,
	case when (d.DepartmentID = 'INJ' and a.InsuranceID = '') or (d.DepartmentID = 'VAC' and a.insuranceID = '') then 'Y' else 'N' end as PrintDept,
	dbo.currency_conversion(a.BillAmt) as AmtWordArabic,
	b.DiscountPer,
	b.DiscountAmt,
	b.DeductibleAmt
from 	CoInvoices_View a
	left outer join AllCoInvoicesDetails_View b on a.Trans_key=b.Group_key and a.BranchID=b.BranchID
	left outer join PatientDetails 			c on a.RegistrationNo=c.RegistrationNo and upper(a.RegistrationType)=upper(c.PatientType) 
							     and a.BranchID=c.BranchID
	left outer join MedicalServices  		d on b.ServiceID=d.ServiceID and a.BranchID=d.BranchID
	left outer join EmployeeDetails 		e on a.DoctorID=e.EmpID
	left outer join CountryMaster 			f on c.CountryIOTA COLLATE database_default  =f.CountryIOTA  COLLATE database_default  
	left outer join InsuranceDetails		h on a.InsuranceID=h.InsuranceID and upper(left(a.registrationtype,4))=upper(left(h.insurancetype,4))
	left outer join InsuranceDetails		k on h.GroupInsuranceID=k.InsuranceID and upper(left(h.insurancetype,4))=upper(left(k.insurancetype,4))
	left outer join InsuranceDetails		l on h.GroupInsuranceID=l.InsuranceID  and upper(left(h.insurancetype,4))=upper(left(l.insurancetype,4))
	left outer join InsuranceDetails		m on h.UnderInsuranceID=m.InsuranceID  and upper(left(h.insurancetype,4))=upper(left(m.insurancetype,4))
	left outer join InsuranceServicePriceList    	n on b.ServiceID = n.ServiceID AND n.InsuranceID = a.InsuranceGroupID 
	left outer join MedicalDepartments		g on g.DepartmentID = (case when n.serviceID is null then d.departmentID else n.DepartmentID end)