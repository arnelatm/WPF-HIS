CREATE TABLE [dbo].[xxxLoginxxx] (
    [IDNo]              INT          IDENTITY (1, 1) NOT NULL,
    [LoginName]         VARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Password]          VARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Modified]          ROWVERSION   NOT NULL,
    [SecurityGroupIDNo] INT          NULL,
    CONSTRAINT [PK_LoginIDNo] PRIMARY KEY CLUSTERED ([IDNo] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_LoginName]
    ON [dbo].[xxxLoginxxx]([LoginName] ASC);

