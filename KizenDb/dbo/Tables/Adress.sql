CREATE TABLE [dbo].[Adress] (
    [AdressName] NVARCHAR (MAX) NULL,
    [AdressID]   INT            IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED ([AdressID] ASC)
);

