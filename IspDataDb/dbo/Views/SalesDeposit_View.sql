

CREATE VIEW [dbo].[SalesDeposit_View]
AS
SELECT        dbo.SalesDeposit.IdNo, dbo.SalesDeposit.SalesJournalIdNo, dbo.SalesDeposit.Sequence, dbo.SalesDeposit.SaleAmount, dbo.SalesDeposit.DepositAmount, dbo.SalesDeposit.DepositTypeIdNo, 
                         dbo.DepositType.DepositTypeCode, dbo.DepositType.DepositTypeName, dbo.DepositType.AccountIdNo, dbo.DepositType.Rate, dbo.DepositType.BankChargesAccountIdNo, 
                         dbo.DepositType.BankChargesVatAccountIdNo, dbo.DepositType.DepositTypeNameAra
FROM            dbo.SalesDeposit INNER JOIN
                         dbo.DepositType ON dbo.SalesDeposit.DepositTypeIdNo = dbo.DepositType.IdNo
GO



GO


