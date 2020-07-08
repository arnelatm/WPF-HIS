



/****** Script for SelectTopNRows command from SSMS  ******/
  CREATE VIEW [dbo].[BalanceSheetLayout_View] as
  (SELECT IdNo,ParentIDNo,AccountCode,AccountName,AccountNameAra,DetailAccount,AccountGroup,ByDebit,BYCredit,Debit,Credit,NormalBalance,CloseDebit,CloseCredit,PayeeType,
		  WithReconciliation,IncomeExpSummary,SpecialAccount,Active,LevelNumber,Path,SortKey,
		  CASE WHEN AccountGroup='A' THEN 1 WHEN AccountGroup='L' THEN 2 WHEN AccountGroup='E' THEN 3 END AS 'AccountGroupSort'
		  FROM Chart_View)
  UNION
  (SELECT [IdNo]
      ,[ParentIdNo]
      ,'XXX' AS 'AccountCode'
      ,'Total '+ [AccountName] AS 'AccountName'
      ,'مجموع' + [AccountNameAra] AS 'AccountNameAra'
      ,'1' AS 'DetailAccount'
      ,[AccountGroup]
	  ,0
	  ,0
	  ,0
	  ,0
	  ,NormalBalance
	  ,0
	  ,0
	  ,PayeeType
	  ,WithReconciliation
	  ,IncomeExpSummary
	  ,SpecialAccount
	  ,Active
      ,[LevelNumber]+1 AS 'LevelNumber'
      ,[path]+'-A'
	  ,REPLACE(RTRIM(REPLACE(SortKey, '0', ' ')), ' ', '0')+'999'
	  ,CASE WHEN AccountGroup='A' THEN 1 WHEN AccountGroup='L' THEN 2 WHEN AccountGroup='E' THEN 3 END 
  FROM [ISPDATA].[dbo].[Chart_View] WHERE NOT DetailAccount=1)