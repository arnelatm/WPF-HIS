CREATE VIEW DayCollectionUserWiseSummary_View
 
AS
select 
	a.TransNbr,
	a.TransDateEnglish,
	a.UserID,
	a.RoundOffAmt,
	b.UserNameEnglish,
	case when (a.CreditCardNo is null or a.CreditCardNo = '') and upper(a.RegistrationType) in ('CASH','OUT PATIENT','HOME VISIT','CAMP') then sum(a.BillAmt) else 0 end as CashAmt,
	case when (a.CreditCardNo<>'') and upper(a.RegistrationType) in ('CASH','OUT PATIENT','HOME VISIT','CAMP') then sum(a.BillAmt) else 0 end as CashCCCAmt,
	case when (a.CreditCardNo is null or a.CreditCardNo = '') and NOT upper(a.RegistrationType) in ('CASH','OUT PATIENT','HOME VISIT','CAMP') then sum(a.BillAmt) else 0 end as CreditCashAmt,
	case when (a.CreditCardNo<>'') and NOT upper(a.RegistrationType) in ('CASH','OUT PATIENT','HOME VISIT','CAMP') then sum(a.BillAmt) else 0 end as CreditCCCAmt,
	case when sum(c.Amount) is null then 0 else sum(c.amount) end as Expenses
From clinicinvoiceGroup a
left outer join UsersBank b on a.UserID = b.UserID
left outer join AccStaffExpenseAccount c on a.UserID = c.StaffID AND a.TransDateEnglish = c.Vdate
where a.TransType ='CA' and (a.Reject = 0 or a.Reject is null) 
and TransDateEnglish = '2016/03/28'
Group By 
	a.UserID,
	a.TransNbr,
	a.RoundOffAmt,
	A.TransDateEnglish,
	a.TransType,
	b.UserNameEnglish,
	a.BillAmt,
	a.CreditCardNo,
	a.RegistrationType