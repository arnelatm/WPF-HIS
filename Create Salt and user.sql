USE [ISPDATA]
GO
/****** Object:  Table [dbo].[Salt]    Script Date: 02/12/2020 16:34:23 ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 02/12/2020 16:34:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdNo] [smallint] IDENTITY(18,1) NOT NULL,
	[UserName] [varchar](20) NOT NULL,
	[Password] [varchar](50) NULL,
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
SET IDENTITY_INSERT [dbo].[Salt] OFF
GO

SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (6, N'ARNEL', N'zHGeeKaglmP+6HQfNY+goAxymBs=', 1, N'Arnel Antonio T. Marcelo', N'Arnel Antonio T. Marcelo', 10)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (8, N'ISPADMIN', N'CbIz3PHw+NCgezZaVb2PbSW0ThQ=', 8, N'Arnel Antonio Marcelo', N'Arnel Antonio Marcelo', 10)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (23, N'Yousef', N'CFXbl31704Oss1JHrLt+2ELw864=', 8, N'Ahmad Doghim', N'Ahmad Doghim', 7)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (25, N'USER', N'B/c7pgaWijSX6OMYtrfFr4nQprk=', 0, N'Ordinary User', N'Ordinary User', 7)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (34, N'Olhan', N'uwEpheK3clcx+us0gQVALZOclHg=', 8, N'Rolando Gatbunton', NULL, NULL)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (35, N'Ehab', N'glbeOq63N+8huPlfFxthaunzBYk=', 8, N'Ehab Bakheer', NULL, NULL)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (36, N'Susan', N'nUjZ6qIaujVMzyyDQBqD4tE765Q=', 11, N'Susan Britanico', N'Susan Britanico', 5)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (37, N'Marwan', N'JovqtqeogZKibVN5/dPgNqZt5AU=', 1, N'Marwan Fetyani', N'Marwan Fetyani', 7)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (38, N'DELL', N'1', 1, N'ARNEL', N'ARNEL', 10)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (1038, N'Dell I7', N'gNvqSyQA6WHPZu1hHx8rX/Rghak=', 1, N'Dell', N'Dell', 8)
GO
INSERT [dbo].[User] ([IdNo], [UserName], [Password], [SecurityGroupIDNo], [FullName], [FullNameAra], [SecurityLevel]) VALUES (1039, N'MAY', N'1', 1, N'MAY MARCELO', N'MAY MARCELO', 10)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_User] FOREIGN KEY([IdNo])
REFERENCES [dbo].[User] ([IdNo])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_User]
GO
