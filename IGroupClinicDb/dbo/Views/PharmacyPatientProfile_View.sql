
CREATE VIEW PharmacyPatientProfile_View
 
AS
	select a.BranchID         	,
	a.trans_key    			,
	c.series			,
	c.PatientType as RegistrationType,
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
	a.NormalDiscountAmt 		,
	a.PreviousBalanceAmt 		,
	a.DeductibleAmt 		,
	a.DeductibleDiscountAmt		,
	a.ExtraDiscountPercent 		,
	a.ExtraDiscountAmt    		,
	a.RoundOffAmt      		,
	a.BillAmt       		,
	a.Remarks               	,
	c.InsSoapNo 			,
	c.InsSoapCode   		,
	c.InsCardNo	           	,
	a.UserID 			,
	a.MachineID	,
	CONVERT(datetime,a.Create_Date) as entry_date,
	b.RowNbr			,
	b.Item_Code as ServiceID	,
	b.Qty				,
	b.SalePrice			,
	b.CostPrice			,
	b.DiscountPer			,
	b.DiscountAmt			,
	b.deductibleper			,
	b.SaleStatus			,
	b.CostPricePerUnit		,
	c.PatientNameEnglish		,
	c.Age				,
	c.AgeYMD			,
	c.Sex				,
	c.CountryIOTA			,
	d.ItemNameEnglish as ServiceNameEnglish,
 	e.EmpNameEnglish		,
 	f.CountryNameEng		,
	c.IqamaNo			
from 	PharmacyInvoiceGroup 				a
	left outer join PharmacyInvoiceDetails 		b on a.Trans_key=b.Group_key and a.BranchID=b.BranchID
	left outer join PatientDetails 			c on a.RegistrationNo=c.RegistrationNo  and upper(left(a.RegistrationType,2)) = c.Series
 	left outer join ItemDetails  			d on b.Item_code=d.Item_Code and a.BranchID=d.BranchID
 	left outer join EmployeeDetails 		e on a.DoctorID=e.EmpID
 	left outer join CountryMaster 			f on c.CountryIOTA=f.CountryIOTA
 	left outer join InsuranceDetails		h on a.InsuranceID=h.InsuranceID 
	WHERE B.ITEM_CODE<>'PHR-DED'