Close All Database
*USE y:\accounts\aptrans.dbf exclusive
Set Deleted On
Set Exclusive On
Set Safety Off
Set Collate To "MACHINE"
Set Date To YMD

Create Table c:\temp\ApJournal.Dbf (IdNo Integer(6),;
	SuppIdNo Integer(10),;
	TransDate Date(8),;
	Reference c(15),;
	TransType c(1),;
	Amount N(10,2),;
	AcctIdNo Int(7),;
	DueDate Date(8),;
	SettDate Date(8),;
	SettDisc numeric(5,2),;
	InvoiceNo c(15),;
	InvoiceDt Date(8),;
	VatNumber c(15),;
	VatAmount N(10,2),;
	Notes c(254),;
	Posted Logical,;
	Cancelled Logical,;
	DtCreated Date(8))


Create Table c:\temp\ApJourItm.Dbf ;
	(IdNo Integer(6),;
	Sequence Int(7),;
	JourIdNo Int(7),;
	AcctIdNo Int(7),;
	Debit numeric(10,2),;
	Credit numeric(10,2),;
	ProfIdNo Int(7),;
	Notes c(254),;
	Posted Logical)


Create Table c:\temp\supplier.Dbf ;
	(  IdNo Int(7),;
	SuppCode   Varchar(15)  ,;
	SuppName   Varchar(50)  ,;
	SuppNmAr Varchar(50)  ,;
	Contact Varchar(50)  ,;
	ContDesi Varchar(15)  ,;
	Street   Varchar(50)  ,;
	District   Varchar(35)  ,;
	TownCity   Varchar(35)  ,;
	ProvState   Varchar(35)  ,;
	CountryCd   Char(2)  ,;
	POBox   Varchar(10)  ,;
	ZipCode   Varchar(10)  ,;
	Phone1   Varchar(15)  ,;
	Phone2   Varchar(15)  ,;
	Mobile   Varchar(15)  ,;
	Fax   Varchar(15)  ,;
	Email   Varchar(254)  ,;
	Website   Varchar(254)  ,;
	VatNumber   Varchar(15)  ,;
	CRNumber   Varchar(20)  ,;
	AcctStat   Char(1)  ,;
	APAcctIdNo   Int(7),;
	ExpAccIdNo   Int(7) Null,;
	CredLimit   numeric(9,2)   ,;
	SetDueDays   Int(7)   ,;
	SetDisc   numeric(5, 2)  ,;
	PaymentDd   Int(7)   ,;
	DateAccOp   Date(8)   ,;
	BankAcName   Varchar(50)  ,;
	BankAccNo   Varchar(20)  ,;
	BankIdNo   Int(7) Null,;
	IBAN   Varchar(35)  ,;
	PaymMethod   Char(2)  ,;
	Notes   Varchar(254)  ,;
	OpBalance   numeric(9,2),;
	Active Logical   ,;
	DtCreated Date(8))

Use

********************************
* create Suppliers             *
********************************

Select 1
Use Y:\acctbackup\supplier.Dbf Index Y:\acctbackup\supplier.Cdx Shared Alias SUPPORIG
Select 2
Use c:\temp\supplier.Dbf
Local ctr
ctr = 0
Select 1
Go Top
Do While Not Eof()
	ctr = ctr + 1
	Select 2
	Append Blank
	Replace IdNo With ctr
	Replace SuppCode With SUPPORIG.SuppCode
	Replace SuppName With SUPPORIG.SuppName
	Replace SuppNmAr With SUPPORIG.SuppName
	Replace Contact With SUPPORIG.Contact
	Replace Street   With SUPPORIG.suppaddr
	Replace TownCity   With "Jeddah"
	Replace ProvState   With "Makkah"
	Replace CountryCd   With "SA"
	Replace Phone1   With SUPPORIG.Tel_no
	Replace Fax   With SUPPORIG.fax_no
	Replace VatNumber   With SUPPORIG.Vatno
	Replace AcctStat   With "O"
	Replace APAcctIdNo With Int(Val(SUPPORIG.defapact))
	If APAcctIdNo = 0 Then
		Replace APAcctIdNo With 210
	Endif
	Replace CredLimit   With SUPPORIG.credlimt
	Replace SetDueDays   With 0
	Replace SetDisc   With 0
	Replace PaymentDd   With 0
	If SUPPORIG.firstran < Date(1994,01,01) Then
		Replace DateAccOp   With SUPPORIG.DateAdded
	Else
		Replace DateAccOp   With SUPPORIG.firstran
	Endif
	Replace PaymMethod   With "BT"
	Replace OpBalance   With SUPPORIG.Init_Bal
	Replace BankIdNo With Null
	Replace ExpAccIdNo  With Null
	If SUPPORIG.inactive = 'Y' Then
		Replace Active   With .T.
	Endif
	If SUPPORIG.DateAdded < Date(1994,01,01) Then
		Replace DtCreated With SUPPORIG.firstran
	Else
		Replace DtCreated With SUPPORIG.DateAdded
	Endif
	Select 1
	Skip
Enddo


Create Table c:\temp\ArJournal.Dbf ;
	(IdNo Integer(6),;
	CustIdNo Integer(10),;
	TransDate Date(8),;
	Reference c(15),;
	TransType c(1),;
	Amount N(10,2),;
	AcctIdNo Int(7),;
	DueDate Date(8),;
	SettDate Date(8),;
	SettDisc numeric(5,2),;
	InvoiceNo c(15),;
	InvoiceDt Date(8),;
	Notes c(254),;
	Posted Logical,;
	Cancelled Logical,;
	DtCreated Datetime(8))

Create Table c:\temp\ArJourItm.Dbf ;
	(IdNo Integer(6),;
	Sequence Int(7),;
	JourIdNo Int(7),;
	AcctIdNo Int(7),;
	Debit numeric(10,2),;
	Credit numeric(10,2),;
	ProfIdNo Int(7),;
	Notes c(254),;
	Posted Logical)

Create Table c:\temp\ErJournal.Dbf ;
	(IdNo Integer(6),;
	EmplIdNo Integer(10),;
	TransDate Date(8),;
	Reference c(15),;
	TransType c(1),;
	Amount N(10,2),;
	AcctIdNo Int(7),;
	Notes c(254),;
	Posted Logical,;
	Cancelled Logical,;
	DtCreated Datetime(8))

Create Table c:\temp\ErJourItm.Dbf ;
	(IdNo Integer(6),;
	Sequence Int(7),;
	JourIdNo Int(7),;
	AcctIdNo Int(7),;
	Debit numeric(10,2),;
	Credit numeric(10,2),;
	ProfIdNo Int(7),;
	Notes c(254),;
	Posted Logical)


********************************
* create Customers *
********************************

Create Table c:\temp\customer.Dbf ;
	(  IdNo Int(7),;
	CustCode   c(15)  ,;
	CustName   c(50)  ,;
	CustNmAr c(50)  ,;
	Contact c(50)  ,;
	ContDesi c(15)  ,;
	Street   c(50)  ,;
	District   c(50)  ,;
	TownCity   c(50)  ,;
	ProvState   c(50)  ,;
	CountryCd   c(2)  ,;
	POBox   c(10)  ,;
	ZipCode   c(10)  ,;
	Phone1   c(50)  ,;
	Phone2   c(50)  ,;
	Mobile   c(50)  ,;
	Fax   c(50)  ,;
	Email   c(50)  ,;
	Website   c(50)  ,;
	VatNumber   c(15)  ,;
	CRNumber   c(20)  ,;
	AcctStat   c(1)  ,;
	ArAcctIdNo   Int(7),;
	RevAccIdNo   Int(7),;
	DisSchIdNo   Int(7),;
	CredLimit   numeric(9,2)   ,;
	SetDueDays   Int(7)   ,;
	SetDisc   numeric(5, 2)  ,;
	PaymentDd   Int(7)   ,;
	DateAccOp   Date(8)   ,;
	BankAcName   c(50)  ,;
	BankAccNo   c(20)  ,;
	BankIdNo   Int(7) Null,;
	IBAN   c(20)  ,;
	PaymMethod   c(2)  ,;
	Notes   c(254)  ,;
	OpBalance   numeric(9,2)   ,;
	Active   Logical   ,;
	DateCreate  Date(8))
Use
Select 1
Use Y:\acctbackup\customer.Dbf Index Y:\acctbackup\customer.Cdx Shared Alias custorig
Select 2
Use c:\temp\customer.Dbf
Local ctr
ctr = 0
Select 1
Go Top
Do While Not Eof()
*!*		IF CustOrig.Custcode='C84' THEN
*!*			SET STEP ON 
*!*		ENDIF
	If custorig.CustCode <> "E" Then
		Select 2
		ctr = ctr + 1
		Append Blank
		Replace IdNo With ctr
		Replace CustCode With custorig.CustCode
		Replace CustName With custorig.CustName
		Replace CustNmAr With custorig.CustName
		Replace Contact With custorig.Contact
		Replace Street   With custorig.custaddr
		Replace TownCity   With "Jeddah"
		Replace ProvState   With "Makkah"
		Replace CountryCd   With "SA"
		Replace Phone1   With custorig.Tel_no
		Replace Fax   With custorig.fax_no
		Replace AcctStat   With "O"
		Replace ArAcctIdNo With Int(Val(custorig.defaract))
		If ArAcctIdNo = 0 Then
			Replace ArAcctIdNo With 112
		Endif
		Replace CredLimit   With custorig.credlimt
		Replace SetDueDays   With 0
		Replace SetDisc   With 0
		Replace PaymentDd   With 0
		If custorig.firstran < Date(1994,01,01) Then
			Replace DateAccOp With custorig.DateAdded
		Else
			Replace DateAccOp With custorig.firstran
		Endif

		Replace BankIdNo With Null
		Replace PaymMethod   With "BT"
		Replace OpBalance   With custorig.Init_Bal
		Replace RevAccIdNo   With 417
		If custorig.inactive = "Y" Then
			Replace Active With .F.
		Else
			Replace Active   With .T.
		Endif
		If custorig.DateAdded < Date(1994,01,01) Then
			Replace DateCreate  With custorig.firstran
		Else
			Replace DateCreate  With custorig.DateAdded
		ENDIF
	Endif
	Select 1
	Skip
Enddo

********************************
* create AP beginning balances *
********************************


Select 1
Create Table c:\temp\ApOpnInv.Dbf ;
	(IdNo Integer(6),;
	JournalCd Char(2),;
	JourIdNo Int(7),;
	JrItIdNo Int(7),;
	PaidAmt  numeric(10,2),;
	DiscTakn numeric(10,2),;
	SuppIdNo Int(7),;
	Date Date(8),;
	Amount numeric(10,2))
Use c:\temp\ApOpnInv Alias ApOpnInv

Select 2
Use c:\temp\supplier.Dbf Exclusive Alias supplier
Index On SuppCode Tag SuppCode
Select 3
Use c:\temp\ApJournal.Dbf  Exclusive Alias ApJournal
Zap
Set Order To
Select 4
Use c:\temp\ApJourItm Exclusive Alias ApJourItm
Zap
*!*	Select supplier
*!*	Go Top
*!*	nCtr = 0
*!*	nAmount = 0
*!*	Do While Not Eof()
*!*		nAmount = supplier.OpBalance
*!*		If nAmount <> 0 Then
*!*			nCtr = nCtr + 1
*!*			Select ApJourItm
*!*			Append Blank
*!*			Replace ApJourItm.IdNo With nCtr
*!*			Replace ApJourItm.Sequence With 1
*!*			Replace ApJourItm.JourIdNo With nCtr
*!*			Replace ApJourItm.AcctIdNo With 210
*!*			If nAmount  >= 0 Then
*!*				Replace ApJourItm.Credit With nAmount
*!*			Else
*!*				Replace ApJourItm.Debit With nAmount * -1
*!*			Endif
*!*			Replace ApJourItm.Notes With "Opening Balance"
*!*			Replace ApJourItm.Posted With .T.

