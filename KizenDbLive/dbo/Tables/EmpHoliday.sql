CREATE TABLE [dbo].[EmpHoliday] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [EmpID]           INT            NULL,
    [EmpName]         NVARCHAR (50)  NULL,
    [StartDate]       DATE           NULL,
    [EndDate]         DATE           NULL,
    [IsOustCity]      BIT            NULL,
    [EmpVisaKizenNum] INT            NULL,
    [BackToCityDate]  DATE           NULL,
    [Type]            NVARCHAR (50)  NULL,
    [CountFromSalary] BIT            NULL,
    [UserName]        NVARCHAR (50)  NULL,
    [Date]            DATE           NULL,
    [Time]            TIME (0)       NULL,
    [Note]            NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_EmpHoliday] PRIMARY KEY CLUSTERED ([ID] ASC)
);

