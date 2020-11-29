








CREATE PROC [dbo].[InsertCkOiItemTVP]
  @MParam CkOiItemInsert READONLY
AS 
INSERT  INTO CkOiItem ( Amount, ApOpenInvoiceIdNo, DiscountTaken, DjIdNo, Sequence )
        SELECT  Amount, ApOpenInvoiceIdNo, DiscountTaken, DjIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CkOiItem ON;