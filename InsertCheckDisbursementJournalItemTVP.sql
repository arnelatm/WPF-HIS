USE [ISPDATA]
GO

/****** Object:  StoredProcedure [dbo].[InsertCkJournalItemTVP]    Script Date: 3/18/2020 11:09:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







Create PROC [dbo].[InsertCkJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO CkJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CkJournalItem ON;

GO


