CREATE TABLE [dbo].[Lab_Antibiotic_Culture] (
    [ID]          CHAR (1)     NULL,
    [ACID]        NUMERIC (5)  NULL,
    [ACName]      VARCHAR (50) NULL,
    [PrintStatus] INT          NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_Lab_Antibiotic_Culture]
    ON [dbo].[Lab_Antibiotic_Culture]([ID] ASC, [ACID] ASC);

