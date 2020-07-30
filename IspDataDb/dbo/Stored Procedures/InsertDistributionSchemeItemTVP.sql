





CREATE PROC [dbo].[InsertDistributionSchemeItemTVP]
  @MParam DistributionSchemeItemInsert READONLY
AS 
INSERT  INTO DistributionSchemeItem (DistributionSchemeIdNo, [Sequence], RevCostCenteridNo, [Percentage])
        SELECT  DistributionSchemeIdNo, [Sequence], RevCostCenteridNo, [Percentage]
        FROM    @MParam
SET IDENTITY_INSERT DBO.DistributionSchemeItem ON;

