
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE View [dbo].[DuplicateItemRegistration]
as 
SELECT TOP (1000) a.[RegistrationNo]
	  ,d.[Trade name]
	  ,d.[Generic name]
	  ,d.[Strength value]
	  ,d.[Dosage Form]
	  ,d.[Package size]
	  ,d.[Package type]
	  ,d.[Volume]
	  ,d.[Unit of Volume]
  FROM [iGroupClinic].[dbo].[ItemRegistration] a
  left join ItemDetails b
  on a.item_code = b.Item_code and b.BranchId = '01'
  left join druglist d
  on a.registrationno = d.RegistrationNo
  GROUP BY a.RegistrationNo
	  ,d.[Trade name]
	  ,d.[Generic name]
	  ,d.[Strength value]
	  ,d.[Dosage Form]
	  ,d.[Package size]
	  ,d.[Package type]
	  ,d.[Volume]
	  ,d.[Unit of Volume]
HAVING COUNT(a.RegistrationNo)>1
  order by a.RegistrationNo