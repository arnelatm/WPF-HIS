-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[spGetUntransferredHolidays] 
	-- Add the parameters for the stored procedure here
	@holidayIdNo int = 0 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	-- Add the SELECT statement with parameter references here
	select e.idno from employee e
	where e.idNo not In
	(SELECT a.EmployeeIdnO FROM holidaytransferitem a
	LEFT JOIN holidaytransfer b
	on a.HolidayTransferIdNo = b.IdNo
	where b.HolidayIdNo=@HolidayIdNo)  and e.Active = 1
	order by e.EmployeeName
END