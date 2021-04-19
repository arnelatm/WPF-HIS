CREATE vIEW [TransactionNotes_View] AS
(
Select Distinct TransactionNotes from 
( SELECT Distinct [Notes] Collate Arabic_CI_AS  as 'TransactionNotes' FROM dbo.GeneralJournal where year(generalJournal.TransactionDate) > 2019
union 
(select Distinct GeneralJournalItem.[Notes] Collate Arabic_CI_AS from generaljournalitem
 join generaljournal on generaljournalitem.JournalIdNo = GeneralJournal.IdNo where year(generalJournal.TransactionDate) > 2019)
union 
select Distinct [Notes] Collate Arabic_CI_AS from ArJournal where year(arjournal.TransactionDate) > 2019
union
(select Distinct arjournalitem.[Notes] Collate Arabic_CI_AS from arjournalitem
 join arjournal on arjournalitem.JournalIdNo = arjournalitem.IdNo where year(arjournal.TransactionDate) > 2019)
union
select Distinct [Notes] Collate Arabic_CI_AS from apjournal where year(apjournal.TransactionDate) > 2019
union
(select Distinct apjournalitem.[Notes] Collate Arabic_CI_AS from apjournalitem
join apjournal on apjournalitem.JournalIdNo = apjournalitem.IdNo where year(apjournal.TransactionDate) > 2019)
union
select Distinct [Notes] Collate Arabic_CI_AS from cdjournal where year(cdjournal.TransactionDate) > 2019
union
(select Distinct CdJournalItem.Notes Collate Arabic_CI_AS from cdjournalitem
join cdjournal on cdjournalitem.JournalIdNo = cdjournalitem.IdNo where year(cdjournal.TransactionDate) > 2019)
union
select Distinct [Notes] Collate Arabic_CI_AS from erjournal where year(erjournal.TransactionDate) > 2019
union
(select Distinct erjournalitem.[Notes] Collate Arabic_CI_AS from erjournalitem
join erjournal on erjournalitem.JournalIdNo = erjournalitem.IdNo where year(erjournal.TransactionDate) > 2019)
union
select Distinct [Notes] Collate Arabic_CI_AS from cashReceiptJournal where year(cashreceiptjournal.TransactionDate) > 2019
union
(select Distinct cashreceiptjournalitem.[Notes] Collate Arabic_CI_AS from cashreceiptjournalitem
join cashreceiptjournal on CashReceiptJournalitem.JournalIdNo = cashreceiptjournal.IdNo where year(cashreceiptjournal.TransactionDate) > 2019)
) as TransactionNotes WHERE TransactionNotes LIKE '%[a-Z]%'
)