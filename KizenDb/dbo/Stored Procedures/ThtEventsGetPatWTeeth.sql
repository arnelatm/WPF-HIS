/****** Object:  StoredProcedure [dbo].[ThtEventsGetPatWTeeth]    Script Date: 02/10/2015 10:51:33 PM ******/
 
-- =============================================
CREATE PROCEDURE [dbo].[ThtEventsGetPatWTeeth]
	-- Add the parameters for the stored procedure here
	@PatId as int 
	 
AS
BEGIN
	 


DECLARE @Names nvarchar(max) 
SELECT @Names =  COALESCe(@Names + ', ',  '') +  ISNULL(a.TthCode, '') FROM ThtEvents as a where a.PatId = @PatId 
SELECT @Names 

END