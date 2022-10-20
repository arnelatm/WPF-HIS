CREATE TABLE [dbo].[MasterCreationDetails] (
    [Primary_Key]    INT           IDENTITY (1, 1) NOT NULL,
    [TagName]        VARCHAR (25)  NOT NULL,
    [TableName]      VARCHAR (30)  NOT NULL,
    [Caption]        VARCHAR (35)  NOT NULL,
    [Icon]           VARCHAR (50)  NULL,
    [lblID]          VARCHAR (30)  NULL,
    [lblNameEnglish] VARCHAR (30)  DEFAULT ('W') NULL,
    [lblNameArabic]  NVARCHAR (30) NULL,
    [lblValue]       VARCHAR (30)  NULL,
    [lblActivate]    VARCHAR (30)  NULL,
    PRIMARY KEY CLUSTERED ([Primary_Key] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_MasterCreationDetails]
    ON [dbo].[MasterCreationDetails]([TagName] ASC);

