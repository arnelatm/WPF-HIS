USE [ISPDATA]
GO
/****** Object:  Table [dbo].[List]    Script Date: 1/10/2022 9:37:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[List](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[ListIdNo] [smallint] NULL,
	[ListName] [varchar](100) NULL,
	[ListNameAra] [nvarchar](100) NULL,
 CONSTRAINT [PK_List] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListCoded]    Script Date: 1/10/2022 9:37:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListCoded](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[ListIdNo] [smallint] NULL,
	[ListName] [varchar](100) NULL,
	[ListNameAra] [nvarchar](100) NULL,
 CONSTRAINT [PK_ListCoded_1] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListGroup]    Script Date: 1/10/2022 9:37:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListGroup](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[ListName] [varchar](50) NULL,
	[ListNameAra] [nvarchar](50) NULL,
	[Coded] [bit] NULL,
	[Closed] [bit] NULL,
 CONSTRAINT [PK_ListGroup] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[List] ON 
GO
INSERT [dbo].[List] ([IdNo], [ListIdNo], [ListName], [ListNameAra]) VALUES (1, 1, N'Dr.', NULL)
GO
INSERT [dbo].[List] ([IdNo], [ListIdNo], [ListName], [ListNameAra]) VALUES (2, 1, N'Mr.', NULL)
GO
INSERT [dbo].[List] ([IdNo], [ListIdNo], [ListName], [ListNameAra]) VALUES (3, 1, N'Ms.', NULL)
GO
INSERT [dbo].[List] ([IdNo], [ListIdNo], [ListName], [ListNameAra]) VALUES (4, 1, N'Mrs.', NULL)
GO
SET IDENTITY_INSERT [dbo].[List] OFF
GO
SET IDENTITY_INSERT [dbo].[ListGroup] ON 
GO
INSERT [dbo].[ListGroup] ([IdNo], [ListName], [ListNameAra], [Coded], [Closed]) VALUES (1, N'NameTitle', NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[ListGroup] OFF
GO
