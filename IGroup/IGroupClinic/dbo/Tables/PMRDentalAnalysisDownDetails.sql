CREATE TABLE [dbo].[PMRDentalAnalysisDownDetails] (
    [Trans_key]    BIGINT       NOT NULL,
    [Item_Code]    VARCHAR (35) NULL,
    [da_actual]    VARCHAR (15) NULL,
    [da_inference] VARCHAR (25) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRDentalAnalysisDownDetails]
    ON [dbo].[PMRDentalAnalysisDownDetails]([Trans_key] ASC, [Item_Code] ASC);

