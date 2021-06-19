USE [ISPDATA]
GO
/****** Object:  Table [dbo].[JournalPrefix]    Script Date: 6/19/2021 11:58:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JournalPrefix](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[JournalCode] [char](2) NULL,
	[JournalName] [varchar](50) NULL,
	[JournalNameAra] [nvarchar](50) NULL,
	[JournalCodeAra] [nvarchar](2) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_JournalPrefix] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[JournalPrefix] ON 
GO
INSERT [dbo].[JournalPrefix] ([IdNo], [JournalCode], [JournalName], [JournalNameAra], [JournalCodeAra]) VALUES (1, N'AP', N'Accounts Payable Journal', N'Accounts Payable Journal', N'حد')
GO
INSERT [dbo].[JournalPrefix] ([IdNo], [JournalCode], [JournalName], [JournalNameAra], [JournalCodeAra]) VALUES (2, N'AR', N'Accounts Receivable Journal', N'Accounts Receivable Journal', N'ذم')
GO
INSERT [dbo].[JournalPrefix] ([IdNo], [JournalCode], [JournalName], [JournalNameAra], [JournalCodeAra]) VALUES (3, N'CD', N'Cash Disbursement Journal', N'Cash Disbursement Journal', N'كا')
GO
INSERT [dbo].[JournalPrefix] ([IdNo], [JournalCode], [JournalName], [JournalNameAra], [JournalCodeAra]) VALUES (4, N'PC', N'Petty Cash Disbursement Journal', N'قيد المصروفات النثريه', N'من')
GO
INSERT [dbo].[JournalPrefix] ([IdNo], [JournalCode], [JournalName], [JournalNameAra], [JournalCodeAra]) VALUES (5, N'CR', N'Cash Receipt Journal', N'Cash Receipt Journal', N'ؤق')
GO
INSERT [dbo].[JournalPrefix] ([IdNo], [JournalCode], [JournalName], [JournalNameAra], [JournalCodeAra]) VALUES (6, N'SJ', N'Sales Journal', N'مجلة المبيعات', N'مب')
GO
INSERT [dbo].[JournalPrefix] ([IdNo], [JournalCode], [JournalName], [JournalNameAra], [JournalCodeAra]) VALUES (7, N'ER', N'Employee Loans Journal', N'Employee Loans Journal', N'ثق')
GO
INSERT [dbo].[JournalPrefix] ([IdNo], [JournalCode], [JournalName], [JournalNameAra], [JournalCodeAra]) VALUES (8, N'GJ', N'General Journal Journal', N'General Journal Journal', N'عا')
GO
INSERT [dbo].[JournalPrefix] ([IdNo], [JournalCode], [JournalName], [JournalNameAra], [JournalCodeAra]) VALUES (9, N'BB', N'Beginning Balance', N'Beginnng Balance', N'بد')
GO
SET IDENTITY_INSERT [dbo].[JournalPrefix] OFF
GO