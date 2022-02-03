CREATE TABLE [dbo].[PayrollPayElement] (
    [IdNo]                    INT      IDENTITY (1, 1) NOT NULL,
    [PayrollDetailIdNo]       INT      NULL,
    [PayElementIdNo]          SMALLINT NULL,
    [Amount]                  MONEY    NULL,
    [Active]                  BIT      NULL,
    [RecurringPayElementIdNo] INT      NULL,
    [RecurType]              CHAR (1) NULL,
    [Generated]               BIT      NULL
);







