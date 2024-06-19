



CREATE VIEW [dbo].[InvoiceDCVatSummary_View]
AS
SELECT	TransDateEnglish, 
		InvoiceType, 
		TransNbr, 
		BillAmt, 
		Sum(AdjItemNetPrice) as InvNetPrice,
		Sum(Iif(AdjVatAmount<>0 and AdjVatExemption=0,AdjItemNetPrice,0)) as 'StdRatedSales',
		Sum(Iif(AdjVatAmount<>0 and AdjVatExemption<>0,AdjItemNetPrice,0)) as 'PvtHcCitizenSales',
		Sum(Iif(AdjVatAmount=0,AdjItemNetPrice,0)) as 'ZeroRatedSales',
		Sum(AdjVatAmount) as InvVatAmount, 
		Sum(AdjVatExemption) as InvVatExemption
FROM    dbo.InvoiceDCItemAdj_View
group by TransDateEnglish,InvoiceType,TransNbr,BillAmt