CREATE TABLE [dbo].[JC_GridSetting] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [GridId]     INT            NOT NULL,
    [DeviceName] NVARCHAR (255) NOT NULL,
    [UserId]     INT            NULL,
    [Layout]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.JC_GridSetting] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JC_GridSetting_dbo.JC_Grid_GridId] FOREIGN KEY ([GridId]) REFERENCES [dbo].[JC_Grid] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_GridId]
    ON [dbo].[JC_GridSetting]([GridId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_GridAndDeviceAndUser]
    ON [dbo].[JC_GridSetting]([GridId] ASC, [DeviceName] ASC, [UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DeviceName]
    ON [dbo].[JC_GridSetting]([DeviceName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[JC_GridSetting]([UserId] ASC);

