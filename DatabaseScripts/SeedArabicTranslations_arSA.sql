/*
    Arabic (ar-SA) translation seed for the active Accounts application.

    This script is intentionally not part of the DACPAC.  Translation text is
    application data, not schema.  Run it after a database backup, first on a
    restored test database, then on the approved production database.

    The script is idempotent and only fills missing/blank Arabic values.  It
    does not overwrite an existing translation.
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
    TranslatedMessage NVARCHAR(512) NOT NULL,
    TranslatedCaption NVARCHAR(256) NULL
);

INSERT INTO @Messages (MessageKey, TranslatedMessage, TranslatedCaption)
VALUES
('MsgAccountsNotAllowed', N'خطأ في السطر {lineNumber}. عذراً، لا يُسمح بحسابات {entryNames} لهذه المعاملة!', N'إدخال غير صالح'),
('MsgRunPreviewBeforeExecution', N'يرجى تشغيل المعاينة قبل تنفيذ الترحيل.', N'الترحيل'),
('MsgConfirmMonthlyPosting', N'هل تريد ترحيل جميع اليوميات الصالحة للشهر {month} من السنة {year}؟', N'تأكيد الترحيل الشهري'),
('MsgEnterChecklistNote', N'أدخل ملاحظة قبل إكمال بند قائمة التحقق.', N'قائمة تحقق إغلاق الشهر'),
('MsgMonthlyCloseChecklistFailed', N'فشلت عملية قائمة تحقق إغلاق الشهر: {details}', N'قائمة تحقق إغلاق الشهر'),
('MsgMonthApproved', N'تم اعتماد الشهر. يمكنك الآن تشغيل الترحيل الشهري.', N'إغلاق الشهر'),
('MsgChecklistLoaded', N'تم تحميل قائمة التحقق: {itemCount} بنداً. حدد بنداً ثم اضغط إكمال البند.', N'قائمة تحقق إغلاق الشهر'),
('MsgMonthlyPostingStatus', N'الأخطاء: {errors}؛ الرؤوس: {headers}؛ البنود: {items}؛ حالة الإغلاق: {closeStatus}', N'ترحيل اليومية الشهري'),
('MsgMonthlyPostingRequestFailed', N'فشل طلب الترحيل الشهري: {details}', N'ترحيل اليومية الشهري'),
('MsgFiscalPostingStatus', N'الأخطاء المانعة: {errors}؛ الرؤوس للترحيل: {headers}؛ البنود للترحيل: {items}', N'ترحيل السنة المالية'),
('MsgConfirmFiscalYearPosting', N'سيتم وضع علامة "مُرحّل" على جميع رؤوس وبنود اليوميات غير المرحّلة في السنة المالية {year}. العملية مسجلة ولا يمكن التراجع عنها من هذه الشاشة. هل تريد المتابعة؟', N'تأكيد ترحيل السنة المالية'),
('MsgFiscalPostingRequestFailed', N'فشل طلب ترحيل السنة المالية: {details}', N'ترحيل السنة المالية'),
('MsgAlreadyPosted', N'عذراً، هذا السجل مُرحّل بالفعل!', N'عملية غير مسموحة'),
('MsgAppliedAmtExceedsBalance', N'خطأ في السطر {lineNumber}. المبلغ المطبق والخصم يتجاوزان الرصيد.', N'دفعة غير صالحة'),
('MsgApplLvExceedAllowLv', N'عذراً، الأيام المطبقة {noOfDaysApplied} تتجاوز الحد الأقصى المسموح به {noOfDaysAllowed} من أيام الإجازة لنوع الإجازة {leaveName}.', N'إجازة غير صالحة'),
('MsgApprovedOrUsedLeave', N'لا يمكن حذف الإجازة التي تم اعتمادها أو اعتمادها من المشرف أو استخدامها.', N'إجازة غير صالحة'),
('MsgApprovedQtyUpdated', N'تم تحديث الكمية المعتمدة لجميع البنود التي يتوفر لها مخزون كافٍ!', N'نجاح'),
('MsgAttendanceInitializationCompleted', N'اكتملت تهيئة حضور الموظفين للرواتب!', N'اكتمل'),
('MsgBegDateMustBeLessThanEndDate', N'يجب أن يكون تاريخ البداية أسبق من تاريخ النهاية.', N'إدخال غير صالح'),
('MsgBlankAccountIDNotAllowed', N'خطأ في السطر {lineNumber}. لا يمكن حفظ مبالغ مدينة أو دائنة عندما يكون معرّف الحساب فارغاً.', N'إدخال غير صالح'),
('MsgBlankDistributionScheme', N'لا توجد بنود، لا يمكن حفظ مخطط توزيع فارغ.', N'إدخال غير صالح'),
('MsgBlankRevenueCostCenter', N'لا يُسمح بمركز إيراد/تكلفة فارغ في السطر رقم {lineNumber}.', N'إدخال غير صالح'),
('MsgCannotEditInvItems', N'لا يمكن تعديل {fieldName} للأصناف الموجودة. ستتم إعادة القيمة السابقة.', N'إدخال غير صالح'),
('MsgCannotPostUnreconciledEntry', N'عذراً، لا يمكنك ترحيل قيد غير مُطابق.', N'عملية غير مسموحة'),
('MsgCannotPostUnsaved', N'يرجى حفظ القيد قبل ترحيله.', N'عملية غير مسموحة'),
('MsgCannotSaveAnEmptyTransaction', N'عذراً، لا يمكن حفظ معاملة فارغة!', N'خطأ'),
('MsgCashAccountsNotAllowed', N'خطأ في السطر {lineNumber}. لا يُسمح بحسابات النقد لهذه المعاملة.', N'إدخال غير صالح'),
('MsgChangeApprovedTransaction', N'تم اعتماد هذا السجل بالفعل. لا يُسمح بالتعديل!', N'قيد معتمد'),
('MsgChangeClosedTransaction', N'فترة هذه المعاملة مغلقة بالفعل، ولا يُسمح بالتعديل أو الحذف.', N'خطأ'),
('MsgChangePostedRecordNotAllowed', N'تم ترحيل هذا السجل بالفعل. لا يُسمح بالتعديل أو الحذف!', N'قيد مرحّل'),
('MsgChildRecordsExists', N'توجد سجلات فرعية لهذا السجل الرئيسي. لا يُسمح بالحذف!', N'خطأ'),
('MsgCollectionIsOverApplied', N'تم تطبيق التحصيل بأكثر من اللازم. زد مبلغ التحصيل أو خفّض المبالغ المطبقة.', N'معاملة غير صالحة'),
('MsgCollectionNotFullyApplied', N'لم يُطبّق التحصيل بالكامل بعد. لا يمكن حفظ القيد حتى يُطبّق المبلغ بالكامل.', N'معاملة غير صالحة'),
('MsgDateCannotBeBlank', N'عذراً، لا يُسمح بتاريخ فارغ.', N'خطأ'),
('MsgDateNotInRange', N'تاريخ {dateField} غير صالح، يجب أن تكون القيمة بين {startDate} و{endDate}!', N'تاريخ غير صالح'),
('MsgDatesCannotBeEmpty', N'لا يمكن أن تكون التواريخ فارغة، يرجى إدخال التواريخ.', N'إدخال غير صالح'),
('MsgDeleteCollEntryNotAllowed', N'لا يمكنك حذف هذا الصف لأن القيد له تحصيل أو خصم موجود!', N'خطأ الحذف'),
('MsgDeleteEntryNotAllowed', N'عذراً، لا يُسمح بحذف قيود {description}!', N'خطأ الحذف'),
('MsgDeletePaidEntryNotAllowed', N'لا يمكنك حذف هذا الصف لأن القيد له دفعة أو خصم موجود!', N'خطأ الحذف'),
('MsgDeleteRecordFailed', N'لم يُحذف السجل بسبب خطأ. يرجى المحاولة لاحقاً أو طلب مساعدة مسؤول قاعدة البيانات.', N'خطأ الحذف'),
('MsgDependentRecordExists', N'عذراً، توجد سجلات مرتبطة في جداول أخرى. لا يُسمح بالتعديل أو الحذف! {additionalMessage}', N'خطأ'),
('MsgDuplicateValuesNotAllowed', N'يوجد سجل بالقيمة {fieldValue} في الحقل {fieldDescription}، ولا يُسمح بالقيم المكررة.', N'قيمة مكررة'),
('MsgEditingOfClosedPcRecordNotAllowed', N'تم إغلاق هذا السجل بالفعل. لا يُسمح بالتعديل!', N'خطأ'),
('MsgEditingOfReconciledNotAllowed', N'لا يُسمح بتعديل أو حذف معاملة تحتوي على قيود حسابات تمت مطابقتها!', N'خطأ'),
('MsgEditingOfReconciliationReviewNotAllowed', N'تتضمن هذه المعاملة مطابقة حساب مكتملة أو نهائية. أعد فتح مراجعة المطابقة قبل تعديلها أو حذفها.', N'خطأ'),
('MsgEmptyApprovalNote', N'يجب تحديد سبب رفض الإجازة لرقم الإجازة {leaveNumber}.', N'خطأ'),
('MsgEmptyEmployeeAttendanceOt', N'لم تتم تهيئة حضور الموظفين أو العمل الإضافي لهذه المسيرة بعد. يرجى التهيئة أولاً قبل إنشاء الرواتب.', N'خطأ'),
('MsgExpDateNeeded', N'خطأ في السطر {lineNumber}. يلزم إدخال تاريخ انتهاء لصنف الشراء المذكور.', N'إدخال غير صالح'),
('MsgFirstRecordHit', N'هذا هو السجل الأول بالفعل.', N'السجل الأول'),
('MsgFirstRowDeletionNotAllowed', N'لا يُسمح بحذف الصف الأول لهذه المعاملة!', N'خطأ الحذف'),
('MsgHolidayAvailmentAlreadyActed', N'تم تنفيذ إجراء {approvalAction} على طلب الإجازة هذا بالفعل، ولا يُسمح بالتغيير.', N'إجازة غير صالحة'),
('MsgInvalidCode', N'عذراً، لا يوجد {fieldName} بهذا الرمز في الملفات.', N'خطأ'),
('MsgInvalidDecimalValue', N'قيمة غير صالحة، الإدخال ليس رقماً عشرياً.', N'إدخال غير صالح'),
('MsgInvalidInteger', N'الرقم {number} المُدخل في الحقل {controlName} ليس عدداً صحيحاً صالحاً.', N'خطأ'),
('MsgInvalidIntegerValue', N'قيمة غير صالحة، الإدخال ليس عدداً صحيحاً.', N'إدخال غير صالح'),
('MsgInvalidNumericValue', N'القيمة {text} المُدخلة في الحقل {controlName} ليست رقماً.', N'خطأ'),
('MsgInvalidPercentageRange', N'يجب أن تكون النسبة المئوية بين 1 و100.', N'إدخال غير صالح'),
('MsgInvalidTotalPercentage', N'يجب أن يكون إجمالي النسبة المئوية 100.00%.', N'إدخال غير صالح'),
('MsgInvalidUserNameOrPassword', N'اسم المستخدم أو كلمة المرور غير صالحة.', N'خطأ تسجيل الدخول'),
('MsgInvalidValue', N'القيمة {fieldValue} غير صالحة للحقل {fieldDescription}.', N'قيمة غير صالحة'),
('MsgInvTransferSuccess', N'تم نقل أصناف المخزون بنجاح.', N'نجاح'),
('MsgLastRecordHit', N'هذا هو السجل الأخير بالفعل.', N'السجل الأخير'),
('MsgLeaveAlreadyActed', N'تم تنفيذ الإجراء {approvalAction} على هذه الإجازة بالفعل، ولا يُسمح بالتغيير.', N'خطأ'),
('MsgLeavePlusPendingExcess', N'إجمالي إجازات {leaveName} المطلوبة وعددها {noOfDaysRequested} يوماً، بالإضافة إلى الإجازات المعلقة وعددها {pendingLeaves} يوماً، يتجاوز الإجازات المكتسبة وعددها {earnedLeaveDays} يوماً لهذا الموظف.', N'خطأ'),
('MsgMemberCannotBeAParentToItself', N'عذراً، لا يمكن أن يكون العضو أباً لنفسه.', N'أب غير صالح'),
('MsgMultiResultCBCFound', N'تم العثور على عدة نتائج في الملفات، يرجى تحديد السجل المراد نقله يدوياً.', N'خطأ'),
('MsgMustBeGreaterThan', N'يجب أن تكون القيمة المُدخلة في الحقل {fieldName1} أكبر من {fieldName2}.', N'خطأ'),
('MsgMustSelectFromList', N'عذراً، يجب اختيار {selectionName} من القائمة. لا يُسمح بالقيم الفارغة.', N'خطأ'),
('MsgNegativeDaysPresent', N'تم العثور على أيام سالبة في السطر {lineNumber}. يرجى تصحيح الخطأ قبل الحفظ.', N'خطأ'),
('MsgNegativeValNotAllowed', N'لا يُسمح بالقيم السالبة للحقل {fieldName}. راجع السطر {lineNumber} وصحح الخطأ قبل الحفظ.', N'خطأ'),
('MsgNoAccessToSecurity', N'عذراً، لا تملك صلاحية {securityKey}.', N'خطأ'),
('MsgNoApprovedQtySpecified', N'لم يتم تحديد الكمية المعتمدة لهذا الطلب، ولا يوجد شيء لاعتماده.', N'خطأ'),
('MsgNoChangesMadeNothingToSave', N'لم يتم إجراء أي تغييرات أو أن القيم الجديدة مطابقة للقيم الأصلية، لا يوجد شيء لحفظه!', N'لا يوجد شيء لحفظه'),
('MsgNoEarnedLeaves', N'عذراً، لا توجد للموظف حالياً إجازة مكتسبة من نوع {leaveName}. يجب أولاً تقديم إجازة مكتسبة من نوع {leaveName} واعتمادها قبل طلب هذه الإجازة.', N'خطأ'),
('MsgNoImageEntered', N'عذراً، لم يتم إدخال صورة لهذا المستند.', N'خطأ'),
('MsgNoLeavesToApprove', N'لا توجد إجازات مقدمة حالياً أو تم تنفيذ الإجراءات على جميع الإجازات المتاحة.', N'خطأ'),
('MsgNoMatchingRecordFound', N'لا توجد سجلات تطابق شرط الاستعلام!', N'تحذير'),
('MsgNonPostableEntry', N'عذراً، هذا قيد مخزون غير قابل للترحيل.', N'خطأ'),
('MsgNoPostOnWHouse', N'عذراً، لا تملك صلاحية الترحيل على المستودع المحدد.', N'خطأ'),
('MsgNoRecordsFound', N'لا توجد سجلات لهذا الجدول!', N'جدول فارغ'),
('MsgNoSelectedRecordToView', N'عذراً، لم يتم تحديد سجل لعرضه. يرجى تحديد سجل أولاً.', N'خطأ'),
('MsgNoSpecialAccount', N'عذراً، لا يوجد لديك حساب {specialAccountName}. انتقل إلى إدخال دليل الحسابات وعرّف حساباً واحداً على الأقل من نوع {specialAccountName}!', N'خطأ'),
('MsgNoSuchInventory', N'عذراً، لا يوجد هذا الصنف في المخزون الحالي. لا يمكنك خصم صنف غير موجود في المخزون!', N'خطأ'),
('MsgNotEnoughEarnedLeave', N'عذراً، طلب إجازة {leaveName} وعدده {noOfDaysRequested} يوماً أكبر من رصيد الإجازات المكتسبة {earnedLeaveDays} يوماً لهذا الموظف. خفّض عدد الأيام أو اكسب رصيداً إضافياً.', N'خطأ'),
('MsgNotEnoughLeave', N'عذراً، لا يوجد رصيد كافٍ لهذا النوع من الإجازة أو أن الأيام المطلوبة {noOfDaysApplied} تتجاوز الأيام المسموح بها {daysAllowed} لنوع الإجازة {leaveName}.', N'خطأ'),
('MsgNumeric0to255Only', N'يجب أن تكون القيمة المُدخلة للحقل {FieldName} بين 0 و255. ستتم إعادة القيمة السابقة.', N'إدخال غير صالح'),
('MsgNumericOverflow', N'الرقم {Number} المُدخل في الحقل {controlName} كبير جداً أو صغير جداً. يجب أن تكون القيمة بين {lowNumber} و{highNumber}.', N'خطأ'),
('MsgOldPasswordError', N'عذراً، كلمة المرور القديمة التي أدخلتها لا تطابق كلمة المرور المسجلة. يرجى المحاولة مرة أخرى.', N'خطأ'),
('MsgOneTimeLeaveOnly', N'عذراً، لقد استخدمت هذه الإجازة أو يوجد طلب قائم لها بالفعل. لا يمكن استخدام هذه الإجازة إلا مرة واحدة. راجع رقم الإجازة {leaveNumber}.', N'خطأ'),
('MsgOnlyNumbersAllowed', N'يجب أن يحتوي الحقل {FieldName} على أرقام فقط.', N'إدخال غير صالح'),
('MsgOvertimeInitializationCompleted', N'اكتملت تهيئة العمل الإضافي للرواتب!', N'اكتمل'),
('MsgPasswordNotSaved', N'لم يتم حفظ كلمة المرور.', N'خطأ'),
('MsgPasswordSaved', N'تم حفظ كلمة المرور الجديدة بنجاح.', N'نجاح'),
('MsgPaymentCollExistChangeNotAllowed', N'عذراً، تم تحصيل هذا الحساب المدين جزئياً أو كلياً أو تم أخذ خصم له. لا يُسمح بتغيير الحساب أو العميل، وستتم إعادة القيمة السابقة.', N'خطأ التعديل'),
('MsgPaymentDiscExistChangeNotAllowed', N'عذراً، تم دفع هذا الحساب الدائن جزئياً أو كلياً أو تم أخذ خصم له. لا يُسمح بتغيير الحساب أو المورد، وستتم إعادة القيمة السابقة.', N'خطأ التعديل'),
('MsgPaymentIsOverApplied', N'تم تطبيق الدفعة بأكثر من اللازم. زد مبلغ الدفعة أو خفّض الدفعات المطبقة.', N'معاملة غير صالحة'),
('MsgPaymentNotFullyApplied', N'لم تُطبّق الدفعة بالكامل بعد. لا يمكن حفظ القيد حتى يُطبّق المبلغ بالكامل.', N'معاملة غير صالحة'),
('MsgPayrollGenerationCompleted', N'اكتمل إنشاء الرواتب!', N'اكتمل'),
('MsgPostingAccountMustNotBeBlank', N'يرجى إدخال حساب الترحيل لهذا الاستحقاق.', N'إدخال مطلوب'),
('MsgReconciliationAlreadyPosted', N'تم ترحيل قيد المطابقة هذا بالفعل. لا يُسمح بالتعديل!', N'مطابقة مُرحّلة'),
('MsgRecordSuccessfullyDeleted', N'تم حذف السجل بنجاح.', N'تم حذف السجل'),
('MsgRecordSuccessfullyPosted', N'تم ترحيل السجل بنجاح!', N'ترحيل ناجح'),
('MsgRecordSuccessfullySaved', N'تم حفظ السجل بنجاح!', N'تم حفظ السجل'),
('MsgRecordSuccessfullyUpdated', N'تم تحديث السجل بنجاح!', N'تم تحديث السجل'),
('MsgRecordUpdateFail', N'فشل التحديث.', N'خطأ'),
('MsgRequiredField', N'عذراً، الحقل {fieldName} مطلوب!', N'إدخال غير صالح'),
('MsgRowDelExistNotAllowed', N'لا يُسمح بحذف الصفوف الموجودة!', N'خطأ الحذف'),
('MsgSameSourceNTargetWH', N'لا يمكن أن يكون مستودع التحويل المصدر والهدف متطابقين.', N'خطأ'),
('MsgSaveFirstBeforeGeneration', N'يرجى الحفظ أولاً قبل إنشاء الرواتب.', N'خطأ'),
('MsgSaveReconFirstBeforePosting', N'يرجى حفظ المطابقة أولاً قبل الترحيل!', N'توجد قيود غير محفوظة'),
('MsgSaveRecordFailed', N'حدث خطأ أثناء الحفظ، وفشل حفظ السجل.', N'خطأ التعديل'),
('MsgSeeTableEntry', N'راجع الإدخال في {tableName} برقم المعرّف #{idNumber}.', N'خطأ'),
('MsgSeeTransactionNumber', N'راجع رقم {transactionName} #{transactionNumber}.', N'خطأ'),
('MsgSelectedValueNotAllowed', N'عذراً، القيمة المحددة لـ {field1} غير مسموحة مع {field2} المحدد.', N'خطأ'),
('MsgSettingNotSet', N'عذراً، لم تقم بإعداد [{setupName}] في إعداد [{groupSetting}]!', N'إعداد غير صالح'),
('MsgSysEarnDelNotAllowed', N'هذا استحقاق محجوز للنظام، ولا يُسمح بحذفه!', N'خطأ'),
('MsgSysPayElementDelNotAllowed', N'هذا عنصر راتب محجوز للنظام، ولا يُسمح بحذفه!', N'خطأ'),
('MsgText2Short', N'نص البحث قصير جداً، ويجب أن يتكون من 3 أحرف على الأقل.', N'تحذير'),
('MsgTooManyFormsOpen', N'عدد النوافذ المفتوحة كبير جداً. يمكنك فتح {maxOpenForms} نافذة فقط في الوقت نفسه.', N'عدد نوافذ كبير'),
('MsgTotalApMismatch', N'عذراً، إجمالي الحساب الدائن في الرأس لا يطابق إجمالي تفاصيل الحساب الدائن!', N'إدخال غير صالح'),
('MsgTotalArMismatch', N'عذراً، إجمالي الحساب المدين في الرأس لا يطابق إجمالي تفاصيل الحساب المدين!', N'إدخال غير صالح'),
('MsgTotalErMismatch', N'عذراً، إجمالي قروض الموظفين في الرأس لا يطابق إجمالي تفاصيل قروض الموظفين!', N'إدخال غير صالح'),
('MsgTransactionDateClosed', N'تاريخ المعاملة المُدخل مغلق بالفعل، ولا يُسمح بمعاملة لهذا التاريخ.', N'خطأ'),
('MsgTvSelectionNotAllowed', N'عذراً، لا يمكنك تغيير التحديد أثناء وضع التعديل أو الإضافة. احفظ أو ألغِ التعديلات أولاً.', N'إجراء غير صالح'),
('MsgValueMustBeGreaterThan', N'يجب أن تكون القيمة المُدخلة في الحقل {fieldName1} أكبر من {fieldName2}.', N'خطأ'),
('MsgValueMustBeGreaterThanOrEqual', N'يجب أن تكون القيمة المُدخلة في الحقل {fieldName1} أكبر من أو تساوي {fieldName2}.', N'خطأ'),
('MsgValueMustBeLessThan', N'يجب أن تكون القيمة المُدخلة في الحقل {fieldName1} أقل من {fieldName2}.', N'خطأ'),
('MsgValueMustBeLessThanOrEqual', N'يجب أن تكون القيمة المُدخلة في الحقل {fieldName1} أقل من أو تساوي {fieldName2}.', N'خطأ'),
('MsgWareHouseToBlank', N'عذراً، لا يمكن أن يكون مستودع المصدر والهدف فارغين في طلب/تحويل المخزون.', N'خطأ');

DECLARE @OriginalDefaults TABLE
(
    MessageKey VARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL PRIMARY KEY,
    EnglishMessage VARCHAR(256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    EnglishCaption VARCHAR(128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
);

INSERT INTO @OriginalDefaults (MessageKey, EnglishMessage, EnglishCaption)
VALUES
('MsgRunPreviewBeforeExecution', 'Run Preview before executing posting.', 'Monthly Posting'),
('MsgConfirmMonthlyPosting', 'Post all valid journals for {month} {year}?', 'Confirm monthly posting'),
('MsgEnterChecklistNote', 'Enter a note before completing this checklist item.', 'Monthly Close Checklist'),
('MsgMonthlyCloseChecklistFailed', 'Checklist operation failed: {details}', 'Monthly Close Checklist'),
('MsgMonthApproved', 'Month approved. You may now run Monthly Posting.', 'Monthly Close'),
('MsgChecklistLoaded', 'Checklist loaded: {itemCount} items. Select an item and click Complete Item.', 'Monthly Close Checklist'),
('MsgMonthlyPostingStatus', 'Errors: {errors}; headers: {headers}; items: {items}; close status: {closeStatus}', 'Monthly Journal Posting'),
('MsgMonthlyPostingRequestFailed', 'Posting request failed: {details}', 'Monthly Posting'),
('MsgFiscalPostingStatus', 'Blocking errors: {errors}; headers to post: {headers}; items to post: {items}', 'Fiscal-Year Posting'),
('MsgConfirmFiscalYearPosting', 'This will mark all currently unposted journal headers and items in fiscal year {year} as Posted. The operation is audited and cannot be undone by this screen. Continue?', 'Confirm fiscal-year posting'),
('MsgFiscalPostingRequestFailed', 'Fiscal-year posting request failed: {details}', 'Fiscal-Year Posting'),
('MsgBlankAccountIdNotAllowed', 'Error in line <{lineNumber}>. Cannot save entries with debit/credit amounts when account ID is blank.', 'Invalid Entry'),
('MsgEditingOfReconciliationReviewNotAllowed', 'This transaction is included in a completed or finalized account reconciliation. Reopen the reconciliation review before editing or deleting it.', 'Error'),
('MsgHolidayAvailmentAlreadyActed', 'Sorry, this leave has already been acted upon. Change not allowed.', 'Error'),
('MsgSysPayElementDelNotAllowed', 'This is a system reserved pay element, deletion not allowed!', 'Error'),
('MsgCannotPostUnsaved', 'Please save the entry before posting.', 'Disallowed operation');

BEGIN TRANSACTION;

/* Add only the few message keys introduced by the recent code that are not
   present in older databases. */
