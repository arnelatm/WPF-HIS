



CREATE VIEW [dbo].[InvoicePrintingDuplicate_View]
AS
(
(SELECT  'ASLI' as Copy,dbo.CoAllInvoices_View.*
FROM            dbo.CoAllInvoices_View)
Union 
(SELECT  'DUPLICATE',dbo.CoAllInvoices_View.*
FROM            dbo.CoAllInvoices_View)
)
