











CREATE PROC [dbo].[InsertPurchaseOrderDetailTVP]
  @MParam PurchaseOrderDetailInsert READONLY
AS 
INSERT  INTO PurchaseOrderDetail (PurchaseOrderIdNo, NetAmount, ProductIdNo, Quantity, [Sequence], UnitCost, UnitIdNo )
        SELECT  PurchaseOrderIdNo, NetAmount, ProductIdNo, Quantity, [Sequence], UnitCost, UnitIdNo 
        FROM    @MParam
SET IDENTITY_INSERT DBO.PurchaseOrderDetail ON;