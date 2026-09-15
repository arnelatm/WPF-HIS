CREATE TABLE [dbo].[AuditSessionContext]
(
    [SessionId] INT NOT NULL,
    [UserIdNo] SMALLINT NULL,
    [UserNameSnapshot] NVARCHAR (100) NULL,
    [BranchIdNo] SMALLINT NULL,
    [ApplicationName] NVARCHAR (128) NULL,
    [MachineName] NVARCHAR (128) NULL,
    [UpdatedAt] DATETIME2 NOT NULL CONSTRAINT [DF_AuditSessionContext_UpdatedAt] DEFAULT (SYSUTCDATETIME()),
    CONSTRAINT [PK_AuditSessionContext] PRIMARY KEY CLUSTERED ([SessionId])
);
