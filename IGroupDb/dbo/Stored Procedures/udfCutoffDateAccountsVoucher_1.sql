CREATE 	PROCEDURE udfCutoffDateAccountsVoucher 
        ( 
		  @BranchID as varchar(15) ,
		  @DateFrom as varchar(10), 	
		  @LedgerID as varchar(15),
		  @FinYear as varchar(4) 
        )
 
AS 
delete AccountsCutOffDateOPB --where MachineID = HOST_NAME()
DECLARE @SQLString varchar(8000)
SET @SQLString='INSERT INTO AccountsCutOffDateOPB
(
	Trans_Key,
	BranchID ,
	FinYear,
	TransNo,
	VDate,
	VType,
	RefType,
	RefNo,
	CostCentreID,
	SlNo,
	DrCr,
	LedgerID,
	LedgerNameEnglish,
	LedgerNameArabic,
	ParentID,
	GroupNameEnglish,
	GroupNameArabic,
	DrAmt,
	CrAmt,
	EntryDescription,
	VDescription,
	UserID,
	Create_date,
	MachineID,
	CCNameEnglish,
	Status 
) 
select 
	1 as Trans_Key,
	"'+@branchid+'" as BranchID,
	"'+@finyear+'" as FinYear,
	0 as TransNo,
	"'+@datefrom +'" as VDate,
	"OPB" as VType,
	"" as RefType,
	0 as RefNo,
	"" as CostCentreID,
	1 as SlNo,
	case when sum(dramt) - sum(cramt) > 0 then "D" else "C" end as DrCr,
	LedgerID,
	LedgerNameEnglish,
	LedgerNameArabic,
	ParentID,
	GroupNameEnglish,
	GroupNameArabic,
	case when (sum(dramt) - sum(cramt)) > 0 then sum(dramt) - sum(cramt) else 0 end as DrAmt,
	case when (sum(cramt) - sum(dramt)) > 0 then sum(cramt) - sum(dramt) else 0 end as CrAmt,
	"" as EntryDescription,
	"Opening Balance" as VDescription,
	"" as UserID,
	getdate() as Create_date,
	host_name() as MachineID,
	"" as CCNameEnglish,
	1 as Status 
From AccountsVoucher_View
where LedgerID = "'+@LedgerID +'" and VDate < "'+@Datefrom  + '" AND Status = 1  
AND FinYear = "'+@FinYear +'" AND BranchID = "'+@BranchID+'" 
 Group by
	LedgerID,
	LedgerNameEnglish,
	LedgerNameArabic,
	ParentID,
	GroupNameEnglish,
	GroupNameArabic'
EXECUTE (@SQLString)