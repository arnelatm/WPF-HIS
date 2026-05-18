USE [BioTime]
GO

UPDATE [dbo].[personnel_employee]
   SET [emp_code] = '529'
 WHERE id = 40
GO

UPDATE [dbo].[iclock_transaction]
   SET [emp_code] = '529'
 WHERE emp_id = 40
GO


UPDATE [dbo].[ep_eptransaction]
   SET [emp_code] = '529'
 WHERE emp_id = 40
GO
