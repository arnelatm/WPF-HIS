CREATE TABLE [dbo].[PayElementAccount] (
    [IdNo]           INT      IDENTITY (1, 1) NOT NULL,
    [PayElementIdNo] SMALLINT NULL,
    [PayGroupIdNo]   SMALLINT NULL,
    [EmployeeIdNo]   INT      NULL,
    [AccountIdNo]    SMALLINT NULL,
    [Sequence]       SMALLINT NULL,
    CONSTRAINT [PK_PayElementAccount] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

