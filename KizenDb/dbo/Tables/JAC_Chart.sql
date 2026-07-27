CREATE TABLE [dbo].[JAC_Chart] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]        INT            NOT NULL,
    [Title]            NVARCHAR (250) NULL,
    [Kind]             INT            NOT NULL,
    [Data]             NVARCHAR (MAX) NULL,
    [Height]           INT            NOT NULL,
    [Width]            INT            NOT NULL,
    [Style3D]          BIT            DEFAULT ((0)) NOT NULL,
    [TitleLatin]       NVARCHAR (250) NULL,
    [ShowInHomeScreen] BIT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.JAC_Chart] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_Chart_dbo.JAC_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JAC_Company] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Title]
    ON [dbo].[JAC_Chart]([Title] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndTitle]
    ON [dbo].[JAC_Chart]([CompanyId] ASC, [Title] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JAC_Chart]([CompanyId] ASC);

