

CREATE PROC [dbo].[InsertUserAccessTVP]
  @MParam UserAccessInsert READONLY
AS 
INSERT  INTO UserAccess (Editable, SecurityObjectIDNo, UserIdNo, Visible)
        SELECT  Editable, SecurityObjectIDNo, UserIdNo, Visible
        FROM    @MParam
SET IDENTITY_INSERT DBO.UserAccess ON;