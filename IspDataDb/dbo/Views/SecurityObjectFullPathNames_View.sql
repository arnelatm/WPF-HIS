
CREATE View [dbo].[SecurityObjectFullPathNames_View]
as
with parentChildResult as
( select IdNo,
		 SecurityObjectName,
		 ParentIdNo,
	 	 cast('' as nvarchar(max)) as ParentName
	from SecurityObject
	where ParentIdNo is null
  union all
	select i2.IdNo,
	i2.SecurityObjectName,
	i2.ParentIdNo,
	parentChildResult.ParentName + ' > ' + parentChildResult.SecurityObjectName
	from SecurityObject as i2
	inner join parentChildResult
	on parentChildResult.IdNo = i2.ParentIdNo
)     
select IdNo,securityObjectName,ParentName,
	IIf(ParentName = '',SecurityObjectName,stuff(ParentName, 1, 3, '') + ' > ' + SecurityObjectName) as FullPathName
	from parentChildResult