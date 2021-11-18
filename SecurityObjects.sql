USE [ISPDATA]
GO
/****** Object:  Table [dbo].[SecurityObject]    Script Date: 18/11/2021 15:12:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityObject](
	[IdNo] [int] IDENTITY(1000,1) NOT NULL,
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
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (8, N'8', N'Menu', NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (9, N'9', N'Translators', NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (10, N'10', N'Accounting', NULL, NULL, NULL, 0, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (11, N'11', N'AccountClerk', NULL, 10, NULL, 0, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (12, N'12', N'TransactionApproval', NULL, 10, NULL, 0, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (13, N'13', N'HumanResources', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES (14, N'14', N'Inventory', NULL, NULL, 3109, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[SecurityObject] OFF
GO
ALTER TABLE [dbo].[SecurityObject]  WITH CHECK ADD  CONSTRAINT [FK__SecurityObject__ParentId] FOREIGN KEY([ParentIdNo])
REFERENCES [dbo].[SecurityObject] ([IdNo])
GO
ALTER TABLE [dbo].[SecurityObject] CHECK CONSTRAINT [FK__SecurityObject__ParentId]
GO
