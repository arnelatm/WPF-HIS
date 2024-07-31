UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.PcJournal AS t1
  INNER JOIN dbo.Contact_View AS t2
  ON t1.PayeeIdNo = t2.CSEIdNo 
  where t1.PaymentType = 'A' and T2.CSECode = 'S'

UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.PcJournal AS t1
  INNER JOIN dbo.Contact_View AS t2
  ON t1.PayeeIdNo = t2.CSEIdNo 
  where t1.PaymentType = 'S' and T2.CSECode = 'S'

UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.PcJournal AS t1
  INNER JOIN dbo.Contact_View AS t2
  ON t1.PayeeIdNo = t2.CSEIdNo 
  where t1.PaymentType = 'E' and T2.CSECode = 'E'

UPDATE t1
  SET t1.ContactIdNo = t2.IdNo
  FROM dbo.PcJournal AS t1
  INNER JOIN dbo.Contact_View AS t2
  ON t1.PayeeIdNo = t2.CSEIdNo 
  where t1.PaymentType = 'R' and T2.CSECode = 'C'
