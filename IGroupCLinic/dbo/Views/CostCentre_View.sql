
CREATE VIEW CostCentre_View
 
AS
 select 
	 a.* ,
	 b.LedgerNameEnglish as SalesLedger,
	 c.LedgerNameEnglish as CostOfGodsLedger,
	 d.LedgerNameEnglish as InventoryLedger,
	 e.DepartmentNameEnglish as Department,
	 f.GroupNameEnglish as GroupDepartment
 from CostCentre a
 left outer join AccountsLedger b on a.AcSalesLedgerID = b.LedgerID 
 left outer join AccountsLedger c on a.AcCOGSLedgerID  = c.LedgerID 
 left outer join AccountsLedger d on a.AcInventoryLedgerID  = d.LedgerID 
 left outer join MedicalDepartments  e on a.AcDepartmentID  = e.DepartmentID  
 left outer join MedicalDepartmentGroups  f on f.DepartmentGroupID  = e.DepartmentGroupID  
