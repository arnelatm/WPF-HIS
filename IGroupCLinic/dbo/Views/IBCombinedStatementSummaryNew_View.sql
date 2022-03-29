


CREATE VIEW [dbo].[IBCombinedStatementSummaryNew_View]
  AS
  (SELECT 
  invSource,
  iif(InvoiceType='Cash','CA','CR') as 'TransType',
  saleType,
  iif(InvoiceType='Cash','CA','CR') as 'BillType',
  a.Group_Key,
  transdateenglish,
  transnbr,
  rownbr,
  a.userid,
  b.UserNameEnglish,
  a.doctorid,
  a.VATPercent,
  c.EmpNameEnglish as 'DoctorNameEnglish',
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
  left outer join usersbank b 
  on a.UserID = b.UserID  
  left outer join EmployeeDetails c
  on a.doctorid = c.empid
  where a.Rejected = 0
  group by invSource,saletype,invoicetype,rownbr,a.Group_Key,transdateenglish,Transnbr,a.userid,b.UserNameEnglish,a.doctorid,c.EmpNameEnglish,a.VATPercent)




