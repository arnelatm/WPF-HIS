USE [ISPDATA]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 11/14/2021 12:16:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[IdNo] [smallint] IDENTITY(1000,1) NOT NULL,
	[DepartmentCode] [varchar](10) NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
	[DepartmentNameAra] [nvarchar](50) NOT NULL,
	[ParentIdNo] [smallint] NULL,
	[Notes] [nvarchar](250) NULL,
	[RevCostCenterIDNo] [smallint] NULL,
	[Active] [bit] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_DepartmentIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON 
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (1, N'001', N'Surgery', N'Surgery', NULL, N's', 4, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (2, N'002', N'Internal Medicine 1', N'Internal Medicine 1', 102, NULL, 3, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (4, N'004', N'Dental 1', N'Dental', 104, NULL, 5, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (5, N'005', N'Obstetrics & Gynecology', N'Obstetrics & Gynecology', NULL, NULL, 2, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (6, N'006', N'Pediatrics 1', N'Pediatrics 1', 106, NULL, 1, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (8, N'008', N'General Practitioner 1', N'General Practitioner 1', 108, NULL, 8, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (9, N'009', N'General Practitioner 2', N'General Practitioner 2', 108, NULL, 8, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (10, N'010', N'General Practitioner 3', N'General Practitioner 3', 108, NULL, 8, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (11, N'011', N'General Practitioner 4', N'General Practitioner 4', 108, NULL, NULL, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (12, N'012', N'Pediatrics 2', N'Pediatrics 2', 106, NULL, 0, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (14, N'014', N'Dental 2', N'Dental 2', 104, NULL, 4, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (15, N'015', N'Internal Medicine 2', N'Internal Medicine 2', 102, NULL, 15, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (24, N'024', N'Dental 3', N'Dental 3', 104, NULL, 24, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (90, N'090', N'Opthalmology', N'Opthalmology', NULL, N'1', 5, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (102, N'102', N'Internal Medicine', N'Internal Medicine', NULL, NULL, 102, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (104, N'104', N'Dental Department', N'Dental Department', NULL, NULL, 4, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (106, N'106', N'Pediatrics', N'Pediatrics', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (108, N'108', N'General Practitioner Department', N'General Practitioner Department', NULL, NULL, 8, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (201, N'201', N'Laboratory', N'Laboratory', NULL, NULL, 80, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (202, N'202', N'Radiology', N'Radiology', NULL, NULL, 202, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (203, N'203', N'Nursing', N'Nursing', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (301, N'301', N'Diagnostic Center', N'Diagnostic Center', NULL, NULL, 301, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (500, N'500', N'Pharmacy', N'Pharmacy', NULL, NULL, 0, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (666, N'666', N'Pediatrics Department', N'Pediatrics Department', NULL, NULL, 0, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (800, N'800', N'Administration', N'Administration', NULL, NULL, 999, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (801, N'801', N'Support Services', N'Support Services', NULL, NULL, 999, NULL)
GO
INSERT [dbo].[Department] ([IdNo], [DepartmentCode], [DepartmentName], [DepartmentNameAra], [ParentIdNo], [Notes], [RevCostCenterIDNo], [Active]) VALUES (999, N'999', N'Other Department', N'Other Department', NULL, NULL, 999, NULL)
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DepartmentCode]    Script Date: 11/14/2021 12:16:36 PM ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [IX_DepartmentCode] UNIQUE NONCLUSTERED 
(
	[DepartmentCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DepartmentName]    Script Date: 11/14/2021 12:16:36 PM ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [IX_DepartmentName] UNIQUE NONCLUSTERED 
(
	[DepartmentName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DepartmentNameAra]    Script Date: 11/14/2021 12:16:36 PM ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [IX_DepartmentNameAra] UNIQUE NONCLUSTERED 
(
	[DepartmentNameAra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
