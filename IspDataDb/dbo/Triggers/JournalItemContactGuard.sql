CREATE TRIGGER [dbo].[ApJournalItem_ContactGuard]
ON [dbo].[ApJournalItem]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Posting and other status-only updates to historical lines are unaffected.
    IF NOT (UPDATE(AccountIdNo) OR UPDATE(PayIdNo) OR UPDATE(Debit) OR UPDATE(Credit))
        RETURN;

    IF EXISTS (
        SELECT 1
        FROM inserted AS i
        LEFT JOIN deleted AS d ON d.IdNo = i.IdNo
        WHERE (d.IdNo IS NULL
            OR i.AccountIdNo <> d.AccountIdNo
            OR ISNULL(i.PayIdNo, 0) <> ISNULL(d.PayIdNo, 0)
            OR i.Debit <> d.Debit
            OR i.Credit <> d.Credit)
          AND dbo.FnJournalItemContactIsValid(i.AccountIdNo, i.PayIdNo, i.Debit, i.Credit) = 0
    )
        THROW 51920, 'AP, AR, and employee-loan lines require a valid contact of the account party type.', 1;
END;
GO

CREATE TRIGGER [dbo].[ArJournalItem_ContactGuard]
ON [dbo].[ArJournalItem]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Posting and other status-only updates to historical lines are unaffected.
    IF NOT (UPDATE(AccountIdNo) OR UPDATE(PayIdNo) OR UPDATE(Debit) OR UPDATE(Credit))
        RETURN;

    IF EXISTS (
        SELECT 1
        FROM inserted AS i
        LEFT JOIN deleted AS d ON d.IdNo = i.IdNo
        WHERE (d.IdNo IS NULL
            OR i.AccountIdNo <> d.AccountIdNo
            OR ISNULL(i.PayIdNo, 0) <> ISNULL(d.PayIdNo, 0)
            OR i.Debit <> d.Debit
            OR i.Credit <> d.Credit)
          AND dbo.FnJournalItemContactIsValid(i.AccountIdNo, i.PayIdNo, i.Debit, i.Credit) = 0
    )
        THROW 51920, 'AP, AR, and employee-loan lines require a valid contact of the account party type.', 1;
END;
GO

CREATE TRIGGER [dbo].[ErJournalItem_ContactGuard]
ON [dbo].[ErJournalItem]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Posting and other status-only updates to historical lines are unaffected.
    IF NOT (UPDATE(AccountIdNo) OR UPDATE(PayIdNo) OR UPDATE(Debit) OR UPDATE(Credit))
        RETURN;

    IF EXISTS (
        SELECT 1
        FROM inserted AS i
        LEFT JOIN deleted AS d ON d.IdNo = i.IdNo
        WHERE (d.IdNo IS NULL
            OR i.AccountIdNo <> d.AccountIdNo
            OR ISNULL(i.PayIdNo, 0) <> ISNULL(d.PayIdNo, 0)
            OR i.Debit <> d.Debit
            OR i.Credit <> d.Credit)
          AND dbo.FnJournalItemContactIsValid(i.AccountIdNo, i.PayIdNo, i.Debit, i.Credit) = 0
    )
        THROW 51920, 'AP, AR, and employee-loan lines require a valid contact of the account party type.', 1;
END;
GO

CREATE TRIGGER [dbo].[GeneralJournalItem_ContactGuard]
ON [dbo].[GeneralJournalItem]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Posting and other status-only updates to historical lines are unaffected.
    IF NOT (UPDATE(AccountIdNo) OR UPDATE(PayIdNo) OR UPDATE(Debit) OR UPDATE(Credit))
        RETURN;

    IF EXISTS (
        SELECT 1
        FROM inserted AS i
        LEFT JOIN deleted AS d ON d.IdNo = i.IdNo
        WHERE (d.IdNo IS NULL
            OR i.AccountIdNo <> d.AccountIdNo
            OR ISNULL(i.PayIdNo, 0) <> ISNULL(d.PayIdNo, 0)
            OR i.Debit <> d.Debit
            OR i.Credit <> d.Credit)
          AND dbo.FnJournalItemContactIsValid(i.AccountIdNo, i.PayIdNo, i.Debit, i.Credit) = 0
    )
        THROW 51920, 'AP, AR, and employee-loan lines require a valid contact of the account party type.', 1;
END;
GO

