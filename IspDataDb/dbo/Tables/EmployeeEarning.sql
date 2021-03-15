CREATE TABLE [dbo].[EmployeeEarning] (
    [IdNo]          INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]  INT           NOT NULL,
    [EarningIdNo]   SMALLINT      NOT NULL,
    [Rate]          SMALLMONEY    NULL,
    [Unit]          CHAR(1)       NOT NULL,
    [Amount]        SMALLMONEY    CONSTRAINT [DF__EmployeeF__Amoun__3FFB60B2] DEFAULT ((0)) NULL,
    [Sequence]      SMALLINT      NOT NULL,
    [DateTimeStamp] ROWVERSION    NULL,
    CONSTRAINT [PK__Employee__3214EC075B264C4C] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);









