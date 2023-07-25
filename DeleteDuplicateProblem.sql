WITH cte
	 AS (SELECT userid, usernameenglish , ROW_NUMBER() OVER (PARTITION BY UserId, UserNameEnglish ORDER BY ( SELECT 0)) RN
		 FROM   igroupCLinic.dbo.UsersBank
		 where userid = 'ag')
SELECT * FROM CTE
--DELETE FROM cte
WHERE  RN > 1;


