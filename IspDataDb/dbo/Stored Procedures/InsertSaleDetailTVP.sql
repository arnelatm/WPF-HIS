




CREATE PROC [dbo].[InsertSaleDetailTVP]
  @MParam SaleDetailInsert READONLY
AS 
INSERT  INTO SaleDetail ( BatchNo, DiscountAmount, ExpiryDate, NetAmount, Price, ProductIdNo, SaleIdNo, Quantity, [Sequence], UnitIdNo, VatAmount, VatPercent)
        SELECT  BatchNo, DiscountAmount, ExpiryDate, NetAmount, Price, ProductIdNo, SaleIdNo, Quantity, [Sequence], UnitIdNo, VatAmount, VatPercent
        FROM    @MParam
SET IDENTITY_INSERT DBO.SaleDetail ON;