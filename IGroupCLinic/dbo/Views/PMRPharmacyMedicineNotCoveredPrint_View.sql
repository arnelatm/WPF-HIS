
CREATE view 	PMRPharmacyMedicineNotCoveredPrint_View --EMR_Pharmacy_Medicine_NotCovered_Print_View
 
as 
select 	a.*,
	b.RowNBR,
	b.Item_Code,
	b.Qty,
	b.Unit,
	b.SalePrice,
	b.DiscountPer,
	b.DiscountAmt,
	b.BillAmt,
	b.ItemNameEnglish as ItemNameEnglish,
	b.ItemNameArabic as ItemNameArabic,
	b.DosageID, 
	b.DosageEnglish ,
	b.DosageArabic ,
	b.Duration,
	c.PatientNameEnglish ,
	c.Age,
	c.Sex,
	c.AgeYMD ,
	d.CountryNameEng,
	e.EMPNameEnglish,
	e.OPDNo ,
	f.NameEnglish as Company,
	g.PharmacyTransNBR,
	g.Printed
from 	PMRPatientGeneralInfo A	
left outer join PMRMedicineNotCoveredDetails_View B on a.trans_key=b.trans_key 
left outer join PatientDetails 		C on a.registrationno =c.registrationno and a.series=c.series
left outer join CountryMaster 	D on c.countryiota =d.countryiota 
left outer join EmployeeDetails		E on a.doctorid  =e.empid 
left outer join InsuranceDetails 	F on a.insuranceid  =f.insuranceid
left outer join PMRPharmacyInvoiceGenerated g on a.Trans_Key  =g.PMRTrans_Key AND b.item_Code = g.item_code

