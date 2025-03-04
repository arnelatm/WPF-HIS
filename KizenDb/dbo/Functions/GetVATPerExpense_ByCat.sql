
CREATE FUNCTION [dbo].[GetVATPerExpense_ByCat]
(
@SourceType nvarchar(255), @SourceID nvarchar(255), 
@VATEnb bit,@VATValue dec(18,2) , @Value dec(18,2),
@PurchaseInvocesID nvarchar(255) , @VATPer dec(18,2),
@VATBefore dec(18,2),@VATCat dec(18,2)
)
RETURNS dec(18,2)
AS
BEGIN

if @VATEnb is null set @VATEnb = 0;
if @VATValue is null set @VATValue = 0;
if @Value is null set @Value = 0;
if @VATPer is null set @VATPer = 0;
if @VATBefore is null set @VATBefore = 0;
if @VATCat is null set @VATCat = 0;

	declare @InvoiceNet decimal(18,2);
	declare @InvoiceNetCat decimal(18,2);
	declare @Res decimal(18,2);

	set @Res = 0

	if(@SourceType = 'PurchaseInvoces')
		Begin

			Select @InvoiceNet = d1.InvoiceNet
			from A1_PurchaseInvoces as d 
			LEFT OUTER JOIN 
			(SELECT  OrderID,SUM(Net) AS InvoiceNet, SUM(isnull(VatValue,0)) AS InvoiceTotalVatValue FROM  A1_PurchaseInvocesWorks as tt
			where tt.net > 0 GROUP BY OrderID  ) AS d1 ON d1.OrderID = d.ID
			where @SourceID = d.SupplierID and @PurchaseInvocesID = d.InvoiceID	
					
		if @VATCat = 0
			begin
				Select @InvoiceNetCat = d1.InvoiceNet
				from A1_PurchaseInvoces as d 
				LEFT OUTER JOIN 
				(SELECT  OrderID,SUM(Net) AS InvoiceNet, SUM(isnull(VatValue,0)) AS InvoiceTotalVatValue FROM  A1_PurchaseInvocesWorks as tt
				where tt.net > 0 and (tt.VATPer is null or tt.VATPer = 0) GROUP BY OrderID  ) AS d1 ON d1.OrderID = d.ID
				where @SourceID = d.SupplierID and @PurchaseInvocesID = d.InvoiceID			
			End
		Else	
			begin	
				Select @InvoiceNetCat = d1.InvoiceNet
				from A1_PurchaseInvoces as d 
				LEFT OUTER JOIN 
				(SELECT  OrderID,SUM(Net) AS InvoiceNet, SUM(isnull(VatValue,0)) AS InvoiceTotalVatValue FROM  A1_PurchaseInvocesWorks as tt
				where tt.net > 0 and tt.VATPer = @VATCat GROUP BY OrderID  ) AS d1 ON d1.OrderID = d.ID
				where @SourceID = d.SupplierID and @PurchaseInvocesID = d.InvoiceID			
			End
		End

	else

		if(@SourceType = 'LabOrders')
			Begin
				Select @InvoiceNet = d1.InvoiceNet
				from DL_LabOrder as d 
				LEFT OUTER JOIN 
				(SELECT  OrderID,SUM(Net) AS InvoiceNet, SUM(isnull(VatValue,0)) AS InvoiceTotalVatValue FROM  DL_LabOrderWorks as tt
				where tt.net > 0 GROUP BY OrderID  ) AS d1 ON d1.OrderID = d.ID
				where @SourceID = d.LabName and @PurchaseInvocesID = CONVERT(nvarchar, d.LabOrderNum)

				if @VATCat = 0
					begin
						Select @InvoiceNetCat = d1.InvoiceNet
						from DL_LabOrder as d 
						LEFT OUTER JOIN 
						(SELECT  OrderID,SUM(Net) AS InvoiceNet, SUM(isnull(VatValue,0)) AS InvoiceTotalVatValue FROM  DL_LabOrderWorks as tt
						where tt.net > 0 and (tt.VATPer is null or tt.VATPer = 0) GROUP BY OrderID  ) AS d1 ON d1.OrderID = d.ID
						where @SourceID = d.LabName and @PurchaseInvocesID = CONVERT(nvarchar, d.LabOrderNum)
					End
				Else	
					begin	
						Select @InvoiceNetCat = d1.InvoiceNet
						from DL_LabOrder as d 
						LEFT OUTER JOIN 
						(SELECT  OrderID,SUM(Net) AS InvoiceNet, SUM(isnull(VatValue,0)) AS InvoiceTotalVatValue FROM  DL_LabOrderWorks as tt
						where tt.net > 0  and tt.VATPer = @VATCat GROUP BY OrderID  ) AS d1 ON d1.OrderID = d.ID
						where @SourceID = d.LabName and @PurchaseInvocesID = CONVERT(nvarchar, d.LabOrderNum)
				End				
			End			
		else
			begin	if(@VATEnb = 1 and @VATPer = @VATCat) or ((@VATEnb = 0 or @VATEnb is null) and @VATCat = 0) set @Res = @Value   end
	

	if (@Res = 0 )
		begin
		if (@InvoiceNetCat > 0 and @InvoiceNet > 0) 
				set @Res = (@Value *  @InvoiceNetCat) / isnull( @InvoiceNet,0) 
		else	set @Res=  0 
		end

	return @Res;
END