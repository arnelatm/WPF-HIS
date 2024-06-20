








CREATE VIEW [dbo].[InvoiceAllVatSummary_View]
AS
(SELECT 'C' as 'InvSource',TransDateEnglish, CustomerId, RevCostCenter, Cash, BillAmt, Group_key, TransNbr, Sum(VatableAmount) as VatableAmount, Sum(CitizenSale) as CitizenSale, Sum(ZeroRatedSale) as ZeroRatedSale, Sum(AdjItemNetPrice) as InvNetPrice, Sum(AdjVatAmount) as InvVatAmount, Sum(AdjVatExemption) as InvVatExemption, Rejected from dbo.InvoiceClinicItemAdj_View group by TransDateEnglish,CustomerId,Cash,Group_key,TransNbr,BillAmt,RevCostCenter,Rejected)
Union
(SELECT 'I' as 'InvSource',TransDateEnglish, CustomerId, RevCostCenter, Cash, BillAmt, Group_key, TransNbr, Sum(VatableAmount) as VatableAmount, Sum(CitizenSale) as CitizenSale, Sum(ZeroRatedSale) as ZeroRatedSale, Sum(AdjItemNetPrice) as InvNetPrice, Sum(AdjVatAmount) as InvVatAmount, Sum(AdjVatExemption) as InvVatExemption, Rejected from dbo.InvoiceDCItemAdj_View group by TransDateEnglish,CustomerId,Cash,Group_key,TransNbr,BillAmt,RevCostCenter,Rejected)
Union
(SELECT 'P' as 'InvSource',TransDateEnglish, CustomerId, RevCostCenter, Cash, BillAmt, Group_key, TransNbr, Sum(VatableAmount) as VatableAmount, Sum(CitizenSale) as CitizenSale, Sum(ZeroRatedSale) as ZeroRatedSale, Sum(AdjItemNetPrice) as InvNetPrice, Sum(AdjVatAmount) as InvVatAmount, Sum(AdjVatExemption) as InvVatExemption, Rejected from dbo.InvoicePharmacyItemAdj_View group by TransDateEnglish,CustomerId,Cash,Group_key,TransNbr,BillAmt,RevCostCenter,Rejected)