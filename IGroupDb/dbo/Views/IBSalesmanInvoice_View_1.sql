CREATE VIEW IBSalesmanInvoice_View
 
AS
Select a.*,
		b.SalesManNameEnglish
From IBDocuments_View a
left outer join SalesmanDetails b on a.SalesmanID = b.SalesmanID