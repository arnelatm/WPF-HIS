USE iGroupClinic
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON
GO
Create view patientprofile_view2 as 
Select a.Branchid,
a.Trans_key,
c.series,
a.registrationtype,
a.transtype,
a.transnbr,
a.billtype,
a.registrationno,
a.transdateenglish,
a.transdatehijri,
a.doctorid,
a.insuranceid,
a.insurancegroupid,
a.insurancenameenglish,
a.normaldiscountamt,
a.previousBalanceAmt,
a.deductibleamt,
a.deductiblediscountamt,
a.extradiscountpercent,
a.extradiscountamt,
a.roundoffamt,
a.billamt,
a.remarks,
c.inssoapno,
c.inssoapcode,
c.inscardno,
a.userid,
a.machineid,
convert(datetime,a.create_date) as entry_date,
b.rownbr,
b.serviceid,
b.qty,
b.saleprice,
b.costprice,
b.discountper,
b.discountamt,
b.deductibleper,
b.salestatus,
b.costpriceperunit,
d.departmentid,
c.patientnameenglish,
c.Age,
c.AgeYMD,
c.Sex,
c.CountryIOTA,
d.ServiceNameEnglish,
e.EmpNameENglish,
f.countryNameEng,
c.IqamaNo,
k.NameEnglish as groupName,
h.GroupInsuranceID,
l.NameEnglish as activeInsName,
h.UnderInsuranceID,
m.NameENglish as co_ins_company,
n.ServiceID as insServiceID,
n.ServiceNameEnglish as InsServiceNameENglish
from ClinicInvoiceGroup a
left outer join CLinicInvoiceDetails b on a.Trans_key = b.Group_key and a.BranchId = b.BranchID 
left outer join PatientDetails c on a.RegistrationNo = c.RegistrationNo and upper(a.RegistrationType) = upper(c.PatientType) and a.BranchID = c.BranchID
left outer join MedicalServices d on b.ServiceID = d.ServiceID and a.BranchID = d.BranchID 
left outer join EMployeeDetails e on a.DOctorID=e.EmpId 
left outer join CountryMaster f on c.CountryIOTA=f.CountryIOTA
left outer join INsuranceDetails h on a.InsuranceID=h.InsuranceID
left outer join InsuranceDetails k on a.InsuranceGroupID=k.InsuranceID
left outer join InsuranceDetails l on h.GroupInsuranceID=l.InsuranceID
left outer join insuranceDetails m on h.UnderInsuranceID=m.InsuranceID
left outer join InsuranceServicePRiceList n on b.ServiceID=n.ServiceID and n.InsuranceID = a.InsuranceGroupID
GO
