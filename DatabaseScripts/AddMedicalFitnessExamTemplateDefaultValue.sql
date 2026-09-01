SET NOCOUNT ON;
SET XACT_ABORT ON;

IF OBJECT_ID(N'dbo.MedicalFitnessReportExamTemplate', N'U') IS NULL
    THROW 50000, 'dbo.MedicalFitnessReportExamTemplate must exist before updating medical fitness templates.', 1;

BEGIN TRANSACTION;

IF COL_LENGTH(N'dbo.MedicalFitnessReportExamTemplate', N'DefaultValue') IS NULL
BEGIN
    ALTER TABLE dbo.MedicalFitnessReportExamTemplate
        ADD [DefaultValue] NVARCHAR(255) NULL;
END;

IF COL_LENGTH(N'dbo.MedicalFitnessReportExamTemplate', N'SectionCode') IS NULL
BEGIN
    ALTER TABLE dbo.MedicalFitnessReportExamTemplate
        ADD [SectionCode] VARCHAR(20) NOT NULL
            CONSTRAINT [DF_MedicalFitnessReportExamTemplate_SectionCode] DEFAULT ('CLINICAL');
END;

IF NOT EXISTS (
    SELECT 1
    FROM sys.check_constraints
    WHERE parent_object_id = OBJECT_ID(N'dbo.MedicalFitnessReportExamTemplate')
      AND name = N'CK_MedicalFitnessReportExamTemplate_SectionCode')
BEGIN
    EXEC(N'ALTER TABLE dbo.MedicalFitnessReportExamTemplate
        ADD CONSTRAINT [CK_MedicalFitnessReportExamTemplate_SectionCode]
        CHECK ([SectionCode] IN (''CLINICAL'', ''XRAY''));');
END;

EXEC(N'UPDATE dbo.MedicalFitnessReportExamTemplate
       SET SectionCode = ''XRAY''
       WHERE UPPER(TestCode) IN (''CHEST_XRAY'', ''XRAY'')
         AND SectionCode <> ''XRAY'';');

COMMIT TRANSACTION;
