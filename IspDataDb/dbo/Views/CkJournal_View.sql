

CREATE VIEW [dbo].[CkJournal_View]
AS
SELECT        dbo.CkJournal.IdNo, dbo.CkJournal.TransactionDate, dbo.CkJournal.ReferenceNo, dbo.CkJournal.Amount, 
                         dbo.CkJournal.AccountIdNo, dbo.CkJournal.PaymentType, dbo.CkJournal.PayeeIdNo, dbo.CkJournal.PayeeName, 
                         dbo.CkJournal.ORNumber, dbo.CkJournal.DiscountTaken, 
                         dbo.CkJournal.DiscountAccountIdNo, dbo.CkJournal.Applied, dbo.CkJournal.UnApplied, dbo.CkJournal.VatNumber, 
                         dbo.CkJournal.VatAmount, dbo.CkJournal.Notes, dbo.CkJournal.Posted, dbo.CkJournal.DateCreated, dbo.CkJournal.Cancelled, 
                         dbo.CkJournal.DateTimeStamp, dbo.currency_conversion(dbo.CkJournal.Amount) AS WordAmount, dbo.Bank.BankCode, dbo.Bank.BankNameAra, 
                         dbo.BankAccount.BranchName
FROM            dbo.CkJournal INNER JOIN
                         dbo.BankAccount ON dbo.CkJournal.AccountIdNo = dbo.BankAccount.AccountIdNo INNER JOIN
                         dbo.Bank ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo