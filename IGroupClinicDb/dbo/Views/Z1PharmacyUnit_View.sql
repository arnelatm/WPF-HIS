




CREATE VIEW [dbo].[Z1PharmacyUnit_View]
AS
SELECT Distinct a.BRANCHID,a.[Item_Code],a.[Unit]
      FROM [iGroupClinic].[dbo].[PharmacyInvoiceDetails] a
	  left join ItemDetails b
	  on a.Item_Code = b.Item_Code and a.BranchId = b.BranchId
	  where unit <> 'B'