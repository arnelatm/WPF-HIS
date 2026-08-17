
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE View [dbo].[ApSummaryPharmacy_View] as 
(select SUPPLIERiDnO,b.SupplierName,SupplierCode,SupplierNameAra,Sum(BALANCE) as Balance
  FROM [ISPDATA].[dbo].[ApOpenInvoice_View] A 
  LEFT JOIN SUPPLIER B ON A.SupplierIdNo = b.IdNo
   WHERE ACCOUNTIDNO = '202' AND BALANCE <> 0
  GROUP BY SUPPLIERIDNO,SupplierName,SupplierNameAra,SupplierCode)

GO

