CREATE TABLE [dbo].[PMRSignificantSignPatient] (
    [Trans_Key] NUMERIC (10) DEFAULT (1) NULL,
    [RowNBR]    NUMERIC (10) DEFAULT (1) NULL,
    [SSID]      VARCHAR (15) NOT NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRSignificantSignPatient]
    ON [dbo].[PMRSignificantSignPatient]([Trans_Key] ASC, [RowNBR] ASC);

