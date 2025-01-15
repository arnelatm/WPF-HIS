CREATE TABLE [dbo].[A1_WorksSession] (
    [ID]                  INT            IDENTITY (1, 1) NOT NULL,
    [WorkID]              INT            NOT NULL,
    [Description]         NVARCHAR (MAX) NOT NULL,
    [Days]                INT            NOT NULL,
    [HasFollowUp]         BIT            NOT NULL,
    [FollowUpDescription] NVARCHAR (MAX) NULL,
    [FollowUpDays]        INT            NULL,
    [FollowUpIsExpired]   BIT            NULL,
    [Note]                NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_A1_WorksSession] PRIMARY KEY CLUSTERED ([ID] ASC)
);

