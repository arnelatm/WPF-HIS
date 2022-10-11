CREATE TABLE [dbo].[PMRDentalAnalysis] (
    [Trans_key]     BIGINT         NOT NULL,
    [analysis1]     TEXT           NULL,
    [analysis2]     TEXT           NULL,
    [History]       NVARCHAR (300) NULL,
    [onExamination] NVARCHAR (300) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRDentalAnalysis]
    ON [dbo].[PMRDentalAnalysis]([Trans_key] ASC);

