
CREATE VIEW dbo.MedicalFitnessReportPrint_View
AS
SELECT
    h.IdNo,
    h.InvoiceNo,
    h.InvoiceDate,
    h.FileNo,
    h.PatientName,
    h.CompanyName,
    h.PassportNo,
    h.Gender,
    h.Age,
    h.Nationality,
    h.IdentityNo,
    h.DoctorName,
    h.BloodType,
    h.ExamTemperature,
    h.ExamBloodPressure,
    h.ExamPulse,
    h.ExamRespiratorySystem,
    h.ExamCardiovascularSystem,
    h.ExamNervousSystem,
    h.ExamAbdomen,
    h.ExamWeight,
    h.ExamHeight,
    h.ExamExtremities,
    h.ExamChestXRay,
    h.ExamRightEye,
    h.ExamLeftEye,
    h.ExamRightEar,
    h.ExamLeftEar,
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

GO

