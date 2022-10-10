CREATE TABLE [dbo].[EmployeeIdPrinting] (
    [IdNo]              INT IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]      INT NULL,
    [TransactionNumber] INT NULL,
    CONSTRAINT [PK_EmployeeIdPrinting] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

