





CREATE PROC [dbo].[InsertPurchaseOrderDetailTVP]
  @MParam PurchaseOrderDetailInsert READONLY
AS 
INSERT  INTO PurchaseOrderDetail ( BonusQuantity, DiscountAmount, NetAmount, Price, ProductIdNo, PurchaseOrderIdNo, Quantity, [Sequence], UnitIdNo, VatAmount, VatPercent)
        SELECT  BonusQuantity, DiscountAmount, NetAmount, Price, ProductIdNo, PurchaseOrderIdNo, Quantity, [Sequence], UnitIdNo, VatAmount, VatPercent
        FROM    @MParam
SET IDENTITY_INSERT DBO.PurchaseOrderDetail ON;