-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spProductMovement] 
	-- Add the parameters for the stored procedure here
	@ProductIdNo int = 0, 
	@WarehouseIdNo int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	-- SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ProductIdNo]
      ,[WarehouseIdNo]
      ,[WarehouseToIdNo]
      ,a.[IdNo]
      ,[TransactionDate]
	  ,[BaseQty] * IIf(WarehouseIdNo = @WareHouseIdNo,1,-1) as 'BaseQty'
      ,[Quantity] * IIf(WarehouseIdNo = @WareHouseIdNo,1,-1) as 'Quantity'
      ,[UnitIdNo]
	  ,[UnitName]
      ,[UnitCost]
	  ,[Description] + ' ' + IIf(IsNull(WarehouseToIdNo,0)=0,'',b.WarehouseName) as 'Description'
	  ,[ExpiryDate]
	  ,[BatchNo]
  FROM [dbo].[ProductMovement_View] a
  Left Join Warehouse b
  on b.IdNo = WarehouseToIdNo
  where (warehouseidno = @WarehouseIdNo or warehousetoidno = @WarehouseIdNo) and ProductIdNo = @ProductIdNo 
  order by Productidno
END