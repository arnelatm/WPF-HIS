IF COL_LENGTH(N'dbo.MedicalFitnessReportLabTemplate', N'TranslationConfidence') IS NULL
BEGIN
    ALTER TABLE dbo.MedicalFitnessReportLabTemplate
        ADD TranslationConfidence NVARCHAR(20) NULL;
END;
GO
