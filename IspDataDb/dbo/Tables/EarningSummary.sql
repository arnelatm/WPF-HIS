CREATE TABLE [dbo].[EarningSummary] (
    [IdNo]             SMALLINT        IDENTITY (1, 1) NOT NULL,
    [EarningSummaryIdNo] SMALLINT        NOT NULL,
    [EarningIdNo]      SMALLINT        NOT NULL,
    [FactorValue]       DECIMAL (10, 4) NOT NULL,
    [FactorType]       CHAR(1)         NOT NULL,
    [Sequence]         SMALLINT        NOT NULL,
    CONSTRAINT [PK_EarningSummary] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

