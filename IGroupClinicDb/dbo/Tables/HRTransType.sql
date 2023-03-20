CREATE TABLE [dbo].[HRTransType] (
    [TransID]           VARCHAR (15)  NOT NULL,
    [Description]       VARCHAR (50)  NOT NULL,
    [DescriptionArabic] NVARCHAR (50) NULL,
    [ACCode]            VARCHAR (15)  NULL,
    [AddLess]           INT           NULL,
    [Remarks]           VARCHAR (100) NULL
);

