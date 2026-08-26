/*
    Arabic captions for the reconciliation workflow and MainForm menus.

    This is application data, not schema, so it is intentionally kept out of
    the DACPAC.  Run it after a database backup, first on a restored test
    database and then on the approved live database.

    The script is idempotent.  Existing non-blank Arabic translations are
    preserved, except for the three explicitly listed duplicate menu captions
    that are normalized to one canonical Arabic value.
*/
SET NOCOUNT ON;
SET XACT_ABORT ON;

DECLARE @LanguageIdNo SMALLINT =
(
    SELECT TOP (1) IdNo
    FROM dbo.Languages
    WHERE CultureInfoCode = 'ar-SA'
);

IF @LanguageIdNo IS NULL
    THROW 51010, 'Language ar-SA was not found in dbo.Languages.', 1;

DECLARE @Captions TABLE
(
    Caption NVARCHAR(1024) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL PRIMARY KEY,
    TranslatedCaption NVARCHAR(256) NOT NULL
);

INSERT INTO @Captions (Caption, TranslatedCaption)
VALUES
    (N'Account Reconciliation', N'تسوية الحسابات'),
    (N'Clear All', N'مسح الكل'),
    (N'Complete Review', N'إكمال المراجعة'),
    (N'Finalize', N'اعتماد نهائي'),
    (N'Post', N'ترحيل'),
    (N'Reopen Review', N'إعادة فتح المراجعة'),
    (N'Un-clear all', N'إلغاء تحديد الكل'),
    (N'&File', N'ملف'),
    (N'&Edit', N'تعديل'),
    (N'&Masters', N'الرئيسية'),
    (N'&Transactions', N'العمليات'),
    (N'Reports', N'التقارير'),
    (N'Utilities', N'الأدوات'),
    (N'&Help', N'مساعدة'),
    (N'&Add New', N'إضافة جديد'),
    (N'Accounting Closing', N'إقفال الحسابات'),
    (N'Accounting Reports', N'تقارير المحاسبة'),
    (N'Add New Member...', N'إضافة عضو جديد...'),
    (N'Application Setting', N'إعدادات التطبيق'),
    (N'Attendance Reports', N'تقارير الحضور'),
    (N'Baladiya Result Entry (IGroup)', N'إدخال نتائج البلدية (IGroup)'),
    (N'Baladiya Result Entry (Kizen)', N'إدخال نتائج البلدية (Kizen)'),
    (N'Bank Transfer Report', N'تقرير التحويلات البنكية'),
    (N'Category', N'الفئة'),
    (N'Cbc Result Retrieval By Invoice No.', N'استرجاع نتائج CBC برقم الفاتورة'),
    (N'Cbc Result Retrieval By Sample Id No.', N'استرجاع نتائج CBC برقم العينة'),
    (N'Clinic Reports', N'تقارير العيادة'),
    (N'Clinic Samples', N'عينات العيادة'),
    (N'Closing Year', N'إقفال السنة'),
    (N'Diagnostic Samples', N'العينات التشخيصية'),
    (N'Diagnostic Samples (Kizen)', N'العينات التشخيصية (Kizen)'),
    (N'Doctor', N'الطبيب'),
    (N'Doctors Investigations/Prescriptions', N'فحوصات ووصفات الأطباء'),
    (N'Doctor''s Prescriptions', N'وصفات الطبيب'),
    (N'Document Expiry List', N'قائمة انتهاء المستندات'),
    (N'Document Management', N'إدارة المستندات'),
    (N'Documents', N'المستندات'),
    (N'Drug Acceptance', N'استلام الأدوية'),
    (N'Drug Sale', N'بيع الأدوية'),
    (N'Duration Translation', N'ترجمة المدة'),
    (N'Edit Member...', N'تعديل العضو...'),
    (N'Employee Absences/Late', N'غياب وتأخر الموظفين'),
    (N'Employee Holiday Leave', N'إجازة الموظف الرسمية'),
    (N'Employee Leave Report', N'تقرير إجازات الموظفين'),
    (N'Employee Leaves Earned', N'الإجازات المكتسبة للموظفين'),
    (N'Employee Leaves Earned Approval', N'اعتماد الإجازات المكتسبة للموظفين'),
    (N'Employee Medical Report', N'التقرير الطبي للموظف'),
    (N'Employee Non-Holiday Leave', N'إجازة الموظف غير الرسمية'),
    (N'Generate Daily Drug Transfer File', N'إنشاء ملف نقل الأدوية اليومي'),
    (N'Generate Drug Acceptance File', N'إنشاء ملف استلام الأدوية'),
    (N'H.R.', N'الموارد البشرية'),
    (N'H.R. Reports', N'تقارير الموارد البشرية'),
    (N'Holiday Entry', N'إدخال الإجازات'),
    (N'IGroup', N'IGroup'),
    (N'Inventory', N'المخزون'),
    (N'Inventory Reports', N'تقارير المخزون'),
    (N'Inventory Transactions', N'معاملات المخزون'),
    (N'Invoice Note Editor', N'محرر ملاحظات الفواتير'),
    (N'Iqama CBC Result By Invoice No', N'نتيجة CBC للإقامة برقم الفاتورة'),
    (N'Iqama CBC Result By Sample No', N'نتيجة CBC للإقامة برقم العينة'),
    (N'Iqama Result Entry (IGroup)', N'إدخال نتائج الإقامة (IGroup)'),
    (N'Iqama Result Entry (Kizen)', N'إدخال نتائج الإقامة (Kizen)'),
    (N'Item Matcher', N'مطابقة الأصناف'),
    (N'ItemCode', N'رمز الصنف'),
    (N'Laboratory', N'المختبر'),
    (N'Laboratory Reports', N'تقارير المختبر'),
    (N'Medical Fitness Report Entry', N'إدخال تقرير اللياقة الطبية'),
    (N'Old Dosage Translation', N'ترجمة الجرعات القديمة'),
    (N'Other Laboratory Reports', N'تقارير المختبر الأخرى'),
    (N'Other Reports', N'تقارير أخرى'),
    (N'Payroll', N'الرواتب'),
    (N'Pharmacy', N'الصيدلية'),
    (N'Pharmacy Barcode Printing', N'طباعة باركود الصيدلية'),
    (N'Pharmacy Items', N'أصناف الصيدلية'),
    (N'Pharmacy Reports', N'تقارير الصيدلية'),
    (N'PMR', N'PMR'),
    (N'Prescription', N'الوصفة الطبية'),
    (N'Print Jobs', N'مهام الطباعة'),
    (N'Print Setups', N'إعدادات الطباعة'),
    (N'Printers', N'الطابعات'),
    (N'Printing', N'الطباعة'),
    (N'Product', N'المنتج'),
    (N'Product Expiry Report', N'تقرير انتهاء صلاحية المنتجات'),
    (N'Product Movement', N'حركة المنتجات'),
    (N'Purchase', N'المشتريات'),
    (N'Purchase Order', N'أمر شراء'),
    (N'Purchase Order Approval', N'اعتماد أمر الشراء'),
    (N'Purchase Return', N'مرتجع مشتريات'),
    (N'Purchases', N'المشتريات'),
    (N'Reception Reports', N'تقارير الاستقبال'),
    (N'Recurring Payroll Entry', N'إدخال الرواتب المتكررة'),
    (N'Report Group', N'مجموعة التقارير'),
    (N'Report Master', N'إدارة التقارير'),
    (N'Report Status Editing', N'تعديل حالة التقرير'),
    (N'Request Approval', N'اعتماد الطلب'),
    (N'Sales', N'المبيعات'),
    (N'Sales Entry', N'إدخال المبيعات'),
    (N'Sales Return', N'مرتجع مبيعات'),
    (N'Shift Daily Summary', N'ملخص المناوبة اليومية'),
    (N'Shift Summary Entry', N'إدخال ملخص المناوبة'),
    (N'Simple Password Generator', N'منشئ كلمات المرور البسيط'),
    (N'Sterilization Labels', N'ملصقات التعقيم'),
    (N'Stock Inventory', N'جرد المخزون'),
    (N'Supplier Product Link', N'ربط منتجات المورد'),
    (N'Test Form', N'نموذج اختبار'),
    (N'Update Menu Security Objects', N'تحديث كائنات أمان القوائم'),
    (N'Warehouse', N'المستودع');

