CREATE TYPE [dbo].[PayrollPayElementInsert] AS TABLE (
    [Amount]                  MONEY    NULL,
    [Generated]               BIT      NULL,
    [PayElementIdNo]          SMALLINT NOT NULL,
    [PayrollDetailIdNo]       INT      NOT NULL,
    [RecurringPayElementIdNo] INT      NULL);





