CREATE PROCEDURE [dbo].[SetAuditSessionContext]
    @UserIdNo           SMALLINT = NULL,
    @UserNameSnapshot   NVARCHAR (100) = NULL,
    @BranchIdNo         SMALLINT = NULL,
    @ApplicationName    NVARCHAR (128) = NULL,
    @MachineName        NVARCHAR (128) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[AuditSessionContext]
    SET [UserIdNo] = @UserIdNo,
        [UserNameSnapshot] = @UserNameSnapshot,
        [BranchIdNo] = @BranchIdNo,
        [ApplicationName] = @ApplicationName,
        [MachineName] = @MachineName,
        [UpdatedAt] = SYSUTCDATETIME()
    WHERE [SessionId] = @@SPID;

    IF @@ROWCOUNT = 0
    BEGIN
        INSERT INTO [dbo].[AuditSessionContext]
        ([SessionId], [UserIdNo], [UserNameSnapshot], [BranchIdNo], [ApplicationName], [MachineName])
        VALUES
        (@@SPID, @UserIdNo, @UserNameSnapshot, @BranchIdNo, @ApplicationName, @MachineName);
    END;
END;
