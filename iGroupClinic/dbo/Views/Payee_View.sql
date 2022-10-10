





CREATE VIEW [dbo].[Payee_View]
AS
SELECT dbo.Payee.IdNo,
	   dbo.Payee.PayeeType,
	   dbo.Payee.PayeeIdNo,
	   iif(dbo.Payee.PayeeType='S',Supplier.SupplierCode,Iif(dbo.Payee.PayeeType='C',Customer.CustomerCode,IIf(dbo.Payee.PayeeType='E',Employee.EmployeeCode,''))) as PayeeCode,
	   iif(dbo.Payee.PayeeType='S',Supplier.SupplierName,Iif(dbo.Payee.PayeeType='C',Customer.CustomerName,IIf(dbo.Payee.PayeeType='E',Employee.EmployeeName,''))) as PayeeName,
	   iif(dbo.Payee.PayeeType='S',Supplier.SupplierNameAra,Iif(dbo.Payee.PayeeType='C',Customer.CustomerNameAra,IIf(dbo.Payee.PayeeType='E',Employee.EmployeeNameAra,''))) as PayeeNameAra	   
From Payee
Left Join Employee on dbo.Payee.PayeeIdNo = Employee.IdNo
Left Join Customer on dbo.Payee.PayeeIdNo = Customer.IdNo
Left Join Supplier on dbo.Payee.PayeeIdNo = Supplier.IdNo