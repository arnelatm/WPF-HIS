


CREATE VIEW [dbo].[GlReconciliation_View]
AS
SELECT			dbo.GlLedgers_View.JournalCode, dbo.GlLedgers_View.IdNo, dbo.GlLedgers_View.Sequence, dbo.GlLedgers_View.JournalIdNo, dbo.GlLedgers_View.AccountIdNo, dbo.GlLedgers_View.Debit, 
				dbo.GlLedgers_View.Credit,dbo.GlLedgers_View.DocumentNumber, dbo.GlLedgers_View.RevCostCenterIdNo, dbo.GlLedgers_View.Notes, dbo.GlLedgers_View.Posted, dbo.GlLedgers_View.TransactionDate, dbo.GlLedgers_View.ReferenceNo, 
				dbo.GlLedgers_View.PayDescription, dbo.GlLedgers_View.PayDescriptionAra, Reconciled.IdNo AS Reconciled
FROM			dbo.GlLedgers_View 
				LEFT OUTER JOIN (
					SELECT JournalCode, JournalItemIdNo, MIN(IdNo) AS IdNo
					FROM dbo.Reconciled
					GROUP BY JournalCode, JournalItemIdNo
				) AS Reconciled
				ON dbo.GlLedgers_View.IdNo = Reconciled.JournalitemIdNo AND dbo.GlLedgers_View.JournalCode = Reconciled.JournalCode Collate SQL_Latin1_General_CP1_CI_AS
