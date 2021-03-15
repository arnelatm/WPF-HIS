CREATE TABLE [dbo].[EarningSummary] (
    [IdNo]             SMALLINT        IDENTITY (1, 1) NOT NULL,
    [EarningSummaryIdNo] SMALLINT        NULL,
    [EarningIdNo]      SMALLINT        NULL,
    [FactorValue]       DECIMAL (10, 4) NULL,
    [FactorType]       CHAR(1)         NOT NULL,
    [Sequence]         SMALLINT        NULL,
    CONSTRAINT [PK_EarningSummary] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

