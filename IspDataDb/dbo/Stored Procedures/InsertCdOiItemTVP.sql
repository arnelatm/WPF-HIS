






CREATE PROC [dbo].[InsertCdOiItemTVP]
  @MParam CdOiItemInsert READONLY
AS 
INSERT  INTO CdOiItem ( Amount, ApOpenInvoiceIdNo, CjIdNo, DiscountTaken, Sequence )
        SELECT  Amount, ApOpenInvoiceIdNo, CjIdNo, DiscountTaken, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CdOiItem ON;