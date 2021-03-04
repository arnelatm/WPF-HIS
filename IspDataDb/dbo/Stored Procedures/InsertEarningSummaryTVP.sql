









CREATE PROC [dbo].[InsertEarningSummaryTVP]
  @MParam EarningSummaryInsert READONLY
AS 
INSERT  INTO EarningSummary (EarningSummaryIdNo, EarningIdNo, Multiplier, Sequence)
        SELECT  EarningSummaryIdNo, EarningIdNo, Multiplier , Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.EarningSummary ON;