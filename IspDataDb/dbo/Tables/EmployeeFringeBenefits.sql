CREATE TABLE [dbo].[EmployeeFringeBenefits]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FringeBenefitIdNo] SMALLINT NULL, 
    [AccountIdNo] INT NULL, 
    [Amount] SMALLMONEY NULL DEFAULT 0, 
    [PayFrequency] CHAR NOT NULL
)
