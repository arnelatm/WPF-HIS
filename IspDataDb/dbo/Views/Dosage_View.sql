
























CREATE VIEW [dbo].[Dosage_View]
AS
SELECT a.IdNo, a.DosageCode, a.Direction, a.DosageUnit, a.Frequency, a.FrequencyTiming, a.Route,		
		Concat(e.ItemCodeName + ' ', f.ItemCodeName + ' ', d.ItemCodeName + ' ', c.ItemCodeName + ' ') as DosageName,
		Concat(e.ItemCodeNameAra + ' ', f.ItemCodeNameAra + ' ', d.ItemCodeNameAra + ' ', c.ItemCodeNameAra + ' ') as DosageNameAra,
		c.ItemCodeName AS DirectionName, 
		d.ItemCodeName AS RouteName, 
		e.ItemCodeName AS FrequencyName, 
		f.ItemCodeName AS FrequencyTimingName, 
		'' as PatientName,
		'' as AgeYmd,
		0 as Age,
		0.00 as Dose,
		'' as Gender,
		0 as DoseUnit,
		0.00 as Duration,
		0 as DurationUnit,
		0 as FileNo,
		a.DateTimeStamp
FROM            dbo.Dosage AS a LEFT OUTER JOIN
                         dbo.ItemCode AS c ON a.Direction = c.IdNo AND c.CodeGroupIdNo = 10 LEFT OUTER JOIN
                         dbo.ItemCode AS d ON a.Route = d.IdNo AND d.CodeGroupIdNo = 9 LEFT OUTER JOIN
                         dbo.ItemCode AS e ON a.Frequency = e.IdNo AND e.CodeGroupIdNo = 6 LEFT OUTER JOIN
                         dbo.ItemCode AS f ON a.FrequencyTiming = f.IdNo AND f.CodeGroupIdNo = 11