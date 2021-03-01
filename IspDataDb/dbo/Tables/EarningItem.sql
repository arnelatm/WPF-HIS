CREATE TABLE [dbo].[EarningItem] (
    [IdNo]        SMALLINT       IDENTITY (1, 1) NOT NULL,
    [EarningIdNo] SMALLINT       NOT NULL,
    [Multiplier]  DECIMAL (8, 4) NOT NULL,
    CONSTRAINT [PK_EarningItem] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

