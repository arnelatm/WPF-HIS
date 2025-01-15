CREATE TABLE [dbo].[UserSty] (
    [ID]     INT            IDENTITY (1, 1) NOT NULL,
    [Type]   NVARCHAR (50)  NULL,
    [Name]   NVARCHAR (255) NULL,
    [Data]   NVARCHAR (MAX) NULL,
    [UserID] INT            NULL,
    CONSTRAINT [PK_UserSty] PRIMARY KEY CLUSTERED ([ID] ASC)
);

