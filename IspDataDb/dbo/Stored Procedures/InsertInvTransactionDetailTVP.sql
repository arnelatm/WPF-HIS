









CREATE PROC [dbo].[InsertInvTransactionDetailTVP]
  @MParam InvTransactionDetailInsert READONLY
AS 
INSERT  INTO InvTransactionDetail ( BatchNo, ExpiryDate, InventoryIdNo, InvTransactionIdNo, NetAmount, ProductIdNo, Quantity, [Sequence], UnitCost, UnitIdNo )
        SELECT  BatchNo, ExpiryDate, InventoryIdNo, InvTransactionIdNo, NetAmount, ProductIdNo, Quantity, [Sequence], UnitCost, UnitIdNo 
        FROM    @MParam
SET IDENTITY_INSERT DBO.InvTransactionDetail ON;