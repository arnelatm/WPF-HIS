CREATE PROCEDURE [dbo].[InsertAuditEventWithSnapshot]
    @Action             VARCHAR (30),
    @EntityName         VARCHAR (128),
    @RecordIdNo         INT = NULL,
    @ReferenceNo        NVARCHAR (100) = NULL,
    @BranchIdNo         SMALLINT = NULL,
    @Description        NVARCHAR (500) = NULL,
    @OldSnapshot        NVARCHAR (MAX) = NULL,
    @NewSnapshot        NVARCHAR (MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @AuditEventId BIGINT;
    EXEC [dbo].[InsertAuditEvent]
        @Action = @Action,
        @EntityName = @EntityName,
        @RecordIdNo = @RecordIdNo,
        @ReferenceNo = @ReferenceNo,
        @BranchIdNo = @BranchIdNo,
        @Description = @Description,
        @ApplicationName = N'Accounts',
        @AuditEventId = @AuditEventId OUTPUT;

    IF @OldSnapshot IS NOT NULL OR @NewSnapshot IS NOT NULL
    BEGIN
        INSERT [dbo].[AuditFieldChange] ([AuditEventId], [FieldName], [OldValue], [NewValue])
        VALUES (@AuditEventId, N'__RecordSnapshot', @OldSnapshot, @NewSnapshot);
    END;
END;
