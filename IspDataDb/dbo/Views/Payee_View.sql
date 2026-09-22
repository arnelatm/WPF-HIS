





CREATE VIEW [dbo].[Payee_View]
AS
SELECT contact.IdNo,
       contact.CSECode AS PayeeType,
       contact.IdNo AS PayeeIdNo,
       contact.ContactCode AS PayeeCode,
       contact.ContactName AS PayeeName,
       contact.ContactNameAra AS PayeeNameAra
FROM dbo.Contact_View AS contact
