CREATE VIEW [dbo].[AllInvoicesChecking_View]
  AS
 select sum(a.qty*a.salePrice) as grossamt,
		sum(iif(Discountamt<>0,discountamt,discountper*qty*saleprice/100)) as ItDiscount,
		sum(a.qty*a.salePrice - iif(Discountamt<>0,discountamt,discountper*qty*saleprice/100)) as ItemNetAmount,
		sum(isnull(a.vatamt,0)) as itVatAmt,
		avg(ExtraDiscountAmt) as invExtraDiscAmt,
		avg(b.RoundOffAmt) as invRoundOffAmt,
		avg(isnull(b.VATAmt,0)) as invVatAmt,
		avg(isnull(b.VATExemption,0)) as invVatExemption,
		avg(b.BillAmt) as invBillAmt,
		b.TransNbr,
		b.TransDateEnglish,
		b.BillType
 from clinicinvoicedetails a
 join clinicinvoicegroup b
 on a.Group_Key = b.Trans_Key
 group by b.BillType,b.transdateenglish,b.Transnbr