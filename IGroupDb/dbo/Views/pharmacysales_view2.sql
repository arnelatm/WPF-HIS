
create view pharmacysales_view2
AS
SELECT a.Trans_Key,
a.branchID,
a.BillType,
a.TransType,
a.TranSNBR,
a.TransDateEnglish,
a.RegistrationType,
a.RegistrationNo,
a.RegistrationDate,
a.ReferenceNo,
a.DoctorID,
a.InsuranceID,
a.InsuranceGroupID,
a.InsuranceNameEnglish,
a.DeductionCategory,
a.InsuranceCardNo,
a.InsurancePolicyNo,
a.InsSoapNo,
a.InsSoapCard,
a.PreviousBalanceAmt,
a.NormalDiscountAmt,
a.DeductibleAmt,
a.DeductibleDiscountAmt,
a.ExtraDiscountAmt,
a.ExtraDiscountPercent,
a.RoundoffAmt,
a.BillAmt,
a.CostAmt,
a.VATAmt as TotalVatAmt,
a.Remarks,
a.CreditCardID,
a.UserID,
a.Create_Date,
a.MachineID,
b.RowNbr,
b.SaleType,
b.Item_Code,
b.Batch,
b.EXpiry,
b.Qty,
(case when b.Unit = 'B' then 'Box'
when b.Unit = 'S' then 'Strip'
when b.Unit = 'P' then 'Pieces'
end) as unit,
b.pCSQty,
c.Pack1,
c.Pack2,
c.Pack3,
l.CashPrice,
b.SalePrice,
b.CostPrice,
b.DiscountPer,
b.DiscountAmt,
b.VATPercent,
b.VATAmt,
b.DeductiblePer as ItemDeductiblePer,
b.DeductibleAmt as ItemDeductibleAmt,
b.SaleStatus,
C.ItemNameEnglish,
d.EmpNameEnglish as DoctorNameEnglish,
e.NameEnglish as InsuranceGroupNameEnglish,
case when a.TransType = 'CA' and a.RegistrationNo = 0
	then 'Cash Customer'
		else case when a.registrationtype = 'Cash'
			then a.InsuranceNameEnglish
			else f.PatientNameEnglish end
		end as PatientNameEnglish,
	f.GroupNo as FamilyRegistrationNo,
	f.age,
	(case when f.ageymd='Y' then 'Year(s)'
		  when f.ageymd='M' then 'Month(s)'
		  when f.ageymd='D' then 'Day(s)'
	end) as AgeYMD,
	(case when f.sex = 'M' then 'Male' else 'Female' end) as Sex,
	f.IqamaNo,
	f.Series,
	f.CountryIOTA ,
	g.CountryNameEng,
	CAST((case when a.roundoffamt <> 0 and
	b.saleprice <> 0 and b.qty <> 0 and a.billamt <> 0 then
	((b.SalePrice * b.qty)* a.roundoffamt)/a.billamt
		else 0 end) AS NUMERIC(38,16)) as itemroundoff,
	CAST((case when a.extradiscountamt <> 0 and
	b.saleprice <> 0 and b.qty <> 0 and a.billamt <> 0 then
	((b.SalePrice * b.qty) * a.ExtraDiscountAmt)/a.billamt else 0 end) as Numeric(38,16)) as itemDiscount,
	h.UserNameEnglish,
	i.UnderInsuranceID,
	j.NameEnglish as UnderInsuranceName
From PharmacyInvoiceGroup a
Left Outer Join pharmacyinvoicedetails b on a.trans_key = b.group_key
Left Outer Join ItemDetails c 
on C.item_code 
COLLATE database_DEFAULT = b.Item_Code 
COLLATE database_DEFAULT and 
C.BranChID COLLATE database_DEFAULT= b.BranchID
COLLATE database_DEFAULT
Left Outer Join EmployeeDetails d on 
a.DoctorID COLLATE database_DEFAULT = d.EmpID
COLLATE database_DEFAULT
Left outer join InsuranceDetails e on
a.InsuranceGroupID COLLATE database_DEFAULT = e.InsuranceID 
COLLATE database_DEFAULT and
InsuranceType = 'I'
Left Outer Join PatientDetails f 
on a.RegistrationNo = f.RegistrationNo and f.series = upper(left(a.RegistrationType,2))
Left Outer Join CountryMaster g 
on g.CountryIOTA COLLATE database_DEFAULT=f.countryIOTA COLLATE database_DEFAULT
left outer Join UsersBank h 
on a.UserID COLLATE database_DEFAULT= h.UserID
COLLATE database_DEFAULT
left outer Join InsuranceDetails i
on a.InsuranceID COLLATE database_DEFAULT = i.insuranceID
COLLATE database_DEFAULT and i.InsuranceType = 'I'
left outer Join InsuranceDetails j on
i.UnderInsuranceID COLLATE database_DEFAULT =
j.UnderInsuranceID COLLATE database_DEFAULT and
i.InsuranceType = 'I'
outer apply (select top 1 * from
StockPositionCurrent where CashPrice > 0 and
branchid='01' and b.Item_Code = Item_Code ) l