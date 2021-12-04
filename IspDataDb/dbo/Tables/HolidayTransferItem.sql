CREATE TABLE [dbo].[HolidayTransferItem] (
    [IdNo]                INT IDENTITY (1, 1) NOT NULL,
    [HolidayTransferIdNo] INT NULL,
    [EmployeeIdNo]        INT NULL,
    CONSTRAINT [PK_HolidayTransferItem] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [ucHTIdNoEmpIdNo] UNIQUE NONCLUSTERED ([HolidayTransferIdNo] ASC, [EmployeeIdNo] ASC)
);



