
























CREATE VIEW [dbo].[IBCLAInvoices_View]
  AS
(SELECT * FROM IbAInvoices_View 
Union
Select * from ClinicAINvoices_View
)
