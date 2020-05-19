CREATE TABLE [dbo].[Salt] (
    [IdNo]      INT          IDENTITY (1, 1) NOT NULL,
    [LoginIDNo] INT          NOT NULL,
    [Salt]      VARCHAR (50) NULL,
    [Modified]  ROWVERSION   NOT NULL,
    CONSTRAINT [PK_SaltIDNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

