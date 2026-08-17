
CREATE VIEW [dbo].[Employee_Kizen_View]
AS
SELECT 
       e.IdNo as Id
      ,e.[EmployeeNameAra] as NameAr
      ,e.[EmployeeName] as NameEn
      ,e.[NationalIdNo] as IdentityNumber
      ,CASE
            WHEN e.NationalityCode = 'SA' THEN N'هوية'
            ELSE N'إقامة'
       END as IdenetyType
      ,ep.PhoneNumber as Mobile1
      ,case
	  when e.[NationalityCode]='SA' THEN 'سعودي Saudi Arabian'
	  when e.[NationalityCode]='EG' THEN 'مصري Egyptian'
	  when e.[NationalityCode]='EG' THEN 'هندي Indian'
	  when e.[NationalityCode]='PK' THEN 'باكستاني Pakistani'
	  when e.[NationalityCode]='PK' THEN 'باكستاني Pakistani'
	  when e.[NationalityCode]='PH' THEN 'فليبيني Philippine'
	  when e.[NationalityCode]='TN' THEN 'تونسي Tunisian'
	  when e.[NationalityCode]='YE' THEN 'يمني Yemeni'
	  ELSE 'سعودي Saudi Arabian'
	  END as Nationality
      ,CASE
            WHEN e.[MaritalStatus] = 'M' THEN N'متزوج/ة - Married'
            WHEN e.[MaritalStatus] = 'S' THEN N'أعزب/ة - Single'
            ELSE N''
       END as MateralStatu
      ,e.[Email] as Mail1
	  ,CASE 
			WHEN TRY_CONVERT(date, e.[BirthDate]) BETWEEN '1900-01-01' AND CAST(GETDATE() AS date)
			THEN TRY_CONVERT(date, e.[BirthDate])
			ELSE NULL
		 END as BirthDay
      ,CASE 
            WHEN e.NationalityCode = 'SA' THEN N'مسلم'
            WHEN e.ReligionId = 'CHR' THEN N'مسيحي'
            WHEN e.ReligionId = 'ISL' THEN N'مسلم'
            ELSE N'مسلم'
       END as Religion
      ,CASE 
			WHEN TRY_CONVERT(date, e.[HiredDate]) BETWEEN '1900-01-01' AND CAST(GETDATE() AS date)
			THEN TRY_CONVERT(date, e.[HiredDate])
			ELSE NULL
	   END as StartContract
	   ,CASE
            WHEN e.[Gender] = 'M' THEN 'Male'
            WHEN e.[Gender] = 'F' THEN 'Female'
            ELSE ''
       END as Gender
FROM dbo.Employee e
OUTER APPLY 
(
    SELECT TOP 1 
           p.PhoneNumber
    FROM dbo.EmployeePhone p
    WHERE p.EmployeeIdNo = e.IdNo
      AND p.PhoneTypeIdNo = 1
    ORDER BY p.IdNo ASC
) ep
WHERE e.Active = 1;

GO

