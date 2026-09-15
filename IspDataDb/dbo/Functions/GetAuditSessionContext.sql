CREATE FUNCTION [dbo].[GetAuditSessionContext]()
RETURNS TABLE
AS
RETURN
(
    SELECT [UserIdNo], [UserNameSnapshot], [BranchIdNo], [ApplicationName], [MachineName]
    FROM [dbo].[AuditSessionContext]
    WHERE [SessionId] = @@SPID
    UNION ALL
    SELECT CAST(NULL AS SMALLINT), CAST(NULL AS NVARCHAR(100)), CAST(NULL AS SMALLINT),
        CAST(NULL AS NVARCHAR(128)), CAST(NULL AS NVARCHAR(128))
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM [dbo].[AuditSessionContext]
        WHERE [SessionId] = @@SPID
    )
);
