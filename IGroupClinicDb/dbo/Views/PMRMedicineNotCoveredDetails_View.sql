





CREATE view 	[dbo].[PMRMedicineNotCoveredDetails_View] --EMR_Patient_Medicine_Detail_View
 
as 
select		a.*,
		b.IdNo as PrescriptionItemIdNo,
		b.RowNBR,
		b.item_code,
		b.qty,
		b.unit,
		b.saleprice,
		b.discountper,
		b.discountamt,
		b.days,
		b.dosageID,
		c.ItemnameEnglish,
		c.itemnamearabic,
		c.pack1,
		c.pack2 ,
		c.pack3 ,
		c.acct_dept ,
		d.itemnameenglish as DosageEnglish,
		d.itemnamearabic as DosageArabic,
		e.DescriptionEnglish as Duration,
		'PHR' as DepartmentID,
		g.PharmacyTransNBR,
		g.Printed,
		IsNull(b.LabelPrinted,0) as LabelPrinted
from		PMRMedicineNotCoveredGroup	A
left outer join	PMRMedicineNotCoveredDetails 	B ON a.Trans_key =b.Group_key 
left outer join	ItemDetails		C ON B.item_code=C.item_code 
left outer join	MedicineDosageMaster	D ON b.dosageID=d.ItemID
left outer join	PMRQtyDays		E ON b.days =e.id
left outer join	EmployeeDetails		F ON a.doctorID =f.empID
left outer join PMRPharmacyInvoiceGenerated g on a.Trans_Key  =g.PMRTrans_Key AND b.item_Code = g.item_code