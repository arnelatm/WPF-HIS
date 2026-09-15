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

    DECLARE @ContextUserIdNo SMALLINT;
    DECLARE @ContextUserName NVARCHAR(100);
    DECLARE @ContextBranchIdNo SMALLINT;
    DECLARE @ContextMachineName NVARCHAR(128);
    DECLARE @ContextApplicationName NVARCHAR(128);

    SELECT @ContextUserIdNo = [UserIdNo], @ContextUserName = [UserNameSnapshot],
        @ContextBranchIdNo = [BranchIdNo], @ContextMachineName = [MachineName],
        @ContextApplicationName = [ApplicationName]
    FROM [dbo].[GetAuditSessionContext]();

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
