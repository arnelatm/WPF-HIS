USE ISPDATA
GO
SET IDENTITY_INSERT [dbo].[Earning] ON 
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Frequency], [AccountIdNo], [EarningType]) VALUES (1, N'OTC', N'Overtime Cost', N'Overtime Cost', N'M', 432, N'H')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Frequency], [AccountIdNo], [EarningType]) VALUES (2, N'OTE', N'Overtime Expense', N'Overtime Expense', N'M', 512, N'H')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Frequency], [AccountIdNo], [EarningType]) VALUES (3, N'HAC', N'Housing Allowance Cost', N'Housing Allowance Cost', N'M', 434, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Frequency], [AccountIdNo], [EarningType]) VALUES (4, N'HAE', N'Housing Allowance Expense', N'Housing Allowance Expense', N'M', 538, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Frequency], [AccountIdNo], [EarningType]) VALUES (5, N'TAC', N'Transportation Allowance Cost', N'Transportation Allowance Cost', N'M', 433, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Frequency], [AccountIdNo], [EarningType]) VALUES (6, N'TAE', N'Transportation Allowance Expense', N'Transportation Allowance Expense', N'M', 513, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Frequency], [AccountIdNo], [EarningType]) VALUES (7, N'FAC', N'Food Allowance Cost', N'Food Allowance Cost', N'M', 433, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Frequency], [AccountIdNo], [EarningType]) VALUES (8, N'FAE', N'Food Allowance Expense', N'Food Allowance Expense', N'M', 513, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Frequency], [AccountIdNo], [EarningType]) VALUES (9, N'VPC', N'Vacation Pay Cost', N'Vacation Pay Cost', N'A', 435, N'O')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Frequency], [AccountIdNo], [EarningType]) VALUES (10, N'VPE', N'Vacation Pay Expense', N'Vacation Pay Expense', N'Y', 535, N'O')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Frequency], [AccountIdNo], [EarningType]) VALUES (11, N'BNC', N'Bonus Cost', N'Bonus Cost', N'A', 433, N'O')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Frequency], [AccountIdNo], [EarningType]) VALUES (12, N'BNE', N'Bonus Expense', N'Bonus Expense', N'A', 513, N'O')
GO
SET IDENTITY_INSERT [dbo].[Earning] OFF
GO


