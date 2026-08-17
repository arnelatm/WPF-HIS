


CREATE VIEW [dbo].[GroupNUserAccess_View]
AS
(SELECT	dbo.UserAccess.SecurityObjectIdNo, 
		dbo.UserAccess.Visible AS Visible, 
		dbo.UserAccess.Editable AS Editable, 
		dbo.UserAccess.UserIdNo as UserIdNo,
		0 as SecurityGroupIdNo
		from dbo.UserAccess)
Union
(Select	dbo.GroupAccess.SecurityObjectIDNo, 
		dbo.GroupAccess.Visible,
		dbo.GroupAccess.Editable,
		0,
		dbo.GroupAccess.SecurityGroupIDNo 
		from dbo.GroupAccess)

GO

