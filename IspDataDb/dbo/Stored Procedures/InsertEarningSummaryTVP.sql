









CREATE PROC [dbo].[InsertEarningSummaryTVP]
  @MParam EarningSummaryInsert READONLY
AS 
INSERT  INTO EarningSummary (EarningGroupIdNo, EarningIdNo, Multiplier, Sequence)
        SELECT  EarningGroupIdNo, EarningIdNo, Multiplier , Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.EarningSummary ON;