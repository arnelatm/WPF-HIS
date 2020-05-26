




CREATE PROC [dbo].[InsertCkdOiItemTVP]
  @MParam CkdOiItemInsert READONLY
AS 
INSERT  INTO CkdOiItem ( Amount, CkdIdNo, DiscountTaken, ApOpenInvoiceIdNo, Sequence )
        SELECT  Amount, CkdIdNo, DiscountTaken, JournalItemIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CkdOiItem ON;

