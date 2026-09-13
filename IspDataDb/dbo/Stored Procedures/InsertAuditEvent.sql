CREATE PROCEDURE [dbo].[InsertAuditEvent]
    @Action             VARCHAR (30),
    @EntityName         VARCHAR (128),
    @RecordIdNo         INT = NULL,
    @ReferenceNo        NVARCHAR (100) = NULL,
    @BranchIdNo         SMALLINT = NULL,
    @Description        NVARCHAR (500) = NULL,
    @CorrelationId      UNIQUEIDENTIFIER = NULL,
    @MachineName        NVARCHAR (128) = NULL,
    @ApplicationName    NVARCHAR (128) = NULL,
    @AuditEventId       BIGINT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ContextUserIdNo SMALLINT = TRY_CONVERT(SMALLINT, SESSION_CONTEXT(N'AuditUserIdNo'));
    DECLARE @ContextUserName NVARCHAR(100) = TRY_CONVERT(NVARCHAR(100), SESSION_CONTEXT(N'AuditUserName'));
    DECLARE @ContextBranchIdNo SMALLINT = TRY_CONVERT(SMALLINT, SESSION_CONTEXT(N'AuditBranchIdNo'));
    DECLARE @ContextMachineName NVARCHAR(128) = TRY_CONVERT(NVARCHAR(128), SESSION_CONTEXT(N'AuditMachineName'));
    DECLARE @ContextApplicationName NVARCHAR(128) = TRY_CONVERT(NVARCHAR(128), SESSION_CONTEXT(N'AuditApplicationName'));

    INSERT INTO [dbo].[AuditEvent]
    (
        [UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo],
        [ReferenceNo], [BranchIdNo], [Description], [CorrelationId],
        [MachineName], [ApplicationName]
    )
    VALUES
    (
        @ContextUserIdNo, @ContextUserName, @Action, @EntityName, @RecordIdNo,
        @ReferenceNo, COALESCE(@BranchIdNo, @ContextBranchIdNo), @Description,
        @CorrelationId, COALESCE(@MachineName, @ContextMachineName),
        COALESCE(@ApplicationName, @ContextApplicationName)
    );

    SET @AuditEventId = CONVERT(BIGINT, SCOPE_IDENTITY());
END;
