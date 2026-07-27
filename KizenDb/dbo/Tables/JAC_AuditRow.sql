CREATE TABLE [dbo].[JAC_AuditRow] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]        INT            NOT NULL,
    [Code]             NVARCHAR (250) NOT NULL,
    [Note]             NVARCHAR (250) NULL,
    [BackColorArgb]    INT            NOT NULL,
    [ForeColorArgb]    INT            NOT NULL,
    [FontName]         NVARCHAR (100) NULL,
    [FontSize]         REAL           NOT NULL,
    [Bold]             BIT            NOT NULL,
    [Italic]           BIT            NOT NULL,
    [Underline]        BIT            NOT NULL,
    [Strikeout]        BIT            NOT NULL,
    [UserId]           INT            NULL,
    [UserName]         NVARCHAR (250) NULL,
    [UserIdLastEdit]   INT            NULL,
    [UserNameLastEdit] NVARCHAR (250) NULL,
    CONSTRAINT [PK_dbo.JAC_AuditRow] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_AuditRow_dbo.JAC_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JAC_Company] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JAC_AuditRow]([Code] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndCode]
    ON [dbo].[JAC_AuditRow]([CompanyId] ASC, [Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JAC_AuditRow]([CompanyId] ASC);

