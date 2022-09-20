CREATE TABLE [dbo].[PMRChiefComplaintDental] (
    [Trans_Key]   NUMERIC (10) DEFAULT (1) NULL,
    [RowNBR]      NUMERIC (10) DEFAULT (1) NULL,
    [ComplaintID] VARCHAR (15) NOT NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRChiefComplaintDental]
    ON [dbo].[PMRChiefComplaintDental]([Trans_Key] ASC, [RowNBR] ASC);

