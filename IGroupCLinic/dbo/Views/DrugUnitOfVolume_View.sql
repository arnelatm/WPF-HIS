

CREATE VIEW [dbo].[DrugUnitOfVolume_View]
AS
SELECT Distinct [Unit of volume] AS UnitOfVolume
FROM            dbo.DrugList
