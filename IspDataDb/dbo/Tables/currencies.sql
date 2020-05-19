CREATE TABLE [dbo].[currencies] (
    [id]            UNIQUEIDENTIFIER CONSTRAINT [DF_currencies_id] DEFAULT (newid()) NOT NULL,
    [number]        INT              NOT NULL,
    [number_string] NVARCHAR (MAX)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    CONSTRAINT [PK_currencies] PRIMARY KEY CLUSTERED ([id] ASC)
);

