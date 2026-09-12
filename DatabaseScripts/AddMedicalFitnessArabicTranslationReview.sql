/* Adds the review marker used for Arabic lab-template translations. */
SET XACT_ABORT ON;
BEGIN TRY
    BEGIN TRANSACTION;
    IF COL_LENGTH(N'dbo.MedicalFitnessReportLabTemplate', N'ArabicTranslationReview') IS NULL
        ALTER TABLE dbo.MedicalFitnessReportLabTemplate
            ADD ArabicTranslationReview BIT NOT NULL
                CONSTRAINT DF_MedicalFitnessReportLabTemplate_ArabicTranslationReview DEFAULT (1);
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;
