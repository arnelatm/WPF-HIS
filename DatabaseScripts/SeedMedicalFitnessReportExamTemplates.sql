SET NOCOUNT ON;
SET XACT_ABORT ON;

BEGIN TRANSACTION;

IF OBJECT_ID(N'dbo.MedicalFitnessReportExamTemplate', N'U') IS NULL
    THROW 50000, 'dbo.MedicalFitnessReportExamTemplate must exist before seeding.', 1;

INSERT INTO dbo.MedicalFitnessReportExamTemplate
    (TestCode, TestNameEnglish, TestNameArabic, Unit, DisplayOrder, InputMode, IsRequired, Active)
SELECT source.TestCode,
       source.TestNameEnglish,
       source.TestNameArabic,
       source.Unit,
       source.DisplayOrder,
       source.InputMode,
       source.IsRequired,
       source.Active
FROM (VALUES
    ('TEMPERATURE', 'Temperature', N'درجة الحرارة', N'°C', 10, 'TEXT', 0, 1),
    ('BLOOD_PRESSURE', 'Blood Pressure', N'ضغط الدم', NULL, 20, 'TEXT', 0, 1),
    ('PULSE', 'Pulse', N'النبض', NULL, 30, 'TEXT', 0, 1),
    ('RESPIRATORY_SYSTEM', 'Respiratory System', N'الجهاز التنفسي', NULL, 40, 'FIT_UNFIT', 0, 1),
    ('CARDIOVASCULAR_SYSTEM', 'Chest / Heart', N'فحص القلب والصدر', NULL, 50, 'FIT_UNFIT', 0, 1),
    ('ABDOMEN_DERMATOLOGICAL', 'Abdomen / Dermatological', N'البطن / الأمراض الجلدية', NULL, 60, 'FIT_UNFIT', 0, 1),
    ('NEUROLOGICAL_DISORDER', 'Neurological Disorder', N'الاضطرابات العصبية', NULL, 70, 'FIT_UNFIT', 0, 1),
    ('PHYSICAL_DISABILITY', 'Physical Disability', N'الإعاقة الجسدية', NULL, 80, 'FIT_UNFIT', 0, 1),
    ('WEIGHT', 'Weight', N'الوزن', N'kg', 90, 'NUMBER', 0, 1),
    ('HEIGHT', 'Height', N'الطول', N'cm', 100, 'NUMBER', 0, 1),
    ('CHEST_XRAY', 'Chest X-ray', N'الأشعة الصدرية', NULL, 110, 'FIT_UNFIT', 0, 1),
    ('RIGHT_EYE', 'Right Eye', N'العين اليمنى', NULL, 120, 'FIT_UNFIT', 0, 1),
    ('LEFT_EYE', 'Left Eye', N'العين اليسرى', NULL, 130, 'FIT_UNFIT', 0, 1),
    ('RIGHT_EAR', 'Right Ear', N'الأذن اليمنى', NULL, 140, 'FIT_UNFIT', 0, 1),
    ('LEFT_EAR', 'Left Ear', N'الأذن اليسرى', NULL, 150, 'FIT_UNFIT', 0, 1)
) AS source(TestCode, TestNameEnglish, TestNameArabic, Unit, DisplayOrder, InputMode, IsRequired, Active)
WHERE NOT EXISTS (
    SELECT 1
    FROM dbo.MedicalFitnessReportExamTemplate target
    WHERE target.TestCode = source.TestCode);

UPDATE dbo.MedicalFitnessReportExamTemplate
SET SectionCode = 'XRAY'
WHERE UPPER(TestCode) IN ('CHEST_XRAY', 'XRAY')
  AND SectionCode <> 'XRAY';

INSERT INTO dbo.MedicalFitnessReportExamTemplate
    (SectionCode, TestCode, TestNameEnglish, TestNameArabic, Unit, DefaultValue,
     DisplayOrder, InputMode, IsRequired, Active)
SELECT source.SectionCode, source.TestCode, source.TestNameEnglish, source.TestNameArabic,
       NULL, NULL, source.DisplayOrder, 'FIT_UNFIT', 0, 1
FROM (VALUES
    ('XRAY', 'ECG', 'ECG', N'رسم القلب', 110),
    ('XRAY', 'AUDIOMETRY', 'Audiometry', N'قياس السمع', 120),
    ('XRAY', 'SPIROMETRY', 'Spirometry', N'قياس التنفس', 130)
) AS source(SectionCode, TestCode, TestNameEnglish, TestNameArabic, DisplayOrder)
WHERE NOT EXISTS (
    SELECT 1 FROM dbo.MedicalFitnessReportExamTemplate target
    WHERE target.TestCode = source.TestCode);

UPDATE dbo.MedicalFitnessReportExamTemplate
SET SectionCode = 'XRAY'
WHERE UPPER(TestCode) IN ('CHEST_XRAY', 'XRAY', 'ECG', 'AUDIOMETRY', 'SPIROMETRY')
  AND SectionCode <> 'XRAY';

COMMIT TRANSACTION;
