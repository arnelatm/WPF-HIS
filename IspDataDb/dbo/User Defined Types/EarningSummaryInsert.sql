CREATE TYPE [dbo].[EarningSummaryInsert] AS TABLE (
    [EarningSummaryIdNo] SMALLINT        NOT NULL,
    [EarningIdNo]      SMALLINT        NOT NULL,
    [FactorType]       CHAR(1)         NOT NULL,
    [FactorValue]       DECIMAL (10, 4) NOT NULL,
    [Sequence]         SMALLINT        NOT NULL);

