
CREATE VIEW table_names
 
AS
SELECT 		upper(left(table_name,75)) as tname, 
		table_type as tabtype  
FROM 		information_schema.tables  where table_schema = 'dbo' 
           	and not (table_name like 'DTP%' or table_name like 'SYS%' ) 
