
CREATE VIEW [dbo].[CdJournal_View]
AS
SELECT        dbo.CdJournal.IdNo, dbo.CdJournal.TransactionDate, dbo.CdJournal.ReferenceNo, dbo.CdJournal.Amount, 
                         dbo.CdJournal.AccountIdNo, dbo.CdJournal.PaymentType, dbo.CdJournal.PayeeIdNo, dbo.CdJournal.PayeeName, 
                         dbo.CdJournal.ORNumber, dbo.CdJournal.DiscountTaken, 
                         dbo.CdJournal.DiscountAccountIdNo, dbo.CdJournal.Applied, dbo.CdJournal.UnApplied, dbo.CdJournal.VatNumber, 
                         dbo.CdJournal.VatAmount, dbo.CdJournal.Notes, dbo.CdJournal.Posted, dbo.CdJournal.DateCreated, dbo.CdJournal.Cancelled, 
                         dbo.CdJournal.DateTimeStamp, dbo.currency_conversion(dbo.CdJournal.Amount) AS WordAmount, dbo.Bank.BankCode, dbo.Bank.BankNameAra, 
                         dbo.BankAccount.BranchName
FROM            dbo.CdJournal INNER JOIN
                         dbo.BankAccount ON dbo.CdJournal.AccountIdNo = dbo.BankAccount.AccountIdNo INNER JOIN
                         dbo.Bank ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo