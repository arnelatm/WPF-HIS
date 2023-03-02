Select a.Transnbr,a.TransDateEnglish,a.DiscountAmt,b.group_key,b.itemTotal from IBInvoiceGroup a
left join (SELECT group_key, SUM(discamt) as itemTotal FROM ibinvoicedetails GROUP BY group_key) as b
on b.Group_Key = a.Trans_Key
where a.DiscountAmt <> b.itemTotal