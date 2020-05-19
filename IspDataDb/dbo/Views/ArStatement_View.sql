


CREATE VIEW [dbo].[ArStatement_View]
AS
SELECT        dbo.ArDetails_View.JournalCode, dbo.ArDetails_View.IdNo, dbo.ArDetails_View.Sequence, dbo.ArDetails_View.JournalIdNo, dbo.ArDetails_View.AccountIdNo, dbo.ArDetails_View.Debit, dbo.ArDetails_View.Credit, 
                         dbo.ArDetails_View.ProfitCenterIdNo, dbo.ArDetails_View.Notes, dbo.ArDetails_View.Posted, dbo.ArDetails_View.CustomerIdNo, dbo.ArDetails_View.InvoiceNo, dbo.ArDetails_View.TransactionDate, dbo.ArDetails_View.ReferenceNo, 
                         dbo.ArDetails_View.TransactionType, dbo.Chart.SpecialAccount, dbo.ARDetails_View.MainNote
FROM            dbo.ArDetails_View INNER JOIN
                         dbo.Chart ON dbo.ArDetails_View.AccountIdNo = dbo.Chart.IDNo
WHERE        (dbo.Chart.SpecialAccount = 'AR')
