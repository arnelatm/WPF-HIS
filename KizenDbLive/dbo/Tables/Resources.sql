CREATE TABLE [dbo].[Resources] (
    [ResourcesID]   INT           IDENTITY (1, 1) NOT NULL,
    [ResourcesName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Resources] PRIMARY KEY CLUSTERED ([ResourcesID] ASC)
);

