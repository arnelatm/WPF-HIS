WITH cte AS (
    SELECT 
        Reconciliationidno, 
        journalitemidno, 
        JournalCode, 
        ROW_NUMBER() OVER (
            PARTITION BY 
				ReconciliationIdNo,
                journalitemidno, 
                JournalCode
            ORDER BY 
				ReconciliationIdNo,
                journalitemidno, 
                JournalCode
        ) row_num
     FROM 
        Reconciled where reconciliationidno>=8
)
DELETE FROM cte
WHERE row_num > 1 and reconciliationidno>=8;