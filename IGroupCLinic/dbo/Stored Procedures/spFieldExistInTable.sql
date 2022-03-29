
CREATE Procedure [dbo].[spFieldExistInTable]
@tableName as nVarChar(50),
@fieldName as nVarChar(50)
as
begin
	Declare @retValue as int
	IF COL_LENGTH(@tableName,@fieldName) IS NOT NULL
		set @retValue = 1
	ELSE
		set @retValue = 0
	return @retValue
end
