


CREATE PROCEDURE [dbo].[spProductMovementSummaryVer1]
    @WarehouseIdNo int = 0,
    @DateFrom date,
    @DateTo date
AS
BEGIN
    SET NOCOUNT ON;

    WITH Movement AS
    (
        SELECT
            a.ProductIdNo,
            a.WarehouseIdNo,
            a.WarehouseToIdNo,
            a.TransactionDate,
            a.Description,
            a.UnitName,

            CASE
				WHEN a.WarehouseIdNo = @WarehouseIdNo THEN a.BaseQty
				WHEN a.WarehouseToIdNo = @WarehouseIdNo THEN ABS(a.BaseQty)
				ELSE 0
			END AS SignedBaseQty

        FROM dbo.ProductMovement_View a
        WHERE 
            (a.WarehouseIdNo = @WarehouseIdNo OR a.WarehouseToIdNo = @WarehouseIdNo)
    )
    SELECT
		b.BranchName,
		w.WarehouseName,
		c.CategoryName,
        p.IdNo AS ProductIdNo,
		p.ProductCode,
        p.ProductName,

        MAX(m.UnitName) AS UnitName,

        CAST(SUM(CASE 
            WHEN m.TransactionDate < @DateFrom
              OR m.Description = 'Beginning Inventory'
            THEN m.SignedBaseQty 
            ELSE 0 
        END) AS decimal(12,4)) AS BeginningQuantity,

        CAST(SUM(CASE 
            WHEN m.TransactionDate >= @DateFrom
             AND m.TransactionDate < DATEADD(DAY, 1, @DateTo)
             AND LTRIM(RTRIM(m.Description)) LIKE 'Purchase%'
            THEN m.SignedBaseQty 
            ELSE 0 
        END) AS decimal(12,4)) AS PurchaseQuantity,

        CAST(SUM(CASE 
            WHEN m.TransactionDate >= @DateFrom
             AND m.TransactionDate < DATEADD(DAY, 1, @DateTo)
             AND m.SignedBaseQty < 0
            THEN ABS(m.SignedBaseQty)
            ELSE 0 
        END) AS decimal(12,4)) AS UsedQuantity,

        CAST(SUM(CASE 
            WHEN m.TransactionDate < DATEADD(DAY, 1, @DateTo)
            THEN m.SignedBaseQty 
            ELSE 0 
        END) AS decimal(12,4)) AS EndingQuantity

    FROM dbo.Product p
    LEFT JOIN Movement m
        ON m.ProductIdNo = p.IdNo
	LEFT JOIN Category c
	    on p.CategoryIdNo = c.IdNo
	LEFT JOIN Warehouse w
	    on w.IdNo = @WarehouseIdNo
	LEFT JOIN Branch b
	    on w.BranchIdNo = b.IdNo

    GROUP BY
        p.IdNo,
        p.ProductCode,
        p.ProductName,
		c.CategoryName,
		b.BranchName,
		w.WarehouseName
    HAVING
		SUM(CASE 
			WHEN m.TransactionDate < DATEADD(DAY, 1, @DateTo)
			THEN m.SignedBaseQty
			ELSE 0
		END) > 0
		ORDER BY
			b.BranchName,w.WarehouseName,c.CategoryName,p.ProductName;
END

GO

