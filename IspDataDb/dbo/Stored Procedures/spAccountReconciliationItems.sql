

-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	Create Account Reconciliation Items
-- =============================================
CREATE PROCEDURE [dbo].[spAccountReconciliationItems] 
	-- Add the parameters for the stored procedure here
	@ReconciliationIdNo as Integer = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 /****** Script for SelectTopNRows command from SSMS  ******/
	(SELECT [IdNo],[Sequence],[TransactionDate],[JournalItemIdNo],[JournalCode],[AccountReconciliationIdNo],[Debit],[DocumentNumber],[Credit],[Cleared],[AccountIdNo],[PayDescription],[PayDescriptionAra],[ReferenceNo],[JournalIdNo],[Reconciled],[Posted]
     FROM [ISPDATA].[dbo].[AccountReconciliationItem_View] where [AccountReconciliationIdNo] = @reconciliationIdNo and cleared = 0
	 )
	  Union
	(SELECT 0,0,'',0,'',@ReconciliationIdNo,0,'',0,0,0,'','','',0,0,0     
	 )
END