







CREATE PROC [dbo].[InsertCdOiItemTVP]
  @MParam CdOiItemInsert READONLY
AS 
INSERT  INTO CdOiItem ( Amount, ApOpenInvoiceIdNo, DiscountTaken, DjIdNo, Sequence )
        SELECT  Amount, ApOpenInvoiceIdNo, DiscountTaken, DjIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CdOiItem ON;
