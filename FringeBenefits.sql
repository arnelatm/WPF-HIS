USE [ISPDATA]
GO
/****** Object:  Table [dbo].[FringeBenefits]    Script Date: 06/09/2020 9:21:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FringeBenefits](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[FringeBenefitCode] [varchar](10) NULL,
	[FringeBenefitName] [varchar](50) NULL,
	[FringeBenefitNameAra] [nvarchar](50) NULL,
	[DefaultFrequency] [char](1) NULL,
	[AccountIdNo] [int] NULL,
	[FringeBenefitType] [char](1) NULL,
 CONSTRAINT [PK_FringeBenefits] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FringeBenefits] ON 
GO
INSERT [dbo].[FringeBenefits] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (1, N'OTC', N'Overtime Cost', N'Overtime Cost', N'M', NULL, N'H')
GO
INSERT [dbo].[FringeBenefits] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (2, N'OTE', N'Overtime Expense', N'Overtime Expense', N'M', NULL, N'H')
GO
INSERT [dbo].[FringeBenefits] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (3, N'HAC', N'Housing Allowance Cost', N'Housing Allowance Cost', N'M', NULL, N'R')
GO
INSERT [dbo].[FringeBenefits] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (4, N'HAE', N'Housing Allowance Expense', N'Housing Allowance Expense', N'M', NULL, N'R')
GO
INSERT [dbo].[FringeBenefits] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (5, N'TAC', N'Transportation Allowance Cost', N'Transportation Allowance Cost', N'M', NULL, N'R')
GO
INSERT [dbo].[FringeBenefits] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (6, N'TAE', N'Transportation Allowance Expense', N'Transportation Allowance Expense', N'M', NULL, N'R')
GO
INSERT [dbo].[FringeBenefits] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (7, N'FAC', N'Food Allowance Cost', N'Food Allowance Cost', N'M', NULL, N'R')
GO
INSERT [dbo].[FringeBenefits] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (8, N'FAE', N'Food Allowance Expense', N'Food Allowance Expense', N'M', NULL, N'R')
GO
INSERT [dbo].[FringeBenefits] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (9, N'VPC', N'Vacation Pay Cost', N'Vacation Pay Cost', N'Y', NULL, N'P')
GO
INSERT [dbo].[FringeBenefits] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (10, N'VPE', N'Vacation Pay Expense', N'Vacation Pay Expense', N'Y', NULL, N'P')
GO
INSERT [dbo].[FringeBenefits] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (11, N'BNC', N'Bonus Cost', N'Bonus Cost', N' ', NULL, N'O')
GO
INSERT [dbo].[FringeBenefits] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (12, N'BNE', N'Bonus Expense', NULL, N' ', NULL, N'O')
GO
SET IDENTITY_INSERT [dbo].[FringeBenefits] OFF
GO
