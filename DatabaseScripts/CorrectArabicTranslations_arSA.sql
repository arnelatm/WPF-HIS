/*
    First-pass Arabic corrections for the active Accounts application.

    Scope:
      * fills Arabic only when the ar-SA value is missing or blank;
      * adds the one message key used by reconciliation code but absent from
        older databases;
      * corrects only the explicitly identified corrupted/placeholder values;
      * does not overwrite any other non-blank translation.

    Run first against a restored test database.  The script is idempotent.
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
    THROW 51000, 'Language ar-SA was not found in dbo.Languages.', 1;

DECLARE @Messages TABLE
(
    MessageKey VARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL PRIMARY KEY,
    TranslatedMessage NVARCHAR(512) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    TranslatedCaption NVARCHAR(256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
);

INSERT INTO @Messages (MessageKey, TranslatedMessage, TranslatedCaption)
VALUES
('AskAddAnotherRecord', N'هل تريد إضافة سجل آخر؟', N'يرجى التأكيد'),
('AskAutoLogOff', N'سيُغلق البرنامج خلال دقيقتين. اضغط إلغاء للاستمرار في العمل؟', N'يرجى التأكيد'),
('AskContinueWithPreviousSearch', N'هل تريد متابعة البحث السابق (نعم) أم إنشاء بحث جديد (لا)؟', N'معلومات'),
('AskIfContinueAction', N'هل أنت متأكد أنك تريد {action} هذا القيد الخاص بـ {itemName}؟', N'يرجى التأكيد'),
('AskIfDeleteRecord', N'هل أنت متأكد من حذف هذا السجل؟', N'تأكيد الحذف'),
('AskIfRegeneratePayroll', N'تم إنشاء كشف الرواتب مسبقاً. هل أنت متأكد من إعادة إنشائه وتحديث كشف الرواتب السابق؟', N'يرجى التأكيد'),
('AskIfSaveEmptyJournal', N'قيد اليومية فارغ. هل تريد حفظه رغم ذلك؟', N'يومية فارغة'),
('AskIfUseExpiredDate', N'هل أنت متأكد من استخدام هذا التاريخ المنتهي؟', N'يرجى التأكيد'),
('AskIfUserWantsToSaveOrContinueEdits', N'تم إجراء تغييرات على هذا السجل. اضغط [نعم] لحفظها، أو [لا] لتجاهلها، أو [إلغاء] لمتابعة التعديل.', N'حفظ التغييرات؟'),
('AskLastRecordReachStartBeg', N'هذا آخر سجل مطابق للنص. هل تريد بدء البحث من السجل الأول؟', N'تم العثور على آخر سجل'),
('AskMakeExcessCollectionAdvance', N'لم يُطبّق المبلغ بالكامل أو لا توجد فواتير غير مسددة لهذا العميل. هل تريد تسجيل المبلغ الزائد كتحصيل مقدم؟', N'حفظ تحصيل مقدم'),
('AskMakeExcessPaymentAdvance', N'لم يُطبّق المبلغ بالكامل أو لا توجد فواتير غير مسددة لهذا المورد. هل تريد تسجيل المبلغ الزائد كدفعة مقدمة؟', N'حفظ دفعة مقدمة'),
('MsgBlankExpNotAllowed', N'عذراً، يجب إدخال تاريخ انتهاء لهذا الصنف.', N'خطأ'),
('MsgCannotEditReadOnly', N'عذراً، هذا العنصر للقراءة فقط أو لا تملك صلاحية تعديله. ستتم إعادة القيمة الأصلية.', N'خطأ'),
('MsgDuplicateKeyValueViolation', N'لا يمكن إدراج صف بمفتاح مكرر في الكائن {tableName} باستخدام الفهرس الفريد {indexName}. قيمة المفتاح المكرر هي {duplicateValue}!', N'تعارض مفتاح فريد'),
('MsgDuplicateLine', N'عذراً، تم العثور على قيم مكررة. راجع السطر رقم {lineNumber}.', N'خطأ'),
('MsgEditingNotAllowed', N'عذراً، لا يُسمح بتعديل هذا القيد!', N'خطأ'),
('MsgEmptyEmployeeOvertime', N'عذراً، لم يتم إنشاء حضور الموظف بعد. يجب إنشاء الحضور أولاً قبل إنشاء كشف الرواتب!', N'خطأ إنشاء'),
('MsgErroneousDate', N'التاريخ المدخل <{enteredDate}> غير صالح لتقويم <{calendarName}>! اضغط Ctrl-Z لإعادة القيمة السابقة.', N'خطأ'),
('MsgErroneousTime', N'الوقت المدخل غير صالح! اضغط Ctrl-Z لإعادة القيمة السابقة.', N'خطأ'),
('MsgExactTextLength', N'يجب أن يتكون الحقل {fieldName} من {minimumLength} حرفاً بالضبط.', N'إدخال غير صالح'),
('MsgFirstRowInsertionNotAllowed', N'لا يُسمح بحذف الصف الأول من هذه المعاملة!', N'خطأ الحذف'),
('MsgInvalidDate', N'التاريخ المدخل <{enteredDate}> غير صالح. يجب أن يكون بأحد التنسيقات التالية [yyyy/MM أو yyyyMM أو yyyy-MM]. اضغط Ctrl-Z لإعادة القيمة السابقة.', N'خطأ'),
('MsgInvalidEMail', N'الحقل {fieldName} ليس بريداً إلكترونياً صالحاً؛ يجب أن يكون بالتنسيق xxxxxx@xxxxxx.xxx', N'إدخال غير صالح'),
('MsgInvalidEndOfYearDate', N'تاريخ نهاية السنة غير صالح. يجب أن يكون الشهر 12 واليوم 31!', N'إدخال غير صالح'),
('MsgInvalidInsertOnFirstRow', N'عذراً، لا يُسمح بالإدراج في الصف الأول من {transactionName}.', N'إدراج غير صالح'),
('MsgInvalidRange', N'يجب أن تكون قيمة الحقل {fieldName} بين {minimumValue} و{maximumValue}.', N'إدخال غير صالح'),
('MsgInvalidTextLength', N'يجب أن يكون طول الحقل {fieldName} بين {minimumLength} و{maximumLength} حرفاً.', N'إدخال غير صالح'),
('MsgInvalidVatNumber', N'القيمة المدخلة غير صالحة؛ يجب أن يتكون رقم ضريبة القيمة المضافة من 15 رقماً بالضبط!', N'إدخال غير صالح'),
('MsgNoHolidayAvailmentToApprove', N'إما أنه لا توجد طلبات إجازة مقدمة حالياً أو تم اتخاذ إجراء بشأن جميع الطلبات المتاحة.', N'خطأ'),
('MsgNonDoctorUser', N'عذراً، لست طبيباً. يقتصر الوصول إلى هذه الوحدة على الأطباء.', N'خطأ'),
('MsgNoPrevSearchFindInvalid', N'لم يُنفذ بحث سابق. لا توجد نتائج للعثور عليها. لبدء البحث، انقر بزر الفأرة الأيمن داخل الحقل المطلوب وابحث عن النص.', N'تحذير'),
('MsgNothingToFind', N'إما أن قيمة هذا الحقل ثابتة أو أن البحث غير مفعّل لهذا الحقل.', N'تحذير'),
('MsgObj1MustBeLessThanObj2', N'يجب أن تكون قيمة {name1} أصغر من قيمة {name2}.', N'إدخال غير صالح'),
('MsgOnEmptyReconChangeAccNotAllowed', N'عذراً، لا يمكنك تغيير الحساب المراد مطابقته عندما تكون شبكة المطابقة فارغة. تمت استعادة القيمة السابقة.', N'لا يُسمح بتغيير الحساب'),
('MsgOperationNotAvailableInViewMode', N'عذراً، لا يُسمح بهذه العملية في وضع العرض. انتقل إلى وضع التعديل لتنفيذها.', N'تحذير'),
('MsgPasswordLengthError', N'عذراً، يجب ألا تقل كلمة المرور عن 6 أحرف.', N'تحذير'),
('MsgPasswordMatchError', N'عذراً، كلمة المرور الجديدة وتأكيدها غير متطابقين. يرجى المحاولة مرة أخرى.', N'تحذير'),
('MsgRateChangeNotAllowed', N'عذراً، لا يمكنك تغيير حقل السعر في قيود "المبلغ الثابت". يمكنك تغيير حقل المبلغ فقط.', N'تحذير'),
('MsgRecordChangedSinceLastRetrieval', N'تم تغيير السجل منذ آخر استرجاع له، ولا يمكن حفظ تعديلاتك. يرجى تحديث السجل ثم المحاولة مرة أخرى.', N'تم تغيير السجل'),
('MsgRowDelNotAllowedInViewMode', N'لا يُسمح بحذف الصف أثناء وضع العرض. اضغط زر التعديل لتمكين الحذف.', N'خطأ'),
('MsgRowInsNotAllowedInFirstRow', N'لا يُسمح بإدراج صف في الصف الأول لهذه المعاملة.', N'خطأ'),
('MsgRowInsNotAllowedInViewMode', N'لا يُسمح بإدراج صف أثناء وضع العرض. اضغط زر التعديل لتمكين الإدراج.', N'خطأ'),
('MsgSecurityError', N'عذراً، لا تملك صلاحية الأمان اللازمة لتنفيذ هذا الأمر!', N'خطأ'),
('MsgShowCsvOutputFile', N'تم إنشاء ملف تحويل البنك CSV في مجلد المستندات باسم CSV.csv', N'إشعار'),
('MsgSysPayElementNotAllowed', N'هذا عنصر راتب محجوز للنظام؛ لا يُسمح بحذفه!', N'خطأ'),
('MsgUnitEqualToBaseUnit', N'عذراً، لا يمكن أن تكون الوحدة هي نفسها الوحدة الأساسية.', N'خطأ'),
('MsgUnitQtyEqualToBUQty', N'عذراً، لا يمكن أن تكون كمية الوحدة مساوية لكمية الوحدة الأساسية.', N'خطأ'),
('MsgValidationCompareEqual', N'يجب أن تكون قيمة {propertyName} مساوية لقيمة {otherPropertyName}', N'خطأ التحقق'),
('MsgValidationCompareNotEqual', N'يجب ألا تكون قيمة {propertyName} مساوية لقيمة {otherPropertyName}', N'خطأ التحقق'),
('MsgEditingOfReconciledItemsNotAllowed', N'لا يُسمح بتعديل أو حذف هذه المعاملة لأنها تحتوي على قيود حسابات تمت مطابقتها.', N'خطأ'),
('MsgRequiredField', N'عذراً، الحقل [{fieldName}] مطلوب!', N'إدخال غير صالح');

DECLARE @OriginalDefaults TABLE
(
    MessageKey VARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL PRIMARY KEY,
    EnglishMessage VARCHAR(256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    EnglishCaption VARCHAR(128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
);

INSERT INTO @OriginalDefaults (MessageKey, EnglishMessage, EnglishCaption)
VALUES
('MsgEditingOfReconciledItemsNotAllowed', 'Editing or deleting a transaction with reconciled account entries is not allowed.', 'Error');

DECLARE @Captions TABLE
(
    Caption NVARCHAR(1024) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL PRIMARY KEY,
    TranslatedCaption NVARCHAR(256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
);

INSERT INTO @Captions (Caption, TranslatedCaption)
VALUES
(N'Acceptance Date', N'تاريخ القبول'),
(N'Base Form', N'النموذج الأساسي'),
(N'CBC Results Retrieval', N'استرجاع نتائج تعداد الدم الكامل'),
(N'Company Name', N'اسم الشركة'),
(N'Country Maintenance Form', N'نموذج صيانة الدول'),
(N'Customer Code:', N'رمز العميل:'),
(N'Customer Name Ara:', N'اسم العميل بالعربية:'),
(N'Customer Name:', N'اسم العميل:'),
(N'Date Applied', N'تاريخ التقديم'),
(N'Display Order', N'ترتيب العرض'),
(N'Employee Earned Leave Approval', N'اعتماد الإجازة المكتسبة للموظف'),
(N'Employee Earned Leave Entry', N'إدخال الإجازة المكتسبة للموظف'),
(N'Employee Information', N'معلومات الموظف'),
(N'End Reference Number', N'رقم المرجع النهائي'),
(N'Entry Result', N'نتيجة الإدخال'),
(N'Final Fit', N'لائق نهائياً'),
(N'Final Unfit', N'غير لائق نهائياً'),
(N'Fiscal-Year Journal Posting', N'ترحيل يوميات السنة المالية'),
(N'Full Day', N'يوم كامل'),
(N'General Medical Examination / الفحص الطبي العام', N'الفحص الطبي العام'),
(N'Generate Payroll CSV File', N'إنشاء ملف الرواتب بصيغة CSV'),
(N'ID/Iqama/ Border No.', N'رقم الهوية/الإقامة/الحدود'),
(N'Invoice Number', N'رقم الفاتورة'),
(N'Item Purchase History', N'سجل شراء الصنف'),
(N'Kizen Result', N'نتيجة كيزن'),
(N'Lab No.', N'رقم المختبر'),
(N'Label Printed', N'تمت طباعة الملصق'),
(N'Leave ID No.', N'رقم تعريف الإجازة'),
(N'Medical Fitness Report', N'تقرير اللياقة الطبية'),
(N'Patient Prescription', N'وصفة المريض'),
(N'Patient Type', N'نوع المريض'),
(N'Pay Cycles Maintenance Form', N'نموذج صيانة دورات الدفع'),
(N'Payroll Date', N'تاريخ كشف الرواتب'),
(N'Payroll Description', N'وصف كشف الرواتب'),
(N'Payroll Maintenance Form', N'نموذج صيانة كشف الرواتب'),
(N'Payroll No.', N'رقم كشف الرواتب'),
(N'Petty Cash Posting', N'ترحيل المصروفات النثرية'),
(N'PMR Reports', N'تقارير السجل الطبي للمريض'),
(N'Prescription for :', N'وصفة لـ:'),
(N'Print Job Maintenance Form', N'نموذج صيانة مهام الطباعة'),
(N'Print Setup Maintenance Form', N'نموذج صيانة إعدادات الطباعة'),
(N'Print?', N'طباعة؟'),
(N'Printer Maintenance Form', N'نموذج صيانة الطابعات'),
(N'Product Id No.', N'رقم تعريف المنتج'),
(N'Prompt Parameter Names', N'أسماء معاملات المطالبة'),
(N'Qty. Approved', N'الكمية المعتمدة'),
(N'Qty. Supplied', N'الكمية الموردة'),
(N'RDW-CV', N'RDW-CV'),
(N'RDW-SD', N'RDW-SD'),
(N'Reference Value', N'القيمة المرجعية'),
(N'Refresh Lab Results', N'تحديث نتائج المختبر'),
(N'Repeat Prompt After Close?', N'تكرار المطالبة بعد الإغلاق؟'),
(N'Report Maintenance Form', N'نموذج صيانة التقارير'),
(N'Revenue Groups Maintenance Form', N'نموذج صيانة مجموعات الإيرادات'),
(N'Start Reference Number', N'رقم المرجع الابتدائي'),
(N'Status Source', N'مصدر الحالة'),
(N'Summary of A.P.', N'ملخص الحسابات الدائنة'),
(N'Supplier Maintenance Form', N'نموذج صيانة الموردين'),
(N'Taken By', N'تم الاستلام بواسطة'),
(N'Time Taken', N'وقت الاستلام'),
(N'Unit Name', N'اسم الوحدة'),
(N'User Maintenance Form', N'نموذج صيانة المستخدمين'),
(N'View Kizen Results', N'عرض نتائج كيزن'),
(N'Warehouse Requested', N'المستودع المطلوب');

DECLARE @MessageCorrections TABLE
(
    MessageKey VARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL PRIMARY KEY,
    InvalidTranslation NVARCHAR(512) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    CorrectTranslation NVARCHAR(512) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    CorrectCaption NVARCHAR(256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
);

INSERT INTO @MessageCorrections (MessageKey, InvalidTranslation, CorrectTranslation, CorrectCaption)
VALUES
('MsgRequiredField', N'{fieldName} Is a required field.', N'عذراً، الحقل [{fieldName}] مطلوب!', N'إدخال غير صالح');

DECLARE @CaptionCorrections TABLE
(
    Caption NVARCHAR(1024) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL PRIMARY KEY,
    InvalidTranslation NVARCHAR(256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    CorrectTranslation NVARCHAR(256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
);

INSERT INTO @CaptionCorrections (Caption, InvalidTranslation, CorrectTranslation)
VALUES
(N'LeaveEntry', N'???? ??????', N'إدخال الإجازة'),
(N'&Copy', N'Translation', N'نسخ'),
(N'Year End Date:', N'Year End Date Arabic:', N'تاريخ نهاية السنة:'),
(N'Month End Date:', N'Month End Date Arabic:', N'تاريخ نهاية الشهر:'),
(N'Delete', N'الغاء', N'حذف'),
(N'&Delete', N'إحذف', N'حذف'),
(N'Statement of Accounts Receivable', N'كشوف حساب الذمم المدينه', N'كشف حساب الذمم المدينة'),
(N'Accounts Payable', N'حسابات  دائنه ', N'الحسابات الدائنة'),
(N'Monthly Journal Posting', N'ترحيل اليومية الشهري', N'ترحيل اليومية الشهرية');

BEGIN TRANSACTION;

INSERT INTO dbo.OriginalMessages (MessageKey, Message, Caption)
SELECT d.MessageKey, d.EnglishMessage, d.EnglishCaption
FROM @OriginalDefaults d
WHERE NOT EXISTS
(
    SELECT 1 FROM dbo.OriginalMessages om WHERE om.MessageKey = d.MessageKey
);

UPDATE om
SET om.Message = CASE WHEN NULLIF(LTRIM(RTRIM(om.Message)), '') IS NULL THEN d.EnglishMessage ELSE om.Message END,
    om.Caption = CASE WHEN NULLIF(LTRIM(RTRIM(om.Caption)), '') IS NULL THEN d.EnglishCaption ELSE om.Caption END
FROM dbo.OriginalMessages om
JOIN @OriginalDefaults d ON d.MessageKey = om.MessageKey;

UPDATE tm
SET tm.TranslatedMessage = CASE WHEN NULLIF(LTRIM(RTRIM(tm.TranslatedMessage)), N'') IS NULL THEN m.TranslatedMessage ELSE tm.TranslatedMessage END,
    tm.TranslatedCaption = CASE WHEN NULLIF(LTRIM(RTRIM(tm.TranslatedCaption)), N'') IS NULL THEN m.TranslatedCaption ELSE tm.TranslatedCaption END
FROM dbo.TranslatedMessages tm
JOIN dbo.OriginalMessages om ON om.IdNo = tm.MessageIdNo
JOIN @Messages m ON m.MessageKey = om.MessageKey
WHERE tm.LanguageIdNo = @LanguageIdNo;

INSERT INTO dbo.TranslatedMessages (MessageIdNo, LanguageIdNo, TranslatedMessage, TranslatedCaption)
SELECT om.IdNo, @LanguageIdNo, m.TranslatedMessage, m.TranslatedCaption
FROM dbo.OriginalMessages om
JOIN @Messages m ON m.MessageKey = om.MessageKey
WHERE NOT EXISTS
(
    SELECT 1 FROM dbo.TranslatedMessages tm
    WHERE tm.MessageIdNo = om.IdNo AND tm.LanguageIdNo = @LanguageIdNo
);

UPDATE tm
SET tm.TranslatedMessage = c.CorrectTranslation,
    tm.TranslatedCaption = CASE WHEN c.CorrectCaption IS NULL THEN tm.TranslatedCaption ELSE c.CorrectCaption END
FROM dbo.TranslatedMessages tm
JOIN dbo.OriginalMessages om ON om.IdNo = tm.MessageIdNo
JOIN @MessageCorrections c ON c.MessageKey = om.MessageKey
WHERE tm.LanguageIdNo = @LanguageIdNo
  AND tm.TranslatedMessage = c.InvalidTranslation;

INSERT INTO dbo.OriginalCaptions (Caption)
SELECT c.Caption
FROM @Captions c
WHERE NOT EXISTS
(
    SELECT 1 FROM dbo.OriginalCaptions oc WHERE oc.Caption = c.Caption
);

UPDATE tc
SET tc.TranslatedCaption = CASE WHEN NULLIF(LTRIM(RTRIM(tc.TranslatedCaption)), N'') IS NULL THEN c.TranslatedCaption ELSE tc.TranslatedCaption END
FROM dbo.TranslatedCaption tc
JOIN dbo.OriginalCaptions oc ON oc.IdNo = tc.CaptionIdNo
JOIN @Captions c ON c.Caption = oc.Caption
WHERE tc.LanguageIdNo = @LanguageIdNo;

INSERT INTO dbo.TranslatedCaption (CaptionIdNo, LanguageIdNo, TranslatedCaption)
SELECT oc.IdNo, @LanguageIdNo, c.TranslatedCaption
FROM dbo.OriginalCaptions oc
JOIN @Captions c ON c.Caption = oc.Caption
WHERE NOT EXISTS
(
    SELECT 1 FROM dbo.TranslatedCaption tc
    WHERE tc.CaptionIdNo = oc.IdNo AND tc.LanguageIdNo = @LanguageIdNo
);

UPDATE tc
SET tc.TranslatedCaption = c.CorrectTranslation
FROM dbo.TranslatedCaption tc
JOIN dbo.OriginalCaptions oc ON oc.IdNo = tc.CaptionIdNo
JOIN @CaptionCorrections c ON c.Caption = oc.Caption
WHERE tc.LanguageIdNo = @LanguageIdNo
  AND tc.TranslatedCaption = c.InvalidTranslation;

/* Some older databases contain a variable number of replacement question
   marks for LeaveEntry, so also repair that caption when it contains no
   Arabic text.  A valid Arabic translation is left unchanged. */
