CREATE TABLE [dbo].[Contact] (
    [IdNo]      INT      IDENTITY (1, 1) NOT NULL,
    [PayeeIdNo] INT      NULL,
    [PayeeType] CHAR (1) NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

