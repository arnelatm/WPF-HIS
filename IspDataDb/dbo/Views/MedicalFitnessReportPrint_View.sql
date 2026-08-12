CREATE VIEW [dbo].[MedicalFitnessReportPrint_View]
AS
SELECT
    h.IdNo,
    h.InvoiceNo,
    h.InvoiceDate,
    h.FileNo,
    h.PatientName,
    h.Gender,
    h.Age,
    h.Nationality,
    h.IdentityNo,
    h.DoctorName,
    h.BloodType,
    h.FinalResultStatus,
    h.Remarks AS HeaderRemarks,
    d.SectionCode,
    d.TestCode,
    d.TestNameEnglish,
    d.TestNameArabic,
    d.DisplayOrder,
    d.[Sequence],
    d.ResultStatus,
    d.ResultText,
    d.LabResult,
    d.LabReferenceValue,
    d.LabUnit,
    d.LabAssessment,
    d.ResultStatusSource,
    d.Remarks AS DetailRemarks
FROM dbo.MedicalFitnessReport h
LEFT JOIN dbo.MedicalFitnessReportTestResult d
    ON d.MedicalFitnessReportIdNo = h.IdNo;
