
CREATE VIEW [dbo].[AllInvoicesSummary_View]
  AS
  (SELECT invSource,
  [Group_Key],
  transnbr,
  TransDateEnglish,
  rejected,
  sum(qty*salePrice) as 'ItemGrossTotal',
  sum(ItemDiscountAmt) as 'ItemNormalDiscountTotal',
  sum(InvNormalDiscount) as 'InvNormalDiscountTotal',
  sum(VATAmt) as 'ItemVATAmtTotal',
  sum(qty*salePrice-ItemDiscountAmt-InvExtraDiscount+InvRoundoffAmt+InvVATAmt-InvVatExemption) as 'ItemBillAmt',
  sum(InvVATAmt) as 'InvVATAmtTotal',
  sum(InvVATExemption) as 'InvVATExemption',
  sum(InvExtraDiscount) as 'InvExtraDiscount',
  sum(InvRoundoffAmt) as 'InvRoundOffAmt',
  sum(BillAmt) as 'InvBillAmt'
  FROM [iGroupClinic].[dbo].[AllInvoicesDetails_View]
  group by invSource,group_key,transdateenglish,Transnbr,Rejected)