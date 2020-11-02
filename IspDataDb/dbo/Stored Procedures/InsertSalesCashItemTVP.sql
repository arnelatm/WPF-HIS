
CREATE PROC [dbo].[InsertSalesCashItemTVP]
  @MParam SalesCashItemInsert READONLY
AS 
INSERT  INTO SalesCashItem ( CashCodeIdNo, DepositAmount, SaleAmount, SalesJournalIdNo, Sequence )
        SELECT  CashCodeIdNo, DepositAmount, SaleAmount, SalesJournalIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.SalesCashItem ON;

