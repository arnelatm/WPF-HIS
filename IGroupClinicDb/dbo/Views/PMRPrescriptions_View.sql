
CREATE VIEW [dbo].[PMRPrescriptions_View]
as 
SELECT Distinct [PmrDate], [FileNo], [FileType], [PatientName], [Status], [TokenNo], [PType], [LastConsDate], [Trans_Key], [InvTime], DoctorId from PmrDoctorsGenForm_View 
where not (trans_key is Null and tokenno = 0)