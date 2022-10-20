CREATE VIEW IBSamplePrinting_View
 
AS
Select a.*,
        b.LabReportNo as SampleNo,
		b.TakenBy,
		b.TakenDate,
		b.TakenTime
From IBInvoice_View  a
left outer join IBLabSampleTaken b on a.Trans_Key  = b.Trans_Key