
CREATE FUNCTION [dbo].[GetVATPerExpense]
(
@SourceType nvarchar(255), @SourceID nvarchar(255), 
@VATEnb bit,@VATValue dec(18,2) , @Value dec(18,2),
@PurchaseInvocesID nvarchar(255)
)
RETURNS dec(18,2)
AS
BEGIN

	declare @InvoiceNet decimal(18,2);
	declare @InvoiceTotalVatValue decimal(18,2);
	declare @Res decimal(18,2);
	declare @IsReturn bit;

	set @Res = 0

	if(@SourceType = 'PurchaseInvoces')
		Begin
 			Select @InvoiceNet = sum(d1.InvoiceNet),@InvoiceTotalVatValue = sum(d1.InvoiceTotalVatValue)
			from A1_PurchaseInvoces as d 
			LEFT OUTER JOIN 
			(SELECT  OrderID,SUM(Net) AS InvoiceNet, SUM(isnull(VatValue,0)) AS InvoiceTotalVatValue FROM  A1_PurchaseInvocesWorks as tt
			where tt.net > 0 or (Select Count(Id) From A1_PurchaseInvocesWorks Where OrderID = tt.OrderID and Net > 0) = 0 GROUP BY OrderID  ) AS d1 ON d1.OrderID = d.ID
			where @SourceID = d.SupplierID and (@PurchaseInvocesID = d.InvoiceID or @PurchaseInvocesID like '%,'+d.InvoiceID+',%' or @PurchaseInvocesID like '%,'+d.InvoiceID  or @PurchaseInvocesID like  d.InvoiceID+',%')			
		End
	else
		if(@SourceType = 'LabOrders')
			Begin
				Select @InvoiceNet = sum(d1.InvoiceNet),@InvoiceTotalVatValue = sum(d1.InvoiceTotalVatValue)
				from DL_LabOrder as d 
				LEFT OUTER JOIN 
				(SELECT  OrderID,SUM(Net) AS InvoiceNet, SUM(isnull(VatValue,0)) AS InvoiceTotalVatValue FROM  DL_LabOrderWorks as tt
				where tt.net > 0  or (Select Count(Id) From DL_LabOrderWorks Where OrderID = tt.OrderID and Net > 0) = 0 GROUP BY OrderID  ) AS d1 ON d1.OrderID = d.ID
				where @SourceID = d.LabName and (@PurchaseInvocesID = CONVERT(nvarchar, d.LabOrderNum) or @PurchaseInvocesID like '%,'+ CONVERT(nvarchar, d.LabOrderNum) +',%' or @PurchaseInvocesID like '%,'+ CONVERT(nvarchar, d.LabOrderNum)  or @PurchaseInvocesID like  CONVERT(nvarchar, d.LabOrderNum)+',%')
			End			
		else
			begin	if(@VATEnb = 1) set @Res = @VATValue else set @Res = 0 	end
	
	if (@Res = 0 and @InvoiceNet > 0)
		begin		
		  set @Res = (@Value *  @InvoiceTotalVatValue) / isnull( @InvoiceNet,0) 		
		end

	return @Res;
END