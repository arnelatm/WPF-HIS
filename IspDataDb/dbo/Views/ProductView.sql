CREATE VIEW [dbo].[ProductView]
AS
SELECT
    p.IdNo,
    p.ProductName,
    c.CategoryName,
    u.UnitName,
    ROUND(ISNULL(last_purchase.LastPurchaseCost, 0), 2) AS LastPurchaseCost
FROM dbo.Product AS p
LEFT OUTER JOIN dbo.Category AS c
    ON p.BranchIdNo = c.BranchIdNo
    AND p.CategoryIdNo = c.IdNo
LEFT OUTER JOIN dbo.Unit AS u
    ON p.BaseUnitIdNo = u.IdNo
OUTER APPLY
(
    SELECT TOP 1
        IIF(pd.BonusQuantity + pd.Quantity = 0,
            0,
            pd.NetAmount / (pd.BonusQuantity + pd.Quantity))
        * IIF(pd.UnitIdNo = p.BaseUnitIdNo,
            1,
            IIF(pu.BaseQty = 0,
                0,
                CAST(pu.UnitQty AS DECIMAL(12, 4)) / pu.BaseQty)) AS LastPurchaseCost
    FROM dbo.PurchaseDetail AS pd
    LEFT OUTER JOIN dbo.ProductUnit AS pu
        ON pd.ProductIdNo = pu.ProductIdNo
        AND pd.UnitIdNo = pu.UnitIdNo
    WHERE pd.ProductIdNo = p.IdNo
    ORDER BY pd.IdNo DESC
) AS last_purchase
GO
