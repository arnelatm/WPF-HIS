CREATE TABLE [dbo].[A1_Works_CustomPrice] (
    [ID]             INT             IDENTITY (1, 1) NOT NULL,
    [WorkCode]       NVARCHAR (MAX)  NULL,
    [SourceCode]     NVARCHAR (MAX)  NULL,
    [SourceType]     NVARCHAR (50)   NULL,
    [CustomCode]     NVARCHAR (MAX)  NULL,
    [CustomName]     NVARCHAR (MAX)  NULL,
    [Price]          DECIMAL (18, 2) NULL,
    [CustomCCHICode] NVARCHAR (255)  NULL,
    [CustomCCHIName] NVARCHAR (255)  NULL,
    CONSTRAINT [PK_A1_Works_CustomPrice] PRIMARY KEY CLUSTERED ([ID] ASC)
);

