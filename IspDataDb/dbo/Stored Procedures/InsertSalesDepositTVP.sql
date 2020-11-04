

CREATE PROC [dbo].[InsertSalesDepositTVP]
  @MParam SalesDepositInsert READONLY
AS 
INSERT  INTO SalesDeposit ( PaymentTypeIdNo, DepositAmount, SaleAmount, SalesJournalIdNo, Sequence )
        SELECT  PaymentTypeIdNo, DepositAmount, SaleAmount, SalesJournalIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.SalesDeposit ON;