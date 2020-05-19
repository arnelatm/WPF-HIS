CREATE TABLE [dbo].[Series] (
    [IdNo]        INT          IDENTITY (1, 1) NOT NULL,
    [SeriesName]  VARCHAR (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Value]       INT          NULL,
    [Prefix]      VARCHAR (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Suffix]      VARCHAR (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [MaxLength]   INT          NULL,
    [Description] VARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [PK_Series] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

