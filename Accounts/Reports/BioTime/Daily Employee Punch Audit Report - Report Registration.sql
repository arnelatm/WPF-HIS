DECLARE @ReportGroupIdNo int;

SELECT @ReportGroupIdNo = IdNo
FROM dbo.ReportGroup
WHERE ReportGroupCode = 'Attendance';

IF @ReportGroupIdNo IS NULL
BEGIN
    INSERT INTO dbo.ReportGroup
        (ReportGroupCode, ReportGroupName, ReportGroupNameAra)
    VALUES
        ('Attendance', 'Attendance Reports', 'Attendance Reports');

    SET @ReportGroupIdNo = SCOPE_IDENTITY();
END;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Report
    WHERE ReportCode = 'ATT02'
)
BEGIN
    INSERT INTO dbo.Report
        (
            Active,
            BranchIdNo,
            DatabaseName,
            PrintJobIdNo,
            QueryForm,
            QueryFormParameters,
            QueryParameters,
            ReportCode,
            ReportFileName,
            ReportGroupIdNo,
            ReportName,
            ReportNameAra,
            ReportOrder,
            ReportTitle,
            ReportTitleAra
        )
    VALUES
        (
            1,
            0,
            'BIOTIME',
            0,
            NULL,
            NULL,
            NULL,
            'ATT02',
            'Daily Employee Punch Audit Report.rpt',
            @ReportGroupIdNo,
            'Daily Employee Punch Audit Report',
            'Daily Employee Punch Audit Report',
            20,
            'Daily Employee Punch Audit Report',
            'Daily Employee Punch Audit Report'
        );
END;
ELSE
BEGIN
    UPDATE dbo.Report
    SET Active = 1,
        DatabaseName = 'BIOTIME',
        QueryForm = NULL,
        QueryFormParameters = NULL,
        QueryParameters = NULL,
        ReportFileName = 'Daily Employee Punch Audit Report.rpt',
        ReportGroupIdNo = @ReportGroupIdNo,
        ReportName = 'Daily Employee Punch Audit Report',
        ReportNameAra = 'Daily Employee Punch Audit Report',
        ReportOrder = 20,
        ReportTitle = 'Daily Employee Punch Audit Report',
        ReportTitleAra = 'Daily Employee Punch Audit Report'
    WHERE ReportCode = 'ATT02';
END;
