/*
    Adds configurable Kizen laboratory-result behavior to the existing
    MedicalFitnessReportLabTemplate master.

    Run this script once on the target ISPDATA database after taking the
    normal database backup. It is intentionally idempotent and does not
    change existing laboratory template rows.
*/
IF COL_LENGTH('dbo.MedicalFitnessReportLabTemplate', 'EnglishNameOverride') IS NULL
BEGIN
    ALTER TABLE dbo.MedicalFitnessReportLabTemplate
        ADD EnglishNameOverride NVARCHAR(255) NULL;
END;

IF COL_LENGTH('dbo.MedicalFitnessReportLabTemplate', 'ArabicNameOverride') IS NULL
BEGIN
    ALTER TABLE dbo.MedicalFitnessReportLabTemplate
        ADD ArabicNameOverride NVARCHAR(255) NULL;
END;

IF COL_LENGTH('dbo.MedicalFitnessReportLabTemplate', 'CopyResultToEntry') IS NULL
BEGIN
    ALTER TABLE dbo.MedicalFitnessReportLabTemplate
        ADD CopyResultToEntry BIT NOT NULL
            CONSTRAINT DF_MedicalFitnessReportLabTemplate_CopyResultToEntry DEFAULT (0);
END;
