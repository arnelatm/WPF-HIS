CREATE TABLE [dbo].[EmployeeDeduction] (
    [Id]            INT        IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]  INT        NULL,
    [DeductionIdNo] SMALLINT   NULL,
    [AccountIdNo]   INT        NULL,
    [Amount]        SMALLMONEY NULL,
    [EndAmount]     SMALLMONEY NULL,
    [PayFrequency]  CHAR (1)   NOT NULL,
    [StartDate]     DATE       NOT NULL,
    [EndDate]       DATE       NULL,
    CONSTRAINT [PK_EmployeeDeduction] PRIMARY KEY CLUSTERED ([Id] ASC)
);



