


CREATE VIEW [dbo].[ZProduct]
AS
SELECT 
Primary_Key as 'IdNo',
IIf(branchid='01',2,1) as 'BranchIdNo',
Ean_code as 'BarCode',
1 as 'BaseUnitIdNo',
Item_code as 'ProductCode',
ItemNameENglish as 'ProductName', 
itemNameEnglish as 'ProductNameAra',
CASE WHEN ItemGroup='MD' then 1
    WHEN ItemGroup='NM' THEN 2
    WHEN itemgroup='XX' THEN 3
	WHEN itemgroup='CL' THEN 8
	ELSE 2
END AS 'CategoryIdNo',
gtin as 'GTIN',
1 as 'ACTIVE',
Create_Date as 'DateCreated',
CASE WHEN UserId='arahman' then 1080
WHEN userid='005' then 1068
WHEN UserId='shyju' then 1079
WHEN UserId='mgalal' then 1061
WHEN UserId='admin' then 1082
WHEN UserId='arnel' then 6
WHEN UserId='PHA' then 1081
WHEN UserId='mahmoud' then 1083
WHEN UserId='asif' then 1084
WHEN UserId='noman' then 1085
WHEN UserId='ragab' then 1086
WHEN UserId='emma' then 1044
WHEN UserId='Ram' then 1087
ELSE 1081
END AS 'UserIdNo'
from ItemDetails