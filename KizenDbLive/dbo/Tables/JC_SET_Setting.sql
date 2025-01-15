CREATE TABLE [dbo].[JC_SET_Setting] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [SystemId] SMALLINT       NOT NULL,
    [Name]     NVARCHAR (50)  NULL,
    [Value]    NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.JC_SET_Setting] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_SystemId]
    ON [dbo].[JC_SET_Setting]([SystemId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SystemIdAndName]
    ON [dbo].[JC_SET_Setting]([SystemId] ASC, [Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JC_SET_Setting]([Name] ASC);

