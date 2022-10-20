CREATE TABLE [dbo].[Lab_SampleMaster] (
    [Trans_Key]         INT           IDENTITY (1, 1) NOT NULL,
    [SampleID]          VARCHAR (15)  NOT NULL,
    [SampleNameEnglish] VARCHAR (50)  NOT NULL,
    [SampleNameArabic]  NVARCHAR (50) NULL,
    [Active]            INT           NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_Lab_SampleMaster]
    ON [dbo].[Lab_SampleMaster]([SampleID] ASC);

