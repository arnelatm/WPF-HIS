



CREATE VIEW [dbo].[ARJournalTransaction_View]
AS
SELECT        dbo.ArJournalItem.Sequence, dbo.ArJournalItem.JournalIdNo, dbo.ArJournalItem.Debit, dbo.ArJournalItem.Credit, dbo.ArJournalItem.Notes, dbo.ArJournalItem.Posted, dbo.Customer.CustomerCode, 
                         dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, dbo.ArJournal.TransactionDate, dbo.ArJournal.ReferenceNo, dbo.ArJournal.Amount, dbo.ArJournal.InvoiceNo, dbo.ArJournal.InvoiceDate, 
                         dbo.ArJournal.Notes AS 'DetailNotes', dbo.ArJournal.Posted AS 'JOurnalPosted', dbo.ArJournal.Cancelled, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra, dbo.RevCostCenter.RevCostCenterCode
FROM            dbo.RevCostCenter RIGHT OUTER JOIN
                         dbo.ArJournalItem ON dbo.RevCostCenter.IdNo = dbo.ArJournalItem.RevCostCenterIdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.ArJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.ArJournal LEFT OUTER JOIN
                         dbo.Customer ON dbo.ArJournal.CustomerIdNo = dbo.Customer.IdNo ON dbo.ArJournalItem.JournalIdNo = dbo.ArJournal.IDNo
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ARJournalTransaction_View';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'  Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ARJournalTransaction_View';


GO




