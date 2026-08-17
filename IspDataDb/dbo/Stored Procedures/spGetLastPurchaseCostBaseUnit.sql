




CREATE PROCEDURE [dbo].[spGetLastPurchaseCostBaseUnit] @ProductidNo Decimal(12,4)
AS
DECLARE @Quantity AS Decimal(12,4) = 0;

SELECT TOP 1 
    ISNULL(
        IIf(a.BonusQuantity + a.Quantity = 0, 0, a.NetAmount / (a.BonusQuantity + a.Quantity))
        * IIf(a.UnitIdNo = c.BaseUnitIdNo, 1, Iif(b.BaseQty = 0, 0, Cast(b.UnitQty AS Decimal(12,4)) / b.BaseQty )),
        0
    ) AS Quantity
FROM [dbo].[PurchaseDetail] a
LEFT JOIN ProductUnit b
    ON a.ProductIdNo = b.ProductIdNo AND a.UnitIdNo = b.UnitIdNo
LEFT JOIN Product c
    ON a.ProductIdNo = c.IdNo
WHERE a.ProductIdNo = @ProductIdNo
ORDER BY a.IdNo DESC;
--Declare @Quantity as Decimal(12,4) = 0 
--SELECT top 1 IIf(a.BonusQuantity+a.Quantity = 0, 0 ,a.NetAmount / (a.BonusQuantity + a.Quantity)) * IIf(a.UnitIdNo = c.BaseUnitIdNo,1, Iif(b.BaseQty = 0, 0, Cast(b.UnitQty as Decimal(12,4)) / b.BaseQty ))
--  FROM [dbo].[PurchaseDetail] a 
--  left join ProductUnit b
--  on a.ProductIdNo = b.ProductIdNo and a.UnitIdNo = b.UnitIdNo
--  left join Product c
--  on a.ProductIdNo = c.IdNo 
--  where a.productidno = @ProductIdNo
--  order by a.IdNo desc

GO

