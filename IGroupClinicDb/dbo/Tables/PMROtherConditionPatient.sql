CREATE TABLE [dbo].[PMROtherConditionPatient] (
    [Trans_Key] NUMERIC (10) DEFAULT (1) NULL,
    [RowNBR]    NUMERIC (10) DEFAULT (1) NULL,
    [OCID]      VARCHAR (15) NOT NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMROtherConditionPatient]
    ON [dbo].[PMROtherConditionPatient]([Trans_Key] ASC, [RowNBR] ASC);

