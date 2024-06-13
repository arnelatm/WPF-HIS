

Create View [dbo].[SecurityObjectHierarchy_View]
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
select a.IdNo,SecurityObjectCode,a.SecurityObjectName,SecurityObjectNameAra,a.ParentIdNo,a.SystemViewIdNo,a.ManuallyAdded,a.Notes,
	IIf(ParentName = '',b.SecurityObjectName,stuff(ParentName, 1, 3, '') + ' > ' + b.SecurityObjectName) as FullPathName
	from SecurityObject a
	inner Join parentChildResult b
	on a.IdNo = b.IdNo