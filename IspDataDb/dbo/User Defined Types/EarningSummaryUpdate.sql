CREATE TYPE [dbo].[EarningSummaryUpdate] AS TABLE (
    [EarningSummaryIdNo] SMALLINT        NOT NULL,
    [EarningIdNo]      SMALLINT        NOT NULL,
    [IdNo]             INT             NOT NULL,
    [Multiplier]       DECIMAL (10, 4) NOT NULL,
    [Sequence]         SMALLINT        NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));

