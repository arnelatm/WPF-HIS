





CREATE PROC [dbo].[InsertCadOiItemTVP]
  @MParam CadOiItemInsert READONLY
AS 
INSERT  INTO CadOiItem ( Amount, CadIdNo, DiscountTaken, ApOpenInvoiceIdNo, Sequence )
        SELECT  Amount, CadIdNo, DiscountTaken, JournalItemIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CadOiItem ON;

