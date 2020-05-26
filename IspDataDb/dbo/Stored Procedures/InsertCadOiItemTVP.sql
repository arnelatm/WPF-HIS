





CREATE PROC [dbo].[InsertCadOiItemTVP]
  @MParam CadOiItemInsert READONLY
AS 
INSERT  INTO CadOiItem ( Amount, ApOpenInvoiceIdNo, CadIdNo, DiscountTaken, Sequence )
        SELECT  Amount, ApOpenInvoiceIdNo, CadIdNo, DiscountTaken, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CadOiItem ON;

