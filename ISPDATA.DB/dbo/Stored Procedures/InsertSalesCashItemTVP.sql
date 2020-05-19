
CREATE PROC [dbo].[InsertSalesCashItemTVP]
  @MParam SalesCashItemInsert READONLY
AS 
INSERT  INTO SalesCashItem ( CashCode, DepositAmount, SaleAmount, SalesJournalIdNo, Sequence )
        SELECT  CashCode, DepositAmount, SaleAmount, SalesJournalIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.SalesCashItem ON;

