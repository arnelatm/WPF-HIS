


CREATE VIEW [dbo].[ProductPharmacyUnit_View]
AS
SELECT Distinct [Item_Code],[Unit]
      FROM [iGroupClinic].[dbo].[PharmacyInvoiceDetails] 
	  where unit <> 'B'