*!*			Select ApJournal
*!*			Append Blank
*!*			Replace ApJournal.IdNo With nCtr
*!*			Replace ApJournal.SuppIdNo With supplier.IdNo
*!*			Replace ApJournal.TransDate With Date(2016,12,31)
*!*			Replace ApJournal.AcctIdNo With 210
*!*			Replace ApJournal.Reference With "Beg.Bal."
*!*			If nAmount >= 0 Then
*!*				Replace ApJournal.TransType With "C"
*!*			Else
*!*				Replace ApJournal.TransType With "D"
*!*			Endif
*!*			Replace ApJournal.Amount With Abs(nAmount)
*!*			Replace ApJournal.AcctIdNo With 210
*!*			Replace ApJournal.DueDate With Date(2016,12,31)
*!*			Replace ApJournal.InvoiceNo With "Beg. Bal."
*!*			Replace ApJournal.InvoiceDt With Date(2016,12,31)
*!*			Replace ApJournal.Notes With "Beg. Bal."
*!*			Replace ApJournal.Posted With .T.
*!*			Replace ApJournal.Cancelled With .F.
*!*			Replace ApJournal.DtCreated With Date(2016,12,31)
*!*			Replace ApJournal.Posted With .T.

*!*			Select supplier
*!*			* Replace supplier.OpBalance With 0
*!*		Endif
*!*		Skip
*!*	Enddo

********************************
* create AR beginning balances *
********************************

Close Databases

Select 1
Create Table c:\temp\ArOpnInv.Dbf ;
	(IdNo Integer(6),;
	JournalCd Char(2),;
	JourIdNo Int(7),;
	JrItIdNo Int(7),;
	PaidAmt  numeric(10,2),;
	DiscTakn numeric(10,2),;
	CustIdNo Int(7),;
	Date Date(8),;
	Amount numeric(10,2))

Use c:\temp\ArOpnInv Alias ArOpnInv

Select 2
Use c:\temp\customer.Dbf Exclusive Alias customer
Index On CustCode Tag CustCode
Select 3
Use c:\temp\ArJournal.Dbf  Exclusive Alias ArJournal
Zap
Set Order To
Select 4
Use c:\temp\ArJourItm Exclusive Alias ArJourItm
Zap
Select 5
Use c:\temp\ErJournal.Dbf  Exclusive Alias ErJournal
Zap
Set Order To
Select 6
Use c:\temp\ErJourItm Exclusive Alias ErJourItm
Zap
*!*	Select customer
*!*	Go Top
*!*	nArCtr = 0
*!*	nErCtr = 0
*!*	nAmount = 0
*!*	Do While Not Eof()
*!*		cCustCode = customer.CustCode
*!*	*!*		IF cCustCode='C77' THEN
*!*	*!*			SET STEP ON 
*!*	*!*		ENDIF
*!*		nAmount = customer.OpBalance
*!*		If nAmount <> 0 Then
*!*			If cCustCode <> "E" Then
*!*	*!*				nErCtr = nErCtr + 1
*!*	*!*				Select ErJourItm
*!*	*!*				Append Blank
*!*	*!*				Replace ErJourItm.IdNo With nErCtr
*!*	*!*				Replace ErJourItm.Sequence With 1
*!*	*!*				Replace ErJourItm.JourIdNo With nErCtr
*!*	*!*				Replace ErJourItm.AcctIdNo With 114
*!*	*!*				If nAmount  >= 0 Then
*!*	*!*					Replace ErJourItm.Debit With nAmount
*!*	*!*				Else
*!*	*!*					Replace ErJourItm.Credit With nAmount * -1
*!*	*!*				Endif
*!*	*!*				Replace ErJourItm.Notes With "Opening Balance"
*!*	*!*				Replace ErJourItm.Posted With .T.
*!*	*!*				Select ErJournal
*!*	*!*				Append Blank
*!*	*!*				Replace ErJournal.IdNo With nErCtr
*!*	*!*				Replace ErJournal.EmplIdNo With Val(Substr(cCustCode,2,5))
*!*	*!*				Replace ErJournal.TransDate With Date(2016,12,31)
*!*	*!*				Replace ErJournal.AcctIdNo With 114
*!*	*!*				Replace ErJournal.Reference With "Beg.Bal."
*!*	*!*				If nAmount >= 0 Then
*!*	*!*					Replace ErJournal.TransType With "D"
*!*	*!*				Else
*!*	*!*					Replace ErJournal.TransType With "C"
*!*	*!*				Endif
*!*	*!*				Replace ErJournal.Amount With Abs(nAmount)
*!*	*!*				Replace ErJournal.Posted With .T.
*!*	*!*				Replace ErJournal.Cancelled With .F.
*!*	*!*				Replace ErJournal.DtCreated With Date(2016,12,31)
*!*	*!*			Else
*!*				nArCtr = nArCtr + 1
*!*				Select ArJourItm
*!*				Append Blank
*!*				Replace ArJourItm.IdNo With nArCtr
*!*				Replace ArJourItm.Sequence With 1
*!*				Replace ArJourItm.JourIdNo With nArCtr
*!*				Replace ArJourItm.AcctIdNo With 112
*!*				If nAmount  >= 0 Then
*!*					Replace ArJourItm.Debit With nAmount
*!*				Else
*!*					Replace ArJourItm.Credit With nAmount * -1
*!*				Endif
*!*				Replace ArJourItm.Notes With "Opening Balance"
*!*				Replace ArJourItm.Posted With .T.
*!*				Select ArJournal
*!*				Append Blank
*!*				Replace ArJournal.IdNo With nArCtr
*!*				Replace ArJournal.CustIdNo With customer.IdNo
*!*				Replace ArJournal.TransDate With Date(2016,12,31)
*!*				Replace ArJournal.AcctIdNo With 112
*!*				Replace ArJournal.Reference With "Beg.Bal."
*!*				If nAmount >= 0 Then
*!*					Replace ArJournal.TransType With "D"
*!*				Else
*!*					Replace ArJournal.TransType With "C"
*!*				Endif
*!*				Replace ArJournal.Amount With Abs(nAmount)
*!*				Replace ArJournal.DueDate With Date(2016,12,31)
*!*				Replace ArJournal.InvoiceNo With "Beg. Bal."
*!*				Replace ArJournal.InvoiceDt With Date(2016,12,31)
*!*				Replace ArJournal.Notes With "Beg. Bal."
*!*				Replace ArJournal.Posted With .T.
*!*				Replace ArJournal.Cancelled With .F.
*!*				Replace ArJournal.DtCreated With Date(2016,12,31)
*!*			Endif
*!*			Select customer
*!*		Endif
*!*		Skip
*!*	ENDDO


********************************
* create ER beginning balances *
********************************

CLOSE DATABASES

Select 2

Select 1
Use Y:\acctbackup\customer.Dbf Index Y:\acctbackup\customer.Cdx
Select 5
Use c:\temp\ErJournal.Dbf  Exclusive Alias ErJournal
Zap
Set Order To
Select 6
Use c:\temp\ErJourItm Exclusive Alias ErJourItm
Zap
*!*	Select customer
*!*	Go Top
*!*	nErCtr = 0
*!*	nAmount = 0
*!*	Do While Not Eof()
*!*		cCustCode = customer.CustCode
*!*	*!*		IF cCustCode='C77' THEN
*!*	*!*			SET STEP ON 
*!*	*!*		ENDIF
*!*		nAmount = customer.INIT_BAL
*!*		If nAmount <> 0 AND cCustCode = "E" Then
*!*				nErCtr = nErCtr + 1
*!*				Select ErJourItm
*!*				Append Blank
*!*				Replace ErJourItm.IdNo With nErCtr
*!*				Replace ErJourItm.Sequence With 1
*!*				Replace ErJourItm.JourIdNo With nErCtr
*!*				Replace ErJourItm.AcctIdNo With 114
*!*				If nAmount  >= 0 Then
*!*					Replace ErJourItm.Debit With nAmount
*!*				Else
*!*					Replace ErJourItm.Credit With nAmount * -1
*!*				Endif
*!*				Replace ErJourItm.Notes With "Opening Balance"
*!*				Replace ErJourItm.Posted With .T.
*!*				Select ErJournal
*!*				Append Blank
*!*				Replace ErJournal.IdNo With nErCtr
*!*				Replace ErJournal.EmplIdNo With Val(Substr(cCustCode,2,5))
*!*				Replace ErJournal.TransDate With Date(2016,12,31)
*!*				Replace ErJournal.AcctIdNo With 114
*!*				Replace ErJournal.Reference With "Beg.Bal."
*!*				If nAmount >= 0 Then
*!*					Replace ErJournal.TransType With "D"
*!*				Else
*!*					Replace ErJournal.TransType With "C"
*!*				Endif
*!*				Replace ErJournal.Amount With Abs(nAmount)
*!*				Replace ErJournal.Posted With .T.
*!*				Replace ErJournal.Cancelled With .F.
*!*				Replace ErJournal.DtCreated With Date(2016,12,31)

*!*		ENDIF
*!*		Select customer
*!*		Skip
*!*	Enddo

**************************
* Create APJournal/Items *
**************************


Close All
Select 1
Use c:\temp\customer.Dbf Exclusive Alias customer
Index On CustCode Tag CustCode
Use c:\temp\supplier.Dbf Exclusive Alias supplier
Index On SuppCode Tag SuppCode
Select 2
Use Y:\acctbackup\APTRANS.Dbf Index Y:\acctbackup\APTRANS.Cdx Exclusive Alias APTRANS
Set Order To APTHTRNO   && TRANNO
Select 3
Use Y:\acctbackup\JOURITEM.Dbf Index Y:\acctbackup\JOURITEM.Cdx Exclusive Alias JOURITEM
Set Order To JRITJCTN   && JOURCODE+TRANNO
Set Filter To JOURCODE="AP"
Go Top
Select 4
Use c:\temp\ApJournal.Dbf  Exclusive Alias ApJournal
Set Order To
Select 5
Use c:\temp\ApJourItm Exclusive Alias ApJourItm
Go Bottom
nCtrItm = ApJourItm.IdNo
Select APTRANS
Go Top
Do While Not Eof()
	cSuppCode = APTRANS.SuppCode
	cTranno = APTRANS.TRANNO
	apCancelled = APTRANS.Cancelled
	Select supplier
	Seek cSuppCode
	If Not Eof()
		nIdNo = supplier.IdNo
	Else
		nIdNo = 0
	Endif
	Select JOURITEM
	Seek "AP"+cTranno
	SEQ = 0
	nVATAMT = 0
	cVATNO = ""
	nAcctIdNo = 0
	apSw = 0
	Do While TRANNO = cTranno And JOURCODE="AP" And Not Eof()
		If apSw = 0
			If SEQ = 0 And JOURITEM.ACCTCODE $ "210:204:205:203:202:227:207:226" Then
				nAcctIdNo = Int(Val(JOURITEM.ACCTCODE))
				apSw = 1
			Else
				If JOURITEM.ACCTCODE $ "210:204:205:203:202:227:207:226" Then
					nAcctIdNo = Int(Val(JOURITEM.ACCTCODE))
					apSw = 1
				Endif
			Endif
		Endif
		SEQ = SEQ + 1
		Select ApJourItm
		nVATAMT = nVATAMT + JOURITEM.VATAMT
		If Not Empty(JOURITEM.VAT_NO) Then
			cVATNO = JOURITEM.VAT_NO
		Endif
		Append Blank
		nCtrItm = nCtrItm + 1
		Replace ApJourItm.IdNo With nCtrItm
		Replace ApJourItm.Sequence With SEQ
		Replace ApJourItm.JourIdNo With Val(JOURITEM.TRANNO)
		Replace ApJourItm.AcctIdNo With Int(Val(JOURITEM.ACCTCODE))
		Replace ApJourItm.Debit With JOURITEM.Debit
		Replace ApJourItm.Credit With JOURITEM.Credit
		If JOURITEM.DEPTCODE = "S" Then
			Replace ApJourItm.ProfIdNo With 1000 + Val(Substr(JOURITEM.DEPTCODE,2))
		Else
			Replace ApJourItm.ProfIdNo With Val(JOURITEM.DEPTCODE)
		Endif
		Replace ApJourItm.Notes With JOURITEM.Descript
		Replace ApJourItm.Posted With Iif(JOURITEM.Posted="P",.T.,.F.)
		Select JOURITEM
		Skip
	Enddo
