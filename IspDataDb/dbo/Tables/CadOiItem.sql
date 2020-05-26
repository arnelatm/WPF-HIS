CREATE TABLE [dbo].[CadOiItem] (
    [IdNo]            INT   NOT NULL,
    [CadIdNo]         INT   NOT NULL,
    [JournalItemIdNo] INT   NOT NULL,
    [Sequence]        INT   NOT NULL,
    [Amount]          MONEY NOT NULL,
    [DiscountTaken]   MONEY NOT NULL,
    CONSTRAINT [PK_CadOiItemIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



