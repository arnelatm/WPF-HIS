CREATE TABLE [dbo].[EmployeePayElement] (
    [IdNo]           INT        IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]   INT        NOT NULL,
    [PayElementIdNo] SMALLINT   NOT NULL,
    [Rate]           SMALLMONEY NULL,
    [Amount]         SMALLMONEY CONSTRAINT [DF_EmployeePayElement_Amount] DEFAULT ((0)) NULL,
    [Unit]           CHAR (1)   NOT NULL,
    [Sequence]       SMALLINT   NOT NULL,
    [DateTimeStamp]  ROWVERSION NULL,
    CONSTRAINT [PK__EmployeeElement] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

