USE [ISPDATA]
GO
/****** Object:  Table [dbo].[Salt]    Script Date: 28/10/2021 14:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salt](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[LoginIDNo] [int] NOT NULL,
	[Salt] [varchar](50) NULL,
	[Modified] [timestamp] NOT NULL,
 CONSTRAINT [PK_SaltIDNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecurityGroup]    Script Date: 28/10/2021 14:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityGroup](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[SecurityGroupName] [varchar](50) NULL,
	[ParentIdNo] [smallint] NULL,
	[Notes] [varchar](100) NULL,
	[DateTimeStamp] [timestamp] NULL,
	[SecurityGroupCode] [varchar](10) NULL,
	[SecurityGroupNameAra] [nvarchar](50) NULL,
 CONSTRAINT [PK_IDNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecurityGroupAccess]    Script Date: 28/10/2021 14:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityGroupAccess](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[SecurityGroupIdNo] [smallint] NOT NULL,
	[SecurityControlIdNo] [int] NOT NULL,
	[Viewalble] [bit] NOT NULL,
	[Editable] [bit] NOT NULL,
 CONSTRAINT [PK_SecurityGroupAccess] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecurityObject]    Script Date: 28/10/2021 14:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityObject](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[SecurityObjectCode] [varchar](10) NULL,
	[SecurityObjectName] [varchar](100) NOT NULL,
	[SecurityObjectNameAra] [nvarchar](200) NULL,
	[ParentIdNo] [int] NULL,
	[SystemViewIdNo] [int] NULL,
	[ManuallyAdded] [bit] NULL,
	[Notes] [varchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_SecurityObject] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 28/10/2021 14:01:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdNo] [int] IDENTITY(18,1) NOT NULL,
	[UserName] [varchar](20) NOT NULL,
	[Password] [varchar](50) NULL,
	[EmployeeIdNo] [int] NULL,
	[SecurityGroupIDNo] [smallint] NULL,
	[FullName] [varchar](50) NULL,
	[FullNameAra] [nvarchar](50) NULL,
	[SecurityLevel] [tinyint] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_UserIDNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Salt] ON 
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (1, 5, N'vAkINPsPpiL/GO7UlUfo2ww')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (2, 6, N'XUWDZPh/jrgwH+7rr7z2/A8=')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (7, 23, N'Cerk2ysKliLN0W0sQIJGNxCs1')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (8, 8, N'nIjAKoHJ4tKyB4n3G//haHvvL')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (9, 0, N'nIjAKoHJ4tKyB4n3G//haHvvL')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (10, 24, N'L2ztYgmclU2xPvk576wnmDJyf')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (11, 25, N'BlSgKOWupIyPuwmHG485ehhsiDs=')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (18, 34, N'ZNjrg9+kY7sgt04tv0IdzFyNuQ==')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (19, 35, N'I1/hjNlLJB1frSSSEM611WrY2A==')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (20, 36, N'RkJF9AUc87mjf9Zd9aaMkPR9cQ==')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (21, 37, N'lDuhcH/exFAz4gG9T1LKWnUcIA==')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (22, 1038, N'NWoZK3kTsExUV00Ywo1G5jlUKKs=')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (23, 2, N'2kuSN7rMzfGcB2DKt67EqDWQELA=')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (24, 1040, N'Yi1/XyD85X+DiNx2TFF8+YzXrxs=')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (25, 1039, N'NWoZK3kTsExUV00Ywo1G5jlUKKs=')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (26, 1041, N'0xqH2js3aWJl6ao8l/S3IukA8mA=')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (27, 1042, N'KF3LKslOXg9dtVJ1wIXnovNaZUU=')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (28, 1043, N'Lgu4SkPmpxYG7IBUlWyLK7fTnsg=')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (29, 1044, N'JV3iWb3Z/S7euoJTynRunRCvMdI=')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIDNo], [Salt]) VALUES (30, 1045, N'choMGuqCodLb89QsxGChcHA3Kjo=')
GO
SET IDENTITY_INSERT [dbo].[Salt] OFF
GO
SET IDENTITY_INSERT [dbo].[SecurityGroup] ON 
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (1, N'Admin', NULL, N'Administrator Account', N'ADM', N'Admin')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (2, N'Receptionists', NULL, N'Receptionists', N'REC', N'Receptionists')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (4, N'HR Manager', NULL, N'Human Resources Manager', N'HRM', N'HR Manager')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (5, N'Lab Supervisor', NULL, N'Laboratory Supervisor', N'SUP', N'Lab Supervisor')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (6, N'Nurses           ', NULL, N'Nursing Staff', N'STN', N'Nurses           ')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (7, N'Support Staff', NULL, N'Support Staff including cleaners, drivers, maintenance personnel.', N'SN2', N'Support Staff')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (8, N'Accountant', NULL, N'Accountant 2cf', N'ACT', N'Accountant')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (9, N'Lab Technicians', NULL, N'Laboratory Technicians', N'LBT', N'Lab Technicians')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (10, N'X-Ray Technician', NULL, N'X-Ray Technicians', N'XRT', N'X-Ray Technician')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (11, N'Chief Nurse', NULL, N'Chief Nurse', N'CRN', N'Chief Nurse')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (12, N'Doctors', NULL, N'Doctors', N'DOC', N'Doctors')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (13, N'Stock Clerk', NULL, N'Stock Clerk', N'SCL', N'Stock Clerk')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (15, N'Pharmacists', NULL, N'Pharmacists', N'PHA', N'Pharmacists')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (16, N'Reception Supervisor', NULL, N'Reception Supervisor', N'RSP', N'Reception Supervisor')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (17, N'Cleaners', NULL, N'Cleaners', N'CLN', N'Cleaners')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (18, N'Drivers', NULL, N'Drivers', N'DRV', N'Drivers')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (19, N'Electrician', NULL, N'Electricain', N'ELE', N'Electrician')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (20, N'Purchaser', NULL, N'Purchaser', N'PUR', N'Purchaser')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (21, N'Financial Manager', NULL, N'Financial Manager', N'FMG', N'Financial Manager')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (22, N'Bookkeeper', 8, NULL, NULL, N'Bookkeeper')
GO
SET IDENTITY_INSERT [dbo].[SecurityGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[SecurityObject] ON 
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (1, N'1', N'_SuperAdministrator', NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (2, N'2', N'_Administrator', NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (3, N'3', N'_Manager', NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (4, N'4', N'_Supervisor', NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (5, N'5', N'_PowerUser', NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (6, N'6', N'_User', NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (7, N'7', N'_Guest', NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (8, N'8', N'Translators', NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (9, NULL, N'ApproveTransactions', N'ApproveTransactions', 4, 0, 0, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (10, NULL, N'Main', NULL, NULL, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (11, NULL, N'ToolStrip', NULL, 10, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (12, NULL, N'Login', NULL, 11, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (13, NULL, N'Logout', NULL, 11, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (14, NULL, N'Exit', NULL, 11, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (15, NULL, N'Arabic', NULL, 11, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (16, NULL, N'English', NULL, 11, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (17, NULL, N'Translate', NULL, 11, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (18, NULL, N'AccountsMenu', NULL, 10, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (19, NULL, N'File', NULL, 18, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (20, NULL, N'Login', NULL, 19, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (21, NULL, N'Logout', NULL, 19, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (22, NULL, N'ChangePassword', NULL, 19, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (23, NULL, N'Settings', NULL, 19, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (24, NULL, N'Exit', NULL, 19, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (25, NULL, N'Edit', NULL, 18, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (26, NULL, N'Cut', NULL, 25, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (27, NULL, N'Copy', NULL, 25, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (28, NULL, N'Paste', NULL, 25, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (29, NULL, N'Masters', NULL, 18, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (30, NULL, N'General', NULL, 29, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (31, NULL, N'Branches', NULL, 30, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (32, NULL, N'ChartOfAccounts', NULL, 30, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (33, NULL, N'Departments', NULL, 30, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (34, NULL, N'RevCostCenters', NULL, 30, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (35, NULL, N'RevenueGroups', NULL, 30, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (36, NULL, N'DistributionSchemes', NULL, 30, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (37, NULL, N'Countries', NULL, 30, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (38, NULL, N'PhoneTypes', NULL, 30, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (39, NULL, N'Religions', NULL, 30, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (40, NULL, N'Banks', NULL, 30, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (41, NULL, N'Categories', NULL, 30, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (42, NULL, N'Items', NULL, 30, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (43, NULL, N'DefaultFieldValues', NULL, 30, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (44, NULL, N'SalesDepositTypes', NULL, 30, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (45, NULL, N'Security', NULL, 29, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (46, NULL, N'SecurityGroups', NULL, 45, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (47, NULL, N'SecurityObjects', NULL, 45, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (48, NULL, N'Users', NULL, 45, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (49, NULL, N'Employee', NULL, 29, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (50, NULL, N'Employees', NULL, 49, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (51, NULL, N'Designations', NULL, 49, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (52, NULL, N'Translations', NULL, 29, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (53, NULL, N'Messages', NULL, 52, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (54, NULL, N'Captions', NULL, 52, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (55, NULL, N'CaptionsBatchEdit', NULL, 52, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (56, NULL, N'CreateAllMessages', NULL, 52, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (57, NULL, N'Payroll', NULL, 29, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (58, NULL, N'PayElement', NULL, 57, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (59, NULL, N'Leaves', NULL, 57, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (60, NULL, N'PayGroups', NULL, 57, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (61, NULL, N'PayCycles', NULL, 57, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (62, NULL, N'Payrolls', NULL, 57, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (63, NULL, N'PensionProviders', NULL, 57, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (64, NULL, N'PensionSchemes', NULL, 57, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (65, NULL, N'SupplierVendors', NULL, 29, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (66, NULL, N'CustomerClients', NULL, 29, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (67, NULL, N'Transactions', NULL, 18, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (68, NULL, N'PettyCash', NULL, 67, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (69, NULL, N'CashDisbursementEntry', NULL, 67, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (70, NULL, N'AccountsPayableEntry', NULL, 67, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (71, NULL, N'AccountsReceivableEntry', NULL, 67, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (72, NULL, N'CashReceiptEntry', NULL, 67, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (73, NULL, N'EmployeeReceivable', NULL, 67, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (74, NULL, N'GeneralJournalEntry', NULL, 67, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (75, NULL, N'SalesJournalEntry', NULL, 67, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (76, NULL, N'AccountReconciliation', NULL, 67, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (77, NULL, N'PostPettyCashAccount', NULL, 67, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (78, NULL, N'Closing', NULL, 67, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (79, NULL, N'PayrollMenu', NULL, 67, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (80, NULL, N'PayrollAttendance', NULL, 79, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (81, NULL, N'GeneratePayroll', NULL, 79, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (82, NULL, N'PayrollEntry', NULL, 79, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (83, NULL, N'eToolStripMenuItem', NULL, 79, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (84, NULL, N'ClosePettyCashFund', NULL, 67, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (85, NULL, N'Reports', NULL, 18, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (86, NULL, N'StatementOfAccountsPayable', NULL, 85, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (87, NULL, N'StatementOfAccountsReceivable', NULL, 85, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (88, NULL, N'StatementOfEmployeeLoans', NULL, 85, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (89, NULL, N'SummaryOfEmployeeLoans', NULL, 85, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (90, NULL, N'SummaryOfAccountsPayable', NULL, 85, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (91, NULL, N'SummaryOfAccountsReceivable', NULL, 85, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (92, NULL, N'TrialBalance', NULL, 85, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (93, NULL, N'TBMonthly', NULL, 92, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (94, NULL, N'TBQuarterly', NULL, 92, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (95, NULL, N'TBSemestral', NULL, 92, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (96, NULL, N'TBYearly', NULL, 92, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (97, NULL, N'TBCustom', NULL, 92, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (98, NULL, N'BalanceSheet', NULL, 85, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (99, NULL, N'BSYearly', NULL, 98, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (100, NULL, N'BSMonthly', NULL, 98, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (101, NULL, N'BSQuarterly', NULL, 98, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (102, NULL, N'BSSemestral', NULL, 98, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (103, NULL, N'IncomeStatement', NULL, 85, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (104, NULL, N'ISYearly', NULL, 103, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (105, NULL, N'ISMonthly', NULL, 103, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (106, NULL, N'ISQuarterly', NULL, 103, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (107, NULL, N'ISSemiAnnually', NULL, 103, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (108, NULL, N'ISCustomRange', NULL, 103, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (109, NULL, N'AccountActivity', NULL, 85, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (110, NULL, N'IGroupReports', NULL, 85, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (111, NULL, N'CashIncomePerDoctorService', NULL, 110, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (112, NULL, N'NumberOfCashPatientsPerDoctor', NULL, 110, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (113, NULL, N'BlankReport', NULL, 110, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (114, NULL, N'ARAging', NULL, 85, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (115, NULL, N'APAging', NULL, 85, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (116, NULL, N'CheckPrinting', NULL, 85, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (117, NULL, N'PayrollReport', NULL, 85, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (118, NULL, N'PeriodicPayroll', NULL, 117, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (119, NULL, N'Utilities', NULL, 18, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (120, NULL, N'RecreateSecurityObjectMenu', NULL, 119, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (121, NULL, N'TransactionNotesTranslator', NULL, 119, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (122, NULL, N'Help', NULL, 18, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (123, NULL, N'Index', NULL, 122, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (124, NULL, N'About', NULL, 122, 24, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (125, N'PYPR', N'Payroll Processing', N'Payroll Processing', NULL, 0, 0, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (126, N'EPI', N'Employee Payroll Information', N'Employee Payroll Information', 125, 0, 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[SecurityObject] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (6, N'ARNEL', N'zHGeeKaglmP+6HQfNY+goAxymBs=', NULL, 1, N'Arnel Antonio T. Marcelo', N'Arnel Antonio T. Marcelo', 10)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (8, N'ISPADMIN', N'CbIz3PHw+NCgezZaVb2PbSW0ThQ=', NULL, 8, N'Arnel Antonio Marcelo', N'Arnel Antonio Marcelo', 10)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (23, N'Yousef', N'rEw46sJZxyYsEziEsXx7lrsL65c=', NULL, 8, N'Ahmad Doghim', N'Ahmad Doghim', 7)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (25, N'USER', N'B/c7pgaWijSX6OMYtrfFr4nQprk=', NULL, 0, N'Ordinary User', N'Ordinary User', 7)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (34, N'Olhan', N'uwEpheK3clcx+us0gQVALZOclHg=', NULL, 8, N'Rolando Gatbunton', NULL, NULL)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (35, N'Ehab', N'glbeOq63N+8huPlfFxthaunzBYk=', NULL, 8, N'Ehab Bakheer', NULL, NULL)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (36, N'Susan', N'5EejqTQxadPC0YoIxwalCe2kJ1U=', NULL, 11, N'Susan Britanico', N'Susan Britanico', 5)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (37, N'Marwan', N'JovqtqeogZKibVN5/dPgNqZt5AU=', NULL, 1, N'Marwan Fetyani', N'Marwan Fetyani', 7)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (38, N'DELL', N'1', NULL, 1, N'ARNEL', N'ARNEL', 10)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (1038, N'Dell I7', N'gNvqSyQA6WHPZu1hHx8rX/Rghak=', NULL, 1, N'Dell', N'Dell', 8)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (1039, N'MAY', N'gNvqSyQA6WHPZu1hHx8rX/Rghak=', NULL, 22, N'MAY MARCELO', N'MAY MARCELO', 10)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (1040, N'Faten', N'q97hFdrLehJnbCFw/fUtbkiB88s=', NULL, 22, N'Faten Ahmad', NULL, NULL)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (1041, N'Areej', N'YbK8OGQ9NiiFW4GjN+ByRklBK1E=', 492, 2, NULL, NULL, NULL)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (1042, N'Basma', N'IUcvTmhzNkWoglj/kaq6XWigpvw=', 438, 2, NULL, NULL, NULL)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (1043, N'Villy', N'wi8ar/7Mu5LrQPrO1YymUS/AVHs=', 318, 6, NULL, NULL, NULL)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (1044, N'Emma', N'XvaUxdxp61ejsaz86V+A1rRfRpg=', 322, 6, NULL, NULL, NULL)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [EmployeeIdNo], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (1045, N'Johnson', N'3YhfJ4Hc4CPe7mKoxiSbgUnsnpU=', 324, 6, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SecurityGroupName]    Script Date: 28/10/2021 14:01:57 ******/
ALTER TABLE [dbo].[SecurityGroup] ADD  CONSTRAINT [IX_SecurityGroupName] UNIQUE NONCLUSTERED 
(
	[SecurityGroupName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SecurityObject]  WITH CHECK ADD  CONSTRAINT [FK__SecurityObject__ParentId] FOREIGN KEY([ParentIdNo])
REFERENCES [dbo].[SecurityObject] ([IdNo])
GO
ALTER TABLE [dbo].[SecurityObject] CHECK CONSTRAINT [FK__SecurityObject__ParentId]
GO
ALTER TABLE [dbo].[User]  WITH NOCHECK ADD  CONSTRAINT [FK_User_User] FOREIGN KEY([IdNo])
REFERENCES [dbo].[User] ([IdNo])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_User]
GO
