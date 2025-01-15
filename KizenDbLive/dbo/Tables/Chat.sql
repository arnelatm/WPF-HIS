CREATE TABLE [dbo].[Chat] (
    [ChatID]      INT            IDENTITY (1, 1) NOT NULL,
    [SenderID]    INT            NULL,
    [SenderName]  NVARCHAR (MAX) NULL,
    [ReciverID]   INT            NULL,
    [ReciverName] NVARCHAR (MAX) NULL,
    [Type]        NVARCHAR (MAX) NULL,
    [Txt]         NVARCHAR (MAX) NULL,
    [Data]        NVARCHAR (MAX) NULL,
    [Date]        DATE           NULL,
    [Time]        TIME (0)       NULL,
    [SeenEnab]    BIT            NULL,
    [SeenDate]    DATETIME       NULL,
    [DllName]     NVARCHAR (100) NULL,
    CONSTRAINT [PK_Chat] PRIMARY KEY CLUSTERED ([ChatID] ASC)
);