CREATE TRIGGER [dbo].[CashReceiptJournalItem_ContactGuard]
ON [dbo].[CashReceiptJournalItem]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Posting and other status-only updates to historical lines are unaffected.
    IF NOT (UPDATE(AccountIdNo) OR UPDATE(PayIdNo) OR UPDATE(Debit) OR UPDATE(Credit))
        RETURN;

    IF EXISTS (
        SELECT 1
        FROM inserted AS i
        LEFT JOIN deleted AS d ON d.IdNo = i.IdNo
        WHERE (d.IdNo IS NULL
            OR i.AccountIdNo <> d.AccountIdNo
            OR ISNULL(i.PayIdNo, 0) <> ISNULL(d.PayIdNo, 0)
            OR i.Debit <> d.Debit
            OR i.Credit <> d.Credit)
          AND dbo.FnJournalItemContactIsValid(i.AccountIdNo, i.PayIdNo, i.Debit, i.Credit) = 0
    )
        THROW 51920, 'AP, AR, and employee-loan lines require a valid contact of the account party type.', 1;
END;
GO

CREATE TRIGGER [dbo].[CdJournalItem_ContactGuard]
ON [dbo].[CdJournalItem]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Posting and other status-only updates to historical lines are unaffected.
    IF NOT (UPDATE(AccountIdNo) OR UPDATE(PayIdNo) OR UPDATE(Debit) OR UPDATE(Credit))
        RETURN;

    IF EXISTS (
        SELECT 1
        FROM inserted AS i
        LEFT JOIN deleted AS d ON d.IdNo = i.IdNo
        WHERE (d.IdNo IS NULL
            OR i.AccountIdNo <> d.AccountIdNo
            OR ISNULL(i.PayIdNo, 0) <> ISNULL(d.PayIdNo, 0)
            OR i.Debit <> d.Debit
            OR i.Credit <> d.Credit)
          AND dbo.FnJournalItemContactIsValid(i.AccountIdNo, i.PayIdNo, i.Debit, i.Credit) = 0
    )
        THROW 51920, 'AP, AR, and employee-loan lines require a valid contact of the account party type.', 1;
END;
GO

CREATE TRIGGER [dbo].[PcJournalItem_ContactGuard]
ON [dbo].[PcJournalItem]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Posting and other status-only updates to historical lines are unaffected.
    IF NOT (UPDATE(AccountIdNo) OR UPDATE(PayIdNo) OR UPDATE(Debit) OR UPDATE(Credit))
        RETURN;

    IF EXISTS (
        SELECT 1
        FROM inserted AS i
        LEFT JOIN deleted AS d ON d.IdNo = i.IdNo
        WHERE (d.IdNo IS NULL
            OR i.AccountIdNo <> d.AccountIdNo
            OR ISNULL(i.PayIdNo, 0) <> ISNULL(d.PayIdNo, 0)
            OR i.Debit <> d.Debit
            OR i.Credit <> d.Credit)
          AND dbo.FnJournalItemContactIsValid(i.AccountIdNo, i.PayIdNo, i.Debit, i.Credit) = 0
    )
        THROW 51920, 'AP, AR, and employee-loan lines require a valid contact of the account party type.', 1;
END;
GO

CREATE TRIGGER [dbo].[CkJournalItem_ContactGuard]
ON [dbo].[CkJournalItem]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Posting and other status-only updates to historical lines are unaffected.
    IF NOT (UPDATE(AccountIdNo) OR UPDATE(PayIdNo) OR UPDATE(Debit) OR UPDATE(Credit))
        RETURN;

    IF EXISTS (
        SELECT 1
        FROM inserted AS i
        LEFT JOIN deleted AS d ON d.IdNo = i.IdNo
        WHERE (d.IdNo IS NULL
            OR i.AccountIdNo <> d.AccountIdNo
            OR ISNULL(i.PayIdNo, 0) <> ISNULL(d.PayIdNo, 0)
            OR i.Debit <> d.Debit
            OR i.Credit <> d.Credit)
          AND dbo.FnJournalItemContactIsValid(i.AccountIdNo, i.PayIdNo, i.Debit, i.Credit) = 0
    )
        THROW 51920, 'AP, AR, and employee-loan lines require a valid contact of the account party type.', 1;
END;
GO

CREATE TRIGGER [dbo].[SalesJournalItem_ContactGuard]
ON [dbo].[SalesJournalItem]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Posting and other status-only updates to historical lines are unaffected.
    IF NOT (UPDATE(AccountIdNo) OR UPDATE(PayIdNo) OR UPDATE(Debit) OR UPDATE(Credit))
        RETURN;

    IF EXISTS (
        SELECT 1
        FROM inserted AS i
        LEFT JOIN deleted AS d ON d.IdNo = i.IdNo
        WHERE (d.IdNo IS NULL
            OR i.AccountIdNo <> d.AccountIdNo
            OR ISNULL(i.PayIdNo, 0) <> ISNULL(d.PayIdNo, 0)
            OR i.Debit <> d.Debit
            OR i.Credit <> d.Credit)
          AND dbo.FnJournalItemContactIsValid(i.AccountIdNo, i.PayIdNo, i.Debit, i.Credit) = 0
    )
        THROW 51920, 'AP, AR, and employee-loan lines require a valid contact of the account party type.', 1;
END;
GO
