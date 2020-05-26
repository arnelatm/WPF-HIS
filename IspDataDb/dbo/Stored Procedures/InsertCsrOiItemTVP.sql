





CREATE PROC [dbo].[InsertCsrOiItemTVP]
  @MParam CsrOiItemInsert READONLY
AS 
INSERT  INTO CsrOiItem ( Amount, ArOpenInvoiceIdNo, CsrIdNo, DiscountTaken, [Sequence] )
        SELECT  Amount, ArOpenInvoiceIdNo, CsrIdNo, DiscountTaken, [Sequence]
        FROM    @MParam
SET IDENTITY_INSERT DBO.CsrOiItem ON;