INSERT INTO dbo.OriginalMessages (MessageKey, Message, Caption)
SELECT d.MessageKey, d.EnglishMessage, d.EnglishCaption
FROM @OriginalDefaults d
WHERE NOT EXISTS
(
    SELECT 1 FROM dbo.OriginalMessages om WHERE om.MessageKey = d.MessageKey
);

/* Fill blank English seed text for old placeholder rows, without replacing
   an existing message/caption. */
UPDATE om
SET om.Message = CASE WHEN NULLIF(LTRIM(RTRIM(om.Message)), '') IS NULL THEN d.EnglishMessage ELSE om.Message END,
    om.Caption = CASE WHEN NULLIF(LTRIM(RTRIM(om.Caption)), '') IS NULL THEN d.EnglishCaption ELSE om.Caption END
FROM dbo.OriginalMessages om
JOIN @OriginalDefaults d ON d.MessageKey = om.MessageKey;

/* Update every existing Arabic row that is blank, and insert missing rows. */
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

/* Captions used by the recently added monthly/fiscal posting and
   reconciliation screens.  BFMain also captures these automatically, but
   inserting them here makes the first Arabic display deterministic. */
DECLARE @Captions TABLE
(
    Caption NVARCHAR(1024) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    TranslatedCaption NVARCHAR(256) NOT NULL
);

