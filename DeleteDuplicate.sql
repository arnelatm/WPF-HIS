    SELECT 
      [JournalCode],
      [JournalItemIdNo],
      [ReconciliationIdNo],
      ROW_NUMBER() OVER (
            PARTITION BY 
				 [JournalCode],
				 [JournalItemIdNo],
				 [ReconciliationIdNo]
            ORDER BY 
			   [JournalCode],
			   [JournalItemIdNo],
			   [ReconciliationIdNo]
        ) row_num
     FROM 
        dbo.Reconciled