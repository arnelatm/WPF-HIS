CREATE TABLE [dbo].[City] (
    [CityID]   INT           IDENTITY (1, 1) NOT NULL,
    [CityName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED ([CityID] ASC)
);

