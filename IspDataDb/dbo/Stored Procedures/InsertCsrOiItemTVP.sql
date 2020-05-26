





CREATE PROC [dbo].[InsertCsrOiItemTVP]
  @MParam CsrOiItemInsert READONLY
AS 
INSERT  INTO CsrOiItem ( Amount, ApOpenInvoiceIdNo, CsrIdNo, DiscountTaken, Sequence )
        SELECT  Amount, ApOpenInvoiceIdNo, CsrIdNo, DiscountTaken, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CsrOiItem ON;

