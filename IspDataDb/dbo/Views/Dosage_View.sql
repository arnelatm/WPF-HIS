





















CREATE VIEW [dbo].[Dosage_View]
AS
SELECT a.IdNo, a.DosageCode, a.Direction, a.DosageUnit, a.Frequency, a.FrequencyTiming, a.Route,		
		Concat(e.ItemCodeName + ' ', f.ItemCodeName + ' ', d.ItemCodeName + ' ', c.ItemCodeName + ' ') as DosageName,
		Concat(e.ItemCodeNameAra + ' ', f.ItemCodeNameAra + ' ', d.ItemCodeNameAra + ' ', c.ItemCodeNameAra + ' ') as DosageNameAra,
		c.ItemCodeName AS DirectionName, 
		d.ItemCodeName AS RouteName, 
		e.ItemCodeName AS FrequencyName, 
		f.ItemCodeName AS FrequencyTimingName, 
		a.DateTimeStamp
FROM            dbo.Dosage AS a LEFT OUTER JOIN
                         dbo.ItemCode AS c ON a.Direction = c.IdNo AND c.CodeGroupIdNo = 10 LEFT OUTER JOIN
                         dbo.ItemCode AS d ON a.Route = d.IdNo AND d.CodeGroupIdNo = 9 LEFT OUTER JOIN
                         dbo.ItemCode AS e ON a.Frequency = e.IdNo AND e.CodeGroupIdNo = 6 LEFT OUTER JOIN
                         dbo.ItemCode AS f ON a.FrequencyTiming = f.IdNo AND f.CodeGroupIdNo = 11