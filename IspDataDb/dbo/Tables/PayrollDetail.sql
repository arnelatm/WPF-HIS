CREATE TABLE [dbo].[PayrollDetail] (
    [IdNo]          INT        IDENTITY (1, 1) NOT NULL,
    [PayrollIdNo]   SMALLINT   NULL,
    [EmployeeIdNo]  INT        NULL,
    [BankTransfer]  BIT        NULL,
    [DateTimeStamp] ROWVERSION NULL,
    CONSTRAINT [PK_PayrollDetail] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);







