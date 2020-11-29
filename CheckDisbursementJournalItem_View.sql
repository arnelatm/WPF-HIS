USE [ISPDATA]
GO

/****** Object:  View [dbo].[CkJournalItem_View]    Script Date: 3/18/2020 11:06:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[CkJournalItem_View]
AS
SELECT        dbo.CkJournalItem.AccountIdNo, dbo.CkJournalItem.Credit, dbo.CkJournalItem.Debit, dbo.CkJournalItem.IdNo, 
                         dbo.CkJournalItem.JournalIdNo, dbo.CkJournalItem.Notes, dbo.CkJournalItem.RevCostCenterIdNo, dbo.CkJournalItem.Sequence, 
                         dbo.Account.AccountName, dbo.CkJournalItem.Debit - dbo.CkJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.CkJournal INNER JOIN
                         dbo.CkJournalItem ON dbo.CkJournal.IdNo = dbo.CkJournalItem.JournalIdNo INNER JOIN
                         dbo.Account ON dbo.CkJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CkJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO


