CREATE TABLE [dbo].[CustomerHealthEvents] (
    [ID]                   INT            IDENTITY (1, 1) NOT NULL,
    [PatID]                INT            NULL,
    [PatName]              NVARCHAR (50)  NULL,
    [HealthStatuOtherID]   INT            NULL,
    [HealthStatuOtherName] NVARCHAR (50)  NULL,
    [Deatials]             NVARCHAR (MAX) NULL,
    [Note]                 NVARCHAR (MAX) NULL,
    [Date]                 DATE           NULL,
    [Time]                 TIME (0)       NULL,
    [User]                 NVARCHAR (50)  NULL,
    CONSTRAINT [PK_CustomerHealthEvents] PRIMARY KEY CLUSTERED ([ID] ASC)
);

