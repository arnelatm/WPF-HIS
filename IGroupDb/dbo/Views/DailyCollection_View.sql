
CREATE VIEW DailyCollection_View
 
AS
SELECT 
		a.TRANS_KEY,
		a.CollectionType,
		a.Apply, 
		a.BRANCHID,
		a.TRANSSERIES,
		a.TRANSNO,
		a.TRANSDATE,
		a.DEBITAMT,
		b.SLNO,
		b.ACCODE,
		b.ACNAMEENGLISH,
		b.SALESCODE,
		b.COSTOFGOODSCODE,
		b.InventoryCode ,
		b.GROSSAMT,
		b.COSTAMT,
		b.DISCOUNTAMT,
		b.DEDUCTIBLEAMT,
		b.NETAMT,
		c.BranchNameEnglish,
		c.Address1,
		c.Address2,
		c.Street,
		c.City
FROM AccountsDailyCollectionGroup A
LEFT OUTER JOIN AccountsDailyCollectionDetails B ON a.Trans_Key = b.Group_Key
LEFT OUTER JOIN BranchDetails C ON a.BranchID = c.BranchID