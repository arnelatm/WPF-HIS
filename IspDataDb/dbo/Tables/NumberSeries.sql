CREATE TABLE [dbo].[NumberSeries] (
    [IdNo]         SMALLINT     IDENTITY (1, 1) NOT NULL,
    [SeriesName]   VARCHAR (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [CurrentValue] INT          NULL,
    CONSTRAINT [PK_NumberSeries] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





