CREATE PROCEDURE [dbo].[WriteAuditFieldSnapshot]
    @AuditEventId BIGINT,
    @OldValues NVARCHAR(MAX),
    @NewValues NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    IF @AuditEventId IS NULL OR ISNULL(@OldValues,N'')=ISNULL(@NewValues,N'') RETURN;
    INSERT dbo.AuditFieldChange(AuditEventId,FieldName,OldValue,NewValue)
    VALUES(@AuditEventId,N'Record fields',@OldValues,@NewValues);
END;