*!*		If apSw = 0 And Not apCancelled Then
*!*			Set Step On
*!*		Endif
	Select ApJournal
	Append Blank
	Replace ApJournal.IdNo With Val(cTranno)
	Replace ApJournal.SuppIdNo With nIdNo
	Replace ApJournal.TransDate With APTRANS.Date
	Replace ApJournal.AcctIdNo With nAcctIdNo
	Replace ApJournal.Reference With APTRANS.Reference
	Replace ApJournal.TransType With APTRANS.APTTYPE
	Replace ApJournal.Amount With APTRANS.Amount
	Replace ApJournal.DueDate With APTRANS.DATEDUE
	Replace ApJournal.SettDate With APTRANS.Date
	Replace ApJournal.SettDisc With 0
	Replace ApJournal.InvoiceNo With APTRANS.SUPPREFE
	Replace ApJournal.InvoiceDt With APTRANS.INV_DATE
	Replace ApJournal.Notes With APTRANS.Descript
	Replace ApJournal.Posted With Iif(APTRANS.Posted="P",.T.,.F.)
	Replace ApJournal.Cancelled With APTRANS.Cancelled
	Replace ApJournal.DtCreated With APTRANS.DateAdded
	Replace ApJournal.VatNumber With cVATNO
	Replace ApJournal.VatAmount With nVATAMT
	Select APTRANS
	Skip
Enddo


************************************
* create ARJournal/ERJournal Items *
************************************
Close Databases

Select 1
Use c:\temp\customer.Dbf Exclusive Alias customer
Index On CustCode Tag CustCode
Select 2
Use Y:\acctbackup\artrans.Dbf Index Y:\acctbackup\artrans.Cdx Exclusive Alias artrans
Set Order To ARTHTRNO   && TRANNO
Select 3
Use Y:\acctbackup\JOURITEM.Dbf Index Y:\acctbackup\JOURITEM.Cdx Exclusive Alias JOURITEM
Set Order To JRITJCTN   && JOURCODE+TRANNO
Set Filter To JOURCODE="AR"
Go Top

Select 4
Use c:\temp\ArJournal.Dbf  Exclusive Alias ArJournal
Set Order To
Select 5
Use c:\temp\ArJourItm Exclusive Alias ArJourItm
Go Bottom
nArCtrItm = ArJourItm.IdNo

Select 6
Use c:\temp\ErJournal.Dbf  Exclusive Alias ErJournal
Set Order To
Select 7
Use c:\temp\ErJourItm Exclusive Alias ErJourItm
Go Bottom
nErCtrItm = ErJourItm.IdNo

Select artrans
Go Top
aCtr = 0
eCtr = 0

Do While Not Eof()
	cCustCode = artrans.CustCode
	cTranno = artrans.TRANNO
	Select customer
	Seek cCustCode
	If cCustCode = "E" Then
		nIdNo = Int(Val(Substr(cCustCode,2)))
	Else
		If Not Eof()
			nIdNo = customer.IdNo
		Else
			nIdNo = 0
		Endif
	Endif
	Select JOURITEM
	Seek "AR"+cTranno
	SEQ = 0
	nVATAMT = 0
	cVATNO = ""
	nAcctIdNo = 0
	arSw = 0
	Do While TRANNO = cTranno And JOURCODE="AR" And Not Eof()
		If SEQ = 0 Then
			nAcctIdNo = Val(JOURITEM.ACCTCODE)
			If nAcctIdNo = 112 Or nAcctIdNo = 114 Then
				arSw = 1
				Exit
			Endif
		Endif
		Skip
	Enddo
	If arSw = 0
		If artrans.Cancelled Then
			Select artrans
			Skip
			Loop
		Endif
*!*			Set Step On
	Else
		SEQ = SEQ + 1
		If cCustCode="E" Then
			Select ErJourItm
			Append Blank
			nErCtrItm = nErCtrItm + 1
			Replace ErJourItm.IdNo With nErCtrItm
			Replace ErJourItm.Sequence With SEQ
			Replace ErJourItm.JourIdNo With Val(JOURITEM.TRANNO)
			Replace ErJourItm.AcctIdNo With Val(JOURITEM.ACCTCODE)
			Replace ErJourItm.Debit With JOURITEM.Debit
			Replace ErJourItm.Credit With JOURITEM.Credit
			If JOURITEM.DEPTCODE = "S" Then
				Replace ErJourItm.ProfIdNo With 1000 + Val(Substr(JOURITEM.DEPTCODE,2))
			Else
				Replace ErJourItm.ProfIdNo With Val(JOURITEM.DEPTCODE)
			Endif
			Replace ErJourItm.Notes With JOURITEM.Descript
			Replace ErJourItm.Posted With Iif(JOURITEM.Posted="U",.F.,.T.)
		Else
			Select ArJourItm
			Append Blank
			nArCtrItm = nArCtrItm + 1
			Replace ArJourItm.IdNo With nArCtrItm
			Replace ArJourItm.Sequence With SEQ
			Replace ArJourItm.JourIdNo With Val(JOURITEM.TRANNO)
			Replace ArJourItm.AcctIdNo With Val(JOURITEM.ACCTCODE)
			Replace ArJourItm.Debit With JOURITEM.Debit
			Replace ArJourItm.Credit With JOURITEM.Credit
			If JOURITEM.DEPTCODE = "S" Then
				Replace ArJourItm.ProfIdNo With 1000 + Val(Substr(JOURITEM.DEPTCODE,2))
			Else
				Replace ArJourItm.ProfIdNo With Val(JOURITEM.DEPTCODE)
			Endif
			Replace ArJourItm.Notes With JOURITEM.Descript
			Replace ArJourItm.Posted With Iif(JOURITEM.Posted="U",.F.,.T.)
		Endif
	Endif
	Select JOURITEM
	Seek "AR"+cTranno
	nArCtr = 0
	Do While TRANNO = cTranno And JOURCODE="AR" And Not Eof()
		If Val(JOURITEM.ACCTCODE) = 112 Or Val(JOURITEM.ACCTCODE) = 114 Then
			nArCtr = nArCtr + 1
		Else
			SEQ = SEQ + 1
			If cCustCode="E" Then
				Select ErJourItm
				Append Blank
				nErCtrItm = nErCtrItm + 1
				Replace ErJourItm.IdNo With nErCtrItm
				Replace ErJourItm.Sequence With SEQ
				Replace ErJourItm.JourIdNo With Val(JOURITEM.TRANNO)
				Replace ErJourItm.AcctIdNo With Val(JOURITEM.ACCTCODE)
				Replace ErJourItm.Debit With JOURITEM.Debit
				Replace ErJourItm.Credit With JOURITEM.Credit
				If JOURITEM.DEPTCODE = "S" Then
					Replace ErJourItm.ProfIdNo With 1000 + Val(Substr(JOURITEM.DEPTCODE,2))
				Else
					Replace ErJourItm.ProfIdNo With Val(JOURITEM.DEPTCODE)
				Endif
				Replace ErJourItm.Notes With JOURITEM.Descript
				Replace ErJourItm.Posted With Iif(JOURITEM.Posted="P",.T.,.F.)
			Else
				Select ArJourItm
				Append Blank
				nArCtrItm = nArCtrItm + 1
				Replace ArJourItm.IdNo With nArCtrItm
				Replace ArJourItm.Sequence With SEQ
				Replace ArJourItm.JourIdNo With Val(JOURITEM.TRANNO)
				Replace ArJourItm.AcctIdNo With Val(JOURITEM.ACCTCODE)
				Replace ArJourItm.Debit With JOURITEM.Debit
				Replace ArJourItm.Credit With JOURITEM.Credit
				If JOURITEM.DEPTCODE = "S" Then
					Replace ArJourItm.ProfIdNo With 1000 + Val(Substr(JOURITEM.DEPTCODE,2))
				Else
					Replace ArJourItm.ProfIdNo With Val(JOURITEM.DEPTCODE)
				Endif
				Replace ArJourItm.Notes With JOURITEM.Descript
				Replace ArJourItm.Posted With Iif(JOURITEM.Posted="P",.T.,.F.)
			Endif
		Endif
		Select JOURITEM
		Skip
	Enddo
*!*		If nArCtr > 1 Then
*!*	* double ar/er entries in jouritem
*!*			Set Step On
*!*		Endif
	If cCustCode = "E" Then
		Select ErJournal
		Append Blank
		Replace ErJournal.IdNo With Val(cTranno)
		Replace ErJournal.EmplIdNo With nIdNo
		Replace ErJournal.TransDate With artrans.Date
		Replace ErJournal.AcctIdNo With nAcctIdNo
		Replace ErJournal.Reference With artrans.Reference
		Replace ErJournal.TransType With artrans.ARTTYPE
		Replace ErJournal.Amount With artrans.Amount
		Replace ErJournal.Notes With artrans.Descript
		Replace ErJournal.Posted With Iif(artrans.Posted="P",.T.,.F.)
		Replace ErJournal.Cancelled With artrans.Cancelled
		Replace ErJournal.DtCreated With artrans.DateAdded
	Else
		Select ArJournal
		Append Blank
		Replace ArJournal.IdNo With Val(cTranno)
		Replace ArJournal.CustIdNo With nIdNo
		Replace ArJournal.TransDate With artrans.Date
		Replace ArJournal.AcctIdNo With nAcctIdNo
		Replace ArJournal.Reference With artrans.Reference
		Replace ArJournal.TransType With artrans.ARTTYPE
		Replace ArJournal.Amount With artrans.Amount
		Replace ArJournal.DueDate With artrans.DATEDUE
		Replace ArJournal.SettDate With artrans.Date
		Replace ArJournal.SettDisc With 0
		Replace ArJournal.InvoiceNo With artrans.Reference
		Replace ArJournal.InvoiceDt With artrans.INV_DATE
		Replace ArJournal.Notes With artrans.Descript
		Replace ArJournal.Posted With Iif(artrans.Posted="P",.T.,.F.)
		Replace ArJournal.Cancelled With artrans.Cancelled
		Replace ArJournal.DtCreated With artrans.DateAdded
	Endif
	Select artrans
	Skip
Enddo
Close Databases

********************************
* create GeneralJournal/Items *
********************************

Create Table c:\temp\GnJournal.Dbf (IdNo Integer(6),;
	TransDate Date(8),;
	Reference c(15),;
	Notes c(254),;
	Posted Logical,;
	Closing Logical,;
	Cancelled Logical,;
	DtCreated Date(8))
Use

