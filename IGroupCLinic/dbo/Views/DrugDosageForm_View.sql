

CREATE VIEW [dbo].[DrugDosageForm_View]
AS
SELECT Distinct [Dosage Form] AS DosageForm
FROM            dbo.DrugList
