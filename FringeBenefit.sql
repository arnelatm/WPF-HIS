USE [ISPDATA]
GO
SET IDENTITY_INSERT [dbo].[FringeBenefit] ON 
GO
INSERT [dbo].[FringeBenefit] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (1, N'OTC', N'Overtime Cost', N'Overtime Cost', N'M', NULL, N'H')
GO
INSERT [dbo].[FringeBenefit] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (2, N'OTE', N'Overtime Expense', N'Overtime Expense', N'M', NULL, N'H')
GO
INSERT [dbo].[FringeBenefit] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (3, N'HAC', N'Housing Allowance Cost', N'Housing Allowance Cost', N'M', NULL, N'R')
GO
INSERT [dbo].[FringeBenefit] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (4, N'HAE', N'Housing Allowance Expense', N'Housing Allowance Expense', N'M', NULL, N'R')
GO
INSERT [dbo].[FringeBenefit] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (5, N'TAC', N'Transportation Allowance Cost', N'Transportation Allowance Cost', N'M', NULL, N'R')
GO
INSERT [dbo].[FringeBenefit] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (6, N'TAE', N'Transportation Allowance Expense', N'Transportation Allowance Expense', N'M', NULL, N'R')
GO
INSERT [dbo].[FringeBenefit] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (7, N'FAC', N'Food Allowance Cost', N'Food Allowance Cost', N'M', NULL, N'R')
GO
INSERT [dbo].[FringeBenefit] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (8, N'FAE', N'Food Allowance Expense', N'Food Allowance Expense', N'M', NULL, N'R')
GO
INSERT [dbo].[FringeBenefit] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (9, N'VPC', N'Vacation Pay Cost', N'Vacation Pay Cost', N'Y', NULL, N'P')
GO
INSERT [dbo].[FringeBenefit] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (10, N'VPE', N'Vacation Pay Expense', N'Vacation Pay Expense', N'Y', NULL, N'P')
GO
INSERT [dbo].[FringeBenefit] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (11, N'BNC', N'Bonus Cost', N'Bonus Cost', N' ', NULL, N'O')
GO
INSERT [dbo].[FringeBenefit] ([IdNo], [FringeBenefitCode], [FringeBenefitName], [FringeBenefitNameAra], [DefaultFrequency], [AccountIdNo], [FringeBenefitType]) VALUES (12, N'BNE', N'Bonus Expense', NULL, N' ', NULL, N'O')
GO
SET IDENTITY_INSERT [dbo].[FringeBenefit] OFF
GO
