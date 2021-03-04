CREATE TYPE [dbo].[EarningSummaryInsert] AS TABLE (
    [EarningSummaryIdNo] SMALLINT        NOT NULL,
    [EarningIdNo]      SMALLINT        NOT NULL,
    [Multiplier]       DECIMAL (10, 4) NOT NULL,
    [Sequence]         SMALLINT        NOT NULL);

