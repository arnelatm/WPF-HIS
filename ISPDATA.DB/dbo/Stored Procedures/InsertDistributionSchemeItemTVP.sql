




create PROC [dbo].[InsertDistributionSchemeItemTVP]
  @MParam DistributionSchemeItemInsert READONLY
AS 
INSERT  INTO DistributionSchemeItem (DistributionSchemeIdNo, [Sequence], ProfitCenteridNo, [Percentage])
        SELECT  DistributionSchemeIdNo, [Sequence], ProfitCenteridNo, [Percentage]
        FROM    @MParam
SET IDENTITY_INSERT DBO.DistributionSchemeItem ON;

