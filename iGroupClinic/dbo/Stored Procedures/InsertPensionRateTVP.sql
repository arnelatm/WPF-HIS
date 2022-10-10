







CREATE PROC [dbo].[InsertPensionRateTVP]
  @MParam PensionRateInsert READONLY
AS 
INSERT  INTO PensionRate (EmployeeShare, EmployerShare, HighRange, LowRange, MaxAmount, PensionSchemeIdNo, Sequence)
        SELECT  EmployeeShare, EmployerShare, HighRange, LowRange, MaxAmount, PensionSchemeIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PensionRate ON;
