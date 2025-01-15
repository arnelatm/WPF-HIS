CREATE TABLE [dbo].[ThtEvents] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [Date]                   DATE           NULL,
    [Time]                   TIME (0)       NULL,
    [User]                   NVARCHAR (255) NULL,
    [TthCode]                NVARCHAR (MAX) NULL,
    [TthPro]                 NVARCHAR (MAX) NULL,
    [TthTreat]               NVARCHAR (MAX) NULL,
    [PatId]                  INT            NULL,
    [PatName]                NVARCHAR (255) NULL,
    [URTthCode]              NVARCHAR (255) NULL,
    [ULTthCode]              NVARCHAR (255) NULL,
    [LRTthCode]              NVARCHAR (255) NULL,
    [LLTthCode]              NVARCHAR (255) NULL,
    [LastModfiyUser]         NVARCHAR (255) NULL,
    [LastModifyDateTime]     DATETIME       NULL,
    [TthMC]                  NVARCHAR (MAX) NULL,
    [TthMedicalDiagnosis]    NVARCHAR (MAX) NULL,
    [Anesthesia]             NVARCHAR (MAX) NULL,
    [Outcomes]               NVARCHAR (MAX) NULL,
    [NextVisit]              NVARCHAR (MAX) NULL,
    [ProphylaxisAntibiotic]  NVARCHAR (MAX) NULL,
    [PatientFamilyEducation] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ThtEvents] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_ThtEvents_AppWait]
    ON [dbo].[ThtEvents]([PatId] ASC, [Date] ASC, [Time] ASC, [User] ASC);