INSERT INTO @Captions (Caption, TranslatedCaption)
VALUES
(N'Approve Month', N'اعتماد الشهر'),
(N'Cash Disbursement Journal', N'دفتر يومية المدفوعات النقدية'),
(N'Checklist load failed.', N'فشل تحميل قائمة التحقق.'),
(N'Checklist loaded: ', N'تم تحميل قائمة التحقق: '),
(N'Complete Item', N'إكمال البند'),
(N'Complete Review', N'إكمال المراجعة'),
(N'Execute Posting', N'تنفيذ الترحيل'),
(N'Fiscal-Year Posting', N'ترحيل السنة المالية'),
(N'Approved', N'معتمد'),
(N'Not approved', N'غير معتمد'),
(N'FiscalYear    FiscalMonth    Status    ChecklistCode    Completed    CompletedBy    CompletedAt    Notes', N'السنة المالية    الشهر المالي    الحالة    رمز قائمة التحقق    مكتمل    أتمه    تاريخ الإكمال    الملاحظات'),
(N'JournalCode    Headers    HeadersToPost    EmptyHeaders    Items    ItemsToPost    ZeroAmountItems    CancelledHeaders    Debit    Credit', N'رمز اليومية    الرؤوس    رؤوس للترحيل    رؤوس فارغة    البنود    بنود للترحيل    بنود بصفر    رؤوس ملغاة    مدين    دائن'),
(N'Load Checklist', N'تحميل قائمة التحقق'),
(N'Month:', N'الشهر:'),
(N'Monthly Close', N'إغلاق الشهر'),
(N'Monthly Close Checklist', N'قائمة تحقق إغلاق الشهر'),
(N'Monthly Journal Posting', N'ترحيل اليومية الشهري'),
(N'No validation summary was returned.', N'لم يتم إرجاع ملخص للتحقق.'),
(N'Notes for selected checklist item:', N'ملاحظات بند قائمة التحقق المحدد:'),
(N'Petty Cash Disbursement Journal', N'دفتر يومية المدفوعات من العهدة النثرية'),
(N'Posting completed. Run Preview again to verify the final state.', N'اكتمل الترحيل. شغّل المعاينة مرة أخرى للتحقق من الحالة النهائية.'),
(N'Posting completed. Run Preview again to verify.', N'اكتمل الترحيل. شغّل المعاينة مرة أخرى للتحقق.'),
(N'Posting request failed.', N'فشل طلب الترحيل.'),
(N'Preview', N'معاينة'),
(N'Preview is required before execution.', N'يجب تشغيل المعاينة قبل التنفيذ.'),
(N'Reopen Review', N'إعادة فتح المراجعة'),
(N'Run Preview before executing posting.', N'شغّل المعاينة قبل تنفيذ الترحيل.'),
(N'Confirm monthly posting', N'تأكيد الترحيل الشهري'),
(N'Confirm fiscal-year posting', N'تأكيد ترحيل السنة المالية'),
(N'Monthly Posting', N'الترحيل الشهري'),
(N'Result set', N'مجموعة النتائج'),
(N'Year:', N'السنة:'),
(N'Journal batches', N'دفعات اليومية'),
(N'Close checklist', N'قائمة تحقق الإغلاق'),
(N'Validation details', N'تفاصيل التحقق');

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

