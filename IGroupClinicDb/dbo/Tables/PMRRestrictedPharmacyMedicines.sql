CREATE TABLE [dbo].[PMRRestrictedPharmacyMedicines] (
    [Item_Code] VARCHAR (15) NOT NULL,
    [RowNBR]    NUMERIC (5)  DEFAULT (1) NULL,
    [Covered]   CHAR (1)     DEFAULT ('N') NULL,
    [Approval]  CHAR (1)     DEFAULT ('N') NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRRestrictedPharmacyMedicines]
    ON [dbo].[PMRRestrictedPharmacyMedicines]([Item_Code] ASC);

