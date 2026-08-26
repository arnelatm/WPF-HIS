/*
    Arabic (ar-SA) translation for the account-reconciliation duplicate guard.

    This is application data, not schema. Run it after the Accounts build has
    registered the English message in dbo.OriginalMessages, or let this script
    register the message itself. It is idempotent.
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

DECLARE @MessageKey VARCHAR(50) = 'MsgDuplicateReconciliationForAccountDate';
DECLARE @MessageIdNo SMALLINT;

SELECT @MessageIdNo = IdNo
FROM dbo.OriginalMessages
WHERE MessageKey = @MessageKey;

IF @MessageIdNo IS NULL
BEGIN
    INSERT INTO dbo.OriginalMessages (MessageKey, Message, Caption)
    VALUES
    (
        @MessageKey,
        'An account reconciliation already exists for this account and date (reconciliation no. {reconciliationNumber}). Open it or delete it before creating another.',
        'Duplicate Account Reconciliation'
    );

    SET @MessageIdNo = CONVERT(SMALLINT, SCOPE_IDENTITY());
END;

IF EXISTS
(
    SELECT 1
    FROM dbo.TranslatedMessages
    WHERE MessageIdNo = @MessageIdNo
      AND LanguageIdNo = @LanguageIdNo
)
BEGIN
    UPDATE dbo.TranslatedMessages
       SET TranslatedMessage = N'توجد مطابقة حساب لهذا الحساب والتاريخ بالفعل (رقم المطابقة {reconciliationNumber}). افتحها أو احذفها قبل إنشاء مطابقة أخرى.',
           TranslatedCaption = N'مطابقة حساب مكررة'
     WHERE MessageIdNo = @MessageIdNo
       AND LanguageIdNo = @LanguageIdNo;
END
ELSE
BEGIN
    INSERT INTO dbo.TranslatedMessages
        (MessageIdNo, LanguageIdNo, TranslatedMessage, TranslatedCaption)
    VALUES
        (@MessageIdNo, @LanguageIdNo,
         N'توجد مطابقة حساب لهذا الحساب والتاريخ بالفعل (رقم المطابقة {reconciliationNumber}). افتحها أو احذفها قبل إنشاء مطابقة أخرى.',
         N'مطابقة حساب مكررة');
END;

DECLARE @DraftMessageKey VARCHAR(50) = 'MsgPreviousDraftReconciliationExists';
DECLARE @DraftMessageIdNo SMALLINT;

SELECT @DraftMessageIdNo = IdNo
FROM dbo.OriginalMessages
WHERE MessageKey = @DraftMessageKey;

IF @DraftMessageIdNo IS NULL
BEGIN
    INSERT INTO dbo.OriginalMessages (MessageKey, Message, Caption)
    VALUES
    (
        @DraftMessageKey,
        'An earlier Draft reconciliation exists for this account. Complete, delete, or abandon it before starting a later reconciliation.',
        'Open Draft Reconciliation'
    );

    SET @DraftMessageIdNo = CONVERT(SMALLINT, SCOPE_IDENTITY());
END;

IF EXISTS
(
    SELECT 1
    FROM dbo.TranslatedMessages
    WHERE MessageIdNo = @DraftMessageIdNo
      AND LanguageIdNo = @LanguageIdNo
)
BEGIN
    UPDATE dbo.TranslatedMessages
       SET TranslatedMessage = N'توجد مطابقة حساب سابقة بحالة مسودة لهذا الحساب. أكملها أو احذفها أو تخلَّ عنها قبل بدء مطابقة لاحقة.',
           TranslatedCaption = N'مطابقة حساب مسودة مفتوحة'
     WHERE MessageIdNo = @DraftMessageIdNo
       AND LanguageIdNo = @LanguageIdNo;
END
ELSE
BEGIN
    INSERT INTO dbo.TranslatedMessages
        (MessageIdNo, LanguageIdNo, TranslatedMessage, TranslatedCaption)
    VALUES
        (@DraftMessageIdNo, @LanguageIdNo,
         N'توجد مطابقة حساب سابقة بحالة مسودة لهذا الحساب. أكملها أو احذفها أو تخلَّ عنها قبل بدء مطابقة لاحقة.',
         N'مطابقة حساب مسودة مفتوحة');
END;
