
-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[custom_att_GetDailyPunches]
    @Date      DATE,
    @EmpID     INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        t.emp_id,
        e.emp_code,
        e.first_name,
        t.punch_time,
        t.punch_state,
        CASE 
            WHEN t.punch_state = 0 THEN 'IN'
            WHEN t.punch_state = 1 THEN 'OUT'
            ELSE 'UNKNOWN'
        END AS punch_type
    FROM dbo.iclock_transaction t
    LEFT JOIN dbo.personnel_employee e 
        ON t.emp_id = e.id
    WHERE t.punch_time >= @Date
      AND t.punch_time < DATEADD(DAY, 2, @Date)
      AND (@EmpID IS NULL OR t.emp_id = @EmpID)
    ORDER BY
        t.emp_id,
        t.punch_time;
END;
