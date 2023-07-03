
CREATE VIEW [dbo].[PatientProfile_View]
AS
SELECT a.BranchID,
a.Trans_Key,
c.Series,
a.RegistrationType,
a.TransType,
a.TransNbr,
a.BillType,
a.RegistrationNo,
a.TransDateEnglish,
a.TransDateHijri,
a.DoctorID,
a.InsuranceID,
a.InsuranceGroupID,
a.InsuranceNameEnglish,
a.NormalDiscountAmt,
a.PreviousBalanceAmt,
a.DeductibleAmt,
a.DeductibleDiscountAmt,
a.ExtraDiscountPercent,
a.ExtraDiscountAmt,
a.RoundOffAmt,
a.BillAmt,
a.remarks,
c.InsSoapNo,
c.InsSoapCode,
c.InsCardNo,
a.UserID,
a.MachineID,
CONVERT(datetime, a.Create_Date) AS entry_date,
b.RowNbr,
b.ServiceID,
b.Qty,
b.SalePrice,
b.CostPrice, 
b.DiscountPer,
b.DiscountAmt,
b.DeductiblePer,
b.SaleStatus,
b.costPricePerUnit,
d.DepartmentID,
c.PatientNameEnglish,
c.Age,
c.AgeYMD,
c.Sex,
c.CountryIOTA,
d.ServiceNameEnglish,
e.EmpNameEnglish,
f.CountryNameEng,
c.IqamaNo,
k.NameEnglish AS groupName,
h.GroupInsuranceID,
l.NameEnglish AS activeInsName,
h.UnderInsuranceID,
m.NameEnglish AS co_ins_company,
n.ServiceID AS insServiceID,
n.ServiceNameEnglish AS InsServiceNameENglish,
b.VATAmt,
a.VATExemption
FROM dbo.ClinicInvoiceGroup AS a
LEFT OUTER JOIN dbo.ClinicInvoiceDetails AS b ON a.Trans_Key = b.Group_Key AND a.BranchID = b.BranchID
LEFT OUTER JOIN dbo.PatientDetails AS c ON a.RegistrationNo = c.RegistrationNo AND UPPER(a.RegistrationType) = UPPER(c.PatientType) AND a.BranchID = c.BranchID
LEFT OUTER JOIN dbo.MedicalServices AS d ON b.ServiceID = d.ServiceID AND a.BranchID = d.BranchID
LEFT OUTER JOIN dbo.EmployeeDetails AS e ON a.DoctorID = e.EmpID
LEFT OUTER JOIN dbo.CountryMaster AS f ON c.CountryIOTA = f.CountryIOTA
LEFT OUTER JOIN dbo.InsuranceDetails AS h ON a.InsuranceID = h.InsuranceID
LEFT OUTER JOIN dbo.InsuranceDetails AS k ON a.InsuranceGroupID = k.InsuranceID
LEFT OUTER JOIN dbo.InsuranceDetails AS l ON h.GroupInsuranceID = l.InsuranceID
LEFT OUTER JOIN dbo.InsuranceDetails AS m ON h.UnderInsuranceID = m.InsuranceID
LEFT OUTER JOIN dbo.InsuranceServicePriceList AS n ON b.ServiceID = n.ServiceID AND n.InsuranceID = a.InsuranceGroupID