

CREATE VIEW [dbo].[EmployeePayElement_View]
AS
SELECT        dbo.EmployeePayElement.IdNo, dbo.EmployeePayElement.EmployeeIdNo, dbo.EmployeePayElement.PayElementIdNo, dbo.EmployeePayElement.Amount, dbo.PayElement.PayElementCode, dbo.PayElement.PayElementName, dbo.PayElement.PayElementNameAra, 
                         dbo.PayElement.Frequency, dbo.PayElement.PayElementType, dbo.EmployeePayElement.Sequence, dbo.PayElement.CalculationType, dbo.PayElement.DefaultQuantity, dbo.PayElement.FactorValue, dbo.PayElement.FactorType, 
                         dbo.PayElement.BasePaymentIdNo, dbo.PayElement.IncludeInEos, dbo.PayElement.Taxable, dbo.PayElement.Unit, dbo.PayElement.UsePayGroups, dbo.PayElement.AccountIdNo, 
                         dbo.EmployeePayElement.Rate AS 'Rate'
FROM            dbo.EmployeePayElement INNER JOIN
                         dbo.PayElement ON dbo.EmployeePayElement.PayElementIdNo = dbo.PayElement.IdNo