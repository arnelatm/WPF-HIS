





CREATE PROC [dbo].[InsertCsrOiItemTVP]
  @MParam CsrOiItemInsert READONLY
AS 
INSERT  INTO CsrOiItem ( Amount, CsrIdNo, DiscountTaken, JournalItemIdNo, Sequence )
        SELECT  Amount, CsrIdNo, DiscountTaken, JournalItemIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CsrOiItem ON;

