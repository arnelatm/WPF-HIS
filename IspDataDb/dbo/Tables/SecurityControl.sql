CREATE TABLE [dbo].[SecurityControl] (
    [IdNo]                INT                 IDENTITY (1, 1) NOT NULL,
    [SystemViewIdNo]      SMALLINT            NULL,
    [SecurityControlName] VARCHAR (100)       NULL,
    [ParentIdNo]          [sys].[hierarchyid] NULL,
    CONSTRAINT [PK_SecurityControl] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SecurityControlNameNViewIdNo]
    ON [dbo].[SecurityControl]([SecurityControlName] ASC, [IdNo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SecurityControlSecurityControlName]
    ON [dbo].[SecurityControl]([SecurityControlName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SecurityControlSystemViewIdNo]
    ON [dbo].[SecurityControl]([SystemViewIdNo] ASC);

