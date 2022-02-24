  DECLARE @myVar int
SET @myVar = 3640

UPDATE
  ItemDetailsNew 
SET
  @myvar = ITEM_CODE = (@myVar + 1)