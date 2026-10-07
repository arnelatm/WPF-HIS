-- One-time historical journal cleanup for IBN-SERVER.ISPDATA.
-- Leave November 2025 onward for the monthly posting workflow.
SET NOCOUNT ON;
SET XACT_ABORT ON;
SET LOCK_TIMEOUT 15000;

IF CONVERT(sysname, SERVERPROPERTY('ServerName')) <> N'IBN-SERVER' OR DB_NAME() <> N'ISPDATA'
    THROW 52530, 'This cleanup is only for IBN-SERVER.ISPDATA.', 1;

DECLARE @Expected table (JournalCode char(2), HeaderTable sysname, ItemTable sysname,
    Orphans int, EmptyHeaders int, UnpostedEmptyHeaders int, HeadersToPost int, ItemsToPost int);
INSERT @Expected VALUES
('AP','ApJournal','ApJournalItem',0,9,0,1157,2635),
('AR','ArJournal','ArJournalItem',0,0,0,638,3279),
('CD','CdJournal','CdJournalItem',0,41,7,4811,11672),
('CK','CkJournal','CkJournalItem',0,0,0,0,0),
('CR','CashReceiptJournal','CashReceiptJournalItem',0,2,0,445,913),
('ER','ErJournal','ErJournalItem',28,0,0,179,358),
('GJ','GeneralJournal','GeneralJournalItem',6,64,4,267,3113),
('PC','PcJournal','PcJournalItem',8,11,11,7549,19725),
('SJ','SalesJournal','SalesJournalItem',0,0,0,1841,17996);

DECLARE @Result table (JournalCode char(2), OrphansDeleted int, EmptyHeadersDeleted int,
    HeadersPosted int, ItemsPosted int);
DECLARE @Code char(2), @Header sysname, @Item sysname, @Sql nvarchar(max);
DECLARE @ExpectedOrphans int, @ExpectedEmpty int, @ExpectedUnpostedEmpty int, @ExpectedHeaders int, @ExpectedItems int;
DECLARE @Orphans int, @Empty int, @UnpostedEmpty int, @Headers int, @Items int;
DECLARE @OrphansDeleted int, @EmptyDeleted int, @HeadersPosted int, @ItemsPosted int;

