



CREATE VIEW [dbo].[Z1ClinicUnit_View]
AS
SELECT distinct branchid,item_code,unit  
  FROM [iGroupClinic].[dbo].[TransferStockDetails]