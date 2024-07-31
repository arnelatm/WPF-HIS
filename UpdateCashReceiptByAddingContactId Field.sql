UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.CashReceiptJournal AS t1
  INNER JOIN dbo.Contact_View AS t2
  ON t1.PayorIdNo = t2.CSEIdNo 
  where t1.PayorType = 'A' and T2.CSECode = 'C'

UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.CashReceiptJournal AS t1
  INNER JOIN dbo.Contact_View AS t2
  ON t1.PayorIdNo = t2.CSEIdNo 
  where t1.PayorType = 'R' and T2.CSECode = 'S'

UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.CashReceiptJournal AS t1
  INNER JOIN dbo.Contact_View AS t2
  ON t1.PayorIdNo = t2.CSEIdNo 
  where t1.PayorType = 'E' and T2.CSECode = 'E'

UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.CashReceiptJournal AS t1
  INNER JOIN dbo.Contact_View AS t2
  ON t1.PayorIdNo = t2.CSEIdNo 
  where t1.PayorType = 'C' and T2.CSECode = 'C'