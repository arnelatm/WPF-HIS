CREATE PROCEDURE [dbo].[GetAuditHistory]
    @FromUtc       DATETIME2 (3) = NULL,
    @ToUtc         DATETIME2 (3) = NULL,
    @UserIdNo      SMALLINT = NULL,
    @EntityName    VARCHAR (128) = NULL,
    @Action        VARCHAR (30) = NULL,
    @RecordIdNo    INT = NULL,
    @ReferenceNo   NVARCHAR (100) = NULL,
    @TopRows       INT = 1000
AS
BEGIN
    SET NOCOUNT ON;

    IF @TopRows IS NULL OR @TopRows < 1 SET @TopRows = 1000;
    IF @TopRows > 10000 SET @TopRows = 10000;

    SELECT TOP (@TopRows)
        [AuditEventId], [OccurredAtUtc], [UserIdNo], [UserNameSnapshot],
        [Action], [EntityName], [RecordIdNo], [ReferenceNo], [BranchIdNo],
        [Description], [CorrelationId], [MachineName], [ApplicationName],
        [AuditFieldChangeId], [FieldName], [OldValue], [NewValue]
    FROM [dbo].[AuditHistory_View]
    WHERE (@FromUtc IS NULL OR [OccurredAtUtc] >= @FromUtc)
      AND (@ToUtc IS NULL OR [OccurredAtUtc] < @ToUtc)
      AND (@UserIdNo IS NULL OR [UserIdNo] = @UserIdNo)
      AND (@EntityName IS NULL OR [EntityName] = @EntityName)
      AND (@Action IS NULL OR [Action] = @Action)
      AND (@RecordIdNo IS NULL OR [RecordIdNo] = @RecordIdNo)
      AND (@ReferenceNo IS NULL OR [ReferenceNo] LIKE N'%' + @ReferenceNo + N'%')
    ORDER BY [OccurredAtUtc] DESC, [AuditEventId] DESC, [AuditFieldChangeId];
END;
