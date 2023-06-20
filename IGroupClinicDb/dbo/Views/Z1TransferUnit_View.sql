







CREATE VIEW [dbo].[Z1TransferUnit_View]
AS
SELECT distinct branchid,item_code,unit  
  FROM [iGroupClinic].[dbo].[TransferStockDetails]
  where unit <> 'Box'