
CREATE VIEW [dbo].[IBInvoiceVatAmt_View]
  AS (SELECT group_key,SUM(isnull(vatamt,0)) as 'TotVatAmt'
      fROM  ibinvoicedetails
      GROUP BY  group_key)
