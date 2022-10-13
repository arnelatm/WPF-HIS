create view LoanAdvances_View 
as
 Select 
  a.Trans_Key,
  a.EmpID,
  c.EmpNameEnglish,
  c.EmpNameArabic,  
  a.TransNBR,
  a.TransDateEnglish,
  a.TransType,
  a.StartingMonth,
  a.StartingYear,
  a.TotalAmount,
  a.NoOfInstallments,
  a.InstallmentAmt,
  a.Remark,
  b.RowNBR,
  b.[Month],
  b.[Year],
  b.InstallmentsAmt,
  b.PendingAmt, 
  b.DeductedAmt
From HREmployeeInstallmentGroup a
left outer join HREmployeeInstallmentDetails b on a.Trans_Key = b.Group_Key 
left outer join HREmployeeDetails c on a.EmpID = c.EmpID