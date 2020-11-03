
CREATE PROC [dbo].[InsertSalesCashItemTVP]
  @MParam SalesCashItemInsert READONLY
AS 
INSERT  INTO SalesCashItem ( PaymentTypeIdNo, DepositAmount, SaleAmount, SalesJournalIdNo, Sequence )
        SELECT  PaymentTypeIdNo, DepositAmount, SaleAmount, SalesJournalIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.SalesCashItem ON;

