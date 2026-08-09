SET NOCOUNT ON;
SET XACT_ABORT ON;

DECLARE @ArabicLanguageIdNo smallint =
(
    SELECT TOP (1) IdNo
    FROM Languages
    WHERE CultureInfoCode = 'ar-SA'
);

IF @ArabicLanguageIdNo IS NULL
    THROW 50001, 'The ar-SA language is not configured.', 1;

DECLARE @Translations TABLE
(
    Caption nvarchar(255) NOT NULL PRIMARY KEY,
    ArabicCaption nvarchar(255) NOT NULL
);

INSERT INTO @Translations (Caption, ArabicCaption)
VALUES
    (N'Add New Dosage', N'إضافة جرعة جديدة'),
    (N'All', N'الكل'),
    (N'Approve Selected Order', N'اعتماد الطلب المحدد'),
    (N'Auto Fillup unfilled Items', N'تعبئة العناصر الفارغة تلقائياً'),
    (N'Check Printer', N'طباعة الشيكات'),
    (N'Clear Entry', N'مسح المدخلات'),
    (N'Clear the Image', N'مسح الصورة'),
    (N'Clear Values', N'مسح القيم'),
    (N'Enter Employee Absences/ Lates', N'إدخال غياب وتأخر الموظفين'),
    (N'Enter Employee Holiday Leaves', N'إدخال إجازات العطلات للموظفين'),
    (N'Enter Employee Non Holiday Leaves', N'إدخال إجازات غير العطلات للموظفين'),
    (N'Generate', N'إنشاء'),
    (N'Generate Employee Earnings / Deductions', N'إنشاء مستحقات / استقطاعات الموظفين'),
    (N'Initialize Attendance', N'تهيئة الحضور'),
    (N'Initialize Overtime', N'تهيئة العمل الإضافي'),
    (N'Match Displayed Items', N'مطابقة العناصر المعروضة'),
    (N'No', N'لا'),
    (N'Post Inventory Transaction', N'ترحيل حركة المخزون'),
    (N'Post Payroll', N'ترحيل مسير الرواتب'),
    (N'Post Purchase', N'ترحيل المشتريات'),
    (N'Print Dosage Labels for Selected Medicines', N'طباعة ملصقات الجرعات للأدوية المحددة'),
    (N'Print Medicine Dosage Labels', N'طباعة ملصقات جرعات الأدوية'),
    (N'Refresh', N'تحديث'),
    (N'Retrieve', N'استرجاع'),
    (N'Retrieve CBC Results', N'استرجاع نتائج تعداد الدم الكامل'),
    (N'Save Data', N'حفظ البيانات'),
    (N'Select All', N'تحديد الكل'),
    (N'Select New Image', N'اختيار صورة جديدة'),
    (N'Set as default', N'تعيين كافتراضي'),
    (N'Supply Requested Quantity', N'توفير الكمية المطلوبة'),
    (N'Transfer CBC Results', N'نقل نتائج تعداد الدم الكامل'),
    (N'Transfer Selected Request', N'نقل الطلب المحدد'),
    (N'Unselect All', N'إلغاء تحديد الكل'),
    (N'Update Name from File', N'تحديث الاسم من الملف'),
    (N'Validate Entry', N'التحقق من الإدخال'),
    (N'View/Edit Payroll Details', N'عرض/تعديل تفاصيل مسير الرواتب');

BEGIN TRANSACTION;

INSERT INTO TranslatedCaption (CaptionIdNo, LanguageIdNo, TranslatedCaption)
SELECT original.IdNo, @ArabicLanguageIdNo, translation.ArabicCaption
FROM @Translations AS translation
INNER JOIN OriginalCaptions AS original
    ON LTRIM(RTRIM(original.Caption)) COLLATE Arabic_CI_AS = translation.Caption COLLATE Arabic_CI_AS
WHERE NOT EXISTS
(
    SELECT 1
    FROM TranslatedCaption AS existing
    WHERE existing.CaptionIdNo = original.IdNo
      AND existing.LanguageIdNo = @ArabicLanguageIdNo
);

DECLARE @InsertedCount int = @@ROWCOUNT;

COMMIT TRANSACTION;

SELECT @InsertedCount AS InsertedTranslationCount;

SELECT translation.Caption AS MissingOriginalCaption
FROM @Translations AS translation
WHERE NOT EXISTS
(
    SELECT 1
    FROM OriginalCaptions AS original
    WHERE LTRIM(RTRIM(original.Caption)) COLLATE Arabic_CI_AS = translation.Caption COLLATE Arabic_CI_AS
)
ORDER BY translation.Caption;
