/*
    Adds database-driven medical report formats and their item/company mappings.
    Safe to run repeatedly. Execute first against the intended test database.
*/
SET NOCOUNT ON;
SET XACT_ABORT ON;

IF OBJECT_ID(N'dbo.MedicalFitnessReport', N'U') IS NULL
    THROW 50000, 'dbo.MedicalFitnessReport must exist before adding report formats.', 1;

IF OBJECT_ID(N'dbo.MedicalFitnessReportExamTemplate', N'U') IS NULL
    THROW 50000, 'dbo.MedicalFitnessReportExamTemplate must exist before adding report formats.', 1;

IF COL_LENGTH(N'dbo.MedicalFitnessReport', N'ReportFormat') IS NULL
BEGIN
    ALTER TABLE dbo.MedicalFitnessReport
        ADD ReportFormat VARCHAR(50) NOT NULL
            CONSTRAINT [DF_MedicalFitnessReport_ReportFormat] DEFAULT ('STANDARD') WITH VALUES;
END;

IF COL_LENGTH(N'dbo.MedicalFitnessReport', N'ReportFormat') IS NOT NULL
BEGIN
    ALTER TABLE dbo.MedicalFitnessReport ALTER COLUMN ReportFormat VARCHAR(50) NOT NULL;
END;

IF COL_LENGTH(N'dbo.MedicalFitnessReport', N'MedicalReportFormatIdNo') IS NULL
BEGIN
    ALTER TABLE dbo.MedicalFitnessReport
        ADD MedicalReportFormatIdNo INT NULL;
END;

IF EXISTS (
    SELECT 1 FROM sys.check_constraints
    WHERE parent_object_id = OBJECT_ID(N'dbo.MedicalFitnessReport')
      AND name = N'CK_MedicalFitnessReport_ReportFormat')
BEGIN
    ALTER TABLE dbo.MedicalFitnessReport DROP CONSTRAINT CK_MedicalFitnessReport_ReportFormat;
END;

