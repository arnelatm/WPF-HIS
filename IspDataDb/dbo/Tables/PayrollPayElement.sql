CREATE TABLE [dbo].[PayrollPayElement] (
    [IdNo]              INT      IDENTITY (1, 1) NOT NULL,
    [PayrollDetailIdNo] INT      NULL,
    [PayElementIdNo]    SMALLINT NULL,
    [Amount]            MONEY    NULL
);

