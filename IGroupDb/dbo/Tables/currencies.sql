CREATE TABLE [dbo].[currencies] (
    [id]            UNIQUEIDENTIFIER CONSTRAINT [DF_currencies_id] DEFAULT (newid()) NOT NULL,
    [number]        INT              NOT NULL,
    [number_string] NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_currencies] PRIMARY KEY CLUSTERED ([id] ASC)
);

