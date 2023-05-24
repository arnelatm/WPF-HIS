


CREATE PROC [dbo].[InsertPurchaseDetailTVP]
  @MParam PurchaseDetailInsert READONLY
AS 
INSERT  INTO PurchaseDetail ( BonusQuantity, DiscountAmount, ExpiryDate, NetAmount, Price, ProductIdNo, PurchaseIdNo, Quantity, [Sequence], UnitIdNo, UnitSalesPrice, VatAmount, VatPercent)
        SELECT  BonusQuantity, DiscountAmount, ExpiryDate, NetAmount, Price, ProductIdNo, PurchaseIdNo, Quantity, [Sequence], UnitIdNo, UnitSalesPrice, VatAmount, VatPercent
        FROM    @MParam
SET IDENTITY_INSERT DBO.PurchaseDetail ON;