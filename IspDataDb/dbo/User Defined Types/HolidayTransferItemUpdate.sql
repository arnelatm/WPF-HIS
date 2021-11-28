CREATE TYPE [dbo].[HolidayTransferItemUpdate] AS TABLE (
    [EmployeeIdNo]        INT NOT NULL,
    [HolidayTransferIdNo] INT NOT NULL,
    [IDNo]                INT NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

