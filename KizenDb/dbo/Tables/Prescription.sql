CREATE TABLE [dbo].[Prescription] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [Date]           DATE           NULL,
    [Time]           TIME (0)       NULL,
    [PatID]          INT            NULL,
    [PatName]        NVARCHAR (255) NULL,
    [User]           NVARCHAR (255) NULL,
    [PresNote]       NVARCHAR (MAX) NULL,
    [EditedUserName] NVARCHAR (255) NULL,
    [BirthdayStr]    NVARCHAR (255) NULL,
    [SetAsFavorite]  BIT            NULL,
    [FavoriteNote]   NVARCHAR (MAX) NULL,
    [Invoiced]       BIT            NULL,
    [JME_Selected]   BIT            NULL,
    CONSTRAINT [PK_Prescription] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_Prescription_AppWait]
    ON [dbo].[Prescription]([PatID] ASC, [Date] ASC, [Time] ASC, [User] ASC);

