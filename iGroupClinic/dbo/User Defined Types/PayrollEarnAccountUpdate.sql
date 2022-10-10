CREATE TYPE [dbo].[PayrollEarnAccountUpdate] AS TABLE (
    [AccountIdNo]  SMALLINT NOT NULL,
    [EarningIdNo]  SMALLINT NOT NULL,
    [IdNo]         INT      NOT NULL,
    [PayGroupIdNo] SMALLINT NOT NULL,
    [Sequence]     SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));

