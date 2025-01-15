CREATE TABLE [dbo].[HealthStatType] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NULL,
    [LatinName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_HealthStatType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

