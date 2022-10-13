
CREATE VIEW SalesSummary_View
 
AS
SELECT 
	TransNBR,
	TransType,
	TransDateEnglish,
	sum(Qty*SalePrice) as Gross,
	sum(BillAmt) as BillAmt,
	sum(Qty*CostPrice) as Cost 
FROM PharmacySales_View 
--Where TransDateEnglish BETWEEN '2013/06/01' AND '2013/06/31'
Group By TransNBR,TransType,TransDateEnglish