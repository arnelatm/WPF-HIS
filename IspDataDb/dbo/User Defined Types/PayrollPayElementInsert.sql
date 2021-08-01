CREATE TYPE [dbo].[PayrollPayElementInsert] AS TABLE (
    [Amount]                  MONEY    NULL,
    [PayElementIdNo]          SMALLINT NOT NULL,
    [PayrollDetailIdNo]       INT      NOT NULL,
    [RecurringPayElementIdNo] INT      NULL);