EXEC(N'UPDATE dbo.MedicalFitnessReport SET ReportFormat = ''STANDARD''
       WHERE ReportFormat IS NULL OR NULLIF(LTRIM(RTRIM(ReportFormat)), '''') IS NULL;');

IF OBJECT_ID(N'dbo.MedicalFitnessReportFormat', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.MedicalFitnessReportFormat (
        MRIdNo INT IDENTITY(1,1) NOT NULL,
        FormatCode VARCHAR(50) NOT NULL,
        TitleEnglish NVARCHAR(255) NOT NULL,
        TitleArabic NVARCHAR(255) NULL,
        CrystalReportFileName NVARCHAR(255) NOT NULL,
        Active BIT NOT NULL CONSTRAINT DF_MedicalFitnessReportFormat_Active DEFAULT (1),
        DisplayOrder INT NOT NULL CONSTRAINT DF_MedicalFitnessReportFormat_DisplayOrder DEFAULT (10),
        IsDefault BIT NOT NULL CONSTRAINT DF_MedicalFitnessReportFormat_IsDefault DEFAULT (0),
        CONSTRAINT PK_MedicalFitnessReportFormat PRIMARY KEY CLUSTERED (MRIdNo),
        CONSTRAINT UQ_MedicalFitnessReportFormat_FormatCode UNIQUE (FormatCode)
    );
END;

IF OBJECT_ID(N'dbo.MedicalFitnessReportFormatItem', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.MedicalFitnessReportFormatItem (
        IdNo INT IDENTITY(1,1) NOT NULL,
        MRIdNo INT NOT NULL,
        ExamTemplateIdNo INT NOT NULL,
        SectionCode VARCHAR(20) NOT NULL,
        DisplayOrder INT NULL,
        DefaultValue NVARCHAR(255) NULL,
        InputMode VARCHAR(20) NULL,
        IsRequired BIT NULL,
        Active BIT NOT NULL CONSTRAINT DF_MedicalFitnessReportFormatItem_Active DEFAULT (1),
        CONSTRAINT PK_MedicalFitnessReportFormatItem PRIMARY KEY CLUSTERED (IdNo),
        CONSTRAINT UQ_MedicalFitnessReportFormatItem_FormatTemplate UNIQUE (MRIdNo, ExamTemplateIdNo),
        CONSTRAINT FK_MedicalFitnessReportFormatItem_Format FOREIGN KEY (MRIdNo)
            REFERENCES dbo.MedicalFitnessReportFormat (MRIdNo),
        CONSTRAINT FK_MedicalFitnessReportFormatItem_Template FOREIGN KEY (ExamTemplateIdNo)
            REFERENCES dbo.MedicalFitnessReportExamTemplate (IdNo),
        CONSTRAINT CK_MedicalFitnessReportFormatItem_SectionCode CHECK (SectionCode IN ('CLINICAL', 'XRAY')),
        CONSTRAINT CK_MedicalFitnessReportFormatItem_InputMode CHECK
            (InputMode IS NULL OR InputMode IN ('FIT_UNFIT', 'TEXT', 'NUMBER'))
    );
END;

IF OBJECT_ID(N'dbo.MedicalFitnessReportFormatAssignment', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.MedicalFitnessReportFormatAssignment (
        IdNo INT IDENTITY(1,1) NOT NULL,
        CompanyName NVARCHAR(255) NOT NULL,
        MRIdNo INT NOT NULL,
        Active BIT NOT NULL CONSTRAINT DF_MedicalFitnessReportFormatAssignment_Active DEFAULT (1),
        CONSTRAINT PK_MedicalFitnessReportFormatAssignment PRIMARY KEY CLUSTERED (IdNo),
        CONSTRAINT UQ_MedicalFitnessReportFormatAssignment_Company UNIQUE (CompanyName),
        CONSTRAINT FK_MedicalFitnessReportFormatAssignment_Format FOREIGN KEY (MRIdNo)
            REFERENCES dbo.MedicalFitnessReportFormat (MRIdNo)
    );
END;

IF NOT EXISTS (
    SELECT 1 FROM sys.foreign_keys
    WHERE name = N'FK_MedicalFitnessReport_Format'
      AND parent_object_id = OBJECT_ID(N'dbo.MedicalFitnessReport'))
BEGIN
    ALTER TABLE dbo.MedicalFitnessReport
        ADD CONSTRAINT FK_MedicalFitnessReport_Format
        FOREIGN KEY (MedicalReportFormatIdNo)
        REFERENCES dbo.MedicalFitnessReportFormat (MRIdNo);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.MedicalFitnessReportFormat WHERE FormatCode = 'LEGACY')
BEGIN
    INSERT dbo.MedicalFitnessReportFormat
        (FormatCode, TitleEnglish, TitleArabic, CrystalReportFileName, Active, DisplayOrder, IsDefault)
    VALUES ('LEGACY', N'Medical Report - Legacy', N'التقرير الطبي - القديم',
            N'Medical Fitness Legacy.rpt', 1, 10, 0);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.MedicalFitnessReportFormat WHERE FormatCode = 'STANDARD')
BEGIN
    INSERT dbo.MedicalFitnessReportFormat
        (FormatCode, TitleEnglish, TitleArabic, CrystalReportFileName, Active, DisplayOrder, IsDefault)
    VALUES ('STANDARD', N'Medical Report - Standard', N'التقرير الطبي - القياسي',
            N'Medical Fitness Report.rpt', 1, 20, 1);
END;

IF NOT EXISTS (SELECT 1 FROM dbo.MedicalFitnessReportFormat WHERE Active = 1 AND IsDefault = 1)
    UPDATE dbo.MedicalFitnessReportFormat
       SET IsDefault = CASE WHEN FormatCode = 'STANDARD' THEN 1 ELSE 0 END;

/* ECG, audiometry, and spirometry are configurable XRay/examination rows too. */
INSERT dbo.MedicalFitnessReportExamTemplate
    (SectionCode, TestCode, TestNameEnglish, TestNameArabic, Unit, DefaultValue,
     DisplayOrder, InputMode, IsRequired, Active)
SELECT 'XRAY', source.TestCode, source.TestNameEnglish, source.TestNameArabic, NULL, NULL,
       source.DisplayOrder, 'FIT_UNFIT', 0, 1
FROM (VALUES
    ('ECG', 'ECG', N'رسم القلب', 110),
    ('AUDIOMETRY', 'Audiometry', N'قياس السمع', 120),
    ('SPIROMETRY', 'Spirometry', N'قياس التنفس', 130)
) AS source(TestCode, TestNameEnglish, TestNameArabic, DisplayOrder)
WHERE NOT EXISTS (SELECT 1 FROM dbo.MedicalFitnessReportExamTemplate t
                  WHERE t.TestCode = source.TestCode);

UPDATE dbo.MedicalFitnessReportExamTemplate
   SET SectionCode = 'XRAY'
 WHERE TestCode IN ('CHEST_XRAY', 'XRAY', 'ECG', 'AUDIOMETRY', 'SPIROMETRY')
   AND SectionCode <> 'XRAY';

INSERT dbo.MedicalFitnessReportFormatItem
    (MRIdNo, ExamTemplateIdNo, SectionCode, DisplayOrder, DefaultValue, InputMode, IsRequired, Active)
SELECT f.MRIdNo, t.IdNo, t.SectionCode, t.DisplayOrder, t.DefaultValue, t.InputMode, t.IsRequired, t.Active
FROM dbo.MedicalFitnessReportFormat f
CROSS JOIN dbo.MedicalFitnessReportExamTemplate t
WHERE f.FormatCode IN ('LEGACY', 'STANDARD')
  AND NOT EXISTS (SELECT 1 FROM dbo.MedicalFitnessReportFormatItem i
                  WHERE i.MRIdNo = f.MRIdNo AND i.ExamTemplateIdNo = t.IdNo);

EXEC(N'UPDATE r SET MedicalReportFormatIdNo = f.MRIdNo
       FROM dbo.MedicalFitnessReport r
       INNER JOIN dbo.MedicalFitnessReportFormat f
               ON f.FormatCode = CASE WHEN r.ReportFormat = ''LEGACY'' THEN ''LEGACY'' ELSE ''STANDARD'' END
      WHERE r.MedicalReportFormatIdNo IS NULL;');

SELECT MRIdNo, FormatCode, CrystalReportFileName, Active, IsDefault
FROM dbo.MedicalFitnessReportFormat ORDER BY DisplayOrder, MRIdNo;

SELECT FormatCode, COUNT(i.IdNo) AS ItemCount
FROM dbo.MedicalFitnessReportFormat f
LEFT JOIN dbo.MedicalFitnessReportFormatItem i ON i.MRIdNo = f.MRIdNo AND i.Active = 1
GROUP BY FormatCode;
