-- Trial-only permission setup for monthly posting approval.
-- Financial Manager (21) approves; Accountant (8) retains preparation/posting access.
SET NOCOUNT ON;
SET XACT_ABORT ON;

IF CONVERT(sysname, SERVERPROPERTY('ServerName')) <> N'ISPADMIN2' OR DB_NAME() <> N'ISPDATA'
    THROW 52520, 'This permission setup is only for ISPADMIN2.ISPDATA.', 1;

BEGIN TRY
    BEGIN TRANSACTION;

    IF NOT EXISTS (SELECT 1 FROM dbo.SecurityObject WHERE IdNo = 1272 AND SecurityObjectName = 'MonthlyPosting')
        THROW 52521, 'The MonthlyPosting security object was not found.', 1;
    IF NOT EXISTS (SELECT 1 FROM dbo.SecurityGroup WHERE IdNo = 21 AND SecurityGroupName = 'Financial Manager')
        THROW 52522, 'The Financial Manager security group was not found.', 1;

    IF NOT EXISTS (SELECT 1 FROM dbo.SecurityObject WHERE SecurityObjectName = 'ApproveMonthlyPosting')
        INSERT dbo.SecurityObject (SecurityObjectName, ParentIdNo, SystemViewIdNo, ManuallyAdded, Notes)
        VALUES ('ApproveMonthlyPosting', 1272, 3177, 1, 'Permission to approve the monthly journal posting checklist.');

    DECLARE @ApprovalSecurityObjectIdNo int;
    SELECT @ApprovalSecurityObjectIdNo = MIN(IdNo)
    FROM dbo.SecurityObject WHERE SecurityObjectName = 'ApproveMonthlyPosting';
    IF (SELECT COUNT(*) FROM dbo.SecurityObject WHERE SecurityObjectName = 'ApproveMonthlyPosting') <> 1
        THROW 52523, 'The monthly approval security object must be unique.', 1;

    -- The Financial Manager needs access to the monthly posting screen to approve.
    IF EXISTS (SELECT 1 FROM dbo.GroupAccess WHERE SecurityGroupIDNo = 21 AND SecurityObjectIDNo = 1272)
        UPDATE dbo.GroupAccess SET Visible = 1, Editable = 1
        WHERE SecurityGroupIDNo = 21 AND SecurityObjectIDNo = 1272;
    ELSE
        INSERT dbo.GroupAccess (SecurityGroupIDNo, SecurityObjectIDNo, Visible, Editable)
        VALUES (21, 1272, 1, 1);

    -- Administrators and Financial Managers can approve; Accountants cannot.
    INSERT dbo.GroupAccess (SecurityGroupIDNo, SecurityObjectIDNo, Visible, Editable)
    SELECT approver.SecurityGroupIDNo, @ApprovalSecurityObjectIdNo, 1, 1
    FROM (VALUES (1),(21)) AS approver(SecurityGroupIDNo)
    WHERE NOT EXISTS (
        SELECT 1 FROM dbo.GroupAccess ga
        WHERE ga.SecurityGroupIDNo = approver.SecurityGroupIDNo
          AND ga.SecurityObjectIDNo = @ApprovalSecurityObjectIdNo
    );
    UPDATE dbo.GroupAccess SET Visible = 1, Editable = 1
    WHERE SecurityObjectIDNo = @ApprovalSecurityObjectIdNo AND SecurityGroupIDNo IN (1, 21);

    IF EXISTS (
        SELECT 1 FROM dbo.GroupAccess
        WHERE SecurityObjectIDNo = @ApprovalSecurityObjectIdNo AND SecurityGroupIDNo = 8
    ) THROW 52524, 'Accountant approval access must be reviewed separately.', 1;

    COMMIT TRANSACTION;
    SELECT so.SecurityObjectName, sg.SecurityGroupName, ga.Visible, ga.Editable
    FROM dbo.GroupAccess ga
    INNER JOIN dbo.SecurityObject so ON so.IdNo = ga.SecurityObjectIDNo
    INNER JOIN dbo.SecurityGroup sg ON sg.IdNo = ga.SecurityGroupIDNo
    WHERE so.SecurityObjectName = 'ApproveMonthlyPosting'
    ORDER BY sg.IdNo;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;
