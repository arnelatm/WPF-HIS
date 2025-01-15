CREATE TABLE [dbo].[MedicalReferral] (
    [ID]                 INT            IDENTITY (1, 1) NOT NULL,
    [TType]              NVARCHAR (255) NULL,
    [Cause]              NVARCHAR (255) NULL,
    [PatID]              INT            NULL,
    [Partner1Name]       NVARCHAR (255) NULL,
    [Partner1Nat]        NVARCHAR (255) NULL,
    [Partner1ID]         NVARCHAR (255) NULL,
    [Partner1Mobile]     NVARCHAR (255) NULL,
    [Partner2Name]       NVARCHAR (255) NULL,
    [Partner2Nat]        NVARCHAR (255) NULL,
    [Partner2ID]         NVARCHAR (255) NULL,
    [Partner2Mobile]     NVARCHAR (255) NULL,
    [DrID]               INT            NULL,
    [HistoryResult]      NVARCHAR (MAX) NULL,
    [Treatment]          NVARCHAR (MAX) NULL,
    [ToSection]          NVARCHAR (255) NULL,
    [ToName]             NVARCHAR (255) NULL,
    [Catagory]           NVARCHAR (MAX) NULL,
    [Diagnosis]          NVARCHAR (MAX) NULL,
    [ICD10]              NVARCHAR (MAX) NULL,
    [Date]               DATE           NULL,
    [Time]               TIME (0)       NULL,
    [UserName]           NVARCHAR (255) NULL,
    [ManagerDr]          NVARCHAR (255) NULL,
    [PatName]            NVARCHAR (MAX) NULL,
    [NoteType]           NVARCHAR (MAX) NULL,
    [NoteCause]          NVARCHAR (MAX) NULL,
    [Note]               NVARCHAR (MAX) NULL,
    [IsInternal]         BIT            NULL,
    [InternalDrName]     NVARCHAR (255) NULL,
    [SenderNote]         NVARCHAR (MAX) NULL,
    [ReceiverNote]       NVARCHAR (MAX) NULL,
    [LastModfiyUser]     NVARCHAR (255) NULL,
    [LastModifyDateTime] DATETIME       NULL,
    CONSTRAINT [PK_MedicalReferral] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_MedicalReferral_AppWait]
    ON [dbo].[MedicalReferral]([PatID] ASC, [Date] ASC, [Time] ASC, [DrID] ASC);

