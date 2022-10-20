CREATE 	PROCEDURE uSpWSL_CLAIM_ILLNESS 
        ( 
          @DateFrom as varchar(10),
          @DateUpto as varchar(10),
          @TPA as varchar(15) 
        )
 
AS 
DECLARE @SQLString varchar(8000) 
SET @SQLString = 'INSERT INTO WASEELDB..WSL_CLAIM_ILLNESS 
select provclaimno,illnesstype from wsl_claim_illness_view
WHERE [INSURANCEID] = "' + @TPA +'" AND [TRANSDATEENGLISH] Between "' + @DateFrom +'" AND "'+ @DateUpto + '" '+
' group by provclaimno,illnesstype'
EXECUTE(@SQLString)
SET QUOTED_IDENTIFIER ON
SET NOCOUNT OFF