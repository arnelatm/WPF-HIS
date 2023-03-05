SELECT
  sys.columns.name AS ColumnName,
  tables.name AS TableName
FROM
  sys.columns
JOIN sys.tables ON
  sys.columns.object_id = tables.object_id
WHERE
  sys.columns.name = 'ColumnName'


  SELECT tables.name AS TableName
FROM sys.Tables 
WHERE sys.Tables.name like '%TextToSearch'