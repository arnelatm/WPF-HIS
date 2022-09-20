* delete
UPDATE clinicinvoicegroup SET REJECT=2 where ((insuranceid = '1551' or insuranceId = '1559') and reject = 0 and transdateenglish > '2022/06/30' and transdateenglish < '2022/10/01' AND transtype='CR')
update ibinvoicegroup set rejected = 2 where ((companyid = 1551 or companyid = 1559) and rejected = 0 and transtype = 'Credit' and transdateenglish > '2022/06/30' and transdateenglish < '2022/10/01') 
* restore
UPDATE clinicinvoicegroup SET REJECT=2 where ((insuranceid = '1551' or insuranceId = '1559') and reject = 0 and transdateenglish > '2022/06/30' and transdateenglish < '2022/10/01' AND transtype='CR')
update ibinvoicegroup set rejected = 2 where ((companyid = 1551 or companyid = 1559) and rejected = 0 and transtype = 'Credit' and transdateenglish > '2022/06/30' and transdateenglish < '2022/10/01') 