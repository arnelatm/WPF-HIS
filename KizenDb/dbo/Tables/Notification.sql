CREATE TABLE [dbo].[Notification] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [SenderID]     INT            NULL,
    [SenderName]   NVARCHAR (255) NULL,
    [ReciverID]    INT            NULL,
    [ReciverName]  NVARCHAR (255) NULL,
    [Type]         NVARCHAR (MAX) NULL,
    [Txt]          NVARCHAR (MAX) NULL,
    [Data]         NVARCHAR (MAX) NULL,
    [Date]         DATE           NULL,
    [Time]         TIME (0)       NULL,
    [SeenEnab]     BIT            NULL,
    [SeenDate]     DATETIME       NULL,
    [DllName]      NVARCHAR (MAX) NULL,
    [UserNote]     NVARCHAR (MAX) NULL,
    [DataType]     NVARCHAR (50)  NULL,
    [DataID]       INT            NULL,
    [ReciverLevel] NVARCHAR (255) NULL,
    [DataID1]      INT            NULL,
    [Note1]        NVARCHAR (MAX) NULL,
    [Note2]        NVARCHAR (MAX) NULL,
    [Note3]        NVARCHAR (MAX) NULL,
    [Note4]        NVARCHAR (MAX) NULL,
    [Priority]     TINYINT        NULL,
    CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Notification_Date]
    ON [dbo].[Notification]([Date] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Notification_Filter1]
    ON [dbo].[Notification]([SeenEnab] ASC)
    INCLUDE([ReciverID], [ReciverName], [ReciverLevel]);


GO
CREATE NONCLUSTERED INDEX [IX_Notification_ReciverID]
    ON [dbo].[Notification]([ReciverID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Notification_ReciverLevel]
    ON [dbo].[Notification]([ReciverLevel] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Notification_ReciverName]
    ON [dbo].[Notification]([ReciverName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Notification_SeenEnab]
    ON [dbo].[Notification]([SeenEnab] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Notification_SenderID]
    ON [dbo].[Notification]([SenderID] ASC);

