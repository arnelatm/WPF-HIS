 
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[SetCustIDInsertIntoWithoutID]

 @CustName nvarchar(max) ,
 @CustDadName nvarchar(50) ,
 @CustMamName nvarchar(50) ,
 @CustJob nvarchar(50) ,
 @CustGender nvarchar(50) ,
 @CustNat nvarchar(50) ,
 @CustAddress nvarchar(max) ,
 @CustMobile1 nvarchar(50) ,
 @CustMobile2 nvarchar(50) ,
 @CustPhone1 nvarchar(50) ,
 @CustPhone2 nvarchar(50) ,
 @CustMail1 nvarchar(50) ,
 @CustMail2 nvarchar(50) ,
 @CustWattsUp nvarchar(50) ,
 @CustFacbook nvarchar(50) ,
 @CustBirthday date,
 @CutIDentity nvarchar(50),
 @CustMarital nvarchar(50),
 @CustFileDate datetime, 
 @CustDr int ,
 @CustSmsEnabled bit ,
 @CustResource  nvarchar(MAX),
 @CustLevelStatue nvarchar(MAX),
 @CustWebSite  nvarchar(MAX),
 @CustDrName   nvarchar(50),
 @CustAge nvarchar(50),
 @CustResourceDetals nvarchar(MAX),
 @CustComment  nvarchar(MAX),
 @CustCity nvarchar(50),
 @CustDrsName  nvarchar(MAX),
 @CustUserName nvarchar(50),
 @CustOldID  nvarchar(50), 
 @CustAppBlocked bit ,
 @CustAppBlockedNote nvarchar(MAX) 

AS
BEGIN
 
 -- SET IDENTITY_INSERT Customers on 
	INSERT INTO [Customers] ([CustName], [CustDadName], [CustMamName], [CustJob], [CustGender], [CustNat], [CustAddress], [CustMobile1], [CustMobile2], [CustPhone1], [CustPhone2], [CustMail1], [CustMail2], [CustWattsUp], [CustFacbook], [CustBirthday], [CutIDentity], [CustMarital], [CustDr], [CustLevelStatue], [CustResource], [CustSmsEnabled], [CustWebSite], [CustDrName], [CustAge], [CustResourceDetals], [CustCity], [CustComment], [CustDrsName], [CustFileDate], [CustUserName], [CustOldID], [CustAppBlocked], [CustAppBlockedNote] ) VALUES (@CustName, @CustDadName, @CustMamName, @CustJob, @CustGender, @CustNat, @CustAddress, @CustMobile1, @CustMobile2, @CustPhone1, @CustPhone2, @CustMail1, @CustMail2, @CustWattsUp, @CustFacbook, @CustBirthday, @CutIDentity, @CustMarital, @CustDr, @CustLevelStatue, @CustResource, @CustSmsEnabled, @CustWebSite, @CustDrName, @CustAge, @CustResourceDetals, @CustCity, @CustComment, @CustDrsName, @CustFileDate, @CustUserName, @CustOldID, @CustAppBlocked, @CustAppBlockedNote );
	;SELECT CAST(scope_identity() AS int)
 -- SET IDENTITY_INSERT Customers on
 
END