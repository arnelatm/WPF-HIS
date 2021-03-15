









CREATE PROC [dbo].[InsertEarningSummaryTVP]
  @MParam EarningSummaryInsert READONLY
AS 
INSERT  INTO EarningSummary (EarningSummaryIdNo, EarningIdNo, FactorType, FactorValue, Sequence)
        SELECT  EarningSummaryIdNo, EarningIdNo, FactorType, FactorValue , Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.EarningSummary ON;