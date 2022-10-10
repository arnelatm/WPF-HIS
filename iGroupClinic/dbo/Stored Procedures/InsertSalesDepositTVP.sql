

CREATE PROC [dbo].[InsertSalesDepositTVP]
  @MParam SalesDepositInsert READONLY
AS 
INSERT  INTO SalesDeposit ( DepositTypeIdNo, DepositAmount, SaleAmount, SalesJournalIdNo, Sequence, VatAmount)
        SELECT  DepositTypeIdNo, DepositAmount, SaleAmount, SalesJournalIdNo, Sequence, VatAmount
        FROM    @MParam
SET IDENTITY_INSERT DBO.SalesDeposit ON;
