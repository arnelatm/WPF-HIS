CREATE View PMRPrescription_View
 
as
SELECT * FROM PMRPharmacyMedicineNotCoveredPrint_View
 union all
 SELECT * FROM PMRPharmacyMedicinePrint_View