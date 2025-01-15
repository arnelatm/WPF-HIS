CREATE TABLE [dbo].[A1_SalaryCommission] (
    [ID]         INT             IDENTITY (1, 1) NOT NULL,
    [SalaryID]   INT             NULL,
    [Income]     DECIMAL (18, 2) NULL,
    [Amount]     DECIMAL (18, 2) NULL,
    [Commission] DECIMAL (18, 2) NULL,
    [Type]       INT             NULL,
    CONSTRAINT [PK_A1_SalaryCommission] PRIMARY KEY CLUSTERED ([ID] ASC)
);

