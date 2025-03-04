CREATE TABLE [dbo].[Notification_Type] (
    [ID]  INT           IDENTITY (1, 1) NOT NULL,
    [Txt] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Notification_Type] PRIMARY KEY CLUSTERED ([ID] ASC)
);