Create Table c:\temp\GnJourItm.Dbf ;
	(IdNo Integer(6),;
	Sequence Int(7),;
	JourIdNo Int(7),;
	AcctIdNo Int(7),;
	Debit numeric(10,2),;
	Credit numeric(10,2),;
	ProfIdNo Int(7),;
	Notes c(254),;
	Posted Logical)
Use

Select 2
Use Y:\acctbackup\genrjour.Dbf Index Y:\acctbackup\genrjour.Cdx Exclusive Alias genrjour
Set Order To GENJTRNO   && TRANNO
Select 3
Use Y:\acctbackup\JOURITEM.Dbf Index Y:\acctbackup\JOURITEM.Cdx Exclusive Alias JOURITEM
Set Order To JRITJCTN   && JOURCODE+TRANNO
Set Filter To JOURCODE="GJ"
Go Top
Select 4
Use c:\temp\GnJournal.Dbf  Exclusive Alias GnJournal
Zap
Set Order To
Select 5
Use c:\temp\GnJourItm Exclusive Alias GnJourItm
Zap
Select genrjour
Go Top
ctr = 0
Do While Not Eof()
	cTranno = genrjour.TRANNO
	Select JOURITEM
	Seek "GJ"+cTranno
	SEQ = 0
	Do While TRANNO = cTranno And JOURITEM.JOURCODE="GJ" And Not Eof()
		SEQ = SEQ + 1
		Select GnJourItm
		Append Blank
		ctr = ctr + 1
		Replace GnJourItm.IdNo With ctr
		Replace GnJourItm.Sequence With SEQ
		Replace GnJourItm.JourIdNo With Val(JOURITEM.TRANNO)
		Replace GnJourItm.AcctIdNo With Val(JOURITEM.ACCTCODE)
		Replace GnJourItm.Debit With JOURITEM.Debit
		Replace GnJourItm.Credit With JOURITEM.Credit
		If JOURITEM.DEPTCODE = "S" Then
			Replace GnJourItm.ProfIdNo With 1000 + Val(Substr(JOURITEM.DEPTCODE,2))
		Else
			Replace GnJourItm.ProfIdNo With Val(JOURITEM.DEPTCODE)
		Endif
		Replace GnJourItm.Notes With JOURITEM.Descript
		Replace GnJourItm.Posted With Iif(JOURITEM.Posted="P",.T.,.F.)
		Select JOURITEM
		Skip
	Enddo
	Select GnJournal
	Append Blank
	Replace GnJournal.IdNo With Val(cTranno)
	Replace GnJournal.TransDate With genrjour.Date
	Replace GnJournal.Reference With genrjour.Reference
	Replace GnJournal.Notes With genrjour.Descript
	Replace GnJournal.Closing WITH genrjour.Closing
	Replace GnJournal.Posted With Iif(genrjour.Posted="P",.T.,.F.)
	Replace GnJournal.Cancelled With genrjour.Cancelled
	Replace GnJournal.DtCreated With genrjour.DateAdded
	Select genrjour
	Skip
Enddo


****************************************************************
* create CashDisbursement Journal/Items *
****************************************************************

Create Table c:\temp\CDJournal.Dbf (IdNo Integer(6),;
	TransDate Date(8),;
	Reference c(15),;
	Amount N(10,2),;
	AcctIdNo Int(7),;
	PayType c(1),;
	PayeeIdNo Int(7),;
	PayeeName Varchar(50),;
	OrNumber Varchar(15),;
	DiscTaken numeric(10,2),;
	DiscActId Integer(7) Null,;
	Applied numeric(10,2),;
	UnApplied numeric(10,2),;
	VatNumber Varchar(15),;
	VatAmount numeric(10,2),;
	Notes Varchar(254),;
	Posted Logical,;
	DtCreated Date(8),;
	Cancelled Logical)

Use

Create Table c:\temp\CdJourItm.Dbf ;
	(IdNo Integer(6),;
	Sequence Int(7),;
	JourIdNo Int(7),;
	AcctIdNo Int(7),;
	Debit numeric(10,2),;
	Credit numeric(10,2),;
	ProfIdNo Int(7),;
	Notes c(254),;
	Posted Logical)
Use

Select 1
Use c:\temp\customer.Dbf Exclusive Alias customer
Index On CustCode Tag CustCode
Select 2
Use c:\temp\supplier.Dbf Exclusive Alias supplier
Index On SuppCode Tag SuppCode
Select 3
Use Y:\acctbackup\CDisburs.Dbf Index Y:\acctbackup\CDisburs.Cdx Exclusive Alias CDisburs
Set Order To CDVHPSDT   && POSTED+DTOS(DATE)
Set Filter To "-" $ Reference Or (Year(CDisburs.Date)>2019 And Val(CDisburs.Reference) > 20000)
Go Top
Select 4
Use Y:\acctbackup\JOURITEM.Dbf Index Y:\acctbackup\JOURITEM.Cdx Exclusive Alias JOURITEM
Set Order To JRITJCTN   && JOURCODE+TRANNO
Go Top
Select 5
Use c:\temp\CDJournal.Dbf  Exclusive Alias CDJournal
Zap
Set Order To
Select 6
Use c:\temp\CdJourItm Exclusive Alias CdJourItm
Zap
Select CDisburs
Go Top
ctr = 0
Do While Not Eof()
	cPayeeCode = CDisburs.PayeeCod
	cTranno = CDisburs.TRANNO
	cPaymType = ""
	cPayee = ""
	nIdNo = 0
	If CDisburs.Apply_To = "I" Then
		cPaymType = "A"
	Else
		If CDisburs.PayType = "S" Then
			cPaymType = "S"
		Else
			cPaymType = "O"
			cPayee = CDisburs.Payee
		Endif
	Endif
	If cPaymType = "A" Or cPaymType = "S"
		Select supplier
		Seek cPayeeCode
		If Not Eof()
			nIdNo = supplier.IdNo
		Endif
	Endif
	Select JOURITEM
	Seek "CD"+cTranno
	SEQ = 0
	nVATAMT = 0
	cVATNO = ""
	nAcctIdNo = 0
	nDiscAcId = 0
	nPVatAmt = 0
	Do While TRANNO = cTranno And JOURCODE="CD" And Not Eof()
		If SEQ = 0 Then
			nAcctIdNo = Val(JOURITEM.ACCTCODE)
		Endif
		SEQ = SEQ + 1
		Select CdJourItm
		If JOURITEM.VATAMT > nPVatAmt Then
			nPVatAmt = JOURITEM.VATAMT
			If Not Empty(JOURITEM.VAT_NO) Then
				cVATNO = JOURITEM.VAT_NO
			Endif
		Endif
		nVATAMT = nVATAMT + JOURITEM.VATAMT
		Append Blank
		ctr = ctr + 1
		Replace CdJourItm.IdNo With ctr
		Replace CdJourItm.Sequence With SEQ
		Replace CdJourItm.JourIdNo With Val(JOURITEM.TRANNO)
		Replace CdJourItm.AcctIdNo With Val(JOURITEM.ACCTCODE)
		Replace CdJourItm.Debit With JOURITEM.Debit
		Replace CdJourItm.Credit With JOURITEM.Credit
		If JOURITEM.DEPTCODE = "S" Then
			Replace CdJourItm.ProfIdNo With 1000 + Val(Substr(JOURITEM.DEPTCODE,2))
		Else
			Replace CdJourItm.ProfIdNo With Val(JOURITEM.DEPTCODE)
		Endif
		Replace CdJourItm.Notes With JOURITEM.Descript
		Replace CdJourItm.Posted With Iif(JOURITEM.Posted="P",.T.,.F.)
		If Round(CdJourItm.Debit,2) <> 0 Or Round(CdJourItm.Credit,2) <> 0 Then
			If JOURITEM.ACCTCODE = "210" Or JOURITEM.ACCTCODE = "204" Or JOURITEM.ACCTCODE = "205" Or JOURITEM.ACCTCODE = "203" Then
				nDiscAcId = 411
			Else
				If JOURITEM.ACCTCODE = "202" Then
					nDiscAcId = 489
				Else
					If JOURITEM.ACCTCODE = "112" Then
						nDiscAcId = 527
					Endif
				Endif
			Endif
		Endif
		Select JOURITEM
		Skip
	Enddo
	Select CDJournal
	Append Blank
	Replace CDJournal.IdNo With Val(cTranno)
	Replace CDJournal.TransDate With CDisburs.Date
	Replace CDJournal.Reference With CDisburs.Reference
	Replace CDJournal.Amount With CDisburs.Amount
	Replace CDJournal.AcctIdNo With Val(CDisburs.CashCode)
	Replace CDJournal.PayType With cPaymType
	Replace CDJournal.PayeeIdNo With nIdNo
	Replace CDJournal.PayeeName With cPayee
	Replace CDJournal.OrNumber With CDisburs.O_r_no
	Replace CDJournal.DiscTaken With CDisburs.DiscTaken
	If nDiscAcId > 0 Then
		Replace CDJournal.DiscActId With nDiscAcId
	Else
		Replace CDJournal.DiscActId With Null
	Endif
	If CDisburs.Apply_To = "I" Then
		Replace CDJournal.Applied With CDisburs.AplAmt
	Endif
	Replace CDJournal.UnApplied With CDisburs.ToAply
	Replace CDJournal.VatNumber With cVATNO
	Replace CDJournal.VatAmount With nVATAMT
	Replace CDJournal.Notes With Trim(CDisburs.Descript)
	Replace CDJournal.Posted With Iif(CDisburs.Posted="P",.T.,.F.)
	Replace CDJournal.Cancelled With CDisburs.Cancelled
	Replace CDJournal.DtCreated With CDisburs.DateAdded

	Select CDisburs
	Skip
Enddo
Close Databases

****************************************************************
* create CheckDisbursement Journal/Items *
************************************************************

Create Table c:\temp\CkJournal.Dbf (IdNo Integer(6),;
	TransDate Date(8),;
	Reference c(15),;
	Amount N(10,2),;
	AcctIdNo Int(7),;
	PayType c(1),;
	PayeeIdNo Int(7),;
	PayeeName Varchar(50),;
	CheckNo   Varchar(10),;
	CheckDate Date(8),;
	OrNumber Varchar(15),;
	DiscTaken numeric(10,2),;
	DiscActId Integer(7) Null,;
	Applied numeric(10,2),;
	UnApplied numeric(10,2),;
	VatNumber Varchar(15),;
	VatAmount numeric(10,2),;
	Notes Varchar(254),;
	Posted Logical,;
	DtCreated Date(8),;
	Cancelled Logical)

Use

Create Table c:\temp\CkJourItm.Dbf ;
	(IdNo Integer(6),;
	Sequence Int(7),;
	JourIdNo Int(7),;
	AcctIdNo Int(7),;
	Debit numeric(10,2),;
	Credit numeric(10,2),;
	ProfIdNo Int(7),;
	Notes c(254),;
	Posted Logical)
Use

