CREATE TYPE [dbo].[PayrollPayElementUpdate] AS TABLE (
    [Amount]                  MONEY    NULL,
    [IdNo]                    INT      NOT NULL,
    [PayElementIdNo]          SMALLINT NOT NULL,
    [PayrollDetailIdNo]       INT      NOT NULL,
    [RecurringPayElementIdNo] INT      NULL);





