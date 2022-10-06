CREATE VIEW [dbo].[IBCombinedStatementSummaryPh_ViewORIG]
  AS
   (SELECT 
  invSource,
  iif(InvoiceType='Cash','CA','CR') as 'TransType',
  saleType,
  InvoiceType as 'BillType',
  Trans_key,
  transdateenglish,
  transnbr,
  a.userid,
  b.UserNameEnglish,
  sum(qty*salePrice)*iif(a.SaleType='Sales Return',-1,1) as 'ItemGrossTotal',
  sum(ItemDiscountAmt)*iif(a.SaleType='Sales Return',-1,1) as 'ItemNormalDiscountTotal',
  sum(InvNormalDiscount)*iif(a.SaleType='Sales Return',-1,1) as 'InvNormalDiscountTotal',
  sum(VATAmt)*iif(a.SaleType='Sales Return',-1,1) as 'ItemVATAmtTotal',
  sum(qty*salePrice-ItemDiscountAmt-InvExtraDiscount+InvRoundoffAmt+InvVATAmt-InvVatExemption)*iif(a.SaleType='Sales Return',-1,1) as 'ItemBillAmt',
  sum(InvVATAmt)*iif(a.SaleType='Sales Return',-1,1) as 'InvVATAmtTotal',
  sum(InvVATExemption)*iif(a.SaleType='Sales Return',-1,1) as 'InvVATExemption',
  sum(InvExtraDiscount)*iif(a.SaleType='Sales Return',-1,1) as 'InvExtraDiscount',
  sum(InvRoundoffAmt)*iif(a.SaleType='Sales Return',-1,1) as 'InvRoundOffAmt',
  sum(BillAmt)*iif(a.SaleType='Sales Return',-1,1) as 'InvBillAmt'
  FROM [iGroupClinic].[dbo].[AllInvoicesDetails_View] a
  left outer join usersbank b on a.UserID = b.UserID  
    where a.invSource = 'Pharmacy'
  group by invSource,saletype,invoicetype,Trans_Key,transdateenglish,Transnbr,a.userid,b.UserNameEnglish)