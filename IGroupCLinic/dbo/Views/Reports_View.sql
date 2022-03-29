
CREATE VIEW 	Reports_View
 
AS
SELECT 	a.reportID,
	a.ReportNo,
	a.ReportTitleEnglish AS reportTitle 
FROM ReportCreator a LEFT OUTER JOIN ReportMaster b ON a.ReportID = b.ReportID WHERE b.Activate = 'Y'
UNION ALL
SELECT	a.ReportID,
	0 AS ReportNo,
	a.Department AS ReportTitle 
FROM ReportMaster a WHERE a.Activate = 'Y'
