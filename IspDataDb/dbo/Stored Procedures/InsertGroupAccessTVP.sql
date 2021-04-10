
CREATE PROC [dbo].[InsertGroupAccessTVP]
  @MParam groupAccessInsert READONLY
AS 
INSERT  INTO GroupAccess (Editable, SecurityGroupIDNo, SecurityObjectIDNo, Visible)
        SELECT  Editable, SecurityGroupIDNo, SecurityObjectIDNo, Visible
        FROM    @MParam
SET IDENTITY_INSERT DBO.GroupAccess ON;
