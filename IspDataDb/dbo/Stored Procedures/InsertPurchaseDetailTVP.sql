




CREATE PROC [dbo].[InsertPurchaseDetailTVP]
  @MParam PurchaseDetailInsert READONLY
AS 
INSERT  INTO PurchaseDetail ( BatchNo, BonusQuantity, DiscountAmount, ExpiryDate, NetAmount, Price, ProductIdNo, PurchaseIdNo, Quantity, [Sequence], UnitIdNo, UnitSalesPrice, VatAmount, VatPercent)
        SELECT  BatchNo, BonusQuantity, DiscountAmount, ExpiryDate, NetAmount, Price, ProductIdNo, PurchaseIdNo, Quantity, [Sequence], UnitIdNo, UnitSalesPrice, VatAmount, VatPercent
        FROM    @MParam
SET IDENTITY_INSERT DBO.PurchaseDetail ON;