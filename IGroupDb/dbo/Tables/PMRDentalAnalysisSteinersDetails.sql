CREATE TABLE [dbo].[PMRDentalAnalysisSteinersDetails] (
    [Trans_Key]    BIGINT       NOT NULL,
    [item_code]    VARCHAR (35) NULL,
    [da_actual]    VARCHAR (15) NULL,
    [da_inference] VARCHAR (25) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRDentalAnalysisSteinersDetails]
    ON [dbo].[PMRDentalAnalysisSteinersDetails]([Trans_Key] ASC, [item_code] ASC);

