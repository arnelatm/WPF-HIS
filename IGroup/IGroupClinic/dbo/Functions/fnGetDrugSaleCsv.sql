








-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[fnGetDrugSaleCsv] 
(	
	-- Add the parameters for the function here
	@salesDate Varchar(10)
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT GTin
      ,BatchNo
      ,Expiry
      ,SerializationNo
	  ,IdNo
  FROM [dbo].[DrugSale]
    where SaleDate = Cast(@SalesDate as Date)
  

)