USE [ISPDATA]
GO
/****** Object:  Table [dbo].[Deduction]    Script Date: 9/13/2020 11:43:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deduction](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[DeductionCode] [varchar](10) NULL,
	[DeductionName] [varchar](50) NULL,
	[DeductionNameAra] [nvarchar](50) NULL,
	[Frequency] [char](1) NULL,
	[AccountIdNo] [int] NULL,
	[DeductionType] [char](1) NULL,
	[DeductionPlace] [char](1) NULL,
	[ComputationType] [char](1) NULL,
	[Percentage] [decimal](4, 2) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_Deduction] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Earning]    Script Date: 9/13/2020 11:43:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Earning](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[EarningCode] [varchar](10) NULL,
	[EarningName] [varchar](50) NULL,
	[EarningNameAra] [nvarchar](50) NULL,
	[Percentage] [decimal](4, 2) NULL,
	[Frequency] [char](1) NULL,
	[AccountIdNo] [int] NULL,
	[EarningType] [char](1) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_Earning] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave]    Script Date: 9/13/2020 11:43:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[LeaveName] [varchar](100) NOT NULL,
	[LeaveNameAra] [nvarchar](100) NOT NULL,
	[NumberOfDays] [smallint] NULL,
	[Percentage] [decimal](5, 2) NULL,
	[WarningDays] [smallint] NULL,
	[Cumulative] [bit] NULL,
	[WithMaximumCumulative] [bit] NULL,
	[MaximumCumulativeDays] [smallint] NULL,
	[Notes] [nvarchar](200) NULL,
 CONSTRAINT [PK_AbsenceLeave] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Deduction] ON 
GO
INSERT [dbo].[Deduction] ([IdNo], [DeductionCode], [DeductionName], [DeductionNameAra], [Frequency], [AccountIdNo], [DeductionType], [DeductionPlace], [ComputationType], [Percentage]) VALUES (1, N'PNL', N'Penalties or Fines', N'Penalties or Fines', N'A', 0, N'O', NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Deduction] OFF
GO
SET IDENTITY_INSERT [dbo].[Earning] ON 
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Percentage], [Frequency], [AccountIdNo], [EarningType]) VALUES (1, N'OTC', N'Overtime Cost', N'Overtime Cost', NULL, N'M', 432, N'H')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Percentage], [Frequency], [AccountIdNo], [EarningType]) VALUES (2, N'OTE', N'Overtime Expense', N'Overtime Expense', NULL, N'M', 512, N'H')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Percentage], [Frequency], [AccountIdNo], [EarningType]) VALUES (3, N'HAC', N'Housing Allowance Cost', N'Housing Allowance Cost', NULL, N'M', 434, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Percentage], [Frequency], [AccountIdNo], [EarningType]) VALUES (4, N'HAE', N'Housing Allowance Expense', N'Housing Allowance Expense', NULL, N'M', 538, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Percentage], [Frequency], [AccountIdNo], [EarningType]) VALUES (5, N'TAC', N'Transportation Allowance Cost', N'Transportation Allowance Cost', NULL, N'M', 433, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Percentage], [Frequency], [AccountIdNo], [EarningType]) VALUES (6, N'TAE', N'Transportation Allowance Expense', N'Transportation Allowance Expense', NULL, N'M', 513, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Percentage], [Frequency], [AccountIdNo], [EarningType]) VALUES (7, N'FAC', N'Food Allowance Cost', N'Food Allowance Cost', NULL, N'M', 433, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Percentage], [Frequency], [AccountIdNo], [EarningType]) VALUES (8, N'FAE', N'Food Allowance Expense', N'Food Allowance Expense', NULL, N'M', 513, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Percentage], [Frequency], [AccountIdNo], [EarningType]) VALUES (9, N'VPC', N'Vacation Pay Cost', N'Vacation Pay Cost', NULL, N'A', 435, N'O')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Percentage], [Frequency], [AccountIdNo], [EarningType]) VALUES (10, N'VPE', N'Vacation Pay Expense', N'Vacation Pay Expense', NULL, N'A', 535, N'O')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Percentage], [Frequency], [AccountIdNo], [EarningType]) VALUES (11, N'BNC', N'Bonus Cost', N'Bonus Cost', NULL, N'A', 433, N'O')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [Percentage], [Frequency], [AccountIdNo], [EarningType]) VALUES (12, N'BNE', N'Bonus Expense', N'Bonus Expense', NULL, N'A', 513, N'O')
GO
SET IDENTITY_INSERT [dbo].[Earning] OFF
GO
SET IDENTITY_INSERT [dbo].[Leave] ON 
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (1, N'Sick Leave (First 30 days)', N'Sick Leave (First 30 days)', 30, CAST(100.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (2, N'Sick Leave (Next 60 Days)', N'Sick Leave (Next 60 Days)', 60, CAST(75.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (3, N'Sick Leave (Last 30 days) without pay', N'Sick Leave (Last 30 days) without pay', 0, CAST(0.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (4, N'Vacation Leave', N'Vacation Leave', 30, CAST(100.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (5, N'Bereavement Leave', N'Bereavement Leave', 5, CAST(100.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (6, N'Marriage Leave', N'Marriage Leave', 5, CAST(100.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (7, N'Maternity Leave', N'Maternity Leave', 70, CAST(100.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (8, N'Paternity Leave', N'Paternity Leave', 3, CAST(100.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (9, N'Death of Husband Leave (muslim woman)', N'Death of Husband Leave (muslim woman)', 130, CAST(100.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (10, N'Death of Husband Leave (non-muslim woman)', N'Death of Husband Leave (non-muslim woman)', 15, CAST(100.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (11, N'Maternity Leave Extension wihout Pay', N'Maternity Leave wihout Pay', 0, CAST(0.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (12, N'Examination Leave', N'Examination Leave', 1, CAST(100.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (13, N'Birth of a sick child leave', N'Birth of a sick child leave', 30, CAST(100.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (14, N'Birth of a sick child leave extension', N'Birth of a sick child leave extension', 30, CAST(0.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (15, N'Vacation Leave without pay', N'Vacation Leave without pay', 20, CAST(0.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (16, N'Eid Al-Fitr Leave', N'Eid Al-Fitr Leave', 4, CAST(100.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (17, N'Eid Al-Adha Leave', N'Eid Al-Adha Leave', 4, CAST(100.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Leave] ([IdNo], [LeaveName], [LeaveNameAra], [NumberOfDays], [Percentage], [WarningDays], [Cumulative], [WithMaximumCumulative], [MaximumCumulativeDays], [Notes]) VALUES (18, N'National Day Leave', N'National Day Leave', 1, CAST(100.00 AS Decimal(5, 2)), NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Leave] OFF
GO
