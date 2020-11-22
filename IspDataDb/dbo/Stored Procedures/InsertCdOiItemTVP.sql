






CREATE PROC [dbo].[InsertCdOiItemTVP]
  @MParam CdOiItemInsert READONLY
AS 
INSERT  INTO CdOiItem ( Amount, ApOpenInvoiceIdNo, DjIdNo, DiscountTaken, Sequence )
        SELECT  Amount, ApOpenInvoiceIdNo, DjIdNo, DiscountTaken, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CdOiItem ON;