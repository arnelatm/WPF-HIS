USE [ISPDATA]
GO

/****** Object:  View [dbo].[CheckDisbursementJournalItem_View]    Script Date: 3/18/2020 11:06:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[CheckDisbursementJournalItem_View]
AS
SELECT        dbo.CheckDisbursementJournalItem.AccountIdNo, dbo.CheckDisbursementJournalItem.Credit, dbo.CheckDisbursementJournalItem.Debit, dbo.CheckDisbursementJournalItem.IdNo, 
                         dbo.CheckDisbursementJournalItem.JournalIdNo, dbo.CheckDisbursementJournalItem.Notes, dbo.CheckDisbursementJournalItem.ProfitCenterIdNo, dbo.CheckDisbursementJournalItem.Sequence, 
                         dbo.Chart.AccountName, dbo.CheckDisbursementJournalItem.Debit - dbo.CheckDisbursementJournalItem.Credit AS OriginalAmount, dbo.Chart.PayeeType, dbo.Chart.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.CheckDisbursementJournal INNER JOIN
                         dbo.CheckDisbursementJournalItem ON dbo.CheckDisbursementJournal.IdNo = dbo.CheckDisbursementJournalItem.JournalIdNo INNER JOIN
                         dbo.Chart ON dbo.CheckDisbursementJournalItem.AccountIdNo = dbo.Chart.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CheckDisbursementJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO


