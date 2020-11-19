
CREATE VIEW [dbo].[CdJournal_View]
AS
SELECT        dbo.CashDisbursementJournal.IdNo, dbo.CashDisbursementJournal.TransactionDate, dbo.CashDisbursementJournal.ReferenceNo, dbo.CashDisbursementJournal.Amount, 
                         dbo.CashDisbursementJournal.AccountIdNo, dbo.CashDisbursementJournal.PaymentType, dbo.CashDisbursementJournal.PayeeIdNo, dbo.CashDisbursementJournal.PayeeName, 
                         dbo.CashDisbursementJournal.ORNumber, dbo.CashDisbursementJournal.DiscountTaken, 
                         dbo.CashDisbursementJournal.DiscountAccountIdNo, dbo.CashDisbursementJournal.Applied, dbo.CashDisbursementJournal.UnApplied, dbo.CashDisbursementJournal.VatNumber, 
                         dbo.CashDisbursementJournal.VatAmount, dbo.CashDisbursementJournal.Notes, dbo.CashDisbursementJournal.Posted, dbo.CashDisbursementJournal.DateCreated, dbo.CashDisbursementJournal.Cancelled, 
                         dbo.CashDisbursementJournal.DateTimeStamp, dbo.currency_conversion(dbo.CashDisbursementJournal.Amount) AS WordAmount, dbo.Bank.BankCode, dbo.Bank.BankNameAra, 
                         dbo.BankAccount.BranchName
FROM            dbo.CashDisbursementJournal INNER JOIN
                         dbo.BankAccount ON dbo.CashDisbursementJournal.AccountIdNo = dbo.BankAccount.AccountIdNo INNER JOIN
                         dbo.Bank ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo