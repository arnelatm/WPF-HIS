USE [ISPDATA]
GO
SET IDENTITY_INSERT [dbo].[PayElementGroup] ON 
GO
INSERT [dbo].[PayElementGroup] ([IdNo], [PayElementGroupCode], [PayElementGroupName], [PayElementGroupNameAra], [PayElementKind]) VALUES (1, N'NO        ', N'None', N'None', N'E')
GO
INSERT [dbo].[PayElementGroup] ([IdNo], [PayElementGroupCode], [PayElementGroupName], [PayElementGroupNameAra], [PayElementKind]) VALUES (2, N'BP        ', N'Basic Pay', N'Basic Pay', N'E')
GO
INSERT [dbo].[PayElementGroup] ([IdNo], [PayElementGroupCode], [PayElementGroupName], [PayElementGroupNameAra], [PayElementKind]) VALUES (3, N'HA        ', N'Housing Allowance', N'Housing Allowance', N'E')
GO
INSERT [dbo].[PayElementGroup] ([IdNo], [PayElementGroupCode], [PayElementGroupName], [PayElementGroupNameAra], [PayElementKind]) VALUES (4, N'TF        ', N'Transpo. & Food Allow', N'Transpo. & Food Allow', N'E')
GO
INSERT [dbo].[PayElementGroup] ([IdNo], [PayElementGroupCode], [PayElementGroupName], [PayElementGroupNameAra], [PayElementKind]) VALUES (5, N'OA        ', N'Other Allowances', N'Other Allowances', N'E')
GO
INSERT [dbo].[PayElementGroup] ([IdNo], [PayElementGroupCode], [PayElementGroupName], [PayElementGroupNameAra], [PayElementKind]) VALUES (6, N'AD        ', N'Absences Deduction', N'Absences Deduction', N'D')
GO
INSERT [dbo].[PayElementGroup] ([IdNo], [PayElementGroupCode], [PayElementGroupName], [PayElementGroupNameAra], [PayElementKind]) VALUES (7, N'EL        ', N'Employee Loans', N'Employee Loans', N'D')
GO
INSERT [dbo].[PayElementGroup] ([IdNo], [PayElementGroupCode], [PayElementGroupName], [PayElementGroupNameAra], [PayElementKind]) VALUES (8, N'OD        ', N'Other Deductions', N'Other Deduction', N'D')
GO
SET IDENTITY_INSERT [dbo].[PayElementGroup] OFF