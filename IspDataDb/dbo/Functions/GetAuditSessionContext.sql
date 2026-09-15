CREATE FUNCTION [dbo].[GetAuditSessionContext]()
RETURNS TABLE
AS
RETURN
(
    SELECT [UserIdNo], [UserNameSnapshot], [BranchIdNo], [ApplicationName], [MachineName]
    FROM [dbo].[AuditSessionContext]
    WHERE [SessionId] = @@SPID
      AND [SqlLoginName] = SUSER_SNAME()
      AND [ClientHostName] = HOST_NAME()
      AND [ClientApplicationName] = APP_NAME()
    UNION ALL
    SELECT CAST(NULL AS SMALLINT), CONVERT(NVARCHAR(100), ORIGINAL_LOGIN()), CAST(NULL AS SMALLINT),
        CONVERT(NVARCHAR(128), APP_NAME()), CONVERT(NVARCHAR(128), HOST_NAME())
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM [dbo].[AuditSessionContext]
        WHERE [SessionId] = @@SPID
          AND [SqlLoginName] = SUSER_SNAME()
          AND [ClientHostName] = HOST_NAME()
          AND [ClientApplicationName] = APP_NAME()
    )
);
