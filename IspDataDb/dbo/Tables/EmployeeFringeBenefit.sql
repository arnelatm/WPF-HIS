CREATE TABLE [dbo].[EmployeeEarning] (
    [Id]                INT        IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]      INT        NULL,
    [EarningIdNo] SMALLINT   NULL,
    [AccountIdNo]       INT        NULL,
    [Amount]            SMALLMONEY CONSTRAINT [DF__EmployeeF__Amoun__3FFB60B2] DEFAULT ((0)) NULL,
    [PayFrequency]      CHAR (1)   NOT NULL,
    CONSTRAINT [PK__Employee__3214EC075B264C4C] PRIMARY KEY CLUSTERED ([Id] ASC)
);



