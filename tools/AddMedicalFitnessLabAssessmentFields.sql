SET XACT_ABORT ON;
GO

IF COL_LENGTH(N'dbo.MedicalFitnessReportTestResult', N'LabResult') IS NULL
    ALTER TABLE dbo.MedicalFitnessReportTestResult ADD LabResult NVARCHAR(MAX) NULL;

IF COL_LENGTH(N'dbo.MedicalFitnessReportTestResult', N'LabReferenceValue') IS NULL
    ALTER TABLE dbo.MedicalFitnessReportTestResult ADD LabReferenceValue NVARCHAR(MAX) NULL;

IF COL_LENGTH(N'dbo.MedicalFitnessReportTestResult', N'LabUnit') IS NULL
    ALTER TABLE dbo.MedicalFitnessReportTestResult ADD LabUnit NVARCHAR(100) NULL;

IF COL_LENGTH(N'dbo.MedicalFitnessReportTestResult', N'LabAssessment') IS NULL
    ALTER TABLE dbo.MedicalFitnessReportTestResult ADD LabAssessment VARCHAR(30) NULL;

IF COL_LENGTH(N'dbo.MedicalFitnessReportTestResult', N'ResultStatusSource') IS NULL
    ALTER TABLE dbo.MedicalFitnessReportTestResult ADD ResultStatusSource CHAR(1) NULL;
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.check_constraints
    WHERE [name] = N'CK_MedicalFitnessReportTestResult_ResultStatusSource'
      AND parent_object_id = OBJECT_ID(N'dbo.MedicalFitnessReportTestResult'))
BEGIN
    ALTER TABLE dbo.MedicalFitnessReportTestResult WITH CHECK
        ADD CONSTRAINT CK_MedicalFitnessReportTestResult_ResultStatusSource
        CHECK (ResultStatusSource IS NULL OR ResultStatusSource IN ('A', 'M'));
END;
GO

ALTER VIEW dbo.MedicalFitnessReportPrint_View
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
GO
