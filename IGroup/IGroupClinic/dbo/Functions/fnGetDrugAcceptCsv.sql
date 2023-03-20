









-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[fnGetDrugAcceptCsv] 
(	
	-- Add the parameters for the function here
	@AcceptDate Varchar(10)
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
  FROM [dbo].[DrugAccept]
    where AcceptDate = Cast(@AcceptDate as Date)
  

)