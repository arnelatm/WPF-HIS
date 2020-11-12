USE [ISPDATA]
GO
SET IDENTITY_INSERT [dbo].[PayGroup] ON 
GO
INSERT [dbo].[PayGroup] ([IdNo], [PayGroupCode], [PayGroupName], [ParentIdNo], [PayGroupNameAra], [Notes]) VALUES (1, N'999', N'Management', NULL, N'Management', NULL)
GO
INSERT [dbo].[PayGroup] ([IdNo], [PayGroupCode], [PayGroupName], [ParentIdNo], [PayGroupNameAra], [Notes]) VALUES (4, N'201', N'Laboratory', 2, N'Laboratory', NULL)
GO
INSERT [dbo].[PayGroup] ([IdNo], [PayGroupCode], [PayGroupName], [ParentIdNo], [PayGroupNameAra], [Notes]) VALUES (2, N'MED', N'Medical', NULL, N'Medical', NULL)
GO
INSERT [dbo].[PayGroup] ([IdNo], [PayGroupCode], [PayGroupName], [ParentIdNo], [PayGroupNameAra], [Notes]) VALUES (5, N'202', N'Radiology', 2, N'Radiology', NULL)
GO
INSERT [dbo].[PayGroup] ([IdNo], [PayGroupCode], [PayGroupName], [ParentIdNo], [PayGroupNameAra], [Notes]) VALUES (6, N'000', N'Clinics', 2, N'Clinics', NULL)
GO
INSERT [dbo].[PayGroup] ([IdNo], [PayGroupCode], [PayGroupName], [ParentIdNo], [PayGroupNameAra], [Notes]) VALUES (7, N'203', N'Nursing', 2, N'Nursing', NULL)
GO
INSERT [dbo].[PayGroup] ([IdNo], [PayGroupCode], [PayGroupName], [ParentIdNo], [PayGroupNameAra], [Notes]) VALUES (8, N'001', N'Surgery', 5, N'Surgery', NULL)
GO
INSERT [dbo].[PayGroup] ([IdNo], [PayGroupCode], [PayGroupName], [ParentIdNo], [PayGroupNameAra], [Notes]) VALUES (9, N'002', N'Internal Medicine', 5, N'Internal Medicine', NULL)
GO
INSERT [dbo].[PayGroup] ([IdNo], [PayGroupCode], [PayGroupName], [ParentIdNo], [PayGroupNameAra], [Notes]) VALUES (10, N'004', N'Dental', 5, N'Dental', NULL)
GO
INSERT [dbo].[PayGroup] ([IdNo], [PayGroupCode], [PayGroupName], [ParentIdNo], [PayGroupNameAra], [Notes]) VALUES (11, N'005', N'Obstetrics & Gynecology', 5, N'Obstetrics & Gynecology', NULL)
GO
INSERT [dbo].[PayGroup] ([IdNo], [PayGroupCode], [PayGroupName], [ParentIdNo], [PayGroupNameAra], [Notes]) VALUES (13, N'008', N'General Practitioner', 5, N'General Practitioner', NULL)
GO
INSERT [dbo].[PayGroup] ([IdNo], [PayGroupCode], [PayGroupName], [ParentIdNo], [PayGroupNameAra], [Notes]) VALUES (12, N'006', N'Pediatrics', 5, N'Pediatrics', NULL)
GO
INSERT [dbo].[PayGroup] ([IdNo], [PayGroupCode], [PayGroupName], [ParentIdNo], [PayGroupNameAra], [Notes]) VALUES (15, N'997', N'Maintenance', 1, N'Maintenance', NULL)
GO
INSERT [dbo].[PayGroup] ([IdNo], [PayGroupCode], [PayGroupName], [ParentIdNo], [PayGroupNameAra], [Notes]) VALUES (16, N'996', N'Reception', 1, N'Reception', NULL)
GO
INSERT [dbo].[PayGroup] ([IdNo], [PayGroupCode], [PayGroupName], [ParentIdNo], [PayGroupNameAra], [Notes]) VALUES (3, N'500', N'Pharmacy', NULL, N'Pharmacy', NULL)
GO
INSERT [dbo].[PayGroup] ([IdNo], [PayGroupCode], [PayGroupName], [ParentIdNo], [PayGroupNameAra], [Notes]) VALUES (14, N'998', N'Administration', 1, N'Administration', NULL)
GO
SET IDENTITY_INSERT [dbo].[PayGroup] OFF
GO