UPDATE tc
SET tc.TranslatedCaption = N'إدخال الإجازة'
FROM dbo.TranslatedCaption tc
JOIN dbo.OriginalCaptions oc ON oc.IdNo = tc.CaptionIdNo
WHERE tc.LanguageIdNo = @LanguageIdNo
  AND oc.Caption = N'LeaveEntry'
  AND tc.TranslatedCaption NOT LIKE N'%[ء-ي]%';

/* A blank source caption must not display the test value "Translation". */
UPDATE tc
SET tc.TranslatedCaption = N''
FROM dbo.TranslatedCaption tc
JOIN dbo.OriginalCaptions oc ON oc.IdNo = tc.CaptionIdNo
WHERE tc.LanguageIdNo = @LanguageIdNo
  AND NULLIF(LTRIM(RTRIM(oc.Caption)), N'') IS NULL
  AND tc.TranslatedCaption = N'Translation';

COMMIT TRANSACTION;

SELECT
    SUM(CASE WHEN NULLIF(LTRIM(RTRIM(tm.TranslatedMessage)), N'') IS NULL THEN 1 ELSE 0 END) AS BatchMessagesStillBlank
FROM @Messages m
JOIN dbo.OriginalMessages om ON om.MessageKey = m.MessageKey
LEFT JOIN dbo.TranslatedMessages tm ON tm.MessageIdNo = om.IdNo AND tm.LanguageIdNo = @LanguageIdNo;

SELECT
    SUM(CASE WHEN NULLIF(LTRIM(RTRIM(tc.TranslatedCaption)), N'') IS NULL THEN 1 ELSE 0 END) AS BatchCaptionsStillBlank
FROM @Captions c
JOIN dbo.OriginalCaptions oc ON oc.Caption = c.Caption
LEFT JOIN dbo.TranslatedCaption tc ON tc.CaptionIdNo = oc.IdNo AND tc.LanguageIdNo = @LanguageIdNo;
