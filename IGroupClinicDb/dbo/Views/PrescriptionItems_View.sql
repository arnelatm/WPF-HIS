




CREATE VIEW [dbo].[PrescriptionItems_View]
AS
SELECT  a.Trans_Key as TransKey, A.Item_Code as ItemCode, a.DosageArabic as DosageAra, a.ItemNameEnglish as ItemName, 
        a.DosageEnglish as Dosage, a.Duration, a.GenericName, a.RowNBR
FROM   dbo.PMRPharmacyMedicinePrint_View a
GO



GO


