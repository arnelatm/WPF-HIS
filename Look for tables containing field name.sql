select * from INFORMATION_SCHEMA.COLUMNS 
where COLUMN_NAME like '%ColumnNameToSearch%' 
order by TABLE_NAME