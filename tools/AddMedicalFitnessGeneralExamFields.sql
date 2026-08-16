SET NOCOUNT ON;
SET XACT_ABORT ON;

BEGIN TRANSACTION;

IF COL_LENGTH('dbo.MedicalFitnessReport', 'CompanyName') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD CompanyName NVARCHAR(255) NULL;
IF COL_LENGTH('dbo.MedicalFitnessReport', 'PassportNo') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD PassportNo NVARCHAR(100) NULL;
IF COL_LENGTH('dbo.MedicalFitnessReport', 'ExamTemperature') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD ExamTemperature NVARCHAR(255) NULL;
IF COL_LENGTH('dbo.MedicalFitnessReport', 'ExamBloodPressure') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD ExamBloodPressure NVARCHAR(255) NULL;
IF COL_LENGTH('dbo.MedicalFitnessReport', 'ExamPulse') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD ExamPulse NVARCHAR(255) NULL;
IF COL_LENGTH('dbo.MedicalFitnessReport', 'ExamRespiratorySystem') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD ExamRespiratorySystem NVARCHAR(255) NULL;
IF COL_LENGTH('dbo.MedicalFitnessReport', 'ExamCardiovascularSystem') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD ExamCardiovascularSystem NVARCHAR(255) NULL;
IF COL_LENGTH('dbo.MedicalFitnessReport', 'ExamNervousSystem') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD ExamNervousSystem NVARCHAR(255) NULL;
IF COL_LENGTH('dbo.MedicalFitnessReport', 'ExamAbdomen') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD ExamAbdomen NVARCHAR(255) NULL;
IF COL_LENGTH('dbo.MedicalFitnessReport', 'ExamWeight') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD ExamWeight NVARCHAR(255) NULL;
IF COL_LENGTH('dbo.MedicalFitnessReport', 'ExamHeight') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD ExamHeight NVARCHAR(255) NULL;
IF COL_LENGTH('dbo.MedicalFitnessReport', 'ExamExtremities') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD ExamExtremities NVARCHAR(255) NULL;
IF COL_LENGTH('dbo.MedicalFitnessReport', 'ExamChestXRay') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD ExamChestXRay NVARCHAR(255) NULL;
IF COL_LENGTH('dbo.MedicalFitnessReport', 'ExamRightEye') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD ExamRightEye NVARCHAR(255) NULL;
IF COL_LENGTH('dbo.MedicalFitnessReport', 'ExamLeftEye') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD ExamLeftEye NVARCHAR(255) NULL;
IF COL_LENGTH('dbo.MedicalFitnessReport', 'ExamRightEar') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD ExamRightEar NVARCHAR(255) NULL;
IF COL_LENGTH('dbo.MedicalFitnessReport', 'ExamLeftEar') IS NULL
    ALTER TABLE dbo.MedicalFitnessReport ADD ExamLeftEar NVARCHAR(255) NULL;

UPDATE dbo.MedicalFitnessReportTestResult
SET SectionCode = CASE UPPER(LTRIM(RTRIM(TestCode)))
    WHEN 'ECG' THEN 'DETAIL'
    WHEN 'AUDIOMETRY' THEN 'DETAIL'
    WHEN 'SPIROMETRY' THEN 'DETAIL'
    ELSE CASE WHEN DisplayOrder >= 200 THEN 'LAB' ELSE 'GENERAL' END
END
WHERE NULLIF(LTRIM(RTRIM(SectionCode)), '') IS NULL;

UPDATE dbo.MedicalFitnessReportTestResult
SET SectionCode = 'DETAIL'
WHERE UPPER(LTRIM(RTRIM(TestCode))) IN ('ECG', 'AUDIOMETRY', 'SPIROMETRY');

EXEC(N'
ALTER VIEW dbo.MedicalFitnessReportPrint_View
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
');

COMMIT TRANSACTION;

SELECT
    COL_LENGTH('dbo.MedicalFitnessReport', 'ExamTemperature') AS ExamFieldCheck,
    (SELECT COUNT(*) FROM dbo.MedicalFitnessReport) AS RemainingMedicalFitnessReports,
    (SELECT COUNT(*) FROM dbo.MedicalFitnessReportTestResult) AS RemainingMedicalFitnessDetails;
