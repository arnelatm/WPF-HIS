CREATE TABLE [dbo].[PMRRestrictedInvestigations] (
    [Item_Code] VARCHAR (15) NOT NULL,
    [RowNBR]    NUMERIC (5)  DEFAULT (1) NULL,
    [Days]      NUMERIC (5)  DEFAULT (1) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRRestrictedInvestigations]
    ON [dbo].[PMRRestrictedInvestigations]([Item_Code] ASC);

