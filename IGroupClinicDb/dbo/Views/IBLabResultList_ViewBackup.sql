


CREATE VIEW [dbo].[IBLabResultList_ViewBackup]
AS
SELECT CAST(b.TransDateEnglish AS Date) AS TransactionDate,a.PassportNumber, CAST(ISNULL(b.LabSeries, 0) AS VarChar(10)) 
                  + '-' + CASE WHEN b.IBTYPE = 1 THEN 'I' WHEN b.IBTYPE = 2 THEN 'B' WHEN b.IBTYPE = 3 THEN 'D' WHEN b.IBTYPE = 4 THEN 'FD' END AS LabNo, b.Border_Iqama, b.PatientName, c.CountryNameEng, ISNULL(a.Clinical, 0) AS Clinical, 
                  ISNULL(a.Xray, 0) AS XRay, ISNULL(a.TBSputum, 0) AS TBSputum, ISNULL(a.HIVEliza, 0) AS HIVEliza, ISNULL(a.HOVEliza, 0) AS HOVEliza, ISNULL(a.HBSAgEliza, 0) AS HBSAgEliza, ISNULL(a.Malaria, 0) AS Malaria, ISNULL(a.VDRL, 0) 
                  AS VDRL, ISNULL(a.Widal, 0) AS Widal, ISNULL(a.Pregnancy, 0) AS Pregnancy, ISNULL(a.BilharziasisUrine, 0) AS BilharziasisUrine, ISNULL(a.BilharziasisStool, 0) AS BilharziasisStool, ISNULL(a.Shigella, 0) AS Shigella, ISNULL(a.Cholera, 0) 
                  AS Cholera, b.IBType, a.IdNo, b.Trans_Key, b.Sex
FROM     dbo.IBLabResult AS a RIGHT OUTER JOIN
                  dbo.IBInvoiceGroup AS b ON a.Trans_Key = b.Trans_Key LEFT OUTER JOIN
                  dbo.CountryMaster AS c ON b.CountryIOTA = c.CountryIOTA
WHERE  (b.Rejected = 0) AND (b.IBType = 1) OR
                  (b.IBType = 2)