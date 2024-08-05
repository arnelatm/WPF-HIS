UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.ApJournalItem AS t1
  INNER JOIN dbo.ApJournal as t3
  on t1.JournalIdNo = t3.IdNo
  INNER JOIN dbo.Contact_View AS t2
  ON t3.SupplierIdNo = t2.CSEIdNo and t2.CSECode = 'S'

UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.ArJournalItem AS t1
  INNER JOIN dbo.ArJournal as t3
  on t1.JournalIdNo = t3.IdNo
  INNER JOIN dbo.Contact_View AS t2
  ON t3.CustomerIdNo = t2.CSEIdNo and t2.CSECode = 'C'

UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.ErJournalItem AS t1
  INNER JOIN dbo.ErJournal as t3
  on t1.JournalIdNo = t3.IdNo
  INNER JOIN dbo.Contact_View AS t2
  ON t3.EmployeeIdNo = t2.CSEIdNo and t2.CSECode = 'E'

UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.CdJournalItem AS t1
  INNER JOIN dbo.CdJournal as t3
  on t1.JournalIdNo = t3.IdNo
  INNER JOIN dbo.Contact_View AS t2
  ON t3.ContactIdNo = t2.IdNo 


UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.PcJournalItem AS t1
  INNER JOIN dbo.PcJournal as t3
  on t1.JournalIdNo = t3.IdNo
  INNER JOIN dbo.Contact_View AS t2
  ON t3.ContactIdNo = t2.IdNo 


UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.PcJournalItem AS t1
  INNER JOIN dbo.PcJournal as t3
  on t1.JournalIdNo = t3.IdNo
  INNER JOIN dbo.Contact_View AS t2
  ON t3.ContactIdNo = t2.IdNo 


UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.CkJournalItem AS t1
  INNER JOIN dbo.CkJournal as t3
  on t1.JournalIdNo = t3.IdNo
  INNER JOIN dbo.Contact_View AS t2
  ON t3.ContactIdNo = t2.IdNo 


UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.CashReceiptJournalItem AS t1
  INNER JOIN dbo.CashReceiptJournal as t3
  on t1.JournalIdNo = t3.IdNo
  INNER JOIN dbo.Contact_View AS t2
  ON t3.ContactIdNo = t2.IdNo 