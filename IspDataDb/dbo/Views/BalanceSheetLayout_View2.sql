

/****** Script for SelectTopNRows command from SSMS  ******/
  CREATE VIEW [dbo].[BalanceSheetLayout_View2] as
  (SELECT IdNo,ParentIDNo,AccountCode,AccountName,AccountNameAra,DetailAccount,AccountGroup,LevelNumber,Path,SortKey FROM Chart_View)
  UNION
  (SELECT [IdNo]
      ,[ParentIdNo]
      ,'XXX' AS 'AccountCode'
      ,'Total '+ [AccountName] AS 'AccountName'
      ,'مجموع' + [AccountNameAra] AS 'AccountNameAra'
      ,'3' AS 'DetailAccount'
      ,[AccountGroup]
      ,[LevelNumber]+1 AS 'LevelNumber'
      ,[path]+'-A'
	  ,REPLACE(LTRIM(REPLACE(SortKey, '0', ' ')), ' ', '0')+'999'
  FROM [ISPDATA].[dbo].[Chart_View] WHERE NOT DetailAccount=1)