DECLARE @MaxID INT = (SELECT MAX(Item_Code) FROM dbo.ItemDetails)
SELECT t.Item_Code  MissingSeqID FROM dbo.Tally t
LEFT JOIN dbo.ItemDetails td
ON td.Item_Code = t.Item_Code
WHERE td.Item_Code IS NULL
AND t.Item_Code < @MaxID order by t.Item_CodeDECLARE @MaxID INT = (SELECT MAX(Item_Code) FROM dbo.ItemDetails)
SELECT t.Item_Code  MissingSeqID FROM dbo.Tally t
LEFT JOIN dbo.ItemDetails td
ON td.Item_Code = t.Item_Code
WHERE td.Item_Code IS NULL
AND t.Item_Code < @MaxID order by t.Item_Code