Create View SecurityObjectChildValues_View
as
WITH temp (IdNo, ParentIdNo, ChildrenChain)
AS
(
    SELECT IdNo, ParentIdNo, CAST('' AS VARCHAR(100))
    FROM SecurityObject
    WHERE NOT EXISTS (SELECT * FROM SecurityObject cc WHERE cc.ParentIdNo = SecurityObject.IdNo)

    UNION ALL

    SELECT SecurityObject.IdNo, SecurityObject.ParentIdNo, CAST((temp.ChildrenChain + ',' + CAST(temp.IdNo AS VARCHAR(100))) AS VARCHAR(100)) 
    FROM SecurityObject
    INNER JOIN temp ON SecurityObject.IdNo = temp.ParentIdNo
)

SELECT DISTINCT IdNo,
    REPLACE(
        STUFF(
           (SELECT
                ',' + t2.ChildrenChain
                FROM temp t2
                WHERE temp.IdNo=t2.IdNo
                ORDER BY t2.ChildrenChain
                FOR XML PATH(''), TYPE
           ).value('.','varchar(max)')
           ,1,2, ''
        ), 
    ',,', ',') AS ChildValues
FROM temp
WHERE LEN(ChildrenChain) > 0