DECLARE @ReconciliationCaptions TABLE
(
    Caption NVARCHAR(1024) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL PRIMARY KEY
);

INSERT INTO @ReconciliationCaptions (Caption)
VALUES
    (N'Account Reconciliation'),
    (N'Clear All'),
    (N'Complete Review'),
    (N'Finalize'),
    (N'Post'),
    (N'Reopen Review'),
    (N'Un-clear all');

BEGIN TRANSACTION;

INSERT INTO dbo.OriginalCaptions (Caption)
SELECT c.Caption
FROM @Captions c
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.OriginalCaptions oc
    WHERE oc.Caption = c.Caption
);

UPDATE tc
SET tc.TranslatedCaption = c.TranslatedCaption
FROM dbo.TranslatedCaption tc
JOIN dbo.OriginalCaptions oc ON oc.IdNo = tc.CaptionIdNo
JOIN @Captions c ON c.Caption = oc.Caption
WHERE tc.LanguageIdNo = @LanguageIdNo
  AND NULLIF(LTRIM(RTRIM(tc.TranslatedCaption)), N'') IS NULL;

/* Normalize the three known duplicate MainForm translations.  Keeping the
   duplicate rows is safer than deleting them because SystemViewItem may still
   reference either OriginalCaptions row, but every reference now displays the
   same Arabic text. */
