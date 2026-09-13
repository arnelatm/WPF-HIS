CREATE TABLE [dbo].[AuditFieldChange]
(
    [AuditFieldChangeId] BIGINT         IDENTITY (1, 1) NOT NULL,
    [AuditEventId]       BIGINT         NOT NULL,
    [FieldName]          NVARCHAR (128) NOT NULL,
    [OldValue]           NVARCHAR (MAX) NULL,
    [NewValue]           NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AuditFieldChange] PRIMARY KEY CLUSTERED ([AuditFieldChangeId] ASC),
    CONSTRAINT [FK_AuditFieldChange_AuditEvent] FOREIGN KEY ([AuditEventId]) REFERENCES [dbo].[AuditEvent] ([AuditEventId])
);

GO

CREATE INDEX [IX_AuditFieldChange_AuditEvent]
    ON [dbo].[AuditFieldChange] ([AuditEventId]);
