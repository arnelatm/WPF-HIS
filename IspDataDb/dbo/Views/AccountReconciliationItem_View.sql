
CREATE   VIEW [dbo].[AccountReconciliationItem_View]
AS
SELECT        dbo.AccountReconciliationItem.IdNo, dbo.AccountReconciliationItem.Sequence, dbo.GlLedgers_View.TransactionDate, dbo.GlLedgers_View.IdNo AS JournalItemIdNo, dbo.GlLedgers_View.JournalCode, 
                         dbo.AccountReconciliationItem.AccountReconciliationIdNo, dbo.GlLedgers_View.Debit, dbo.GlLedgers_View.DocumentNumber, dbo.GlLedgers_View.Credit, dbo.AccountReconciliationItem.Cleared, dbo.GlLedgers_View.AccountIdNo, dbo.GlLedgers_View.PayDescription, 
                         dbo.GlLedgers_View.PayDescriptionAra, dbo.GlLedgers_View.ReferenceNo, dbo.GlLedgers_View.JournalIdNo, CONVERT(bit, CASE WHEN ReconciledMarker.IdNo IS NULL THEN 0 ELSE 1 END) AS Reconciled, dbo.AccountReconciliation.Posted
FROM            dbo.GlLedgers_View
			      LEFT OUTER JOIN dbo.AccountReconciliationItem 
				     ON dbo.GlLedgers_View.JournalCode = dbo.AccountReconciliationItem.JournalCode Collate SQL_Latin1_General_CP1_CI_AS AND dbo.GlLedgers_View.IdNo = dbo.AccountReconciliationItem.JournalItemIdNo
				  LEFT OUTER JOIN dbo.AccountReconciliation 
					 ON dbo.AccountReconciliationItem.AccountReconciliationIdNo = dbo.AccountReconciliation.IdNo
				  LEFT OUTER JOIN (
					  SELECT JournalCode, JournalItemIdNo, MIN(IdNo) AS IdNo
					  FROM dbo.Reconciled
					  GROUP BY JournalCode, JournalItemIdNo
				  ) AS ReconciledMarker
					 ON dbo.GlLedgers_View.JournalCode = ReconciledMarker.JournalCode COLLATE SQL_Latin1_General_CP1_CI_AS
					AND dbo.GlLedgers_View.IdNo = ReconciledMarker.JournalItemIdNo
