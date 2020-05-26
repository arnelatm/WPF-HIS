




CREATE PROC [dbo].[InsertCkdOiItemTVP]
  @MParam CkdOiItemInsert READONLY
AS 
INSERT  INTO CkdOiItem ( Amount, ApOpenInvoiceIdNo, CkdIdNo, DiscountTaken, Sequence )
        SELECT  Amount, ApOpenInvoiceIdNo, CkdIdNo, DiscountTaken, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CkdOiItem ON;

