-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetVATPerPayment](@PayValue dec(18,2), @OrderID int)
RETURNS dec(18,2)
AS
BEGIN

	declare @InvoiceNet decimal(18,2);
	declare @InvoiceTotalVatValue decimal(18,2);
	declare @Res decimal(18,2);
	declare @IsReturn bit;

	SELECT   @IsReturn = IsReturn FROM A1_Invoces where ID = @OrderID

	SELECT   @InvoiceNet = SUM(IsNull(ABS(Net),0)),
			 @InvoiceTotalVatValue = SUM(isnull(ABS(VatValue),0))  
	FROM	 A1_OrderWorks as tt 
	Where	 (@IsReturn = 1 Or tt.net > 0) and 
			 OrderID = @OrderID 
	GROUP BY OrderID
	
	if (@InvoiceTotalVatValue > 0 and @InvoiceNet > 0) 
			set @Res = (@PayValue *  @InvoiceTotalVatValue) / isnull( @InvoiceNet,0) 
	else	set @Res=  0 

	return @Res;
END