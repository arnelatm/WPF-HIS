


CREATE PROC [dbo].[InsertPurchaseDetailTVP]
  @MParam PurchaseDetailInsert READONLY
AS 
INSERT  INTO PurchaseDetail ( BonusQuantity, DiscountAmount, NetAmount, Price, ProductIdNo, PurchaseIdNo, Quantity, [Sequence], UnitIdNo, UnitSalesPrice, VatAmount, VatPercent)
        SELECT  BonusQuantity, DiscountAmount, NetAmount, Price, ProductIdNo, PurchaseIdNo, Quantity, [Sequence], UnitIdNo, UnitSalesPrice, VatAmount, VatPercent
        FROM    @MParam
SET IDENTITY_INSERT DBO.PurchaseDetail ON;