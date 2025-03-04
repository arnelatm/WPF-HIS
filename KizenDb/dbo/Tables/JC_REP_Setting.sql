CREATE TABLE [dbo].[JC_REP_Setting] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [HeaderImageArray] VARBINARY (MAX) NULL,
    [FooterImageArray] VARBINARY (MAX) NULL,
    CONSTRAINT [PK_dbo.JC_REP_Setting] PRIMARY KEY CLUSTERED ([Id] ASC)
);

