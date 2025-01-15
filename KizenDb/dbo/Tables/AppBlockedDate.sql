CREATE TABLE [dbo].[AppBlockedDate] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [ResourceID]   INT            NULL,
    [BlcoedDate]   DATE           NULL,
    [BlockedTxt]   NVARCHAR (MAX) NULL,
    [BlcoedDateTo] DATE           NULL,
    CONSTRAINT [PK_AppBlockedDate] PRIMARY KEY CLUSTERED ([ID] ASC)
);

