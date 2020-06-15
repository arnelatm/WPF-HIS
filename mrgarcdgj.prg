Close All Database
*USE y:\accounts\aptrans.dbf exclusive
Set Deleted On
Set Exclusive On
Set Safety Off
Set Collate To "MACHINE"

Select 1
Use c:\temp\customer.Dbf Exclusive Alias customer
Index On CustCode Tag CustCode
Select 2
Use Y:\acctbackup\artrans.Dbf Index Y:\acctbackup\artrans.Cdx Exclusive Alias artrans
Set Order To ARTHTRNO   && TRANNO
Select 3
Use Y:\acctbackup\JOURITEM.Dbf Index Y:\acctbackup\JOURITEM.Cdx Exclusive Alias JOURITEM
Set Order To JRITJCTN   && JOURCODE+TRANNO
Go Top

Select 4
Use c:\temp\ArJournal.Dbf  Exclusive Alias ArJournal
Set Order To
Select 5
Use c:\temp\ArJourItm Exclusive Alias ArJourItm
Go Bottom
nCtrItm = ArJourItm.IdNo
Select 6
Use c:\temp\CdJournal.Dbf
Select 7
Use c:\temp\CkJournal.Dbf
Select 8
Use c:\temp\CdJourItm.Dbf
Go Bottom
cdCtr = CdJourItm.IdNo
Select 9
Use c:\temp\CkJourItm.Dbf
ckCtr = CkJourItm.IdNo
Select 10
Use c:\temp\GnJournal.Dbf ALIAS GnJournal
Index On Trim(Reference) + Dtos(Transdate) Tag cRfGJSel
SELECT 11
Use c:\temp\GnJourItm.Dbf ALIAS GnJourItm
Index On jouridno Tag gjiJIdNo
Select artrans
Go Top
Do While Not Eof()
	cCustCode = artrans.CustCode
	dDate = artrans.Date
	cTranno = artrans.TRANNO
	cReference = Trim(artrans.Reference)
	lCashFound = .F.
	Select customer
	Seek cCustCode
	If Not Eof()
		nIdNo = customer.IdNo
	Else
		nIdNo = 0
	ENDIF
	IF VAL(arTrans.Tranno) = 7535
		SET STEP ON 
	endif
	If artrans.CustCode="E" Then
		Select JOURITEM
		Seek "AR"+cTranno
*   	see if debit = credit
		nDebit = 0
		nCredit = 0
		seq = 0
		Do While TRANNO = cTranno And JourCode="AR" And Not Eof()
			nDebit = nDebit + JOURITEM.Debit
			nCredit = nCredit + JOURITEM.Credit
			Skip
		Enddo
		If nDebit = nCredit
*			find cash account
			Seek "AR"+cTranno
			Do While TRANNO = cTranno And JourCode="AR" And Not Eof()
				If JOURITEM.AcctCode = "106" Or JOURITEM.AcctCode = "107" Then
					cAcctCode = JOURITEM.AcctCode
					niDebit = JOURITEM.Debit
					niCredit = JOURITEM.Credit
					ciNotes = JOURITEM.Descript
					cPosted = Iif(JOURITEM.Posted="P",.T.,.F.)
					If JOURITEM.DEPTCODE = "S" Then
						ciProfIdNo = 1000 + Val(Substr(JOURITEM.DEPTCODE,2))
					Else
						ciProfIdNo = Val(JOURITEM.DEPTCODE)
					Endif
					lCashFound = .T.
					Exit
				Endif
				Skip
			Enddo
			SEQ = SEQ + 1
			Select CdJourItm
			Append Blank
			cdCtr = cdCtr + 1
			Replace CdJourItm.IdNo With cdCtr
			Replace CdJourItm.Sequence With SEQ
			Replace CdJourItm.jouridno With Val(cTranno)
			Replace CdJourItm.AcctIdNo With Val(cAcctCode)
			Replace CdJourItm.Debit With niDebit
			Replace CdJourItm.Credit With niCredit
			Replace CdJourItm.ProfIdNo With ciProfIdNo
			Replace CdJourItm.Notes With ciNotes
			Replace CdJourItm.Posted With cPosted
			SELECT JourItem
			Seek "AR"+cTranno
*!*				IF VAL(cTranno) = 7485
*!*					SET STEP ON 
*!*				endif
			niSw = 0
			Do While TRANNO = cTranno And JourCode="AR" And Not Eof()
				If niSw = 0 And (JOURITEM.AcctCode = "106" Or JOURITEM.AcctCode = "107") Then
					niSw = 1
				ELSE
					SELECT CdJourItm
					SEQ = SEQ + 1
					Append Blank
					cdCtr = cdCtr + 1
					Replace CdJourItm.IdNo With cdCtr
					Replace CdJourItm.Sequence With SEQ
					Replace CdJourItm.jouridno With Val(JOURITEM.TRANNO)
					Replace CdJourItm.AcctIdNo With Val(JOURITEM.AcctCode)
					Replace CdJourItm.Debit With JOURITEM.Debit
					Replace CdJourItm.Credit With JOURITEM.Credit
					If JOURITEM.DEPTCODE = "S" Then
						Replace CdJourItm.ProfIdNo With 1000 + Val(Substr(JOURITEM.DEPTCODE,2))
					Else
						Replace CdJourItm.ProfIdNo With Val(JOURITEM.DEPTCODE)
					Endif
					Replace CdJourItm.Notes With JOURITEM.Descript
					Replace CdJourItm.Posted With Iif(JOURITEM.Posted="P",.T.,.F.)
				ENDIF
				SELECT JourItem
				Skip
			ENDDO
			IF niSw = 0 then
				SET STEP ON 
			endif
		Else
