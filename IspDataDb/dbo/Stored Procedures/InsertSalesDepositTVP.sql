

CREATE PROC [dbo].[InsertSalesDepositTVP]
  @MParam SalesDepositInsert READONLY
AS 
INSERT  INTO SalesDeposit ( DepositTypeIdNo, DepositAmount, SaleAmount, SalesJournalIdNo, Sequence )
        SELECT  DepositTypeIdNo, DepositAmount, SaleAmount, SalesJournalIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.SalesDeposit ON;