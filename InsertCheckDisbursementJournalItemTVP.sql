USE [ISPDATA]
GO

/****** Object:  StoredProcedure [dbo].[InsertCheckDisbursementJournalItemTVP]    Script Date: 3/18/2020 11:09:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







Create PROC [dbo].[InsertCheckDisbursementJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO CheckDisbursementJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, ProfitCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, ProfitCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CheckDisbursementJournalItem ON;

GO


