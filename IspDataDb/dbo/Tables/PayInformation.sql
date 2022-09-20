CREATE TABLE [dbo].[PayInformation] (
    [IdNo]             INT      IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]     INT      NULL,
    [FrequencyOfPay]   CHAR (1) NULL,
    [SalariedOrHourly] CHAR (1) NULL,
    [Rate]             MONEY    NULL,
    CONSTRAINT [PK_PayInformation] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);







