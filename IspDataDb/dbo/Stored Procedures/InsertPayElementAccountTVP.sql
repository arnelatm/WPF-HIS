








CREATE PROC [dbo].[InsertPayElementAccountTVP]
  @MParam PayElementAccountInsert READONLY
AS 
INSERT  INTO PayElementAccount (AccountIdNo, PayElementIdNo, PayGroupIdNo, Sequence)
        SELECT  AccountIdNo, PayElementIdNo, PayGroupIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PayElementAccount ON;