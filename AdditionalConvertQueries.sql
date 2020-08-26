
update aropeninvoice 
set aropeninvoice.JOURNALCODE='BB' 
from aropeninvoice a
left join arjournal b
on a.journalitemidno = b.idno
where b.Referenceno='Beg.Bal.'
go
delete arjournalitem 
from arjournalitem 
left join arjournal
on arjournalitem.journalidno = arjournal.idno
where arjournal.ReferenceNo = 'Beg.Bal.' and arjournal.Notes = 'Beg. Bal.'
go

delete from arjournal where ReferenceNo = 'Beg.Bal.' and Notes = 'Beg. Bal.'
go