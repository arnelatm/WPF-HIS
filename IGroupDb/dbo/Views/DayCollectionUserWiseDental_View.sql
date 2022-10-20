CREATE VIEW DayCollectionUserWiseDental_View
 
AS
select 
	a.TransNbr,
	a.TransDateEnglish,
	a.UserID,
	a.RoundOffAmt,
	b.UserNameEnglish,
	case when (a.CreditCardNo is null or a.CreditCardNo = '') and upper(a.RegistrationType) in ('CASH','OUT PATIENT','HOME VISIT','CAMP') then sum(a.BillAmt) else 0 end as CashAmt,
	case when (a.CreditCardNo is null or a.CreditCardNo = '') and NOT upper(a.RegistrationType) in ('CASH','OUT PATIENT','HOME VISIT','CAMP') then sum(a.BillAmt) else 0 end as CreditCashAmt,
	case when (a.CreditCardNo<>'' AND a.CreditCardNo <> '') and upper(a.TransType) ='CA' then sum(a.BillAmt) else 0 end as VisaSpanAmt,
	case when sum(c.Amount) is null then 0 else sum(c.amount) end as Expenses
From DentalDoctors d
left outer join clinicinvoiceGroup a on d.DoctorID = a.DoctorID 
left outer join UsersBank b on a.UserID = b.UserID
left outer join AccStaffExpenseAccount c on a.UserID = c.StaffID AND a.TransDateEnglish = c.Vdate
where a.TransType ='CA' and (a.Reject = 0 or a.Reject is null) and not a.DoctorID is null 
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