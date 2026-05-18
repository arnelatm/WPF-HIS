CREATE TABLE [dbo].[payroll_deductionformula] (
    [id]      INT            IDENTITY (1, 1) NOT NULL,
    [name]    NVARCHAR (30)  NOT NULL,
    [formula] NVARCHAR (100) NOT NULL,
    [remark]  NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([name] ASC)
);

