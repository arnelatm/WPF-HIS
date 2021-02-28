CREATE TABLE [dbo].[EarningGroupItems] (
    [IdNo]             SMALLINT IDENTITY (1, 1) NOT NULL,
    [EarningGroupIdNo] SMALLINT NULL,
    [EarningIdNo]      SMALLINT NULL,
    CONSTRAINT [PK_EarningGroupItemsIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

