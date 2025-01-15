 
CREATE FUNCTION [dbo].[PaymentVATInfo](@PayValue decimal(18,2), @OrderID int,@CustomVATPer decimal(18,2))
RETURNS
 @InfoTable TABLE ([VATValue] decimal(30,18),
				   [ZeroVATValue] decimal(30,18),
				   [NotZeroVATValue] decimal(30,18),
				   [ExempVATValue] decimal(30,18),
				   [CustomValue] decimal(30,18),
				   [CustomVATValue] decimal(30,18),
				   [VATValueGenerated] decimal(30,18))
AS
BEGIN
	
	declare @InvoiceNet decimal(18,2);
	declare @Invoice0Total decimal(18,2);
	declare @InvoiceNot0Total decimal(18,2);	
	declare @InvoiceExempTotal decimal(18,2);
	declare @InvoiceVATTotal decimal(18,2);	
	declare @InvoiceCustomTotal decimal(18,2);
	declare @InvoiceCustomVATTotal decimal(18,2);

	declare @Res0 decimal(30,18);
	declare @ResNot0 decimal(30,18);	
	declare @ResVATValueGenerated decimal(30,18);	
	declare @ResExemp decimal(30,18);
	declare @ResVATValue decimal(30,18);
	declare @ResCustom decimal(30,18);	
	declare @ResCustomVATValue decimal(30,18);	

	declare @IsVAT5Generate bit;
	declare @IsVAT5GenerateExemption bit;

	declare @IsReturn bit;
	SELECT  @IsReturn = IsReturn FROM A1_Invoces where ID = @OrderID

	Select @IsVAT5Generate = Count(ID) From A1_OrderWorks Where OrderID = @OrderID And WorkID = 'VAT'
	Select @IsVAT5GenerateExemption = Count(ID) From A1_OrderWorks Where OrderID = @OrderID And WorkID = 'VATExemption'

	SELECT @InvoiceNet = SUM(IsNull(Abs(Net),0)) FROM A1_OrderWorks where (@IsReturn = 1 Or net > 0) and OrderID = @OrderID GROUP BY OrderID
	SELECT @Invoice0Total = SUM(isnull(Abs(Net),0))  FROM A1_OrderWorks where (@IsReturn =1 Or net > 0) and (VATPer is null or VATPer = 0) and OrderID = @OrderID GROUP BY OrderID	
	SELECT @InvoiceNot0Total = SUM(isnull(Abs(TotalNoVAT),0)), @InvoiceVATTotal = SUM(isnull(Abs(VatValue),0)) FROM A1_OrderWorks  Where (@IsReturn = 1 Or net > 0) and VatValue <> 0 and OrderID = @OrderID GROUP BY OrderID					

	if (@CustomVATPer is not null and @CustomVATPer <> 0)
	Begin
		SELECT @InvoiceCustomTotal = SUM(isnull(Abs(TotalNoVAT),0)),@InvoiceCustomVATTotal = SUM(isnull(Abs(VatValue),0)) FROM A1_OrderWorks  Where (@IsReturn = 1 Or net > 0) and VatValue <> 0 and OrderID = @OrderID and Abs(VATPer) = @CustomVATPer GROUP BY OrderID
	End

	SELECT  @InvoiceExempTotal = SUM(isnull(Abs(Net),0))  FROM A1_OrderWorks where (@IsReturn =1 Or net > 0) and VatExemption <> 0 and OrderID = @OrderID GROUP BY OrderID
	
	if @InvoiceNet is null or @InvoiceNet = 0 
	   BEGIN
	    Set @Res0 = 0
		Set @ResNot0 = 0
		Set @ResVATValueGenerated = 0
		Set @ResExemp = 0
		Set @ResVATValue = 0
		Set @ResCustom = 0
		Set @ResCustomVATValue = 0
	   END
	else
	   BEGIN
	   -- NORMAL Invoices
	    IF @IsVAT5Generate = 0 And @IsVAT5GenerateExemption = 0
	     Begin
			set @Res0 = (@PayValue *  IsNull(@Invoice0Total,0)) /  @InvoiceNet
			set @ResNot0 = (@PayValue *  IsNull(@InvoiceNot0Total,0)) / @InvoiceNet		
			Set @ResVATValueGenerated = 0
			set @ResExemp = (@PayValue *  IsNull(@InvoiceExempTotal,0)) / @InvoiceNet
			set @ResVATValue = (@PayValue *  IsNull(@InvoiceVATTotal,0)) / @InvoiceNet
			set @ResCustom = (@PayValue *  IsNull(@InvoiceCustomTotal,0)) / @InvoiceNet
			set @ResCustomVATValue = (@PayValue *  IsNull(@InvoiceCustomVATTotal,0)) / @InvoiceNet
		 End

	   -- GENERATE 5% VAT Invoices		
		IF @IsVAT5Generate > 0
		 Begin
		    set @Res0 = 0
			set @ResNot0 = 0
			set @ResExemp = 0			
			set @ResCustom = 0			
			set @ResVATValue = (@PayValue *  IsNull(@InvoiceVATTotal,0)) / @InvoiceNet
			set @ResVATValueGenerated = @PayValue - @ResVATValue			
			set @ResCustomVATValue = Case When @CustomVATPer = 5 Then @ResVATValue Else 0 End
		 End

	   -- GENERATE 5% VAT Invoices Exemption
		IF @IsVAT5Generate = 0 and @IsVAT5GenerateExemption > 0
		 Begin
			set @Res0 = 0
			set @ResNot0 = 0
			Set @ResVATValueGenerated = 0
			set @ResVATValue = 0						
			set @ResCustom = 0
			set @ResCustomVATValue = 0
			set @ResExemp = @PayValue		
		 End
		 
	   END			

 INSERT INTO @InfoTable
 SELECT @ResVATValue,@Res0,@ResNot0,@ResExemp,@ResCustom,@ResCustomVATValue,@ResVATValueGenerated

 RETURN
END