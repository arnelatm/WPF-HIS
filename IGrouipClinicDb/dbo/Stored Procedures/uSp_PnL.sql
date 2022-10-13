CREATE 	PROCEDURE uSp_PnL
        ( 
          @DateFrom as varchar(10),
          @DateUpto as varchar(10),
          @YearCode as varchar(4) ,
   	      @BrCode   as varchar(02)
        )
 
AS 
if exists (select * from sysobjects where id=object_id(N'AccPnLTemp') and OBJECTPROPERTY(id,N'IsUserTable')=1) drop table 	AccPnLTemp
DECLARE @SQLString varchar(8000)
DECLARE @Cond as varchar(20)
SET @Cond = CASE @BrCode
		       WHEN '99' THEN 
		                 ' 1=1'
				 ELSE
				 'a.BRANCHID = '+@BrCode 
                       END
SET @SQLString =
'select a.branchID,
       a.LedgerID,
       "" AS LedgerNature,
       "'+@YearCode +'" as year_code,
       "" as period_code,
       0 as op_bal,
       0 as budget,
       a.LedgerNameEnglish,
       a.LedgerNameArabic,
       a.parentID,
       b.GroupNameEnglish as parent_name,
       Case when A.LedgerID Like "4%" then "I" else "E" end as ac_type,
       SUM(a.DrAmt) as debit,
       SUM(a.CrAmt) as credit
into AccPnLTemp 
from AccountsVoucher_View a left outer join AccountsGroup b on a.parentID = b.GroupID 
where a.vdate between "' + @DateFrom +'" and "'+ @DateUpto +'" and (a.LedgerID Like "4%" or a.LedgerID Like "5%")  and ' + @cond + ' 
group by a.branchID,
		 a.LedgerID,
		 a.LedgerNameEnglish,
		 a.LedgerNameArabic,
         a.parentID,
         b.GroupNameEnglish '
EXECUTE (@SQLString)