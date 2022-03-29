
  CREATE View [dbo].[MissingDrugs_View] as
  Select a.[RegistrationNo],
	[Generic name] ,
	[Trade name] ,
	[Strength value] ,
	[Unit of strength] ,
	[Dosage Form] ,
	[Route of Administration] ,
	[ATC Code 1] ,
	[ATC Code 2] ,
	[Volume] [float] ,
	[Unit of volume] ,
	[Package type] ,
	[Package size] ,
	[Legal status] ,
	[Product control] ,
	[Public price (SAR)] ,
	[Shelf-life (mon)] ,
	[Storage conditions] ,
	[Manufacturer name] ,
	[Country of Manufacturer] ,
	[Marketing Company] ,
	[Nationality] ,
	[MAH (Agent name)] ,
	[Authorization status] ,
	[Marketing status] ,
	[Remarks] ,
	[Color] ,
	[Shape] ,
	[DrugIdentification] from druglist_copy a
  left join itemregistration b
  on a.RegistrationNo = b.RegistrationNo 
  where b.Item_Code is Null
