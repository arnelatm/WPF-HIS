



CREATE VIEW [dbo].[MohReportDiagnosticServices_View]
AS
SELECT		c.CustID, 
			c.CustGender AS Sex, 
			c.CustNat AS Nationality, 
			b.DrName, 
			CAST(b.Date AS dATE) AS InvoiceDate, 
			C.CustFileDate, 
			B.IsReturn, 
			a.ID AS InvoiceNumber,
			a.[Name] as ItemServiceName
FROM        dbo.A1_OrderWorks a
			INNER JOIN dbo.A1_Invoces b
			on a.OrderId = b.Id 
			Inner Join dbo.Customers c
			ON b.CustID = c.CustID
			inner join dbo.A1_works d
			on a.WorkID = d.Code
			where d.GroupCode='T'