CREATE 	PROCEDURE uSpAccountsTB 
        ( 
          @DateFrom as varchar(10),
          @DateUpto as varchar(10),
          @YearCode as varchar(4) 
        )
 
AS 
if exists (select * from sysobjects where id=object_id(N'AccTrialBalance') and OBJECTPROPERTY(id,N'IsUserTable')=1) drop table 	AccTrialBalance

DECLARE @SQLString varchar(8000)
SET @SQLString =
'select "02" as br_code,
       "'+@DateFrom +'" as vou_date, 
       LedgerID as ac_code,
       LedgerNameEnglish as name_e,
       "" as name_a,
       "" as ac_or_group,
       4 as level_no,
       ParentID as parent_code,
       GroupNameEnglish as parent_name,
       "" as acc_type,
       0 as op_debit,
       0 as op_credit,
       0 AS OP_BALANCE,
       SUM(dramt) as debit,
       SUM(cramt) as credit,
       SUM(Dramt) - SUM(CRamt) AS BALANCE
into AccTrialBalance ' +
' From AccountsTB_View Where vdate Between "' + @DateFrom +'" AND "'+ @DateUpto + '" '+
'Group By LedgerID,LedgerNameEnglish,ParentID,GroupNameEnglish' 
EXECUTE (@SQLString)