Select 1
Use c:\temp\customer.Dbf Exclusive Alias customer
Index On CustCode Tag CustCode
Select 2
Use c:\temp\supplier.Dbf Exclusive Alias supplier
Index On SuppCode Tag SuppCode
Select 3
Use Y:\acctbackup\CDisburs.Dbf Index Y:\acctbackup\CDisburs.Cdx Exclusive Alias CDisburs
Set Order To CDVHPSDT   && POSTED+DTOS(DATE)
Set Filter To Not ("-" $ Reference Or (Year(CDisburs.Date)>2019 And Val(CDisburs.Reference) > 20000))
Go Top
Select 4
Use Y:\acctbackup\JOURITEM.Dbf Index Y:\acctbackup\JOURITEM.Cdx Exclusive Alias JOURITEM
Set Order To JRITJCTN   && JOURCODE+TRANNO
Go Top
Select 5
Use c:\temp\CkJournal.Dbf  Exclusive Alias CkJournal
Zap
Set Order To
Select 6
Use c:\temp\CkJourItm Exclusive Alias CkJourItm
Zap
Select CDisburs
Go Top
ctr = 0
Do While Not Eof()
	cPayeeCode = CDisburs.PayeeCod
	cTranno = CDisburs.TRANNO
	cPaymType = ""
	cPayee = ""
	nIdNo = 0
	If CDisburs.Apply_To = "I" Then
		cPaymType = "A"
	Else
		If CDisburs.PayType = "S" Then
			cPaymType = "S"
		Else
			cPaymType = "O"
			cPayee = CDisburs.Payee
		Endif
	Endif
	If cPaymType = "A" Or cPaymType = "S"
		Select supplier
		Seek cPayeeCode
		If Not Eof()
			nIdNo = supplier.IdNo
		Endif
	Endif
	Select JOURITEM
	Seek "CD"+cTranno
	SEQ = 0
	nVATAMT = 0
	cVATNO = ""
	nAcctIdNo = 0
	nDiscAcId = 0
	nPVatAmt = 0
	Do While TRANNO = cTranno And JOURCODE="CD" And Not Eof()
		If SEQ = 0 Then
			nAcctIdNo = Val(JOURITEM.ACCTCODE)
		Endif
		SEQ = SEQ + 1
		Select CkJourItm
		If JOURITEM.VATAMT > nPVatAmt Then
			nPVatAmt = JOURITEM.VATAMT
			If Not Empty(JOURITEM.VAT_NO) Then
				cVATNO = JOURITEM.VAT_NO
			Endif
		Endif
		nVATAMT = nVATAMT + JOURITEM.VATAMT
		Append Blank
		ctr = ctr + 1
		Replace CkJourItm.IdNo With ctr
		Replace CkJourItm.Sequence With SEQ
		Replace CkJourItm.JourIdNo With Val(JOURITEM.TRANNO)
		Replace CkJourItm.AcctIdNo With Val(JOURITEM.ACCTCODE)
		Replace CkJourItm.Debit With JOURITEM.Debit
		Replace CkJourItm.Credit With JOURITEM.Credit
		If JOURITEM.DEPTCODE = "S" Then
			Replace CkJourItm.ProfIdNo With 1000 + Val(Substr(JOURITEM.DEPTCODE,2))
		Else
			Replace CkJourItm.ProfIdNo With Val(JOURITEM.DEPTCODE)
		Endif
		Replace CkJourItm.Notes With JOURITEM.Descript
		Replace CkJourItm.Posted With Iif(JOURITEM.Posted="P",.T.,.F.)
		If Round(CkJourItm.Debit,2) <> 0 Or Round(CkJourItm.Credit,2) <> 0 Then
			If JOURITEM.ACCTCODE = "210" Or JOURITEM.ACCTCODE = "204" Or JOURITEM.ACCTCODE = "205" Or JOURITEM.ACCTCODE = "203" Then
				nDiscAcId = 411
			Else
				If JOURITEM.ACCTCODE = "202" Then
					nDiscAcId = 489
				Else
					If JOURITEM.ACCTCODE = "112" Then
						nDiscAcId = 527
					Endif
				Endif
			Endif
		Endif
		Select JOURITEM
		Skip
	Enddo
	Select CkJournal
	Append Blank
	Replace CkJournal.IdNo With Val(cTranno)
	Replace CkJournal.TransDate With CDisburs.Date
	Replace CkJournal.Reference With CDisburs.Reference
	Replace CkJournal.Amount With CDisburs.Amount
	Replace CkJournal.AcctIdNo With Val(CDisburs.CashCode)
	Replace CkJournal.PayType With cPaymType
	Replace CkJournal.PayeeIdNo With nIdNo
	Replace CkJournal.PayeeName With cPayee
	Replace CkJournal.OrNumber With CDisburs.O_r_no
	Replace CkJournal.CheckNo With CDisburs.Check_No
	Replace CkJournal.CheckDate With CDisburs.Check_Date

	Replace CkJournal.DiscTaken With CDisburs.DiscTaken
	If nDiscAcId > 0 Then
		Replace CkJournal.DiscActId With nDiscAcId
	Else
		Replace CkJournal.DiscActId With Null
	Endif
	If CDisburs.Apply_To = "I" Then
		Replace CkJournal.Applied With CDisburs.AplAmt
	Endif
	Replace CkJournal.UnApplied With CDisburs.ToAply
	Replace CkJournal.VatNumber With cVATNO
	Replace CkJournal.VatAmount With nVATAMT
	Replace CkJournal.Notes With Trim(CDisburs.Descript)
	Replace CkJournal.Posted With Iif(CDisburs.Posted="P",.T.,.F.)
	Replace CkJournal.Cancelled With CDisburs.Cancelled
	Replace CkJournal.DtCreated With CDisburs.DateAdded

	Select CDisburs
	Skip
Enddo
Close Databases


************************************
* create CashReceipt Journal/Items *
************************************

Create Table c:\temp\CrJournal.Dbf (IdNo Integer(6),;
	TransDate Date(8),;
	Reference c(15),;
	Amount N(10,2),;
	AcctIdNo Int(7),;
	PayType c(1),;
	PayeeIdNo Int(7) Null,;
	PayeeName Varchar(50),;
	ChkNumber Varchar(10),;
	ChkDate Date(8),;
	OrNumber Varchar(15),;
	DiscTaken numeric(10,2),;
	DiscActId Integer(7) Null,;
	Applied numeric(10,2),;
	UnApplied numeric(10,2),;
	Notes Varchar(254),;
	Posted Logical,;
	DtCreated Date(8),;
	Cancelled Logical)

Use

Create Table c:\temp\CrJourItm.Dbf ;
	(IdNo Integer(6),;
	Sequence Int(7),;
	JourIdNo Int(7),;
	AcctIdNo Int(7),;
	Debit numeric(10,2),;
	Credit numeric(10,2),;
	ProfIdNo Int(7),;
	Notes c(254),;
	Posted Logical)
Use

Close Databases


Select 1
Use c:\temp\customer.Dbf Exclusive Alias customer
Index On CustCode Tag CustCode
Select 2
Use c:\temp\supplier.Dbf Exclusive Alias supplier
Index On SuppCode Tag SuppCode
Select 3
Use Y:\acctbackup\CReceipt.Dbf Index Y:\acctbackup\CReceipt.Cdx Exclusive Alias CReceipt
Set Order To CRCTTRNO   && TRANNO
Go Top
Select 4
Use Y:\acctbackup\JOURITEM.Dbf Index Y:\acctbackup\JOURITEM.Cdx Exclusive Alias JOURITEM
Set Order To JRITJCTN   && JOURCODE+TRANNO
Go Top
Select 5
Use c:\temp\CrJournal.Dbf  Exclusive Alias CrJournal
Zap
Set Order To
Select 6
Use c:\temp\CrJourItm Exclusive Alias CrJourItm
Zap
Select CReceipt
Go Top
ctr = 0
Do While Not Eof()
	cPayeeCode = CReceipt.PayorCod
	cTranno = CReceipt.TRANNO
	cPaymType = ""
	cPayee = ""
	nIdNo = 0
	If CReceipt.Apply_To = "I" Then
		If CReceipt.PayType = "C" Then
			cPaymType = "A"
		Else
			If CReceipt.PayType = "S" Then
				cPaymType = "R"
			Endif
		Endif
	Else
		If CReceipt.PayType = "C" Then
			cPaymType = "A"
		ELSE
			IF cPaymType = "S" then
 				cPaymType = "R"
			else
		 		cPaymType = "O"
	 			cPayee = CReceipt.Payor
	 	 ENDIF
		Endif
	Endif
	If cPaymType = "A" Or cPaymType = "C"
		Select customer
		Seek cPayeeCode
		If Not Eof()
			nIdNo = customer.IdNo
		Endif
	Else
		If cPaymType = "R" Then
			Select supplier
			Seek cPayeeCode
			If Not Eof()
				nIdNo = supplier.IdNo
			Endif
		Endif
	Endif
	Select JOURITEM
	Seek "CR"+cTranno
	SEQ = 0
	nAcctIdNo = 0
	nDiscAcId = 0
	nPVatAmt = 0
	Do While TRANNO = cTranno And JOURCODE="CR" And Not Eof()
		If SEQ = 0 Then
			nAcctIdNo = Val(JOURITEM.ACCTCODE)
		Endif
		SEQ = SEQ + 1
		Select CrJourItm
		Append Blank
		ctr = ctr + 1
		Replace CrJourItm.IdNo With ctr
		Replace CrJourItm.Sequence With SEQ
		Replace CrJourItm.JourIdNo With Val(JOURITEM.TRANNO)
		Replace CrJourItm.AcctIdNo With Val(JOURITEM.ACCTCODE)
		Replace CrJourItm.Debit With JOURITEM.Debit
		Replace CrJourItm.Credit With JOURITEM.Credit
		If JOURITEM.DEPTCODE = "S" Then
			Replace CrJourItm.ProfIdNo With 1000 + Val(Substr(JOURITEM.DEPTCODE,2))
		Else
			Replace CrJourItm.ProfIdNo With Val(JOURITEM.DEPTCODE)
		Endif
		Replace CrJourItm.Notes With JOURITEM.Descript
		Replace CrJourItm.Posted With Iif(JOURITEM.Posted="P",.T.,.F.)
		If Round(CrJourItm.Debit,2) <> 0 Or Round(CrJourItm.Credit,2) <> 0 Then
			If JOURITEM.ACCTCODE = "210" Or JOURITEM.ACCTCODE = "204" Or JOURITEM.ACCTCODE = "205" Or JOURITEM.ACCTCODE = "203" Then
				nDiscAcId = 411
			Else
				If JOURITEM.ACCTCODE = "202" Then
					nDiscAcId = 489
				Else
					If JOURITEM.ACCTCODE = "112" Then
						nDiscAcId = 527
					Endif
				Endif
			Endif
		Endif
		Select JOURITEM
		Skip
	Enddo
	Select CrJournal
	Append Blank
	Replace CrJournal.IdNo With Val(cTranno)
	Replace CrJournal.TransDate With CReceipt.Date
	Replace CrJournal.Reference With CReceipt.Reference
	Replace CrJournal.Amount With CReceipt.Amount
	Replace CrJournal.AcctIdNo With Val(CReceipt.CashCode)
	Replace CrJournal.PayType With cPaymType
	If nIdNo > 0 Then
		Replace CrJournal.PayeeIdNo With nIdNo
	Else
		Replace CrJournal.PayeeIdNo With Null
	Endif
	Replace CrJournal.PayeeName With cPayee
	Replace CrJournal.ChkNumber With CReceipt.Check_No
	Replace CrJournal.ChkDate With CReceipt.Check_Date
* Replace CrJournal.OrNumber With CReceipt.O_r_no
	Replace CrJournal.DiscTaken With CReceipt.DiscTaken
	If nDiscAcId > 0 Then
		Replace CrJournal.DiscActId With nDiscAcId
	Else
		Replace CrJournal.DiscActId With Null
	Endif
	If CReceipt.Apply_To = "I" Then
		Replace CrJournal.Applied With CReceipt.Amount
	Endif
	Replace CrJournal.UnApplied With 0
	Replace CrJournal.Notes With Trim(CReceipt.Descript)
	Replace CrJournal.Posted With Iif(CReceipt.Posted="P",.T.,.F.)
	Replace CrJournal.Cancelled With CReceipt.Cancelled
	Replace CrJournal.DtCreated With CReceipt.DateAdded

	Select CReceipt
	Skip
