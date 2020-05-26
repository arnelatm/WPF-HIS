







CREATE PROC [dbo].[InsertPcsOiItemTVP]
  @MParam PcsOiItemInsert READONLY
AS 
INSERT  INTO PcsOiItem ( Amount, PcsIdNo, DiscountTaken, ApOpenInvoiceIdNo, Sequence )
        SELECT  Amount, PcsIdNo, DiscountTaken, JournalItemIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PcsOiItem ON;

