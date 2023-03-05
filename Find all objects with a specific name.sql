SELECT name AS [Name], 
       SCHEMA_NAME(schema_id) AS schema_name, 
       type_desc, 
       create_date, 
       modify_date
FROM sys.objects
WHERE name like '%NameToFind%'