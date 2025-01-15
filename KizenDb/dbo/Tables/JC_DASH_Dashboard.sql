CREATE TABLE [dbo].[JC_DASH_Dashboard] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Type]            INT             NOT NULL,
    [UserId]          INT             NULL,
    [UserName]        NVARCHAR (MAX)  NULL,
    [Name]            NVARCHAR (100)  NOT NULL,
    [Layout]          VARBINARY (MAX) NOT NULL,
    [CreatedDateTime] DATETIME        NOT NULL,
    CONSTRAINT [PK_dbo.JC_DASH_Dashboard] PRIMARY KEY CLUSTERED ([Id] ASC)
);

