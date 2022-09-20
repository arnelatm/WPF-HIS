
CREATE VIEW PRItemList_View
 
AS
select a.*,c.TransNo
from itemdetails a 
left outer join purchaseDetails b on a.item_code = b.Item_code and a.BranchID = b.BranchID
left outer join purchasegroup c on b.Group_Key = c.Trans_Key AND a.BranchID = c.BranchID