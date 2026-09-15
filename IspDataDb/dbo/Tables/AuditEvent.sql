CREATE TABLE [dbo].[AuditEvent]
(
    [AuditEventId]      BIGINT         IDENTITY (1, 1) NOT NULL,
    [OccurredAtUtc]     DATETIME2 (3)  CONSTRAINT [DF_AuditEvent_OccurredAtUtc] DEFAULT (SYSUTCDATETIME()) NOT NULL,
    [UserIdNo]          SMALLINT       NULL,
    [UserNameSnapshot]  NVARCHAR (100) NULL,
    [Action]            VARCHAR (30)   NOT NULL,
    [EntityName]        VARCHAR (128)  NOT NULL,
    [RecordIdNo]        INT            NULL,
    [ReferenceNo]       NVARCHAR (100) NULL,
    [BranchIdNo]        SMALLINT       NULL,
    [Description]       NVARCHAR (500) NULL,
    [CorrelationId]     UNIQUEIDENTIFIER NULL,
    [MachineName]       NVARCHAR (128) NULL,
    [ApplicationName]   NVARCHAR (128) NULL,
    [SqlLoginName]      NVARCHAR (256) CONSTRAINT [DF_AuditEvent_SqlLoginName] DEFAULT (SUSER_SNAME()) NULL,
    [OriginalLoginName] NVARCHAR (256) CONSTRAINT [DF_AuditEvent_OriginalLoginName] DEFAULT (ORIGINAL_LOGIN()) NULL,
    [ClientHostName]    NVARCHAR (128) CONSTRAINT [DF_AuditEvent_ClientHostName] DEFAULT (HOST_NAME()) NULL,
    [ClientApplicationName] NVARCHAR (256) CONSTRAINT [DF_AuditEvent_ClientApplicationName] DEFAULT (APP_NAME()) NULL,
    [ClientIpAddress]   VARCHAR (48) CONSTRAINT [DF_AuditEvent_ClientIpAddress] DEFAULT (CONVERT(VARCHAR(48), CONNECTIONPROPERTY('client_net_address'))) NULL,
    CONSTRAINT [PK_AuditEvent] PRIMARY KEY CLUSTERED ([AuditEventId] ASC),
    CONSTRAINT [CK_AuditEvent_Action] CHECK ([Action] IN ('Insert', 'Update', 'Delete', 'Post', 'Approve', 'Cancel', 'Close', 'Login', 'Logout', 'Other'))
);

GO

CREATE INDEX [IX_AuditEvent_EntityRecordDate]
    ON [dbo].[AuditEvent] ([EntityName], [RecordIdNo], [OccurredAtUtc] DESC);

GO

CREATE INDEX [IX_AuditEvent_UserDate]
    ON [dbo].[AuditEvent] ([UserIdNo], [OccurredAtUtc] DESC);
