CREATE TABLE [dbo].[SecurityGroupAccess] (
    [IdNo]                INT      IDENTITY (1, 1) NOT NULL,
    [SecurityGroupIdNo]   SMALLINT NOT NULL,
    [SecurityControlIdNo] INT      NOT NULL,
    [Viewalble]           BIT      NOT NULL,
    [Editable]            BIT      NOT NULL,
    CONSTRAINT [PK_SecurityGroupAccess] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_SecurityGroupAccessSecurityControlIdNo]
    ON [dbo].[SecurityGroupAccess]([IdNo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SecurityGroupAccessSecurityGroupIdNo]
    ON [dbo].[SecurityGroupAccess]([SecurityGroupIdNo] ASC);

