CREATE TABLE [dbo].[AuditSessionContext]
(
    [SessionId] INT NOT NULL,
    [UserIdNo] SMALLINT NULL,
    [UserNameSnapshot] NVARCHAR (100) NULL,
    [BranchIdNo] SMALLINT NULL,
    [ApplicationName] NVARCHAR (128) NULL,
    [MachineName] NVARCHAR (128) NULL,
    [SqlLoginName] NVARCHAR (256) NOT NULL CONSTRAINT [DF_AuditSessionContext_SqlLoginName] DEFAULT (SUSER_SNAME()),
    [ClientHostName] NVARCHAR (128) NOT NULL CONSTRAINT [DF_AuditSessionContext_ClientHostName] DEFAULT (HOST_NAME()),
    [ClientApplicationName] NVARCHAR (256) NOT NULL CONSTRAINT [DF_AuditSessionContext_ClientApplicationName] DEFAULT (APP_NAME()),
    [ClientIpAddress] VARCHAR (48) NULL CONSTRAINT [DF_AuditSessionContext_ClientIpAddress] DEFAULT (CONVERT(VARCHAR(48), CONNECTIONPROPERTY('client_net_address'))),
    [UpdatedAt] DATETIME2 NOT NULL CONSTRAINT [DF_AuditSessionContext_UpdatedAt] DEFAULT (SYSUTCDATETIME()),
    CONSTRAINT [PK_AuditSessionContext] PRIMARY KEY CLUSTERED ([SessionId])
);
