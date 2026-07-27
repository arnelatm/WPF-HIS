


CREATE VIEW [dbo].[XRayServicesInvoice_View]
AS
SELECT dbo.A1_Invoces.ID, 
dbo.A1_Invoces.Date AS InvoiceDate, 
dbo.A1_Invoces.CustID AS FileNumber, 
Cast(dbo.A1_Works.Name as nvarchar(255)) AS ItemName, 
dbo.Customers.CustGender AS Gender, 
dbo.Customers.CustNat AS Nationality
FROM     dbo.A1_Invoces INNER JOIN
                  dbo.A1_OrderWorks ON dbo.A1_Invoces.ID = dbo.A1_OrderWorks.OrderID INNER JOIN
                  dbo.A1_Works ON dbo.A1_OrderWorks.WorkID = dbo.A1_Works.Code INNER JOIN
                  dbo.Customers ON dbo.A1_Invoces.CustID = dbo.Customers.CustID
where dbo.A1_works.GroupCode='X'