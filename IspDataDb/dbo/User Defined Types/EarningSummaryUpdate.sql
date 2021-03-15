CREATE TYPE [dbo].[EarningSummaryUpdate] AS TABLE (
    [EarningSummaryIdNo] SMALLINT        NOT NULL,
    [EarningIdNo]      SMALLINT        NOT NULL,
    [IdNo]             INT             NOT NULL,
    [FactorValue]      DECIMAL (10, 4) NOT NULL,
    [FactorType]       CHAR(1)          NOT NULL,
    [Sequence]         SMALLINT        NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));

