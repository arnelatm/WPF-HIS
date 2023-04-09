-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE spGetProductBySearchString 
	-- Add the parameters for the stored procedure here
	@findString varchar(50) = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @queryString as VarChar(50)
    -- Insert statements for procedure here
	Set @queryString = Concat('%',@findString,'%')
	SELECT ProductCode,ProductName,BarCode,GTIN from Product where ProductName like @queryString or ProductCode like @queryString or GTIN = @queryString or BarCode = @queryString
END