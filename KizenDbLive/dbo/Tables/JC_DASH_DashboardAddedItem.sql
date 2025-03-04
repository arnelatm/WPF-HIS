CREATE TABLE [dbo].[JC_DASH_DashboardAddedItem] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [DashboardId] INT            NOT NULL,
    [Name]        NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_dbo.JC_DASH_DashboardAddedItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JC_DASH_DashboardAddedItem_dbo.JC_DASH_Dashboard_DashboardId] FOREIGN KEY ([DashboardId]) REFERENCES [dbo].[JC_DASH_Dashboard] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_DashboardIdAndName]
    ON [dbo].[JC_DASH_DashboardAddedItem]([DashboardId] ASC, [Name] ASC);