COMMIT TRANSACTION;

SELECT COUNT(*) AS ArabicMessageRowsSeeded
FROM dbo.TranslatedMessages tm
JOIN dbo.Languages l ON l.IdNo = tm.LanguageIdNo
WHERE l.CultureInfoCode = 'ar-SA';

SELECT COUNT(*) AS ArabicCaptionRowsSeeded
FROM dbo.TranslatedCaption tc
JOIN dbo.Languages l ON l.IdNo = tc.LanguageIdNo
WHERE l.CultureInfoCode = 'ar-SA';

SELECT
    SUM(CASE WHEN NULLIF(LTRIM(RTRIM(tm.TranslatedMessage)), N'') IS NULL THEN 1 ELSE 0 END) AS SeededKeysStillMissingMessage,
    SUM(CASE WHEN NULLIF(LTRIM(RTRIM(tm.TranslatedCaption)), N'') IS NULL THEN 1 ELSE 0 END) AS SeededKeysStillMissingCaption
FROM @Messages m
JOIN dbo.OriginalMessages om ON om.MessageKey = m.MessageKey
LEFT JOIN dbo.TranslatedMessages tm
    ON tm.MessageIdNo = om.IdNo AND tm.LanguageIdNo = @LanguageIdNo;

SELECT
    SUM(CASE WHEN NULLIF(LTRIM(RTRIM(tc.TranslatedCaption)), N'') IS NULL THEN 1 ELSE 0 END) AS SeededCaptionsStillMissingArabic
FROM @Captions c
JOIN dbo.OriginalCaptions oc ON oc.Caption = c.Caption
LEFT JOIN dbo.TranslatedCaption tc
    ON tc.CaptionIdNo = oc.IdNo AND tc.LanguageIdNo = @LanguageIdNo;
