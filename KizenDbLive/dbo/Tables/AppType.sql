CREATE TABLE [dbo].[AppType] (
    [AppTypeID]    INT            IDENTITY (1, 1) NOT NULL,
    [AppTypeTxt]   NVARCHAR (MAX) NULL,
    [AppTypeColor] INT            NULL,
    [Type]         NVARCHAR (50)  NULL,
    CONSTRAINT [PK_AppType] PRIMARY KEY CLUSTERED ([AppTypeID] ASC)
);

