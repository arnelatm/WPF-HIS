










CREATE PROC [dbo].[InsertPayElementItemTvp]
  @MParam PayElementItemInsert READONLY
AS 
INSERT  INTO PayElementItem (FactorType, FactorValue, ParentIdNo, PayElementIdNo, Sequence)
        SELECT  FactorType, FactorValue, ParentIdNo, PayElementIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PayElementItem ON;
