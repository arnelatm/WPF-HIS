CREATE VIEW [dbo].[ExpiryStock_View] (
    [BranchID],
    [WarehouseID],
    [item_code],
    [ItemNameEnglish],
    [Batch],
    [Expiry],
    [Qty],
    [QtyInBox],
    [CashPrice],
    [CostPrice],
    [Expired],
    [PACK1],
    [pack2],
    [pack3],
    [TRANSDATE]
)
WITH ENCRYPTION
AS
SELECT NULL AS [NullColumn]
--The script body was encrypted and cannot be reproduced here.;

