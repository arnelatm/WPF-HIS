 
CREATE FUNCTION [dbo].[ExpenseVATInfo](
@SourceType nvarchar(255), @SourceID nvarchar(255), 
@VATEnb bit,@VATPer decimal(18,2),@VATValue dec(18,2),
@Value decimal(18,2),@PurchaseInvocesID nvarchar(255),
@CustomVATPer decimal(18,2))
RETURNS
 @InfoTable TABLE ([VATValue] decimal(30,18),
				   [ZeroVATValue] decimal(30,18),
				   [NotZeroVATValue] decimal(30,18),
				   [CustomValue] decimal(30,18),
				   [CustomVATValue] decimal(30,18))
AS
BEGIN

declare @Res0 decimal(30,18);
declare @ResNot0 decimal(30,18);
declare @ResVATValue decimal(30,18);
declare @ResCustom decimal(30,18);	
declare @ResCustomVATValue decimal(30,18);	

Set @Res0 = 0;
Set @ResNot0 = 0;
Set @ResVATValue = 0;
Set @ResCustom = 0;
Set @ResCustomVATValue = 0;

 if @VATEnb = 1	
	 Begin	 
		if @VATValue = 0 or @VATValue is null			
			Set @Res0 = @Value
		else
			Begin
				Set @ResNot0 = @Value - @VATValue
				set @ResVATValue = @VATValue
				if (@CustomVATPer is not null and @CustomVATPer = @VATPer)
				Begin
					Set @ResCustom = @ResNot0
					set @ResCustomVATValue = @ResVATValue
				End
			End
	 End
 Else
	 Begin
		declare @InvoiceNet decimal(18,2);
		declare @Invoice0Total decimal(18,2);
		declare @InvoiceNot0Total decimal(18,2);		
		declare @InvoiceVATTotal decimal(18,2);
		declare @InvoiceCustomTotal decimal(18,2);
		declare @InvoiceCustomVATTotal decimal(18,2);

		if(@SourceType = 'PurchaseInvoces')
			Begin
 				Select @InvoiceNet = sum(d1.InvoiceNet)
				From A1_PurchaseInvoces as d 
				LEFT OUTER JOIN 
				(SELECT  OrderID,SUM(Net) AS InvoiceNet FROM  A1_PurchaseInvocesWorks as tt
				where (tt.net > 0 or (Select Count(Id) From A1_PurchaseInvocesWorks Where OrderID = tt.OrderID and Net > 0) = 0) GROUP BY OrderID  ) AS d1 ON d1.OrderID = d.ID
				where @SourceID = d.SupplierID and (@PurchaseInvocesID = d.InvoiceID or  d.InvoiceID in (select * from dbo.splitstring(@PurchaseInvocesID)))			

 				Select @Invoice0Total = sum(d1.InvoiceNet)
				from A1_PurchaseInvoces as d 
				LEFT OUTER JOIN 
				(SELECT  OrderID,SUM(Net) AS InvoiceNet FROM  A1_PurchaseInvocesWorks as tt
				where (tt.net > 0 or (Select Count(Id) From A1_PurchaseInvocesWorks Where OrderID = tt.OrderID and Net > 0) = 0) and (tt.VATPer is null or tt.VATPer = 0) GROUP BY OrderID  ) AS d1 ON d1.OrderID = d.ID
				where @SourceID = d.SupplierID and (@PurchaseInvocesID = d.InvoiceID or  d.InvoiceID in (select * from dbo.splitstring(@PurchaseInvocesID)))			

 				Select @InvoiceNot0Total = sum(d1.InvoiceTotalNoVAT),
					   @InvoiceVATTotal = SUM(isnull(d1.InvoiceTotalVatValue,0))
				from A1_PurchaseInvoces as d 
				LEFT OUTER JOIN 
				(SELECT  OrderID,SUM(TotalNoVAT) AS InvoiceTotalNoVAT,SUM(VatValue) AS InvoiceTotalVatValue FROM  A1_PurchaseInvocesWorks as tt
				where (tt.net > 0  or (Select Count(Id) From A1_PurchaseInvocesWorks Where OrderID = tt.OrderID and Net > 0) = 0) and (tt.VATPer > 0)  GROUP BY OrderID  ) AS d1 ON d1.OrderID = d.ID
				where @SourceID = d.SupplierID and (@PurchaseInvocesID = d.InvoiceID or  d.InvoiceID in (select * from dbo.splitstring(@PurchaseInvocesID)))							

				if (@CustomVATPer is not null and @CustomVATPer <> 0)
				Begin
 					Select @InvoiceCustomTotal = sum(d1.InvoiceTotalNoVAT),
						   @InvoiceCustomVATTotal = SUM(isnull(d1.InvoiceTotalVatValue,0))
					from A1_PurchaseInvoces as d 
					LEFT OUTER JOIN 
					(SELECT  OrderID,SUM(TotalNoVAT) AS InvoiceTotalNoVAT,SUM(VatValue) AS InvoiceTotalVatValue FROM  A1_PurchaseInvocesWorks as tt
					where (tt.net > 0 or (Select Count(Id) From A1_PurchaseInvocesWorks Where OrderID = tt.OrderID and Net > 0) = 0) and (tt.VATPer > 0) and tt.VATPer = @CustomVATPer GROUP BY OrderID  ) AS d1 ON d1.OrderID = d.ID
					where @SourceID = d.SupplierID and (@PurchaseInvocesID = d.InvoiceID or  d.InvoiceID in (select * from dbo.splitstring(@PurchaseInvocesID)))
				End

			End

		if(@SourceType = 'LabOrders')
			Begin
				Select @InvoiceNet = sum(d1.InvoiceNet)
				from DL_LabOrder as d 
				LEFT OUTER JOIN 
				(SELECT  OrderID,SUM(Net) AS InvoiceNet FROM  DL_LabOrderWorks as tt
				where (tt.net > 0 or (Select Count(Id) From DL_LabOrderWorks Where OrderID = tt.OrderID and Net > 0) = 0) GROUP BY OrderID  ) AS d1 ON d1.OrderID = d.ID
				where @SourceID = d.LabName and (@PurchaseInvocesID = CONVERT(nvarchar, d.LabOrderNum) or CONVERT(nvarchar, d.LabOrderNum) in (select * from dbo.splitstring(@PurchaseInvocesID)))

				Select @Invoice0Total = sum(d1.InvoiceNet)
				from DL_LabOrder as d 
				LEFT OUTER JOIN 
				(SELECT  OrderID,SUM(Net) AS InvoiceNet FROM  DL_LabOrderWorks as tt
				where (tt.net > 0  or (Select Count(Id) From DL_LabOrderWorks Where OrderID = tt.OrderID and Net > 0) = 0) and (tt.VATPer is null or tt.VATPer = 0) GROUP BY OrderID  ) AS d1 ON d1.OrderID = d.ID
				where @SourceID = d.LabName and (@PurchaseInvocesID = CONVERT(nvarchar, d.LabOrderNum) or CONVERT(nvarchar, d.LabOrderNum) in (select * from dbo.splitstring(@PurchaseInvocesID)))

				Select @InvoiceNot0Total = sum(d1.InvoiceTotalNoVAT),
					   @InvoiceVATTotal = SUM(isnull(d1.InvoiceTotalVatValue,0))
				from DL_LabOrder as d 
				LEFT OUTER JOIN 
				(SELECT  OrderID,SUM(TotalNoVAT) AS InvoiceTotalNoVAT,SUM(VatValue) AS InvoiceTotalVatValue FROM  DL_LabOrderWorks as tt
				where (tt.net > 0 or (Select Count(Id) From DL_LabOrderWorks Where OrderID = tt.OrderID and Net > 0) = 0) and (tt.VATPer > 0)  GROUP BY OrderID  ) AS d1 ON d1.OrderID = d.ID
				where @SourceID = d.LabName and (@PurchaseInvocesID = CONVERT(nvarchar, d.LabOrderNum) or CONVERT(nvarchar, d.LabOrderNum) in (select * from dbo.splitstring(@PurchaseInvocesID)))				

				if (@CustomVATPer is not null and @CustomVATPer <> 0)
				Begin
					Select @InvoiceCustomTotal = sum(d1.InvoiceTotalNoVAT),
						   @InvoiceCustomVATTotal = SUM(isnull(d1.InvoiceTotalVatValue,0))
					from DL_LabOrder as d 
					LEFT OUTER JOIN 
					(SELECT  OrderID,SUM(TotalNoVAT) AS InvoiceTotalNoVAT,SUM(VatValue) AS InvoiceTotalVatValue FROM  DL_LabOrderWorks as tt
					where (tt.net > 0 or (Select Count(Id) From DL_LabOrderWorks Where OrderID = tt.OrderID and Net > 0) = 0) and (tt.VATPer > 0)  and tt.VATPer = @CustomVATPer GROUP BY OrderID  ) AS d1 ON d1.OrderID = d.ID
					where @SourceID = d.LabName and (@PurchaseInvocesID = CONVERT(nvarchar, d.LabOrderNum) or CONVERT(nvarchar, d.LabOrderNum) in (select * from dbo.splitstring(@PurchaseInvocesID)))
				End

			End
	
		if @InvoiceNet is null or @InvoiceNet = 0 
		   BEGIN
			Set @Res0 = 0
			Set @ResNot0 = 0
			set @ResVATValue = 0
			Set @ResCustom = 0
			Set @ResCustomVATValue = 0
		   END
		else
		   BEGIN
			set @Res0 = (@Value *  IsNull(@Invoice0Total,0)) /  @InvoiceNet
			set @ResNot0 = (@Value *  IsNull(@InvoiceNot0Total,0)) / @InvoiceNet
			set @ResVATValue = (@Value *  IsNull(@InvoiceVATTotal,0)) / @InvoiceNet
			set @ResCustom = (@Value *  IsNull(@InvoiceCustomTotal,0)) / @InvoiceNet
			set @ResCustomVATValue = (@Value *  IsNull(@InvoiceCustomVATTotal,0)) / @InvoiceNet
		   END		   
	 End	

 INSERT INTO @InfoTable
 SELECT @ResVATValue,@Res0,@ResNot0,@ResCustom,@ResCustomVATValue

 RETURN
END