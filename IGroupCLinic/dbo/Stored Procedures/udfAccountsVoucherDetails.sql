CREATE PROCEDURE udfAccountsVoucherDetails
                 (
				 @LedgerID varchar(15) =null,
				 @DateFrom varchar(10) = null,
				 @DateUpto varchar(10) = null
                 )
 
AS 
DECLARE @SQLString varchar(8000)
SET @SQLString='INSERT INTO AccountsLedgerDetails
(
		Trans_Key,
		BranchID,
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
		Create_Date,
		MachineID,
		CCNameEnglish
) 
select 
		Trans_Key,
		BranchID,
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
		Create_Date,
		host_name() as MachineID,
		CCNameEnglish
from AccountsVoucher_View 
where LedgerID <> '''+@ledgerID+''' and '+
'TransNo  in (select TransNo from AccountsVoucher_View where LedgerID = '''+@LedgerID+''' AND VDate Between '''+@DateFrom +''' AND '''+@DateUpto +''') '+
'union all '+ 
' select 
		Trans_Key,
		BranchID,
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
		Create_Date,
		host_name() as MachineID,
		CCNameEnglish
from AccountsVoucher_View 
where LedgerID = '''+@ledgerID+''' and VType =''OPB'''
EXECUTE (@SQLString)
