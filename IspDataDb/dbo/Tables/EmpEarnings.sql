CREATE TABLE [dbo].[EmpEarnings] (
    [IdNo]         INT             IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo] SMALLINT        NOT NULL,
    [Basic]        NUMERIC (10, 2) NOT NULL,
    [HRA]          NUMERIC (10, 2) NULL,
    [Food]         NUMERIC (10, 2) NULL,
    [Transport]    NUMERIC (10, 2) NULL,
    [OTRate]       NUMERIC (10, 2) NULL,
    [Others]       NUMERIC (10, 2) NULL,
    [PaymentMode]  VARCHAR (20)    NULL,
    [BankName]     VARCHAR (50)    NULL,
    [IBAN]         VARCHAR (20)    NULL
);

