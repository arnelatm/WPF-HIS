CREATE PROC [dbo].[InsertGroupAccessTVP]
  @MParam groupAccessInsert READONLY
AS 
INSERT  INTO GroupAccess (SecurityGroupIDNo, SecurityObjectIDNo, Visible, Editable)
        SELECT  SecurityGroupIDNo, SecurityObjectIDNo, Visible, Editable
        FROM    @MParam
SET IDENTITY_INSERT DBO.GroupAccess ON;
