CREATE TABLE [dbo].[HealthStatOtherType] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [Caption]        NVARCHAR (50) NULL,
    [Specialization] NVARCHAR (50) NULL,
    [DefalutValue]   NVARCHAR (50) NULL,
    [Image]          IMAGE         NULL,
    CONSTRAINT [PK_HealthStatOtherType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

