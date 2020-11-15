USE [ISPDATA]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (1, NULL, N'1', N'ASSETS', N'الأصول', NULL, 0, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (2, NULL, N'2', N'LIABILITIES', N'خصوم', NULL, 0, N'L', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (3, NULL, N'3', N'EQUITIES', N'راس المال', NULL, 0, N'E', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (4, NULL, N'4', N'Profit (Loss)', N'اجنالى الربح ( الخسارة )', NULL, 0, N'S', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, NULL, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (5, 1, N'5', N'Current Assets', N'الاصول المتداوله', NULL, 0, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (6, 5, N'6', N'Cash & Cash Equiv.', N'النقد والنقد المماثل', NULL, 0, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (7, 5, N'7', N'Accounts Receivables', N'حساب الذمم المدينه', NULL, 0, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (8, 5, N'8', N'Total Inventory', N'اجمالى المخزون', NULL, 0, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (9, 1, N'9', N'Fixed Assets', N'الاصول الثابته', NULL, 0, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (10, 9, N'10', N'Fixed Assets Orig. Value', N'القيمة الاصليه للاصول الثابته', NULL, 0, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (11, 9, N'11', N'Accumulated Depreciation', N'الاستهلاك المتراكم', NULL, 0, N'A', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (12, 1, N'12', N'Deferred Assets', N'الاصول المؤجله', NULL, 0, N'A', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (14, 2, N'14', N'Current Liabilities', N'المطلوبات المتداوله', NULL, 0, N'L', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (15, 14, N'15', N'Total Accounts Payable', N'اجمالى حسابات الموردين', NULL, 0, N'L', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (16, 14, N'16', N'VAT Payable', N'ضريبة موردين', NULL, 0, N'L', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (17, 14, N'17', N'Accrued Expenses', N'مصروفات مستحقه', NULL, 0, N'L', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 4, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (18, 2, N'18', N'Long Term Liabilities', N'مطلوبات طويلة الاجل', NULL, 0, N'L', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, 4, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (19, 4, N'19', N'Gross Profit', N'اجمالي الربح', NULL, 0, N'S', NULL, NULL, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 0, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (20, 19, N'20', N'Sales/Revenue', N' مبيعات وايرادات', NULL, 0, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (21, 20, N'21', N'Revenue (Clinic)', N'ايرادات عيادات', NULL, 0, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (22, 20, N'22', N'Sales (Pharmacy)', N'المبيعات والايرادات ( صي)', NULL, 0, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (23, 19, N'23', N'Cost of Goods Sold', N'تكلفة البضاعه المباعه1', NULL, 0, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (24, 23, N'24', N'Clinic Costs', N'تكلفة عيادات', NULL, 0, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (25, 23, N'25', N'Cost of Goods Sold Pharmacy', N'تكلفة البضاعه المباعه', NULL, 0, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (26, 4, N'26', N'General & Adm. Expenses', N'مصروفات عموميه واداريه', NULL, 0, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (27, 4, N'27', N'Other Income/(Loss)', N'ايرادات اخرى', NULL, 0, N'S', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (99, NULL, N'599', N'Income Summary', N'الدخل', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 5, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (104, 6, N'104', N'Cash on Hand2', N'النقديه', NULL, 1, N'A', 10102.4700, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'CS', 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (105, 6, N'105', N'Cash in Cash Register', N'النقد فى الكاشير', NULL, 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'CS', 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (106, 6, N'106', N'Cash in Bank NCB (PC)', N'البنك الاهلى التجارى ( مجمع)', NULL, 1, N'A', 5157.5200, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'CK', 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (107, 6, N'107', N'Cash in Bank Riyad Bank', N'بنك الرياض ( مجمع)', NULL, 1, N'A', 15034.6700, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'CK', 4, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (108, 6, N'108', N'Petty Cash', N'مبلغ صغير', NULL, 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'CS', 5, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (109, 6, N'109', N'Cash in Bank NCB (Phar.)', N'البنك الاهلى التجارى ( ص)', NULL, 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'BA', 6, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (111, 6, N'111', N'Collectibles Under Adj.', N'مبالغ تحت التسويه', NULL, 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 7, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (112, 7, N'112', N'Accounts Receivables Current', N'حساب الذمم المدينه عملاء ', NULL, 1, N'A', 523616.7600, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'AR', 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (113, 6, N'113', N'Imprest Fund', N'السلفه المستديمه', NULL, 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'PC', 8, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (114, 7, N'114', N'Employee Loans', N'سلف عاملين', NULL, 1, N'A', 82979.9100, 0.0000, NULL, NULL, N'D', NULL, NULL, N'E', 0, NULL, 1, N'EL', 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (115, 6, N'115', N'NCB Marwan', N'NCB Marwan', NULL, 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'BA', 9, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (116, 7, N'116', N'Other Accounts Receivable', N'Other Accounts Receivable', NULL, 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 4, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (118, 8, N'118', N'Inventory (Pharmacy)', N'مخزون الصيدليه', N'', 1, N'A', 189662.4100, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (119, 8, N'119', N'Inventory (Clinic)', N'مخزن الطوارئ', N'', 1, N'A', 27423.2700, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (122, 6, N'122', N'Cash in Bank SBB (Old)', N'Cash in Bank SBB (Old)', NULL, 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'BA', 10, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (123, 7, N'123', N'Copayment/Co-insurance', N'Copayment/Co-insurance', NULL, 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (124, 7, N'124', N'Other Accounts Rec.', N'ذمم مدينه اخرى', NULL, 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'C', 0, NULL, 1, N'AR', 4, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (125, 6, N'125', N'NCB (WALISET)', N'البنك الاهلى ( ولى سيت )', NULL, 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'BA', 11, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (126, 5, N'126', N'Other Current Assets', N'موجودات متداوله اخرى', NULL, 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (127, 6, N'127', N'Cash in bank Riyad (Pharmacy)', N'بنك الرياض ( صيدليه )', NULL, 1, N'A', 11.2100, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'CK', 12, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (128, 7, N'128', N'Advances to Suppliers', N'Advances to Suppliers', NULL, 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'S', 0, NULL, 1, N'AS', 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (136, 10, N'136', N'Build. & Improv Orig. Val', N'مبانى', N'', 1, N'A', 551444.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (137, 10, N'137', N'Land', N'اراضى', N'', 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (138, 10, N'138', N'Decor. & Improv. Orig Val', N'ديكورات وتحسينات', N'', 1, N'A', 1663410.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (140, 10, N'140', N'Furn. & Fixt. Orig. Val.', N'اثاث ومفروشات', N'', 1, N'A', 694799.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (142, 10, N'142', N'Elect. Equip. Orig. Val.', N'اجهزه كهربائيه', N'', 1, N'A', 733118.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (143, 10, N'143', N'Air Conditioner Orig. Val', N'مكيفات', N'', 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (144, 10, N'144', N'Medical Equip. Orig. Val.', N'اجهزه ومعدات طبيه', N'', 1, N'A', 2168695.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 7, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (146, 10, N'146', N'Cars & Veh. Orig. Value', N'سيارات ووسائل نقل', N'', 1, N'A', 352341.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 8, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (148, 10, N'148', N'Adv. Board Orig. Value', N'لوحات اعلانيه', N'', 1, N'A', 57100.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 9, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (150, 10, N'150', N'Small Tools Orig. Value', N'عدد وادوات معمليه', N'', 1, N'A', 7731.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 10, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (152, 10, N'152', N'Computers/IT Eqp. Or.Val.', N'اجهزة كمبيوتر وملحقاتها', N'', 1, N'A', 202346.5700, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 11, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (166, 11, N'166', N'Acc. Depr. Build. & Imp', N'اهلاك مبانى', N'', 1, N'A', 0.0000, 89369.0300, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (168, 11, N'168', N'Acc. Dep. Decor & Improv', N'اهلاك ديكورات وتحسينات', N'', 1, N'A', 0.0000, 489987.1500, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (170, 11, N'170', N'Acc. Dep. Furn. & Fixt.', N'اهلاك اثاث ومفروشات', N'', 1, N'A', 0.0000, 464560.8100, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (172, 11, N'172', N'Acc. Dep. Elect. Eqpt.', N'اهلاك اجهزه كهربائيه', N'', 1, N'A', 0.0000, 692003.2300, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (173, 11, N'173', N'Acc. Dep. Air Cond.', N'Acc. Dep. Air Cond.', N'', 1, N'A', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (174, 11, N'174', N'Acc. Dep. Medical Eqpt.', N'اهلاك اجهزه ومعدات طبيه', N'', 1, N'A', 0.0000, 1821418.1700, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (176, 11, N'176', N'Acc. Dep. Cars & Veh.', N'اهلاك سيارات ووسائل نقل', N'', 1, N'A', 0.0000, 347343.4200, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 7, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (178, 11, N'178', N'Acc. Dep. Adv. Board', N'اهلاك لوحات اعلانيه', N'', 1, N'A', 0.0000, 45233.8800, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 8, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (180, 11, N'180', N'Acc. Dep. Small Tools', N'اهلاك عدد وادوات معمليه', N'', 1, N'A', 0.0000, 5555.5800, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 9, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (181, 11, N'181', N'Acc. Dep. Computers/IT Eq', N'اهلاك اجهزة كمبيوتر وملحق', N'', 1, N'A', 0.0000, 141319.5400, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 10, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (188, 12, N'188', N'Prepaid Expenses', N'مصروفات مدفوعه مقدما', NULL, 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (190, 1, N'190', N'Other Assets', N'اصول اخرى', N'', 1, N'A', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (193, 14, N'193', N'Marwan Curr Account', N'جارى مروان', N'', 1, N'L', 0.0000, 1649945.9500, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (202, 15, N'202', N'Accounts Payable Pharmacy', N'موردين الصيدليه', NULL, 1, N'L', 0.0000, 186616.2300, NULL, NULL, N'C', NULL, NULL, N'S', 0, NULL, 1, N'AP', 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (203, 15, N'203', N'Accounts Payable Clinic', N'موردين العيادات', N'', 1, N'L', 0.0000, 22992.8900, NULL, NULL, N'C', NULL, NULL, N'S', NULL, NULL, 1, N'AP', 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (204, 15, N'204', N'Accounts Payable Stocks', N'موردين مخزن الادويه', NULL, 1, N'L', 0.0000, 117693.5400, NULL, NULL, N'C', NULL, NULL, N'S', 0, NULL, 1, N'AP', 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (205, 15, N'205', N'Accounts Payable Lab.', N'موردين المختبر', N'', 1, N'L', 0.0000, 274586.8100, NULL, NULL, N'C', NULL, NULL, N'S', NULL, NULL, 1, N'AP', 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (207, 15, N'207', N'Accounts Payable Dental', N'موردين عيادات الاسنان', N'', 1, N'L', 0.0000, 68751.0000, NULL, NULL, N'C', NULL, NULL, N'S', NULL, NULL, 1, N'AP', 4, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (208, 18, N'208', N'Acc End of Service Awards', N'مخصص نهاية الخدمه', NULL, 1, N'L', 0.0000, 146793.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (210, 15, N'210', N'Accounts Payable', N'الموردين', N'', 1, N'L', 0.0000, 4926.7100, NULL, NULL, N'C', NULL, NULL, N'S', NULL, NULL, 1, N'AP', 5, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (212, 17, N'212', N'Accrued Expenses Others', N'مصاريف مستحقه اخرى', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (213, 17, N'213', N'Accrued Salaries & Wages', N'رواتب مستحقه', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (214, 17, N'214', N'Accrued Overtime & Bonus', N'اضافى وبونص مستحق', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (215, 17, N'215', N'Accrued Rent Clinic', N'ايجار مستحق عيادات', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (216, 17, N'216', N'Accrued Rent Pharmacy', N'ايجار مستحق صيدليه', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (217, 17, N'217', N'Accrued Tickets', N'تذاكر مستحقه', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (218, 17, N'218', N'Accrued Vacation Pay', N'اجازات مستحقه', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 7, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (219, 17, N'219', N'Accrued Rent Employees', N'ايجارات مستحقه موظفين', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 8, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (222, 2, N'222', N'Deferred Payment', N'الدفع المؤجل', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (223, 17, N'223', N'Provision for Zakah', N'ذكاه مستحقه', N'', 1, N'L', 0.0000, 3616.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 9, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (224, 14, N'224', N'Loan (Mr. Marwan)', N'قرض حسن', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (225, 15, N'225', N'Contract Payable', N'عقود موردين', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, N'S', NULL, NULL, 1, N'AP', 6, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (226, 15, N'226', N'Accounts Payable X-Ray', N'موردين قسم الاشعه', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, N'S', NULL, NULL, 1, N'AP', 7, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (227, 15, N'227', N'Acc. Payable Under Adjust', N'حسابات موردين تحت التسوي', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, N'S', NULL, NULL, 1, N'AP', 8, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (228, 16, N'228', N'VAT on Capital Goods', N'ضريبة القيمه المضافه على', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, N'VI', 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (229, 16, N'229', N'VAT on Purchases (Input)', N'ضريبة مشتريات', N'', 1, N'L', 28181.2200, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, N'VI', 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (230, 15, N'230', N'Bounced Check Payable', N'ارتداد شيك مستحق الدفع', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, N'S', NULL, NULL, 1, N'AP', 9, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (231, 16, N'231', N'VAT on Cr/Db Card Charges', N'ضريبة القيمه المضافه على العمليات البنكيه ', NULL, 1, N'L', 1072.8000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'VI', 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (232, 16, N'232', N'VAT on Rev/Sales (Output)', N'ضريبة الدخل', N'', 1, N'L', 0.0000, 278775.9700, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, N'VO', 4, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (233, 16, N'233', N'VAT on Rev (SaudiExemp)', N'ضريبة القيمه المضافه ( سعودين )', NULL, 1, N'L', 113049.8700, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'VO', 5, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (234, 16, N'234', N'VAT Payments', N'مدفوعات ضريبة القيمه المضافه', NULL, 1, N'L', 98173.0400, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, 6, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (238, 16, N'238', N'VAT on Sale (Self) (Outp)', N'صضريبة مبيعات', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, N'VO', 7, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (240, 15, N'240', N'Customer Advances', N'Customer Advances', NULL, 1, N'L', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'C', 0, NULL, 1, N'CA', 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (242, 14, N'242', N'Accrued Vat', N'ضريبة مستحقه ', NULL, 1, N'L', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 7, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (250, 2, N'250', N'Sanduk Al-Tanmeya', N'صندوق التنميه', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (290, 2, N'290', N'Other Liabilities', N'مطلوبات اخرى', N'', 1, N'L', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (310, 3, N'310', N'Owner''s Capital', N'راس المال', N'', 1, N'E', 0.0000, 300000.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (320, 3, N'320', N'Retained Earnings', N'الارباح المدوره', N'', 1, N'E', 0.0000, 373960.8100, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, N'RE', 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (390, 3, N'390', N'Current Earnings', N'الارباح المحققة', N'', 1, N'E', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, N'CE', 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (401, 22, N'401', N'Sales (Undistributed)', N'Sales (Undistributed)', NULL, 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, N'SL', 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (402, 22, N'402', N'Sales Cash VATable', N'مبيعات كاش خاضعه للضريبه', N'', 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (403, 21, N'403', N'Revenue Credit VATable', N'ايرادات اجله خاضعه للضريب', N'', 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (404, 27, N'404', N'Sales Credit (Self)', N'مبيعات اجله مجمع خاضعه للضريبة', NULL, 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (408, 21, N'408', N'Revenue Credit Zero VAT', N'ايرادات اجله غير خاضعه  للضريبه', NULL, 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, 4, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (409, 22, N'409', N'Sales Cr. Co. Zero VAT', N'مبيعات اجله شركات  غير خاضعه للضريبه', NULL, 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, 4, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (410, 22, N'410', N'Sales Cr. Clin. Zero VAT', N'مبيعات اجله مجمع غير خاضع', N'', 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (411, 24, N'411', N'Purchase Discount Clinic', N'خصم مشتريات', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, N'PD', 5, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (412, 21, N'412', N'Purchase Bonus Clinic', N'بونص مشتريات عيادات', N'', 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (413, 21, N'413', N'Revenue (Cash) Zero VAT', N'ايرادات غير خاضعه للضريبه', N'', 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 7, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (414, 22, N'414', N'Sales Cash Zero VAT', N'مبيعات كاش غير خاضعه للضريبه', NULL, 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, 6, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (415, 22, N'415', N'Sales Return', N'مرتجع مبيعات', N'', 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 7, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (416, 22, N'416', N'Sales Discount', N'خصم مبيعات', N'', 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 8, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (417, 21, N'417', N'Revenue (Undistributed)', N'Revenue (Undistributed)', NULL, 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, N'SL', 8, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (418, 21, N'418', N'Revenue Return', N'عائد ايرادات ( مرتجع )', N'', 1, N'R', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 9, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (419, 21, N'419', N'Accts. Rec. Discount', N'Accts. Rec. Discount', NULL, 1, N'R', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'RD', 10, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (421, 21, N'421', N'Accts. Rec. Deductions', N'Accts. Rec. Deductions', N'', 1, N'R', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 11, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (422, 24, N'422', N'Injections', N'ابر', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (423, 24, N'423', N'Infusions', N'تمويل', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (424, 24, N'424', N'Vaccines', N'تطعيمات', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (425, 24, N'425', N'Medical Supplies/Services', N'اللوازم الطبيه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (426, 21, N'426', N'Revenue (Cash) VATable', N'ايرادات خاضعه للضريبه', N'', 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 12, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (427, 24, N'427', N'Baladiya Cards', N'بلديه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (428, 22, N'428', N'Sales Cr. Co. VATable', N'مبيعات اجله خاضعه للضريبه', N'', 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 9, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (429, 24, N'429', N'Stocks Consumption', N'مخزون الاستهلاك', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (430, 27, N'430', N'Revenue (Self)', N'ايرادات علاجات عاملين', NULL, 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 0, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (431, 24, N'431', N'Salaries & Wages (Med)', N'رواتب واجور', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'E', NULL, NULL, 1, NULL, 7, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (432, 24, N'432', N'Overtime (Medical)', N'اضافى', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'E', NULL, NULL, 1, NULL, 8, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (433, 24, N'433', N'Bonus & Other Wages (Med)', N'بونص ومزايا', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'E', NULL, NULL, 1, NULL, 9, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (434, 24, N'434', N'Housing Allowance (Med.)', N'بدل سكن', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'E', NULL, NULL, 1, NULL, 10, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (435, 24, N'435', N'Vacation Pay (Medical)', N'اجازات سنويه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'E', NULL, NULL, 1, NULL, 11, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (436, 24, N'436', N'End of Service Awards Med', N'نهاية خدمه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'E', NULL, NULL, 1, NULL, 12, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (437, 24, N'437', N'Tickets (Medical)', N'تذاكر سفر', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'E', NULL, NULL, 1, NULL, 13, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (438, 24, N'438', N'Permits & Licenses (Med)', N'رسوم حكوميه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 14, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (439, 24, N'439', N'Medical & Other Ben. (Med', N'علاجات عاملين', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'E', NULL, NULL, 1, NULL, 15, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (440, 24, N'440', N'Maintenance & Repairs Med', N'صيانة اجهزه طبيه ', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 16, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (441, 24, N'441', N'Office Supplies (Medical)', N'صيانة واصلاح ( طبى )', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 17, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (442, 24, N'442', N'Hospital Operation/Refer.', N'عمليات بالمستشفى ( تحويل)', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 18, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (443, 24, N'443', N'Transportation Costs (Med', N'مصاريف نقل ( طبى )', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 19, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (444, 24, N'444', N'Rent', N'Rent', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 20, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (445, 24, N'445', N'Medical Insurance', N'تأمين طبى', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 21, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (446, 24, N'446', N'Hum.Res.Dev.Fund Subsidy', N'الاعاشة', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (447, 447, N'447', N'Purchase Discount (Clinic)', N'Purchase Discount (Clinic)', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'PD', 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (450, 24, N'450', N'Miscellaneous Costs', N'تكاليف متنوعه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 23, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (468, 24, N'468', N'Medicines (Co. Clients)', N'Medicines (Co. Clients)', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 24, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (480, 25, N'480', N'Beginning Inventory Phar.', N'مخزون اول المده صيدليه', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'BI', 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (481, 25, N'481', N'Beginning Inv. (Al-Tazaj)', N'Beginning Inv. (Al-Tazaj)', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (484, 25, N'484', N'Purchases (Pharmacy)', N'مشتريات الصيدليه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (486, 25, N'486', N'Purchase Returns Pharm.', N'مردودات المشتريات', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (488, 22, N'488', N'Purchase Bonus (Pharmacy)', N'بونص مشتريات ( صيدليه )', N'', 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, NULL, NULL, 1, NULL, 10, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (489, 25, N'489', N'Purchase Discount Pharm.', N'خصم المشتريات', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'PD', 5, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (490, 25, N'490', N'Ending Inventory Pharm.', N'مخزون نهاية المده للصيدلي', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'EI', 6, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (491, 25, N'491', N'Ending Inv. (Al-Tazaj)', N'Ending Inv. (Al-Tazaj)', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 7, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (499, 27, N'499', N'Other Income', N'ايرادات اخرى_', NULL, 1, N'R', 0.0000, 0.0000, NULL, NULL, N'C', NULL, NULL, NULL, 0, NULL, 1, NULL, 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (511, 26, N'511', N'Salaries & Wages (Admin.)', N'رواتب واجور ومافى حكمها', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'E', NULL, NULL, 1, NULL, 1, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (512, 26, N'512', N'Overtime (Admin.)', N'اجور اضافيه وعمولات', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'E', NULL, NULL, 1, NULL, 2, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (513, 26, N'513', N'Bonus & Other Wages (Adm)', N'بونص', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'E', NULL, NULL, 1, NULL, 3, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (514, 26, N'514', N'Tickets (Admin.)', N'تذاكر سفر ادارين ', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'E', 0, NULL, 1, NULL, 4, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (515, 26, N'515', N'Profess./Consultant Fees', N'رسوم استشارى', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (516, 26, N'516', N'Permits & Licenses (Adm.)', N'رسوم واشتراكات وتأشيرات حكوميه ', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 6, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (517, 26, N'517', N'Advertising/Promotions', N'الاعلان', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 7, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (518, 26, N'518', N'Elect. & Water', N'كهرباء ومياه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 8, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (519, 26, N'519', N'Maint. & Repairs Bld. Adm', N'صيانه واصلاح مبانى', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 9, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (520, 26, N'520', N'Office Supplies (Admin)', N'قرطاسيه ومطبوعات', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 10, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (521, 26, N'521', N'Cleaning Supp. & Laundry', N'مصاريف ومواد نظافه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 11, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (522, 26, N'522', N'Cars Maintenance', N'صيانة سيارات', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 12, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (523, 26, N'523', N'Petrol & Oil', N'زيوت ومحروقات', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 13, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (524, 26, N'524', N'Miscellaneous Exp.', N'مصروفات متنوعه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 14, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (525, 26, N'525', N'Recruitment Fees', N'رسوم التوظيف', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 15, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (526, 26, N'526', N'Medical & Other Ben. (Ad)', N'علاجات عاملين اداري', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'E', 0, NULL, 1, NULL, 16, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (527, 26, N'527', N'Discount Allowance', N'خصم مسموح به', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, N'RD', 17, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (528, 26, N'528', N'Telephone, Fax & Post', N'هاتف وبريد', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 18, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (529, 26, N'529', N'Zakah', N'ذكاه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 19, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (530, 26, N'530', N'Rent Expense (Admin.)', N'ايجارات', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 20, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (531, 26, N'531', N'Social Insurance', N'تأمينات اجتماعيه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 21, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (532, 26, N'532', N'Bank Charges/Commissions', N'عمولات بنكيه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (533, 26, N'533', N'Transpor./Freight Expense', N'مصاريف نقل وانتقال', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 23, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (534, 26, N'534', N'Entertainment Expense', N'مصروفات ضيافه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 24, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (535, 26, N'535', N'Vacation Pay (Admin.)', N'اجازات سنويه ادارين ', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, N'E', 0, NULL, 1, NULL, 25, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (536, 26, N'536', N'End of Serv. Awards (Adm)', N' نهاية خدمه ادارين ', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 26, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (537, 26, N'537', N'Membership/Dues/Subscr.', N'العضويه / الاشتراكات', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 27, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (538, 26, N'538', N'Housing Allowance (Admin)', N'بدل سكن ادارين ', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 28, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (539, 26, N'539', N'Staff Training & Educ.', N'تأمين سيارات', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 29, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (540, 26, N'540', N'Car Insurance', N'تأمين سيارات', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 30, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (541, 26, N'541', N'Maint. & Repairs Equipm.', N'مصاريف صيانة اجهزه طبيه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 31, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (542, 26, N'542', N'Charity Donations', N'مساعدات عينيه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 32, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (543, 26, N'543', N'Baladiya', N'رسوم  اصدار كروت بلديه', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 33, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (544, 26, N'544', N'LEGAL EXPENSES', N'أتعاب مهنيه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 34, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (545, 26, N'545', N'Bad Debt Loss', N'ديون معدومه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 35, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (546, 26, N'546', N'Security Expenses', N'حراسات امنيه', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 36, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (547, 26, N'547', N'Medical Insurance Exp.', N'تامين طبى', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 37, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (548, 26, N'548', N'IQAMA FEES (EFADA)', N'اقامه ( حكوميه )', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 38, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (549, 26, N'549', N'Maintenance Building', N'صيانة مبانى', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 39, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (550, 26, N'550', N'COMMISSIONS', N'عمولات', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 40, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (551, 26, N'551', N'Bank Charges (Income)', N'عمولا بنكيه ( على الايراد )', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 41, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (552, 26, N'552', N'MOH Fees', N'رسوم حكوميه', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 42, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (553, 26, N'553', N'Software', N'البرمجيات', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 43, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (554, 26, N'554', N'Computer Supplies', N'مستلزمات كمبيوتر', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 44, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (560, 26, N'560', N'Previous Years Unpaid Exp', N'مصروفات مستحقه2', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 45, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (565, 26, N'565', N'Depreciation Expense', N'مصاريف الاستهلاك', N'', 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, NULL, NULL, 1, NULL, 46, NULL)
GO
INSERT [dbo].[Account] ([IdNo], [ParentIDNo], [AccountCode], [AccountName], [AccountNameAra], [Notes], [DetailAccount], [AccountGroup], [BYDebit], [BYCredit], [Debit], [Credit], [NormalBalance], [CloseDebit], [CloseCredit], [PayeeType], [WithReconciliation], [IncomeExpSummary], [Active], [SpecialAccount], [GroupSortOrder], [CreateDate]) VALUES (590, 26, N'590', N'Other Expenses', N'مصروفات اخرى', NULL, 1, N'X', 0.0000, 0.0000, NULL, NULL, N'D', NULL, NULL, NULL, 0, NULL, 1, NULL, 2, NULL)
GO
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[AccountBalance] ON 
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (1, 2017, 106, 487308.7600, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (2, 2017, 112, 584565.6000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (3, 2017, 114, 172017.7500, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (4, 2017, 118, 300269.8400, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (5, 2017, 119, 119409.3600, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (6, 2017, 138, 1340778.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (7, 2017, 140, 541922.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (8, 2017, 142, 435065.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (9, 2017, 144, 2017445.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (10, 2017, 146, 352341.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (11, 2017, 148, 57100.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (12, 2017, 150, 5796.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (13, 2017, 168, 0.0000, 304432.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (14, 2017, 170, 0.0000, 381774.8300)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (15, 2017, 172, 0.0000, 532748.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (16, 2017, 174, 0.0000, 1621137.6800)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (17, 2017, 176, 0.0000, 221470.4200)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (18, 2017, 178, 0.0000, 33691.3800)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (19, 2017, 180, 0.0000, 5189.3300)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (20, 2017, 193, 0.0000, 1517951.8700)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (21, 2017, 210, 0.0000, 12258.9000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (22, 2017, 310, 0.0000, 300000.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (23, 2017, 320, 0.0000, 584787.3800)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (24, 2017, 212, 0.0000, 5000.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (25, 2017, 213, 0.0000, 475473.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (26, 2017, 208, 0.0000, 146793.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (27, 2017, 136, 351944.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (28, 2017, 166, 0.0000, 31490.0300)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (29, 2017, 152, 165893.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (30, 2017, 181, 0.0000, 87203.7000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (31, 2017, 143, 242870.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (32, 2017, 202, 0.0000, 352485.7500)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (33, 2017, 203, 0.0000, 152657.4100)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (34, 2017, 204, 0.0000, 215575.4500)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (35, 2017, 205, 0.0000, 221155.8000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (36, 2017, 125, 999.4200, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (37, 2017, 223, 0.0000, 5063.8000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (38, 2017, 207, 32615.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (39, 2018, 106, 479360.8200, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (40, 2018, 107, 0.0400, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (41, 2018, 111, 1224.7300, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (42, 2018, 112, 552833.2700, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (43, 2018, 114, 144393.8000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (44, 2018, 118, 341037.6800, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (45, 2018, 119, 96081.0200, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (46, 2018, 125, 999.4200, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (47, 2018, 127, 5000.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (48, 2018, 136, 511944.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (49, 2018, 138, 1663410.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (50, 2018, 140, 606669.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (51, 2018, 142, 451548.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (52, 2018, 143, 281570.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (53, 2018, 144, 2175195.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (54, 2018, 146, 352341.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (55, 2018, 148, 57100.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (56, 2018, 150, 7731.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (57, 2018, 152, 183128.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (58, 2018, 166, 0.0000, 48533.0300)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (59, 2018, 168, 0.0000, 360906.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (60, 2018, 170, 0.0000, 401292.1600)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (61, 2018, 172, 0.0000, 586138.6000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (62, 2018, 174, 0.0000, 1711750.6800)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (63, 2018, 176, 0.0000, 266345.4200)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (64, 2018, 178, 0.0000, 37538.8800)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (65, 2018, 180, 0.0000, 5292.0800)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (66, 2018, 181, 0.0000, 104293.4900)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (67, 2018, 193, 0.0000, 1790351.6700)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (68, 2018, 202, 0.0000, 390119.9100)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (69, 2018, 203, 0.0000, 103175.9600)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (70, 2018, 204, 0.0000, 148923.2500)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (71, 2018, 205, 0.0000, 241386.8000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (72, 2018, 207, 0.0000, 54460.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (73, 2018, 208, 0.0000, 146793.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (74, 2018, 210, 0.0000, 53633.3800)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (75, 2018, 213, 0.0000, 385553.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (76, 2018, 223, 0.0000, 4972.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (77, 2018, 226, 0.0000, 10230.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (78, 2018, 310, 0.0000, 300000.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (79, 2018, 320, 0.0000, 759877.4700)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (80, 2019, 104, 16894.6700, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (81, 2019, 106, 311831.9800, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (82, 2019, 107, 20637.1400, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (83, 2019, 111, 2893.5300, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (84, 2019, 112, 526218.6700, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (85, 2019, 114, 160915.9800, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (86, 2019, 118, 184209.0600, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (87, 2019, 119, 50879.1200, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (88, 2019, 127, 5000.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (89, 2019, 136, 511944.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (90, 2019, 138, 1663410.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (91, 2019, 140, 694799.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (92, 2019, 142, 733118.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (93, 2019, 144, 2160695.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (94, 2019, 146, 352341.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (95, 2019, 148, 57100.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (96, 2019, 150, 7731.0000, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (97, 2019, 152, 202346.5700, 0.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (98, 2019, 166, 0.0000, 65701.0300)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (99, 2019, 168, 0.0000, 417381.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (100, 2019, 170, 0.0000, 432346.1100)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (101, 2019, 172, 0.0000, 640653.8500)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (102, 2019, 174, 0.0000, 1761545.1700)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (103, 2019, 176, 0.0000, 311220.4200)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (104, 2019, 178, 0.0000, 41386.3800)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (105, 2019, 180, 0.0000, 5423.8300)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (106, 2019, 181, 0.0000, 122442.9100)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (107, 2019, 193, 0.0000, 1867513.2500)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (108, 2019, 202, 0.0000, 297895.6500)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (109, 2019, 203, 0.0000, 34041.5100)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (110, 2019, 204, 0.0000, 180066.4600)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (111, 2019, 205, 0.0000, 240078.1900)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (112, 2019, 207, 0.0000, 72502.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (113, 2019, 208, 0.0000, 146793.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (114, 2019, 210, 0.0000, 63687.7600)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (115, 2019, 213, 0.0000, 320029.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (116, 2019, 226, 0.0000, 11651.4400)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (117, 2019, 310, 0.0000, 300000.0000)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (118, 2019, 320, 0.0000, 297971.2300)
GO
INSERT [dbo].[AccountBalance] ([IdNo], [Year], [AccountIdNo], [Debit], [Credit]) VALUES (119, 2019, 242, 0.0000, 32634.5300)
GO
SET IDENTITY_INSERT [dbo].[AccountBalance] OFF
GO
