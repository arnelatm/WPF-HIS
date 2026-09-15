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
        [SqlLoginName] = SUSER_SNAME(),
        [ClientHostName] = HOST_NAME(),
        [ClientApplicationName] = APP_NAME(),
        [ClientIpAddress] = CONVERT(VARCHAR(48), CONNECTIONPROPERTY('client_net_address')),
        [UpdatedAt] = SYSUTCDATETIME()
    WHERE [SessionId] = @@SPID;

    IF @@ROWCOUNT = 0
    BEGIN
        INSERT INTO [dbo].[AuditSessionContext]
        ([SessionId], [UserIdNo], [UserNameSnapshot], [BranchIdNo], [ApplicationName], [MachineName],
         [SqlLoginName], [ClientHostName], [ClientApplicationName], [ClientIpAddress])
        VALUES
        (@@SPID, @UserIdNo, @UserNameSnapshot, @BranchIdNo, @ApplicationName, @MachineName,
         SUSER_SNAME(), HOST_NAME(), APP_NAME(), CONVERT(VARCHAR(48), CONNECTIONPROPERTY('client_net_address')));
    END;
END;
