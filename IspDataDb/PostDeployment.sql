SET NOCOUNT ON;
SET XACT_ABORT ON;

BEGIN TRY
    BEGIN TRANSACTION;

    INSERT INTO dbo.Contact (CSEIdNo, CSECode)
    SELECT e.IdNo, 'E'
    FROM dbo.Employee AS e
    WHERE NOT EXISTS (
        SELECT 1
        FROM dbo.Contact AS c WITH (UPDLOCK, HOLDLOCK)
        WHERE c.CSECode = 'E'
          AND c.CSEIdNo = e.IdNo
    );

    INSERT INTO dbo.Contact (CSEIdNo, CSECode)
    SELECT s.IdNo, 'S'
    FROM dbo.Supplier AS s
    WHERE NOT EXISTS (
        SELECT 1
        FROM dbo.Contact AS c WITH (UPDLOCK, HOLDLOCK)
        WHERE c.CSECode = 'S'
          AND c.CSEIdNo = s.IdNo
    );

    INSERT INTO dbo.Contact (CSEIdNo, CSECode)
    SELECT cst.IdNo, 'C'
    FROM dbo.Customer AS cst
    WHERE NOT EXISTS (
        SELECT 1
        FROM dbo.Contact AS c WITH (UPDLOCK, HOLDLOCK)
        WHERE c.CSECode = 'C'
          AND c.CSEIdNo = cst.IdNo
    );

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
    THROW;
END CATCH;
