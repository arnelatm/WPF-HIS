CREATE TABLE [dbo].[EmployeeDocument] (
    [IdNo]           INT             IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]   INT             NULL,
    [Sequence]       SMALLINT        NULL,
    [DocumentIdNo]   SMALLINT        NULL,
    [DocumentImage]  Int             NULL, 
    [DocumentNumber] VARCHAR (30)    NULL,
    [IssueDate]      DATE            NULL,
    [ExpiryDate]     DATE            NULL
    CONSTRAINT [PK_EmployeeDocument] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



