USE [ISPDATA]
GO
/****** Object:  Table [dbo].[GroupAccess]    Script Date: 4/28/2020 2:02:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupAccess](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[SecurityGroupIdNo] [int] NOT NULL,
	[SecurityObjectIdNo] [int] NOT NULL,
	[Visible] [bit] NOT NULL,
	[Editable] [bit] NOT NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_SecurityGroupAccessIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salt]    Script Date: 4/28/2020 2:02:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salt](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[LoginIdNo] [int] NOT NULL,
	[Salt] [varchar](50) NULL,
	[Modified] [timestamp] NOT NULL,
 CONSTRAINT [PK_SaltIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecurityGroup]    Script Date: 4/28/2020 2:02:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityGroup](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[SecurityGroupName] [varchar](50) NULL,
	[ParentIdNo] [int] NULL,
	[Notes] [varchar](100) NULL,
	[DateTimeStamp] [timestamp] NULL,
	[SecurityGroupCode] [varchar](10) NULL,
	[SecurityGroupNameAra] [nvarchar](50) NULL,
 CONSTRAINT [PK_IdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecurityObject]    Script Date: 4/28/2020 2:02:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityObject](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[SecurityObjectName] [varchar](100) NOT NULL,
	[SecurityObjectNameAra] [nvarchar](200) NULL,
	[ParentIdNo] [int] NULL,
	[Notes] [varchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_SecurityObject] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/28/2020 2:02:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdNo] [int] IDENTITY(18,1) NOT NULL,
	[UserName] [varchar](20) NOT NULL,
	[Password] [varchar](50) NULL,
	[SecurityGroupIdNo] [int] NULL,
	[FullName] [varchar](50) NULL,
	[FullNameAra] [nvarchar](50) NULL,
	[SecurityLevel] [tinyint] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_UserIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GroupAccess] ON 
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (61, 1, 3, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (62, 1, 4, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (63, 1, 5, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (64, 2, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (65, 2, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (66, 2, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (67, 3, 1, 0, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (68, 4, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (69, 4, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (70, 4, 5, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (71, 5, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (72, 5, 2, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (73, 5, 3, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (74, 6, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (75, 6, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (76, 1, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (77, 1, 2, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (78, 25, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (79, 25, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (80, 25, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (81, 25, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (83, 48, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (84, 48, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (85, 48, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (86, 48, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (87, 66, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (88, 66, 2, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (89, 66, 3, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (90, 66, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (91, 67, 2, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (92, 69, 4, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (93, 69, 3, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (94, 69, 2, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (95, 6, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (96, 6, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (97, 70, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (98, 70, 2, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (99, 70, 3, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (100, 70, 4, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (101, 72, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (102, 72, 2, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (103, 72, 3, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (104, 72, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (105, 74, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (106, 74, 2, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (107, 74, 3, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (108, 74, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (109, 0, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (110, 0, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (111, 0, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (112, 0, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (118, 85, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (119, 85, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (120, 85, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (121, 85, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (122, 86, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (123, 86, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (124, 86, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (125, 86, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (126, 87, 1, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (127, 87, 2, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (128, 87, 3, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (129, 87, 4, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (130, 88, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (131, 88, 2, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (132, 88, 3, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (133, 88, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (134, 89, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (135, 89, 4, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (136, 90, 1, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (137, 90, 2, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (138, 90, 3, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (139, 90, 4, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (140, 91, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (141, 91, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (142, 91, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (143, 91, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (144, 92, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (145, 92, 2, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (146, 92, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (147, 92, 4, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (148, 94, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (149, 94, 4, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (150, 95, 1, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (151, 95, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (152, 95, 3, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (153, 95, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (154, 96, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (155, 96, 2, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (156, 96, 3, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (157, 96, 4, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (158, 97, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (159, 97, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (160, 97, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (161, 97, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (162, 98, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (163, 98, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (164, 98, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (165, 98, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (166, 99, 1, 0, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (167, 99, 4, 0, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (168, 100, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (169, 100, 2, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (170, 100, 3, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (171, 100, 4, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (172, 101, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (173, 101, 2, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (174, 101, 3, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (175, 101, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (176, 2, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (177, 102, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (178, 102, 2, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (179, 102, 3, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (180, 102, 4, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (181, 9, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (182, 9, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (183, 9, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (184, 9, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (185, 99, 2, 0, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (186, 99, 3, 0, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (187, 103, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (188, 103, 2, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (189, 103, 3, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (190, 103, 4, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (191, 104, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (192, 104, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (193, 104, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (194, 105, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (195, 105, 4, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (196, 106, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (197, 106, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (198, 106, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (199, 106, 4, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (201, 107, 1, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (202, 107, 2, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (203, 107, 3, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (204, 107, 4, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (206, 15, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (207, 15, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (208, 15, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (209, 15, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (210, 108, 1, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (211, 108, 2, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (212, 108, 3, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (213, 108, 4, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (214, 109, 1, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (215, 109, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (216, 110, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (217, 110, 4, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (261, 7, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (262, 7, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (263, 7, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (264, 8, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (265, 8, 2, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (266, 8, 3, 0, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (267, 8, 4, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (268, 10, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (269, 10, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (270, 10, 4, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (271, 11, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (272, 11, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (273, 7, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (274, 4, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (275, 4, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (276, 10, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (277, 42, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (278, 42, 5, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (279, 111, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (280, 111, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (281, 111, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (282, 111, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (283, 111, 5, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (284, 112, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (285, 112, 5, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (286, 24, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (287, 80, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (288, 80, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (289, 80, 3, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (290, 80, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (291, 80, 5, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (292, 80, 6, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (293, 47, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (294, 8, 5, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (295, 8, 6, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (296, 92, 6, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (297, 1, 6, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (298, 90, 5, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (299, 90, 6, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (300, 113, 1, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (301, 113, 2, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (302, 113, 3, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (303, 113, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (304, 113, 5, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (305, 113, 6, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (306, 61, 5, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (307, 61, 4, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (308, 68, 5, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (309, 68, 6, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (310, 68, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (311, 68, 2, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (312, 68, 3, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (313, 68, 4, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (314, 114, 5, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (315, 114, 6, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (316, 114, 1, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (317, 114, 2, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (318, 114, 3, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (319, 114, 4, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (320, 68, 7, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (321, 1, 7, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (322, 8, 8, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (323, 8, 9, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (324, 8, 13, 0, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (325, 8, 12, 0, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (326, 8, 11, 0, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (327, 8, 10, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (330, 8, 14, 0, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (331, 8, 7, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (332, 1, 8, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (333, 1, 9, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (334, 1, 13, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (335, 1, 12, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (336, 1, 11, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (337, 1, 10, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (340, 1, 14, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (341, 68, 10, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (342, 68, 15, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (343, 68, 16, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (344, 1, 23, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (345, 1, 17, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (346, 1, 18, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (347, 1, 19, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (348, 1, 20, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (349, 1, 21, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (350, 1, 22, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (351, 1, 30, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (352, 1, 24, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (353, 1, 27, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (354, 1, 28, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (355, 1, 25, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (356, 1, 26, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (357, 1, 29, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (358, 1, 36, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (359, 1, 32, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (360, 1, 31, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (361, 1, 35, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (362, 1, 33, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (363, 1, 34, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (364, 8, 23, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (365, 8, 17, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (366, 8, 18, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (367, 8, 19, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (368, 8, 20, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (369, 8, 21, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (370, 8, 22, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (371, 8, 30, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (372, 8, 24, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (373, 8, 27, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (374, 8, 28, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (375, 8, 25, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (376, 8, 26, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (377, 8, 29, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (378, 8, 36, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (379, 8, 34, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (381, 1, 38, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (383, 8, 41, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (384, 1, 41, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (385, 8, 42, 1, 0)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (386, 1, 42, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (393, 10, 26, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (394, 10, 20, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (395, 10, 55, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (396, 10, 21, 1, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (398, 10, 48, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (399, 10, 36, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (400, 10, 49, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (401, 10, 42, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (402, 10, 37, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (403, 10, 35, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (404, 10, 38, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (405, 10, 47, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (406, 10, 50, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (408, 10, 34, 0, 1)
GO
INSERT [dbo].[GroupAccess] ([IdNo], [SecurityGroupIdNo], [SecurityObjectIdNo], [Visible], [Editable]) VALUES (410, 10, 46, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[GroupAccess] OFF
GO
SET IDENTITY_INSERT [dbo].[Salt] ON 
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIdNo], [Salt]) VALUES (1, 5, N'vAkINPsPpiL/GO7UlUfo2ww')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIdNo], [Salt]) VALUES (2, 6, N'XUWDZPh/jrgwH+7rr7z2/A8=')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIdNo], [Salt]) VALUES (7, 23, N'Cerk2ysKliLN0W0sQIJGNxCs1')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIdNo], [Salt]) VALUES (8, 8, N'nIjAKoHJ4tKyB4n3G//haHvvL')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIdNo], [Salt]) VALUES (9, 0, N'nIjAKoHJ4tKyB4n3G//haHvvL')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIdNo], [Salt]) VALUES (10, 24, N'L2ztYgmclU2xPvk576wnmDJyf')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIdNo], [Salt]) VALUES (11, 25, N'BlSgKOWupIyPuwmHG485ehhsiDs=')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIdNo], [Salt]) VALUES (18, 34, N'ZNjrg9+kY7sgt04tv0IdzFyNuQ==')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIdNo], [Salt]) VALUES (19, 35, N'I1/hjNlLJB1frSSSEM611WrY2A==')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIdNo], [Salt]) VALUES (20, 36, N'RkJF9AUc87mjf9Zd9aaMkPR9cQ==')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIdNo], [Salt]) VALUES (21, 37, N'lDuhcH/exFAz4gG9T1LKWnUcIA==')
GO
INSERT [dbo].[Salt] ([IdNo], [LoginIdNo], [Salt]) VALUES (22, 1038, N'NWoZK3kTsExUV00Ywo1G5jlUKKs=')
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
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (7, N'Support Staff 2', 7, N'Support Staff including cleaners, drivers, maintenance personnel', N'SN2', N'Support Staff 2')
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
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (22, N'Engineering Staff1', NULL, N'test', N'STF', N'Engineering Staff1')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (23, N'STAFF 3', 7, N'S', N'STA', N'STAFF 3')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (24, N'New Group', 6, N'test', N'New ', N'New Group')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (25, N'dfasdfsdf', NULL, N'dfsasdfsdfsdfsdf', NULL, N'dfasdfsdf')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (26, N'arnel', 1, NULL, N'ar', N'arnel')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (27, N'xxxxxx', NULL, N'ssdsdfsdfsdf', N'xxx', N'xxxxxx')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (28, N'May', 8, N'May', N'Mayu', N'May')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (29, N'antony', 8, N'andnd', N'ant', N'antony')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (30, N'cvxxcvxcv', 8, N'dfsdsdfsdfsdf', N'vcxc', N'cvxxcvxcv')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (31, N'qqqqq', 8, N'qqqqqq', N'qqq', N'qqqqq')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (32, N'zzzzzzzzzzzz', 8, N'dfdfdfsdsdf...', N'aaa', N'zzzzzzzzzzzz')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (33, N'tttt', 8, N'ttttt', N'tttt', N'tttt')
GO
INSERT [dbo].[SecurityGroup] ([IdNo], [SecurityGroupName], [ParentIdNo], [Notes], [SecurityGroupCode], [SecurityGroupNameAra]) VALUES (35, N'ccccc', 8, N'ddddd', N'ccccc', N'ccccc')
GO
SET IDENTITY_INSERT [dbo].[SecurityGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[SecurityObject] ON 
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (1, N'_Developer', NULL, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (2, N'_Administrator', NULL, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (3, N'_Manager', NULL, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (4, N'_Supervisor', NULL, NULL, N'dfdfdf')
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (5, N'_User1', NULL, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (6, N'_Guest', NULL, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (7, N'_User2', NULL, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (8, N'_User3', N'_User3', NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (9, N'Main.Account', N'Main.Account', NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (10, N'Main.Account.Masters', N'Main.Menu.Masters', 9, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (11, N'Main.Account.Masters.General', NULL, 10, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (12, N'Main.Account.Masters.General.PhoneTypes', NULL, 11, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (13, N'Main.Account.Masters.General.Religions', NULL, 11, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (20, N'Main.Account.Masters.Employee', NULL, 10, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (21, N'Main.Account.Masters.Employee.Employees', N'Main.Menu.Masters.Employee.Employees', 20, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (22, N'Main.Account.Masters.Translations', NULL, 10, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (23, N'Main.Account.Masters.Translations.Captions', NULL, 22, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (24, N'Main.Account.Masters.Translations.Messages', NULL, 22, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (25, N'Main.Account.Masters.Payroll', NULL, 10, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (27, N'Main.Account.Transactions', N'Main.Menu.Transactions', 9, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (28, N'Main.Account.Transactions.GeneralJournal', NULL, 27, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (29, N'Main.Account.Masters.CustomerClients', N'Main.Menu.Masters.CustomerClients', 10, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (30, N'Main.Account.Transactions.CashDisbursement', NULL, 27, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (31, N'Main.Account.Transactions.CashReceptSales', NULL, 27, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (32, N'Main.Account.Masters.SupplierVendors', N'Main.Menu.Masters.SupplierVendors', 10, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (33, N'Main.Account.Reports', N'Main.Menu.Reports', 9, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (34, N'Main.Account.Masters.General.RevCostCenters', NULL, 11, N'Only the Developer should have access to this objects')
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (35, N'Main.Account.Masters.General.Countries', NULL, 11, N'admin user2')
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (36, N'Main.Account.Masters.General.Branches', NULL, 11, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (37, N'Main.Account.Masters.General.RevCostCenters', NULL, 11, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (38, N'Main.Account.Masters.General.Departments', NULL, 11, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (39, N'Main.ToolStrip.Translate', NULL, NULL, N's')
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (42, N'Main.Account.Masters.General.ChartOfAccounts', NULL, 11, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (44, N'Translators', NULL, NULL, N'Users who are allowed to translate captions and messages.')
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (45, N'Translators_Developer', N'Translators_Developer', NULL, N'Access to Developer restricted strings.')
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (46, N'Main.Account.Masters.General.RevenueGroups', NULL, 11, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (47, N'Main.Account.Masters.General.DistributionSchemes', NULL, 11, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (48, N'Main.Account.Masters.General.Banks', NULL, 11, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (49, N'Main.Account.Masters.General.Categories', NULL, 11, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (50, N'Main.Account.Masters.General.Items', NULL, 11, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (51, N'Main.Account.Masters.Security', NULL, 10, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (52, N'Main.Account.Masters.Security.SecurityGroups', NULL, 51, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (53, N'Main.Account.Masters.Security.SecurityObjects', NULL, 51, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (54, N'Main.Account.Masters.Security.Users', NULL, 51, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (55, N'Main.Account.Masters.Employee.Designations', N'Main.Menu.Masters.Employee.Designations', 20, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (56, N'Main.Account.Masters.Translations.CaptionsBatchEdit', N'Main.Menu.Masters.Translations.CaptionsBatchEdit', 22, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (57, N'Main.Account.Masters.Translations.CreateAllmessages', NULL, 22, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (58, N'Main.Account.Transactions.PettyCash', NULL, 27, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (59, N'Main.Account.Transactions.AccountsPayable', NULL, 27, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (60, N'Main.Account.Transactions.AccountsReceivable', NULL, 27, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (61, N'Main.Account.Transactions.CheckDisbursement', NULL, 27, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (62, N'Main.Account.Transactions.SalesJournal', NULL, 27, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (63, N'Main.Account.Transactions.AccountReconciliation', NULL, 27, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [Notes]) VALUES (64, N'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx', N'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[SecurityObject] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIdNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (5, N'BETH', N'bToIlHpGvJiufgXQ273sNyJGn7U=', 97, N'Beth M', NULL, NULL)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIdNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (6, N'ARNEL', N'zHGeeKaglmP+6HQfNY+goAxymBs=', 1, N'Arnel Antonio T. Marcelo', N'Arnel Antonio T. Marcelo', 10)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIdNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (8, N'ISPADMIN', N'CbIz3PHw+NCgezZaVb2PbSW0ThQ=', 8, N'Arnel Antonio Marcelo', N'Arnel Antonio Marcelo', 10)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIdNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (23, N'Yousef', N'CFXbl31704Oss1JHrLt+2ELw864=', 8, N'Ahmad Doghim', N'Ahmad Doghim', 7)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIdNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (24, N'JANU', N'1zgJDTKLfhbnvD2SUbdDF/+wdOU=', 1, N'Jan Uriel Marcelo', N'Jan Uriel Marcelo', 10)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIdNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (25, N'USER', N'B/c7pgaWijSX6OMYtrfFr4nQprk=', 0, N'Ordinary User', N'Ordinary User', 7)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIdNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (34, N'Olhan', N'uwEpheK3clcx+us0gQVALZOclHg=', 8, N'Rolando Gatbunton', NULL, NULL)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIdNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (35, N'Ehab', N'glbeOq63N+8huPlfFxthaunzBYk=', 8, N'Ehab Bakheer', NULL, NULL)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIdNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (36, N'Susan', N'ln4pt0JbeWt0IOao9+obqN40qjA=', 11, N'Susan Britanico', N'Susan Britanico', 4)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIdNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (37, N'Marwan', N'JovqtqeogZKibVN5/dPgNqZt5AU=', 1, N'Marwan Fetyani', N'Marwan Fetyani', 7)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIdNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (38, N'DELL', N'1', 1, N'ARNEL', N'ARNEL', 10)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIdNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (1038, N'Dell I7', N'gNvqSyQA6WHPZu1hHx8rX/Rghak=', 1, N'Dell', N'Dell', 8)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIdNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (1039, N'MAY', N'1', 1, N'MAY MARCELO', N'MAY MARCELO', 10)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SecurityGroupName]    Script Date: 4/28/2020 2:02:33 PM ******/
ALTER TABLE [dbo].[SecurityGroup] ADD  CONSTRAINT [IX_SecurityGroupName] UNIQUE NONCLUSTERED 
(
	[SecurityGroupName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_User] FOREIGN KEY([IdNo])
REFERENCES [dbo].[User] ([IdNo])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_User]
GO
