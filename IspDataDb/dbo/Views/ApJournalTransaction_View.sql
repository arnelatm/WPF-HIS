


CREATE VIEW [dbo].[ApJournalTransaction_View]
AS
SELECT        dbo.ApJournalItem.JournalIdNo, dbo.ApJournalItem.AccountIdNo AS ApAccountIdNo, dbo.ApJournalItem.Debit, dbo.ApJournalItem.Credit, dbo.ApJournalItem.RevCostCenterIdNo, dbo.ApJournalItem.Notes AS ApNotes, 
                         dbo.ApJournalItem.Sequence, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierNameAra, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra, 
                         dbo.ApJournal.TransactionDate, dbo.ApJournal.ReferenceNo, dbo.ApJournal.TransactionType, dbo.ApJournal.Amount, dbo.ApJournal.AccountIdNo, dbo.ApJournal.InvoiceNo, dbo.ApJournal.InvoiceDate, 
                         dbo.ApJournal.VatNumber, dbo.ApJournal.VatAmount, dbo.ApJournal.Notes, dbo.ApJournal.DueDate, dbo.ApJournal.SettlementDueDate, dbo.ApJournal.SettlementDiscount, dbo.ApJournal.Posted, dbo.ApJournal.Cancelled, 
						 dbo.ApJournal.Approved, dbo.ApJournal.DateCreated, dbo.RevCostCenter.RevCostCenterNameAra, dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName
FROM          dbo.ApJournalItem 
			  LEFT OUTER JOIN dbo.RevCostCenter 
			  ON dbo.ApJournalItem.RevCostCenterIdNo = dbo.RevCostCenter.IdNo 
			  LEFT OUTER JOIN dbo.Account 
			  ON dbo.ApJournalItem.AccountIdNo = dbo.Account.IdNo 
			  LEFT OUTER JOIN dbo.ApJournal  
			  INNER JOIN dbo.Supplier 
			  ON dbo.ApJournal.SupplierIdNo = dbo.Supplier.IdNo 
			  ON dbo.ApJournalItem.JournalIdNo = dbo.ApJournal.IDNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ApJournalTransaction_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'    Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ApJournalTransaction_View';

