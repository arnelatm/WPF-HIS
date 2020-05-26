







CREATE PROC [dbo].[InsertPcsOiItemTVP]
  @MParam PcsOiItemInsert READONLY
AS 
INSERT  INTO PcsOiItem ( Amount, ApOpenInvoiceIdNo, DiscountTaken, PcsIdNo, [Sequence] )
        SELECT  Amount, ApOpenInvoiceIdNo, DiscountTaken, PcsIdNo, [Sequence]
        FROM    @MParam
SET IDENTITY_INSERT DBO.PcsOiItem ON;

