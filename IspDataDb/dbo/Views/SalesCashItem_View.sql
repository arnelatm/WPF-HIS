


CREATE VIEW [dbo].[SalesCashItem_View]
AS
SELECT  dbo.SalesCashItem.*, 
		dbo.CashCode.CashName, 
		dbo.CashCode.CashNameAra, 
		dbo.CashCode.Rate, 
		dbo.CashCode.BankChargesAccountIdNo, 
		dbo.CashCode.BankChargesVatAccountIdNo, 
		dbo.CashCode.AccountIdNo
FROM    dbo.SalesCashItem LEFT OUTER JOIN
        dbo.CashCode ON dbo.SalesCashItem.CashCode = dbo.CashCode.CashCode
