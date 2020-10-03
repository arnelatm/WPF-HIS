CREATE TYPE [dbo].[PayrollEarnAccountInsert] AS TABLE (
    [AccountIdNo]  SMALLINT NOT NULL,
    [EarningIdNo]  SMALLINT NOT NULL,
    [PayGroupIdNo] SMALLINT NOT NULL,
    [Sequence]     SMALLINT NOT NULL);

