CREATE TABLE [dbo].[HolidayType] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NULL,
    CONSTRAINT [PK_HolidayType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

