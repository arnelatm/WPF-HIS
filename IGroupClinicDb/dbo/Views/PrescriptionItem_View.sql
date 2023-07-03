








CREATE VIEW [dbo].[PrescriptionItem_View]
AS
SELECT  Trans_Key as TransKey, Item_Code as ItemCode, DosageArabic as DosageAra, ItemNameEnglish as ItemName, 
        DosageEnglish as Dosage, Duration, GenericName, PrescriptionItemIdNo, RowNBR, LabelPrinted, IIf(LabelPrinted=0,1,0) as PrintLabel
FROM   dbo.PMRPharmacyMedicinePrint_View