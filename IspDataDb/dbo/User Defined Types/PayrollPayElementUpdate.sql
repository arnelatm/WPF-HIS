CREATE TYPE [dbo].[PayrollPayElementUpdate] AS TABLE (
    [Amount]               MONEY    NULL,
    [IdNo]                 INT      NOT NULL,
    [PayElementIdNo]       SMALLINT NOT NULL,
    [PayrollPayDetailIdNo] INT      NOT NULL);