Enddo

Close All

***************************
* create Ap Open invoices *
***************************
Select 1
Use c:\temp\ApJourItm.Dbf Alias ApJourItm
Index On Str(JourIdNo,7)+Str(Sequence,7) Tag apjIdNo
Go Top
Select 2
Use c:\temp\ApOpnInv
Go Bottom
nCtr = ApOpnInv.IdNo
Select 3
Use c:\temp\ApJournal.Dbf  Exclusive Alias ApJournal
Go Top
nCtr = 0
Do While Not Eof()
	apjIdNo = ApJournal.IdNo
	Select ApJourItm
	Seek Str(apjIdNo,7)+Str(1,7)
	apjItIdNo = 0
	apSw = 0
	Do While ApJourItm.JourIdNo = apjIdNo And Not Eof("apjouritm")

		If Str(ApJourItm.AcctIdNo,3,0) $ "210:204:205:203:202:227:207:226" Then
			apjItIdNo = ApJourItm.IdNo
			nAcctIdNo = ApJourItm.AcctIdNo
			apSw = 1
			Exit
		Endif
		Select ApJourItm
		Skip
	Enddo
*!*		If apSw = 0 And Not ApJournal.Cancelled
*!*			Set Step On
*!*		Endif
	Select ApOpnInv
	nCtr = nCtr + 1
	Append Blank
	Replace ApOpnInv.IdNo With nCtr
	Replace ApOpnInv.JournalCd With "AP"
	Replace ApOpnInv.JourIdNo With apjIdNo
	Replace ApOpnInv.JrItIdNo With apjItIdNo
	Replace ApOpnInv.SuppIdNo With ApJournal.SuppIdNo
	Replace ApOpnInv.Date With ApJournal.TransDate
	If ApJournal.TransType = "I" Or ApJournal.TransType = "C" Then
		Replace ApOpnInv.Amount With ApJournal.Amount
	Else
		Replace ApOpnInv.Amount With ApJournal.Amount * -1
	Endif
	Select ApJournal
	Skip
Enddo

Select ApJournal
Use

* from Supplier Refunds

Select 4
Use c:\temp\CrJourItm.Dbf Alias CrJourItm
Index On Str(JourIdNo,7)+Str(Sequence,7) Tag apjIdNo
Go Top
Select 5
Use c:\temp\CrJournal.Dbf  Exclusive Alias CrJournal
Set Filter To PayType = "R"
Go Top
Do While Not Eof()
	apjIdNo = CrJournal.IdNo
	Select CrJourItm
	Seek Str(apjIdNo,7)+Str(1,7)
	apjItIdNo = 0
	apSw = 0
	Do While CrJourItm.JourIdNo = apjIdNo And Not Eof("crJouritm")
		If Str(CrJourItm.AcctIdNo,3,0) $ "210:204:205:203:202:227:207:226" Then
			apjItIdNo = CrJourItm.IdNo
			nAcctIdNo = CrJourItm.AcctIdNo
			apSw = 1
			Exit
		Endif
		Select CrJourItm
		Skip
	Enddo
*!*		If apSw = 0 And Not CrJournal.Cancelled
*!*			Set Step On
*!*		Endif
	Select ApOpnInv
	nCtr = nCtr + 1
	Append Blank
	Replace ApOpnInv.IdNo With nCtr
	Replace ApOpnInv.JournalCd With "CR"
	Replace ApOpnInv.JourIdNo With apjIdNo
	Replace ApOpnInv.JrItIdNo With apjItIdNo
	Replace ApOpnInv.SuppIdNo With CrJournal.PayeeIdNo
	Replace ApOpnInv.Date With CrJournal.TransDate
	Replace ApOpnInv.Amount With CrJournal.Amount * -1
	Select CrJournal
	Skip
Enddo
Close Databases

***************************************************
* create CashDisbursement AP Paid Invoices /Items *
* CadOiItem / CkdOiItem                           *
***************************************************

Select 1
Create Table c:\temp\CadOiItm.Dbf ;
	(IdNo Integer(6),;
	CadIdNo Int(7),;
	ApOpIdNo Int(7),;
	Sequence Int(7),;
	Amount numeric(10,2),;
	DiscTakn numeric(10,2))


Select 2
Create Table c:\temp\CkdOiItm.Dbf ;
	(IdNo Integer(6),;
	CkdIdNo Int(7),;
	ApOpIdNo Int(7),;
	Sequence Int(7),;
	Amount numeric(10,2),;
	DiscTakn numeric(10,2))
Close All

Select 1
Use c:\temp\CDJournal.Dbf Alias CDJournal Exclusive
Index On TransDate Tag cdDate
Go Top
Select 2
Use c:\temp\CkJournal.Dbf Alias CkJournal Exclusive
Index On TransDate Tag ckDate
Go Top
Select 3
Use c:\temp\ApOpnInv Alias ApOpnInv Exclusive
Index On Str(SuppIdNo,5,0) + Str(Year(Date),4) + Str(Month(Date),2) + Str(Day(Date),2) Tag ckdDate
nCtr = 1
switch = 0
Select 4
Use c:\temp\CadOiItm Alias CadOiItm

Select 5
Use c:\temp\CkdOiItm Alias CkdOiItm


Select CDJournal
Do While Not (Eof("CdJournal") And Eof("CkJournal"))

	cdDate = Iif(Eof("CdJournal"),Date()+10000,CDJournal.TransDate)
	ckDate = Iif(Eof("CkJournal"),Date()+10000,CkJournal.TransDate)

	If cdDate <= ckDate And Not Eof("CdJournal") Then
		If CDJournal.PayType = "A" Then

			rPayAmount = CDJournal.Amount
			rDscTknAmt = CDJournal.DiscTaken
			trantype  = CDJournal.PayType
			rTotApPay = rPayAmount+rDscTknAmt
			sIdNo = CDJournal.PayeeIdNo
			cdIdNo = CDJournal.IdNo
			nSeq = 0

			Select ApOpnInv
			Seek Str(sIdNo,5,0)

			negAmount = 0
* look for negative amounts and apply them if the date is less than the current date
			Do While ApOpnInv.SuppIdNo = sIdNo And ApOpnInv.Date <= cdDate  And Not Eof("ApOpnInv")
				If ApOpnInv.Amount < 0 And ApOpnInv.Date <= cdDate  Then
					lNegAmount = ApOpnInv.Amount
					negAmount = negAmount + lNegAmount * -1
					Replace ApOpnInv.PaidAmt With  ApOpnInv.PaidAmt + lNegAmount
					Replace ApOpnInv.Amount With 0
					nApOpnIdNo = ApOpnInv.IdNo
					Select CadOiItm
					nSeq = nSeq + 1
					Append Blank
					Replace IdNo With nCtr
					Replace CadIdNo With cdIdNo
					Replace ApOpIdNo With nApOpnIdNo
					Replace Sequence With nSeq
					Replace Amount With lNegAmount
					Replace DiscTakn With 0
					nCtr = nCtr + 1
				Endif
				Select ApOpnInv
				Skip
			Enddo

			Seek Str(sIdNo,5,0)
			rPayAmount = rPayAmount + negAmount
			rTotApPay = rTotApPay + negAmount

			Select ApOpnInv
			Seek Str(sIdNo,5,0)
			Do While ApOpnInv.SuppIdNo = sIdNo And rTotApPay <> 0 And Not Eof("ApOpnInv")
* if Open invoice not yet paid
				If ApOpnInv.Amount <> 0 Then
					If ApOpnInv.Amount <= rTotApPay Then
*  if open invoice amount is less than Payment Amount
						If rPayAmount <= ApOpnInv.Amount Then
							m.AplAmt = rPayAmount
							rTotApPay = rTotApPay - rPayAmount
							rPayAmount = 0
							m.AplDsc = ApOpnInv.Amount - m.AplAmt
							rDscTknAmt = rDscTknAmt - m.AplDsc
							rTotApPay = rTotApPay - m.AplDsc
						Else
							m.AplAmt = ApOpnInv.Amount
							m.AplDsc = 0
							rTotApPay = rTotApPay - m.AplAmt
							rPayAmount = rPayAmount - m.AplAmt
						Endif

						Replace ApOpnInv.PaidAmt With ApOpnInv.PaidAmt + m.AplAmt
						Replace ApOpnInv.DiscTakn With ApOpnInv.DiscTakn + m.AplDsc
						Replace ApOpnInv.Amount With 0
					Else
* discount and payment is more than the openinvoice amount			
						m.AplAmt = rPayAmount
						m.AplDsc = rDscTknAmt
						Replace ApOpnInv.PaidAmt With ApOpnInv.PaidAmt + m.AplAmt
						Replace ApOpnInv.DiscTakn With ApOpnInv.DiscTakn + m.AplDsc
						Replace ApOpnInv.Amount  With ApOpnInv.Amount - rTotApPay
						rTotApPay = 0
					Endif
					nApOpnIdNo = ApOpnInv.IdNo
					Select CadOiItm
					nSeq = nSeq + 1
					Append Blank
					Replace IdNo With nCtr
					Replace CadIdNo With cdIdNo
					Replace ApOpIdNo With nApOpnIdNo
					Replace Sequence With nSeq
					Replace Amount With m.AplAmt
					Replace DiscTakn With m.AplDsc
					nCtr = nCtr + 1
				Endif
				Select ApOpnInv
				Skip
			Enddo
		Endif
		Select CDJournal
		If Eof()
			cdDate = Date() + 10000
		Else
			Skip
		Endif
	Else
		If CkJournal.PayType = "A" Then
			rPayAmount = CkJournal.Amount
			rDscTknAmt = CkJournal.DiscTaken
			trantype  = CkJournal.PayType
			rTotApPay = rPayAmount + rDscTknAmt
			sIdNo = CkJournal.PayeeIdNo
			ckIdNo = CkJournal.IdNo
			nSeq = 0
			Select ApOpnInv
			Seek Str(sIdNo,5,0)

			negAmount = 0
* look for negative amounts and apply them if the date is less than the current date
			Do While ApOpnInv.SuppIdNo = sIdNo And ApOpnInv.Date <= cdDate  And Not Eof("ApOpnInv")
				If ApOpnInv.Amount < 0 And ApOpnInv.Date <= cdDate  Then
					lNegAmount = ApOpnInv.Amount
					negAmount = negAmount + lNegAmount * -1
					Replace ApOpnInv.PaidAmt With  ApOpnInv.PaidAmt + lNegAmount
					Replace ApOpnInv.Amount With 0
					nApOpnIdNo = ApOpnInv.IdNo
					Select CkdOiItm
					nSeq = nSeq + 1
					Append Blank
					Replace IdNo With nCtr
					Replace CkdIdNo With ckIdNo
					Replace ApOpIdNo With nApOpnIdNo
					Replace Sequence With nSeq
					Replace Amount With lNegAmount
					Replace DiscTakn With 0
					nCtr = nCtr + 1
				Endif
				Select ApOpnInv
				Skip
			Enddo

			Seek Str(sIdNo,5,0)
			rPayAmount = rPayAmount + negAmount
			rTotApPay = rTotApPay + negAmount

			Do While ApOpnInv.SuppIdNo = sIdNo And rTotApPay <> 0 And Not Eof("ApOpnInv")
* if Open invoice not yet paid
				If ApOpnInv.Amount <> 0 Then
					If ApOpnInv.Amount <= rTotApPay Then
