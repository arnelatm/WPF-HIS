CREATE TABLE [dbo].[EarningSummary] (
    [IdNo]        SMALLINT       IDENTITY (1, 1) NOT NULL,
    [EarningIdNo] SMALLINT       NOT NULL,
    [Multiplier]  DECIMAL (8, 4) NOT NULL,
    CONSTRAINT [PK_EarningSummary] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

