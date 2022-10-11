CREATE TABLE [dbo].[Lab_SampleCollectionDetails] (
    [Group_Key] NUMERIC (12) NOT NULL,
    [SampleNo]  NUMERIC (10) NOT NULL,
    [SampleID]  VARCHAR (15) NOT NULL,
    [Taken]     INT          DEFAULT ((0)) NULL,
    [Pass]      INT          DEFAULT ((0)) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_Lab_SampleCollectionDetails]
    ON [dbo].[Lab_SampleCollectionDetails]([Group_Key] ASC, [SampleNo] ASC, [SampleID] ASC);

