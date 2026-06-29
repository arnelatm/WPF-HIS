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
    WHERE ReportCode = 'ATT01'
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
            'DateRangeForm',
            'M,CM,CME',
            NULL,
            'ATT01',
            'Periodic Attendance Report.rpt',
            @ReportGroupIdNo,
            'Periodic Attendance Report',
            'Periodic Attendance Report',
            10,
            'Periodic Attendance Report',
            'Periodic Attendance Report'
        );
END;
ELSE
BEGIN
    UPDATE dbo.Report
    SET Active = 1,
        DatabaseName = 'BIOTIME',
        QueryForm = 'DateRangeForm',
        QueryFormParameters = 'M,CM,CME',
        ReportFileName = 'Periodic Attendance Report.rpt',
        ReportGroupIdNo = @ReportGroupIdNo,
        ReportName = 'Periodic Attendance Report',
        ReportTitle = 'Periodic Attendance Report'
    WHERE ReportCode = 'ATT01';
END;