*  if open invoice amount is less than Payment Amount
						If rPayAmount <= ApOpnInv.Amount Then
							m.AplAmt = rPayAmount
							rTotApPay = rTotApPay - rPayAmount
							rPayAmount = 0
							m.AplDsc = ApOpnInv.Amount - m.AplAmt
							rDscTknAmt = rDscTknAmt - m.AplDsc
							rTotApPay = rTotApPay - m.AplDsc
						Else
							m.AplAmt = ApOpnInv.Amount
							m.AplDsc = 0
							rTotApPay = rTotApPay - m.AplAmt
							rPayAmount = rPayAmount - m.AplAmt
						Endif
						Replace ApOpnInv.PaidAmt With ApOpnInv.PaidAmt + m.AplAmt
						Replace ApOpnInv.DiscTakn With ApOpnInv.DiscTakn + m.AplDsc
						Replace ApOpnInv.Amount With 0
					Else
* discount and payment is more than the openinvoice amount			
						m.AplAmt = rPayAmount
						m.AplDsc = rDscTknAmt
						Replace ApOpnInv.PaidAmt With ApOpnInv.PaidAmt + m.AplAmt
						Replace ApOpnInv.DiscTakn With ApOpnInv.DiscTakn + m.AplDsc
						Replace ApOpnInv.Amount  With ApOpnInv.Amount - rTotApPay
						rTotApPay = 0
					Endif
					nApOpnIdNo = ApOpnInv.IdNo
					Select CkdOiItm
					nSeq = nSeq + 1
					Append Blank
					Replace IdNo With nCtr
					Replace CkdIdNo With ckIdNo
					Replace ApOpIdNo With nApOpnIdNo
					Replace Sequence With nSeq
					Replace Amount With m.AplAmt
					Replace DiscTakn With m.AplDsc
					nCtr = nCtr + 1
				Endif
				Select ApOpnInv
				Skip
			Enddo
		Endif
		Select CkJournal
		If Eof()
			ckDate = Date() + 10000
		Else
			Skip
		Endif
	Endif
	If Eof("CkJournal") And Eof("CdJournal") Then
		Exit
	Endif
Enddo

Close All




***************************
* create Ar Open invoices *
***************************
Select 1
Use c:\temp\ArJourItm.Dbf Alias ArJourItm
Index On Str(JourIdNo,7)+Str(Sequence,7) Tag arjIdNo
Go Top
Select 2
Use c:\temp\ArOpnInv
Go Bottom
nCtr = ArOpnInv.IdNo
Select 3
Use c:\temp\ArJournal.Dbf  Exclusive Alias ArJournal
Go Top
nCtr = 0
Do While Not Eof()
	arjIdNo = ArJournal.IdNo
	Select ArJourItm
	Seek Str(arjIdNo,7)+Str(1,7)
	arjItIdNo = 0
	arSw = 0
	Do While ArJourItm.JourIdNo = arjIdNo And Not Eof("arjouritm")
		If ArJourItm.AcctIdNo = 112 Or ArJourItm.AcctIdNo = 114 Then
			arjItIdNo = ArJourItm.IdNo
			nAcctIdNo = ArJourItm.AcctIdNo
			arSw = 1
			Exit
		Endif
		Select ArJourItm
		Skip
	Enddo
*!*		If arSw = 0 And Not ArJournal.Cancelled
*!*			Set Step On
*!*		Endif
	Select ArOpnInv
	nCtr = nCtr + 1
	Append Blank
	Replace ArOpnInv.IdNo With nCtr
	Replace ArOpnInv.JournalCd With "AR"
	Replace ArOpnInv.JourIdNo With arjIdNo
	Replace ArOpnInv.JrItIdNo With arjItIdNo
	Replace ArOpnInv.CustIdNo With ArJournal.CustIdNo
	Replace ArOpnInv.Date With ArJournal.TransDate
	If ArJournal.TransType = "I" Or ArJournal.TransType = "D" Then
		Replace ArOpnInv.Amount With ArJournal.Amount
	Else
		Replace ArOpnInv.Amount With ArJournal.Amount * -1
	Endif
	Select ArJournal
	Skip
Enddo
Use

Close Data

**********************************************
* create CashReceipt AR Paid Invoices /Items *
* CsrOiItem                                  *
**********************************************

Select 1
Create Table c:\temp\CsrOiItm.Dbf ;
	(IdNo Integer(6),;
	CsrIdNo Int(7),;
	ArOpIdNo Int(7),;
	Sequence Int(7),;
	Amount numeric(10,2),;
	DiscTakn numeric(10,2))
Use
Select 1
Use c:\temp\CrJournal.Dbf Alias CrJournal Exclusive
Index On TransDate Tag crDate

Select 2
Use c:\temp\ArOpnInv Alias ArOpnInv Exclusive
Index On Str(CustIdNo,5,0) + Str(Year(Date),4) + Str(Month(Date),2) + Str(Day(Date),2) Tag crDate
nCtr = 1
switch = 0
Select 3
Use c:\temp\CsrOiItm Alias CsrOiItm

Select 4
Use Y:\acctbackup\JOURITEM.Dbf Index Y:\acctbackup\JOURITEM.Cdx Exclusive Alias JOURITEM
Set Order To JRITJCTN   && JOURCODE+TRANNO
Set Filter To JOURCODE="CR"
Go Top
Select 5
Use c:\temp\ApOpnInv Alias ApOpnInv

Select CrJournal
Go Top
Do While Not Eof()
	If CrJournal.PayType = "A" Then
		rPayAmount = CrJournal.Amount
		rDscTknAmt = CrJournal.DiscTaken
		trantype  = CrJournal.PayType
		rTotArPay = rPayAmount+rDscTknAmt
		cIdNo = CrJournal.PayeeIdNo
		crIdNo = CrJournal.IdNo
		nSeq = 0
		Select ArOpnInv
		Seek Str(cIdNo,5,0)
		dDate = CrJournal.TransDate
		negAmount = 0
* look for negative amounts and apply them if the date is less than the current date
		Do While ArOpnInv.CustIdNo = cIdNo And ArOpnInv.Date <= dDate  And Not Eof("ArOpnInv")
			If ArOpnInv.Amount < 0 And ArOpnInv.Date <= dDate  Then
				lNegAmount = ArOpnInv.Amount
				negAmount = negAmount + lNegAmount * -1
				Replace ArOpnInv.PaidAmt With  ArOpnInv.PaidAmt + lNegAmount
				Replace ArOpnInv.Amount With 0
				nArOpnIdNo = ArOpnInv.IdNo
				Select CsrOiItm
				nSeq = nSeq + 1
				Append Blank
				Replace IdNo With nCtr
				Replace CsrIdNo With crIdNo
				Replace ArOpIdNo With nArOpnIdNo
				Replace Sequence With nSeq
				Replace Amount With lNegAmount
				Replace DiscTakn With 0
				nCtr = nCtr + 1
			Endif
			Select ArOpnInv
			Skip
		Enddo

		Seek Str(cIdNo,5,0)
		rPayAmount = rPayAmount + negAmount
		rTotArPay = rTotArPay + negAmount
		Do While ArOpnInv.CustIdNo = cIdNo And rTotArPay <> 0 And Not Eof("ArOpnInv")
* if Open invoice not yet paid
			If ArOpnInv.Amount <> 0 Then
				If ArOpnInv.Amount <= rTotArPay Then
*  if open invoice amount is less than Payment Amount
					If rPayAmount <= ArOpnInv.Amount Then
						m.AplAmt = rPayAmount
						rTotArPay = rTotArPay - rPayAmount
						rPayAmount = 0
						m.AplDsc = ArOpnInv.Amount - m.AplAmt
						rDscTknAmt = rDscTknAmt - m.AplDsc
						rTotArPay = rTotArPay - m.AplDsc
					Else
						m.AplAmt = ArOpnInv.Amount
						m.AplDsc = 0
						rTotArPay = rTotArPay - m.AplAmt
						rPayAmount = rPayAmount - m.AplAmt

					Endif
					Replace ArOpnInv.PaidAmt With ArOpnInv.PaidAmt + m.AplAmt
					Replace ArOpnInv.DiscTakn With ArOpnInv.DiscTakn + m.AplDsc
					Replace ArOpnInv.Amount With 0
* already fully paid so exit the loop
				Else
* discount and payment is more than the openinvoice amount			
					m.AplAmt = rPayAmount
					m.AplDsc = rDscTknAmt
					Replace ArOpnInv.PaidAmt With ArOpnInv.PaidAmt + m.AplAmt
					Replace ArOpnInv.DiscTakn With ArOpnInv.DiscTakn + m.AplDsc
					Replace ArOpnInv.Amount  With ArOpnInv.Amount - rTotArPay
					rTotArPay = 0
				Endif
				nArOpnIdNo = ArOpnInv.IdNo
				Select CsrOiItm
				nSeq = nSeq + 1
				Append Blank
				Replace IdNo With nCtr
				Replace CsrIdNo With crIdNo
				Replace ArOpIdNo With nArOpnIdNo
				Replace Sequence With nSeq
				Replace Amount With m.AplAmt
				Replace DiscTakn With m.AplDsc
				nCtr = nCtr + 1
			Endif
			Select ArOpnInv
			Skip
		Enddo
	Else
*!*			If CrJournal.PayType = "R" Then
*!*	* Supplier Refund

*!*				apjIdNo = CrJournal.IdNo
*!*				Select CrJourItm
*!*				Seek Str(apjIdNo,7)+Str(1,7)
*!*				apjItIdNo = 0
*!*				apSw = 0
*!*				Do While ApJourItm.JourIdNo = apjIdNo And Not Eof("apjouritm")

*!*					If Str(ApJourItm.AcctIdNo,3,0) $ "210:204:205:203:202:227:207:226" Then
*!*						apjItIdNo = ApJourItm.IdNo
*!*						nAcctIdNo = ApJourItm.AcctIdNo
*!*						apSw = 1
*!*						Exit
*!*					Endif
*!*					Select ApJourItm
*!*					Skip
*!*				Enddo
*!*				If apSw = 0 And Not ApJournal.Cancelled
*!*					Set Step On
*!*				Endif
*!*				Select ApOpnInv
*!*				nCtr = nCtr + 1
*!*				Append Blank
*!*				Replace ApOpnInv.IdNo With nCtr
*!*				Replace ApOpnInv.JournalCd With "AP"
*!*				Replace ApOpnInv.JourIdNo With apjIdNo
*!*				Replace ApOpnInv.JrItIdNo With apjItIdNo
*!*				Replace ApOpnInv.SuppIdNo With ApJournal.SuppIdNo
*!*				Replace ApOpnInv.Date With ApJournal.TransDate
*!*				If ApJournal.TransType = "I" Or ApJournal.TransType = "C" Then
*!*					Replace ApOpnInv.Amount With ApJournal.Amount
*!*				Else
*!*					Replace ApOpnInv.Amount With ApJournal.Amount * -1
*!*				Endif


*!*			Endif
	Endif
	Select CrJournal
	Skip
Enddo

Close All

* Finalize ApOpInvo Table

Create Table c:\temp\ApOpInvo.Dbf ;
	(IdNo Integer(6),;
	JournalCd Char(2),;
	JourIdNo Int(7),;
	JrItIdNo Int(7),;
	PaidAmt  numeric(10,2),;
	DiscTakn numeric(10,2))
Append From c:\temp\ApOpnInv.Dbf
Delete File c:\temp\ApOpnInv.Dbf
Close All

* Finalize ArOpInvo Table

Create Table c:\temp\ArOpInvo.Dbf ;
	(IdNo Integer(6),;
	JournalCd Char(2),;
	JourIdNo Int(7),;
	JrItIdNo Int(7),;
	PaidAmt  numeric(10,2),;
	DiscTakn numeric(10,2))