BEGIN TRY
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    BEGIN TRANSACTION;

    DECLARE journal_cursor CURSOR LOCAL FAST_FORWARD FOR
        SELECT JournalCode, HeaderTable, ItemTable, Orphans, EmptyHeaders, UnpostedEmptyHeaders, HeadersToPost, ItemsToPost
        FROM @Expected ORDER BY JournalCode;
    OPEN journal_cursor;
    FETCH NEXT FROM journal_cursor INTO @Code, @Header, @Item,
        @ExpectedOrphans, @ExpectedEmpty, @ExpectedUnpostedEmpty, @ExpectedHeaders, @ExpectedItems;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @Sql = N'SELECT
            @Orphans = (SELECT COUNT(*) FROM dbo.' + QUOTENAME(@Item) + N' i
                WHERE NOT EXISTS (SELECT 1 FROM dbo.' + QUOTENAME(@Header) + N' h WHERE h.IdNo = i.JournalIdNo)),
            @Empty = (SELECT COUNT(*) FROM dbo.' + QUOTENAME(@Header) + N' h
                WHERE h.TransactionDate < ''20260101'' AND NOT EXISTS
                    (SELECT 1 FROM dbo.' + QUOTENAME(@Item) + N' i WHERE i.JournalIdNo = h.IdNo)),
            @UnpostedEmpty = (SELECT COUNT(*) FROM dbo.' + QUOTENAME(@Header) + N' h
                WHERE h.TransactionDate < ''20251101'' AND ISNULL(h.Posted, 0) = 0 AND NOT EXISTS
                    (SELECT 1 FROM dbo.' + QUOTENAME(@Item) + N' i WHERE i.JournalIdNo = h.IdNo)),
            @Headers = (SELECT COUNT(*) FROM dbo.' + QUOTENAME(@Header) + N' h
                WHERE h.TransactionDate < ''20251101'' AND ISNULL(h.Posted, 0) = 0),
            @Items = (SELECT COUNT(*) FROM dbo.' + QUOTENAME(@Item) + N' i
                INNER JOIN dbo.' + QUOTENAME(@Header) + N' h ON h.IdNo = i.JournalIdNo
                WHERE h.TransactionDate < ''20251101'' AND i.Posted = 0);';
        EXEC sys.sp_executesql @Sql,
            N'@Orphans int OUTPUT, @Empty int OUTPUT, @UnpostedEmpty int OUTPUT, @Headers int OUTPUT, @Items int OUTPUT',
            @Orphans OUTPUT, @Empty OUTPUT, @UnpostedEmpty OUTPUT, @Headers OUTPUT, @Items OUTPUT;
        IF @Orphans <> @ExpectedOrphans OR @Empty <> @ExpectedEmpty
           OR @UnpostedEmpty <> @ExpectedUnpostedEmpty OR @Headers <> @ExpectedHeaders OR @Items <> @ExpectedItems
            THROW 52531, 'Journal cleanup counts changed; no changes were committed.', 1;

        SET @Sql = N'DELETE i FROM dbo.' + QUOTENAME(@Item) + N' i
            WHERE NOT EXISTS (SELECT 1 FROM dbo.' + QUOTENAME(@Header) + N' h WHERE h.IdNo = i.JournalIdNo);
            SET @OrphansDeleted = @@ROWCOUNT;
            DELETE h FROM dbo.' + QUOTENAME(@Header) + N' h
            WHERE h.TransactionDate < ''20260101'' AND NOT EXISTS
                (SELECT 1 FROM dbo.' + QUOTENAME(@Item) + N' i WHERE i.JournalIdNo = h.IdNo);
            SET @EmptyDeleted = @@ROWCOUNT;
            UPDATE i SET Posted = 1 FROM dbo.' + QUOTENAME(@Item) + N' i
            INNER JOIN dbo.' + QUOTENAME(@Header) + N' h ON h.IdNo = i.JournalIdNo
            WHERE h.TransactionDate < ''20251101'' AND i.Posted = 0;
            SET @ItemsPosted = @@ROWCOUNT;
            UPDATE h SET Posted = 1 FROM dbo.' + QUOTENAME(@Header) + N' h
            WHERE h.TransactionDate < ''20251101'' AND ISNULL(h.Posted, 0) = 0;
            SET @HeadersPosted = @@ROWCOUNT;';
        EXEC sys.sp_executesql @Sql,
            N'@OrphansDeleted int OUTPUT, @EmptyDeleted int OUTPUT, @ItemsPosted int OUTPUT, @HeadersPosted int OUTPUT',
            @OrphansDeleted OUTPUT, @EmptyDeleted OUTPUT, @ItemsPosted OUTPUT, @HeadersPosted OUTPUT;
        IF @OrphansDeleted <> @ExpectedOrphans OR @EmptyDeleted <> @ExpectedEmpty
           OR @HeadersPosted <> @ExpectedHeaders - @ExpectedUnpostedEmpty OR @ItemsPosted <> @ExpectedItems
            THROW 52532, 'Journal cleanup row counts did not match; no changes were committed.', 1;
        INSERT @Result VALUES (@Code, @OrphansDeleted, @EmptyDeleted, @HeadersPosted, @ItemsPosted);
        FETCH NEXT FROM journal_cursor INTO @Code, @Header, @Item,
            @ExpectedOrphans, @ExpectedEmpty, @ExpectedUnpostedEmpty, @ExpectedHeaders, @ExpectedItems;
    END;
    CLOSE journal_cursor;
    DEALLOCATE journal_cursor;

    COMMIT TRANSACTION;
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
    SELECT * FROM @Result ORDER BY JournalCode;
END TRY
BEGIN CATCH
    IF CURSOR_STATUS('local', 'journal_cursor') >= 0 CLOSE journal_cursor;
    IF CURSOR_STATUS('local', 'journal_cursor') >= -1 DEALLOCATE journal_cursor;
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
    THROW;
END CATCH;
