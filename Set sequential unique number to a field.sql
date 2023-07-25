DECLARE @myVar int
SET @myVar = 0

UPDATE
  usersbank
SET
  @myvar = primary_key = @myVar + 1



  with T as (select ROW_NUMBER() over (order by ColumnToOrderBy) as RN
        , ColumnToHoldConsecutiveNumber from TableToUpdate
    where ...)
update T
set ColumnToHoldConsecutiveNumber = RN