DECLARE @CanonicalCaptions TABLE
(
    Caption NVARCHAR(1024) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL PRIMARY KEY,
    TranslatedCaption NVARCHAR(256) NOT NULL
);

INSERT INTO @CanonicalCaptions (Caption, TranslatedCaption)
VALUES
    (N'&Help', N'مساعدة'),
    (N'&Masters', N'الرئيسية'),
    (N'&Transactions', N'العمليات');

UPDATE tc
SET tc.TranslatedCaption = c.TranslatedCaption
FROM dbo.TranslatedCaption tc
JOIN dbo.OriginalCaptions oc ON oc.IdNo = tc.CaptionIdNo
JOIN @CanonicalCaptions c ON c.Caption = oc.Caption
WHERE tc.LanguageIdNo = @LanguageIdNo;

INSERT INTO dbo.TranslatedCaption (CaptionIdNo, LanguageIdNo, TranslatedCaption)
SELECT oc.IdNo, @LanguageIdNo, c.TranslatedCaption
FROM dbo.OriginalCaptions oc
JOIN @Captions c ON c.Caption = oc.Caption
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.TranslatedCaption tc
    WHERE tc.CaptionIdNo = oc.IdNo
    AND tc.LanguageIdNo = @LanguageIdNo
);

/* BFMain loads translations by SystemViewIdNo.  Having an
   OriginalCaptions/TranslatedCaption row alone is not enough for a menu or
   form to see it, so ensure the relevant form-to-caption links exist too. */
IF NOT EXISTS (SELECT 1 FROM dbo.SystemView WHERE SystemViewName = 'MainForm')
    INSERT INTO dbo.SystemView (SystemViewName) VALUES ('MainForm');

IF NOT EXISTS (SELECT 1 FROM dbo.SystemView WHERE SystemViewName = 'AccountReconciliationEntry')
    INSERT INTO dbo.SystemView (SystemViewName) VALUES ('AccountReconciliationEntry');

DECLARE @MainFormIdNo SMALLINT =
(
    SELECT TOP (1) IdNo
    FROM dbo.SystemView
    WHERE SystemViewName = 'MainForm'
);

DECLARE @ReconciliationFormIdNo SMALLINT =
(
    SELECT TOP (1) IdNo
    FROM dbo.SystemView
    WHERE SystemViewName = 'AccountReconciliationEntry'
);

INSERT INTO dbo.SystemViewItem (SystemViewIdNo, CaptionIdNo)
SELECT @MainFormIdNo, oc.IdNo
FROM dbo.OriginalCaptions oc
JOIN @Captions c ON c.Caption = oc.Caption
WHERE NOT EXISTS
(
    SELECT 1
    FROM @ReconciliationCaptions rc
    WHERE rc.Caption = c.Caption
)
AND NOT EXISTS
(
    SELECT 1
    FROM dbo.SystemViewItem svi
    WHERE svi.SystemViewIdNo = @MainFormIdNo
      AND svi.CaptionIdNo = oc.IdNo
);

INSERT INTO dbo.SystemViewItem (SystemViewIdNo, CaptionIdNo)
SELECT @ReconciliationFormIdNo, oc.IdNo
FROM dbo.OriginalCaptions oc
JOIN @ReconciliationCaptions rc ON rc.Caption = oc.Caption
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.SystemViewItem svi
    WHERE svi.SystemViewIdNo = @ReconciliationFormIdNo
      AND svi.CaptionIdNo = oc.IdNo
);

COMMIT TRANSACTION;

SELECT COUNT(*) AS CaptionsSeeded
FROM dbo.OriginalCaptions oc
JOIN @Captions c ON c.Caption = oc.Caption;

SELECT COUNT(*) AS ArabicTranslationsPresent
FROM dbo.TranslatedCaption tc
JOIN dbo.OriginalCaptions oc ON oc.IdNo = tc.CaptionIdNo
JOIN @Captions c ON c.Caption = oc.Caption
WHERE tc.LanguageIdNo = @LanguageIdNo
  AND NULLIF(LTRIM(RTRIM(tc.TranslatedCaption)), N'') IS NOT NULL;
