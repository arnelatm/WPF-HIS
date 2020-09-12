USE ISPDATA
GO
SET IDENTITY_INSERT [dbo].[Earning] ON 
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [DefaultFrequency], [AccountIdNo], [EarningType]) VALUES (1, N'OTC', N'Overtime Cost', N'Overtime Cost', N'M', 432, N'H')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [DefaultFrequency], [AccountIdNo], [EarningType]) VALUES (2, N'OTE', N'Overtime Expense', N'Overtime Expense', N'M', 512, N'H')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [DefaultFrequency], [AccountIdNo], [EarningType]) VALUES (3, N'HAC', N'Housing Allowance Cost', N'Housing Allowance Cost', N'M', 434, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [DefaultFrequency], [AccountIdNo], [EarningType]) VALUES (4, N'HAE', N'Housing Allowance Expense', N'Housing Allowance Expense', N'M', 538, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [DefaultFrequency], [AccountIdNo], [EarningType]) VALUES (5, N'TAC', N'Transportation Allowance Cost', N'Transportation Allowance Cost', N'M', 433, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [DefaultFrequency], [AccountIdNo], [EarningType]) VALUES (6, N'TAE', N'Transportation Allowance Expense', N'Transportation Allowance Expense', N'M', 513, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [DefaultFrequency], [AccountIdNo], [EarningType]) VALUES (7, N'FAC', N'Food Allowance Cost', N'Food Allowance Cost', N'M', 433, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [DefaultFrequency], [AccountIdNo], [EarningType]) VALUES (8, N'FAE', N'Food Allowance Expense', N'Food Allowance Expense', N'M', 513, N'R')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [DefaultFrequency], [AccountIdNo], [EarningType]) VALUES (9, N'VPC', N'Vacation Pay Cost', N'Vacation Pay Cost', N'A', 435, N'O')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [DefaultFrequency], [AccountIdNo], [EarningType]) VALUES (10, N'VPE', N'Vacation Pay Expense', N'Vacation Pay Expense', N'Y', 535, N'O')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [DefaultFrequency], [AccountIdNo], [EarningType]) VALUES (11, N'BNC', N'Bonus Cost', N'Bonus Cost', N'A', 433, N'O')
GO
INSERT [dbo].[Earning] ([IdNo], [EarningCode], [EarningName], [EarningNameAra], [DefaultFrequency], [AccountIdNo], [EarningType]) VALUES (12, N'BNE', N'Bonus Expense', N'Bonus Expense', N'A', 513, N'O')
GO
SET IDENTITY_INSERT [dbo].[Earning] OFF
GO
