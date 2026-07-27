CREATE TABLE [dbo].[Documents] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Note]         NVARCHAR (MAX) NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [DllName]      NVARCHAR (50)  NULL,
    [EndID]        NVARCHAR (255) NULL,
    [SourceType]   NVARCHAR (50)  NULL,
    [Type]         NVARCHAR (MAX) NULL,
    [DateTime]     DATETIME       NULL,
    [UserID]       INT            NULL,
    [UserName]     NVARCHAR (MAX) NULL,
    [DeviceName]   NVARCHAR (MAX) NULL,
    [OnlineEnb]    BIT            NULL,
    [OnlineDone]   BIT            NULL,
    [OnlineInfo]   NVARCHAR (MAX) NULL,
    [UserRefID]    INT            NULL,
    [UserRefName]  NVARCHAR (255) NULL,
    [JME_Selected] BIT            NULL,
    CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_Documents_AppWait]
    ON [dbo].[Documents]([EndID] ASC, [DateTime] ASC, [SourceType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Documents_AppWaitUserRef]
    ON [dbo].[Documents]([EndID] ASC, [DateTime] ASC, [SourceType] ASC, [UserRefID] ASC);

