
CREATE VIEW [dbo].[GroupAccessAll_View]
AS
SELECT        dbo.SecurityObject.IDNo, dbo.SecurityObject.SecurityObjectName, dbo.SecurityGroup.IDNo AS Expr1, dbo.GroupAccess.Visible, dbo.GroupAccess.Editable, dbo.GroupAccess.SecurityGroupIDNo, 
              dbo.GroupAccess.SecurityObjectIDNo, dbo.GroupAccess.IDNo AS Expr2, dbo.SecurityGroup.SecurityGroupName
FROM            dbo.SecurityGroup INNER JOIN
                         dbo.GroupAccess ON dbo.SecurityGroup.IDNo = dbo.GroupAccess.SecurityGroupIDNo RIGHT OUTER JOIN
                         dbo.SecurityObject ON dbo.GroupAccess.SecurityObjectIDNo = dbo.SecurityObject.IDNo