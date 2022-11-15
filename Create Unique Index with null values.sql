CREATE UNIQUE NONCLUSTERED INDEX idx_yourcolumn_notnull
ON YourTable(yourcolumn)
WHERE yourcolumn IS NOT NULL;