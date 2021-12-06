DECLARE @SQL NVARCHAR(max);
Declare @Max Int;
DECLARE @Tablename VARCHAR(50);
SET @Tablename='YourTableNameHere';
SET @Sql=N'Select Max(IdNo) from ' + @TableName ;
exec sp_executeSQl @Sql, N'@Max Int out', @Max output;
SET @Sql=N'DBCC CHECKIDENT(' + @TableName + N', RESEED,' + Str(@Max) + ')';
exec(@Sql);
