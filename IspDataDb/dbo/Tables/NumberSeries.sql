CREATE TABLE [dbo].[NumberSeries] (
    [SeriesName]   VARCHAR (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [CurrentValue] INT          NULL,
    CONSTRAINT [PK_NumberSeries] PRIMARY KEY CLUSTERED ([SeriesName] ASC)
);



