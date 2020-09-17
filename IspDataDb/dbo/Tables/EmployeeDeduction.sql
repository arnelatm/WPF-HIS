CREATE TABLE [dbo].[EmployeeDeduction] (
    [Id]            INT        IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]  SMALLINT   NOT NULL,
    [DeductionIdNo] SMALLINT   NOT NULL,
    [Amount]        SMALLMONEY NULL,
    [Sequence]      SMALLINT   NOT NULL,
    [DateTimeStamp] ROWVERSION NULL,
    CONSTRAINT [PK_EmployeeDeduction] PRIMARY KEY CLUSTERED ([Id] ASC)
);







