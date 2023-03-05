










/****** Script for SelectTopNRows command from SSMS  ******/
  CREATE VIEW [dbo].[IncomeStatementLayoutCT_View] as
  (SELECT IdNo,ParentIDNo,AccountCode,AccountName,AccountNameAra,DetailAccount,AccountGroup,ByDebit,BYCredit,Debit,Credit,NormalBalance,CloseDebit,CloseCredit,PayeeType,
		  WithReconciliation,IncomeExpSummary,SpecialAccount,Active,LevelNumber,Path,SortKey,Iif(AccountGroup='R','1',iif(AccountCode like '4%','2','3')) as SortGroup
		  FROM Account_View)
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
	  ,Iif(AccountGroup='R','1',iif(AccountCode like '4%','2','3')) as SortGroup
  FROM [dbo].[Account_View] WHERE NOT DetailAccount=1)