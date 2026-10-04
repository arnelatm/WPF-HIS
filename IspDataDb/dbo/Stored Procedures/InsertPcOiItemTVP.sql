








CREATE PROC [dbo].[InsertPcOiItemTVP]
  @MParam PcOiItemInsert READONLY
AS 
INSERT  INTO PcOiItem ( Amount, ApOpenInvoiceIdNo, DiscountTaken, DjIdNo, Sequence )
        SELECT  Amount, ApOpenInvoiceIdNo, DiscountTaken, DjIdNo, Sequence
        FROM    @MParam
