CREATE VIEW [dbo].[AuditHistory_View]
AS
SELECT
    e.[AuditEventId],
    e.[OccurredAtUtc],
    e.[UserIdNo],
    e.[UserNameSnapshot],
    e.[Action],
    e.[EntityName],
    e.[RecordIdNo],
    e.[ReferenceNo],
    e.[BranchIdNo],
    e.[Description],
    e.[CorrelationId],
    e.[MachineName],
    e.[ApplicationName],
    c.[AuditFieldChangeId],
    c.[FieldName],
    c.[OldValue],
    c.[NewValue]
FROM [dbo].[AuditEvent] AS e
LEFT JOIN [dbo].[AuditFieldChange] AS c
    ON c.[AuditEventId] = e.[AuditEventId];
