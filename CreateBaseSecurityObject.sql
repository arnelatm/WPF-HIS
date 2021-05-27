USE [ISPDATA]
GO
Delete SecurityObject
DBCC CHECKIDENT ('SecurityObject', RESEED, 1)  
SET IDENTITY_INSERT [dbo].[SecurityObject] ON 
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (1, N'1', N'_SuperAdministrator', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (2, N'2', N'_Administrator', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (3, N'3', N'_Manager', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (4, N'4', N'_Supervisor', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (5, N'5', N'_PowerUser', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (6, N'6', N'_User', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (7, N'7', N'_Guest', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (8, N'8', N'ApproveTransactions', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (9, N'9', N'Translators', NULL, NULL, NULL, NULL, NULL)
GO
DBCC CHECKIDENT ('SecurityObject', RESEED, 10)  
SET IDENTITY_INSERT [dbo].[SecurityObject] OFF
GO
GO