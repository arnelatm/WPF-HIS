CREATE TABLE [dbo].[JTX_Tax] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [CompanyId]        INT             NOT NULL,
    [StartDate]        DATETIME        NOT NULL,
    [EndDate]          DATETIME        NOT NULL,
    [Note]             NVARCHAR (MAX)  NULL,
    [CreatedDateTime]  DATETIME        NOT NULL,
    [CreatedUserId]    INT             NOT NULL,
    [CreatedUserName]  NVARCHAR (MAX)  NOT NULL,
    [LastEditDateTime] DATETIME        NULL,
    [LastEditUserId]   INT             NULL,
    [LastEditUserName] NVARCHAR (MAX)  NULL,
    [VATPercent]       DECIMAL (18, 2) DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.JTX_Tax] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JTX_Tax_dbo.JTX_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JTX_Company] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JTX_Tax]([CompanyId] ASC);

