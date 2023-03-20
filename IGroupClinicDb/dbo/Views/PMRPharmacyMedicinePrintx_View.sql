



CREATE view 	[dbo].[PMRPharmacyMedicinePrintx_View] --EMR_Pharmacy_Medicine_Print_View
 
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
	b.itemnamearabic as ItemNameArabic,
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
	g.Printed,
	c.InsCardExpiry,
	k.RegistrationNo as SFDACode,
    IsNull(m.[Generic name],n.[Generic name]) as GenericName,
	IsNULL(m.[trade name],n.[Trade Name]) as TradeName,
    IsNULL(m.[strength value],n.[strength value]) as StrengthValue,
    IsNULL(m.[unit of strength],n.[unit of strength]) as UnitOfStrength,
    IsNULL(m.[dosage form],n.[dosage form]) as DosageForm,
    IsNULL(m.[Volume],n.[Volume]) as Volume,
    IsNULL(m.[Unit of Volume],n.[Unit of Volume]) as UnitOfVolume,
    IsNULL(m.[Package type],n.[Package type]) as PackageType,
    IsNULL(m.[Package size],n.[Package size]) as PackageSize
from 	PMRPatientGeneralInfo			A	
left outer join PMRMedicineDetails_View 	B on a.trans_key=b.Trans_key 
left outer join PatientDetails 			C on a.registrationno =c.registrationno and a.series=c.series
left outer join CountryMaster 			D on c.countryiota =d.countryiota 
left outer join EmployeeDetails			E on a.doctorid  =e.empid 
left outer join InsuranceDetails 		F on a.insuranceid  =f.insuranceid
left outer join PMRPharmacyInvoiceGenerated g on a.Trans_Key  =g.PMRTrans_Key AND b.item_Code = g.item_code
left outer join ItemRegistration    k on b.item_code COLLATE database_DEFAULT = k.Item_Code COLLATE database_DEFAULT 
left outer join ItemDetails         o on o.Item_code = b.item_code
left outer join DrugList            m on m.GTIN = o.GTIN 
left outer join DrugList            n on k.RegistrationNo  COLLATE database_DEFAULT = m.registrationno COLLATE database_DEFAULT