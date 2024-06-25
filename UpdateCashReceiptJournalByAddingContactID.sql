UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.CashReceiptJournal AS t1
  INNER JOIN dbo.Contact_View AS t2
  ON t1.PayorIdNo = t2.PayeeIdNo 
  where t1.PayorType = 'A' and T2.PayeeType = 'C'

UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.CashReceiptJournal AS t1
  INNER JOIN dbo.Contact_View AS t2
  ON t1.PayorIdNo = t2.PayeeIdNo 
  where t1.PayorType = 'R' and T2.PayeeType = 'S'

UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.CashReceiptJournal AS t1
  INNER JOIN dbo.Contact_View AS t2
  ON t1.PayorIdNo = t2.PayeeIdNo 
  where t1.PayorType = 'E' and T2.PayeeType = 'E'

