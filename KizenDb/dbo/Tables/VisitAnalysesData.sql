CREATE TABLE [dbo].[VisitAnalysesData] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [PatID]           INT            NULL,
    [PatName]         NVARCHAR (MAX) NULL,
    [RegDate]         DATE           NULL,
    [RegTime]         TIME (0)       NULL,
    [RegUserName]     NVARCHAR (MAX) NULL,
    [ReqNote]         NVARCHAR (MAX) NULL,
    [ResultTakenEnb]  BIT            NULL,
    [ResultTakenDate] DATETIME       NULL,
    [ResultNote]      NVARCHAR (MAX) NULL,
    [Data]            NVARCHAR (MAX) NULL,
    [Type]            NVARCHAR (50)  NULL,
    [TheSample]       NVARCHAR (MAX) NULL,
    [SadatTaken]      NVARCHAR (MAX) NULL,
    [DrManager]       NVARCHAR (MAX) NULL,
    [OutLab]          NVARCHAR (MAX) NULL,
    [OrderID]         INT            NULL,
    [LastEditUser]    NVARCHAR (255) NULL,
    [ReceivedDate]    DATETIME       NULL,
    [ReceivedUser]    NVARCHAR (255) NULL,
    [CollectedDate]   DATETIME       NULL,
    [CollectedUser]   NVARCHAR (255) NULL,
    [JME_Selected]    BIT            NULL,
    [VersionNumber]   NVARCHAR (50)  NULL,
    CONSTRAINT [PK_AnalysesData] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_VisitAnalysesData_OrderID]
    ON [dbo].[VisitAnalysesData]([OrderID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_VisitAnalysesData_RegDate_RegTime]
    ON [dbo].[VisitAnalysesData]([RegDate] ASC, [RegTime] ASC);

