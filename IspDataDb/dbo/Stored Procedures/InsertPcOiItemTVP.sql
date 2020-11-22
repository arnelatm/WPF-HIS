







CREATE PROC [dbo].[InsertPcOiItemTVP]
  @MParam PcOiItemInsert READONLY
AS 
INSERT  INTO PcOiItem ( Amount, ApOpenInvoiceIdNo, DjIdNo, DiscountTaken, Sequence )
        SELECT  Amount, ApOpenInvoiceIdNo, DjIdNo, DiscountTaken, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PcOiItem ON;