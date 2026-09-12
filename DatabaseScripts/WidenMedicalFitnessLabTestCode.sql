/*
    Preserve full Kizen VisitAnalysesResult.Code values (nvarchar(255)).
    The glucose code for the reported failure is 60 characters; varchar(50)
    rejects it. Do not shorten codes: they identify results during refresh.

    Apply only to the explicitly approved ISPDATA target after a backup and
    verification on a restored test database. This script changes no results.
    The Accounts save fix should be deployed with this schema change.
*/
SET XACT_ABORT ON;

BEGIN TRY
    BEGIN TRANSACTION;

    IF OBJECT_ID(N'dbo.MedicalFitnessReportTestResult', N'U') IS NULL
       OR OBJECT_ID(N'dbo.MedicalFitnessReportLabTemplate', N'U') IS NULL
        THROW 50001, 'Required medical fitness tables are missing. Verify the target database.', 1;

    -- Refuse unexpected definitions instead of shrinking a wider deployment.
    IF EXISTS (
        SELECT 1 FROM sys.columns c
        WHERE c.object_id IN (OBJECT_ID(N'dbo.MedicalFitnessReportTestResult'),
                              OBJECT_ID(N'dbo.MedicalFitnessReportLabTemplate'))
          AND c.name = N'TestCode'
          AND (c.is_nullable = 1 OR NOT (
              (TYPE_NAME(c.system_type_id) = N'varchar' AND c.max_length BETWEEN 1 AND 255)
              OR (TYPE_NAME(c.system_type_id) = N'nvarchar' AND c.max_length BETWEEN 2 AND 510))))
        THROW 50002, 'Unexpected TestCode definition. Review the schema before applying this change.', 1;

    IF EXISTS (SELECT 1 FROM sys.columns
               WHERE object_id = OBJECT_ID(N'dbo.MedicalFitnessReportTestResult')
                 AND name = N'TestCode'
                 AND (TYPE_NAME(system_type_id) <> N'nvarchar' OR max_length <> 510))
        ALTER TABLE dbo.MedicalFitnessReportTestResult ALTER COLUMN TestCode NVARCHAR(255) NOT NULL;

    IF EXISTS (SELECT 1 FROM sys.columns
               WHERE object_id = OBJECT_ID(N'dbo.MedicalFitnessReportLabTemplate')
                 AND name = N'TestCode'
                 AND (TYPE_NAME(system_type_id) <> N'nvarchar' OR max_length <> 510))
    BEGIN
        -- Rebuild the dependent unique constraint within the same transaction.
        ALTER TABLE dbo.MedicalFitnessReportLabTemplate
            DROP CONSTRAINT UQ_MedicalFitnessReportLabTemplate_TestCode;
        ALTER TABLE dbo.MedicalFitnessReportLabTemplate ALTER COLUMN TestCode NVARCHAR(255) NOT NULL;
        ALTER TABLE dbo.MedicalFitnessReportLabTemplate
            ADD CONSTRAINT UQ_MedicalFitnessReportLabTemplate_TestCode UNIQUE NONCLUSTERED (TestCode);
    END;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;
