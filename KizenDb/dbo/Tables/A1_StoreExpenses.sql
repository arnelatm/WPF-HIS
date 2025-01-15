CREATE TABLE [dbo].[A1_StoreExpenses] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [Store]            INT            NULL,
    [EmpID]            INT            NULL,
    [UserID]           INT            NULL,
    [UserName]         NVARCHAR (MAX) NULL,
    [UserIDLastEdit]   INT            NULL,
    [UserNameLastEdit] NVARCHAR (MAX) NULL,
    [Cause]            NVARCHAR (MAX) NULL,
    [DateTime]         DATETIME       NULL,
    [DateTimeLastEdit] DATETIME       NULL,
    CONSTRAINT [PK_A1_StoreExpenses] PRIMARY KEY CLUSTERED ([ID] ASC)
);

