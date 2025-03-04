CREATE TABLE [dbo].[AppStat] (
    [AppStatTxt]   NVARCHAR (MAX) NULL,
    [AppStatID]    INT            IDENTITY (1, 1) NOT NULL,
    [AppStatColor] INT            NULL,
    CONSTRAINT [PK_AppStat] PRIMARY KEY CLUSTERED ([AppStatID] ASC)
);

