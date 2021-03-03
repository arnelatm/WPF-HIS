CREATE TABLE [dbo].[EarningSummary] (
    [IdNo]             SMALLINT        IDENTITY (1, 1) NOT NULL,
    [EarningGroupIdNo] SMALLINT        NULL,
    [EarningIdNo]      SMALLINT        NULL,
    [Multiplier]       DECIMAL (10, 4) NULL,
    [Sequence]         SMALLINT        NULL,
    CONSTRAINT [PK_EarningSummary] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