*	        find other part
*		    start with the General Journal
			Select GnJournal
			Seek cReference+Left(Dtos(dDate),6)
			If Not Eof()
				gDebit = 0
				gCredit = 0
				Do While GnJournal.Reference = cReference And Year(GnJournal.TransDate)=Year(dDate) And Month(GnJournal.TransDate)=Month(dDate) And Not Eof()
					gIdNo = GnJournal.IdNo
					Select GnJourItm
					Seek gIdNo
					Do While GnJourItm.IdNo = gIdNo And Not Eof()
						gDebit = gDebit + GnJourItm.Debit
						gCredit = gCredit + GnJourItm.Credit
						Skip
					Enddo
					Select GnJournal
					Skip
				Enddo
				If gDebit+nDebit = gCredit + nCredit
*				   * find cash account
					If lCashFound
						Select GnJournal
						Seek cReference+Left(Dtos(dDate),6)
						Do While GnJournal.TRANNO = cTranno And Year(GnJournal.Date)=Year(dDate) And Month(GnJournal.Date)=Month(dDate) And Not Eof("GnJournal")
							gIdNo = GnJournal.IdNo
							Select GnJourItm
							Seek gIdNo
							Do While GnJourItm.IdNo = gIdNo And Not Eof()
								If GnJourItm.AcctCode = 106 Or GnJourItm.AcctCode = 107 Then
									cAcctCode = JOURITEM.AcctCode
									niDebit = JOURITEM.Debit
									niCredit = JOURITEM.Credit
									ciNotes = JOURITEM.Descript
									cPosted = Iif(JOURITEM.Posted="P",.T.,.F.)
									If JOURITEM.DEPTCODE = "S" Then
										Replace ciProfIdNo With 1000 + Val(Substr(JOURITEM.DEPTCODE,2))
									Else
										Replace ciProfIdNo With Val(JOURITEM.DEPTCODE)
									ENDIF
									lCashFound = .t.
									Exit
								Endif
								Skip
							Enddo
						Enddo
					Endif
					IF not lCashFound
						SET STEP ON
					endif
					SEQ = SEQ + 1
					Select CdJourItm
					Append Blank
					cdCtr = cdCtr + 1
					Replace CdJourItm.IdNo With cdCtr
					Replace CdJourItm.Sequence With SEQ
					Replace CdJourItm.jouridno With Val(cTranno)
					Replace CdJourItm.AcctIdNo With Val(cAcctCode)
					Replace CdJourItm.Debit With niDebit
					Replace CdJourItm.Credit With niCredit
					Replace CdJourItm.ProfIdNo With ciProfIdNo
					Replace CdJourItm.Notes With ciNotes
					Replace CdJourItm.Posted With cPosted
					SELECT GnJournal
					niSw = 0
					Do While GnJournal.TRANNO = cTranno And Year(GnJournal.Date)=Year(dDate) And Month(GnJournal.Date)=Month(dDate) And Not Eof("GnJournal")
						gIdNo = GnJournal.IdNo
						Select GnJourItm
						Seek gIdNo
						If niSw = 0 And (JOURITEM.AcctCode = "106" Or JOURITEM.AcctCode = "107") Then
							niSw = 1
						Else
							SEQ = SEQ + 1
							Append Blank
							cdCtr = cdCtr + 1
							Replace CdJourItm.IdNo With cdCtr
							Replace CdJourItm.Sequence With SEQ
							Replace CdJourItm.jouridno With Val(JOURITEM.TRANNO)
							Replace CdJourItm.AcctIdNo With Val(JOURITEM.AcctCode)
							Replace CdJourItm.Debit With JOURITEM.Debit
							Replace CdJourItm.Credit With JOURITEM.Credit
							If JOURITEM.DEPTCODE = "S" Then
								Replace CdJourItm.ProfIdNo With 1000 + Val(Substr(JOURITEM.DEPTCODE,2))
							Else
								Replace CdJourItm.ProfIdNo With Val(JOURITEM.DEPTCODE)
							Endif
							Replace CdJourItm.Notes With JOURITEM.Descript
							Replace CdJourItm.Posted With Iif(JOURITEM.Posted="P",.T.,.F.)
						Endif
						Skip
					ENDDO
					IF niSw = 0
						SET STEP ON 
					endif
					Skip
				Endif
			Endif
		Endif
	Endif
	Select artrans
	Skip
Enddo
Close Databases
