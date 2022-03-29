create view [dbo].SalesManPerDay_VIew
as 
SELECT TransDateEnglish,Transnbr,RegistrationNo, Border_Iqama, SalesmanID, LabSeries
FROM            IBInvoiceGroup WHERE IBType = '3'
