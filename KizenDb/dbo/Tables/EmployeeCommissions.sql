CREATE TABLE [dbo].[EmployeeCommissions] (
    [ID]     INT             IDENTITY (1, 1) NOT NULL,
    [EmpID]  INT             NULL,
    [Income] DECIMAL (18, 2) NULL,
    [Amount] DECIMAL (18, 2) NULL,
    [Type]   INT             NULL,
    CONSTRAINT [PK_Employee_Commissions] PRIMARY KEY CLUSTERED ([ID] ASC)
);

