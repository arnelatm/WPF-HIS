-- Apply to the confirmed ISPDATA target only after backup and restored-test validation.
-- Deploy with the matching Accounts build. No existing names/results are rewritten.
SET NOCOUNT ON;
SET XACT_ABORT ON;

IF OBJECT_ID(N'dbo.MedicalFitnessReportFormatItem', N'U') IS NULL
    THROW 50000, 'MedicalFitnessReportFormatItem must exist before adding name overrides.', 1;

BEGIN TRY
    BEGIN TRANSACTION;

    IF COL_LENGTH(N'dbo.MedicalFitnessReportFormatItem', N'EnglishNameOverride') IS NULL
        ALTER TABLE dbo.MedicalFitnessReportFormatItem ADD EnglishNameOverride NVARCHAR(255) NULL;
    IF COL_LENGTH(N'dbo.MedicalFitnessReportFormatItem', N'ArabicNameOverride') IS NULL
        ALTER TABLE dbo.MedicalFitnessReportFormatItem ADD ArabicNameOverride NVARCHAR(255) NULL;

    -- View definition copied from the authoritative SQL project object.
    EXEC(N'ALTER VIEW dbo.MedicalFitnessReportPrint_View
AS
SELECT
    h.IdNo,
    h.InvoiceNo,
    h.ReportFormat,
    h.MedicalReportFormatIdNo,
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
    COALESCE(NULLIF(LTRIM(RTRIM(fi.EnglishNameOverride)), N''''),
             t.TestNameEnglish, d.TestNameEnglish) AS TestNameEnglish,
    COALESCE(NULLIF(LTRIM(RTRIM(fi.ArabicNameOverride)), N''''),
             t.TestNameArabic, d.TestNameArabic) AS TestNameArabic,
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
    ON d.MedicalFitnessReportIdNo = h.IdNo
LEFT JOIN dbo.MedicalFitnessReportFormat f
    ON f.MRIdNo = h.MedicalReportFormatIdNo
    OR (ISNULL(h.MedicalReportFormatIdNo, 0) = 0 AND f.FormatCode = h.ReportFormat)
LEFT JOIN dbo.MedicalFitnessReportExamTemplate t
    ON t.TestCode = d.TestCode
    AND UPPER(LTRIM(RTRIM(d.SectionCode))) IN (''CLINICAL'', ''XRAY'', ''DETAIL'')
LEFT JOIN dbo.MedicalFitnessReportFormatItem fi
    ON fi.MRIdNo = f.MRIdNo AND fi.ExamTemplateIdNo = t.IdNo AND fi.Active = 1;');

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;
