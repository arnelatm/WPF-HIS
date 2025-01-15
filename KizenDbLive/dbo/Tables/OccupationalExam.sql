CREATE TABLE [dbo].[OccupationalExam] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [DateTime]      DATETIME       NULL,
    [CustID]        INT            NULL,
    [PhysicianData] NVARCHAR (MAX) NULL,
    [XRayData]      NVARCHAR (MAX) NULL,
    [LabData]       NVARCHAR (MAX) NULL,
    [Divison]       NVARCHAR (255) NULL,
    [PhysicianName] NVARCHAR (255) NULL,
    [Comment]       NVARCHAR (MAX) NULL,
    [BadgeNo]       NVARCHAR (255) NULL,
    CONSTRAINT [PK_OccupationalExam] PRIMARY KEY CLUSTERED ([ID] ASC)
);