Append From c:\temp\ArOpnInv.Dbf
* Delete File c:\temp\ArOpnInv.Dbf
Close All

*******************************************************************************
* Dbf to Sql
*******************************************************************************

Close Databases


Create Table c:\temp\ChartNBal.Dbf ;
	(IdNo Integer(6),;
	Year INT(4),;
	AcctIdNo INT(7),;
	ByDebit numeric(10,2),;
	ByCredit numeric(10,2))
nCtr = 0
Select 1
Use y:\acctbackup\chartBal.Dbf Alias ChartBal Exclusive
SELECT 2
USE c:\temp\ChartNBal ALIAS ChartNBal
SELECT 1
GO Top
Do While Not Eof()
	nCtr = nCtr + 1
	SELECT ChartNBal
	Append Blank
	Replace ChartNBal.IdNo With nCtr
	Replace ChartNBal.AcctIdNo WITH VAL(ChartBal.AcctCode)
	Replace ChartNBal.Year With VAL(ChartBal.Year)
	Replace ChartNBal.ByDebit With ChartBal.ByDebit
	Replace ChartNBal.ByCredit With ChartBal.ByCredit
	Select ChartBal
	Skip
ENDDO

CLOSE DataBase

Set Deleted On
Set Exclusive On
Set Safety Off
Set Date YMD
SET CENTURY ON

cFields = "[IdNo], [SupplierCode], [SupplierName], [SupplierNameAra], [ContactPerson], [ContactDesignation], [Street], [District], [TownCity], [ProvinceState], [CountryCode], [POBox], "
cFields = cFields + "[ZipCode], [Phone1], [Phone2], [Mobile], [Fax], [Email], [Website], [VATNumber], [CRNumber], [AccountStatus], [APAccountIdNo], [ExpAccountIdNo], [CreditLimit], [SettlementDueDays], [SettlementDiscount], "
cFields = cFields + "[PaymentDueDays], [DateAccountOpen], [BankAccountName], [BankAccountNo], [BankIdNo], [IBAN], [PaymentMethod], [Notes], [OpeningBalance], [Active], [DateCreated]"
DbfToSql(cFields,"Supplier","Supplier")

cFields = "[IdNo],[CustomerCode],[CustomerName],[CustomerNameAra],[ContactPerson],[ContactDesignation],[Street],[District],[TownCity],[ProvinceState],[CountryCode],[POBox],[ZipCode],[Phone1],[Phone2],[Mobile],[Fax],[Email],"
cFields = cFields + "[Website],[VATNumber],[CRNumber],[AccountStatus],[ARAccountIdNo],[RevAccountIdNo],[DiscountSchemeIdNo],[CreditLimit],[SettlementDueDays],[SettlementDiscount],[PaymentDueDays],[DateAccountOpen],[BankAccountName],[BankAccountNo],[BankIdNo],"
cFields = cFields + "[IBAN],[PaymentMethod],[Notes],[OpeningBalance],[Active],[DateCreated]"
DbfToSql(cFields,"Customer","Customer")

cFields = "[IDNo],[SupplierIdNo],[TransactionDate],[ReferenceNo],[TransactionType],[Amount],[AccountIdNo],[DueDate],[SettlementDueDate],[SettlementDiscount],[InvoiceNo],[InvoiceDate],[VatNumber],[VatAmount],[Notes],[Posted],[Cancelled],[DateCreated]"
DbfToSql(cFields,"ApJournal","ApJournal")

cFields = "[IdNo],[Sequence],[JournalIdNo],[AccountIdNo],[Debit],[Credit],[RevCostCenterIdNo],[Notes],[Posted]"
DbfToSql(cFields,"ApJourItm","ApJournalItem")

cFields = "[IDNo],[CustomerIdNo],[TransactionDate],[ReferenceNo],[TransactionType],[Amount],[AccountIdNo],[DueDate],[SettlementDueDate],[SettlementDiscount],[InvoiceNo],[InvoiceDate],[Notes],[Posted],[Cancelled],[DateCreated]"
DbfToSql(cFields,"ArJournal","ArJournal")

cFields = "[IdNo],[Sequence],[JournalIdNo],[AccountIdNo],[Debit],[Credit],[RevCostCenterIdNo],[Notes],[Posted]"
DbfToSql(cFields,"ArJourItm","ArJournalItem")

cFields = "[IDNo],[EmployeeIdNo],[TransactionDate],[ReferenceNo],[TransactionType],[Amount],[AccountIdNo],[Notes],[Posted],[Cancelled],[DateCreated]"
DbfToSql(cFields,"ErJournal","ErJournal")

cFields = "[IdNo],[Sequence],[JournalIdNo],[AccountIdNo],[Debit],[Credit],[RevCostCenterIdNo],[Notes],[Posted]"
DbfToSql(cFields,"ErJourItm","ErJournalItem")

cFields = "[IdNo],[TransactionDate],[ReferenceNo],[Notes],[Posted],[ClosingJournal],[Cancelled],[DateCreated]"
DbfToSql(cFields,"GnJournal","GeneralJournal")

cFields = "[IdNo],[Sequence],[JournalIdNo],[AccountIdNo],[Debit],[Credit],[RevCostCenterIdNo],[Notes],[Posted]"
DbfToSql(cFields,"GnJourItm","GeneralJournalItem")

cFields = "[IdNo],[TransactionDate],[ReferenceNo],[Amount],[AccountIdNo],[PaymentType],[PayeeIdNo],[PayeeName],[ORNumber],[DiscountTaken],[DiscountAccountIdNo],[Applied],[UnApplied],[VatNumber],[VatAmount],[Notes],[Posted],[DateCreated],[Cancelled]"
DbfToSql(cFields,"CdJournal","CashDisbursementJournal")

cFields = "[IdNo],[Sequence],[JournalIdNo],[AccountIdNo],[Debit],[Credit],[RevCostCenterIdNo],[Notes],[Posted]"
DbfToSql(cFields,"CdJourItm","CashDisbursementJournalItem")

cFields = "[IdNo],[TransactionDate],[ReferenceNo],[Amount],[AccountIdNo],[PaymentType],[PayeeIdNo],[PayeeName],[CheckNumber],[CheckDate],[ORNumber],[DiscountTaken],[DiscountAccountIdNo],[Applied],[UnApplied],[VatNumber],[VatAmount],[Notes],[Posted],"
cFields = cFields + "[DateCreated],[Cancelled]"
DbfToSql(cFields,"CkJournal","CheckDisbursementJournal")

cFields = "[IdNo],[Sequence],[JournalIdNo],[AccountIdNo],[Debit],[Credit],[RevCostCenterIdNo],[Notes],[Posted]"
DbfToSql(cFields,"CkJourItm","CheckDisbursementJournalItem")

cFields = "[IdNo],[TransactionDate],[ReferenceNo],[Amount],[AccountIdNo],[PayorType],[PayorIdNo],[Payorname],[CheckNumber],[CheckDate],[ORNumber],[DiscountTaken],[DiscountAccountIdNo],[Applied],[UnApplied],[Notes],[Posted],[DateCreated],[Cancelled]"
DbfToSql(cFields, "CrJournal","CashReceiptJournal")

cFields = "[IdNo],[Sequence],[JournalIdNo],[AccountIdNo],[Debit],[Credit],[RevCostCenterIdNo],[Notes],[Posted]"
DbfToSql(cFields,"CrJourItm","CashReceiptJournalItem")

cFields = "[IdNo],[CadIdNo],[ApOpenInvoiceIdNo],[Sequence],[Amount],[DiscountTaken]"
DbfToSql(cFields,"CadOiItm","CadOiItem")

cFields = "[IdNo],[CkdIdNo],[ApOpenInvoiceIdNo],[Sequence],[Amount],[DiscountTaken]"
DbfToSql(cFields,"CkdOiItm","CkdOiItem")

cFields = "[IdNo],[JournalCode],[JournalIdNo],[JournalItemIdNo],[PaidAmount],[DiscountTaken]"
DbfToSql(cFields,"ApOpInvo","ApOpenInvoice")


cFields = "[IdNo],[CsrIdNo],[ArOpenInvoiceIdNo],[Sequence],[Amount],[DiscountTaken]"
DbfToSql(cFields,"CsrOiItm","CsrOiItem")

cFields = "[IdNo],[JournalCode],[JournalIdNo],[JournalItemIdNo],[PaidAmount],[DiscountTaken]"
DbfToSql(cFields,"ArOpInvo","ArOpenInvoice")

cFields = "[IdNo],[Year],[AccountIdNo],[Debit],[Credit]"
DbfToSql(cFields,"ChartNBal","ChartBalance")

SET DELETED Off
CLOSE Data
Use y:\acctbackup\chart.dbf
Go Top
lnfh = Fcreate("C:\TEMP\SQL\UpdateChartBegBal.sql")
lctr = 0
nFctr = 0
Do While Not Eof()
	cByDebit = STR(Chart.ByDebit,10,2)
	cByCredit = STR(Chart.ByCredit,10,2)
	
	cText = "UPDATE Chart SET ByDebit = " + cByDebit + ", ByCredit = " + cByCredit + " WHERE idno = " + Chart.AcctCode
	Fputs(lnfh,cText)
	Skip
Enddo
Fclose(lnfh)
CLOSE ALL
Cancel


*********************************************
Function DbfToSql(cFields,dbfName,targetName)
*********************************************

Use ("C:\temp\" + dbfName)
Go Top
lnfh=Fcreate("C:\TEMP\SQL\" + targetName + ".sql")
lctr = 0
nFctr = 0
Fputs(lnfh,"DELETE " + targetName )
Fputs(lnfh,"SET IDENTITY_INSERT " + targetName + " ON" )
cFields = "INSERT " + targetName + "(" + cFields + ") VALUES ("
Do While Not Eof()
	Counter = 1
	lctr = lctr + 1
	cText = cFields
	NumFields = Fcount()
	Do While Counter <= NumFields
		Something = Eval(Field(Counter))
		If Lower(Field(Counter)) = "timestamp" Then
			cSomething = "DEFAULT"
		Else
			If Isnull(Something) Then
				cSomething = "NULL"
			Else
				If Vartype(Something) = "L" Then
					cSomething = Iif(Something,"'1'","'0'")
				Else
					If Vartype(Something) = "D" Then
						If Empty(Something) Then
							cSomething = "NULL"
						Else
							cSomething = Transform(Something)
							cSomething = "'" + cSomething + "'"
							cSomething = Strtran(cSomething ,"/","-")
						Endif
					Else
						cSomething = Trim(Transform(Something))
						cSomething = Strtran(cSomething ,"\","\\")
						cSomething = Strtran(cSomething, "'","''")
						cSomething = Strtran(cSomething, '"', '""')
						cSomething = "'" + cSomething + "'"
					Endif
				Endif
			Endif
		Endif
		cText = cText + cSomething
		If Counter = NumFields
			cText = cText + ");"
		Else
			cText = cText + ","
		Endif
		Counter = Counter +1
	Enddo
	Skip
	Fputs(lnfh,cText)
	If lctr = 10000 And Not Eof() Then
		Fclose(lnfh)
		nFctr = nFctr+1
		lnfh = Fcreate("C:\TEMP\SQL\" + targetName + Alltrim(Str(nFctr)) + ".sql")
		lctr = 0
		Fputs(lnfh,"SET IDENTITY_INSERT " + targetName + " ON" )
	Endif
Enddo
Fputs(lnfh,"SET IDENTITY_INSERT " + targetName + " OFF" )
Fclose(lnfh)
Use
Return

Endfunc






