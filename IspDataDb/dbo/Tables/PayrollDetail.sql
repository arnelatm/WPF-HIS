CREATE TABLE [dbo].[PayrollDetail] (
    [IdNo]          INT        IDENTITY (1, 1) NOT NULL,
    [PayrollIdNo]   TINYINT    NULL,
    [EmployeeIdNo]  INT        NULL,
    [DateTimeStamp] ROWVERSION NULL,
    CONSTRAINT [PK_PayrollDetail] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



