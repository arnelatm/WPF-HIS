
create view [dbo].[LastPurhasePrice_clinic_2018_view]
as
select * from (select a.branchid,item_code,costprice,b.TransDate,row_number() over (partition by item_code order by item_code,a.branchid,b.transdate desc) as rn
from purchasedetails a
left join purchasegroup b
on a.group_key = b.trans_key
where a.branchid='02' and b.transdate < '2019/01/01') as subquery 
where rn=1
